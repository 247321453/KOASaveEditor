/*
 * 由SharpDevelop创建。
 * 用户： Acer
 * 日期: 7月27 星期日
 * 时间: 18:01
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace KOASaveEditor
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openSkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openThToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.reloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.gitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.downloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tb_bagcount = new System.Windows.Forms.TextBox();
			this.tb_allexp = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btn_getexp = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.tb_name = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.btn_modname = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.cb_level = new System.Windows.Forms.ComboBox();
			this.tb_nextexp = new System.Windows.Forms.TextBox();
			this.btn_modbag = new System.Windows.Forms.Button();
			this.btn_modexp = new System.Windows.Forms.Button();
			this.lv_equips = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.btn_delequip = new System.Windows.Forms.Button();
			this.btn_saveequip = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btn_modlevel = new System.Windows.Forms.Button();
			this.tb_curexp = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.tb_searchname = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.button6 = new System.Windows.Forms.Button();
			this.tb_searchmaxdur = new System.Windows.Forms.TextBox();
			this.tb_searchcurdur = new System.Windows.Forms.TextBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.btn_deleffect = new System.Windows.Forms.Button();
			this.tb_hex = new System.Windows.Forms.TextBox();
			this.lv_effect = new System.Windows.Forms.ListView();
			this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
			this.cb_effect = new System.Windows.Forms.ComboBox();
			this.btn_addeffect = new System.Windows.Forms.Button();
			this.tb_equipcode = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.tb_money = new System.Windows.Forms.TextBox();
			this.btn_modmoney = new System.Windows.Forms.Button();
			this.menuStrip1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.fileFToolStripMenuItem,
									this.helpHToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(734, 25);
			this.menuStrip1.TabIndex = 2;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileFToolStripMenuItem
			// 
			this.fileFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.openOToolStripMenuItem,
									this.openSkToolStripMenuItem,
									this.openThToolStripMenuItem,
									this.toolStripSeparator3,
									this.reloadToolStripMenuItem,
									this.toolStripSeparator1,
									this.saveToolStripMenuItem,
									this.toolStripMenuItem1,
									this.toolStripSeparator2,
									this.quitToolStripMenuItem});
			this.fileFToolStripMenuItem.Name = "fileFToolStripMenuItem";
			this.fileFToolStripMenuItem.Size = new System.Drawing.Size(58, 21);
			this.fileFToolStripMenuItem.Text = "文件(&F)";
			// 
			// openOToolStripMenuItem
			// 
			this.openOToolStripMenuItem.Name = "openOToolStripMenuItem";
			this.openOToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
			this.openOToolStripMenuItem.Text = "打开存档";
			this.openOToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItemClick);
			// 
			// openSkToolStripMenuItem
			// 
			this.openSkToolStripMenuItem.Name = "openSkToolStripMenuItem";
			this.openSkToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
			this.openSkToolStripMenuItem.Text = "打开skidrow存档";
			this.openSkToolStripMenuItem.Click += new System.EventHandler(this.OpenSkToolStripMenuItemClick);
			// 
			// openThToolStripMenuItem
			// 
			this.openThToolStripMenuItem.Name = "openThToolStripMenuItem";
			this.openThToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
			this.openThToolStripMenuItem.Text = "打开Theta存档";
			this.openThToolStripMenuItem.Click += new System.EventHandler(this.OpenThToolStripMenuItemClick);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(167, 6);
			// 
			// reloadToolStripMenuItem
			// 
			this.reloadToolStripMenuItem.Name = "reloadToolStripMenuItem";
			this.reloadToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
			this.reloadToolStripMenuItem.Text = "重新加载存档";
			this.reloadToolStripMenuItem.Click += new System.EventHandler(this.ReloadToolStripMenuItemClick);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(167, 6);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
			this.saveToolStripMenuItem.Text = "保存存档";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItemClick);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(170, 22);
			this.toolStripMenuItem1.Text = "另存为新存档";
			this.toolStripMenuItem1.Click += new System.EventHandler(this.ToolStripMenuItem1Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(167, 6);
			// 
			// quitToolStripMenuItem
			// 
			this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
			this.quitToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
			this.quitToolStripMenuItem.Text = "退出";
			this.quitToolStripMenuItem.Click += new System.EventHandler(this.QuitToolStripMenuItemClick);
			// 
			// helpHToolStripMenuItem
			// 
			this.helpHToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.aboutToolStripMenuItem,
									this.gitToolStripMenuItem,
									this.downloadToolStripMenuItem});
			this.helpHToolStripMenuItem.Name = "helpHToolStripMenuItem";
			this.helpHToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
			this.helpHToolStripMenuItem.Text = "帮助(&H)";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
			this.aboutToolStripMenuItem.Text = "关于(&A)";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItemClick);
			// 
			// gitToolStripMenuItem
			// 
			this.gitToolStripMenuItem.Name = "gitToolStripMenuItem";
			this.gitToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
			this.gitToolStripMenuItem.Text = "源代码";
			this.gitToolStripMenuItem.Click += new System.EventHandler(this.GitToolStripMenuItemClick);
			// 
			// downloadToolStripMenuItem
			// 
			this.downloadToolStripMenuItem.Name = "downloadToolStripMenuItem";
			this.downloadToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
			this.downloadToolStripMenuItem.Text = "下载最新版本";
			this.downloadToolStripMenuItem.Click += new System.EventHandler(this.DownloadToolStripMenuItemClick);
			// 
			// tb_bagcount
			// 
			this.tb_bagcount.Location = new System.Drawing.Point(548, 85);
			this.tb_bagcount.Name = "tb_bagcount";
			this.tb_bagcount.Size = new System.Drawing.Size(100, 21);
			this.tb_bagcount.TabIndex = 3;
			// 
			// tb_allexp
			// 
			this.tb_allexp.Location = new System.Drawing.Point(60, 96);
			this.tb_allexp.Name = "tb_allexp";
			this.tb_allexp.Size = new System.Drawing.Size(100, 21);
			this.tb_allexp.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(491, 88);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 12);
			this.label1.TabIndex = 4;
			this.label1.Text = "背包上限";
			// 
			// btn_getexp
			// 
			this.btn_getexp.Location = new System.Drawing.Point(163, 49);
			this.btn_getexp.Name = "btn_getexp";
			this.btn_getexp.Size = new System.Drawing.Size(70, 40);
			this.btn_getexp.TabIndex = 0;
			this.btn_getexp.Text = "查找经验";
			this.btn_getexp.UseVisualStyleBackColor = true;
			this.btn_getexp.Click += new System.EventHandler(this.btn_GetExpClick);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(4, 74);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(41, 12);
			this.label3.TabIndex = 4;
			this.label3.Text = "下一级";
			// 
			// tb_name
			// 
			this.tb_name.Location = new System.Drawing.Point(547, 29);
			this.tb_name.Name = "tb_name";
			this.tb_name.Size = new System.Drawing.Size(172, 21);
			this.tb_name.TabIndex = 3;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(491, 31);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(41, 12);
			this.label4.TabIndex = 4;
			this.label4.Text = "玩家名";
			// 
			// btn_modname
			// 
			this.btn_modname.Location = new System.Drawing.Point(548, 56);
			this.btn_modname.Name = "btn_modname";
			this.btn_modname.Size = new System.Drawing.Size(175, 23);
			this.btn_modname.TabIndex = 0;
			this.btn_modname.Text = "修改名字";
			this.btn_modname.UseVisualStyleBackColor = true;
			this.btn_modname.Click += new System.EventHandler(this.btn_modnameClick);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(5, 24);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(29, 12);
			this.label5.TabIndex = 4;
			this.label5.Text = "等级";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(3, 49);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(53, 12);
			this.label6.TabIndex = 4;
			this.label6.Text = "当前经验";
			// 
			// cb_level
			// 
			this.cb_level.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cb_level.FormattingEnabled = true;
			this.cb_level.Location = new System.Drawing.Point(59, 19);
			this.cb_level.Name = "cb_level";
			this.cb_level.Size = new System.Drawing.Size(100, 20);
			this.cb_level.TabIndex = 5;
			// 
			// tb_nextexp
			// 
			this.tb_nextexp.Location = new System.Drawing.Point(60, 69);
			this.tb_nextexp.Name = "tb_nextexp";
			this.tb_nextexp.ReadOnly = true;
			this.tb_nextexp.Size = new System.Drawing.Size(100, 21);
			this.tb_nextexp.TabIndex = 3;
			// 
			// btn_modbag
			// 
			this.btn_modbag.Location = new System.Drawing.Point(651, 83);
			this.btn_modbag.Name = "btn_modbag";
			this.btn_modbag.Size = new System.Drawing.Size(74, 23);
			this.btn_modbag.TabIndex = 0;
			this.btn_modbag.Text = "修改背包";
			this.btn_modbag.UseVisualStyleBackColor = true;
			this.btn_modbag.Click += new System.EventHandler(this.btn_ModBagClick);
			// 
			// btn_modexp
			// 
			this.btn_modexp.Location = new System.Drawing.Point(163, 95);
			this.btn_modexp.Name = "btn_modexp";
			this.btn_modexp.Size = new System.Drawing.Size(73, 23);
			this.btn_modexp.TabIndex = 0;
			this.btn_modexp.Text = "修改总经验";
			this.btn_modexp.UseVisualStyleBackColor = true;
			this.btn_modexp.Click += new System.EventHandler(this.btn_ModExpClick);
			// 
			// lv_equips
			// 
			this.lv_equips.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader1,
									this.columnHeader2,
									this.columnHeader3,
									this.columnHeader4,
									this.columnHeader5,
									this.columnHeader6});
			this.lv_equips.FullRowSelect = true;
			this.lv_equips.GridLines = true;
			this.lv_equips.Location = new System.Drawing.Point(2, 27);
			this.lv_equips.Name = "lv_equips";
			this.lv_equips.ShowItemToolTips = true;
			this.lv_equips.Size = new System.Drawing.Size(480, 239);
			this.lv_equips.TabIndex = 6;
			this.lv_equips.UseCompatibleStateImageBehavior = false;
			this.lv_equips.View = System.Windows.Forms.View.Details;
			this.lv_equips.SelectedIndexChanged += new System.EventHandler(this.Lv_equipsSelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "位置";
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "装备名";
			this.columnHeader2.Width = 131;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "装备ID";
			this.columnHeader3.Width = 101;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "当前耐久";
			this.columnHeader4.Width = 64;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "最大耐久";
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "效果";
			this.columnHeader6.Width = 38;
			// 
			// btn_delequip
			// 
			this.btn_delequip.ForeColor = System.Drawing.Color.Maroon;
			this.btn_delequip.Location = new System.Drawing.Point(624, 201);
			this.btn_delequip.Name = "btn_delequip";
			this.btn_delequip.Size = new System.Drawing.Size(89, 23);
			this.btn_delequip.TabIndex = 0;
			this.btn_delequip.Text = "删除装备";
			this.btn_delequip.UseVisualStyleBackColor = true;
			this.btn_delequip.Click += new System.EventHandler(this.btn_DeleteEquipClick);
			// 
			// btn_saveequip
			// 
			this.btn_saveequip.Location = new System.Drawing.Point(472, 201);
			this.btn_saveequip.Name = "btn_saveequip";
			this.btn_saveequip.Size = new System.Drawing.Size(146, 23);
			this.btn_saveequip.TabIndex = 0;
			this.btn_saveequip.Text = "保存装备";
			this.btn_saveequip.UseVisualStyleBackColor = true;
			this.btn_saveequip.Click += new System.EventHandler(this.btn_ModEquipClick);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btn_modlevel);
			this.groupBox1.Controls.Add(this.btn_modexp);
			this.groupBox1.Controls.Add(this.btn_getexp);
			this.groupBox1.Controls.Add(this.cb_level);
			this.groupBox1.Controls.Add(this.tb_curexp);
			this.groupBox1.Controls.Add(this.tb_allexp);
			this.groupBox1.Controls.Add(this.tb_nextexp);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label13);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Location = new System.Drawing.Point(488, 140);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(237, 124);
			this.groupBox1.TabIndex = 7;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "等级/经验";
			// 
			// btn_modlevel
			// 
			this.btn_modlevel.Location = new System.Drawing.Point(162, 19);
			this.btn_modlevel.Name = "btn_modlevel";
			this.btn_modlevel.Size = new System.Drawing.Size(73, 23);
			this.btn_modlevel.TabIndex = 0;
			this.btn_modlevel.Text = "修改等级";
			this.btn_modlevel.UseVisualStyleBackColor = true;
			this.btn_modlevel.Click += new System.EventHandler(this.btn_ModLevelClick);
			// 
			// tb_curexp
			// 
			this.tb_curexp.Location = new System.Drawing.Point(59, 49);
			this.tb_curexp.Name = "tb_curexp";
			this.tb_curexp.Size = new System.Drawing.Size(100, 21);
			this.tb_curexp.TabIndex = 3;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(6, 100);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(41, 12);
			this.label13.TabIndex = 4;
			this.label13.Text = "总经验";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(483, 49);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(11, 12);
			this.label8.TabIndex = 4;
			this.label8.Text = "/";
			// 
			// tb_searchname
			// 
			this.tb_searchname.Location = new System.Drawing.Point(378, 15);
			this.tb_searchname.Name = "tb_searchname";
			this.tb_searchname.Size = new System.Drawing.Size(224, 21);
			this.tb_searchname.TabIndex = 3;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(337, 20);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(41, 12);
			this.label9.TabIndex = 4;
			this.label9.Text = "装备名";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(336, 47);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(29, 12);
			this.label7.TabIndex = 4;
			this.label7.Text = "耐久";
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(620, 13);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(89, 59);
			this.button6.TabIndex = 0;
			this.button6.Text = "搜索装备";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.btn_FindEquipClick);
			// 
			// tb_searchmaxdur
			// 
			this.tb_searchmaxdur.Location = new System.Drawing.Point(502, 44);
			this.tb_searchmaxdur.Name = "tb_searchmaxdur";
			this.tb_searchmaxdur.Size = new System.Drawing.Size(100, 21);
			this.tb_searchmaxdur.TabIndex = 3;
			// 
			// tb_searchcurdur
			// 
			this.tb_searchcurdur.Location = new System.Drawing.Point(378, 44);
			this.tb_searchcurdur.Name = "tb_searchcurdur";
			this.tb_searchcurdur.Size = new System.Drawing.Size(100, 21);
			this.tb_searchcurdur.TabIndex = 3;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.btn_deleffect);
			this.groupBox3.Controls.Add(this.tb_hex);
			this.groupBox3.Controls.Add(this.label8);
			this.groupBox3.Controls.Add(this.lv_effect);
			this.groupBox3.Controls.Add(this.button6);
			this.groupBox3.Controls.Add(this.tb_searchname);
			this.groupBox3.Controls.Add(this.label7);
			this.groupBox3.Controls.Add(this.label9);
			this.groupBox3.Controls.Add(this.cb_effect);
			this.groupBox3.Controls.Add(this.btn_addeffect);
			this.groupBox3.Controls.Add(this.tb_searchmaxdur);
			this.groupBox3.Controls.Add(this.tb_searchcurdur);
			this.groupBox3.Controls.Add(this.tb_equipcode);
			this.groupBox3.Controls.Add(this.label10);
			this.groupBox3.Controls.Add(this.btn_saveequip);
			this.groupBox3.Controls.Add(this.btn_delequip);
			this.groupBox3.Location = new System.Drawing.Point(2, 268);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(719, 235);
			this.groupBox3.TabIndex = 8;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "装备信息";
			// 
			// btn_deleffect
			// 
			this.btn_deleffect.ForeColor = System.Drawing.Color.Maroon;
			this.btn_deleffect.Location = new System.Drawing.Point(243, 201);
			this.btn_deleffect.Name = "btn_deleffect";
			this.btn_deleffect.Size = new System.Drawing.Size(85, 23);
			this.btn_deleffect.TabIndex = 12;
			this.btn_deleffect.Text = "删除效果";
			this.btn_deleffect.UseVisualStyleBackColor = true;
			this.btn_deleffect.Click += new System.EventHandler(this.Btn_deleffectClick);
			// 
			// tb_hex
			// 
			this.tb_hex.AcceptsReturn = true;
			this.tb_hex.AcceptsTab = true;
			this.tb_hex.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tb_hex.Location = new System.Drawing.Point(332, 73);
			this.tb_hex.Multiline = true;
			this.tb_hex.Name = "tb_hex";
			this.tb_hex.ReadOnly = true;
			this.tb_hex.Size = new System.Drawing.Size(381, 126);
			this.tb_hex.TabIndex = 11;
			this.tb_hex.Text = "XX XX XX XX 0B 00 00 00 68 D5 24 00 03";
			// 
			// lv_effect
			// 
			this.lv_effect.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader7,
									this.columnHeader8});
			this.lv_effect.FullRowSelect = true;
			this.lv_effect.GridLines = true;
			this.lv_effect.Location = new System.Drawing.Point(6, 20);
			this.lv_effect.Name = "lv_effect";
			this.lv_effect.ShowItemToolTips = true;
			this.lv_effect.Size = new System.Drawing.Size(322, 153);
			this.lv_effect.TabIndex = 6;
			this.lv_effect.UseCompatibleStateImageBehavior = false;
			this.lv_effect.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "效果ID";
			this.columnHeader7.Width = 64;
			// 
			// columnHeader8
			// 
			this.columnHeader8.Text = "效果描述";
			this.columnHeader8.Width = 233;
			// 
			// cb_effect
			// 
			this.cb_effect.FormattingEnabled = true;
			this.cb_effect.Location = new System.Drawing.Point(6, 175);
			this.cb_effect.Name = "cb_effect";
			this.cb_effect.Size = new System.Drawing.Size(320, 20);
			this.cb_effect.TabIndex = 8;
			// 
			// btn_addeffect
			// 
			this.btn_addeffect.Location = new System.Drawing.Point(6, 201);
			this.btn_addeffect.Name = "btn_addeffect";
			this.btn_addeffect.Size = new System.Drawing.Size(153, 23);
			this.btn_addeffect.TabIndex = 7;
			this.btn_addeffect.Text = "添加效果";
			this.btn_addeffect.UseVisualStyleBackColor = true;
			this.btn_addeffect.Click += new System.EventHandler(this.Btn_AddEffectClick);
			// 
			// tb_equipcode
			// 
			this.tb_equipcode.Location = new System.Drawing.Point(384, 203);
			this.tb_equipcode.Name = "tb_equipcode";
			this.tb_equipcode.Size = new System.Drawing.Size(82, 21);
			this.tb_equipcode.TabIndex = 3;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(337, 208);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(41, 12);
			this.label10.TabIndex = 4;
			this.label10.Text = "装备ID";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(494, 118);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(29, 12);
			this.label2.TabIndex = 4;
			this.label2.Text = "金钱";
			// 
			// tb_money
			// 
			this.tb_money.Location = new System.Drawing.Point(547, 114);
			this.tb_money.Name = "tb_money";
			this.tb_money.Size = new System.Drawing.Size(100, 21);
			this.tb_money.TabIndex = 3;
			// 
			// btn_modmoney
			// 
			this.btn_modmoney.Location = new System.Drawing.Point(652, 113);
			this.btn_modmoney.Name = "btn_modmoney";
			this.btn_modmoney.Size = new System.Drawing.Size(70, 23);
			this.btn_modmoney.TabIndex = 9;
			this.btn_modmoney.Text = "修改金钱";
			this.btn_modmoney.UseVisualStyleBackColor = true;
			this.btn_modmoney.Click += new System.EventHandler(this.Btn_modmoneyClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(734, 503);
			this.Controls.Add(this.btn_modmoney);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.lv_equips);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tb_name);
			this.Controls.Add(this.tb_money);
			this.Controls.Add(this.tb_bagcount);
			this.Controls.Add(this.btn_modname);
			this.Controls.Add(this.btn_modbag);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "KOASaveEditor";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button btn_modmoney;
		private System.Windows.Forms.TextBox tb_money;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ToolStripMenuItem downloadToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem gitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem reloadToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.Button btn_deleffect;
		private System.Windows.Forms.Button btn_modlevel;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox tb_curexp;
		private System.Windows.Forms.TextBox tb_hex;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox tb_equipcode;
		private System.Windows.Forms.Button btn_addeffect;
		private System.Windows.Forms.ComboBox cb_effect;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ListView lv_effect;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox tb_searchname;
		private System.Windows.Forms.TextBox tb_searchcurdur;
		private System.Windows.Forms.TextBox tb_searchmaxdur;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btn_saveequip;
		private System.Windows.Forms.Button btn_delequip;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ListView lv_equips;
		private System.Windows.Forms.Button btn_modexp;
		private System.Windows.Forms.Button btn_modbag;
		private System.Windows.Forms.ComboBox cb_level;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button btn_modname;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tb_name;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btn_getexp;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tb_nextexp;
		private System.Windows.Forms.TextBox tb_allexp;
		private System.Windows.Forms.TextBox tb_bagcount;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpHToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem openThToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openSkToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openOToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fileFToolStripMenuItem;
		private System.Windows.Forms.MenuStrip menuStrip1;
	}
}
