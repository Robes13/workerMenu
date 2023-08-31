using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using workerMenu.GUI;
using workerMenu.View;

namespace workerMenu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /// Here I am just testing what I've coded so far.




            Console.SetWindowSize(200, 50);
            Draw orderBox = new Draw(0, 0, 38, 60);
            orderBox.DrawBox();

            Draw storageBox = new Draw(60, 0, 38, 90);
            storageBox.DrawBox();

        
            DrawOrders printOrders = new DrawOrders(0, 0, 16, 5);
            printOrders.GetUserChoice();
            Console.ReadLine();


        }
    }
}
