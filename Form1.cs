using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Timers.Timer;
using System.Diagnostics;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Media;


namespace JokeVirus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            //создаем новый процесс
            Process proc = new Process();
            //Запускаем Блокнто
            proc.StartInfo.FileName = @"status.exe";
            proc.StartInfo.Arguments = "";
            proc.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //создаем новый процесс
            Process proc = new Process();
            //Запускаем Блокнто
            proc.StartInfo.FileName = @"don'topen.exe";
            proc.StartInfo.Arguments = "";
            proc.Start();
        }

       
       
        private void button3_Click(object sender, EventArgs e)
        {
            //создаем новый процесс
            Process proc = new Process();
            //Запускаем Блокнто
            proc.StartInfo.FileName = @"setup.exe";
            proc.StartInfo.Arguments = "";
            proc.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RegistryKey _reg = Registry.LocalMachine;
            _reg = _reg.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer", RegistryKeyPermissionCheck.ReadWriteSubTree);
            _reg.SetValue("NoDrives", 67108863, RegistryValueKind.DWord);
            _reg.Close();
            foreach (Process proc in Process.GetProcessesByName("explorer"))
            {
                proc.Kill();
            }
            Process.Start("explorer");

          
        }

        private void button6_Click(object sender, EventArgs e)
        {
            RegistryKey reg = Registry.LocalMachine;
            reg = reg.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer", RegistryKeyPermissionCheck.ReadWriteSubTree);
            reg.SetValue("NoDrives", 0, RegistryValueKind.DWord);
            reg.Close();
            foreach (Process proc in Process.GetProcessesByName("explorer"))
            {
                proc.Kill();
            }
            Process.Start("explorer");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Process proc = new Process();
            //Запускаем Блокнто
            proc.StartInfo.FileName = @"start.exe";
            proc.StartInfo.Arguments = "";
            proc.Start();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //создаем новый процесс
            Process proc = new Process();
            //Запускаем Блокнто
            proc.StartInfo.FileName = @"run.vbs";
            proc.StartInfo.Arguments = "";
            proc.Start();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //создаем новый процесс
            Process proc = new Process();
            //Запускаем Блокнто
            proc.StartInfo.FileName = @"hlprun.bat";
            proc.StartInfo.Arguments = "";
            proc.Start();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            SetWallpaper("C:\\Windows\\jokevirus.jpg", 1, 0);
        }

        public static void SetWallpaper(string path, int style, int tile)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Control Panel\\Desktop", true);
            key.SetValue("WallpaperStyle", style.ToString());
            key.SetValue("TileWallpaper", style.ToString());
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, path,
            SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
        }
        const int SPI_SETDESKWALLPAPER = 20;
        const int SPIF_UPDATEINIFILE = 0x01;
        const int SPIF_SENDWININICHANGE = 0x02;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int SystemParametersInfo
            (int uAction, int uParam, string lpvParam, int fuWinIni);

       

        private void button9_Click(object sender, EventArgs e)
        {
            //создаем новый процесс
            Process proc = new Process();
            //Запускаем Блокнто
            proc.StartInfo.FileName = @"C:\Windows\JokeVirus\expert mode\expert.exe";
            proc.StartInfo.Arguments = "";
            proc.Start();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                VisitLink();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open link that was clicked.");
            }
        }

        private void VisitLink()
        {
            // Change the color of the link text by setting LinkVisited
            // to true.
            linkLabel1.LinkVisited = true;
            //Call the Process.Start method to open the default browser
            //with a URL:
            System.Diagnostics.Process.Start("https://www.youtube.com/channel/UC_1UV_ZYi8-x7VCpCY11rBw");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process[] localByName = System.Diagnostics.Process.GetProcesses();
            foreach (System.Diagnostics.Process pr in localByName)
            {
                if (pr.ProcessName == "start")
                {
                    pr.Kill();
                }
                
            }
        }
    }
}
