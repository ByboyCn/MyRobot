using CPF;
using CPF.Controls;
using CPF.Shapes;

namespace My.QQ
{
    public class MessageItem : ListBoxItem
    {
        protected override void InitializeComponent()
        {//模板定义
            if (DesignMode) {
                Width = 300;
                Background = "#fff";
            } else {
                Width = "100%";
            }
            Height = 55;

            Children.Add(new Ellipse
            {
                MarginLeft = 7.9f,
                Height = 40,
                Width = 40,
                StrokeFill = null,
                Fill = "url(res://My.QQ.CPF/Resources/headQQ.png) Clamp Fill",
                Bindings = {
                    {nameof(Ellipse.Fill),"Item1" }
                }
            });
            Children.Add(new TextBlock
            {
                FontSize = 14,
                MarginLeft = 63.5f,
                MarginTop = 7.3f,
                Text = "TextBlock1",
                MarginRight = 40,
                Bindings =
                {
                    {nameof(TextBlock.Text),"Item2" }
                }
            });
            Children.Add(new TextBlock
            {
                Foreground = "#7E7E7E",
                MarginLeft = 62.1f,
                MarginTop = 30f,
                MarginRight = 40,
                Height = 16,
                ClipToBounds = true,
                Text = "TextBlock2231313112311",
                Bindings =
                {
                    {nameof(TextBlock.Text),"Item3" }
                }
            });
            Children.Add(new Border
            {
                CornerRadius = "8",
                IsAntiAlias = true,
                MarginTop = 30f,
                MarginRight = 10,
                BorderFill = "247,76,49",
                Background = "247,76,49",
                Child = new TextBlock
                {
                    Foreground = "#fff",
                    Text = "99+",
                }
            });
            Children.Add(new TextBlock
            {
                Foreground = "#7E7E7E",
                MarginTop = 10f,
                MarginRight = 10,
                Text = "00:00",
            });
            Triggers.Add(nameof(IsMouseOver), Relation.Me, null, (nameof(Background), "#aaaaaa55"));
            Triggers.Add(nameof(IsSelected), Relation.Me, null, (nameof(Background), "#aaaaaa55"));
            Commands.Add(nameof(DoubleClick), nameof(QQMainModel.ClickMessageItem), null, this);
        }
    }
}
