namespace Worms2_IPXAddressBook
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.tblDesign = new Worms2_IPXAddressBook.Main.DBTableLayoutPanel();
            this.btnExit = new System.Windows.Forms.Button();
            this.flwMode = new System.Windows.Forms.FlowLayoutPanel();
            this.rbOnline = new System.Windows.Forms.RadioButton();
            this.rbLAN = new System.Windows.Forms.RadioButton();
            this.tblEdit = new Worms2_IPXAddressBook.Main.DBTableLayoutPanel();
            this.tblEditFields = new Worms2_IPXAddressBook.Main.DBTableLayoutPanel();
            this.gbPort = new System.Windows.Forms.GroupBox();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.gbAddress = new System.Windows.Forms.GroupBox();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.gbName = new System.Windows.Forms.GroupBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.btnSet = new System.Windows.Forms.Button();
            this.tblEditButtons = new Worms2_IPXAddressBook.Main.DBTableLayoutPanel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.gbServers = new System.Windows.Forms.GroupBox();
            this.listServers = new System.Windows.Forms.ListView();
            this.colServer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPort = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEnabled = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.tblDesign.SuspendLayout();
            this.flwMode.SuspendLayout();
            this.tblEdit.SuspendLayout();
            this.tblEditFields.SuspendLayout();
            this.gbPort.SuspendLayout();
            this.gbAddress.SuspendLayout();
            this.gbName.SuspendLayout();
            this.tblEditButtons.SuspendLayout();
            this.gbServers.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblDesign
            // 
            this.tblDesign.AutoSize = true;
            this.tblDesign.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tblDesign.BackgroundImage = global::Worms2_IPXAddressBook.Properties.Resources.background;
            this.tblDesign.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tblDesign.ColumnCount = 1;
            this.tblDesign.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblDesign.Controls.Add(this.btnExit, 0, 1);
            this.tblDesign.Controls.Add(this.flwMode, 0, 0);
            this.tblDesign.Controls.Add(this.tblEdit, 0, 3);
            this.tblDesign.Controls.Add(this.gbServers, 0, 2);
            this.tblDesign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblDesign.Location = new System.Drawing.Point(0, 0);
            this.tblDesign.Name = "tblDesign";
            this.tblDesign.RowCount = 4;
            this.tblDesign.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblDesign.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblDesign.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblDesign.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblDesign.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblDesign.Size = new System.Drawing.Size(930, 559);
            this.tblDesign.TabIndex = 1;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnExit.AutoSize = true;
            this.btnExit.Location = new System.Drawing.Point(430, 48);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(113, 53);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // flwMode
            // 
            this.flwMode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flwMode.AutoSize = true;
            this.flwMode.BackColor = System.Drawing.Color.Transparent;
            this.flwMode.Controls.Add(this.rbOnline);
            this.flwMode.Controls.Add(this.rbLAN);
            this.flwMode.Location = new System.Drawing.Point(272, 3);
            this.flwMode.Name = "flwMode";
            this.flwMode.Size = new System.Drawing.Size(428, 39);
            this.flwMode.TabIndex = 3;
            // 
            // rbOnline
            // 
            this.rbOnline.AutoSize = true;
            this.rbOnline.BackColor = System.Drawing.Color.Transparent;
            this.rbOnline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbOnline.Location = new System.Drawing.Point(3, 3);
            this.rbOnline.Name = "rbOnline";
            this.rbOnline.Size = new System.Drawing.Size(161, 33);
            this.rbOnline.TabIndex = 1;
            this.rbOnline.TabStop = true;
            this.rbOnline.Text = "Play Online";
            this.rbOnline.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbOnline.UseVisualStyleBackColor = false;
            this.rbOnline.CheckedChanged += new System.EventHandler(this.rbOnline_CheckedChanged);
            // 
            // rbLAN
            // 
            this.rbLAN.AutoSize = true;
            this.rbLAN.BackColor = System.Drawing.Color.Transparent;
            this.rbLAN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbLAN.Location = new System.Drawing.Point(170, 3);
            this.rbLAN.Name = "rbLAN";
            this.rbLAN.Size = new System.Drawing.Size(255, 33);
            this.rbLAN.TabIndex = 0;
            this.rbLAN.TabStop = true;
            this.rbLAN.Text = "Play via LAN or VPN";
            this.rbLAN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbLAN.UseVisualStyleBackColor = false;
            this.rbLAN.CheckedChanged += new System.EventHandler(this.rbLAN_CheckedChanged);
            // 
            // tblEdit
            // 
            this.tblEdit.BackColor = System.Drawing.Color.Transparent;
            this.tblEdit.ColumnCount = 2;
            this.tblEdit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblEdit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblEdit.Controls.Add(this.tblEditFields, 0, 0);
            this.tblEdit.Controls.Add(this.tblEditButtons, 1, 0);
            this.tblEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblEdit.Location = new System.Drawing.Point(3, 382);
            this.tblEdit.Name = "tblEdit";
            this.tblEdit.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.tblEdit.RowCount = 2;
            this.tblEdit.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblEdit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tblEdit.Size = new System.Drawing.Size(967, 183);
            this.tblEdit.TabIndex = 4;
            // 
            // tblEditFields
            // 
            this.tblEditFields.AutoSize = true;
            this.tblEditFields.ColumnCount = 2;
            this.tblEditFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblEditFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblEditFields.Controls.Add(this.gbPort, 0, 1);
            this.tblEditFields.Controls.Add(this.gbAddress, 1, 0);
            this.tblEditFields.Controls.Add(this.gbName, 0, 0);
            this.tblEditFields.Controls.Add(this.btnSet, 1, 1);
            this.tblEditFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblEditFields.Location = new System.Drawing.Point(9, 3);
            this.tblEditFields.Name = "tblEditFields";
            this.tblEditFields.RowCount = 3;
            this.tblEditFields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblEditFields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblEditFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tblEditFields.Size = new System.Drawing.Size(688, 178);
            this.tblEditFields.TabIndex = 4;
            // 
            // gbPort
            // 
            this.gbPort.Controls.Add(this.tbPort);
            this.gbPort.Location = new System.Drawing.Point(3, 88);
            this.gbPort.Name = "gbPort";
            this.gbPort.Padding = new System.Windows.Forms.Padding(9);
            this.gbPort.Size = new System.Drawing.Size(338, 79);
            this.gbPort.TabIndex = 6;
            this.gbPort.TabStop = false;
            this.gbPort.Text = "Port number";
            // 
            // tbPort
            // 
            this.tbPort.Enabled = false;
            this.tbPort.Location = new System.Drawing.Point(9, 36);
            this.tbPort.MaxLength = 5;
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(320, 34);
            this.tbPort.TabIndex = 0;
            this.tbPort.TextChanged += new System.EventHandler(this.tb_TextChanged);
            // 
            // gbAddress
            // 
            this.gbAddress.Controls.Add(this.tbAddress);
            this.gbAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbAddress.Location = new System.Drawing.Point(347, 3);
            this.gbAddress.Name = "gbAddress";
            this.gbAddress.Padding = new System.Windows.Forms.Padding(9);
            this.gbAddress.Size = new System.Drawing.Size(338, 79);
            this.gbAddress.TabIndex = 5;
            this.gbAddress.TabStop = false;
            this.gbAddress.Text = "Address";
            // 
            // tbAddress
            // 
            this.tbAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbAddress.Enabled = false;
            this.tbAddress.Location = new System.Drawing.Point(9, 36);
            this.tbAddress.MaxLength = 253;
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(320, 34);
            this.tbAddress.TabIndex = 0;
            this.tbAddress.TextChanged += new System.EventHandler(this.tb_TextChanged);
            // 
            // gbName
            // 
            this.gbName.Controls.Add(this.tbName);
            this.gbName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbName.Location = new System.Drawing.Point(3, 3);
            this.gbName.Name = "gbName";
            this.gbName.Padding = new System.Windows.Forms.Padding(9);
            this.gbName.Size = new System.Drawing.Size(338, 79);
            this.gbName.TabIndex = 4;
            this.gbName.TabStop = false;
            this.gbName.Text = "Name";
            // 
            // tbName
            // 
            this.tbName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbName.Enabled = false;
            this.tbName.Location = new System.Drawing.Point(9, 36);
            this.tbName.MaxLength = 100;
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(320, 34);
            this.tbName.TabIndex = 0;
            this.tbName.TextChanged += new System.EventHandler(this.tb_TextChanged);
            // 
            // btnSet
            // 
            this.btnSet.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSet.AutoSize = true;
            this.btnSet.BackColor = System.Drawing.SystemColors.Control;
            this.btnSet.Enabled = false;
            this.btnSet.Location = new System.Drawing.Point(421, 122);
            this.btnSet.Margin = new System.Windows.Forms.Padding(3, 3, 3, 9);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(190, 39);
            this.btnSet.TabIndex = 1;
            this.btnSet.Text = "Select Server";
            this.btnSet.UseVisualStyleBackColor = false;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // tblEditButtons
            // 
            this.tblEditButtons.AutoSize = true;
            this.tblEditButtons.ColumnCount = 3;
            this.tblEditButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblEditButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblEditButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tblEditButtons.Controls.Add(this.btnDelete, 1, 1);
            this.tblEditButtons.Controls.Add(this.btnCancel, 1, 0);
            this.tblEditButtons.Controls.Add(this.btnNew, 0, 0);
            this.tblEditButtons.Controls.Add(this.btnOK, 0, 2);
            this.tblEditButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblEditButtons.Location = new System.Drawing.Point(703, 3);
            this.tblEditButtons.Name = "tblEditButtons";
            this.tblEditButtons.RowCount = 4;
            this.tblEditButtons.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblEditButtons.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblEditButtons.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblEditButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tblEditButtons.Size = new System.Drawing.Size(255, 178);
            this.tblEditButtons.TabIndex = 5;
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSize = true;
            this.btnDelete.BackColor = System.Drawing.SystemColors.Control;
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(122, 62);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(113, 53);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.Location = new System.Drawing.Point(122, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(113, 53);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Exit";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnNew
            // 
            this.btnNew.AutoSize = true;
            this.btnNew.BackColor = System.Drawing.SystemColors.Control;
            this.btnNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNew.Location = new System.Drawing.Point(3, 3);
            this.btnNew.Name = "btnNew";
            this.tblEditButtons.SetRowSpan(this.btnNew, 2);
            this.btnNew.Size = new System.Drawing.Size(113, 112);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.SystemColors.Control;
            this.tblEditButtons.SetColumnSpan(this.btnOK, 2);
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(3, 121);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(232, 53);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // gbServers
            // 
            this.gbServers.BackColor = System.Drawing.Color.Transparent;
            this.gbServers.Controls.Add(this.listServers);
            this.gbServers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbServers.Location = new System.Drawing.Point(12, 107);
            this.gbServers.Margin = new System.Windows.Forms.Padding(12, 3, 12, 3);
            this.gbServers.Name = "gbServers";
            this.gbServers.Padding = new System.Windows.Forms.Padding(9);
            this.gbServers.Size = new System.Drawing.Size(949, 269);
            this.gbServers.TabIndex = 7;
            this.gbServers.TabStop = false;
            this.gbServers.Text = "Server List";
            // 
            // listServers
            // 
            this.listServers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colServer,
            this.colAddress,
            this.colPort,
            this.colEnabled});
            this.listServers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listServers.HideSelection = false;
            this.listServers.Location = new System.Drawing.Point(9, 36);
            this.listServers.MultiSelect = false;
            this.listServers.Name = "listServers";
            this.listServers.Size = new System.Drawing.Size(931, 224);
            this.listServers.SmallImageList = this.imgList;
            this.listServers.TabIndex = 2;
            this.listServers.UseCompatibleStateImageBehavior = false;
            this.listServers.View = System.Windows.Forms.View.Details;
            this.listServers.SelectedIndexChanged += new System.EventHandler(this.listServers_SelectedIndexChanged);
            // 
            // colServer
            // 
            this.colServer.Text = "Server";
            this.colServer.Width = 342;
            // 
            // colAddress
            // 
            this.colAddress.Text = "Address";
            this.colAddress.Width = 342;
            // 
            // colPort
            // 
            this.colPort.Text = "Port";
            this.colPort.Width = 75;
            // 
            // colEnabled
            // 
            this.colEnabled.Text = "";
            this.colEnabled.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colEnabled.Width = 140;
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "icon-server");
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(930, 559);
            this.Controls.Add(this.tblDesign);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(750, 100);
            this.Name = "Main";
            this.ShowIcon = false;
            this.Text = "Address book";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.tblDesign.ResumeLayout(false);
            this.tblDesign.PerformLayout();
            this.flwMode.ResumeLayout(false);
            this.flwMode.PerformLayout();
            this.tblEdit.ResumeLayout(false);
            this.tblEdit.PerformLayout();
            this.tblEditFields.ResumeLayout(false);
            this.tblEditFields.PerformLayout();
            this.gbPort.ResumeLayout(false);
            this.gbPort.PerformLayout();
            this.gbAddress.ResumeLayout(false);
            this.gbAddress.PerformLayout();
            this.gbName.ResumeLayout(false);
            this.gbName.PerformLayout();
            this.tblEditButtons.ResumeLayout(false);
            this.tblEditButtons.PerformLayout();
            this.gbServers.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox gbServers;
        private System.Windows.Forms.ListView listServers;
        private System.Windows.Forms.ColumnHeader colServer;
        private System.Windows.Forms.ColumnHeader colAddress;
        private System.Windows.Forms.ColumnHeader colPort;
        private System.Windows.Forms.ColumnHeader colEnabled;
        private System.Windows.Forms.FlowLayoutPanel flwMode;
        private System.Windows.Forms.RadioButton rbOnline;
        private System.Windows.Forms.RadioButton rbLAN;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.GroupBox gbPort;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.GroupBox gbAddress;
        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.GroupBox gbName;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ImageList imgList;
        private DBTableLayoutPanel tblDesign;
        private DBTableLayoutPanel tblEdit;
        private DBTableLayoutPanel tblEditFields;
        private DBTableLayoutPanel tblEditButtons;
    }
}

