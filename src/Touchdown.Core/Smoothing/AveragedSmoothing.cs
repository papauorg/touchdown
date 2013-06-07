/*
	Apache 2.0 Licence
 * Original source code: http://kinectdepthsmoothing.codeplex.com/
 */

using System.Threading.Tasks;
using System.Collections.Generic;

namespace KinectDepthSmoothing{
	/// <summary>
	/// for internal use only:
	///  http://kinectdepthsmoothing.codeplex.com/
	/// </summary>
    public class AveragedSmoothing {
        // Will specify how many frames to hold in the Queue for averaging
        private int _averageFrameCount;
        public int AverageFrameCount { get { return _averageFrameCount; } set { if (value > 0 && value <= MaxAverageFrameCount) _averageFrameCount = value; } }
        // The actual Queue that will hold all of the frames to be averaged
        private Queue<int[]> averageQueue = new Queue<int[]>();

        public static readonly int MaxAverageFrameCount = 12;

        public AveragedSmoothing()
        {
            this._averageFrameCount = 4;
        }

        public AveragedSmoothing(int AverageFrameCount)
        {
            this.AverageFrameCount = AverageFrameCount;
        }

        public int[] CreateAverageDepthArray(int[] depthArray, int width, int height)
        {
            // This is a method of Weighted Moving Average per pixel coordinate across several frames of depth data.
            // This means that newer frames are linearly weighted heavier than older frames to reduce motion tails,
            // while still having the effect of reducing noise flickering.

            averageQueue.Enqueue(depthArray);

            CheckForDequeue();

            int[] sumDepthArray = new int[depthArray.Length];
            int[] averagedDepthArray = new int[depthArray.Length];

            int Denominator = 0;
            int Count = 1;

            // REMEMBER!!! Queue's are FIFO (first in, first out).  This means that when you iterate
            // over them, you will encounter the oldest frame first.

            // We first create a single array, summing all of the pixels of each frame on a weighted basis
            // and determining the denominator that we will be using later.
            foreach (var item in averageQueue)
            {
                // Process each row in parallel
                Parallel.For(0, height, depthArrayRowIndex =>
                {
                    // Process each pixel in the row
                    for (int depthArrayColumnIndex = 0; depthArrayColumnIndex < width; depthArrayColumnIndex++)
                    {
                        var index = depthArrayColumnIndex + (depthArrayRowIndex * width);
                        sumDepthArray[index] += item[index] * Count;
                    }
                });
                Denominator += Count;
                Count++;
            }

            // Once we have summed all of the information on a weighted basis, we can divide each pixel
            // by our calculated denominator to get a weighted average.

            // Process each row in parallel
            Parallel.For(0, height, depthArrayRowIndex =>
            {
                // Process each pixel in the row
                for (int depthArrayColumnIndex = 0; depthArrayColumnIndex < width; depthArrayColumnIndex++)
                {
                    var index = depthArrayColumnIndex + (depthArrayRowIndex * width);
                    averagedDepthArray[index] = (short)(sumDepthArray[index] / Denominator);
                }
            });

            return averagedDepthArray;
        }

        private void CheckForDequeue()
        {
            // We will recursively check to make sure we have Dequeued enough frames.
            // This is due to the fact that a user could constantly be changing the UI element
            // that specifies how many frames to use for averaging.
            if (averageQueue.Count > _averageFrameCount)
            {
                averageQueue.Dequeue();
                CheckForDequeue();
            }
        }
    }
}
