using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Touchdown.Core {
	/// <summary>
	/// contains generic extension methods
	/// </summary>
	public static class Extensions {
		/// <summary>
		/// Adds or updates a value in a dictionary
		/// </summary>
		/// <typeparam name="TKey">key type</typeparam>
		/// <typeparam name="TValue">value type</typeparam>
		/// <param name="dict">dictionary</param>
		/// <param name="key">key that should be added</param>
		/// <param name="value">value that should be added</param>
		public static void AddOrUpdate<TKey, TValue>(this Dictionary<TKey,TValue> dict, TKey key, TValue value){
			if (dict == null) {
				throw new ArgumentNullException("dict");
			}

			if (dict.ContainsKey(key)) {
				dict[key] = value;
			} else { 
				dict.Add(key, value);
			}
		}
	}
}
