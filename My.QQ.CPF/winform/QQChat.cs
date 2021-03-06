using CPF;
using CPF.Controls;

namespace My.QQ
{
    public class QQChat : Window
    {
        protected override void InitializeComponent()
        {
            Title = "标题";
            Width = 800;
            Height = 600;
            Background = null;
            CanResize = true;
            MinWidth = 500;
            MinHeight = 300;
            Children.Add(new WindowFrame(this, new Panel
            {
                Width = "100%",
                Height = "100%",
                Children =
                {//内容元素放这里
                    new ChatTabControl
                    {
                        Size= SizeField.Fill,
                        Items =
                        {
                            new ChatTabItem
                            {
                                Header="昵称1",
                                Content=new ChatPage
                                {

                                }
                            },
                            new ChatTabItem
                            {
                                Header="昵称2",
                                Content=new ChatPage
                                {

                                }
                            },
                            new ChatTabItem
                            {
                                Header="昵称2",
                                Content=new ChatPage
                                {

                                }
                            },
                            new ChatTabItem
                            {
                                Header="昵称2",
                                Content=new ChatPage
                                {

                                }
                            },
                            new ChatTabItem
                            {
                                Header="昵称2",
                                Content=new ChatPage
                                {

                                }
                            },
                            new ChatTabItem
                            {
                                Header="昵称2",
                            },
                            new ChatTabItem
                            {
                                Header="昵称2",
                            },
                        }
                    }
                }
            })
            { MaximizeBox = true });

            LoadStyleFile("res://My.QQ.CPF/css/QQChat.css");//加载样式文件，文件需要设置为内嵌资源

            if (!DesignMode)//设计模式下不执行
            {

            }
        }
    }
}
