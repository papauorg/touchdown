using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Touchdown.Core.Smoothing{

	/// <summary>
	/// Bilinear filter for reducing noise in depth frames.
	/// </summary>
	public class BilinearFilter{
		
		int height, width;
		uint kernelSize;

		/// <summary>
		/// Creates a new instance of the filter
		/// </summary>
		/// <param name="width"></param>
		/// <param name="height"></param>
		public BilinearFilter(int width, int height, uint kernelSize){
			this.height = height;
			this.width = width;	
			this.kernelSize = kernelSize;
		}

		/// <summary>
		/// Applies the filter to the depth data.
		/// </summary>
		/// <param name="inputArray"></param>
		/// <returns></returns>
		public int[] Apply(int[] inputArray){
			int[] result = new int[inputArray.Length];

			// for each pixel
			Parallel.For(0, this.height, y => {
				for (int x = 0; x < this.width; ++x) { 
					int currentPixelIndex = (y * width) + x;
					double pixelWeightSum = 0;

					// iterate each neigbouring pixel in the kernel size
					for (int i = (int)(kernelSize * -1); i <= kernelSize; ++i) {
						for (int k = (int)(kernelSize * -1); k <= kernelSize; ++k) { 
							int currentKernelPixelIndex = (y+i)*width + (x+k);
							if (currentKernelPixelIndex >= 0 && currentKernelPixelIndex < inputArray.Length) {
								double pixelDistance = Math.Sqrt(i * i + k * k);
								double valueDistance = Math.Abs(inputArray[currentKernelPixelIndex] - inputArray[currentPixelIndex]);
								double currentKernelWeight = 1 / (Math.Exp(pixelDistance * pixelDistance / 72) * Math.Exp(valueDistance * valueDistance * 8));
								pixelWeightSum += currentKernelWeight;
								result[currentPixelIndex] += (short)(currentKernelWeight * inputArray[currentKernelPixelIndex]);
							}
						}
					}
					// the result at the current pixel index contains now the sum of all weighted neighbouring pixels.
					// divide by the sum of the weight of all pixels to get the filtered result
					result[currentPixelIndex] = (short)(result[currentPixelIndex] / pixelWeightSum);
				}
			});

			return result;
		}
	}
}
