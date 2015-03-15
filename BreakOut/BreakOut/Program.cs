using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Collections;

namespace BreakOut
{
    static class Program
    {

        static ArrayList block = new ArrayList();
        static Form1 f = new Form1();
        static Ball ball = new Ball(7);
        static Bar bar = new Bar(400,15,100);

        static int life = 5;
        static int state = 0;
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Thread thread = new Thread(thread1);
            thread.Start();
            ball.setPosition(20, 20);
            Application.Run(f);
        }

        static void thread1() {
            while (f != null && f.IsDisposed == false)
            {
                switch(state){
                    case 0:
                        //Title
                        break;
                    case 1:
                        ball.setPosition(bar.getX()+bar.getWidth()/2,bar.getY()-ball.getWidth());
                        break;
                    case 2:
                        if (ball.run()==false) {
                            if (life == 0)
                            {
                                state+=2;
                            }
                            else
                            {
                                state--;
                                life--;
                            }
                        }
                        checkBlock((int)ball.getX(), (int)ball.getY(), (int)ball.getWidth());
                        if (bar.checkHits(ball.getX(),ball.getY(),ball.getWidth())) {
                            ball.reflection();
                        }
                        if(block.Count==0){
                            state++;
                        }
                        break;
                    case 3:
                        break;
                }
                Thread.Sleep(16);
            }
        }

        static void loadStage(string　s) {
            string line;
            string[] numarray;
            int width, height;
            int j = 0;
            using(StreamReader r=new StreamReader(s)){
                line = r.ReadLine();
                numarray = line.Split(' ');
                width = int.Parse(numarray[0]);
                height = int.Parse(numarray[1]);
                while((line=r.ReadLine())!="END"){
                    for (int i = 0; i < line.Length;i++ )
                    {
                        if(line[i]=='1'){
                            addBlock((width + 5) * i, (height + 5) * j, (width + 5) * i+width, (height + 5) * j+height);
                        }
                    }
                    j++;
                }
            }
        }

        static public void addBlock(int x1, int y1, int x2, int y2)
        {
            block.Add(new Block(x1, y1, x2, y2));
        }

        static void checkBlock(int x, int y,int width)
        {
            Block b;
            ArrayList array = new ArrayList();
            int i;
            for (i = 0; i < block.Count; i++)
            {
                b = (Block)(block[i]);
                if (b.checkHits(x, y,width))
                {
                    array.Add(i);
                }
            }

            for (i = 0; i < array.Count; i++)
            {
                block.RemoveAt((int)array[i]);
            }
            if (array.Count!=0)
            {
                ball.reflection();
            }
        }


        public static void pushEnter()
        { 
            switch(state){
                case 0:
                    state++;
                    loadStage("stage.stage");
                    break;
                case 1:
                    state++;
                    break;
            }
        }
        public static void pushRightOrLeft(bool direction) { 
            if(direction){
                bar.toRight();
            }else{
                bar.toLeft();
            }
        }

        public static ArrayList getBlocks(){
            return block;
        }
        public static Ball getBall() {
            return ball;
        }
        public static Bar getBar() {
            return bar;
        }
        public static int getLife() {
            return life;
        }
        public static int getState() {
            return state;
        }
    }
}
