using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

//建立xfl读取类
class XflReader
{
    //创建sc实例
    SpriteCopyer sc = new SpriteCopyer();
    //创建mnr实例
    MainNameRewriter mnr = new MainNameRewriter();
    //生成xfl读取部分
    public void XflRead(string Fpath,string Spath)
    {
        try
        {
            //创建路径文件夹实例
            DirectoryInfo TheFolder = new DirectoryInfo(Fpath);
            //数组记录各个xfl文件信息
            FileInfo[] xfl = TheFolder.GetFiles("Anim.xfl", SearchOption.AllDirectories);
            //新功能更新而停用///FileInfo[] mxfl = TheFolder.GetFiles("main.xfl", SearchOption.AllDirectories);
            //新功能更新而停用///xfl = (FileInfo[])xfl.Concat(mxfl).ToArray();
            if (xfl.Length != 0)
            {
                for (int i = 0; i < xfl.Length ; i++)
                {
                    //创建ddr实例
                    DOMDocumentReader ddr = new DOMDocumentReader();
                    //创建bsc实例
                    BigSpriteCopyer bsc = new BigSpriteCopyer();
                    //记录装载xfl的路径
                    string dir = xfl[i].DirectoryName;
                    //获取dir文件夹名
                    DirectoryInfo dirname = new DirectoryInfo(dir);
                    //新功能更新而停用//执行位图复制操作
                    //新功能更新而停用///sc.SpriteCopy(dir);
                    //将位图引用录入数组
                    ddr.DOMDocumentRead(dir + "\\" + "DOMDocument.xml");
                    //大文件夹图片复制
                    bsc.BigSpriteCopy(dir,Spath,ddr.sarray);
                    Console.WriteLine(dirname.Name + "的LIBRARY位图已填充");
                    //执行Anim名称重写操作
                    mnr.MainNameRewrite(dir);
                    Console.WriteLine(dirname.Name + "的xfl文件已重命名");
                }
            }
            else { }
        }
        catch
        {
            Console.WriteLine("XflRead ERROR");
            //提示按任意键继续
            Console.WriteLine("Press any key to continue...");
            //输入任意键退出
            Console.ReadLine();
        }
    }
}
