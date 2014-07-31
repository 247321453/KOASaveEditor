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
			Effect.LoadEffect(effectFile);
			player=new Player();
		}
		//二进制
		BitStream bitstream;
		//存档名
		string filename;
		/// <summary>
		/// 背包关键字
		/// </summary>
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
		/// 装备关键byte
		/// </summary>
		public static byte[] equitHead = new byte[]{0x0B,0,0,0, 0x68,0xD5, 0x24,0 ,3};
		
		/// <summary>
		/// 分割数组
		/// </summary>
		public static byte[] sepbyte = new byte[]{6,0,0,0,0,0,0,0};
		
		/// <summary>
		/// 名字的第一次出现位置
		/// </summary>
		public static int nameIndex=17;
		/// <summary>
		/// 最大耐久值
		/// </summary>
		public static int MaxDur=0x64;
		/// <summary>
		/// 默认名字
		/// </summary>
		public static string nuname="unkown";
		
		#endregion
		
		#region effect
		public List<string> GetEffectList()
		{
			return Effect.effecttext;
		}
		public SortedList<int, string> GetEffectSortList()
		{
			return Effect.effectList;
		}
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
			//File.Copy(file, file+".bak",true);
			bitstream.SaveAs(file);
		}
		/// <summary>
		/// 保存存档
		/// </summary>
		public void Save()
		{
			if(!isOpen)
				return ;
			//File.Copy(filename, filename+".bak",true);
			bitstream.Save();
		}
		#endregion
		
		#region player
		/// <summary>
		/// 玩家信息
		/// </summary>
		public Player player;
		int allexp;
		/// <summary>
		/// 获取玩家信息
		/// 每次改动字符串，或者装备，就调用这个函数一次s
		/// </summary>
		public void LoadPlayer()
		{
			player.ReSet();
			//获取名字
			player.name=bitstream.GetString(player.pos_name1);
			int index=bitstream.Find(player.pos_name1+4, player.name);
			if(index>0)
			{
				player.pos_name2=index;
				player.pos_money=index-4;
				//获取金钱
				player.money=bitstream.GetInt32(player.pos_money);
			}
			SearchExp(0,allexp);
			//获取背包
			GetBagCount();
			//获取装备
			GetEquips();
		}
		#endregion
		
		#region get bag count
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
								//
								player.pos_bagcount=j;
								player.bagcount=num;
								//
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
			return count;
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
			player.equips.Clear();
			int[] indexs=bitstream.FindIndexByBytes(KOAEditor.equitHead);
			int temp;
			if(indexs==null)
				return ;
			int len=indexs.Length;
			//首次位置
			player.pos_equip=indexs[0];
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
					player.equips.Add(weapon);
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
		/// 搜索装备
		/// </summary>
		/// <param name="name">关键字，为null时，不做搜索条件</param>
		/// <param name="curdur">当前耐久，为0时不做搜索条件</param>
		/// <param name="maxdur">最大耐久，为0时不做搜索条件</param>
		public EquipItem[] Search(string name ,float curdur,float maxdur)
		{
			List<EquipItem> list=new List<EquipItem>();
			foreach(EquipItem item in player.equips)
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
				list.Add(item);
			}
			return list.ToArray();
		}
		
		#endregion
		
		#region search exp
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
		public int SearchExp(int level,int nowexp)
		{
			if(!isOpen)
				return -1;
			int nextExp;
			int curExp=nowexp;
			int allExp=curExp+SumExp(level);
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
				allexp=allExp;
				player.level=GetLevel(allexp);
				player.allexp=allExp;
				player.nextexp=nextExp;
				player.curexp=curExp;
			}
			else
			{
				allexp=0;
				player.level=0;
				player.allexp=0;
				player.nextexp=0;
				player.curexp=0;
			}
			return index;
		}
		int GetLevel(int allExp)
		{
			int i=0,sum=0;
			if(allexp<=0)
				return 0;
			//l e   s   i
			//0 400 0   0
			//      500 1
			while(sum<allExp)
			{
				sum+=KOAEditor.Level[i];
				i++;
			}
			return i-1;
		}
		#endregion
		
		#region set
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
			//旧的长度
			int oldlen=bitstream.GetBytesByString(player.name).Length;
			//新的长度
			int nowlen=bitstream.GetBytesByString(name).Length;
			//修改第一次位置
			bitstream.Remove(player.pos_name1, oldlen);
			bitstream.InsertString(player.pos_name1, name);
			//修改第二次位置
			//计算第二次名字出现的位置偏移值
			player.pos_name2=player.pos_name2+(nowlen-oldlen);
			bitstream.Remove(player.pos_name2, oldlen);
			bitstream.InsertString(player.pos_name2, name);
			if((nowlen-oldlen)!=0)//长度不一样时，重新加载
				LoadPlayer();
			else
				player.name=name;
			return true;
		}
		
		/// <summary>
		/// 保存总经验
		/// </summary>
		/// <param name="exp">总经验</param>
		/// <returns>是否保存成功</returns>
		public bool SetExp(int exp)
		{
			if(!isOpen || allexp==0)
				return false;
			allexp=player.allexp;
			int p=SearchExp(0, allexp);
			//
			bitstream.Remove(p,4);
			bitstream.InsertInt32(p,exp);
			//
			bitstream.Remove(p+4+sepbyte.Length, 4);
			bitstream.InsertInt32(p+4+sepbyte.Length, exp);
			//LoadPlayer();
			return true;
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
		
		/// <summary>
		/// 设置金钱
		/// </summary>
		/// <param name="money">新金钱</param>
		/// <returns>是否成功</returns>
		public bool SetMoney(int money)
		{
			if(player.money==0|| money<=0 || money > int.MaxValue)
				return false;
			bitstream.Remove(player.pos_money,4);
			bitstream.InsertInt32(player.pos_money,money);
			//LoadPlayer();
			return true;
		}
		
		/// <summary>
		/// 保存背包上限
		/// </summary>
		/// <param name="count">新的背包上限</param>
		/// <returns>是否成功</returns>
		public bool SetBagCount(int count)
		{
			if(!isOpen||player.bagcount==0||count<=0||count >= int.MaxValue)
				return false;
			bitstream.Remove(player.pos_bagcount,4);
			bitstream.InsertInt32(player.pos_bagcount,count);
			//LoadPlayer();
			return true;
		}
		#endregion
		
		#region edit equip
		/// <summary>
		/// 删除装备
		/// </summary>
		/// <param name="index">装备出现的位置</param>
		public void DeleteEquipByIndex(int index)
		{
			int i,count=player.equips.Count;
			for(i=0;i<count;i++)
			{
				if(player.equips[i].WeaponIndex==index)
				{
					player.equips.RemoveAt(i);
					LoadPlayer();
					break;
				}
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
			LoadPlayer();
		}
		#endregion
	}
}
