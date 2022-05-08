using System;
using System.Collections.Generic;
using System.Text;

namespace My.Events
{
    public class BotGroup
    {
        /// <summary>
        /// 群uin
        /// </summary>
        public uint Uin { get; set; }

        /// <summary>
        /// 群code
        /// </summary>
        public ulong Code { get; set; }

        /// <summary>
        /// 群名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 群主uin
        /// </summary>
        public uint OwnerUin { get; set; }

        /// <summary>
        /// 群管理员uin列表
        /// </summary>
        public List<uint> AdminUins { get; set; }

        /// <summary>
        /// 群成员个数
        /// </summary>
        public uint MemberCount { get; set; }

        /// <summary>
        /// 群最大运行成员数
        /// </summary>
        public uint MaxMemberCount { get; set; }

        /// <summary>
        /// 群禁言的实践出
        /// </summary>
        public uint Muted { get; set; }

        /// <summary>
        /// 群禁言机器人的时间戳
        /// </summary>
        public uint MutedMe { get; set; }

        internal BotGroup()
        {
            Name = "";
            AdminUins = new();
        }
    }
}
