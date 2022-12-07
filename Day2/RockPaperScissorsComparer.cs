namespace Day2
{
    public class RockPaperScissorsComparer : Comparer<string>
    {
        private readonly Dictionary<string, string> moves = new() { { "A", "X" }, { "B", "Y" }, { "C", "Z" } };
        private readonly Dictionary<string, int> score = new() { { "X", 1 }, { "Y", 2 }, { "Z", 3 } };

        public int GetScoreForInput(string input)
        {
            if (!score.ContainsKey(input))
            {
                input = moves[input];
            }

            return score[input];
        }

        public string GetInputForScore(string opponent, int score)
        {
            var possibleInputs = new string[] { "X", "Y", "Z" };

            foreach (var input in possibleInputs)
            {
                if (this.Compare(opponent, input) == score)
                {
                    return input;
                }
            }

            return opponent;
        }

        public override int Compare(string? x, string? y)
        {
            if (x == null || y == null) return 0;

            var opponent = moves[x];

            if (opponent == y)
            {
                return 0;
            }

            switch (opponent)
            {
                case "X":
                    if (y == "Y") return 1;
                    break;

                case "Y":
                    if (y == "Z") return 1;
                    break;

                case "Z":
                    if (y == "X") return 1;
                    break;
            }

            return -1;
        }
    }
}