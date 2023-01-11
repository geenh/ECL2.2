using ECL2._2.Content.SettingPages;
using MinecraftLaunch.Modules.Toolkits;

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
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using System.Net;
using Natsurainko.FluentCore.Extension.Windows.Service;
using System.Windows.Forms;
using System.Reflection;
using Windows.Storage;
using MinecraftLaunch.Modules.Installer;
using MinecraftLaunch.Modules.Models.Install;
using System.Reflection.Emit;

namespace ECL2._2.Content
{
    /// <summary>
    /// Mods.xaml 的交互逻辑
    /// </summary>
    public partial class Mods : Page
    {
        

        
        public Mods()
        {
            InitializeComponent();
            HotMods();
            HotJson_lib();
            ChangeForeG();
            //    DirectoryInfo d1 = new DirectoryInfo(System.AppDomain.CurrentDomain.BaseDirectory+".minecraft");

            //    DirectoryInfo[] directs = d1.GetDirectories();//文件夹

            //    //获取子文件夹内的文件列表，递归遍历  
            //    foreach (DirectoryInfo dd in directs)
            //    {

            //        if (dd.FullName.EndsWith("mods") == true)
            //        {
            //            TB2.Items.Add(dd.FullName);
            //        }

            //    }

            //    TB2.Items.Add("启动器根目录");
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


                L11.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fbfbfb"));
                L12.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fbfbfb"));


            }
            else if (k == "1")
            {

                L11.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#212529"));
                L12.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#212529"));


            }
        }
        public async Task HotMods()
        {

            var toolkit = new CurseForgeToolkit("");
            var res = await toolkit.GetFeaturedModpacksAsync();
            ModDownloadList.Items.Clear();
            
            res.ForEach(x =>
            {

                
                foreach(var file in x.Files.Values)
                {
                    foreach (var file1 in file.AsEnumerable())
                    {
                        ModDownloadList.Items.Add("模组名:" + x.Name + "\n简介：" + x.Description + "\n适用版本：" + file1.SupportedVersion + "\n模组加载器：" + file1.ModLoaderType + " \n" + file1.FileName + "\n" + file1.DownloadUrl); ModDownloadList.Items.Add("模组名:" + x.Name + "\n适用版本：" + file1.SupportedVersion + "\n模组加载器：" + file1.ModLoaderType + " \n" + file1.FileName + "\n" + file1.DownloadUrl);
                    }
                        //利用x参数获取当前模组的详细信息，例如获取模组名可以使用x.Name,获取文件列表可以用x.Files
                 }
            });


           
            
        }
        public async Task HotJson_lib()
        {

            
            var toolkit = new CurseForgeToolkit("");
            var res = await toolkit.SearchModpacksAsync("",category:4437);


            json_libList.Items.Clear();



            res.ForEach(x =>
            {


                foreach (var file in x.Files.Values)
                {
                    foreach (var file1 in file.AsEnumerable())
                        json_libList.Items.Add("整合包名:" + x.Name + "\n简介：" + x.Description + "\n游戏版本：" + file1.SupportedVersion + "\n模组加载器：" + file1.ModLoaderType + " \n" + file1.FileName + "\n" + file1.DownloadUrl);
                    //利用x参数获取当前模组的详细信息，例如获取模组名可以使用x.Name,获取文件列表可以用x.Files
                }
            });
            //利用x参数获取当前模组的详细信息，例如获取模组名可以使用x.Name,获取文件列表可以用x.Files






        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var toolkit = new CurseForgeToolkit("");
            var res = await toolkit.SearchModpacksAsync(TextBox1.Text);
            
            
            ModDownloadList.Items.Clear();

            
                res.ForEach(x =>
                {


                    foreach (var file in x.Files.Values)
                    {
                        foreach (var file1 in file.AsEnumerable())
                           
                            ModDownloadList.Items.Add("模组名:" + x.Name + "\n简介：" + x.Description + "\n适用版本：" + file1.SupportedVersion + "\n模组加载器：" + file1.ModLoaderType + " \n" + file1.FileName + "\n" + file1.DownloadUrl);
                        //利用x参数获取当前模组的详细信息，例如获取模组名可以使用x.Name,获取文件列表可以用x.Files
                    }
                });
                //利用x参数获取当前模组的详细信息，例如获取模组名可以使用x.Name,获取文件列表可以用x.Files
            
            
        }


        private void tabItem2_Clicked(object sender, MouseButtonEventArgs e)
        {
           
        }

       

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            button1.Opacity = 1;
        }

        private void Border_MouseMove(object sender, MouseEventArgs e)
        {
            button1.Opacity = 0.7;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (TB2.Text !="")
            {
                try
                {

                    var i = ModDownloadList.SelectedItem.ToString();
                    var j = i.Split("\n");

                    var url = j[5];
                    var save = TB2.Text+"\\"+j[4];
                    using (var web = new WebClient())
                    {
                        web.DownloadFile(url, save);
                    }
                    MessageBox.ShowDialog("模组\"" + j[4] + "\"下载完成");
                   
                }
                catch { }
            }
            else
            {
                
                MessageBox.ShowDialog("请输入保存文件夹！");
            }
        }

        //private void button2_Click(object sender, RoutedEventArgs e)
        //{
           
        //}

        //private void Border_MouseMove_1(object sender, MouseEventArgs e)
        //{
        //    button2.Opacity = 0.7;
        //}

        //private void Border_MouseLeave_1(object sender, MouseEventArgs e)
        //{
        //    button2.Opacity = 1;
        //}

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var toolkit = new CurseForgeToolkit("");
            var res = await toolkit.SearchModpacksAsync("Fabric API");


            
            ModDownloadList.Items.Clear();

            res.ForEach(x =>
            {

               
                foreach (var file in x.Files.Values)
                {
                    foreach (var file1 in file.AsEnumerable())
                        if(file1.FileName.ToLower().Contains("fabric-api-")==true)
                        ModDownloadList.Items.Add("模组名:" + x.Name + "\n简介：" + x.Description + "\n适用版本：" + file1.SupportedVersion + "\n模组加载器：" + file1.ModLoaderType + " \n" + file1.FileName + "\n" + file1.DownloadUrl);

                }
                //利用x参数获取当前模组的详细信息，例如获取模组名可以使用x.Name,获取文件列表可以用x.Files
            });
        }

        private void Border_MouseMove_2(object sender, MouseEventArgs e)
        {
            button3.Opacity = 0.7;
        }

        private void Border_MouseLeave_2(object sender, MouseEventArgs e)
        {
            button3.Opacity =1;
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if(TextBox1.Text!="")
            {
                var toolkit = new CurseForgeToolkit("");
                var res = await toolkit.SearchModpacksAsync(TextBox1.Text);


                ModDownloadList.Items.Clear();



                res.ForEach(x =>
                {


                    foreach (var file in x.Files.Values)
                    {
                        foreach (var file1 in file.AsEnumerable())
                            ModDownloadList.Items.Add("模组名:" + x.Name + "\n简介：" + x.Description + "\n适用版本：" + file1.SupportedVersion + "\n模组加载器：" + file1.ModLoaderType + " \n" + file1.FileName + "\n" + file1.DownloadUrl);
                        //利用x参数获取当前模组的详细信息，例如获取模组名可以使用x.Name,获取文件列表可以用x.Files
                    }
                });
                //利用x参数获取当前模组的详细信息，例如获取模组名可以使用x.Name,获取文件列表可以用x.Files

            }
            else
            {
                var toolkit = new CurseForgeToolkit("");
                var res = await toolkit.GetFeaturedModpacksAsync();
                ModDownloadList.Items.Clear();

                res.ForEach(x =>
                {


                    foreach (var file in x.Files.Values)
                    {
                        foreach (var file1 in file.AsEnumerable())
                            ModDownloadList.Items.Add("模组名:" + x.Name + "\n简介："+x.Description+"\n适用版本：" + file1.SupportedVersion + "\n模组加载器：" + file1.ModLoaderType + " \n" + file1.FileName + "\n" + file1.DownloadUrl);
                        //利用x参数获取当前模组的详细信息，例如获取模组名可以使用x.Name,获取文件列表可以用x.Files
                    }
                });
            }
        }

        private void Border_MouseMove_1(object sender, MouseEventArgs e)
        {
            button4.Opacity = 0.7;
        }

        private void Border_MouseLeave_1(object sender, MouseEventArgs e)
        {
            button4.Opacity =1;
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            if (TB3.Text != "")
            {
                ModManageList.Items.Clear();
                DirectoryInfo d = new DirectoryInfo(TB3.Text);
                FileInfo[] files = d.GetFiles();//文件
                DirectoryInfo[] directs = d.GetDirectories();//文件夹
                foreach (FileInfo f in files)
                {
                    FileInfo fileInfo = new FileInfo(f.Name);
                    if (fileInfo.Extension.ToString()==".jar")
                    {
                        ModManageList.Items.Add(f.Name);//添加文件名到列表中  
                    }
                    if (fileInfo.Extension.ToString() == ".disable")
                    {
                        ModManageList.Items.Add(f.Name);//添加文件名到列表中  
                    }
                    else
                    {

                    }
                }
               

            }
            else
            {
                MessageBox.ShowDialog("请输入Mods文件夹！");
                
            }
        }

        private void Border_MouseMove_3(object sender, MouseEventArgs e)
        {
            button5.Opacity = 0.7;
        }

        private void Border_MouseLeave_3(object sender, MouseEventArgs e)
        {
            button5.Opacity = 1;
        }

        private void Border_MouseMove_4(object sender, MouseEventArgs e)
        {
            button6.Opacity = 0.7;
        }

        private void Border_MouseLeave_4(object sender, MouseEventArgs e)
        {
            button6.Opacity = 1;
        }

        private void Border_MouseMove_5(object sender, MouseEventArgs e)
        {
            button7.Opacity = 0.7;
        }

        private void Border_MouseLeave_5(object sender, MouseEventArgs e)
        {
            button7.Opacity =1;
        }

        private void ModManageList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                L1.Content = "选中模组：" + ModManageList.SelectedItem;
                

            }
            catch { }
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(ModManageList.SelectedItem.ToString());
                if (fileInfo.Extension.ToString() == ".jar")
                {

                    File.Move(TB3.Text + "\\" + ModManageList.SelectedItem.ToString(), TB3.Text + "\\" + (ModManageList.SelectedItem.ToString() + ".disable"));
                    ModManageList.Items.Clear();
                    DirectoryInfo d = new DirectoryInfo(TB3.Text);
                    FileInfo[] files = d.GetFiles();//文件

                    foreach (FileInfo f in files)
                    {
                        ModManageList.Items.Add(f.Name);//添加文件名到列表中  
                    }
                }
                if (fileInfo.Extension.ToString() == ".disable")
                {
                    
                }
               
                
            }
            catch { }
           
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var i = ModManageList.SelectedItem.ToString();

                var d = i.TrimEnd('e');
                var d3 = d.TrimEnd('l');
                var d4 = d3.TrimEnd('b');
                var d5 = d4.TrimEnd('a');
                var d6 = d5.TrimEnd('s');
                var d7 = d6.TrimEnd('i');
                var d8 = d7.TrimEnd('d');
                var d9 = d8.TrimEnd('.');
                File.Move(TB3.Text + "\\" + (string)ModManageList.SelectedItem, TB3.Text + "\\" + d9);
                ModManageList.Items.Clear();
                DirectoryInfo d2 = new DirectoryInfo(TB3.Text);
                FileInfo[] files = d2.GetFiles();//文件
                DirectoryInfo[] directs = d2.GetDirectories();//文件夹
                foreach (FileInfo f in files)
                {
                    ModManageList.Items.Add(f.Name);//添加文件名到列表中  
                }
            }
            catch { }
           
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var filePath = TB3.Text + "\\" + (string)ModManageList.SelectedItem;
                File.Delete(filePath);
                ModManageList.Items.Clear();
                DirectoryInfo d2 = new DirectoryInfo(TB3.Text);
                FileInfo[] files = d2.GetFiles();//文件
                DirectoryInfo[] directs = d2.GetDirectories();//文件夹
                foreach (FileInfo f in files)
                {
                    ModManageList.Items.Add(f.Name);//添加文件名到列表中  
                }
            }
            catch { }

        }

        private async void button10_Click(object sender, RoutedEventArgs e)
        {

            //    try
            //    {

            //        var i = json_libList.SelectedItem.ToString();
            //        var j = i.Split("\n");

            //        var url = j[5];
            //        var save = j[4];
            //        using (var web = new WebClient())
            //        {
            //            web.DownloadFile(url, save);
            //        }
            //    MessageBox.Show("整合包\"" + j[4] + "\"下载完成,点击确定来安装", async (s, e) =>
            //    {
            //        if (e.Result.IsYes)
            //        {
            //            await Task.Run(async () =>
            //            {
            //                ModsPacksInstaller installer = new(System.AppDomain.CurrentDomain.BaseDirectory + j[4], ".minecraft", "");
            //                await Dispatcher.BeginInvoke(new Action(async delegate
            //                {
            //                    ProLabel.Content = "正在下载游戏核心";
            //                }));
            //                var i = await installer.GetModsPacksInfo();


            //                var str = i.Minecraft.ModLoaders.First().Id;

            //                if (str.IndexOf("forge") == 1)
            //                {
            //                    var id = i.Version;
            //                    var i2 = await ForgeInstaller.GetForgeBuildsOfVersionAsync(id);
            //                    ProLabel.Content = "当前下载：" + id + "-Forge_" + i2.First().Build;
            //                    GameCoreToolkit toolkit = new(".minecraft");

            //                    string line = File.ReadAllText(@"ECL2.2_Datas\javaCombo_Data.txt").ToString();
            //                    string[] l = line.Split("\r");
            //                    string l2 = l[0];
            //                    string l3 = l2.TrimEnd('r');
            //                    string l5 = l2.TrimEnd('n');
            //                    string l4 = l3.TrimEnd('\\');
            //                    string JavaPaths = l4;


            //                    ForgeInstaller forgeInstaller = new(toolkit, i2.First(), JavaPaths, i.Name);

            //                    var res1 = await forgeInstaller.InstallAsync(async x =>
            //                    {
            //                        await Dispatcher.BeginInvoke(new Action(async delegate
            //                        {
            //                            pro.Value = (x.Item1 * 100); ;
            //                        }));


            //                    });
            //                    if (res1.Success)
            //                    {
            //                        ProLabel.Content = $"游戏核心{id}-Forge_{i2.First().Build}下载完成";
            //                        await Dispatcher.BeginInvoke(new Action(async delegate
            //                        {
            //                            pro.Value = 0;
            //                        }));
            //                    }




            //                }
            //                else
            //                {
            //                    var id = i.Version;
            //                    var i2 = await FabricInstaller.GetFabricBuildsByVersionAsync(id);
            //                    List<FabricInstallBuild> list = new List<FabricInstallBuild>();
            //                    foreach (var build in i2)
            //                    {
            //                        list.Add(build);
            //                    }

            //                    ProLabel.Content = "当前下载版本：" + id + "-Fabric";
            //                    GameCoreToolkit toolkit = new(".minecraft");



            //                    FabricInstaller fabricInstaller = new(toolkit, i2.First(), i.Name);

            //                    var res2 = await fabricInstaller.InstallAsync(async x =>
            //                    {
            //                        await Dispatcher.BeginInvoke(new Action(async delegate
            //                        {
            //                            pro.Value = (x.Item1 * 100); ;
            //                        }));

            //                    });
            //                    if (res2.Success)
            //                    {

            //                        MessageBox.ShowDialog($"游戏核心{id}-Fabric下载完成");
            //                        await Dispatcher.BeginInvoke(new Action(async delegate
            //                        {
            //                            pro.Value = 0;
            //                        }));
            //                    }


            //                }
            //                var res = await installer.InstallAsync(async x =>
            //                {

            //                    await Dispatcher.BeginInvoke(new Action(async delegate
            //                    {
            //                        pro.Value = (x.Item1 * 100); ;
            //                    }));
            //                });

            //                if (res.Success)
            //                {

            //                    MessageBox.ShowDialog($"整合包{j[4]}安装完成");
            //                    await Dispatcher.BeginInvoke(new Action(async delegate
            //                    {
            //                        pro.Value = 0;
            //                    }));
            //                }
            //            });
            //            //选择了Yes
            //        }
            //        else
            //        {
            //            //选择了No
            //        }
            //    });


            //}
            //    catch { }
            MessageBox.ShowDialog("暂未完成此功能！");
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void Border_MouseMove_6(object sender, MouseEventArgs e)
        {
            button10.Opacity = 0.7;
        }

        private void Border_MouseLeave_6(object sender, MouseEventArgs e)
        {
            button10.Opacity = 1;
        }

        private void Border_MouseMove_7(object sender, MouseEventArgs e)
        {
            button11.Opacity = 0.7;
        }

        private void Border_MouseLeave_7(object sender, MouseEventArgs e)
        {
            button11.Opacity =1;
        }

        private async void button11_Click(object sender, RoutedEventArgs e)
        {
            var toolkit = new CurseForgeToolkit("");
            var res = await toolkit.SearchModpacksAsync(TextBox10.Text,category:4437);


           json_libList.Items.Clear();



            res.ForEach(x =>
            {


                foreach (var file in x.Files.Values)
                {
                    foreach (var file1 in file.AsEnumerable())
                        json_libList.Items.Add("整合包名:" + x.Name + "\n简介：" + x.Description + "\n游戏版本：" + file1.SupportedVersion + "\n模组加载器：" + file1.ModLoaderType + " \n" + file1.FileName + "\n" + file1.DownloadUrl);
                    //利用x参数获取当前模组的详细信息，例如获取模组名可以使用x.Name,获取文件列表可以用x.Files
                }
            });
            //利用x参数获取当前模组的详细信息，例如获取模组名可以使用x.Name,获取文件列表可以用x.Files


        }
    }
}
