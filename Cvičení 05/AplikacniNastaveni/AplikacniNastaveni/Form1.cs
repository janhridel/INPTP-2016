using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplikacniNastaveni
{

    public partial class Form1 : Form
    {
        MainFormCfg cfg = new MainFormCfg();
        public Form1()
        {
            InitializeComponent();
            // není nutný test, pokud vlatnost má atribut DefaultSettingValue
            //if (!cfg.IsLocationNull) Location = cfg.Location;
            StartPosition = FormStartPosition.Manual;
            Location = cfg.Location;
            if (cfg.SizeCfg != null)
            {
                Size = cfg.SizeCfg.Size;
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            if (cfg.SizeCfg == null) cfg.SizeCfg = new FormSizeCfg();
            cfg.SizeCfg.Size = Size;
            cfg.Location = Location;
            cfg.Save();
        }
    }
}
