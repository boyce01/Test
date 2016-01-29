using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading; //线程
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _777摇奖机
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //声明一个bool变量，来判断是暂停or开始
        bool b = false;

        private void button1_Click(object sender, EventArgs e)
        {
            if (b == false) //当b为false时，显示start，b改成true，执行新线程PlayGame()方法
            {
                b = true;
                button1.Text = "Pause";
                //new一个新线程，去执行PlayGame()方法
                Thread th = new Thread(PlayGame);
                th.IsBackground = true;
                th.Start();
            }
            else //当b为true时，显示pause，b改成false，不再执行新线程PlayGame()方法
            {
                b = false; 
                button1.Text = "Start";
            }
        }

        private void PlayGame()
        {
            Random r = new Random();
            while (b) //当b==true时，执行while循环
            {
                label1.Text = r.Next(0, 10).ToString();
                label2.Text = r.Next(0, 10).ToString();
                label3.Text = r.Next(0, 10).ToString();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //程序加载时，取消跨线程的检查
            Control.CheckForIllegalCrossThreadCalls = false;
        }
    }
}
