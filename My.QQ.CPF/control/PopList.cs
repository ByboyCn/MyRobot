using CPF;
using CPF.Controls;

namespace My.QQ
{
    public class PopList : Control
    {
        protected override void InitializeComponent()
        {//模板定义
            Children.Add(new Border
            {
                Size = SizeField.Fill,
                ShadowBlur = 5,
                Background = "#ffffffee",
                BorderStroke = "0",
                Child = new ListBox
                {
                    Size = SizeField.Fill,
                    MaxHeight = 300,
                    ItemTemplate = typeof(PopItem),
                    SelectedValuePath = "Item3",
                    Bindings =
                    {
                        {nameof(ListBox.Items),nameof(LoginModel.UserList) },
                        {nameof(ListBox.SelectedValue),nameof(LoginModel.QQ),null,BindingMode.OneWayToSource }
                    }
                }
            });
        }
    }
}
