using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Touchdown.Core;
using Touchdown.SensorAbstraction;
using System.Threading.Tasks;

namespace Touchdown.Core.PatternRecognition {
	
	/// <summary>
	/// Tries to recognize patterns 
	/// </summary>
	public class TouchPatternRecognizer {
		
		#region Members
		ITouchObserver<SimpleTouchFrame> observer;
		ITouchPatternComparer patternComparer;
		List<TouchPattern> registeredPatters;

		TouchPattern recordingPattern;
		TouchPattern lastRecognizedPatter;

		int consecutiveNullFrames;
		#endregion

		#region Object events
		/// <summary>
		/// Fired when a recorded pattern was recognized
		/// </summary>
		public event EventHandler<TouchPatternRecognizedEventArgs> TouchPatternRecognized;
		
		/// <summary>
		/// Fired when a touch pattern is recognized while still recording. Must not be the pattern
		/// that is recognized when the recording is finished.
		/// </summary>
		public event EventHandler<TouchPatternRecognizedEventArgs> TouchPatternPartiallyRecognized;

		/// <summary>
		/// Fired when a frame was added to the recorded touchpattern.
		/// </summary>
		public event EventHandler<TouchPatternRecordingEventArgs> TouchPatternRecording;
		#endregion

		#region Constructors
		/// <summary>
		/// Creates a empty instance of the patterrecognizer that uses the given comparer
		/// to compare patterns.
		/// </summary>
		/// <param name="provider">Provider of the single touch frames that should be used for
		/// recognition.</param>
		/// <param name="comparer">comparer that is used to compare patterns</param>
		/// <param name="consecutiveNullFrames">max count of frames that have no touchpoints - end of recording</param>
		/// <param name="threshold">value that defines a pattern as recognized.</param>
		public TouchPatternRecognizer(ITouchObserver<SimpleTouchFrame> provider, 
									  ITouchPatternComparer comparer, 
									  double threshold, 
									  int consecutiveNullFrames){
			this.patternComparer = comparer;
			this.observer = provider;
			this.MaxDistancePerPixel = threshold;
			this.MaxConsecutiveNullFrames = consecutiveNullFrames;
	
			this.registeredPatters = new List<TouchPattern>();
			this.recordingPattern = new TouchPattern();
			this.lastRecognizedPatter = new TouchPattern();
			this.consecutiveNullFrames = 0;
			
			
			this.observer.TouchFrameReady += observer_TouchFrameReady;
		}

		#endregion

		#region Public Methods
		/// <summary>
		/// Registers the given touch pattern for recognition. Pattern will be normalized first.
		/// </summary>
		/// <param name="pattern">Pattern to register.</param>
		public void RegisterPattern(TouchPattern pattern){
			if (pattern == null) { 
				throw new System.ArgumentNullException("pattern");
			}

			// normalize pattern
			pattern = pattern.Normalize();

			this.registeredPatters.Add(pattern);
		}
		#endregion

		#region Private Methods
		void observer_TouchFrameReady(object sender, FrameReadyEventArgs<SimpleTouchFrame> e) {
			if (e.FrameData.TouchPoints.Count == 0) {
				consecutiveNullFrames++;
			} else { 
				consecutiveNullFrames = 0;
			}
			
			// reset pattern and try end-recognition of pattern
			if (consecutiveNullFrames >= this.MaxConsecutiveNullFrames) {
				if (recordingPattern.Frames.Any(f => f.TouchPoints.Count > 0)){
					// when whole pattern is recognized raise event
					if (this.TouchPatternRecognized != null) { 
						var result = TryRecognize();
						if (result != null) {
							this.TouchPatternRecognized(this, result);
						}
					}
				}

				// reset recording pattern
				recordingPattern.Dispose();
				recordingPattern = new TouchPattern();

				consecutiveNullFrames = 0;
			}

			// Add current frame to recording
			recordingPattern.AddFrame(e.FrameData);
			if (this.TouchPatternRecording != null) { 
				var recArgs = new TouchPatternRecordingEventArgs(DateTime.Now, recordingPattern, e.FrameData);
				this.TouchPatternRecording(this, recArgs);
			}
			
			// try partial recognition
			if (this.TouchPatternPartiallyRecognized != null) { 
				if (recordingPattern.Frames.Any(f => f.TouchPoints.Count > 0)){
					// try partial recognition.
					var result = TryRecognize();
					if (result != null) { 
						this.TouchPatternPartiallyRecognized(this, result);
					}
				}
			}
			
		}
		
		private TouchPatternRecognizedEventArgs TryRecognize(){
			TouchPatternRecognizedEventArgs result = null;

			TouchPattern lowestPattern = null;
			double lowest = double.MaxValue;

			Parallel.ForEach(this.registeredPatters, pattern => {
				double current = patternComparer.Compare(pattern, recordingPattern);

				if (current < lowest) { 
					lowestPattern = pattern;
					lowest = current;
				}
			});

			if (lowest < this.MaxDistancePerPixel) { 
				var startPoint = recordingPattern.Frames.SelectMany(f => f.TouchPoints).First();
				result = new TouchPatternRecognizedEventArgs(DateTime.Now, this.recordingPattern, lowestPattern, lowest, new TimeSpan(), startPoint);
			}

			return result;
		}
		#endregion

		#region Propeties
		/// <summary>
		/// Gets readonly access to all currently registered patterns.
		/// </summary>
		public ReadOnlyCollection<TouchPattern> RegisteredPatterns{
			get{
				return this.registeredPatters.AsReadOnly();
			}
		}

		/// <summary>
		/// gets or sets the max distance per pixel for recognition.
		/// </summary>
		public double MaxDistancePerPixel{
			get; set;
		}
		
		/// <summary>
		/// gets or sets the amount of null frames that is considered an end of a pattern.
		/// </summary>
		public int MaxConsecutiveNullFrames{get;set;}
		#endregion
	}
}
