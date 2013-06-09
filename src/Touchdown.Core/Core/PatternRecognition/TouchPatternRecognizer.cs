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
		SimpleTouchPatternComparer patternComparer;
		List<TouchPattern> registeredPatters;
		double threshold;

		TouchPattern recordingPattern;
		TouchPattern lastRecognizedPatter;

		int consecutiveNullFrames;
		int maxConsecutiveNullFrames;
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
									  SimpleTouchPatternComparer comparer, 
									  double threshold, 
									  int consecutiveNullFrames){
			this.patternComparer = comparer;
			this.threshold = threshold;
			this.observer = provider;

			this.registeredPatters = new List<TouchPattern>();
			this.recordingPattern = new TouchPattern();
			this.lastRecognizedPatter = new TouchPattern();
			this.consecutiveNullFrames = 0;
			this.maxConsecutiveNullFrames = consecutiveNullFrames;

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
			if (consecutiveNullFrames >= maxConsecutiveNullFrames) {
				// when whole pattern is recognized raise event
				if (this.TouchPatternRecognized != null) { 
					var result = TryRecognize();
					if (result != null) { 
						this.TouchPatternRecognized(this, result);
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
				// try partial recognition.
				var result = TryRecognize();
				if (result != null) { 
					this.TouchPatternPartiallyRecognized(this, result);
				}
			}
			
		}
		
		private TouchPatternRecognizedEventArgs TryRecognize(){
			TouchPatternRecognizedEventArgs result = null;

			Parallel.ForEach(this.registeredPatters, pattern => {
				patternComparer.Compare(recordingPattern, pattern);
			});

			return result;
		}
		#endregion

		#region Propeties
		/// <summary>
		/// Gets readonly access to all currently registered patterns.
		/// </summary>
		public ReadOnlyCollection<TouchPattern> RegisteredPatters{
			get{
				return this.registeredPatters.AsReadOnly();
			}
		}
		#endregion
	}
}
