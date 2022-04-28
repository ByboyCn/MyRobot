using Konata.Core;
using Konata.Core.Interfaces.Api;
using Konata.Core.Message;
using Konata.Core.Message.Model;

namespace Impes.HelloPlugin
{
    public class HelloPlugin : Plugin
    {
        //构造
        public HelloPlugin(Bot bot) : base(bot)
        {
            this.Author = "Byboy";
            this.PluginId = "Byboy.HelloWorld";
            this.PluginName = "这是一个插件";
            // 添加群消息
            bot.OnGroupMessage += Bot_OnGroupMessage;
            //加群消息
            bot.OnGroupInvite += Bot_OnGroupInvite;
        }

        private async void Bot_OnGroupInvite(Bot sender, Konata.Core.Events.Model.GroupInviteEvent args)
        {
            var b = await sender.ApproveGroupInvitation(args.GroupUin, args.InviterUin, args.Token);
        }

        private static uint _messageCounter;
        /// <summary>
        /// 收到群消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void Bot_OnGroupMessage(Bot bot, Konata.Core.Events.Model.GroupMessageEvent group)
        {
            ++_messageCounter;
            //过滤自己发的消息
            if (group.MemberUin == bot.Uin) return;
            var textChain = group.Chain.GetChain<TextChain>();
            // 只接受文本指令
            if (textChain == null) return;
            MessageBuilder reply = null;
            if (textChain.Content.StartsWith("/help")) reply = OnCommandHelp(textChain);
        }

        private MessageBuilder? OnCommandHelp(TextChain textChain) => new MessageBuilder().Text("[飞服机器人 帮助]\n").Text("当时时间-查看当前服务器时间\n");

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
