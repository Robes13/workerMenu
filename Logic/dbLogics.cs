using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using workerMenu.Dahl;

namespace workerMenu.Logik
{
    internal class dbLogics
    {
        public string[,] ReturnOrders()
        {
            Database db = new Database();
            return db.GetOrders();
        }

    }
}
