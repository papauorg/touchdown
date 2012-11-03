using System;
using System.Collections.Generic;
using System.Text;

namespace Touch2Much.Frames
{
	public class DepthFrameReadyEventArgs : FrameReadyEventArgs
	{
		private DepthFrame _depthFrame;

		public DepthFrameReadyEventArgs(DepthFrame frame)
		{
			throw new NotImplementedException();
		}

		public DepthFrame DepthFrame
		{
			get
			{
				throw new NotImplementedException();
			}
		}
	}
}
