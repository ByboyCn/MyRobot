using CPF;

namespace My.QQ
{
    public class NodeData : CpfObject
    {
        public NodeData()
        {
            Nodes = new Collection<NodeData>();
        }
        public string Text
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public Collection<NodeData> Nodes
        {
            get { return GetValue<Collection<NodeData>>(); }
            set { SetValue(value); }
        }

        public bool IsChecked
        {
            get { return GetValue<bool>(); }
            set { SetValue(value); }
        }
    }
}
