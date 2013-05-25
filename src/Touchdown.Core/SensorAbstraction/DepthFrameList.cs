using System;
using System.Collections.ObjectModel;
using Touchdown.SensorAbstraction;
using System.Linq;

namespace Touchdown.Core {
	
	/// <summary>
	/// Collection of depthframes
	/// </summary>
	public class DepthFrameList : Collection<DepthFrame> {
		/// <Docs>
		/// To be added.
		/// </Docs>
		/// <summary>
		/// To be added.
		/// </summary>
		/// <since version='.NET 2.0'>
		/// 
		/// </since>
		/// <param name='index'>
		/// Index.
		/// </param>
		/// <param name='item'>
		/// Item.
		/// </param>
		protected override void InsertItem(int index, DepthFrame item) {
			base.InsertItem (index, item);
		}
		
		
	}
}

