using CPF;
using CPF.Drawing;

namespace My.QQ
{
    public class ItemData : CpfObject
    {
        public string Name
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
        public string Introduce
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
        public Image Img
        {
            get { return GetValue<Image>(); }
            set { SetValue(value); }
        }
    }
}
