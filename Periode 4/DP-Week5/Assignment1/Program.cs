using System;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            Program myprogram = new Program();
            myprogram.Start();
        }
        void Start()
        {
            Logger logger = Logger.GetInstance();           
            MainSystem mainSystem = new MainSystem();
            logger.Log("main", "starting");
            mainSystem.DoSomeMainWork();            
            logger.Log("main", "finishing");
            Console.ReadKey();
        }
    }
}
