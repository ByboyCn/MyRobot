using CPF;

namespace My.QQ.CPF
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
    }
}
