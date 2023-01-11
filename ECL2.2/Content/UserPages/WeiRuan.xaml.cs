using MinecaftOAuth;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Natsurainko.FluentCore.Extension.Windows.Service;
using MinecraftLaunch.Modules.Models.Launch;
using MinecraftLaunch.Modules.Models.Auth;
using System.IO;


namespace ECL2._2.Content.UserPages
{
    /// <summary>
    /// WeiRuan.xaml 的交互逻辑
    /// </summary>
    public partial class WeiRuan : Page
    {
        
        //public static void WriteFile(string Path, string Strings)
        //{
        //    if (!System.IO.File.Exists(Path))
        //    {
        //        //Directory.CreateDirectory(Path);
        //        System.IO.FileStream f = System.IO.File.Create(Path);
        //        f.Close();
        //        f.Dispose();
        //    }
        //    System.IO.StreamWriter f2 = new System.IO.StreamWriter(Path, true, System.Text.Encoding.UTF8);
        //    f2.WriteLine(Strings);
        //    f2.Close();
        //    f2.Dispose();
        //}
        //public static LaunchConfig LaunchConfig { get;}=new LaunchConfig();
        //public Account UserInfo { get;private set; }
        //public async ValueTask Login()
        //{
        //    var id= System.IO.File.ReadAllText("ECL2.2_Datas\\ClientToken_Data.txt");
        //    var V = MessageBox.Show("确定开始验证您的账户", "验证", MessageBoxButton.OKCancel);
        //    MicrosoftAuthenticator microsoftAuthenticator = new(MinecaftOAuth.Module.Enum.AuthType.Access)
        //    {
        //        ClientId = "ed0e15b9-fa1e-489b-b83d-7a66ff149abd"
        //    };
        //    var code = await microsoftAuthenticator.GetDeviceInfo();
        //    MessageBox.Show( "你的一次性访问代码在微软登录框中，点击确定开始验证账户");
        //    UUID.Content = "你的一次性访问代码是：" + code.UserCode;
        //    Debug.WriteLine("Link:{0} - Code:{1}", code.VerificationUrl, code.UserCode);
        //    if (V == MessageBoxResult.OK)
        //    {
        //        Process.Start(new ProcessStartInfo(code.VerificationUrl)
        //        {
        //            UseShellExecute = true,
        //            Verb = "open"
        //        });
        //    }
        //    try
        //    {
        //        var token = await microsoftAuthenticator.GetTokenResponse(code);
        //        var user = await microsoftAuthenticator.AuthAsync(x =>
        //        {

        //        });
        //        UserInfo = user;
        //        WelcomeID.Content = "欢迎回来," + user.Name;
        //        UUID.Content = "登录完成!";

        //    }
        //    catch
        //    {
        //        UUID.Content = "登录失败!";
        //        MessageBox.Show("登录失败，请确保已购买Minecraft");
        //    }
        //}
        public WeiRuan()
        {
            InitializeComponent();
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
                UUID.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fbfbfb"));
                WelcomeID.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fbfbfb"));

            }
            else if (k == "1")
            {

                L1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#212529"));
                UUID.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#212529"));
                WelcomeID.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#212529"));

            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Clipboard.SetDataObject(System.IO.File.ReadAllText("ECL2.2_Datas\\Usercode_Temp.txt"));
                Button1.Content = "已复制";
            }
            catch { }
        }

        private void Border_MouseMove(object sender, MouseEventArgs e)
        {
            Button1.Opacity = 0.7;
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            Button1.Opacity = 1;
        }

        //private async void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    await Login();
        //}
    }
}
