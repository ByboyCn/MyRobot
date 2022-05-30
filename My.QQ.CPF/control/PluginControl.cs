using CPF.Controls;
using CPF.Design;
using CPF.Shapes;

namespace My.QQ
{
    [DesignerLoadStyle("res://My.QQ.CPF/css/Plugin.css")]
    public class PluginControl : ListBoxItem
    {
        //模板定义
        protected override void InitializeComponent()
        {
            //模板定义
            if (DesignMode)
            {
                Width = 300;
                Background = "#fff";
            }
            else
            {
                Width = "100%";
            }
            Height = 55;
            //插件主图
            Children.Add(new Ellipse
            {
                MarginLeft = 7.9f,
                Height = 40,
                Width = 40,
                StrokeFill = null,
                Fill = "url(res://My.QQ.CPF/Resources/headQQ.png) Clamp Fill",//Bindings =
                //{
                //    {
                //        nameof(Ellipse.Fill),
                //        "Item1"
                //    }
                //}
            });
            //插件名字
            Children.Add(new TextBlock
            {
                FontSize = 14,
                MarginLeft = 64,
                Width = 89,
                MarginTop = 7,
                Text = "PluginName",//Bindings =
                //{
                //    {
                //        nameof(TextBlock.Text),
                //        "Item2"
                //    }
                //}
            });
            //插件作者
            Children.Add(new TextBlock
            {
                MarginBottom = 29,
                FontSize = 14,
                MarginLeft = 168,
                Width = 76,
                MarginTop = 7,
                Text = "Author",//Bindings =
                //{
                //    {
                //        nameof(TextBlock.Text),
                //        "Item2"
                //    }
                //}
            });
            //插件简介
            Children.Add(new TextBlock
            {
                Foreground = "#7E7E7E",
                MarginLeft = 62,
                MarginTop = 30,
                MarginRight = 56,
                Height = 16,
                ClipToBounds = true,
                Text = "PluginDes",//Bindings =
                //{
                //    {
                //        nameof(TextBlock.Text),
                //        "Item3"
                //    }
                //}
            });
            Children.Add(new Switch
            {
                Height = 21,
                Width = 41,
                Foreground = "#7E7E7E",
                MarginTop = 15,
                MarginRight = 10,
                IsChecked = false,//Bindings =
                //{
                //    {
                //        nameof(CheckBox.IsChecked),
                //        "Item4"
                //    }
                //}
            });
            //Triggers.Add(nameof(IsMouseOver), Relation.Me, null, (nameof(Background), "#aaaaaa55"));
            //Triggers.Add(nameof(IsSelected), Relation.Me, null, (nameof(Background), "#aaaaaa55"));
            //Commands.Add(nameof(DoubleClick), nameof(QQMainModel.ClickMessageItem), null, this);
        }

#if !DesignMode //用户代码写到这里，设计器下不执行，防止设计器出错
        protected override void OnInitialized()
        {
            base.OnInitialized();

        }
        //用户代码

#endif
    }
}
