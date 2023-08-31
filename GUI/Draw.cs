using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace workerMenu.View
{
    internal class Draw : Screenmanager
    {
        private int _x;
        private int _y;
        private int _height;
        private int _width;

        public Draw(int x, int y, int height, int width)
        {
            this._x = x;
            this._y = y;
            this._height = height;
            this._width = width;
        }
        /// <summary>
        /// Draws a box width our desired size.
        /// </summary>
        public void DrawBox()
        {
            DrawHorizontalLine(_x, _y, _width, '═', '╔', '╗');
            DrawHorizontalLine(_x, _y + _height, _width, '═', '╚', '╝');
            for (int i = 0; i < 2; i++)
            {
                DrawVerticalLine(_x + i * (_width - 1), _y + 1, _height - 1, '║');
            }
        }
    }
}
