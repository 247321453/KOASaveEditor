/*
 * 由SharpDevelop创建。
 * 用户： Acer
 * 日期: 7月28 星期一
 * 时间: 14:54
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Text;
using System.Collections.Generic;
using System.IO;

namespace KOASaveEditor.KOA
{
	/// <summary>
	/// Description of ROAEditor.
	/// </summary>
	public class KOAEditor
	{
		#region init
		public KOAEditor(string effectFile)
		{
			bitstream=new BitStream();
			pos_bagcount=-1;
			equitHead = new byte[]{0x0B,0,0,0, 0x68,0xD5, 0x24,0 ,3};
			sepbyte=new byte[]{6,0,0,0,0,0,0,0};
			Eitems=new SortedList<int, EquipItem>();
			searchEitems=new SortedList<int, EquipItem>();
			Effect.LoadEffect(effectFile);
		}
		/// <summary>
		/// 装备属性头部指示属性数量的数据相对装备数据头部的偏移量
		/// </summary>
		public static int WeaponAttHeadOffSet = 21;
		public static string GameVersion = "1.0.2";
		public bool isOpen
		{
			get{
				if(bitstream.Length>0)
					return true;
				else
					return false;
			}
		}
		public BitStream bitstream;
		int pos_bagcount;
		int pos_exp;
		string filename;
		public string playername;
		byte[] equitHead;
		byte[] sepbyte;
		public int bagCount;
		public int allExp;
		public int nextExp;
		public int curExp;
		public static int nameIndex=17;
		public static int bagMaxCount=int.MaxValue;
		public static int nameMaxLength=0xff;
		public static int MaxEffectCount=0xff;
		public SortedList<int, EquipItem> Eitems;
		public static int MaxDur=0x64;
		public SortedList<int, EquipItem> searchEitems;
		public static string nuname="unkown";
		#endregion
		
		#region level
		public static int[] Level=new int[]{
			500,
			1100,
			1800,
			2600,
			3500,
			4500,
			5700,
			6900,
			8300,
			9700,
			11300,
			12900,
			14700,
			16500,
			18500,
			20500,
			22500,
			24500,
			27500,
			30500,
			33500,
			36500,
			40500,
			44500,
			48500,
			52500,
			57500,
			62500,
			67500,
			72500,
			79500,
			86500,
			93500,
			100500,
			110500,
			120500,
			130500,
			140500,
			155500,
			170500,
			185500,
			244000
		};
		#endregion
		
		#region file
		public bool Open(string file)
		{
			this.filename=file;
			return bitstream.Open(file);
		}
		
		public void SaveAs(string file)
		{
			if(!isOpen)
				return ;
			File.Copy(file, file+".bak",true);
			bitstream.SaveAs(file);
		}
		public void Reload()
		{
			Open(filename);
		}
		public void Save()
		{
			if(!isOpen)
				return ;
			File.Copy(filename, filename+".bak",true);
			bitstream.Save();
		}
		#endregion
		
		#region bag
		public int GetBagCount()
		{
			if(!isOpen)
				return -1;
			int count=-1;
			string key="current_inventory_count";
			int len=Encoding.Default.GetBytes(key).Length;
			int index=bitstream.Find(0, key);
			int p=0;
			if(index>=0)
			{
				p=index+len;
				byte[] bytes=new byte[12];
				bytes[0]=3;
				bytes[4]=6;
				byte[] endbe=new byte[]{0xcd,0x34,0,0};
				int index2=bitstream.Find(p, bytes);
				if((index2-p) < 128)
				{
					int index3=bitstream.Find(index2, endbe);
					if(index3-index2 < 128)
					{
						for(int j=index2+4;j<index3;j=j+4)
						{
							int num=bitstream.GetInt32(j);
							if(num>=50)
							{
								pos_bagcount=j;
								count=num;
								break;
							}
						}
					}
					else
						count=-4;
				}
				else
					count=-3;
			}
			else
				count=-2;
			bagCount=count;
			return count;
		}
		public bool SetBagCount(int count)
		{
			if(!isOpen)
				return false;
			if(count>0 && count< KOAEditor.bagMaxCount)
			{
				bitstream.Remove(pos_bagcount, 4);
				bitstream.InsertInt32(pos_bagcount, count);
				return true;
			}
			return false;
		}
		#endregion
		
		#region edit
		//删除装备
		public void DeleteEquipById(int weaponIndex)
		{
			if(!isOpen)
				return ;
			if(Eitems.ContainsKey(weaponIndex))
			{
				EquipItem eitem=Eitems[weaponIndex];
				bitstream.Remove(eitem.WeaponIndex,eitem.Length);
				Eitems.Remove(weaponIndex);
			}
		}
		/// <summary>
		/// 保存装备
		/// </summary>
		/// <param name="eitem"></param>
		public void SaveEquip(EquipItem eitem)
		{
			if(!isOpen)
				return ;
			bitstream.Remove(eitem.WeaponIndex, eitem.OldLength);
			bitstream.InsertBytes(eitem.WeaponIndex, eitem.Datas);
			GetEquips();
		}
		#endregion
		
		#region effect
		public SortedList<int, string> GetEffectList()
		{
			return Effect.effectList;
		}
		#endregion
		
		#region get equip
		/// <summary>
		/// 获取所有装备
		/// </summary>
		public void GetEquips()
		{
			if(!isOpen)
				return ;
			Eitems.Clear();
			int[] indexs=bitstream.FindIndexByBytes(equitHead);
			int temp;
			if(indexs==null)
				return ;
			int len=indexs.Length;
			for(int i=0; i < len; i++)
			{
				indexs[i]-=4;
			}
			for(int i=0; i < len; i++)
			{
				if(i != len-1)
				{
					if (indexs[i + 1] - indexs[i] < 44)
					{
						continue;
					}
				}
				EquipItem weapon=new EquipItem();
				weapon.WeaponIndex = indexs[i];
				
				if (i != len - 1)
				{
					weapon.Datas = bitstream.GetBytes(indexs[i], indexs[i + 1] - indexs[i]);
				}
				else
				{
					int attHeadIndex = weapon.WeaponIndex + KOAEditor.WeaponAttHeadOffSet;
					int attCount = bitstream.GetInt32(attHeadIndex);
					int endIndex = 0;
					temp=attHeadIndex + 22 + attCount * 8;
					if (bitstream.Get(temp) != 1)//无名字
					{
						endIndex = temp;
					}
					else
					{
						int nameLength = 0;
						nameLength = bitstream.GetInt32(temp + 1);
						endIndex = temp + nameLength + 4;
					}
					weapon.Datas = bitstream.GetBytes(weapon.WeaponIndex, endIndex - weapon.WeaponIndex+1);
				}
				if (weapon.CurDurability != 100
				    && weapon.MaxDurability != -1
				    && weapon.MaxDurability != 100
				    && weapon.CurDurability != 0
				    && weapon.MaxDurability != 0)
				{
					Eitems.Add(weapon.WeaponIndex, weapon);
				}
				else
				{
					continue;
				}
			}
		}
		#endregion
		
		#region search equip
		public void SearchByName(string name)
		{
			searchEitems.Clear();
			foreach(EquipItem item in Eitems.Values)
			{
				if(item.Name.IndexOf(name,StringComparison.OrdinalIgnoreCase)>=0)
				{
					searchEitems.Add(item.WeaponIndex, item);
				}
			}
		}
		public void SearchByDur(float curdur,float maxdur)
		{
			searchEitems.Clear();
			foreach(EquipItem item in Eitems.Values)
			{
				if(item.MaxDurability==maxdur)
				{
					if(item.CurDurability.ToString().IndexOf(curdur.ToString())>=0)
					{
						searchEitems.Add(item.WeaponIndex, item);
					}
				}
			}
		}
		public void Search(string name ,float curdur,float maxdur)
		{
			searchEitems.Clear();
			foreach(EquipItem item in Eitems.Values)
			{
				if(!string.IsNullOrEmpty(name) && name != KOAEditor.nuname)
				{
					if(item.Name.IndexOf(name,StringComparison.OrdinalIgnoreCase)<0)
						continue;
				}
				if(item.CurDurability != 0)
				{
					if(item.CurDurability.ToString().IndexOf(curdur.ToString())<0)
						continue;
				}
				if(item.MaxDurability != 0)
				{
					if(item.MaxDurability.ToString().IndexOf(maxdur.ToString())<0)
						continue;
				}
				searchEitems.Add(item.WeaponIndex, item);
			}
			
		}
		
		#endregion
		
		#region exp
		int SumExp(int level)
		{
			if(level >= KOAEditor.Level.Length)
				level=40;
			int exps=0;
			for(int i=0;i<level;i++)
			{
				exps+=KOAEditor.Level[i];
			}
			return exps;
		}
		//XX XX XX XX 06 00 00 00 00 00 00 00
		public int GetExp(int level,int nowexp)
		{
			if(!isOpen)
				return -1;
			curExp=nowexp;
			allExp=curExp+SumExp(level);
			if(level < KOAEditor.Level.Length)
				nextExp=KOAEditor.Level[level];
			else
				nextExp=0;
			List<byte> bytes=new List<byte>();
			bytes.AddRange(BitConverter.GetBytes(allExp));
			bytes.AddRange(sepbyte);
			bytes.AddRange(BitConverter.GetBytes(allExp));
			int index=bitstream.Find(0, bytes.ToArray());
			if(index>=0)
			{
				pos_exp=index;
				return allExp;
			}
			return -1;
		}
		public bool SetExp(int exp)
		{
			if(!isOpen)
				return false;
			bitstream.Remove(pos_exp, 4+8+4);
			bitstream.InsertInt32(pos_exp, exp);
			bitstream.InsertBytes(pos_exp+4,sepbyte);
			bitstream.InsertInt32(pos_exp+4+8, exp);
			return true;
		}
		public bool SetLevel(int level)
		{
			int exps=SumExp(level);
			return SetExp(exps);
		}
		#endregion
		
		#region name
		public string Getname()
		{
			if(!isOpen)
				return "";
			string name=bitstream.GetString(nameIndex);
			playername=name;
			return name;
		}
		public bool Setname(string name)
		{
			if(!isOpen)
				return false;
			if(string.IsNullOrEmpty(name))
				return false;
			byte[] nowname=bitstream.GetBytesByString(name);
			if(nowname.Length>KOAEditor.nameMaxLength)
				return false;
			byte[] oldname=bitstream.GetBytesByString(playername);
			bitstream.Remove(nameIndex, oldname.Length);
			bitstream.InsertBytes(nameIndex, nowname);
			int index=bitstream.Find(nameIndex+oldname.Length,oldname);
			if(index>0)
			{
				int count=bitstream.GetInt32(index);
				bitstream.Remove(index, count+4);
				bitstream.InsertBytes(index, nowname);
			}
			return true;
		}
		#endregion
	}
}
