
using MinecraftLaunch.Modules.Installer;
using MinecraftLaunch.Modules.Models.Install;
using MinecraftLaunch.Modules.Toolkits;
using Natsurainko.FluentCore.Extension.Windows.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Threading;
namespace ECL2._2.Content
{
    /// <summary>
    /// Download.xaml 的交互逻辑
    /// </summary>
    public partial class Download : Page
    {
        
        public Download()
        {
            InitializeComponent();
            if (Directory.Exists("ECL2.2_Datas"))
            {

            }
            else
            {
                DirectoryInfo directoryInfo = new DirectoryInfo("ECL2.2_Datas");
                directoryInfo.Create();
            }
            if (!File.Exists("ECL2.2_Datas\\DownloadVersion-Temp.txt"))
            {

                FileStream fs = File.Create("ECL2.2_Datas\\DownloadVersion-Temp.txt");//创建文件
                fs.Close();

            }
            if (!File.Exists("ECL2.2_Datas\\AutoInstall-Temp.txt"))
            {

                FileStream fs = File.Create("ECL2.2_Datas\\AutoInstall-Temp.txt");//创建文件
                fs.Close();

            }
            IList<string> list = new List<string>();
            list.Add("仅安装游戏本体");
            list.Add("安装游戏本体和Forge");

            list.Add("安装游戏本体和Fabric");
            list.Add("安装游戏本体和Quilt(仅1.14以上)");
            list.Add("安装游戏本体和Optfine");
            list.Add("安装游戏本体、Forge和Optfine");
            AutoInstaller.ItemsSource = list;
            AutoInstaller.SelectedIndex = 0;
            IList<string> list1 = new List<string>();
            list1.Add("全部版本");
            list1.Add("仅正式版");

            list1.Add("仅预览版");
            list1.Add("仅远古版");
            Type_ComboBox.ItemsSource = list1;
            Type_ComboBox.SelectedIndex = 0;
            Flushed_All();
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


                Label1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fbfbfb"));
                L2.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fbfbfb"));
                L3.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fbfbfb"));

            }
            else if (k == "1")
            {

                Label1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#000000"));
                L2.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#000000"));
                L3.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#000000"));

            }
        }
        public async Task Flushed_All()
        {
            List<GameCoreEmtity> coreEmtities = new();
            await Task.Run(async () =>
            {
                
                var res = (await GameCoreInstaller.GetGameCoresAsync()).Cores;
                res.ToList().ForEach(x =>
                {

                    coreEmtities.Add(x);

                });
            });

            DownloadList.ItemsSource = coreEmtities;
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
        public async Task DongHua1()
        {
            var Mov = VersionTextBoxE.Margin;
            
            VersionTextBoxE.Margin = Mov;
            for (int i = 0; i < 75; i++)
            {

                
                Mov.Left -= 5;
                VersionTextBoxE.Margin = Mov;
                await Task.Delay(1);


            }
            await Task.Delay(1000);
            for (int i = 0; i < 75; i++)
            {

               
                Mov.Left += 5;
                VersionTextBoxE.Margin = Mov;
                await Task.Delay(1);


            }
            
        }
        public async Task DongHua2()
        {
            var Mov = JavaE.Margin;
            
            for (int i = 0; i < 80; i++)
            {

               
                Mov.Left -= 6.5;
                JavaE.Margin = Mov;
                await Task.Delay(1);


            }
            await Task.Delay(1000);
            for (int i = 0; i < 80; i++)
            {

                
                Mov.Left += 6.5;
                JavaE.Margin = Mov;
                await Task.Delay(1);


            }
            
        }
        public async ValueTask download()
        {
            if (!File.Exists("ECL2.2_Datas\\JavaCombo_Data.txt"))
            {

                await DongHua2();
            }
            else if (System.IO.File.ReadAllText("ECL2.2_Datas\\JavaCombo_Data.txt") == "")
            {
                await DongHua2();
            }
            else
            {
                if ((DownloadList.SelectedItem as GameCoreEmtity).Id == null)
                {

                    await DongHua1();
                }
                else
                {
                    if (AutoInstaller.SelectedIndex == 0)
                    {
                        //string path = "ECL2.2_Datas\\DownloadVersion-Temp.txt";
                        //File.Delete(path);
                        //WriteFile("ECL2.2_Datas\\DownloadVersion-Temp.txt", (DownloadList.SelectedItem as GameCoreEmtity).Id);
                        //string path1 = "ECL2.2_Datas\\AutoInstall-Temp.txt";
                        //File.Delete(path1);
                        //WriteFile("ECL2.2_Datas\\AutoInstall-Temp.txt", "0");
                        //string appName = "ECL2.2-Downloader.exe";
                        //Process.Start(appName);
                        var id = ((DownloadList.SelectedItem as GameCoreEmtity)!.Id);
                        await Task.Run(async () =>
                        {
                            GameCoreInstaller list = new(new(".minecraft"), id);
                            await Dispatcher.BeginInvoke(new Action(async delegate
                            {
                                Label1.Content = "当前下载版本：" + id;
                            }));
                            var res = await list.InstallAsync(async x =>
                            {
                                Debug.WriteLine(x.Item1);
                                await Dispatcher.BeginInvoke(new Action(async delegate
                                {
                                    pro.Value = (x.Item1 * 100); ;
                                }));
                            });

                            if (res.Success)
                            {
                                
                                await Dispatcher.BeginInvoke(new Action(delegate
                                {
                                    MessageBox.ShowDialog($"游戏核心{id}下载完成");
                                }));
                                await Dispatcher.BeginInvoke(new Action(async delegate
                                {
                                    pro.Value = 0;
                                }));
                                await Dispatcher.BeginInvoke(new Action(async delegate
                                {
                                    Label1.Content = "当前无下载任务";
                                }));
                            }
                        });

                    }

                    else if (AutoInstaller.SelectedIndex == 1)
                    {
                        var id = (DownloadList.SelectedItem as GameCoreEmtity).Id;
                        var i = await ForgeInstaller.GetForgeBuildsOfVersionAsync(id);
                        Label1.Content = "当前下载版本：" + id + "-Forge_" + i.First().Build;
                        
                        GameCoreToolkit toolkit = new(".minecraft");

                        string line = File.ReadAllText(@"ECL2.2_Datas\javaCombo_Data.txt").ToString();
                        string[] l = line.Split("\r");
                        string l2 = l[0];
                        string l3 = l2.TrimEnd('r');
                        string l5 = l2.TrimEnd('n');
                        string l4 = l3.TrimEnd('\\');
                        string JavaPaths = l4;

                        await Task.Run(async () =>
                        {
                            ForgeInstaller forgeInstaller = new(toolkit, i.First(), JavaPaths);

                            var res = await forgeInstaller.InstallAsync(async x =>
                            {
                                await Dispatcher.BeginInvoke(new Action(async delegate
                                {
                                    pro.Value = (x.Item1 * 100); ;
                                }));


                            });
                            if (res.Success)
                            {
                                await Dispatcher.BeginInvoke(new Action(delegate
                                {
                                    MessageBox.ShowDialog($"游戏核心{id}-Forge_{i.First().Build}下载完成");
                                }));
                               
                                await Dispatcher.BeginInvoke(new Action(async delegate
                                {
                                    pro.Value = 0;
                                }));
                            }
                            await Dispatcher.BeginInvoke(new Action(async delegate
                            {
                                Label1.Content = "当前无下载任务";
                            }));



                        });

                    }
                    else if (AutoInstaller.SelectedIndex == 2)
                    {
                        var id = (DownloadList.SelectedItem as GameCoreEmtity).Id;
                        var i = await FabricInstaller.GetFabricBuildsByVersionAsync(id);
                        List<FabricInstallBuild> list = new List<FabricInstallBuild>();
                        foreach (var build in i)
                        {
                            list.Add(build);
                        }

                        Label1.Content = "当前下载版本：" + id + "-Fabric";
                        GameCoreToolkit toolkit = new(".minecraft");


                        await Task.Run(async () =>
                        {
                            FabricInstaller fabricInstaller = new(toolkit, i.First());

                            var res = await fabricInstaller.InstallAsync(async x =>
                            {
                                await Dispatcher.BeginInvoke(new Action(async delegate
                                {
                                    pro.Value = (x.Item1 * 100); ;
                                }));

                            });
                            if (res.Success)
                            {
                                await Dispatcher.BeginInvoke(new Action(delegate
                                {
                                    MessageBox.ShowDialog($"游戏核心{id}-Fabric下载完成");
                                }));
                                
                               
                                await Dispatcher.BeginInvoke(new Action(async delegate
                                {
                                    pro.Value = 0;
                                }));
                            }
                            await Dispatcher.BeginInvoke(new Action(async delegate
                            {
                                Label1.Content = "当前无下载任务";
                            }));
                           
                            MessageBox.ShowDialog("下载完成！");

                        });

                    }
                    else if (AutoInstaller.SelectedIndex == 3)
                    {
                        var id = (DownloadList.SelectedItem as GameCoreEmtity).Id;
                        var i = await QuiltInstaller.GetQuiltBuildsByVersionAsync(id);
                        Label1.Content = "当前下载版本：" + id+ "-Quilt";
                        GameCoreToolkit toolkit = new(".minecraft");


                       
                        await Task.Run(async () =>
                        {
                            QuiltInstaller quiltInstaller = new(toolkit, i.First());

                            var res = await quiltInstaller.InstallAsync(async x =>
                            {
                                await Dispatcher.BeginInvoke(new Action(async delegate
                                {
                                    pro.Value = (x.Item1 * 100); ;
                                }));

                            });
                            if (res.Success)
                            {
                                await Dispatcher.BeginInvoke(new Action(delegate
                                {
                                    MessageBox.ShowDialog($"游戏核心{id}-Quilt下载完成");
                                }));
                               
                                
                                await Dispatcher.BeginInvoke(new Action(async delegate
                                {
                                    pro.Value = 0;
                                }));
                            }
                            await Dispatcher.BeginInvoke(new Action(async delegate
                            {
                                Label1.Content = "当前无下载任务";
                            }));

                        });
                      }
                    else if (AutoInstaller.SelectedIndex == 4)
                    {
                        var id = (DownloadList.SelectedItem as GameCoreEmtity).Id;
                        GameCoreToolkit toolkit = new(".minecraft");
                        var i = await OptiFineInstaller.GetOptiFineBuildsFromMcVersionAsync(id);
                        await Dispatcher.BeginInvoke(new Action(async delegate
                        {
                            Label1.Content = "当前下载版本：" + id + "-Optfine";
                        }));
                        string line = File.ReadAllText(@"ECL2.2_Datas\javaCombo_Data.txt").ToString();
                        string[] l = line.Split("\r");
                        string l2 = l[0];
                        string l3 = l2.TrimEnd('r');
                        string l5 = l2.TrimEnd('n');
                        string l4 = l3.TrimEnd('\\');
                        string JavaPaths = l4;
                        await Task.Run(async () =>
                        {
                            OptiFineInstaller optfineInstaller = new(toolkit, i.FirstOrDefault(), JavaPaths);
                            var res = await optfineInstaller.InstallAsync(async x =>
                             {
                                    await Dispatcher.BeginInvoke(new Action(async delegate
                                    {
                                        pro.Value = (x.Item1 * 100);
                                    }));

                            });

                            if (res.Success)
                            {
                                await Dispatcher.BeginInvoke(new Action(delegate
                                {
                                    MessageBox.ShowDialog($"游戏核心{id}-Optfine_{i.First().Patch}下载完成");
                                }));
                               
                               
                                await Dispatcher.BeginInvoke(new Action(async delegate
                                {
                                    pro.Value = 0;
                                }));
                            }
                            await Dispatcher.BeginInvoke(new Action(async delegate
                            {
                                Label1.Content = "当前无下载任务";
                            }));
                        });
                    }
                    else if (AutoInstaller.SelectedIndex == 5)
                    {
                        var id = (DownloadList.SelectedItem as GameCoreEmtity).Id;
                        var i = await ForgeInstaller.GetForgeBuildsOfVersionAsync(id);
                        var i2 = await OptiFineInstaller.GetOptiFineBuildsFromMcVersionAsync(id);
                        var cid = $"{i.FirstOrDefault().Build}-OptiFine_{i2.FirstOrDefault().Patch}";
                        Label1.Content = cid;
                        string line = File.ReadAllText(@"ECL2.2_Datas\javaCombo_Data.txt").ToString();
                        string[] l = line.Split("\r");
                        string l2 = l[0];
                        string l3 = l2.TrimEnd('r');
                        string l5 = l2.TrimEnd('n');
                        string l4 = l3.TrimEnd('\\');
                        string JavaPaths = l4;
                        ForgeInstaller installer = new(new(".minecraft"), i.First(), JavaPaths, cid);
                        var res = await Task.Run(async () =>
                        {
                            return await installer.InstallAsync(async x =>
                            {
                                await Dispatcher.BeginInvoke(new Action(async delegate
                                {
                                    pro.Value = (x.Item1 * 100);
                                }));
                            });
                        });


                        if (res.Success)
                        {
                            OptiFineInstaller optiFine = new(new(".minecraft"), i2.First(), JavaPaths, customId: cid);
                            var res1 = await Task.Run(async () =>
                            {
                                return await optiFine.InstallAsync(async x =>
                                {
                                    await Dispatcher.BeginInvoke(new Action(async delegate
                                    {
                                        pro.Value = (x.Item1 * 100);
                                    }));
                                });
                            });

                            if (res1.Success)
                            {
                                await Dispatcher.BeginInvoke(new Action(delegate
                                {
                                    MessageBox.ShowDialog($"游戏核心：{cid} 下载成功！");
                                }));
                                
                                
                            }
                        }
                    }

                }

            }
        }


        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await download();
        }

        private async void Type_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Type_ComboBox.SelectedIndex == 0)
            {
                await Flushed_All();
            }
            else if (Type_ComboBox.SelectedIndex == 1)
            {
                List<GameCoreEmtity> coreEmtities = new();
                await Task.Run(async () =>
                {
                    
                    var res = (await GameCoreInstaller.GetGameCoresAsync()).Cores;
                    res.ToList().ForEach(x =>
                    {
                        if (x.Type is "release")
                            coreEmtities.Add(x);

                    });
                });
                DownloadList.ItemsSource = coreEmtities;
            }
            else if (Type_ComboBox.SelectedIndex == 2)
            {
                List<GameCoreEmtity> coreEmtities = new();
                await Task.Run(async () =>
                {
                    
                    var res = (await GameCoreInstaller.GetGameCoresAsync()).Cores;
                    res.ToList().ForEach(x =>
                    {
                        if (x.Type is "snapshot")
                            coreEmtities.Add(x);

                    });
                });
                DownloadList.ItemsSource = coreEmtities;
            }

            else if (Type_ComboBox.SelectedIndex == 3)
            {
                List<GameCoreEmtity> coreEmtities = new();
                await Task.Run(async () =>
                {
                    
                    var res = (await GameCoreInstaller.GetGameCoresAsync()).Cores;
                    res.ToList().ForEach(x =>
                    {
                        if (x.Type is "old_alpha")
                            coreEmtities.Add(x);

                    });
                });
                DownloadList.ItemsSource = coreEmtities;
            }

        }

        private void Border_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            button1.Opacity = 1;
        }

        private void Border_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            button1.Opacity = 0.7;
        }
    }
}
