using System;

namespace MyTools
{
    public class ReadTools
    {
        public static string ReadString(string question)
        {
            Console.Write(question);
            string val = Console.ReadLine();
            return val;
        }

        public static int ReadInt(string question)
        {
            bool isint = false;
            int value = 0;
            do
            {
                Console.Write(question);
                string val = Console.ReadLine();
                isint = int.TryParse(val, out value);
            } while (isint == false);

            return value;
        }

        public static int ReadInt(string question, int min, int max)
        {
            Boolean ask = true;
            int val = -1;
            while (ask)
            {
                val = ReadInt(question);
                if (val > min && val < max)
                {
                    ask = false;
                }
                else
                {
                    continue;
                }
            }
            return val;
        }
    }
}
