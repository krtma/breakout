using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BreakOut
{
    class Ball
    {
        const int norm = 5;
        double x, y,width;
        double speedx, speedy;

        public Ball(int Width) {
            speedx = Math.Sqrt(12.5);
            speedy = Math.Sqrt(12.5);
            width = Width;
        }

        public void drawBall(System.Windows.Forms.PaintEventArgs e, System.Drawing.Brush b)
        {
            e.Graphics.FillEllipse(b,(int)(x-width),(int)(y-width),(int)(width*2),(int)(width*2));
        }

        public void setPosition(double X,double Y) {
            x = X;
            y = Y;
        }

        public bool run()
        {
            double tmpx;
            x += speedx;
            y += speedy;

            if(y>(480+width)){
                return false;
            }

            if((y-width)<0){
                reflection();
            }

            if((x-width)<0){
                tmpx = width-x;
                speedx *= -1;
                x = tmpx+width;
            }

            if((x+width)>640){
                tmpx = x +width - 640;
                speedx *= -1;
                x = 640 - tmpx - width;
            }

            return true;
        }

        public void reflection() {
            speedy*=-1;
        }

        public double getX(){
            return x;
        }
        public double getY() {
            return y;
        }
        public double getWidth() {
            return width;
        }
    }
}
