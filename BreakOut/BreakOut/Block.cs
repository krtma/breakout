using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BreakOut
{
    class Block
    {
        int x, y, width, height;

        public Block(int xa,int ya,int xb,int yb) {
            x = xa>xb? xa:xb;
            y = ya > yb ? ya : yb;
            width = xa > xb ? xa-xb : xb-xa;
            height = ya > yb ? ya - yb : yb - ya;
        }

        public bool checkHits(int X,int Y,int Width) {
            if (((((X + Width) > x)&&((X+Width)<(x + width))) || ((X + Width) < x)&&((X+Width)>(x + width))) 
                && ((((Y + Width) > y)&&((Y+Width)<(y + height))) || ((Y + Width) < y)&&((Y+Width)>(y + height))))
            {
                return true;
            }

            return false;
        }

        public void drawBlock(PaintEventArgs e,System.Drawing.Brush b)
        {
            e.Graphics.FillRectangle(b,x,y,width,height);
        }
    }
}
