using Konata.Core.Common;
using System.Collections.Generic;

namespace My.Commons
{
    /// <summary>
    /// 转换
    /// </summary>
    public static class Convents
    {
        public static IReadOnlyList<My.Events.BotGroup> Convent(this IReadOnlyList<BotGroup> data)
        {
            List<My.Events.BotGroup> botGroups = new();
            foreach (var item in data) {
                My.Events.BotGroup botGroup = new();
                botGroup.AdminUins = item.AdminUins;
                botGroup.Name = item.Name;
                botGroup.Muted = item.Muted;
                botGroup.MemberCount = item.MemberCount;
                botGroup.MaxMemberCount = item.MaxMemberCount;
                botGroup.Muted= item.Muted;
                botGroup.Code = item.Code;
                botGroup.MutedMe = item.MutedMe;
                botGroup.OwnerUin = item.OwnerUin;
                botGroup.Uin = item.Uin;
                botGroups.Add(botGroup);
            }
            return botGroups;
        }

        public static IReadOnlyList<My.Events.BotFriend> Convent(this IReadOnlyList<BotFriend> data)
        {
            List<My.Events.BotFriend> botFriends = new();
            foreach (var item in data) {
                My.Events.BotFriend botFriend = new();
                botFriend.FaceId = item.FaceId;
                botFriend.Gender = item.Gender;
                botFriend.Name = item.Name;
                botFriend.Remark = item.Remark;
                botFriend.Uin = item.Uin;
                botFriends.Add(botFriend);
            }
            return botFriends;
        }
    }
}
