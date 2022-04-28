using Konata.Core;
using Konata.Core.Interfaces.Api;

namespace Impes.HelloPlugin
{
    public class HelloPlugin : Plugin
    {
        //构造
        public HelloPlugin(Bot bot) : base(bot)
        {
            // 添加群消息
            bot.OnGroupMessage += Bot_OnGroupMessage;
        }

        /// <summary>
        /// 收到群消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void Bot_OnGroupMessage(Bot sender, Konata.Core.Events.Model.GroupMessageEvent args)
        {
            //收到消息之后给这个群里发送123
            sender.SendGroupMessage(args.GroupUin, "123");
        }

        /// <summary>
        /// 展示设置框
        /// </summary>
        public override void OpenSettingsForm()
        {
        }
        /// <summary>
        /// 插件开始运行
        /// </summary>
        public override void Start()
        {
        }
        /// <summary>
        /// 插件停止运行
        /// </summary>
        public override void Stop()
        {
        }
    }
}
