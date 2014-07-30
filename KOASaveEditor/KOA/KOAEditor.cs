/*
 * 由SharpDevelop创建。
 * 用户： Acer
 * 日期: 7月28 星期一
 * 时间: 14:54
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace KOASaveEditor.KOA
{
	/// <summary>
	/// Description of ROAEditor.
	/// </summary>
	public class KOAEditor
	{
		#region init
		/// <summary>
		/// 以效果列表文件构造
		/// </summary>
		/// <param name="effectFile">效果列表文件</param>
		public KOAEditor(string effectFile)
		{
			bitstream=new BitStream();
			playername="";
			equitHead = new byte[]{0x0B,0,0,0, 0x68,0xD5, 0x24,0 ,3};
			sepbyte=new byte[]{6,0,0,0,0,0,0,0};
			Eitems=new SortedList<int, EquipItem>();
			searchEitems=new SortedList<int, EquipItem>();
			Effect.LoadEffect(effectFile);
		}
		public static string bagkey="current_inventory_count";
		/// <summary>
		/// 装备属性头部指示属性数量的数据相对装备数据头部的偏移量
		/// </summary>
		public static int WeaponAttHeadOffSet = 21;
		/// <summary>
		/// 适用游戏版本
		/// </summary>
		public static string GameVersion = "1.0.2";
		/// <summary>
		/// 是否打开存档
		/// </summary>
		public bool isOpen
		{
			get{
				if(bitstream.Length>0)
					return true;
				else
					return false;
			}
		}
		BitStream bitstream;
		
		string filename;

		byte[] equitHead;
		byte[] sepbyte;
		
		/// <summary>
		/// 当前金钱
		/// </summary>
		public int money;
		string playername;
		/// <summary>
		/// 当背包上限
		/// </summary>
		public int bagCount;
		/// <summary>
		/// 总经验
		/// </summary>
		public int allExp;
		/// <summary>
		/// 距离下一级的经验
		/// </summary>
		public int nextExp;
		/// <summary>
		/// 当前等级获取的经验
		/// </summary>
		public int curExp;
		/// <summary>
		/// 名字的第一次出现位置
		/// </summary>
		public static int nameIndex=17;
		/// <summary>
		/// 背包最大值
		/// </summary>
		public static int bagMaxCount=int.MaxValue;
		/// <summary>
		/// 名字最大长度
		/// </summary>
		public static int nameMaxLength=byte.MaxValue;
		/// <summary>
		/// 最大效果数
		/// </summary>
		public static int MaxEffectCount=byte.MaxValue;
		/// <summary>
		/// 所有装备
		/// </summary>
		public SortedList<int, EquipItem> Eitems;
		/// <summary>
		/// 最大耐久值
		/// </summary>
		public static int MaxDur=0x64;
		/// <summary>
		/// 当前装备
		/// </summary>
		public SortedList<int, EquipItem> searchEitems;
		/// <summary>
		/// 默认名字
		/// </summary>
		public static string nuname="unkown";
		#endregion
		
		#region level
		/// <summary>
		/// 等级所需经验
		/// </summary>
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
		/// <summary>
		/// 打开存档
		/// </summary>
		/// <param name="file">存档文件</param>
		/// <returns></returns>
		public bool Open(string file)
		{
			this.filename=file;
			return bitstream.Open(file);
		}
		/// <summary>
		/// 另存为新存档
		/// </summary>
		/// <param name="file">新存档</param>
		public void SaveAs(string file)
		{
			if(!isOpen)
				return ;
			File.Copy(file, file+".bak",true);
			bitstream.SaveAs(file);
		}
		/// <summary>
		/// 重新加载存档
		/// </summary>
		public void Reload()
		{
			Open(filename);
		}
		/// <summary>
		/// 保存存档
		/// </summary>
		public void Save()
		{
			if(!isOpen)
				return ;
			File.Copy(filename, filename+".bak",true);
			bitstream.Save();
		}
		#endregion
		
		#region bag
		/// <summary>
		/// 获取背包上限
		/// </summary>
		/// <returns>背包上限，失败则返回负数</returns>
		public int GetBagCount()
		{
			if(!isOpen)
				return -1;
			int count=-1;
			
			int index=bitstream.Find(0, KOAEditor.bagkey);
			int p=0;
			if(index>=0)
			{
				p=index+KOAEditor.bagkey.Length;
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
		/// <summary>
		/// 保存背包上限
		/// </summary>
		/// <param name="count">新的背包上限</param>
		/// <returns>是否成功</returns>
		public bool SetBagCount(int count)
		{
			if(!isOpen)
				return false;
			if(count>0 && count< KOAEditor.bagMaxCount)
			{
				int index=bitstream.Find(0, KOAEditor.bagkey);
				if(index>0)
				{
					List<byte> bagbytes=new List<byte>();
					bagbytes.AddRange(sepbyte);
					bagbytes.AddRange(BitConverter.GetBytes(bagCount));
					index=bitstream.Find(index, bagbytes.ToArray());
					if(index>0)
					{
						bitstream.Remove(index+sepbyte.Length, 4);
						bitstream.InsertInt32(index+sepbyte.Length, count);
						return true;
					}
				}
			}
			return false;
		}
		#endregion
		
		#region edit
		/// <summary>
		/// 删除装备
		/// </summary>
		/// <param name="weaponIndex">装备位置</param>
		public void DeleteEquipByIndex(int weaponIndex)
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
		/// <param name="eitem">装备</param>
		public void SaveEquip(EquipItem eitem)
		{
			if(!isOpen)
				return ;
			bitstream.Remove(eitem.WeaponIndex, eitem.OldLength);
			bitstream.InsertBytes(eitem.WeaponIndex, eitem.Datas);
			GetEquips();
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
					if (bitstream.GetByte(temp) != 1)//无名字
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
		/// <summary>
		/// 搜索装备 by 名字
		/// </summary>
		/// <param name="name"></param>
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
		/// <summary>
		/// 搜索装备 by 耐久
		/// </summary>
		/// <param name="curdur"></param>
		/// <param name="maxdur"></param>
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
		/// <summary>
		/// 搜索装备
		/// </summary>
		/// <param name="name">关键字，为null时，不做搜索条件</param>
		/// <param name="curdur">当前耐久，为0时不做搜索条件</param>
		/// <param name="maxdur">最大耐久，为0时不做搜索条件</param>
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
				if(item.CurDurability > 0)
				{
					if(item.CurDurability.ToString().IndexOf(curdur.ToString())<0)
						continue;
				}
				if(item.MaxDurability > 0)
				{
					if(item.MaxDurability.ToString().IndexOf(maxdur.ToString())<0)
						continue;
				}
				searchEitems.Add(item.WeaponIndex, item);
			}
			
		}
		
		#endregion
		
		#region exp
		//根据等级计算总经验
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
		/// <summary>
		/// 根据等级和当前等级经验，获取经验值位置
		/// XX XX XX XX 06 00 00 00 00 00 00 00 XX XX XX XX
		/// </summary>
		/// <param name="level">等级</param>
		/// <param name="nowexp">当前等级经验</param>
		/// <returns>经验值位置，失败为负数</returns>
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
				return allExp;
			}
			return -1;
		}
		/// <summary>
		/// 保存总经验
		/// </summary>
		/// <param name="exp">总经验</param>
		/// <returns>是否保存成功</returns>
		public bool SetExp(int exp)
		{
			if(!isOpen)
				return false;
			List<byte> bytes=new List<byte>();
			bytes.AddRange(BitConverter.GetBytes(allExp));
			bytes.AddRange(sepbyte);
			bytes.AddRange(BitConverter.GetBytes(allExp));
			int index=bitstream.Find(0, bytes.ToArray());
			if(index>0)
			{
				bitstream.Remove(index, 4+8+4);
				bitstream.InsertInt32(index, exp);
				bitstream.InsertBytes(index+4,sepbyte);
				bitstream.InsertInt32(index+4+8, exp);
				return true;
			}
			return false;
		}
		/// <summary>
		/// 保存等级
		/// </summary>
		/// <param name="level">等级</param>
		/// <returns>是否保存成功</returns>
		public bool SetLevel(int level)
		{
			int exps=SumExp(level);
			return SetExp(exps);
		}
		#endregion
		
		#region name
		/// <summary>
		/// 获取玩家名
		/// </summary>
		/// <returns></returns>
		public string GetPlayerName()
		{
			if(!isOpen)
				return "";
			string name=bitstream.GetString(nameIndex);
			playername=name;
			return name;
		}
		/// <summary>
		/// 设置玩家名
		/// </summary>
		/// <param name="name">新名字</param>
		/// <returns></returns>
		public bool SetPlayerName(string name)
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
		#region money
		/// <summary>
		/// 获取金钱
		/// </summary>
		/// <returns>当前金钱，失败则返回-1</returns>
		public int GetMoney()
		{
			if(string.IsNullOrEmpty(playername))
				GetPlayerName();
			byte[] oldname=bitstream.GetBytesByString(playername);
			int index=bitstream.Find(nameIndex+oldname.Length, oldname);
			if(index>0)
			{
				return bitstream.GetInt32(index-4);
			}
			return -1;
		}
		/// <summary>
		/// 设置金钱
		/// </summary>
		/// <param name="money">新金钱</param>
		/// <returns>是否成功</returns>
		public bool SetMoney(int money)
		{
			if(money<=0 || money > int.MaxValue || this.money<0)
				return false;
			this.money=money;
			byte[] oldname=bitstream.GetBytesByString(playername);
			int index=bitstream.Find(nameIndex+oldname.Length, oldname);
			if(index>0)
			{
				int p=index-4;
				bitstream.Remove(p, 4);
				bitstream.InsertInt32(p, money);
				return true;
			}
			return false;
		}
		#endregion
	}
}
