
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

using System.Threading;
using MinecraftLaunch.Launch;
using MinecraftLaunch.Modules.Enum;
using MinecraftLaunch.Modules.Models.Launch;
using MinecraftLaunch.Modules.Installer;
using MinecraftLaunch.Modules.Models.Auth;

using MinecraftLaunch.Modules.Toolkits;

using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Windows.Media.Animation;

using System.Runtime.Serialization.Formatters;
using MinecaftOAuth;
using MicrosoftAuthenticator = MinecaftOAuth.MicrosoftAuthenticator;
using ECL2._2.Content.UserPages;
using MinecraftLaunch.Modules.Interface;
using System.Xml.Linq;

namespace ECL2._2.Content
{
    /// <summary>
    /// GameStart.xaml 的交互逻辑
    /// </summary>
    public partial class GameStart : Page
    {
        private string rootPath=".minecraft";
        Content.UserPages.Lixian Lixian = new Content.UserPages.Lixian();
        Content.UserPages.WeiRuan WeiRuan = new Content.UserPages.WeiRuan();
       
        public int LoginMode;
        public GameStart()
            {
                InitializeComponent();
          
            StartGameButton.Content = "启动";
            ContentControl1.Content = new Frame
            {
                Content = Lixian
            };
            LoginMode = 0;

            ChangeForeG();


        }
        public void ChangeForeG()
        {
            var i2 = File.ReadAllText("ECL2.2_Datas\\BackGround_Data.txt").ToString();
            string[] d = i2.Split("\r");
            string y = d[0];
            string p = y.TrimEnd('r');
            string k = y.TrimEnd('\\');
            if (k == "0")
            {


                L1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fbfbfb"));


            }
            else if (k == "1")
            {

                L1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#212529"));


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
        public static LaunchConfig LaunchConfig { get; } = new LaunchConfig();
        public Account UserInfo { get; private set; }
        public async ValueTask Login()
        {
            FileStream fs = File.Create("ECL2.2_Datas\\Usercode_Temp.txt");//创建文件
            fs.Close();
            var id = System.IO.File.ReadAllText("ECL2.2_Datas\\ClientToken_Data.txt");
            
            var V= MessageBox.ShowDialog("确定开始验证您的账户");
            MicrosoftAuthenticator microsoftAuthenticator = new(MinecaftOAuth.Module.Enum.AuthType.Access)
            {
                ClientId = "用你滴"
            };
            var code = await microsoftAuthenticator.GetDeviceInfo();
            MessageBox.ShowDialog("你的一次性访问代码在微软登录框中，点击确定开始验证账户");
            
            string path = "ECL2.2_Datas\\Usercode_Temp.txt";
            File.Delete(path);
            WriteFile("ECL2.2_Datas\\Usercode_Temp.txt", code.UserCode);
            WeiRuan.UUID.Content = "你的一次性访问代码是：" + code.UserCode;
            Debug.WriteLine("Link:{0} - Code:{1}", code.VerificationUrl, code.UserCode);
           
            if (V.IsYes)
            {
                Process.Start(new ProcessStartInfo(code.VerificationUrl)
                {
                    UseShellExecute = true,
                    Verb = "open"
                });
                //选择了Yes
            }
            else
            {
                //选择了No
            }
            try
            {
                var token = await microsoftAuthenticator.GetTokenResponse(code);
                var user = await microsoftAuthenticator.AuthAsync(x =>
                {
                    Debug.WriteLine(x);
                });
                UserInfo = user;
                WeiRuan.WelcomeID.Content = "欢迎回来," + user.Name;
                WeiRuan.UUID.Content = "登录完成!";
                File.Delete(path);
            }
            
            catch
            {
                WeiRuan.UUID.Content = "登录失败!";
                MessageBox.ShowDialog("登录失败，请确保已购买Minecraft");
                
                File.Delete(path);
            }
}
        public async Task DongHua1()
        {
            for (int i = 0; i < 75; i++)
            {

                var Mov = VersionE.Margin;
                Mov.Left -= 5;
                VersionE.Margin = Mov;
                await Task.Delay(1);


            }
            await Task.Delay(1000);
            for (int i = 0; i < 75; i++)
            {

                var Mov = VersionE.Margin;
                Mov.Left += 5;
                VersionE.Margin = Mov;
                await Task.Delay(1);


            }


            

            }
        public async Task DongHua3()
        {
            for (int i = 0; i < 75; i++)
            {

                var Mov = UserE.Margin;
                Mov.Left -= 5;
                UserE.Margin = Mov;
                await Task.Delay(1);


            }
            await Task.Delay(1000);
            for (int i = 0; i < 75; i++)
            {

                var Mov = UserE.Margin;
                Mov.Left += 5;
                UserE.Margin = Mov;
                await Task.Delay(1);


            }
        }
        public async Task DongHua4()
        {
            for (int i = 0; i < 75; i++)
            {
                await Dispatcher.BeginInvoke(new Action(async delegate
                {
                    var Mov = StartE.Margin;
                Mov.Left -= 5;
                StartE.Margin = Mov;
                }));
                await Task.Delay(1);


            }
            await Task.Delay(1000);
            for (int i = 0; i < 75; i++)
            {
                await Dispatcher.BeginInvoke(new Action(async delegate
                {
                    var Mov = StartE.Margin;
                Mov.Left += 5;
                StartE.Margin = Mov;
                }));
                await Task.Delay(1);


            }
        }
        public async Task DongHua5()
        {
            for (int i = 0; i < 75; i++)
            {
                await Dispatcher.BeginInvoke(new Action(async delegate
                {
                    var Mov = StartY.Margin;
                Mov.Left -= 5;
                    StartY.Margin = Mov;
                }));
                await Task.Delay(1);
                

            }
            await Task.Delay(1000);
            for (int i = 0; i < 75; i++)
            {
                await Dispatcher.BeginInvoke(new Action(async delegate
                {
                    var Mov = StartY.Margin;
                Mov.Left += 5;
                StartY.Margin = Mov;
                }));
                await Task.Delay(1);
                

            }
        }
        public async Task DongHua2()
        {
            for (int i = 0; i < 75; i++)
            {

                var Mov = JavaE.Margin;
                Mov.Left -= 5;
                JavaE.Margin = Mov;
                await Task.Delay(1);


            }
            await Task.Delay(1000);
            for (int i = 0; i < 75; i++)
            {

                var Mov = JavaE.Margin;
                Mov.Left += 5;
                JavaE.Margin = Mov;
                await Task.Delay(1);


            }

        }
        public async ValueTask Start()
            {

            
            GameCoreToolkit toolkit = new(".minecraft");
            if (versionCombo.Text == "")
            {
                await DongHua1();
            }
            else if(!File.Exists("ECL2.2_Datas\\JavaCombo_Data.txt"))
            {
                await DongHua2();
            }
            else if((File.ReadAllText("ECL2.2_Datas\\JavaCombo_Data.txt"))=="")
            {
                await DongHua2();
            }
            else if(Lixian.IdTextbox.Text=="")
            {
                await DongHua3();
            }
            else 
            {
                
                string[] line1 = File.ReadAllLines(@"ECL2.2_Datas\Width_Data.txt");
                int Width = Convert.ToInt32(line1[0]);
                string[] line2 = File.ReadAllLines(@"ECL2.2_Datas\Height_Data.txt");
                int Height = Convert.ToInt32(line2[0]);
                int MinMemory = Convert.ToInt32(System.IO.File.ReadAllText("ECL2.2_Datas\\MinMemoryTextbox_Data.txt"));
                int MaxMemory = Convert.ToInt32(System.IO.File.ReadAllText("ECL2.2_Datas\\MaxMemoryTextbox_Data.txt"));
                string[] line = File.ReadAllLines(@"ECL2.2_Datas\JavaCombo_Data.txt");
                string Java = line[0];
                string i1 = Lixian.IdTextbox.Text;
                string[] d = i1.Split("\n");
                string k = d.First();
                string id = k;
                if (LoginMode == 1)
                {
                    await Login();
                    try
                    {

                        var launchConfig = new LaunchConfig()
                        {

                            Account = UserInfo,
                            GameWindowConfig = new GameWindowConfig()
                            {
                                Width = Width,
                                Height = Height,
                                IsFullscreen = false
                            },
                            JvmConfig = new JvmConfig(Java)
                            {
                                MaxMemory = MaxMemory,
                                MinMemory = MinMemory,
                            },
                            NativesFolder = null,
                            WorkingFolder = new("q"),
                            LauncherName = "ECL2.2",
                        };

                        //启动部分
                        JavaClientLauncher jcl = new(launchConfig, toolkit,true);
                        //启动！！
                        var Gameid = versionCombo.Text;
                        await Task.Run(async () =>
                        {
                            using var res = await jcl.LaunchTaskAsync(Gameid, async x =>
                            {
                                await Dispatcher.BeginInvoke(new Action(async delegate
                                {
                                    pro.Value = (float.Parse(x.Item1.ToString()) * 100);
                                }));
                            });

                            if (res.State is LaunchState.Succeess)
                            {
                                await Dispatcher.BeginInvoke(new Action(async delegate
                                {
                                    //启动成功的情况下会执行的代码块
                                    pro.Value =0;
                                }));
                                await DongHua5();

                            }
                            else
                            {
                                await Dispatcher.BeginInvoke(new Action(async delegate
                                {
                                   
                                    pro.Value = 0;
                                }));
                                //启动失败的情况下会执行的代码块
                                await DongHua4();
                                MessageBox.ShowDialog("详细异常信息："+ res.Exception.ToString());
                               
                            }
                        });
                    }
                    catch
                    {
                        
                        MessageBox.ShowDialog("启动终止");
                    }
                }
                else if (LoginMode == 0)
                {

                    MinecaftOAuth.OfflineAuthenticator offlineAuthenticator = new(id);
                    var launchConfig = new LaunchConfig()
                    {

                        Account = offlineAuthenticator.Auth(),
                        GameWindowConfig = new GameWindowConfig()
                        {
                            Width = Width,
                            Height = Height,
                            IsFullscreen = false
                        },
                        JvmConfig = new JvmConfig(Java)
                        {
                            MaxMemory = MaxMemory,
                            MinMemory = MinMemory,
                        },

                        NativesFolder = null,
                        WorkingFolder = new("q"),
                        LauncherName = "ECL2.2",
                    };

                    //启动部分
                    JavaClientLauncher jcl = new(launchConfig, toolkit, true);
                    //启动！！
                    var Gameid = versionCombo.Text;
                    await Task.Run(async () =>
                    {
                        using var res = await jcl.LaunchTaskAsync(Gameid, async x =>
                        {
                            await Dispatcher.BeginInvoke(new Action(async delegate
                            {
                                pro.Value = (float.Parse(x.Item1.ToString()) * 100);
                            }));
                });

                        if (res.State is LaunchState.Succeess)
                    {
                            while(true)
                            {
                                
                                if (Process.GetProcessesByName("javaw").ToList().Count > 0)
                                {
                                    await Dispatcher.BeginInvoke(new Action(async delegate
                                    {

                                        pro.Value = 0;
                                    }));
                                    //启动成功的情况下会执行的代码块
                                    await DongHua5();
                                    break;
                                    //存在

                                }
                                
                            }
                           
                    }
                    else
                    {
                            await Dispatcher.BeginInvoke(new Action(async delegate
                            {
                               
                                pro.Value = 0;
                            }));
                            //启动失败的情况下会执行的代码块
                            await DongHua4();
                            MessageBox.ShowDialog("详细异常信息：" + res.Exception.ToString());

                        }
                    });
                }
                else
                {
                   
                    MessageBox.ShowDialog("未选择启动模式");

                }
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
         {

            StartGameButton.Content = "启动中";
            StartGameButton.IsEnabled=false;
            await Start();
            StartGameButton.IsEnabled = true;
            StartGameButton.Content = "启动";
            
        }
        
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ContentControl1.Content = new Frame
            {
                Content = Lixian
            };
            LoginMode = 0;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ContentControl1.Content = new Frame
            {
                Content = WeiRuan
            };
            LoginMode = 1;
        }

        private void Border_MouseMove(object sender, MouseEventArgs e)
        {
            button1.Opacity = 0.7;
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
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

        private void Border_MouseMove_2(object sender, MouseEventArgs e)
        {
            StartGameButton.Opacity = 0.7;
        }

        private void Border_MouseLeave_2(object sender, MouseEventArgs e)
        {
            StartGameButton.Opacity = 1;
        }
    }
    }

