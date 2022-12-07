namespace Day7
{
    public class DirectoryOrFile<String>
    {
        private readonly List<DirectoryOrFile<String>> children = new();
        private int size;

        public DirectoryOrFile(string name, int size = 0)
        {
            this.Name = name;
            this.size = size;
        }

        public DirectoryOrFile<String>? Parent { get; private set; }
        public string Name { get; private set; }
        public int Size { get { return this.GetSize(); } }
        public bool IsFile { get { return children.Count == 0; } }

        public List<DirectoryOrFile<String>> Children
        {
            get { return this.children; }
        }

        public DirectoryOrFile<String> AddChild(string name, int size = 0)
        {
            var node = new DirectoryOrFile<String>(name, size) { Parent = this };
            children.Add(node);
            return node;
        }

        public int GetSize()
        {
            if (this.size != 0)
            {
                return this.size;
            }

            foreach (var child in children)
            {
                this.size += child.Size;
            }

            return this.size;
        }
    }
}
