using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Runtime.Serialization;

namespace Touchdown.SensorAbstraction {
	
	/// <summary>
	/// Represents a frame. Contains basic information about it.
	/// </summary>
	[DataContract]
	public abstract class Frame : IDisposable{
		private DateTime _frameTime;

		#region Constructors / Destructors
		
		/// <summary>
		/// Initializes a new instance of the <see cref="Touchdown.SensorAbstraction.Frame"/> class.
		/// </summary>
		/// <param name='frameTime'>
		/// Frame time.
		/// </param>
		/// <param name='data'>
		/// Data.
		/// </param>
		public Frame(DateTime frameTime, int width, int height){
			this._frameTime = frameTime;
			this.Width = width;
			this.Height = height;
		}
		#endregion
		
		#region Public Methods
		
		/// <summary>
		/// Creates a visual representation of the frame.
		/// </summary>
		/// <returns>
		/// The bitmap.
		/// </returns>
		public abstract Bitmap CreateBitmap();

		/// <summary>
		/// Dispose the frame.
		/// </summary>
		public virtual void Dispose(){
			
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets the frame time.
		/// </summary>
		/// <value>
		/// The frame time.
		/// </value>
		[DataMember]
		public DateTime FrameTime{
			get
			{
				return _frameTime;
			}
			private set {
				_frameTime = value;
			}
		}
		
		/// <summary>
		/// width of the frame.
		/// </summary>
		[DataMember]
		public int Width{get; private set;}

		/// <summary>
		/// height of the frame.
		/// </summary>
		[DataMember]
		public int Height{get; private set;}
		#endregion
	}
}
