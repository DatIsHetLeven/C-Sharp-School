using System;

namespace Assignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Start();
        }

        void Start()
        {
            Program p = new Program();
            Person[] person = new Person[3];
            for (int i = 0; i < 3; i++)
                person[i] = p.ReadPerson();
            for (int i = 0; i < 3; i++)
                p.PrintPerson(person[i]);
            Console.ReadKey();
        }

        int ReadInt(string question)
        {
            Console.Write(question);
            string val = Console.ReadLine();
            return Int32.Parse(val);

        }

        string ReadString(string question)
        {
            Console.Write(question);
            string val = Console.ReadLine();
            return val;
        }

        Person ReadPerson()
        {
            Person p = new Person();
            p.FirstName = ReadString("Enter first name: ");
            p.LastName = ReadString("Enter last name: ");
            p.Age = ReadInt("Enter age: ");
            p.City = ReadString("Enter city: ");
            p.gender = ReadGender("Enter gender(m/f): ");
            return p;
        }

        void PrintPerson(Person p)
        {
            Console.Write(p.FirstName + " " + p.LastName + '(');
            PrintGender(p.gender);
            Console.WriteLine(')');
            Console.WriteLine(p.Age + " years old, " + p.City);
        }

        GenderType ReadGender(string question)
        {
            while(true)
            {
                Console.Write(question);
                string val = Console.ReadLine();
                if (val.CompareTo("m") == 0)
                    return (GenderType)0;
                else if (val.CompareTo("f") == 0)
                    return (GenderType)1;
                Console.WriteLine("Please enter a valid gender");
            }  
        }

        void PrintGender(GenderType gender)
        {
            Console.Write(gender);
        }
    }
}
