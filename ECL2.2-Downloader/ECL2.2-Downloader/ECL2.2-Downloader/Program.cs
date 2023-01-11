using MinecraftLaunch.Launch;
using MinecraftLaunch.Modules.Enum;
using MinecraftLaunch.Modules.Installer;
using MinecraftLaunch.Modules.Models.Auth;
using MinecraftLaunch.Modules.Models.Launch;
using MinecraftLaunch.Modules.Toolkits;
using Natsurainko.FluentCore.Extension.Windows.Service;
using System.IO;
using System.Text;

Console.WriteLine("ECL2.2-Downloader 程序版本:0.8.0Beta");
if (!File.Exists("ECL2.2_Datas\\AutoInstall-Temp.txt"))
{

}
else
{

    string[] line1 = File.ReadAllLines(@"ECL2.2_Datas\AutoInstall-Temp.txt");
    string AutoInstall = line1[0];

    if (!File.Exists("ECL2.2_Datas\\DownloadVersion-Temp.txt"))
    {


    }
    else if (AutoInstall == "0")
    {
        string[] line = File.ReadAllLines(@"ECL2.2_Datas\DownloadVersion-Temp.txt");
        string Version = line[0];
        GameCoreToolkit toolkit = new(".minecraft");

        GameCoreInstaller coreInstaller = new(toolkit, Version);

        var coreres = await coreInstaller.InstallAsync(x =>
        {
            Console.WriteLine(x.Item2.ToString()+"    进度:"+ (float.Parse(x.Item1.ToString())) * 100 + "%");
        });

        //游戏资源补全安装模块
        ResourceInstaller installer = new(coreres.GameCore);
        await installer.DownloadAsync((x, c) =>
        {
            Console.WriteLine(x.ToString() + "    进度:" + (float.Parse(c.ToString())) * 100 + "%");
            //在这里获取当前资源补全进度,利用c获取数字进度,x获取文字进度
        });
        string path = "ECL2.2_Datas\\DownloadVersion-Temp.txt";
        File.Delete(path);
        string path1 = "ECL2.2_Datas\\AutoInstall-Temp.txt";
        File.Delete(path1);
    }
    else if (AutoInstall == "1")
    {
        string[] line = File.ReadAllLines(@"ECL2.2_Datas\DownloadVersion-Temp.txt");
        string Version = line[0];
        GameCoreToolkit toolkit = new(".minecraft");


        var i = await ForgeInstaller.GetForgeBuildsOfVersionAsync(Version);
        //StreamReader sr = new StreamReader(@"ECL2.2_Datas\javaCombo_Data.txt", Encoding.UTF8);
        ////2.调用StreamReader对象的readline方法,读取第1行
        //string content = sr.ReadLine();
        ////3.释放资源
        //sr.Dispose();
        //string JavaPaths = content;
        var JavaPaths= JavaHelper.SearchJavaRuntime().ToList();
        
        ForgeInstaller forgeInstaller = new(toolkit, i.First(), JavaPaths.First());
        await forgeInstaller.InstallAsync(x =>
        {
            Console.WriteLine(x.Item2.ToString() + "    进度:" + (float.Parse(x.Item1.ToString())) * 100 + "%");
            //在这里获取当前安装进度,利用x.Item1获取数字进度,x.Item2获取文字进度
        });
        string path = "ECL2.2_Datas\\DownloadVersion-Temp.txt";
        File.Delete(path);
        string path1 = "ECL2.2_Datas\\AutoInstall-Temp.txt";
        File.Delete(path1);
    }

    else if (AutoInstall == "2")
    {
        string[] line = File.ReadAllLines(@"ECL2.2_Datas\DownloadVersion-Temp.txt");
        string Version = line[0];
        GameCoreToolkit toolkit = new(".minecraft");


        var i = await FabricInstaller.GetFabricBuildsByVersionAsync(Version);
        FabricInstaller fabricInstaller = new(toolkit, i.First());
        await fabricInstaller.InstallAsync(x =>
        {
            Console.WriteLine(x.Item2.ToString() + "    进度:" + (float.Parse(x.Item1.ToString())) * 100 + "%");
            //在这里获取当前安装进度,利用x.Item1获取数字进度,x.Item2获取文字进度
        });

        string path = "ECL2.2_Datas\\DownloadVersion-Temp.txt";
        File.Delete(path);
        string path1 = "ECL2.2_Datas\\AutoInstall-Temp.txt";
        File.Delete(path1);
    }
    else if (AutoInstall == "3")
    {
        string[] line = File.ReadAllLines(@"ECL2.2_Datas\DownloadVersion-Temp.txt");
        string Version = line[0];
        GameCoreToolkit toolkit = new(".minecraft");


        var i = await QuiltInstaller.GetQuiltBuildsByVersionAsync(Version);
        QuiltInstaller quiltInstaller = new(toolkit, i.First());
        var res = await quiltInstaller.InstallAsync(x =>
        {
            Console.WriteLine(x.Item2.ToString() + "    进度:" + (float.Parse(x.Item1.ToString())) * 100 + "%");
        });

        if (res.Success)
            Console.WriteLine($"游戏核心 {res.GameCore.Id} 安装成功");

        string path = "ECL2.2_Datas\\DownloadVersion-Temp.txt";
        File.Delete(path);
        string path1 = "ECL2.2_Datas\\AutoInstall-Temp.txt";
        File.Delete(path1);
    }
    else if (AutoInstall == "4")
    {
        string[] line = File.ReadAllLines(@"ECL2.2_Datas\DownloadVersion-Temp.txt");
        string Version = line[0];
        GameCoreToolkit toolkit = new(".minecraft");

        //StreamReader sr = new StreamReader(@"ECL2.2_Datas\javaCombo_Data.txt", Encoding.UTF8);
        ////2.调用StreamReader对象的readline方法,读取第1行
        //string content = sr.ReadLine();
        ////3.释放资源
        //sr.Dispose();
        //string JavaPaths = content;
        var JavaPaths = JavaHelper.SearchJavaRuntime().ToList();
        var i = await OptiFineInstaller.GetOptiFineBuildsFromMcVersionAsync(Version);
        OptiFineInstaller optfineInstaller = new(toolkit, i.First(),JavaPaths.First());
        var res = await optfineInstaller.InstallAsync(x =>
        {
            Console.WriteLine(x.Item2.ToString() + "    进度:" + (float.Parse(x.Item1.ToString())) * 100 + "%");
        });

        if (res.Success)
            Console.WriteLine($"游戏核心 {res.GameCore.Id} 安装成功");

        string path = "ECL2.2_Datas\\DownloadVersion-Temp.txt";
        File.Delete(path);
        string path1 = "ECL2.2_Datas\\AutoInstall-Temp.txt";
        File.Delete(path1);
    }
}