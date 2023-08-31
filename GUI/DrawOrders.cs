using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using workerMenu.Logik;
using workerMenu.View;

namespace workerMenu.GUI
{
    internal class DrawOrders : Screenmanager
    {
        private int _startx;
        private int _starty;
        private int _currentColumn;
        private int _currentRow;

        public DrawOrders(int currentRow, int currentColumn, int x, int y)
        {
            this._currentColumn = currentColumn;
            this._currentRow = currentRow;
            this._startx = x;
            this._starty = y;
        }
        /// <summary>
        /// This method makes it possible for the worker control what order they are currently 'hovering' over, and when they
        /// want to select an order to 'work on' they can press enter, and the orderID selected will be returned in a string.
        /// </summary>
        /// <returns></returns>
        public string GetUserChoice()
        {
            _currentRow = 0;
            _currentColumn = 0;


            dbLogics getOrders = new dbLogics();
            string[,] orders = getOrders.ReturnOrders();

            int numRows = orders.GetLength(0);
            int numColumns = orders.GetLength(1);

            while (true)
            {
                DrawText(26, 3, "Orders");
                PrintOrders(orders, _currentRow, _currentColumn, _startx, _starty);

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    _currentRow = (_currentRow - 1 + numRows) % numRows;
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    _currentRow = (_currentRow + 1) % numRows;
                }
                else if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    _currentColumn = (_currentColumn - 1 + numColumns) % numColumns;
                }
                else if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    _currentColumn = (_currentColumn + 1) % numColumns;
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    return orders[_currentRow, _currentColumn];
                }
            }
        }
        /// <summary>
        /// This method prints all the orders out, and colours the order that is currently being hovered by the worker, 
        /// it is used by the method above to print out the order numbers, and make the current selected order colored with yellow.
        /// </summary>
        /// <param name="orders"></param>
        /// <param name="selectedRow"></param>
        /// <param name="selectedColumn"></param>
        /// <param name="startX"></param>
        /// <param name="startY"></param>
        public void PrintOrders(string[,] orders, int selectedRow, int selectedColumn, int startX, int startY)
        {
            for (int i = 0; i < orders.GetLength(0); i++)
            {
                for (int j = 0; j < orders.GetLength(1); j++)
                {
                    if (i == selectedRow && j == selectedColumn)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    }
                    DrawText(startX + (j * 5), startY, orders[i, j]);
                    Console.ResetColor();
                }
                startY += 3;
            }
        }
    }
}
