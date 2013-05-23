using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Touchdown.SensorAbstraction;

namespace Touchdown.Core {
	/// <summary>
	/// Creates a background model by all given <see cref="DepthFrame"/>s that can be used by the
	/// <see cref="SimpleTouchAreaObserver"/>.
	/// </summary>
	public class BackgroundModelCreator {
		private DepthFrameList _Frames;

		/// <summary>
		/// New instance of a creator. Can create a simple background model from depthframes used
		/// by the <see cref="SimpleTouchAreaObserver" />
		/// </summary>
		public BackgroundModelCreator(){ 
			_Frames = new DepthFrameList();
		}

		#region Public Methods
		/// <summary>
		/// Clears all currently gathered frames to create a completely new background model.
		/// </summary>
		public void Clear(){
			_Frames.Clear();
		}

		/// <summary>
		/// Add another depthframe that should be part of the background model.
		/// </summary>
		/// <param name="frame">frame to add</param>
		public void Add(DepthFrame frame){
			_Frames.Add(frame);
		}
		
		/// <summary>
		/// Calculates the background model for all currently gathered frames.
		/// </summary>
		/// <exception cref="InvalidOperationException">If no frames are gathered yet.</exception>
		/// <returns>Depthframe that represents the background.</returns>
		public DepthFrame GetBackgroundModel(){
			return _Frames.CalculateAverage();
		}
		#endregion
	
		public int FrameCount{get{return _Frames.Count;}} 
	}
}
