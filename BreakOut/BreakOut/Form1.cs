using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Threading;
using System.Timers;

namespace BreakOut
{
    public partial class Form1 : Form
    {
        Font font=new Font("MSPゴシック",12);
        Font titlefont = new Font("MSPゴシック",30);
        public Form1()
        {
            Width = 640;
            Height = 480;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            //this.KeyDown+=new KeyEventHandler(Form1_KeyDown);
            Thread thread = new Thread(new ThreadStart(draw));
            thread.Start();
        }



        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            switch(Program.getState()){
                case 0:
                    e.Graphics.DrawString("Break out",titlefont,Brushes.Black,100,100);
                    e.Graphics.DrawString("Plese push enter key",titlefont,Brushes.Black,200,200);
                    break;
                case 1:
                    goto case 2;
                case 2:
                    drawBlock(e, Brushes.Yellow, Program.getBlocks());
                    (Program.getBall()).drawBall(e, Brushes.Black);
                    (Program.getBar()).drawBar(e,Brushes.Blue);
                    e.Graphics.DrawString("Life : "+ Program.getLife().ToString(),font,Brushes.Black,560,400);
                    break;
                case 3:
                    e.Graphics.DrawString("Game Clear", titlefont, Brushes.Black, 100, 100);
                    break;
                case 4:
                    e.Graphics.DrawString("Game Over", titlefont, Brushes.Black, 100, 100);
                    break;
            }
        }

        void draw() {
            while(IsDisposed == false){
                Invalidate();
                Thread.Sleep(16);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Program.pushEnter();
            }
            if (e.KeyCode == Keys.Right)
            {
                Program.pushRightOrLeft(true);
            }
            if (e.KeyData == Keys.Left)
            {
                Program.pushRightOrLeft(false);
            }
        }


        protected override bool ProcessDialogKey(Keys keyData)
        {

            if(keyData==Keys.Enter){
                Program.pushEnter();
            }

            if (keyData == Keys.Right)
            {
                Program.pushRightOrLeft(true);
            }
            if (keyData == Keys.Left)
            {
                Program.pushRightOrLeft(false);
            }

            return true;
        }

        void drawBlock(PaintEventArgs e,Brush brush,ArrayList block)
        {
            Block b;
            for (int i = 0;i< block.Count;i++ )
            {
                b=(Block)(block[i]);
                b.drawBlock(e,brush);
            }
        }

    }
}
