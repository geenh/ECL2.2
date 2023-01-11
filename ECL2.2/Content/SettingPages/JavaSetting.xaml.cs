
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using Natsurainko.FluentCore.Extension.Windows.Service;
using System.Windows.Forms.DataVisualization.Charting;

namespace ECL2._2.Content.SettingPages
{
    /// <summary>
    /// JavaSetting.xaml 的交互逻辑
    /// </summary>
    public partial class JavaSetting : Page
    {
        public JavaSetting()
        {

            InitializeComponent();
            ServicePointManager.DefaultConnectionLimit = 512;
            

            // 返回一个表，包含了从注册表中检索到的系统中 Java 安装的全部信息
            var javalist = JavaHelper.SearchJavaRuntime();
            javaCombo.ItemsSource = javalist;


            //List<JavaVersion> aa = tools.GetJavaPath();
            //for (int i = 0; i < aa.Count; i++)
            //{
            //    javaCombo.Items.Add(aa[i].Path);
            //}
            if (javaCombo.Items.Count != 0)
            {
                javaCombo.SelectedItem = javaCombo.Items[0];
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


                JSL1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fbfbfb"));
                JSL2.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fbfbfb"));
                JSL3.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fbfbfb"));
                JSL4.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fbfbfb"));
                JSL5.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fbfbfb"));
                JSL6.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fbfbfb"));
                JSL7.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fbfbfb"));
                JSL8.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fbfbfb"));

            }
            else if (k == "1")
            {

                JSL1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#212529"));
                JSL2.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#212529"));
                JSL3.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#212529"));
                JSL4.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#212529"));
                JSL5.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#212529"));
                JSL6.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#212529"));
                JSL7.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#212529"));
                JSL8.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#212529"));


            }
        }
        public static double delayUs(double time)
        {
            System.Diagnostics.Stopwatch stopTime = new System.Diagnostics.Stopwatch();

            stopTime.Start();
            while (stopTime.Elapsed.TotalMilliseconds < time) { }
            stopTime.Stop();

            return stopTime.Elapsed.TotalMilliseconds;
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
            //Setting_Data.Ram= MemoryTextbox.Text;
            //Setting_Data.Java= javaCombo.Text;
            string path = "ECL2.2_Datas\\MinMemoryTextbox_Data.txt";
            File.Delete(path);
            WriteFile("ECL2.2_Datas\\MinMemoryTextbox_Data.txt", MinMemoryTextbox.Text);

            string path3 = "ECL2.2_Datas\\MaxMemoryTextbox_Data.txt";
            File.Delete(path3);
            WriteFile("ECL2.2_Datas\\MaxMemoryTextbox_Data.txt", MaxMemoryTextbox.Text);

            string path2 = @"ECL2.2_Datas\javaCombo_Data.txt";
            File.Delete(path2);
            WriteFile("ECL2.2_Datas\\javaCombo_Data.txt", javaCombo.Text);

            string path4 = "ECL2.2_Datas\\Width_Data.txt";
            File.Delete(path4);
            WriteFile("ECL2.2_Datas\\Width_Data.txt", Width1.Text);

            string path5 = @"ECL2.2_Datas\Height_Data.txt";
            File.Delete(path5);
            WriteFile("ECL2.2_Datas\\Height_Data.txt", Height.Text);

            button1.IsEnabled = false;
            for (int i = 0; i < 75; i++)
            {

                var Mov = SaveLabel.Margin;
                Mov.Left -= 5;
                SaveLabel.Margin = Mov;
                await Task.Delay(1);


            }
            await Task.Delay(1000);
            for (int i = 0; i < 75; i++)
            {

                var Mov = SaveLabel.Margin;
                Mov.Left += 5;
                SaveLabel.Margin = Mov;
                await Task.Delay(1);


            }
            button1.IsEnabled = true;
        
    }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<string> i = new List<string>();
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog()
            {
                Title = "选择Java",
                Filter = "Java应用程序(无窗口)|javaw.exe",
            };
            if (dialog.ShowDialog() == true)
            {
                var javalist = JavaHelper.SearchJavaRuntime();
                foreach(string j in javalist)
                { 
                i.Add(j);
                }

                i.Add(dialog.FileName);
                
                javaCombo.ItemsSource = i;
            }

        }
       

      

        private async void Border_MouseMove(object sender, MouseEventArgs e)
        {
            //for (double i = 1; i > 0.7; i -= 0.05)
            //{
            //    button1.Opacity = i;
            //    await Task.Delay(5);
            //}
            button1.Opacity = 0.7;
        }

        private async void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            //for (double i = 0.7; i < 1; i+= 0.05)
            //{
            //    button1.Opacity = i;
            //    await Task.Delay(5);
            //}
            button1.Opacity = 1;
        }

        private void Border_MouseMove_1(object sender, MouseEventArgs e)
        {
            button2.Opacity = 0.7;
        }

        private void Border_MouseLeave_1(object sender, MouseEventArgs e)
        {
            button2.Opacity = 1;
        }
    }
}
