using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoYouLoveMe
{
    public partial class Form1 : Form
    {
        public Form1() //Form1类的构造函数
        {
            InitializeComponent(); //初始化组件的方法
            //当一个初始化一个窗体的时候，也会初始化窗体上的所有组件！！！
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("yes"); //MessageBox.Show("");等于Console.WriteLine("");
            this.Close(); //关闭Form1主窗体
        }

        /// <summary>
        /// 当鼠标进入按钮可见部分时，给按钮一个新坐标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_MouseEnter(object sender, EventArgs e)
        {
            //给按钮一个新坐标：
            //这个按钮的最大宽度就是=窗体的宽度-按钮的宽度
            //int x=this.Width; //this表示这个窗体；Width表示宽度（定值）
            int x = this.ClientSize.Width - button2.Width; //ClientSize表示，当窗体大小变化时，size也会变化
            int y = this.ClientSize.Height - button2.Height;
            
            //给unlove按钮一个随机的坐标：
            Random r = new Random();
            button2.Location = new Point(r.Next(0, x + 1), r.Next(0, y + 1));
            //Location：该控件的位置坐标；
            //new Point()：初始化一个点的坐标；
            //r.Next(0,x):最大值取到x-1

        }

        /// <summary>
        /// 当单击到button2时，展示信息，并关闭窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("cateched");
            this.Close();
        }

        /// <summary>
        /// 当输入文本时，在label控件里显示所输入的文本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label1.Text = textBox1.Text; //把TextBox文本框中的文本（值）赋值给label控件（显示出来）
            //Text（是个属性）:输入的当前文本
        }

        
    }
}
