
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
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

using MinecraftLaunch.Modules.Toolkits;
using ECL2._2.Content;
using ECL2._2.Content.UserPages;
using Newtonsoft.Json.Linq;
using MinecraftLaunch.Modules.Models.Launch;
using Natsurainko.FluentCore.Model.Launch;
using System.Diagnostics;
using System.Net;
using UpdateD;

namespace ECL2._2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Content.Download Download = new Content.Download();
        Content.GameStart GameStart = new Content.GameStart();
        Content.Setting Setting = new Content.Setting();
        Content.SettingPages.JavaSetting JavaSetting = new Content.SettingPages.JavaSetting();
       Content.UserPages.Lixian Lixian=new Content.UserPages.Lixian();
        Content.Mods mods= new Content.Mods();
        public System.Guid clientToken;
        public string rootPath = ".minecraft";
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
        public void Invoke_Data()
        {


            
            if (Directory.Exists("ECL2.2_Datas"))
            {

            }
            else
            {
                DirectoryInfo directoryInfo = new DirectoryInfo("ECL2.2_Datas");
                directoryInfo.Create();
            }

            //if (Directory.Exists("C:\\Users\\Public\\ECL2.2_Temp_Data"))
            //{

            //}
            //else
            //{
            //    DirectoryInfo directoryInfo = new DirectoryInfo("C:\\Users\\Public\\ECL2.2_Temp_Data");
            //    directoryInfo.Create();
            //}
            if (!File.Exists("ECL2.2_Datas\\JavaCombo_Data.txt"))
            {

                FileStream fs = File.Create(@"ECL2.2_Datas\JavaCombo_Data.txt");//创建文件
                fs.Close();
                return;

            }
            if (!File.Exists("ECL2.2_Datas\\Width_Data.txt"))
            {

                WriteFile("ECL2.2_Datas\\Width_Data.txt", "854");

                return;
            }
            if (!File.Exists("ECL2.2_Datas\\Height_Data.txt"))
            {

                WriteFile("ECL2.2_Datas\\Height_Data.txt", "480");
                return;
            }
            if (!File.Exists("ECL2.2_Datas\\MinMemoryTextbox_Data.txt"))
            {

                FileStream fs = File.Create("ECL2.2_Datas\\MinMemoryTextbox_Data.txt");//创建文件
                fs.Close();
                return;
            }
            if (!File.Exists("ECL2.2_Datas\\MaxMemoryTextbox_Data.txt"))
            {

                FileStream fs = File.Create("ECL2.2_Datas\\MaxMemoryTextbox_Data.txt");//创建文件
                fs.Close();
                return;
            }
            if (!File.Exists("ECL2.2_Datas\\ID_Data.txt"))
            {

                FileStream fs = File.Create("ECL2.2_Datas\\ID_Data.txt");//创建文件
                fs.Close();
                return;

            }
            if (!File.Exists("ECL2.2_Datas\\DownloadVersion-Temp.txt"))
            {

                FileStream fs = File.Create("ECL2.2_Datas\\DownloadVersion-Temp.txt");//创建文件
                fs.Close();
                return;

            }
            if (File.Exists("StartUpdata.exe"))
            {

                File.Delete("StartUpdata.exe");
                return;

            }
            if (!File.Exists("ECL2.2_Datas\\ClientToken_Data.txt"))
            {

                FileStream fs = File.Create("ECL2.2_Datas\\ClientToken_Data.txt");//创建文件
                fs.Close();
                return;
            }
            if (!File.Exists("ECL2.2_Datas\\MicrosoftUser_UUID.txt"))
            {

                FileStream fs = File.Create("ECL2.2_Datas\\MicrosoftUser_UUID.txt");//创建文件
                fs.Close();
                return;
            }
            if (!File.Exists("ECL2.2_Datas\\BackGround_Data.txt"))
            {

                FileStream fs = File.Create("ECL2.2_Datas\\BackGround_Data.txt");//创建文件
                fs.Close();
                return;
            }

            //if (!File.Exists("C:\\Users\\Public\\ECL2.2_Temp_Data\\UserInfo_Temp.txt"))
            //{

            //    FileStream fs = File.Create("C:\\Users\\Public\\ECL2.2_Temp_Data\\UserInfo_Temp.txt");//创建文件
            //    fs.Close();
            //    return;
            //}
            //Setting.javaCombo.ItemsSource = System.IO.File.ReadAllText("C:\\ECL2_Datas\\JavaCombo_Data.txt");
            JavaSetting.MinMemoryTextbox.Text = System.IO.File.ReadAllText("ECL2.2_Datas\\MinMemoryTextbox_Data.txt");
            JavaSetting.MaxMemoryTextbox.Text = System.IO.File.ReadAllText("ECL2.2_Datas\\MaxMemoryTextbox_Data.txt");
            string i1 = System.IO.File.ReadAllText("ECL2.2_Datas\\ID_Data.txt").ToString();
            string[] d = i1.Split("\r");
            string k = d.First();
            Lixian.IdTextbox.Text = k;
            JavaSetting.Width1.Text= System.IO.File.ReadAllText("ECL2.2_Datas\\Width_Data.txt");
            JavaSetting.Height.Text = System.IO.File.ReadAllText("ECL2.2_Datas\\Height_Data.txt");

        }
       
        public MainWindow()
        {
            InitializeComponent();
            this.WindowStyle = WindowStyle.None;//设置窗体无边框
            this.AllowsTransparency = true;//窗体支持透明度d
            this.Opacity = 0.92;
            

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
                button1.Content = "☀";
                button1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fbfbfb"));
                B3.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fbfbfb"));

                Grid1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#272B2F"));
                LB1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#272B2F"));
                LTB1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#272B2F"));
                LTB2.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#272B2F"));
                LTB3.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#272B2F"));
                LTB4.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#272B2F"));
                GameStart.Grid4.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#212529"));
                Setting.Grid2.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#212529"));
                mods.Grid3_1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#212529"));
                mods.Grid3_2.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#212529"));
                mods.Grid3_3.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#212529"));
                Setting.TC1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#212529"));
                Download.Grid5.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#212529"));
                GameStart.Grid4_2.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#212529"));
                
                mods.Grid3_4.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#212529"));
                mods.Grid3_5.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#212529"));
                mods.Grid3_6.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#212529"));
                mods.Grid3_7.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#212529"));
                GameStart.公告.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fbfbfb"));
            }
            else if (k == "1")
            {


                button1.Content = "☾";
                button1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#212529"));
                B3.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#212529"));
                GameStart.公告.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#212529"));
                Grid1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fbfbfb"));
                LB1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fbfbfb"));
                LTB1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fbfbfb"));
                LTB2.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fbfbfb"));
                LTB3.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fbfbfb"));
                LTB4.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fbfbfb"));
                GameStart.Grid4.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fbfbfb"));
                Setting.Grid2.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fbfbfb"));
                mods.Grid3_1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fbfbfb"));
                mods.Grid3_2.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fbfbfb"));
                mods.Grid3_3.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fbfbfb"));
                Setting.TC1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fbfbfb"));
                Download.Grid5.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fbfbfb"));
                GameStart.Grid4_2.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fbfbfb"));
                mods.Grid3_4.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffffff"));
                mods.Grid3_5.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffffff"));
                mods.Grid3_6.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffffff"));
                mods.Grid3_7.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffffff"));
            }
           


            try
            {
                string path = "ECL2.2_Datas\\MicrosoftUser_UUID.txt";
                File.Delete(path);
            }
            catch { }
            //try
            //{
            //    string path = "C:\\Users\\Public\\ECL2.2_Temp_Data\\UserInfo_Temp.txt";
            //    File.Delete(path);
            //}
            //catch { }
            Invoke_Data();
           
            if (System.IO.File.ReadAllText("ECL2.2_Datas\\ClientToken_Data.txt") == "")
            {
                var id = Guid.NewGuid().ToString();
                string path = "ECL2.2_Datas\\ClientToken_Data.txt";
                File.Delete(path);
                WriteFile("ECL2.2_Datas\\ClientToken_Data.txt", id);
                clientToken = Guid.Parse(id);
            }



            //foreach (var game in gameList)
            //    {
            //    GameStart.versionCombo.Items.Add(game);

            //}
            //GameStart.versionCombo.Items.Add(core.VersionLocator.GetAllGames().ToList());
            GameStart.versionCombo.Items.Clear();
            GameCoreToolkit toolkit = new(".minecraft");
            var gameList = toolkit.GetGameCores();
            foreach (var game in gameList)
            {
                GameStart.versionCombo.Items.Add(game);

            }
          

            if (GameStart.versionCombo.Items.Count != 0)
            {
                GameStart.versionCombo.SelectedItem = GameStart.versionCombo.Items[0];
            }
            ContentControl1.Content = new Frame
            {
                Content = GameStart
            };
            for (double i = 0; i < 1; i += 0.05)
            {

                GameStart.GameStart_Page.Opacity = i;
                
            }
            ListBoxItem1.IsSelected = true;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string path = "ECL2.2_Datas\\MicrosoftUser_UUID.txt";
                File.Delete(path);
            }
            catch { }
            //try
            //{
            //    string path = "C:\\Users\\Public\\ECL2.2_Temp_Data\\UserInfo_Temp.txt";
            //    File.Delete(path);
            //}
            //catch { }
            this.Close();
        }



        private async void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            ContentControl1.Content = new Frame
            {
                Content = GameStart
            };

            GameStart.versionCombo.Items.Clear();
            GameCoreToolkit toolkit = new(".minecraft");
            var gameList = toolkit.GetGameCores();
            foreach (var game in gameList)
            {
                GameStart.versionCombo.Items.Add(game);

            }


            if (GameStart.versionCombo.Items.Count != 0)
            {
                GameStart.versionCombo.SelectedItem = GameStart.versionCombo.Items[0];
            }
            for (double i = 0; i < 1; i += 0.05)
            {

                GameStart.GameStart_Page.Opacity = i;
                await Task.Delay(1);
            }
        }

        private async void ListBoxItem_Selected_1(object sender, RoutedEventArgs e)
        {
            ContentControl1.Content = new Frame
            {
                Content = mods
            };
           
            for (double i = 0; i < 1; i += 0.05)
            {

                mods.Mods_Page.Opacity = i;
                await Task.Delay(1);
            }
        }

        private async void ListBoxItem_Selected_2(object sender, RoutedEventArgs e)
        {
            ContentControl1.Content = new Frame
            {
                Content = Download
            };
            for (double i = 0; i < 1; i+=0.05)
            {
                
                Download.Download_Page.Opacity =i ;
                await Task.Delay(1);
            }
        }

        private async void ListBoxItem_Selected_3(object sender, RoutedEventArgs e)
        {
            ContentControl1.Content = new Frame
            {
                Content = Setting
            };

            for (double i = 0; i < 1; i += 0.05)
            {

                Setting.Setting_Page.Opacity = i;
                await Task.Delay(1);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!File.Exists("ECL2.2_Datas\\BackGround_Data.txt"))
            {

                FileStream fs = File.Create("ECL2.2_Datas\\BackGround_Data.txt");//创建文件
                fs.Close();
                return;
            }
            var i = File.ReadAllText("ECL2.2_Datas\\BackGround_Data.txt").ToString();
            string[] d = i.Split("\r");
            string y = d[0];
            string p = y.TrimEnd('r');
            string k= y.TrimEnd('\\');
            if (k=="0")
            {
                if (Download.pro.Value != 0)
                {
                    MessageBox.Show("确定更换模式？这将会丢失当前的下载进度", (s, e) =>
                    {
                        if (e.Result.IsYes)
                        {
                            button1.Content = "☾";
                            string Path = "ECL2.2_Datas\\BackGround_Data.txt";
                            File.Delete(Path);
                            WriteFile("ECL2.2_Datas\\BackGround_Data.txt", "1");
                            Process.Start("ECL2.2.exe");
                            this.Close();
                            //选择了Yes
                        }
                        else
                        {
                            //选择了No
                        }
                    });
                    
                }
                else if(mods.pro.Value !=0)
                {
                    MessageBox.Show("确定更换模式？这将会丢失当前的下载进度", (s, e) =>
                    {
                        if (e.Result.IsYes)
                        {
                            button1.Content = "☾";
                            string Path = "ECL2.2_Datas\\BackGround_Data.txt";
                            File.Delete(Path);
                            WriteFile("ECL2.2_Datas\\BackGround_Data.txt", "1");
                            Process.Start("ECL2.2.exe");
                            this.Close();
                            //选择了Yes
                        }
                        else
                        {
                            //选择了No
                        }
                    });
                    
                }
                else
                {
                    button1.Content = "☾";
                    string Path = "ECL2.2_Datas\\BackGround_Data.txt";
                    File.Delete(Path);
                    WriteFile("ECL2.2_Datas\\BackGround_Data.txt", "1");
                    Process.Start("ECL2.2.exe");
                    this.Close();
                }
            }
            else if(k=="1")
            {
                if (Download.pro.Value != 0)
                {
                    MessageBoxResult vr = System.Windows.MessageBox.Show("确定更换模式？这将会丢失当前的下载进度", "提示", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                    if (vr == MessageBoxResult.OK)
                    {
                        button1.Content = "☀";
                        button1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fbfbfb"));
                        B3.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fbfbfb"));
                        string Path = "ECL2.2_Datas\\BackGround_Data.txt";
                        File.Delete(Path);
                        WriteFile("ECL2.2_Datas\\BackGround_Data.txt", "0");
                        Process.Start("ECL2.2.exe");
                        this.Close();
                    }
                }
                else if (mods.pro.Value != 0)
                {
                    MessageBoxResult vr = System.Windows.MessageBox.Show("确定更换模式？这将会丢失当前的下载进度", "提示", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                    if (vr == MessageBoxResult.OK)
                    {
                        button1.Content = "☀";
                        button1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fbfbfb"));
                        B3.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fbfbfb"));
                        string Path = "ECL2.2_Datas\\BackGround_Data.txt";
                        File.Delete(Path);
                        WriteFile("ECL2.2_Datas\\BackGround_Data.txt", "0");
                        Process.Start("ECL2.2.exe");
                        this.Close();
                    }
                }

                else
                {
                    button1.Content = "☀";
                    button1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fbfbfb"));
                    B3.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fbfbfb"));
                    string Path = "ECL2.2_Datas\\BackGround_Data.txt";
                    File.Delete(Path);
                    WriteFile("ECL2.2_Datas\\BackGround_Data.txt", "0");
                    Process.Start("ECL2.2.exe");
                    this.Close();
                }
            }
            else
            {
                button1.Content = "☀";
                string Path = "ECL2.2_Datas\\BackGround_Data.txt";
                File.Delete(Path);
                WriteFile("ECL2.2_Datas\\BackGround_Data.txt", "0");
            }
            
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
