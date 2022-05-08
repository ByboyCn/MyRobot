using System;
using System.Collections.Generic;
using System.Text;

namespace My.Events
{
    /// <summary>
    /// 好友
    /// </summary>
    public class BotFriend
    {
        /// <summary>
        /// 好友uin
        /// </summary>
        public uint Uin { get; internal set; }

        /// <summary>
        /// 好友昵称
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// 好友备注
        /// </summary>
        public string Remark { get; internal set; }

        /// <summary>
        /// 好友faceId
        /// </summary>
        public byte FaceId { get; internal set; }

        /// <summary>
        /// 好友性别
        /// </summary>
        public byte Gender { get; internal set; }

        internal BotFriend()
        {
            Name = "";
            Remark = "";
        }
    }
}
