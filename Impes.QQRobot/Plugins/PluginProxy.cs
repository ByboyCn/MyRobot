using Impes.QQRobot.Commons;
using Konata.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Impes.QQRobot.Plugins
{
    internal class PluginProxy
    {
        /// <summary>
        /// dll
        /// </summary>
        private byte[] RawDll;

        /// <summary>
        /// 插件
        /// </summary>
        public Plugin Plugin { get; set; }
        /// <summary>
        /// bot
        /// </summary>
        public Bot Bot { get; set; }
        /// <summary>
        /// 应用Md5值
        /// </summary>
        public string Md5 { get; private set; }
        /// <summary>
        /// 插件路径
        /// </summary>
        public string Filename { get; set; }
        /// <summary>
        /// 是否运行
        /// </summary>
        public bool IsRunning { get; set; } = false;
        /// <summary>
        /// 唯一标识
        /// </summary>
        public string Guid { get; set; }

        /// <summary>
        /// 获取插件信息
        /// </summary>
        /// <param name="filename">插件位置</param>
        /// <returns></returns>
        public bool GetInfo(string filename)
        {

            if (File.Exists(filename))
            {
                return false;
            }
            RawDll = File.ReadAllBytes(filename);
            Md5 = RawDll.MD5ByString();
            return true;
        }
        /// <summary>
        /// 启动插件
        /// </summary>
        public bool Start(Bot Bot)
        {
            if (!GetInfo(Filename))
            {
                return false;
            }
            //构建插件
            Plugin = CreateInstance(RawDll, this.Bot);
            return true;
        }
        /// <summary>
        /// 停止插件
        /// </summary>
        public bool Stop()
        {
            try
            {
                Plugin?.Stop();
            }
            catch { }
            Plugin = null;
            IsRunning = false;
            return true;
        }
        /// <summary>
        /// 打开设置窗口
        /// </summary>
        public void OpenSettingsForm()
        {
            try
            {
                Plugin?.OpenSettingsForm();
            }
            catch { }
        }
        /// <summary>
        /// 委托执行
        /// </summary>
        /// <param name="method"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public object Invoke(string method, params object[] parameters)
        {
            var func = Plugin.GetType().GetMember(method);
            if (func.Length > 0)
            {
                try
                {
                    return Plugin.GetType().GetMethod(method)?.Invoke(Plugin, parameters);
                }
                catch { }
            }
            return null;
        }
        /// <summary>
        /// 创建插件实例
        /// </summary>
        /// <param name="dll"></param>
        /// <param name="bot"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private Plugin CreateInstance(byte[] dll, Bot bot)
        {
            if (dll == null)
            {
                return null;
            }
            var assembly = Assembly.Load(dll);
            var types = GetLoadableTypes(assembly);
            var instance = types.Where(t => t.IsSubclassOf(typeof(Plugin))).FirstOrDefault();

            if (instance != null)
            {
                try
                {
                    //取唯一标识
                    Guid = ((System.Runtime.InteropServices.GuidAttribute)assembly.GetCustomAttributes(typeof(System.Runtime.InteropServices.GuidAttribute), true)[0]).Value.ToLower();
                }
                catch { }

                return Activator.CreateInstance(instance, bot) as Plugin;
            }
            throw new Exception("请确保文件为标准应用，或尝试更新应用");
        }
        /// <summary>
        /// 查找所有Type（排除不存在引用的）
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        private IEnumerable<Type> GetLoadableTypes(Assembly assembly)
        {
            if (assembly == null) throw new ArgumentNullException(nameof(assembly));
            try
            {
                return assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                return e.Types.Where(t => t != null);
            }
        }
    }
}
