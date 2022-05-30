using CPF;
using CPF.Drawing;

namespace My.QQ
{
    public class PluginModel : CpfObject
    {

        /// <summary>
        /// 插件图标
        /// </summary>
        public Image Ioce
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        /// <summary>
        /// 插件名称
        /// </summary>
        public string PluginName
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        /// <summary>
        /// 插件作者
        /// </summary>
        public string Author
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        /// <summary>
        /// 插件描述
        /// </summary>
        public string Description
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

      


      




    }
}
