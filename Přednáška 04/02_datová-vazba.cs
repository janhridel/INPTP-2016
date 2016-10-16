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
    protected override void OnSettingsLoaded(object sender, SettingsLoadedEventArgs e)
    {
        base.OnSettingsLoaded(sender, e);
        if (SizeCfg == null)
        {
            SizeCfg = new FormSizeCfg() { Size = new Size(200, 200) };
        }
    }
}

public partial class MainForm : Form
{
    bool volanoUpgrade = false;
    MainFormCfg cfg = new MainFormCfg();

    public MainForm()
    {
        InitializeComponent();
        cfg.SettingsLoaded += new System.Configuration.SettingsLoadedEventHandler(cfg_SettingsLoaded);
        DataBindings.Add("Location", cfg, "Location", false, DataSourceUpdateMode.OnPropertyChanged);
        Size = cfg.SizeCfg.Size;
    }
    private void cfg_SettingsLoaded(object sender, System.Configuration.SettingsLoadedEventArgs e)
    {
        if (cfg.SizeCfg == null && !volanoUpgrade)
        {
            volanoUpgrade = true;
            cfg.Upgrade();
        }
    }
    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        base.OnFormClosed(e);
        //DataBindings["Location"].WriteValue();
        cfg.SizeCfg.Size = Size;
        cfg.Save();
    }
}