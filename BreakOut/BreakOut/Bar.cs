using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BreakOut
{
    class Bar
    {
        double x,y,height,width;
        public Bar(double pos,double Height,double Width) {
            height = Height;
            width = Width;
            y = pos;
            x = 320 - width / 2;
        }
        public void drawBar(System.Windows.Forms.PaintEventArgs e, System.Drawing.Brush b)
        {
            e.Graphics.FillRectangle(b, (int)x, (int)y, (int)width, (int)height);
        }
 
        public void toRight(){
            x = (x + 30 + width) < 640 ? x + 30 : 640 - width;
        }

        public void toLeft(){
            x = (x - 30) > 0 ? x - 30 : 0; ;
        }

        public bool checkHits(double X,double Y,double Width) {
            if (((((X + Width) > x) && ((X + Width) < (x + width))) || ((X + Width) < x) && ((X + Width) > (x + width)))
                && ((((Y + Width) > y) && ((Y + Width) < (y + height))) || ((Y + Width) < y) && ((Y + Width) > (y + height)))) {
                    return true;
            }
            return false;
        }
        public double getX() {
            return x;
        }

        public double getWidth() {
            return width;
        }
        public double getY() {
            return y;
        }
    }
}
