using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Media;
namespace PlayMusic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //声明一个List泛型集合,用于存放选中的音乐文件的全路径：
        List<string> listSong = new List<string>();

        /// <summary>
        /// 选择要播放的音乐文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "请选择音乐文件";
            ofd.Multiselect = true;
            ofd.InitialDirectory = @"C:\Users\up\Desktop\music";
            ofd.Filter = "音乐文件|*.wav|所有文件|*.*";
            ofd.ShowDialog();
            //获得所选音乐文件的全路径(可多选)
            string[] path = ofd.FileNames;
            //遍历所有选中的yinyuewenj,并在listBox1中显示：
            for (int i = 0; i < path.Length; i++)
            {
                //Path.GetFileName()方法:用于获得文件名
                listBox1.Items.Add(Path.GetFileName(path[i]));
                //把选中音乐文件的全路径赋值给List泛型集合：
                listSong.Add(path[i]);
            }
        }

        //声明在方法外，以便于其他类调用
        SoundPlayer sp = new SoundPlayer();

        /// <summary>
        /// 双击列表中的音乐,并播放该音乐
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            //将选中的文件的全路径(存在list集合中)赋值给SoundLocation
            sp.SoundLocation = listSong[listBox1.SelectedIndex]; //listBox1.SelectedIndex:当前选中的文件的索引
            sp.Play();
        }

        /// <summary>
        /// 播放下一曲
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, EventArgs e)
        {
            //获得当前播放音乐的索引：
            int index = listBox1.SelectedIndex;
            index++; //播放下一曲：当前索引加1
            if (index == listBox1.Items.Count)
            {
                index = 0;
            }
            //把新的索引赋值给当前选中项的索引，这样才能让蓝条变化
            listBox1.SelectedIndex = index;
            sp.SoundLocation = listSong[index];
            sp.Play();
        }

        /// <summary>
        /// 播放上一曲
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPre_Click(object sender, EventArgs e)
        {
            //获得当前播放音乐文件的索引：
            int index = listBox1.SelectedIndex;
            index--;
            if (index < 0)
            {
                index = listBox1.Items.Count-1;
            }
            listBox1.SelectedIndex = index;
            sp.SoundLocation = listSong[index];
            sp.Play();
        }
    }
}
