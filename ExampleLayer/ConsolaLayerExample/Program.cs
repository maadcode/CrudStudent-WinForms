using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolaLayerExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var message = MessageHelper.Message;
            Console.WriteLine(message);
            Console.ReadLine();
        }
    }
}
