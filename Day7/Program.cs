namespace Day7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Day 7: No Space Left On Device");

            Console.WriteLine("1. Test File");
            Console.WriteLine("2. Input File");

            var key = Console.ReadLine();

            if (key != "1" && key != "2")
            {
                return;
            }

            var file = key == "1" ? "/Inputs/Test.txt" : "/Inputs/Input.txt";
            var path = Environment.CurrentDirectory + file;

            var tree = CreateTree(path);

            if (tree == null)
            {
                return;
            }

            PrintTree(tree);

            var totalSum = TraverseChildren(tree);
            Console.WriteLine($"Part One Total Sum: {totalSum}");

            var spaceToFree = 30000000 - (70000000 - tree.Size);
            var spaceToDelete = TraverseChildrenPt2(tree, spaceToFree);
            Console.WriteLine($"Part Two Total Sum: {spaceToDelete}");

        }

        private static int TraverseChildren(DirectoryOrFile<string> current)
        {
            var sum = 0;
             
            if (current.Size <= 100000 && current.IsFile == false)
            {
                sum += current.Size;
            }

            foreach (var child in current.Children)
            {
                sum += TraverseChildren(child);
            }

            return sum;
        }

        private static int TraverseChildrenPt2(DirectoryOrFile<string> current, int spaceToFree)
        {
            var spaceToDelete = 0;

            if (current.IsFile == false && current.Size >= spaceToFree && (spaceToDelete == 0 || current.Size <= spaceToDelete))
            {
                spaceToDelete = current.Size;
            }

            foreach (var child in current.Children)
            {
                var subDirectorySpaceToDelete = TraverseChildrenPt2(child, spaceToFree);

                if (subDirectorySpaceToDelete != 0 && subDirectorySpaceToDelete <= spaceToDelete)
                {
                    spaceToDelete = subDirectorySpaceToDelete;
                }
            }

            return spaceToDelete;
        }

        private static void PrintTree(DirectoryOrFile<string> tree)
        {
            Console.WriteLine($"{tree.Name} {tree.Size}");
            PrintChildren(tree, 0);
        }

        private static void PrintChildren(DirectoryOrFile<string> current, int depth)
        {
            depth++;
            foreach (var child in current.Children)
            {
                var dash = "";
                for (int i = 0; i < depth; i++)
                {
                    dash += "-";
                }
                Console.WriteLine($"{dash} {child.Name} {child.Size}");
                PrintChildren(child, depth);
            }
        }

        private static DirectoryOrFile<string> CreateTree(string path)
        {
            DirectoryOrFile<string>? root = null;
            DirectoryOrFile<string>? currentDirectory = null;

            foreach (var line in File.ReadAllLines(path))
            {
                if (line.StartsWith("dir")) { continue; }

                if (line.StartsWith("$"))
                {
                    var commandParts = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    var command = commandParts[1];

                    if (command == "ls") { continue; }

                    var treePath = commandParts[2];

                    if (root == null)
                    {
                        root = new DirectoryOrFile<string>(treePath);
                        currentDirectory = root;
                        continue;
                    }

                    if (treePath == "/")
                    {
                        currentDirectory = root;
                        continue;
                    }

                    if (treePath == "..")
                    {
                        currentDirectory = currentDirectory?.Parent;
                        continue;
                    }

                    currentDirectory = currentDirectory?.AddChild(treePath);
                    continue;
                }

                var fileName = line.Split(" ")[1];
                var size = line.Split(" ")[0];

                currentDirectory?.AddChild(fileName, int.Parse(size));
            }

            return root;
        }
    }
}