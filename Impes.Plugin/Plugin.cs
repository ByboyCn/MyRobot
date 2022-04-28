using Konata.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Impes
{
    /// <summary>
    /// Plugin二次开发继承类
    /// </summary>
    public abstract class Plugin
    {
        #region 私有变量
        private readonly Bot bot;
        #endregion
        #region 公共变量
        /// <summary>
        /// 插件的名称
        /// </summary>
        public string PluginId { get; set; } = "请安装后查看";
        /// <summary>
        /// 插件的名称
        /// </summary>
        public string PluginName { get; set; } = "请安装后查看";
        /// <summary>
        /// 插件描述
        /// </summary>
        public string Description { get; set; } = "请安装后查看";
        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; } = "请安装后查看";
        #endregion
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="bot">实例</param>
        public Plugin(Bot bot)
        {
            this.bot = bot ?? throw new ArgumentNullException("use ctor : base(client)");
        }

        #region 抽象方法

        /// <summary>
        /// 应用启动时执行
        /// </summary>
        public abstract void Start();

        /// <summary>
        /// 应用停止时执行
        /// 所有定时器、订阅请在停止时释放
        /// </summary>
        public abstract void Stop();

        /// <summary>
        /// 打开应用窗口
        /// </summary>
        public abstract void OpenSettingsForm();

        #endregion
    }
}
