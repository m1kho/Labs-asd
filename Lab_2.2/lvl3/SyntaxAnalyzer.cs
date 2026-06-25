namespace lvl3
{
    public class SyntaxAnalyzer
    {
        private readonly int[,] _transitionMatrix = new int[5, 3]
        {
            { 1, 4, 4 },
            { 4, 2, 4 },
            { 3, 2, 4 },
            { 4, 4, 4 },
            { 4, 4, 4 }
        };

        private int GetInputClass(char c)
        {
            if (c == '%')
            {
                return 0;
            }
            if (c >= 'A' && c <= 'Z')
            {
                return 1;
            }
            return 2;
        }

        public bool Analyze(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            int state = 0;
            foreach (char c in input)
            {
                int inputClass = GetInputClass(c);
                state = _transitionMatrix[state, inputClass];
                if (state == 4)
                {
                    return false;
                }
            }

            return state == 3;
        }
    }
}
