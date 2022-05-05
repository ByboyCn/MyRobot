using My.QQRobot.Entitys;
using My.QQRobot.Plugins;
using Konata.Core;
using Konata.Core.Common;
using Konata.Core.Events.Model;
using Konata.Core.Interfaces;
using Konata.Core.Interfaces.Api;
using System.Text.Json;

namespace My.QQRobot
{
    public partial class Form1 : Form
    {
        public Bot bot;
        public BotKeyStore? key;
        public string code = "";
        List<PluginProxy> PluginProxyList = new List<PluginProxy>();
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_LoadAsync(object sender, EventArgs e)
        {
            
            var config = Config;
            var device = GetDevice();
            key = GetKeyStore();
            if (key == null) {
                new Login(this).ShowDialog();
            }

            bot = BotFather.Create(config, device, key);
            bot.OnLog += Bot_OnLog;
            bot.OnCaptcha += (s, e) => {
                switch (e.Type) {
                    case CaptchaEvent.CaptchaType.Sms: {
                            Console.WriteLine();
                            new InputBox("请输入验证码", $"请输入{e.Phone}的验证码", this).ShowDialog();
                            s.SubmitSmsCode(code);
                            break;
                        }
                    case CaptchaEvent.CaptchaType.Slider: {
                            new InputBox("请输入滑动验证", e.SliderUrl, this).ShowDialog();
                            s.SubmitSliderTicket(code);
                            break;
                        }

                    default:
                    case CaptchaEvent.CaptchaType.Unknown:
                        break;
                }
            };
            var result = await bot.Login();
            // Update the keystore
            if (result) {
                this.Text = $"{bot.Name}({bot.Uin})欢迎登陆";
                UpdateKeystore(bot.KeyStore);
                LoadPlugin();
            }
        }

        private void Bot_OnLog(Bot sender, Konata.Core.Events.LogEvent args)
        {
            this.Invoke(() => {
                logTxt.AppendText($"{args.EventTime}:{args.Level}，{args.EventMessage}\r\n");
            });
        }

        /// <summary>
        /// Get bot config
        /// </summary>
        /// <returns></returns>
        private BotConfig Config => new BotConfig
        {
            DefaultTimeout = 6000,
            EnableAudio = true,
            TryReconnect = true,
            HighwayChunkSize = 8192,
        };
        /// <summary>
        /// Load or create device 
        /// </summary>
        /// <returns></returns>
        private BotDevice GetDevice()
        {
            // Read the device from config
            if (File.Exists("device.json")) {
                return JsonSerializer.Deserialize<BotDevice>(File.ReadAllText("device.json"));
            }
            // Create new one
            var device = BotDevice.Default();
            {
                var deviceJson = JsonSerializer.Serialize(device,
                    new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText("device.json", deviceJson);
            }

            return device;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private BotKeyStore? GetKeyStore()
        {
            if (File.Exists("keystore.json")) {
                return JsonSerializer.Deserialize<BotKeyStore>(File.ReadAllText("keystore.json"));
            }
            return null;
        }
        /// <summary>
        /// Update keystore
        /// </summary>
        /// <param name="keystore"></param>
        /// <returns></returns>
        public BotKeyStore UpdateKeystore(BotKeyStore keystore)
        {
            var deviceJson = JsonSerializer.Serialize(keystore,
                new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("keystore.json", deviceJson);
            return keystore;
        }
        private static BotPlugin[] GetBotPlugins()
        {
            if (!File.Exists("plugin.json")) {
                File.WriteAllText("plugin.json", "[]");
                return Array.Empty<BotPlugin>();
            }
            return JsonSerializer.Deserialize<BotPlugin[]>(File.ReadAllText("plugin.json"));
        }
        private void LoadPlugin()
        {

            //加载当前软件目录下的Plugin目录下的所有dll
            var dlls = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "Plugin", "*.dll");
            //循环dlls
            foreach (var dll in dlls) {
                if (dll == null || dll.Length == 0) {
                    continue;
                }
                //构造PluginProxy
                var proxy = new PluginProxy()
                {
                    Bot = bot,
                    Filename = dll,
                };
                proxy.Init();
                PluginProxyList.Add(proxy);
            }
            UpdateListView();
        }
        private void UpdateListView()
        {
            this.Invoke(() => {
                //清理插件列表
                pluginListView.Items.Clear();
                PluginProxyList.ForEach(t => {
                    //添加到列表
                    var item = new ListViewItem(new String[] { t.Plugin.PluginId,t.Plugin.PluginName,t.Plugin.Author,t.Status.ToString() });
                    pluginListView.Items.Add(item);
                });
            });
        }

        private void 刷新插件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadPlugin();
        }
    }
}