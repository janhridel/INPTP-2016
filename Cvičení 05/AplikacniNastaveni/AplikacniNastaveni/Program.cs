using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplikacniNastaveni
{
    public class FormSizeCfg // Třída musí být veřejná kvůli XML serializaci.
    {
        public Size Size { get; set; }
    }

    class MainFormCfg : ApplicationSettingsBase
    {
        [UserScopedSetting]
        [DefaultSettingValue("600, 100")]
        public Point Location
        {
            get { return (Point)this["Location"]; }
            set { this["Location"] = value; }
        }

        [UserScopedSetting]
        public FormSizeCfg SizeCfg
        {
            get { return (FormSizeCfg)this["SizeCfg"]; }
            set { this["SizeCfg"] = value; }
        }

        public bool IsLocationNull { get { return this["Location"] == null; } }
    }


    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
