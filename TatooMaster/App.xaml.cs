using System.IO;
using System.Windows;

namespace TatooMaster
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        const string savePath = "tatoomaster.json";
        protected override void OnStartup(StartupEventArgs e)
        {
            if (File.Exists(savePath))
            {
                var text = File.ReadAllText(savePath);
                Register.Instance.Deserialize(text);
            }
            
            base.OnStartup(e);
            new MainWindow().ShowDialog();
            
            var serialized = Register.Instance.Serialize();
            File.WriteAllText(savePath, serialized);
        }
    }
}