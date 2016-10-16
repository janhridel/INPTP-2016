namespace AplikacniNastaveni
{
    public class FormSizeCfg // Třída musí být veřejná kvůli XML serializaci.
    {
        public Size Size { get; set; }
    }

    class MainFormCfg : ApplicationSettingsBase
    {
        [UserScopedSetting]
        [DefaultSettingValue("100, 100")]
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

    public partial class MainForm : Form
    {
        MainFormCfg cfg = new MainFormCfg();
        public MainForm()
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


