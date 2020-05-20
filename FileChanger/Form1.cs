using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileChanger
{
    public partial class Form1 : Form
    {
        DirectoryInfo di;
        Timer timer = new Timer();
        private bool isEnabled = false;
        public Form1()
        {
            InitializeComponent();
          
        }
        
        private void label1_Click(object sender, EventArgs e)
        {
       
        

        }
        private void TimerEventProcessor(object sender, EventArgs e)
        {
            //твой код, который будет повторяться каждую секунду

             di = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory));
            if (checkBox1.Checked == true)
            {
                if (label1.Text != "Путь не выбран" && label4.Text != "Путь не выбран" && label5.Text != "Путь не выбран")
                {
                    foreach (var fi in di.GetFiles())
                    {

                        //File.Move(fi.FullName,label1.Text);
                        if (fi.Name.Contains(".jpg") || fi.Name.Contains(".png"))
                        {
                            File.Move(fi.FullName, System.IO.Path.Combine(label1.Text, fi.Name));
                        }
                        else if (fi.Name.Contains(".gif") || fi.Name.Contains(".mp4") || fi.Name.Contains(".mov"))
                        {
                            File.Move(fi.FullName, System.IO.Path.Combine(label4.Text, fi.Name));
                        }
                        else if (fi.Name.Contains(".mp3"))
                        {
                            File.Move(fi.FullName, System.IO.Path.Combine(label5.Text, fi.Name));
                        }
                        else
                        {
                            if (checkBox2.Checked)
                            {
                                File.Move(fi.FullName, System.IO.Path.Combine(label10.Text, fi.Name));
                            }
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Вы не выбрали папки");
                    timer.Stop();
                    panel1.Enabled = false;
                }

            }
            else
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    if (label1.Text != "Путь не выбран")
                    {


                        foreach (var fi in di.GetFiles("*jpg*"))
                        {

                            //File.Move(fi.FullName,label1.Text);
                            File.Move(fi.FullName, System.IO.Path.Combine(label1.Text, fi.Name));
                        }

                        foreach (var fi in di.GetFiles("*png*"))
                        {

                            //File.Move(fi.FullName,label1.Text);
                            File.Move(fi.FullName, System.IO.Path.Combine(label1.Text, fi.Name));
                        }

                        foreach (var fi in di.GetFiles("*ico*"))
                        {

                            //File.Move(fi.FullName,label1.Text);
                            File.Move(fi.FullName, System.IO.Path.Combine(label1.Text, fi.Name));
                        }
                    }
                    else
                    {
                        MessageBox.Show("Вы не выбрали папки");
                        timer.Stop();
                        panel1.Enabled = false;
                    }
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    if (label4.Text != "Путь не выбран")
                    {


                        foreach (var fi in di.GetFiles("*gif*"))
                        {

                            //File.Move(fi.FullName,label1.Text);
                            File.Move(fi.FullName, System.IO.Path.Combine(label4.Text, fi.Name));


                        }
                        foreach (var fi in di.GetFiles("*mp4*"))
                        {

                            //File.Move(fi.FullName,label1.Text);
                            File.Move(fi.FullName, System.IO.Path.Combine(label4.Text, fi.Name));


                        }
                        foreach (var fi in di.GetFiles("*mov*"))
                        {

                            //File.Move(fi.FullName,label1.Text);
                            File.Move(fi.FullName, System.IO.Path.Combine(label4.Text, fi.Name));


                        }
                    }
                    else
                    {
                        MessageBox.Show("Вы не выбрали папки");
                        timer.Stop();
                    }
                }
                else
                {
                    if (label5.Text != "Путь не выбран")
                    {


                        foreach (var fi in di.GetFiles("*mp3*"))
                        {

                            //File.Move(fi.FullName,label1.Text);
                            File.Move(fi.FullName, System.IO.Path.Combine(label5.Text, fi.Name));


                        }
                    }
                    else
                    {
                        MessageBox.Show("Вы не выбрали папки");
                        timer.Stop();
                        panel1.Enabled = true;
                    }
                }
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            label1.Text = folderBrowserDialog1.SelectedPath;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (isEnabled)
            {
                timer.Stop();
                panel1.Enabled = true;
                isEnabled = false;
                button6.Text = "Включить";
            }
            else
            {
                panel1.Enabled = false;
                timer.Interval = 1000; //1000 мс
                timer.Tick += new EventHandler(TimerEventProcessor);
                timer.Start();
                isEnabled = true;
                button6.Text = "Выключить";
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            label4.Text = folderBrowserDialog1.SelectedPath;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            label5.Text = folderBrowserDialog1.SelectedPath;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;

        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.label1.Text = "Расширенные настройки: Кнопка - Включить (Включает автоматическую сортировку файлов)\n " +
                "Раздел Выберете разширение (Выбираете из трех предложенных типоы файлов один , для его сортировки) \n" +
                " ЧекБокс Все разширения (Выбирает все разширения из списка) \n ";
            aboutForm.ShowDialog();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                panel4.Visible = true;
            }
            else
            {

                panel4.Visible = false;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            label10.Text = folderBrowserDialog1.SelectedPath;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox2.Visible = true;
            }
            else
            {

                checkBox2.Visible = false;
            }
        }
    }
}
