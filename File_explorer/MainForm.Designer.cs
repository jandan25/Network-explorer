namespace File_explorer
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Сеть");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.network_tv = new System.Windows.Forms.TreeView();
            this.icons_iL = new System.Windows.Forms.ImageList(this.components);
            this.ip_l = new System.Windows.Forms.Label();
            this.pc_l = new System.Windows.Forms.Label();
            this.scan_btn = new System.Windows.Forms.Button();
            this.files_lv = new System.Windows.Forms.ListView();
            this.icons_files_iL = new System.Windows.Forms.ImageList(this.components);
            this.path_tB = new System.Windows.Forms.TextBox();
            this.path_l = new System.Windows.Forms.Label();
            this.find_btn = new System.Windows.Forms.Button();
            this.cat_cb = new System.Windows.Forms.CheckBox();
            this.recur_cb = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // network_tv
            // 
            this.network_tv.ImageIndex = 1;
            this.network_tv.ImageList = this.icons_iL;
            this.network_tv.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.network_tv.Location = new System.Drawing.Point(15, 97);
            this.network_tv.Name = "network_tv";
            treeNode1.ImageIndex = 5;
            treeNode1.Name = "network_root";
            treeNode1.Text = "Сеть";
            this.network_tv.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.network_tv.SelectedImageIndex = 4;
            this.network_tv.Size = new System.Drawing.Size(292, 324);
            this.network_tv.TabIndex = 1;
            this.network_tv.DoubleClick += new System.EventHandler(this.network_tv_DoubleClick);
            // 
            // icons_iL
            // 
            this.icons_iL.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("icons_iL.ImageStream")));
            this.icons_iL.TransparentColor = System.Drawing.Color.Transparent;
            this.icons_iL.Images.SetKeyName(0, "1 (13).ico");
            this.icons_iL.Images.SetKeyName(1, "1 (24).ico");
            this.icons_iL.Images.SetKeyName(2, "1 (47).ico");
            this.icons_iL.Images.SetKeyName(3, "1 (180).ico");
            this.icons_iL.Images.SetKeyName(4, "1 (72).ico");
            this.icons_iL.Images.SetKeyName(5, "1 (14).ico");
            this.icons_iL.Images.SetKeyName(6, "1 (74).ico");
            // 
            // ip_l
            // 
            this.ip_l.AutoSize = true;
            this.ip_l.Location = new System.Drawing.Point(12, 9);
            this.ip_l.Name = "ip_l";
            this.ip_l.Size = new System.Drawing.Size(35, 13);
            this.ip_l.TabIndex = 2;
            this.ip_l.Text = "label1";
            this.ip_l.Visible = false;
            // 
            // pc_l
            // 
            this.pc_l.AutoSize = true;
            this.pc_l.Location = new System.Drawing.Point(12, 33);
            this.pc_l.Name = "pc_l";
            this.pc_l.Size = new System.Drawing.Size(35, 13);
            this.pc_l.TabIndex = 3;
            this.pc_l.Text = "label2";
            this.pc_l.Visible = false;
            // 
            // scan_btn
            // 
            this.scan_btn.Location = new System.Drawing.Point(53, 427);
            this.scan_btn.Name = "scan_btn";
            this.scan_btn.Size = new System.Drawing.Size(254, 23);
            this.scan_btn.TabIndex = 4;
            this.scan_btn.Text = "Сканировать";
            this.scan_btn.UseVisualStyleBackColor = true;
            this.scan_btn.Click += new System.EventHandler(this.scan_btn_Click);
            // 
            // files_lv
            // 
            this.files_lv.LargeImageList = this.icons_files_iL;
            this.files_lv.Location = new System.Drawing.Point(313, 97);
            this.files_lv.MultiSelect = false;
            this.files_lv.Name = "files_lv";
            this.files_lv.Size = new System.Drawing.Size(477, 353);
            this.files_lv.TabIndex = 5;
            this.files_lv.UseCompatibleStateImageBehavior = false;
            this.files_lv.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.files_lv_MouseDoubleClick);
            // 
            // icons_files_iL
            // 
            this.icons_files_iL.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.icons_files_iL.ImageSize = new System.Drawing.Size(32, 32);
            this.icons_files_iL.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // path_tB
            // 
            this.path_tB.Location = new System.Drawing.Point(59, 52);
            this.path_tB.Name = "path_tB";
            this.path_tB.ReadOnly = true;
            this.path_tB.Size = new System.Drawing.Size(731, 20);
            this.path_tB.TabIndex = 6;
            // 
            // path_l
            // 
            this.path_l.AutoSize = true;
            this.path_l.Location = new System.Drawing.Point(12, 55);
            this.path_l.Name = "path_l";
            this.path_l.Size = new System.Drawing.Size(37, 13);
            this.path_l.TabIndex = 8;
            this.path_l.Text = "Путь: ";
            // 
            // find_btn
            // 
            this.find_btn.ImageIndex = 6;
            this.find_btn.ImageList = this.icons_iL;
            this.find_btn.Location = new System.Drawing.Point(15, 427);
            this.find_btn.Name = "find_btn";
            this.find_btn.Size = new System.Drawing.Size(32, 23);
            this.find_btn.TabIndex = 9;
            this.find_btn.UseVisualStyleBackColor = true;
            this.find_btn.Click += new System.EventHandler(this.find_btn_Click);
            // 
            // cat_cb
            // 
            this.cat_cb.AutoSize = true;
            this.cat_cb.Checked = true;
            this.cat_cb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cat_cb.Location = new System.Drawing.Point(406, 8);
            this.cat_cb.Name = "cat_cb";
            this.cat_cb.Size = new System.Drawing.Size(240, 17);
            this.cat_cb.TabIndex = 10;
            this.cat_cb.Text = "Отображать каталоги в сетевых ресурсах";
            this.cat_cb.UseVisualStyleBackColor = true;
            // 
            // recur_cb
            // 
            this.recur_cb.AutoSize = true;
            this.recur_cb.Location = new System.Drawing.Point(406, 32);
            this.recur_cb.Name = "recur_cb";
            this.recur_cb.Size = new System.Drawing.Size(184, 17);
            this.recur_cb.TabIndex = 11;
            this.recur_cb.Text = "Рекурсивный вывод каталогов";
            this.recur_cb.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Сетевое окружение:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(313, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Сетевые ресурсы:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 456);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.recur_cb);
            this.Controls.Add(this.cat_cb);
            this.Controls.Add(this.find_btn);
            this.Controls.Add(this.path_l);
            this.Controls.Add(this.path_tB);
            this.Controls.Add(this.files_lv);
            this.Controls.Add(this.scan_btn);
            this.Controls.Add(this.pc_l);
            this.Controls.Add(this.ip_l);
            this.Controls.Add(this.network_tv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Сетевые ресурсы";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TreeView network_tv;
        private System.Windows.Forms.Label ip_l;
        private System.Windows.Forms.Label pc_l;
        private System.Windows.Forms.Button scan_btn;
        public System.Windows.Forms.ImageList icons_iL;
        private System.Windows.Forms.ListView files_lv;
        private System.Windows.Forms.ImageList icons_files_iL;
        private System.Windows.Forms.TextBox path_tB;
        private System.Windows.Forms.Label path_l;
        private System.Windows.Forms.Button find_btn;
        private System.Windows.Forms.CheckBox cat_cb;
        private System.Windows.Forms.CheckBox recur_cb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

