/*
 * 由SharpDevelop创建。
 * 用户： Acer
 * 日期: 7月27 星期日
 * 时间: 18:01
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using KOASaveEditor.KOA;

namespace KOASaveEditor
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		#region init
		string skPath,thPath;
		KOAEditor roaedit;
		string title;
		string effectFile;
		SortedList<int, EquipItem> searchEitems;
		EquipItem nowequip;
		public MainForm()
		{
			thPath=Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),"My Games\\Reckoning");
			skPath=Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"SKIDROW\\102500\\Storage");
			InitializeComponent();
			effectFile=Path.Combine(Application.StartupPath,"attribute.txt");
			roaedit=new KOAEditor(effectFile);
			title=this.Text;
			cb_level.Items.Clear();
			for(int i=0;i<=40;i++)
			{
				cb_level.Items.Add(i.ToString());
			}
			cb_level.SelectedIndex=0;
			searchEitems=new SortedList<int, EquipItem>();
			nowequip=null;
			cb_effect.Items.Clear();
			foreach(string str in Effect.effecttext)
			{
				cb_effect.Items.Add(str);
			}
		}
		#endregion
		
		#region file
		string savfilter="Save File(*.sav)|*.sav|All File(*.*)|*.*";
		void SelectSave(string path)
		{
			using(OpenFileDialog of=new OpenFileDialog())
			{
				if(!string.IsNullOrEmpty(path))
					of.InitialDirectory=path;
				of.Filter=savfilter;
				if(of.ShowDialog()==DialogResult.OK)
				{
					LoadSave(of.FileName);
				}
			}
		}
		void LoadSave(string savefile)
		{
			this.Text=Path.GetFileName(savefile)+" - "+title;
			roaedit.Open(savefile);
			tb_bagcount.Text=roaedit.GetBagCount().ToString();
			tb_name.Text=roaedit.Getname();
			roaedit.GetEquips();
			searchEitems=roaedit.Eitems;
			RefreshEquips();
		}
		void ReloadToolStripMenuItemClick(object sender, EventArgs e)
		{
			roaedit.Reload();
			tb_bagcount.Text=roaedit.GetBagCount().ToString();
			tb_name.Text=roaedit.Getname();
			roaedit.GetEquips();
			searchEitems=roaedit.Eitems;
			RefreshEquips();
		}
		#endregion
		
		#region menu click
		void OpenToolStripMenuItemClick(object sender, EventArgs e)
		{
			SelectSave("");
		}
		
		void OpenSkToolStripMenuItemClick(object sender, EventArgs e)
		{
			SelectSave(skPath);
		}
		
		void OpenThToolStripMenuItemClick(object sender, EventArgs e)
		{
			SelectSave(thPath);
		}
		
		void QuitToolStripMenuItemClick(object sender, EventArgs e)
		{
			Application.Exit();
		}
		void SaveToolStripMenuItemClick(object sender, EventArgs e)
		{
			roaedit.Save();
		}
		
		void ToolStripMenuItem1Click(object sender, EventArgs e)
		{
			using(SaveFileDialog sf=new SaveFileDialog())
			{
				sf.Filter=savfilter;
				if(sf.ShowDialog()==DialogResult.OK)
				{
					roaedit.SaveAs(sf.FileName);
				}
			}
		}
		
		void AboutToolStripMenuItemClick(object sender, EventArgs e)
		{
			MessageBox.Show("本存档修改器只适用于版本:"+KOAEditor.GameVersion
			                +"\n查找经验：根据等级和当前经验。","关于");
		}
		
		void GitToolStripMenuItemClick(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("https://github.com/247321453/KOASaveEditor");
		}
		void DownloadToolStripMenuItemClick(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("https://github.com/247321453/KOASaveEditor/raw/master/win32/win32.zip");
		}
		#endregion
		
		#region bag name
		void btn_modnameClick(object sender, EventArgs e)
		{
			string name=tb_name.Text;
			if(!roaedit.Setname(name))
			{
				MessageBox.Show("名字修改失败！","警告");
				tb_name.Text=roaedit.Getname();
				return;
			}
		}
		void btn_ModBagClick(object sender, EventArgs e)
		{
			int count;
			int.TryParse(tb_bagcount.Text, out count);
			if(!roaedit.SetBagCount(count))
			{
				MessageBox.Show("修改失败!\n1、背包数量不能为0\n2、背包数不能超过"+KOAEditor.bagMaxCount.ToString(),"警告");
			}
		}
		#endregion
		
		#region exp
		void btn_GetExpClick(object sender, EventArgs e)
		{
			int level;
			int.TryParse(cb_level.Text, out level);
			int nowexp;
			int.TryParse(tb_curexp.Text, out nowexp);
			nowexp=roaedit.GetExp(level, nowexp);
			if(nowexp>0)
			{
				tb_allexp.Text=roaedit.allExp.ToString();
				tb_nextexp.Text=roaedit.nextExp.ToString();
				//tb_curexp.Text=roaedit.curExp.ToString();
			}
			else
			{
				MessageBox.Show("查找经验值失败！","错误");
			}
		}
		
		void btn_ModExpClick(object sender, EventArgs e)
		{
			int nowexp;
			int.TryParse(tb_allexp.Text,out nowexp);
			if(!roaedit.SetExp(nowexp))
			{
				MessageBox.Show("修改经验失败！","错误");
			}
		}
		void btn_ModLevelClick(object sender, EventArgs e)
		{
			int level;
			int.TryParse(cb_level.Text,out level);
			if(!roaedit.SetLevel(level))
			{
				MessageBox.Show("修改等级失败！","错误");
			}
		}
		#endregion
		
		#region equip
		void btn_FindEquipClick(object sender, EventArgs e)
		{
			float curdur,maxdur;
			float.TryParse(tb_searchcurdur.Text, out curdur);
			float.TryParse(tb_searchmaxdur.Text, out maxdur);
			roaedit.Search(tb_searchname.Text, curdur, maxdur);
			searchEitems=roaedit.searchEitems;
			RefreshEquips();
		}
		
		void SetEuqip(EquipItem eitem)
		{
			tb_searchname.Text=eitem.Name;
			tb_searchcurdur.Text=eitem.CurDurability.ToString();
			tb_searchmaxdur.Text=eitem.MaxDurability.ToString();
			tb_hex.Text=BitConverter.ToString(eitem.Datas).Replace("-"," ");
			tb_equipcode.Text=eitem.Code.ToString("X");
			lv_effect.Items.Clear();
			ListViewItem[] lvitems=new ListViewItem[eitem.EffectCount];
			int i=0;
			Effect[] efs=eitem.Effects;
			foreach(Effect ef in efs)
			{
				lvitems[i]=new ListViewItem();
				lvitems[i].Text=ef.CodeString;
				if ( i % 2 == 0 )
					lvitems[i].BackColor = Color.GhostWhite;
				else
					lvitems[i].BackColor = Color.White;
				lvitems[i].SubItems.Add(ef.Detail);
				i++;
			}
			lv_effect.Items.AddRange(lvitems);
		}
		
		void test()
		{
			#if DEBUG
			MessageBox.Show(BitConverter.ToString(nowequip.Datas).Replace("-"," "));
			#endif
		}
		void btn_ModEquipClick(object sender, EventArgs e)
		{
			string name=tb_searchname.Text;
			string curdur=tb_searchcurdur.Text;
			string maxdur=tb_searchmaxdur.Text;
			string code=tb_equipcode.Text;
			float icurdur,imaxdur;
			int icode;
			float.TryParse(curdur, out icurdur);
			float.TryParse(maxdur, out imaxdur);
			int.TryParse(code, NumberStyles.HexNumber,null,out icode);
			
			if(icurdur>0 && nowequip.CurDurability!=icurdur)
				nowequip.CurDurability=icurdur;
			if(imaxdur>0 && nowequip.MaxDurability!=imaxdur)
				nowequip.MaxDurability=imaxdur;
			if(icode>0 && nowequip.Code!=icode)
				nowequip.Code=icode;
			nowequip.Name=name;

			roaedit.SaveEquip(nowequip);
			SetEuqip(nowequip);
			RefreshEquips();
		}
		
		void btn_DeleteEquipClick(object sender, EventArgs e)
		{
			roaedit.DeleteEquipById(GetCurEquipIndex());
		}
		#endregion
		
		#region equip list
		int GetCurEquipIndex()
		{
			if(lv_equips.SelectedItems.Count>0)
			{
				return lv_equips.SelectedItems[0].Index;
			}
			return 0;
		}
		void RefreshEquips()
		{
			lv_equips.Items.Clear();
			ListViewItem[] lvitems=new ListViewItem[searchEitems.Count];
			int i=0;
			foreach(EquipItem eitem in searchEitems.Values)
			{
				lvitems[i]=new ListViewItem();
				lvitems[i].Text=eitem.WeaponIndex.ToString();
				if ( i % 2 == 0 )
					lvitems[i].BackColor = Color.GhostWhite;
				else
					lvitems[i].BackColor = Color.White;
				lvitems[i].SubItems.Add(eitem.Name);
				lvitems[i].SubItems.Add(eitem.Code.ToString("X"));
				lvitems[i].SubItems.Add(eitem.CurDurability.ToString());
				lvitems[i].SubItems.Add(eitem.MaxDurability.ToString());
				lvitems[i].SubItems.Add(eitem.EffectCount.ToString());
				i++;
			}
			lv_equips.Items.AddRange(lvitems);
		}
		
		
		void Lv_equipsSelectedIndexChanged(object sender, EventArgs e)
		{
			int index=GetCurEquipIndex();
			nowequip=searchEitems.Values[index];
			SetEuqip(nowequip);
		}
		
		#endregion
		
		#region effect
		int GetEffectCode()
		{
			int id;
			string txt=cb_effect.Text;
			int t=txt.IndexOf(" ");
			if(t>0)
			{
				int.TryParse(txt.Substring(0,t), NumberStyles.HexNumber,null,out id);
			}
			else
			{
				int.TryParse(txt, NumberStyles.HexNumber,null,out id);
			}
			if(id>0)
			{
				return id;
			}
			else
				MessageBox.Show("效果格式错误！格式：XXXXXX 描述","警告");
			return 0;
		}
		void Btn_AddEffectClick(object sender, EventArgs e)
		{
			int id=GetEffectCode();
			if(nowequip.AddEffect(new Effect(id)))
			{
				//test();
				SetEuqip(nowequip);
				RefreshEquips();
			}
			else
				MessageBox.Show("添加失败！\n可能是效果超过最大值："+KOAEditor.MaxEffectCount.ToString(),"错误");
		}
		
		void Btn_deleffectClick(object sender, EventArgs e)
		{
			if(lv_effect.SelectedItems.Count>0)
			{
				string sid=lv_effect.SelectedItems[0].Text;
				int id;
				int.TryParse(sid, NumberStyles.HexNumber,null,out id);
				

				if(nowequip.RemoveEffect(new Effect(id)))
				{
					SetEuqip(nowequip);
					RefreshEquips();
				}
				else
					MessageBox.Show("删除失败！\n可能没有找到该效果。","错误");
			}
		}
		#endregion

	}
}
