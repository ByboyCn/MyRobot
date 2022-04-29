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
            fileDialog.Title = "��ѡ���ļ�";
            fileDialog.Filter = "��̬���ӿ�(*.dll)|*.dll";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] names = fileDialog.FileNames;
                if (names.Length != 1)
                {
                    MessageBox.Show("����ѡ�����ļ����м���");
                }
                var name = names[0];
                //MessageBox.Show("��ѡ���ļ�:" + name, "ѡ���ļ���ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                throw new Exception("��ȷ���ļ�Ϊ��׼Ӧ��");
            }
        }

        /// <summary>
        /// ��������Type���ų����������õģ�
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