using System;

public static class helper
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
}

