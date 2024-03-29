﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

//建立Anim名称重写类
class MainNameRewriter
{
    //生成Anim名称重写部分
    public void MainNameRewrite(string Fpath)
    {
        try
        {
            //得到Anim.xfl路径
            FileInfo fi = new FileInfo(Fpath + "\\" + "Anim.xfl");
            if (!fi.Exists)
            {
                fi = new FileInfo(Fpath + "\\" + "main.xfl");
            }
            else { }
            //Anim.xfl重命名
            if (fi.Exists)
            {
                fi.MoveTo(Fpath + Fpath.Substring(Fpath.LastIndexOf("\\"), Fpath.Length - Fpath.LastIndexOf("\\")));
            }
            else { }
        }
        catch
        {
            Console.WriteLine("MainNameRewrite ERROR");
            //提示按任意键继续
            Console.WriteLine("Press any key to continue...");
            //输入任意键退出
            Console.ReadLine();
        }
    }
}
