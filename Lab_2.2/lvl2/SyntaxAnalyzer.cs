using System;

namespace lvl2
{
    public class SyntaxAnalyzer
    {
        private enum State
        {
            S0_Start,
            S1_Percent,
            S2_Letters,
            S3_Percent_Final,
            Error
        }

        public bool Analyze(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            State currentState = State.S0_Start;

            foreach (char c in input)
            {
                switch (currentState)
                {
                    case State.S0_Start:
                        if (c == '%')
                        {
                            currentState = State.S1_Percent;
                        }
                        else
                        {
                            currentState = State.Error;
                        }
                        break;

                    case State.S1_Percent:
                        if (c >= 'A' && c <= 'Z')
                        {
                            currentState = State.S2_Letters;
                        }
                        else
                        {
                            currentState = State.Error;
                        }
                        break;

                    case State.S2_Letters:
                        if (c >= 'A' && c <= 'Z')
                        {
                            currentState = State.S2_Letters;
                        }
                        else if (c == '%')
                        {
                            currentState = State.S3_Percent_Final;
                        }
                        else
                        {
                            currentState = State.Error;
                        }
                        break;

                    case State.S3_Percent_Final:
                        currentState = State.Error;
                        break;

                    case State.Error:
                        return false;
                }
            }

            return currentState == State.S3_Percent_Final;
        }
    }
}