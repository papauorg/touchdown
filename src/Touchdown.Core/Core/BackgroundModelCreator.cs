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
	public abstract class BackgroundModelCreator<TFrame> : IDisposable where TFrame : Frame {

		#region Members
		protected int framewidth, frameheight;
		#endregion

		#region Constructors
		/// <summary>
		/// New instance of a creator. Can create a simple background model from depthframes used
		/// by the <see cref="SimpleTouchAreaObserver" />
		/// </summary>
		public BackgroundModelCreator(){ 
			this.FrameCount = 0;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Clears all currently gathered frames to create a completely new background model.
		/// </summary>
		public virtual void Clear(){
			this.FrameCount = 0;
		}

		/// <summary>
		/// Add another depthframe that should be part of the background model.
		/// </summary>
		/// <param name="frame">frame to add</param>
		public virtual void Add(TFrame frame){
			this.FrameCount++;
			this.framewidth = frame.Width;
			this.frameheight= frame.Height;
		}
		
		/// <summary>
		/// Calculates the background model for all currently gathered frames.
		/// </summary>
		/// <exception cref="InvalidOperationException">If no frames are gathered yet.</exception>
		/// <returns>Depthframe that represents the background.</returns>
		public abstract TFrame GetBackgroundModel();

		protected abstract void DoDispose();

		void IDisposable.Dispose(){
			this.DoDispose();
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets the current count of frames that are
		/// evaluated for the background model.
		/// </summary>
		public int FrameCount{get; private set;} 
		#endregion
	}
}
