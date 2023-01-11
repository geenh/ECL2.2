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
using System.Threading;
namespace ECL2._2.Content.UserPages
{
    /// <summary>
    /// Lixian.xaml 的交互逻辑
    /// </summary>
    public partial class Lixian : Page
    {
        public Lixian()
        {
            InitializeComponent();
            if (!File.Exists("ECL2.2_Datas\\ID_Data.txt"))
            {

                FileStream fs = File.Create("ECL2.2_Datas\\ID_Data.txt");//创建文件
                fs.Close();
                return;

            }
            IdTextbox.Text = System.IO.File.ReadAllText("ECL2.2_Datas\\ID_Data.txt");
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
        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string path = "ECL2.2_Datas\\ID_Data.txt";
            File.Delete(path);
            WriteFile("ECL2.2_Datas\\ID_Data.txt", IdTextbox.Text);
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

        private void Border_MouseMove(object sender, MouseEventArgs e)
        {
            button1.Opacity = 0.7;
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            button1.Opacity = 1;
        }
    }
}
