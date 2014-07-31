/*
 * 由SharpDevelop创建。
 * 用户： Acer
 * 日期: 7月30 星期三
 * 时间: 18:38
 * 
 */
using System;
using System.Collections.Generic;

namespace KOASaveEditor.KOA
{
	/// <summary>
	/// D玩家信息
	/// </summary>
	public class Player
	{
		public Player()
		{
			equips=new List<EquipItem>();
			ReSet();
		}
		/// <summary>
		/// 名字
		/// </summary>
		public string name;
		/// <summary>
		/// 名字位置1
		/// </summary>
		public int pos_name1;
		/// <summary>
		/// 名字位置2
		/// </summary>
		public int pos_name2;
		/// <summary>
		/// 当前等级
		/// </summary>
		public int level;
		/// <summary>
		/// 背包数
		/// </summary>
		public int bagcount;
		/// <summary>
		/// 背包位置
		/// </summary>
		public int pos_bagcount;
		/// <summary>
		/// 金钱
		/// </summary>
		public int money;
		/// <summary>
		/// 金钱位置
		/// </summary>
		public int pos_money;
		/// <summary>
		/// 总经验
		/// </summary>
		public int allexp;
		/// <summary>
		/// 当前等级获取的经验
		/// </summary>
		public int curexp;
		/// <summary>
		/// 距离下一级的经验
		/// </summary>
		public int nextexp;
		/// <summary>
		/// 所有装备
		/// </summary>
		public List<EquipItem> equips;
		/// <summary>
		/// 装备第一次位置
		/// </summary>
		public int pos_equip;
		
		public void ReSet()
		{
			name="";
			pos_name1=KOAEditor.nameIndex;
			pos_name2=0;
			bagcount=0;
			pos_bagcount=0;
			money=0;
			pos_money=0;
			allexp=0;
			
			equips.Clear();
			pos_equip=0;
		}

				
		
	}
}
