using CPF;
using CPF.Drawing;
using CPF.Styling;

namespace My.QQ
{
    public class QQMainModel : CpfObject
    {
        public QQMainModel()
        {
            var img = ResourceManager.GetImage("res://My.QQ.CPF/Resources/headQQ.png").Result;
            Messages = new Collection<(string img, string name, string last)>();
            for (int i = 0; i < 1; i++) {
                Messages.Add(("url(res://My.QQ.CPF/Resources/headQQ.png) Clamp Fill", "名称" + i, "最新一条消息" + i));
            }
            Groups = new Collection<(string, Collection<(string img, string, string)>)>();
            var groups = Groups;
            for (int i = 0; i < 1; i++) {
                var list = new Collection<(string img, string, string)>();
                for (int j = 0; j < 1; j++) {
                    list.Add(("url(res://My.QQ.CPF/Resources/headQQ.png) Clamp Fill", "昵称" + i, "个人签名" + i));
                }
                groups.Add(("名称" + i, list));
            }
        }

        public Collection<(string, Collection<(string img, string, string)>)> Groups
        {
            get { return GetValue<Collection<(string, Collection<(string img, string, string)>)>>(); }
            set { SetValue(value); }
        }

        public Collection<(string img, string name, string last)> Messages
        {
            get { return GetValue<Collection<(string img, string, string)>>(); }
            set { SetValue(value); }
        }

        public void ClickMessageItem(MessageItem messageItem)
        {
            new QQChat().Show();
        }
    }
}
