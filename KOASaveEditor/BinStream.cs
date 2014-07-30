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
	public class BitStream
	{
		#region
		public BitStream()
		{
			myencode=Encoding.Default;
			datas=new List<byte>();
		}
		private List<byte> datas;
		private string filename;
		private Encoding myencode;
		public int Length
		{
			get{return datas.Count;}
		}
		public Encoding MyEncode
		{
			get{return myencode;}
			set{value=myencode;}
		}
		public BitStream(string file)
		{
			myencode=Encoding.Default;
			datas=new List<byte>();
			Open(file);
		}
		#endregion
		
		#region file
		public void SetData(byte[] bytes)
		{
			filename="temp.sav";
			datas.Clear();
			datas.AddRange(bytes);
		}
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
		public void Save()
		{
			SaveAs(this.filename);
		}
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
		public byte Get(int index)
		{
			if(index<Length)
				return datas[index];
			return 0;
		}
		public byte[] GetBytesByString(string str)
		{
			List<byte> list=new List<byte>();
			byte[] bytes=myencode.GetBytes(str);
			list.AddRange(BitConverter.GetBytes(bytes.Length));
			list.AddRange(bytes);
			return list.ToArray();
		}
		public byte[] GetAllBytes()
		{
			return datas.ToArray();
		}
		public byte[] GetBytes(int index, int count)
		{
			if(this.Length < count || count<=0 || count>this.Length)
				return null;
			return datas.GetRange(index, count).ToArray();
		}
		public int GetInt32(int index)
		{
			byte[] bytes=GetBytes(index, 4);
			if(bytes!=null)
				return BitConverter.ToInt32(bytes, 0);
			else
				return 0;
		}
		public long GetInt64(int index)
		{
			byte[] bytes=GetBytes(index, 8);
			if(bytes!=null)
				return BitConverter.ToInt64(bytes, 0);
			else
				return 0;
		}
		public float GetFloat(int index)
		{
			byte[] bytes=GetBytes(index, 4);
			if(bytes!=null)
				return BitConverter.ToSingle(bytes, 0);
			else
				return 0;
		}
		
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
		public void AddBytes(byte[] bytes)
		{
			datas.AddRange(bytes);
		}
		public void InsertBytes(int index ,byte[] bytes)
		{
			if(this.Length < index || bytes==null || bytes.Length==0)
				return;
			datas.InsertRange(index, bytes);
		}
		public void InsertInt32(int index ,int inum)
		{
			InsertBytes(index, BitConverter.GetBytes(inum));
		}
		
		public void InsertInt64(int index ,long lnum)
		{
			InsertBytes(index, BitConverter.GetBytes(lnum));
		}
		public void InsertString(int index ,string str)
		{
			InsertBytes(index, GetBytesByString(str));
		}
		#endregion
		
		#region Remove
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
		public int Find(int index,string str)
		{
			return  Find(index, GetBytesByString(str));
		}
		public int[] FindIndexByString(string key)
		{
			byte[] bytes=myencode.GetBytes(key);
			return FindIndexByBytes(bytes);
		}
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
