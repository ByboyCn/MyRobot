using CPF;
using CPF.Drawing;
using CPF.Styling;

namespace My.QQ
{
    public class LoginModel : CpfObject
    {
        public LoginModel()
        {
            UserList = new Collection<(Image, string, string)>();
            LoadData();
        }

        async void LoadData()
        {
            var img = await ResourceManager.GetImage("res://My.QQ.CPF/Resources/headQQ.png");
            for (int i = 0; i < 1; i++) {
                UserList.Add((img, "Byboy", "3446236"));
            }
        }

        public Collection<(Image, string, string)> UserList
        {
            get { return GetValue<Collection<(Image, string, string)>>(); }
            set { SetValue(value); }
        }

        public void RemoveUserItem(CpfObject cpfObject)
        {
            var item = ((Image, string, string))cpfObject.DataContext;
            UserList.Remove(item);
        }

        public string Password
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string QQ
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
    }
}
