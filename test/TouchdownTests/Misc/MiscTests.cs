using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Touchdown.Core;

namespace TouchTests.Misc {
	/// <summary>
	/// contains tests that do not fit to specific classes
	/// </summary>
	[TestFixture]
	public class MiscTests {
		
		[Test]
		public void AddOrUpdateDictionaryNewTest(){
			Dictionary<string, string> dict = new Dictionary<string,string>();

			dict.AddOrUpdate("key", "value");

			Assert.AreEqual(true, dict.ContainsKey("key"));
			Assert.AreEqual("value", dict["key"]);

		}

		[Test]
		public void AddOrUpdateDictionaryUpdateTest(){
			Dictionary<string, string> dict = new Dictionary<string,string>();
			dict.Add("key", "value01");
			dict.AddOrUpdate("key", "value02");

			Assert.AreEqual(true, dict.ContainsKey("key"));
			Assert.AreEqual("value02", dict["key"]);
		}

		[Test]
		public void AddOrUpdateDictionaryUpdateTest_bool(){
			Dictionary<int, bool> dict = new Dictionary<int,bool>();
			dict.Add(31, false);
			dict.AddOrUpdate(31, true);

			Assert.AreEqual(true, dict.ContainsKey(31));
			Assert.AreEqual(true, dict[31]);
		}
	}
}
