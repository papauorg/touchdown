using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Touchdown.Win.UI.UserControls.InitWizzard {
	public partial class InitKinectWizzardControl : UserControl {
		internal const string INFOKEY_SENSOR = "sensorID";
		internal const string INFOKEY_BACKGROUND_MODEL = "backgroundModel";
		internal const string INFOKEY_COLOR_BACKGROUND_MODEL = "colorBackgroundModel";

		private Button _nextButton;

		public InitKinectWizzardControl(){
			InitializeComponent();
		}

		public InitKinectWizzardControl(Button next) : this() {
			_nextButton = next;
			_nextButton.Enabled = true;
		}

		public virtual void AddOrUpdateWizzardInfo(Dictionary<string, object> info){
			// nothing to do here
		}

		public virtual void SetWizzardInfo(Dictionary<string, object> info){
			// nothing to do here.
		}

		public bool NextButtonEnabled{
			get {
				return _nextButton.Enabled;
			}
			set {
				_nextButton.Enabled = value;
			}
		} 
	
		
	}
}
