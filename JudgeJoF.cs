using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

//建立判断类
class JudgeJoF
{
	//判断完成后路径定义
	public string Path = null;
	//判断完成后xfl路径定义
	public string Fpath = null;
	//判断完成后位图路径定义
	public string Spath = null;
	
	//创建xr实例
	XflReader xr = new XflReader();
	//递归判断
	public void ReJudge(string filepath)
    {
        try
        {
			if (File.Exists(filepath))
			{
				Console.WriteLine("已检测到为文件，请拖入文件夹，而不是单独文件");
				//递归判断
				ReJudge(Console.ReadLine().Trim('"'));
			}
			else if (Directory.Exists(filepath))
			{
				Console.WriteLine("检测到为文件夹，处理中......");
				this.Path = filepath;
			}
			else
			{
				Console.WriteLine("未检测到文件或文件夹！请检查！");
				//递归判断
				ReJudge(Console.ReadLine().Trim('"'));
			}
		}
		catch
		{
			Console.WriteLine("ERROR");
		}
	}

	//判断是file还是dir路径
	public void Judge(string filepath)
	{

		try
		{
			//判断是文件还是文件夹
			ReJudge(filepath);
			this.Fpath = this.Path;
			Console.WriteLine("含xfl文件夹的总文件夹录入完成，处理中......");
			Console.WriteLine("请将含位图文件夹拖入窗体，并按回车键（不输入直接按回车默认位图和xfl文件夹在同一总文件夹中）");
			this.Spath = Console.ReadLine().Trim('"');
			if (this.Spath == "" || this.Spath == "/n/n")
            {
				this.Spath = this.Fpath;
            }
            else
            {
				//判断是文件还是文件夹
				ReJudge(this.Spath);
				this.Spath = this.Path;
			}
			Console.WriteLine("含位图文件夹的总文件夹录入完成，处理中......");
			//寻找总文件夹中所有Anim.xfl文件
			xr.XflRead(this.Fpath,this.Spath);
			
		}
		catch
		{
			Console.WriteLine("ERROR");
		}

	}
}