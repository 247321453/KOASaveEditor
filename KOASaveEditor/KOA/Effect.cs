/*
 * 由SharpDevelop创建。
 * 用户： Acer
 * 日期: 7月28 星期一
 * 时间: 14:53
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.IO;
using System.Text;
using System.Globalization;
using System.Collections.Generic;

namespace KOASaveEditor.KOA
{
	/// <summary>
	/// 属性在文件中的信息
	/// </summary>
	public class Effect
	{
		public Effect(int code)
		{
			this.Code=code;
		}
		public static List<string> effecttext=new  List<string>();
		public static SortedList<int, string> effectList=new SortedList<int, string>();
		public static bool LoadEffect(string file)
		{
			if(!File.Exists(file))
				return false;
			using(FileStream fs=new FileStream(file, FileMode.Open))
			{
				StreamReader sr=new StreamReader(fs,Encoding.UTF8);
				string line;
				while((line=sr.ReadLine())!=null)
				{
					effecttext.Add(line);
					if(!line.StartsWith("#") && !line.StartsWith("-"))
					{
						int t=line.IndexOf(" ");
						if(t>0)
						{
							int k;
							string kstr=line.Substring(0,t);
							string v=line.Substring(t+1);
							int.TryParse(kstr, NumberStyles.HexNumber,null,out k);
							if(k>0 && !effectList.ContainsKey(k))
								effectList.Add(k,v);
						}
					}
				}
				sr.Close();
				fs.Close();
			}
			return true;
		}
		/// <summary>
		/// 属性代码
		/// </summary>
		public int Code
		{
			get{return code;}
			set{
				code=value;
				CodeString=code.ToString("X");
				if(Effect.effectList.ContainsKey(code))
					Detail=Effect.effectList[code];
				else
					Detail="unkown effect";
			}
		}
		private int code;
		/// <summary>
		/// 属性代码string
		/// </summary>
		public string CodeString;
		/// <summary>
		/// 属性文字描述
		/// </summary>
		public string Detail;
	}
}
