/*
 * 由SharpDevelop创建。
 * 用户： Acer
 * 日期: 7月28 星期一
 * 时间: 14:51
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;

namespace KOASaveEditor.KOA
{
	/// <summary>
	/// Description of EquipItem.
	/// </summary>
	public class EquipItem
	{
		BitStream mBitstream;
		public EquipItem()
		{
			this.mBitstream=new BitStream();
		}
		/// <summary>
		/// 装备头部所在索引(XX XX XX XX 0B 00 00 00 68 D5 24 00 03)
		/// </summary>
		public int WeaponIndex;
		/// <summary>
		/// 当前长度
		/// </summary>
		public int Length
		{
			get{return Datas.Length;}
		}
		/// <summary>
		/// 初始的长度
		/// </summary>
		public int OldLength;
		/// <summary>
		/// 装备代码
		/// </summary>
		public int Code
		{
			get{return mBitstream.GetInt32(0);}
			set{
				mBitstream.Remove(0,4);
				mBitstream.InsertInt32(0,value);
			}
		}
		/// <summary>
		/// 装备属性列表头部在存档中的索引(占4字节,指示该装备拥有属性数量)
		/// </summary>
		public int EffectHeadIndex
		{
			get { return WeaponIndex + KOAEditor.WeaponAttHeadOffSet; }
		}

		/// <summary>
		/// 装备数据
		/// </summary>
		public byte[] Datas
		{
			get { return mBitstream.GetAllBytes(); }
			set { mBitstream.SetData(value);OldLength=value.Length;}
		}

		/// <summary>
		/// 装备名称
		/// </summary>
		public string Name
		{
			get
			{
				if (mBitstream.GetByte(KOAEditor.WeaponAttHeadOffSet + 22 + EffectCount * 8) != 1)
				{
					return KOAEditor.nuname;
				}
				else
				{
					return mBitstream.GetString(KOAEditor.WeaponAttHeadOffSet+22+EffectCount*8+1);
				}
			}
			set
			{
				int temp=KOAEditor.WeaponAttHeadOffSet + 22 + EffectCount * 8;
				mBitstream.Remove(temp, mBitstream.Length-temp-1);
				if (!string.IsNullOrEmpty(value)
				    && value!= KOAEditor.nuname
				    && value.Length<int.MaxValue
				   )
				{
					mBitstream.InsertBytes(temp, new byte[] { 1 });
					mBitstream.InsertString(temp+1, value);
				}
				else
				{
					mBitstream.InsertBytes(temp, new byte[] { 0 });
				}
			}
		}

		/// <summary>
		/// 属性数量
		/// </summary>
		public int EffectCount
		{
			get { return mBitstream.GetInt32(KOAEditor.WeaponAttHeadOffSet); }
		}

		/// <summary>
		/// 当前耐久度
		/// </summary>
		public float CurDurability
		{
			get { return mBitstream.GetFloat(KOAEditor.WeaponAttHeadOffSet + 8 + 8 * EffectCount); }
			set
			{
				if(value<=KOAEditor.MaxDur)
				{
					byte[] bt = BitConverter.GetBytes(value);
					int index=KOAEditor.WeaponAttHeadOffSet + 8 + 8 * EffectCount;
					mBitstream.Remove(index, 4);
					mBitstream.InsertBytes(index, bt);
				}
			}
		}

		/// <summary>
		/// 最大耐久度
		/// </summary>
		public float MaxDurability
		{
			get { return mBitstream.GetFloat(KOAEditor.WeaponAttHeadOffSet + 12 + 8 * EffectCount); }
			set
			{
				if(value<=KOAEditor.MaxDur)
				{
					byte[] bt = BitConverter.GetBytes(value);
					int index=KOAEditor.WeaponAttHeadOffSet + 12 + 8 * EffectCount;
					mBitstream.Remove(index, 4);
					mBitstream.InsertBytes(index, bt);
				}
			}
		}

		/// <summary>
		/// 装备属性列表
		/// </summary>
		public Effect[] Effects
		{
			get
			{
				List<Effect> attList = new List<Effect>();

				int attIndex = KOAEditor.WeaponAttHeadOffSet + 4;
				for (int i = 0; i < EffectCount; i++)
				{
					int code=mBitstream.GetInt32(attIndex);
					attList.Add(new Effect(code));

					attIndex += 8;
				}
				return attList.ToArray();
			}
		}
		/// <summary>
		/// 添加效果
		/// </summary>
		/// <param name="ef">新效果</param>
		/// <returns>是否添加成功</returns>
		public bool AddEffect(Effect ef)
		{
			List<Effect> list=new List<Effect>();
			list.AddRange(Effects);
			if(EffectCount < byte.MaxValue)
			{
				list.Add(ef);
				ReEffects(list.ToArray());
				return true;
			}
			return false;
		}
		/// <summary>
		/// 移除效果
		/// </summary>
		/// <param name="ef">效果</param>
		/// <returns>是否移除成功</returns>
		public bool RemoveEffect(Effect ef)
		{
			List<Effect> list=new List<Effect>();
			list.AddRange(Effects);
			for(int i=list.Count-1;i>=0;i--)
			{
				if(list[i].Code==ef.Code)
				{
					list.RemoveAt(i);
					ReEffects(list.ToArray());
					return true;
				}
			}
			return false;
		}
		/// <summary>
		/// 保存效果
		/// </summary>
		/// <param name="efs">效果数组</param>
		public void ReEffects(Effect[] efs)
		{
			int i=efs.Length-1;
			mBitstream.Remove(KOAEditor.WeaponAttHeadOffSet + 4, 8 * EffectCount);
			mBitstream.Remove(KOAEditor.WeaponAttHeadOffSet, 4);
			mBitstream.InsertInt32(KOAEditor.WeaponAttHeadOffSet, efs.Length);
			
			while(i>=0)
			{
				byte[] news = new byte[]{0xff,0xff,0xff,0xff};
				mBitstream.InsertInt32(KOAEditor.WeaponAttHeadOffSet + 4, efs[i--].Code);
				mBitstream.InsertBytes(KOAEditor.WeaponAttHeadOffSet + 8, news);
			}
		}
		/// <summary>
		/// 是否改变
		/// </summary>
		/// <param name="eitem">比较装备</param>
		/// <returns>是否一致</returns>
		public bool isSame(EquipItem eitem)
		{
			if(eitem.Length!=Length)
				return false;
			byte[] bytes=Datas;
			byte[] bytes2=eitem.Datas;
			for(int i=0;i<Length;i++)
			{
				if(bytes2[i]!=bytes[i])
				{
					return false;
				}
			}
			return true;
		}

	}
}
