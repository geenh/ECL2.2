using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using UpdateD;
using System.Runtime.ConstrainedExecution;
using System.Reflection.Emit;
using System.Net;
using System.Diagnostics;

namespace ECL2._2.Content.SettingPages
{
    /// <summary>
    /// LauncherSetting.xaml 的交互逻辑
    /// </summary>
    public partial class LauncherSetting : Page
    {
        UpdateD.Update updated = new UpdateD.Update();
        public LauncherSetting()
        {
            InitializeComponent();
            
            if (!File.Exists("ECL2.2_Datas\\ClientToken_Data.txt"))
            {

                FileStream fs = File.Create("ECL2.2_Datas\\ClientToken_Data.txt");//创建文件
                fs.Close();
                return;
            }
            if (!File.Exists("ECL2.2_Datas\\ClientToken_Data.txt"))
            {
                TextBox1.IsEnabled = false;
                
            }
            else
            {
                TextBox1.IsEnabled = true;
                TextBox1.Text = System.IO.File.ReadAllText("ECL2.2_Datas\\ClientToken_Data.txt");
                TextBox1.IsEnabled = false;
            }
            ChangeForeG();

        }
        public void ChangeForeG()
        {
            if (!File.Exists("ECL2.2_Datas\\BackGround_Data.txt"))
            {

                FileStream fs = File.Create("ECL2.2_Datas\\BackGround_Data.txt");//创建文件
                fs.Close();
                return;
            }
            var i2 = File.ReadAllText("ECL2.2_Datas\\BackGround_Data.txt").ToString();
            string[] d = i2.Split("\r");
            string y = d[0];
            string p = y.TrimEnd('r');
            string k = y.TrimEnd('\\');
            if (k == "0")
            {


                L1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fbfbfb"));
                L2.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fbfbfb"));


            }
            else if (k == "1")
            {

                L1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#212529"));
                L2.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#212529"));


            }
        }
        public void ForeGW()
        {
            
                L1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fbfbfb"));
                L2.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fbfbfb"));


        }
        public void ForeGB()
        {

            L1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#212529"));
            L2.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#212529"));


        }
        public async Task DongHua1()
        {
            for (int i = 0; i < 80; i++)
            {

                var Mov = OldVersion.Margin;
                Mov.Left -= 5.5;
                OldVersion.Margin = Mov;
                await Task.Delay(1);


            }
            await Task.Delay(1000);
            for (int i = 0; i < 80; i++)
            {

                var Mov = OldVersion.Margin;
                Mov.Left += 5.5;
                OldVersion.Margin = Mov;
                await Task.Delay(1);


            }

        }
        public async Task DongHua2()
        {
            for (int i = 0; i < 80; i++)
            {

                var Mov = NewVersion.Margin;
                Mov.Left -= 6.4;
                NewVersion.Margin = Mov;
                await Task.Delay(1);


            }
            await Task.Delay(1000);
            for (int i = 0; i < 80; i++)
            {

                var Mov = NewVersion.Margin;
                Mov.Left += 6.4;
                NewVersion.Margin = Mov;
                await Task.Delay(1);


            }
        }
        public async Task DongHua3()
        {
            for (int i = 0; i < 90; i++)
            {

                var Mov =UPdateText.Margin;
                Mov.Left -= 6.9;
                UPdateText.Margin = Mov;
                //var Mov1 = Label1.Margin;
                //Mov1.Left -= 6.9;
                //Label1.Margin = Mov1;
                await Task.Delay(1);


            }
            await Task.Delay(3000);
            for (int i = 0; i < 90; i++)
            {

                var Mov = UPdateText.Margin;
                Mov.Left +=6.9;
                UPdateText.Margin = Mov;
                //var Mov1 = Label1.Margin;
                //Mov1.Left += 6.9;
                //Label1.Margin = Mov1;
                await Task.Delay(1);


            }

        }
        public static void WriteFile(string Path, string Strings)
        {
            if (!System.IO.File.Exists(Path))
            {
                //Directory.CreateDirectory(Path);
                System.IO.FileStream f = System.IO.File.Create(Path);
                f.Close();
                f.Dispose();
            }
            System.IO.StreamWriter f2 = new System.IO.StreamWriter(Path, true, System.Text.Encoding.UTF8);
            f2.WriteLine(Strings);
            f2.Close();
            f2.Dispose();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            if (updated.GetUpdate("", "0.3.90") == false)
            {
                Button1.IsEnabled=false;
                await DongHua2();
                Button1.IsEnabled = true;

            }
            else if(updated.GetUpdate("", "0.3.90") == true)
            {
                Button1.IsEnabled = false;
                
                MessageBoxResult vr = System.Windows.MessageBox.Show("检测到更新，是否更新？", "提示", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (vr == MessageBoxResult.OK)
                {
                    string i=updated.GetUpdateFile("").ToString();
                                       
                    if (Directory.Exists("Update"))
                    {

                    }
                    else
                    {
                        DirectoryInfo directoryInfo = new DirectoryInfo("Update");
                        directoryInfo.Create();
                    }
                    try
                    {

                        
                        var url = i;
                        var save = @"[Update]ECL2.2.exe";
                        var url1 = "https://startupdata.netlify.app/StartUpdata.exe";
                        var save1 = @"StartUpdata.exe";



                        using (var web = new WebClient())
                        {
                            web.DownloadFile(url, save);
                            web.DownloadFile(url1, save1);
                        }


                        MessageBox.ShowDialog("下载完成，开始更新");
                       
                        Process.Start("StartUpdata.exe");


                        string str = "taskkill /F /IM ECL2.2.exe";

                        System.Diagnostics.Process p = new System.Diagnostics.Process();
                        p.StartInfo.FileName = "cmd.exe";
                        p.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
                        p.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
                        p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
                        p.StartInfo.RedirectStandardError = true;//重定向标准错误输出
                        p.StartInfo.CreateNoWindow = true;//不显示程序窗口
                        p.Start();//启动程序

                        //向cmd窗口发送输入信息
                        p.StandardInput.WriteLine(str + "&exit");

                        p.StandardInput.AutoFlush = true;
                        

                       






                    }
                    catch { }
                }
                Button1.IsEnabled = true;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TextBox1.IsEnabled = true;
            TextBox1.Text = System.IO.File.ReadAllText("ECL2.2_Datas\\ClientToken_Data.txt");
            
            TextBox1.IsEnabled = false;
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var i = updated.GetUpdateRem("d0068f1fc8b84add9824dc8c3ddcaa4c");
            UPdateText.IsEnabled = false;
            UPdateText.Text = i;
            UPdateText.IsEnabled = true;
            await DongHua3();
        }

        private void Border_MouseMove(object sender, MouseEventArgs e)
        {
            Button1.Opacity = 0.7;
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            Button1.Opacity = 1;
        }

        private void Border_MouseMove_1(object sender, MouseEventArgs e)
        {
            button2.Opacity = 0.7;
        }

        private void Border_MouseLeave_1(object sender, MouseEventArgs e)
        {
            button2.Opacity = 1;
        }

        private void Border_MouseMove_2(object sender, MouseEventArgs e)
        {
            button3.Opacity = 0.7;
        }

        private void Border_MouseLeave_2(object sender, MouseEventArgs e)
        {
            button3.Opacity= 1;
        }
    }
}
