using Konata.Core;
using System.Reflection;

namespace Impes.PluginAes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "动态链接库(*.dll)|*.dll";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] names = fileDialog.FileNames;
                if (names.Length != 1)
                {
                    MessageBox.Show("不可选择多个文件进行加密");
                }
                var name = names[0];
                //MessageBox.Show("已选择文件:" + name, "选择文件提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var dll = File.ReadAllBytes(name);
                var assembly = Assembly.Load(dll);
                var types = GetLoadableTypes(assembly);
                var instance = types.Where(t => t.IsSubclassOf(typeof(Plugin)))
                    .FirstOrDefault();

                if (instance != null)
                {
                    //Bot bot = new Bot(null, null, null);
                   var plugin =  Activator.CreateInstance(instance, null) as Plugin;

                }
                throw new Exception("请确保文件为标准应用");
            }
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