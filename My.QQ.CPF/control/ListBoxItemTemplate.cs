using CPF;
using CPF.Controls;
using CPF.Shapes;
using CPF.Styling;

namespace My.QQ
{
    public class ListBoxItemTemplate : ListBoxItem
    {
        protected override void InitializeComponent()
        {//模板定义
            Width = "100%";
            Height = 40;
            Background = "#fff";
            Children.Add(
                new Ellipse
                {
                    IsAntiAlias = true,
                    Fill = new TextureFill("url(https://tva1.sinaimg.cn/crop.0.0.180.180.180/7fde8b93jw1e8qgp5bmzyj2050050aa8.jpg)") { Stretch = Stretch.Fill },
                    Width = 30,
                    Height = 30,
                    MarginLeft = 5,
                    StrokeFill = null,
                });
            Children.Add(new TextBlock { Text = "马大云", MarginLeft = 40, MarginTop = 5, Bindings = { { nameof(TextBlock.Text), nameof(ItemData.Name) } } });
            Children.Add(new TextBlock { Text = "这人很帅", MarginLeft = 40, MarginTop = 20, Foreground = "#666", Bindings = { { nameof(TextBlock.Text), nameof(ItemData.Introduce) } } });



            Triggers.Add(new Trigger { Property = nameof(IsMouseOver), PropertyConditions = a => (bool)a && !IsSelected, Setters = { { nameof(Background), "229,243,251" } } });
            Triggers.Add(new Trigger { Property = nameof(IsSelected), PropertyConditions = a => (bool)a, Setters = { { nameof(Background), "203,233,246" } } });
        }
    }
}
