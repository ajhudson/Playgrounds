namespace Playground.Console.HalsteadStats
{
    public static class HalsteadStatExample
    {
        public static int AlterValue(int value)
        {
            if (value != 0)
            {
                if (value < 0)
                    value += 1;
                else
                {
                    if (value == 999) //special value
                        value = 0;
                    else //process all other positive numbers
                        value -= 1;
                }
            }

            return value;
        }
    }
}
