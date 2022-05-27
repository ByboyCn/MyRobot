﻿using CPF.Controls;
using CPF.Drawing;
using CPF.Shapes;

namespace My.QQ
{
    public class Component1 : Control
    {
        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        protected override void InitializeComponent()
        {
            Children.Add(new StackPanel
            {
                Children =
                {
                    new TextBlock
                    {
                        Text = "test"
                    },
                    new Button
                    {
                        Content = "自定义模板就是这样做啊"
                    },
                    new CheckBox
                    {
                        Content = "测试",
                        IsChecked=true
                    },
                    new RadioButton
                    {
                        Content="单选1"
                    },
                    new RadioButton
                    {
                        Content="单选2",
                        IsChecked=true
                    },
                    new Picture
                    {
                        Source="http://tb2.bdstatic.com/tb/static-puser/widget/celebrity/img/single_member_100_0b51e9e.png"
                    },
                    new ScrollBar
                    {
                        Orientation= Orientation.Horizontal,
                        Width=200,
                        Height=20,
                        Value=0.8f
                    },
                    new Ellipse
                    {
                        Width=60,
                        Height=40,
                        IsAntiAlias=true,
                        Fill="#f00",
                        StrokeStyle=new Stroke(2,DashStyles.Dash)
                    },
                }
            });
            if (DesignMode) {
                Children.Add(new Template());
            }
        }
        #endregion
    }
}
