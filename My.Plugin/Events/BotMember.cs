namespace My.Events
{
    public class BotMember
    {

        /// <summary>
        /// 成员uin
        /// </summary>
        public uint Uin { get; set; }

        /// <summary>
        /// 成员名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 成员昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 成员特殊标题
        /// </summary>
        public string SpecialTitle { get; set; }

        /// <summary>
        /// 特殊标题过期事件
        /// </summary>
        public uint SpecialTitleExpiredTime { get; set; }

        /// <summary>
        /// 成员年龄
        /// </summary>
        public uint Age { get; set; }

        /// <summary>
        /// 成员faceId
        /// </summary>
        public byte FaceId { get; set; }

        /// <summary>
        /// 成员性别
        /// </summary>
        public byte Gender { get; set; }

        /// <summary>
        /// 成员等级
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// 成员加入群聊的时间
        /// </summary>
        public uint JoinTime { get; set; }

        /// <summary>
        /// 成员最后发言时间
        /// </summary>
        public uint LastSpeakTime { get; set; }

        /// <summary>
        /// 成员角色
        /// </summary>
        public RoleType Role { get; set; }

        /// <summary>
        /// 成员是管理员(所有者除外)
        /// </summary>
        internal bool IsAdmin { get; set; }

        /// <summary>
        /// 禁言的时间
        /// </summary>
        public uint MuteTimestamp { get; set; }

        internal BotMember()
        {
            Name = "";
            NickName = "";
        }
    }

    /// <summary>
    /// 成员类型
    /// </summary>
    public enum RoleType
    {
        /// <summary>
        ///  普通成员
        /// </summary>
        Member = 1,

        /// <summary>
        /// 管理员
        /// </summary>
        Admin,

        /// <summary>
        /// 创建者
        /// </summary>
        Owner
    }
}