/*
 * 由SharpDevelop创建。
 * 用户： Acer
 * 日期: 7月27 星期日
 * 时间: 18:01
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace KOASaveEditor
{
	/// <summary>
	/// 二进制操作
	/// </summary>
	public class BitStream
	{
		#region
		/// <summary>
		/// 默认构造
		/// </summary>
		public BitStream()
		{
			myencode=Encoding.Default;
			datas=new List<byte>();
		}
		/// <summary>
		/// 以文件名初构造
		/// </summary>
		/// <param name="file"></param>
		public BitStream(string file)
		{
			myencode=Encoding.Default;
			datas=new List<byte>();
			Open(file);
		}
		private List<byte> datas;
		private string filename;
		private Encoding myencode;
		/// <summary>
		/// byte数组的长度
		/// </summary>
		public int Length
		{
			get{return datas.Count;}
		}
		/// <summary>
		/// 默认编码为ANSI
		/// </summary>
		public Encoding MyEncode
		{
			get{return myencode;}
			set{value=myencode;}
		}

		#endregion
		
		#region file
		/// <summary>
		/// 设置byte数组
		/// </summary>
		/// <param name="bytes">添加的数组</param>
		public void SetData(byte[] bytes)
		{
			filename="temp.tmp";
			datas.Clear();
			datas.AddRange(bytes);
		}
		/// <summary>
		/// 打开一个文件，放入byte数组
		/// </summary>
		/// <param name="file">需要读取的文件</param>
		/// <returns>是否读取成功</returns>
		public bool Open(string file)
		{
			if(!File.Exists(file))
				return false;
			this.filename=file;
			datas.Clear();
			using(FileStream fs=new FileStream(file,FileMode.OpenOrCreate))
			{
				int b;
				while((b=fs.ReadByte())!=-1)
				{
					datas.Add((byte)b);
				}
				fs.Close();
			}
			return true;
		}
		/// <summary>
		/// 保存文件
		/// </summary>
		public void Save()
		{
			SaveAs(this.filename);
		}
		/// <summary>
		/// 文件另存为
		/// </summary>
		/// <param name="file"></param>
		public void SaveAs(string file)
		{
			using(FileStream fs=new FileStream(file,FileMode.OpenOrCreate))
			{
				for (int i=0;i< this.Length;i++)
				{
					fs.WriteByte(datas[i]);
				}
				fs.Close();
			}
		}
		#endregion
		
		#region Get
		/// <summary>
		/// 获取一个byte
		/// </summary>
		/// <param name="index">位置</param>
		/// <returns>字节，失败则返回0</returns>
		public byte GetByte(int index)
		{
			if(index<Length)
				return datas[index];
			return 0;
		}
		/// <summary>
		/// 根据字符串获取一个带字符串长度的byte数组
		/// </summary>
		/// <param name="str">需要转换的字符串</param>
		/// <returns>带字符串长度的byte数组</returns>
		public byte[] GetBytesByString(string str)
		{
			List<byte> list=new List<byte>();
			byte[] bytes=myencode.GetBytes(str);
			list.AddRange(BitConverter.GetBytes(bytes.Length));
			list.AddRange(bytes);
			return list.ToArray();
		}
		/// <summary>
		/// 获取所有字节
		/// </summary>
		/// <returns></returns>
		public byte[] GetAllBytes()
		{
			return datas.ToArray();
		}
		/// <summary>
		/// 从指定位置开始，截取一定长度的byte数组
		/// </summary>
		/// <param name="index">位置</param>
		/// <param name="count">长度</param>
		/// <returns>截取的数组，失败则返回null</returns>
		public byte[] GetBytes(int index, int length)
		{
			if(this.Length < length || length<=0 || length>this.Length)
				return null;
			return datas.GetRange(index, length).ToArray();
		}
		/// <summary>
		/// 从指定位置开始，截取4个字节转为int
		/// </summary>
		/// <param name="index">位置</param>
		/// <returns>对应的整型，失败则返回0</returns>
		public int GetInt32(int index)
		{
			byte[] bytes=GetBytes(index, 4);
			if(bytes!=null)
				return BitConverter.ToInt32(bytes, 0);
			else
				return 0;
		}
		/// <summary>
		/// 从指定位置开始，截取4个字节转为float
		/// </summary>
		/// <param name="index">位置</param>
		/// <returns>对应的单精确度，失败则返回0</returns>
		public float GetFloat(int index)
		{
			byte[] bytes=GetBytes(index, 4);
			if(bytes!=null)
				return BitConverter.ToSingle(bytes, 0);
			else
				return 0;
		}
		/// <summary>
		/// 从指定位置开始，先截取4个字节获取字符串的长度，
		/// 再截取相应的长度转为字符串
		/// </summary>
		/// <param name="index">位置</param>
		/// <returns>对应的字符串，失败则返回""</returns>
		public string GetString(int index)
		{
			int count=GetInt32(index);
			byte[] bytes=GetBytes(index+4, count);
			if(bytes!=null)
				return myencode.GetString(bytes);
			else
				return "";
		}
		#endregion
		
		#region Insert
		/// <summary>
		/// 在末尾添加byte数组
		/// </summary>
		/// <param name="bytes">需要添加的byte数组</param>
		public void AddBytes(byte[] bytes)
		{
			datas.AddRange(bytes);
		}
		/// <summary>
		/// 在指定位置，插入一个byte数组
		/// </summary>
		/// <param name="index">位置</param>
		/// <param name="bytes">数组</param>
		public void InsertBytes(int index ,byte[] bytes)
		{
			if(this.Length < index || bytes==null || bytes.Length==0)
				return;
			datas.InsertRange(index, bytes);
		}
		/// <summary>
		/// 在指定位置，插入一个整型数组
		/// </summary>
		/// <param name="index">位置</param>
		/// <param name="bytes">数值</param>
		public void InsertInt32(int index ,int number)
		{
			InsertBytes(index, BitConverter.GetBytes(number));
		}
		/// <summary>
		/// 在指定位置，插入字符串的一个带长度的byte数组
		/// </summary>
		/// <param name="index">位置</param>
		/// <param name="str">字符串</param>
		public void InsertString(int index ,string str)
		{
			InsertBytes(index, GetBytesByString(str));
		}
		#endregion
		
		#region Remove
		/// <summary>
		/// 移除指定位置，指定长度的byte数组
		/// </summary>
		/// <param name="index">位置</param>
		/// <param name="count">长度</param>
		/// <returns>移除的长度</returns>
		public int Remove(int index, int count)
		{
			if(this.Length < (index+count) || count<=0)
			{
				return 0;
			}
			datas.RemoveRange(index, count);
			return count;
		}
		#endregion
		
		#region Find
		/// <summary>
		/// 在byte数组1中查找byte数组2的第一次出现位置
		/// </summary>
		/// <param name="index">开始查找位置</param>
		/// <param name="bytes1">byte数组1</param>
		/// <param name="bytes2">byte数组2</param>
		/// <returns>出现位置，没有则返回-1</returns>
		public static int Find(int index, byte[] bytes1,byte[] bytes2)
		{
			int i = index, j = 0;
			while ( (i+bytes2.Length-1)< bytes1.Length && j<bytes2.Length)
			{
				if ( bytes1[i+j] == bytes2[j] )
				{
					j ++; // 继续比较后一字符
				}
				else
				{
					i ++;
					j = 0; // 重新开始新的一轮匹配
				}
			}
			if(j==bytes2.Length)
				return i;
			return -1;
		}
		/// <summary>
		/// 在当前byte数组中查找byte数组2的第一次出现位置
		/// </summary>
		/// <param name="index">开始查找位置</param>
		/// <param name="bytes2">byte数组2</param>
		/// <returns>出现位置，没有则返回-1</returns>
		public int Find(int index, byte[] bytes2)
		{
			int i = index, j = 0;
			byte[] bytes1=datas.ToArray();
			while ( (i+bytes2.Length-1)< bytes1.Length && j<bytes2.Length)
			{
				if ( bytes1[i+j] == bytes2[j] )
				{
					j ++; // 继续比较后一字符
				}
				else
				{
					i ++;
					j = 0; // 重新开始新的一轮匹配
				}
			}
			if(j==bytes2.Length)
				return i;
			return -1;
		}
		/// <summary>
		/// 在当前byte数组中查找字符串的第一次出现位置
		/// </summary>
		/// <param name="index">开始查找位置</param>
		/// <param name="str">字符串</param>
		/// <returns>出现位置，没有则返回-1</returns>
		public int Find(int index,string str)
		{
			return  Find(index, GetBytesByString(str));
		}
		/// <summary>
		/// 在当前byte数组中查找字符串的所有出现位置
		/// </summary>
		/// <param name="index">开始查找位置</param>
		/// <param name="key">字符串</param>
		/// <returns>所有出现位置，没有则返回null</returns>
		public int[] FindIndexByString(string key)
		{
			byte[] bytes=myencode.GetBytes(key);
			return FindIndexByBytes(bytes);
		}
		/// <summary>
		/// 在当前byte数组中查找byte数组的所有出现位置
		/// </summary>
		/// <param name="index">开始查找位置</param>
		/// <param name="bytes">字符串</param>
		/// <returns>所有出现位置，没有则返回null</returns>
		public int[] FindIndexByBytes(byte[] bytes)
		{
			int i=0;
			List<int> indexs=new List<int>();
			while((i = Find(i,bytes))!=-1)
			{
				indexs.Add(i);
				i+=bytes.Length;
			}
			if(indexs.Count==0)
				return null;
			return indexs.ToArray();
		}
		#endregion
	}
}
