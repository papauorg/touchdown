using System;
using System.Collections.Generic;
using System.Text;

namespace Touch2Much.Frames
{
	public abstract class Frame
	{
		private DateTime _frameTime;
		protected RawData _data;

		public DateTime FrameTime
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public abstract Bitmap CreateBitmap();
	}
}
