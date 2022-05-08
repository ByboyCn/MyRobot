using Konata.Core;
using My.Events;
using Konata.Core.Interfaces.Api;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using My.Commons;

namespace My
{
    /// <summary>
    /// Plugin二次开发继承类
    /// </summary>
    public abstract class Plugin
    {
        public delegate void PluginEvent<in TArgs>(Bot sender, TArgs args);
        #region 私有变量
        private Bot bot = null!;
        public void InitClient(Bot bot)
        {
            if (this.bot == null) {
                this.bot = bot;
            }
        }
        /// <summary>
        /// 构造
        /// </summary>
        public Plugin()
        {
        }
        #endregion

        #region 公共变量
        /// <summary>
        /// 插件的名称
        /// </summary>
        public string PluginId { get; set; } = "请安装后查看";
        /// <summary>
        /// 插件的名称
        /// </summary>
        public string PluginName { get; set; } = "请安装后查看";
        /// <summary>
        /// 插件描述
        /// </summary>
        public string Description { get; set; } = "请安装后查看";
        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; } = "请安装后查看";
        #endregion

        #region 抽象方法

        /// <summary>
        /// 应用启动时执行
        /// </summary>
        public abstract void Start();

        /// <summary>
        /// 应用停止时执行
        /// 所有定时器、订阅请在停止时释放
        /// </summary>
        public abstract void Stop();

        /// <summary>
        /// 打开应用窗口
        /// </summary>
        public abstract void OpenSettingsForm();

        #endregion

        #region 机器人事件
        /// <summary>
        /// 机器人上线
        /// </summary>
        public event PluginEvent<BotOnlineEvent>? BotOnline;

        /// <summary>
        /// 机器人离线
        /// </summary>
        public event PluginEvent<BotOfflineEvent>? BotOffline;

        /// <summary>
        /// 机器人收到验证码
        /// </summary>
        public event PluginEvent<CaptchaEvent>? Captcha;

        /// <summary>
        /// 机器人收到群消息
        /// </summary>
        public event PluginEvent<GroupMessageEvent>? GroupMessage;

        /// <summary>
        /// 机器人收到群内禁言信息
        /// </summary>
        public event PluginEvent<GroupMuteMemberEvent>? GroupMute;

        /// <summary>
        /// 机器人收到群内撤回消息
        /// </summary>
        public event PluginEvent<GroupMessageRecallEvent>? GroupMessageRecall;

        /// <summary>
        /// 机器人收到群内戳一戳
        /// </summary>
        public event PluginEvent<GroupPokeEvent>? GroupPoke;

        /// <summary>
        /// 机器人收到群内踢人信息
        /// </summary>
        public event PluginEvent<GroupKickMemberEvent>? GroupMemberDecrease;

        /// <summary>
        /// 机器人收到群内加人信息
        /// </summary>
        public event PluginEvent<GroupMemberIncreaseEvent>? GroupMemberIncrease;

        /// <summary>
        /// 机器人收到群内管理员变动信息
        /// </summary>
        public event PluginEvent<GroupPromoteAdminEvent>? GroupPromoteAdmin;

        /// <summary>
        /// 机器人收到群邀请信息
        /// </summary>
        public event PluginEvent<GroupInviteEvent>? GroupInvite;

        /// <summary>
        /// 机器人收到群申请信息
        /// </summary>
        public event PluginEvent<GroupRequestJoinEvent>? GroupRequestJoin;

        /// <summary>
        /// 机器人收到好友消息
        /// </summary>
        public event PluginEvent<FriendMessageEvent>? FriendMessage;

        /// <summary>
        /// 机器人收到好友撤回信息
        /// </summary>
        public event PluginEvent<FriendMessageRecallEvent>? FriendMessageRecall;

        /// <summary>
        /// 机器人收到好友戳一戳
        /// </summary>
        public event PluginEvent<FriendPokeEvent>? FriendPoke;

        /// <summary>
        /// 机器人收到好友正在输入信息
        /// </summary>
        public event PluginEvent<FriendTypingEvent>? FriendTyping;

        /// <summary>
        /// 机器人收到加好友请求
        /// </summary>
        public event PluginEvent<FriendRequestEvent>? FriendRequest;

        /// <summary>
        /// 触发在线事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnBotOnline(Bot sender,BotOnlineEvent e)
        {
            BotOnline?.Invoke(sender, e);
        }

        /// <summary>
        /// 触发离线事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnBotOffline(Bot sender, BotOfflineEvent e)
        {
            BotOffline?.Invoke(sender, e);
        }

        /// <summary>
        /// 触发验证码事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnCaptcha(Bot sender, CaptchaEvent e)
        {
            Captcha?.Invoke(sender, e);
        }

        /// <summary>
        /// 触发群消息事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnGroupMessage(Bot sender, GroupMessageEvent e)
        {
            GroupMessage?.Invoke(sender, e);
        }

        /// <summary>
        /// 触发群内禁言事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnGroupMute(Bot sender, GroupMuteMemberEvent e)
        {
            GroupMute?.Invoke(sender, e);
        }

        /// <summary>
        /// 触发群内撤回事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnGroupMessageRecall(Bot sender, GroupMessageRecallEvent e)
        {
            GroupMessageRecall?.Invoke(sender, e);
        }

        /// <summary>
        /// 触发群内戳一戳事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnGroupPoke(Bot sender, GroupPokeEvent e)
        {
            GroupPoke?.Invoke(sender, e);
        }

        /// <summary>
        /// 触发群内踢人事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnGroupMemberDecrease(Bot sender, GroupKickMemberEvent e)
        {
            GroupMemberDecrease?.Invoke(sender, e);
        }

        /// <summary>
        /// 触发群内加人事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnGroupMemberIncrease(Bot sender, GroupMemberIncreaseEvent e)
        {
            GroupMemberIncrease?.Invoke(sender, e);
        }

        /// <summary>
        /// 触发群内管理员变动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnGroupPromoteAdmin(Bot sender, GroupPromoteAdminEvent e)
        {
            GroupPromoteAdmin?.Invoke(sender, e);
        }

        /// <summary>
        /// 触发群邀请事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnGroupInvite(Bot sender, GroupInviteEvent e)
        {
            GroupInvite?.Invoke(sender, e);
        }

        /// <summary>
        /// 触发群申请事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnGroupRequestJoin(Bot sender, GroupRequestJoinEvent e)
        {
            GroupRequestJoin?.Invoke(sender, e);
        }

        /// <summary>
        /// 触发好友消息事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnFriendMessage(Bot sender, FriendMessageEvent e)
        {
            FriendMessage?.Invoke(sender, e);
        }

        /// <summary>
        /// 触发好友撤回事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnFriendMessageRecall(Bot sender, FriendMessageRecallEvent e)
        {
            FriendMessageRecall?.Invoke(sender, e);
        }

        /// <summary>
        /// 触发好友戳一戳事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnFriendPoke(Bot sender, FriendPokeEvent e)
        {
            FriendPoke?.Invoke(sender, e);
        }

        /// <summary>
        /// 触发好友输入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnFriendTyping(Bot sender, FriendTypingEvent e)
        {
            FriendTyping?.Invoke(sender, e);
        }

        /// <summary>
        /// 触发好友请求事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnFriendRequest(Bot sender, FriendRequestEvent e)
        {
            FriendRequest?.Invoke(sender, e);
        }
        #endregion

        #region 机器人方法
        #region 机器人方法
        /// <summary>
        /// 登陆
        /// </summary>
        /// <returns></returns>
        public Task<bool> Login => bot.Login();

        /// <summary>
        /// 登出
        /// </summary>
        /// <returns></returns>
        public Task Logout => bot.Logout();

        /// <summary>
        /// 发送验证ticket
        /// </summary>
        /// <param name="ticket">ticket</param>
        /// <returns></returns>
        public bool SubmitSliderTicket(string ticket) => bot.SubmitSliderTicket(ticket);
        
        /// <summary>
        /// 发送短信验证码
        /// </summary>
        /// <param name="code">验证码</param>
        /// <returns></returns>
        public bool SubmitSmsCode(string code)=>bot.SubmitSmsCode(code);

        /// <summary>
        /// 获取群列表
        /// </summary>
        /// <param name="forceUpdate">是否实时更新</param>
        /// <returns></returns>
        public async Task<IReadOnlyList<BotGroup>> GetGroupList(bool forceUpdate = false)
        {
            var group = await bot.GetGroupList(forceUpdate);
            return group.Convent();
        }

        /// <summary>
        /// 获取好友列表
        /// </summary>
        /// <param name="forceUpdate"></param>
        /// <returns></returns>
        public async Task<IReadOnlyList<BotFriend>> GetFriendList(bool forceUpdate = false)
        {
            var friend = await bot.GetFriendList(forceUpdate);
            return friend.Convent();
        }






        #endregion
        #endregion

    }
}

