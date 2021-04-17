using System;
using System.IO;

namespace DataStorage
{
    class Program
    {
        static void Main(string[] args)
        {
            Program myprogram = new Program();
            myprogram.start();
            Console.ReadKey();
        }

        public Person ReadPerson()
        {
            Person p = new Person();
            p.name = helper.ReadString("Enter your name: ");
            p.city = helper.ReadString("Enter your city: ");
            p.age = helper.ReadInt("Enter your age: ");
            Console.WriteLine("Your data is written to file");
            return p;
        }

        public void DisplayPerson(Person p)
        {
            Console.WriteLine("{0, -10} : {1}", "Name", p.name);
            Console.WriteLine("{0, -10} : {1}", "City", p.city);
            Console.WriteLine("{0, -10} : {1}", "Age", p.age);
        }

        void WritePerson(Person p, string filename)
        {
            StreamWriter w = new StreamWriter(filename, append: true);
            w.WriteLine(p.name);
            w.WriteLine(p.city);
            w.WriteLine(p.age);
            w.Close();
        }

        Person ReadPerson(string filename)
        {
            Person p = new Person();

            if (!File.Exists(filename))
            {
                return null;
            }

            StreamReader r = File.OpenText(filename);
            p.name = r.ReadLine();
            p.city = r.ReadLine();
            p.age = int.Parse(r.ReadLine());

            return p;
        }

        void start()
        {
            Person p;
            string name = helper.ReadString("Enter your name: ");
            p = ReadPerson(name + ".txt");

            if (p  == null)
            {
                Console.WriteLine("Welcome {0}!", name);
                p = ReadPerson();
                WritePerson(p, p.name + ".txt");
            }
            else
            {
                //Console.WriteLine("Nice to see you again {0}!", p.name);
                //Console.WriteLine("We have the following information about you:");
                DisplayPerson(p);
            }
            Console.ReadKey();
        }
    }
}
