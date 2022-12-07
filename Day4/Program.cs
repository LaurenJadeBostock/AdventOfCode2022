namespace Day4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Day 4: Camp Cleanup");

            Console.WriteLine("1. Test File");
            Console.WriteLine("2. Input File");

            var key = Console.ReadLine();

            if (key != "1" && key != "2")
            {
                return;
            }

            var file = key == "1" ? "/Inputs/Test.txt" : "/Inputs/Input.txt";
            var path = Environment.CurrentDirectory + file;

            PartOne(path);
            PartTwo(path);

        }

        private static void PartOne(string path)
        {
            var total = 0;

            foreach (var line in File.ReadAllLines(path))
            {
                var pairs = line.Split(",", StringSplitOptions.RemoveEmptyEntries);

                var section1 = pairs[0].Split("-", StringSplitOptions.RemoveEmptyEntries);
                var section2 = pairs[1].Split("-", StringSplitOptions.RemoveEmptyEntries);

                var s1min = int.Parse(section1[0]);
                var s1max = int.Parse(section1[1]);

                var s2min = int.Parse(section2[0]);
                var s2max = int.Parse(section2[1]);

                if ((s1min <= s2min && s1max >= s2max) || (s2min <= s1min && s2max >= s1max))
                {
                    total++;
                }
            }

            Console.WriteLine($"Total of complete overlaps: {total}");
        }

        private static void PartTwo(string path)
        {
            var total = 0;

            foreach (var line in File.ReadAllLines(path))
            {
                var pairs = line.Split(",", StringSplitOptions.RemoveEmptyEntries);

                var section1 = pairs[0].Split("-", StringSplitOptions.RemoveEmptyEntries);
                var section2 = pairs[1].Split("-", StringSplitOptions.RemoveEmptyEntries);

                var s1min = int.Parse(section1[0]);
                var s1max = int.Parse(section1[1]);

                var s2min = int.Parse(section2[0]);
                var s2max = int.Parse(section2[1]);

                if (s1min == s2min || s1max == s2max || (s1min <= s2min && s1max >= s2min) || (s2min <= s1min && s2max >= s1min))
                {
                    total++;
                }
            }

            Console.WriteLine($"Total of overlaps: {total}");
        }
    }
}