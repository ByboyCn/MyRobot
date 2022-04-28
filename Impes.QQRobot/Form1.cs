using System.Text.Json;
using Impes.QQRobot.Plugins;
using Konata.Core;
using Konata.Core.Common;

namespace Impes.QQRobot
{
    public partial class Form1 : Form
    {
        Bot bot;
        List<PluginProxy> PluginProxyList = new List<PluginProxy>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    /// <summary>
    /// Get bot config
    /// </summary>
    /// <returns></returns>
    private static BotConfig GetConfig()
    {
        return new BotConfig
        {
            EnableAudio = true,
            TryReconnect = true,
            HighwayChunkSize = 8192,
        };
    }
    /// <summary>
    /// Load or create device 
    /// </summary>
    /// <returns></returns>
    private static BotDevice GetDevice()
    {
        // Read the device from config
        if (File.Exists("device.json"))
        {
            return JsonSerializer.Deserialize<BotDevice>(File.ReadAllText("device.json"));
        }
        // Create new one
        var device = BotDevice.Default();
        {
            var deviceJson = JsonSerializer.Serialize(device,
                new JsonSerializerOptions {WriteIndented = true});
            File.WriteAllText("device.json", deviceJson);
        }

        return device;
    }

     /// <summary>
    /// Load or create keystore
    /// </summary>
    /// <returns></returns>
    private static BotKeyStore GetKeyStore(string? account="",string? password="")
    {
        // Read the device from config
        if (File.Exists("keystore.json"))
        {
            return JsonSerializer.Deserialize
                <BotKeyStore>(File.ReadAllText("keystore.json"));
        }

        Console.WriteLine("警告:没有找到keystore.json,将自动创建一个新的keystore.json");
        return UpdateKeystore(new BotKeyStore(account, password));
    }
     /// <summary>
    /// Update keystore
    /// </summary>
    /// <param name="keystore"></param>
    /// <returns></returns>
    private static BotKeyStore UpdateKeystore(BotKeyStore keystore)
    {
        var deviceJson = JsonSerializer.Serialize(keystore,
            new JsonSerializerOptions {WriteIndented = true});
        File.WriteAllText("keystore.json", deviceJson);
        return keystore;
    }
        private void LoadPlugin()
        {
            //加载当前软件目录下的Plugin目录下的所有dll
            var dlls = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "Plugin", "*.dll");
            //循环dlls
            foreach (var dll in dlls){
                if(dll == null || dll.Length == 0)
                {
                    continue;
                }
                //构造PluginProxy
                var proxy = new PluginProxy(){
                    Bot = bot,
                    Filename = dll,
                };
                PluginProxyList.Add(proxy);
            }
        }
    }
}