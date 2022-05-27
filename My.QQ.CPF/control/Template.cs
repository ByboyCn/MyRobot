using CPF.Controls;
using CPF.Drawing;
using CPF.Shapes;

namespace My.QQ.CPF
{
    public class Template : Control
    {
        protected override void InitializeComponent()
        {
            Children.Add(new TextBlock { Text = "测试" });
            Children.Add(new Line { StartPoint = new Point(), EndPoint = new Point(20, 20), StrokeFill = "#f00" });
        }
    }
}
