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
namespace ECL2._2.Content
{
    /// <summary>
    /// Setting.xaml 的交互逻辑
    /// </summary>
    public partial class Setting : Page
    {
        SettingPages.JavaSetting JavaSetting = new SettingPages.JavaSetting();
        SettingPages.LauncherSetting LauncherSetting = new SettingPages.LauncherSetting();
        SettingPages.OtherSetting OtherSetting = new SettingPages.OtherSetting();
        public Setting()
        {

            InitializeComponent();
            ContentControl1.Content = new Frame
            {
                Content = JavaSetting
            };
            ContentControl2.Content = new Frame
            {
                Content = LauncherSetting
            };
            ContentControl3.Content = new Frame
            {
                Content = OtherSetting
            };
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("确定清除全部数据？（包括用户，设置）", (s, e) =>
            {
                if (e.Result.IsYes)
                {
                    string path = "ECL2.2_Datas\\ID_Data.txt";
                    File.Delete(path);
                    string path2 = @"ECL2.2_Datas\javaCombo_Data.txt";
                    File.Delete(path2);
                    string path3 = "ECL2.2_Datas\\MemoryTextbox_Data.txt";
                    File.Delete(path3);
                    
                    MessageBox.ShowDialog("删除完成！");
                    //选择了Yes
                }
                else
                {
                    //选择了No
                }
            });
           
        }



        private void tabItem1_Clicked(object sender, MouseButtonEventArgs e)
        {
            ContentControl1.Content = new Frame
            {
                Content = JavaSetting
            };
        }

        private void tabItem2_Clicked(object sender, MouseButtonEventArgs e)
        {
            ContentControl2.Content = new Frame
            {
                Content = LauncherSetting
            };
        }
        private void tabItem3_Clicked(object sender, MouseButtonEventArgs e)
        {
            ContentControl3.Content = new Frame
            {
                Content = OtherSetting
            };
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
