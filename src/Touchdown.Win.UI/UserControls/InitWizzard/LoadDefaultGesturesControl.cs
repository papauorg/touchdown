using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Touchdown.Core;

namespace Touchdown.Win.UI.UserControls.InitWizzard {
	public partial class LoadDefaultGesturesControl : Touchdown.Win.UI.UserControls.InitWizzard.InitKinectWizzardControl {
		public LoadDefaultGesturesControl(Button next) : base(next) {
			InitializeComponent();

			this.lblHeadline.Text = "Default Gestures";
			this.lblDescription.Text = "Select the default gestures for recognition.";
		}

		public override void AddOrUpdateWizzardInfo(Dictionary<string, object> info) {
			base.AddOrUpdateWizzardInfo(info);

			var resultList = new List<TouchPattern>();
			foreach(object itemChecked in cblGestures.CheckedItems){
				 TouchPattern castedItem = itemChecked as TouchPattern;
				 resultList.Add(castedItem);
			}

			info.AddOrUpdate(InitKinectWizzardControl.INFOKEY_DEFAULT_GESTURES, resultList);
		}

		public override void SetWizzardInfo(Dictionary<string, object> info) {
			base.SetWizzardInfo(info);

			// load all Default Gestures
			var path = System.IO.Path.Combine(Application.StartupPath, "Gestures");
			List<TouchPattern> patternList = new List<TouchPattern>();

			if (System.IO.Directory.Exists(path)) {
				var files = System.IO.Directory.GetFiles(path, "*.pat");
				foreach (var file in files) {
					try {
						using (var stream = new System.IO.FileStream(file, System.IO.FileMode.Open, System.IO.FileAccess.Read)) { 
							var pattern = Touchdown.Core.TouchPattern.Load(stream);
							patternList.Add(pattern);
						}
					} catch {
						// ignore
					}
				}
			}

			cblGestures.DataSource = patternList;
			cblGestures.DisplayMember = "Name";

			CheckAll(true);
		}

		private void CheckAll(bool val){
			for(int i = 0; i < cblGestures.Items.Count; ++i) { 
				cblGestures.SetItemChecked(i, true);
			}
		}
	}
}
