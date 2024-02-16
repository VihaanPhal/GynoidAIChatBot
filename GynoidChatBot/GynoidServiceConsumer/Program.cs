using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GynoidServiceConsumer
{
    internal class Program
    {

        static void Main(string[] args)
        {
            ServiceReference1.Service1Client myService = new ServiceReference1.Service1Client();
            bool t = true;
            while (t)
            {

                Console.Write("Vihaan: ");
                String str = Console.ReadLine();
                if (str == "exit")
                {
                    t = false;
                    
                    Console.WriteLine("Exiting in 1");
                    Thread.Sleep(1000);
                    Console.WriteLine("Exiting in 2");
                    Thread.Sleep(1000);
                    Console.WriteLine("Exiting in 3");
                    Thread.Sleep(1000);
                    break;
                }
                else
                {
                    String answer = myService.GetAnswer(str);
                    Console.WriteLine("\nGYNOID: " + answer);
                }
            }

        }
    }
}
