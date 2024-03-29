﻿namespace TvForms
{
    partial class UcFavoirute
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
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcFavoirute));
            this.scContainerFav = new System.Windows.Forms.SplitContainer();
            this.lvFavouriteProgs = new System.Windows.Forms.ListView();
            this.Number = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ChannelName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Adult = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Programm = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cbHidePaid = new System.Windows.Forms.CheckBox();
            this.btReload = new System.Windows.Forms.Button();
            this.btMakeOrder = new System.Windows.Forms.Button();
            this.lbUAH_balance = new System.Windows.Forms.Label();
            this.tbAccountBalance = new System.Windows.Forms.TextBox();
            this.lbAccountBalance = new System.Windows.Forms.Label();
            this.lbUAH = new System.Windows.Forms.Label();
            this.tbTotalPrice = new System.Windows.Forms.TextBox();
            this.lbTotalPrice = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.scContainerFav)).BeginInit();
            this.scContainerFav.Panel1.SuspendLayout();
            this.scContainerFav.Panel2.SuspendLayout();
            this.scContainerFav.SuspendLayout();
            this.SuspendLayout();
            // 
            // scContainerFav
            // 
            this.scContainerFav.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scContainerFav.Location = new System.Drawing.Point(0, 0);
            this.scContainerFav.Name = "scContainerFav";
            // 
            // scContainerFav.Panel1
            // 
            this.scContainerFav.Panel1.Controls.Add(this.lvFavouriteProgs);
            // 
            // scContainerFav.Panel2
            // 
            this.scContainerFav.Panel2.Controls.Add(this.cbHidePaid);
            this.scContainerFav.Panel2.Controls.Add(this.btReload);
            this.scContainerFav.Panel2.Controls.Add(this.btMakeOrder);
            this.scContainerFav.Panel2.Controls.Add(this.lbUAH_balance);
            this.scContainerFav.Panel2.Controls.Add(this.tbAccountBalance);
            this.scContainerFav.Panel2.Controls.Add(this.lbAccountBalance);
            this.scContainerFav.Panel2.Controls.Add(this.lbUAH);
            this.scContainerFav.Panel2.Controls.Add(this.tbTotalPrice);
            this.scContainerFav.Panel2.Controls.Add(this.lbTotalPrice);
            this.scContainerFav.Size = new System.Drawing.Size(776, 411);
            this.scContainerFav.SplitterDistance = 591;
            this.scContainerFav.TabIndex = 0;
            // 
            // lvFavouriteProgs
            // 
            this.lvFavouriteProgs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Number,
            this.ChannelName,
            this.Adult,
            this.Price,
            this.Date,
            this.Time,
            this.Programm});
            this.lvFavouriteProgs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvFavouriteProgs.FullRowSelect = true;
            this.lvFavouriteProgs.GridLines = true;
            this.lvFavouriteProgs.Location = new System.Drawing.Point(0, 0);
            this.lvFavouriteProgs.Name = "lvFavouriteProgs";
            this.lvFavouriteProgs.ShowItemToolTips = true;
            this.lvFavouriteProgs.Size = new System.Drawing.Size(591, 411);
            this.lvFavouriteProgs.TabIndex = 1;
            this.lvFavouriteProgs.UseCompatibleStateImageBehavior = false;
            this.lvFavouriteProgs.View = System.Windows.Forms.View.Details;
            // 
            // Number
            // 
            this.Number.Text = "№";
            this.Number.Width = 45;
            // 
            // ChannelName
            // 
            this.ChannelName.Text = "Channel";
            this.ChannelName.Width = 123;
            // 
            // Adult
            // 
            this.Adult.Text = "Adult";
            this.Adult.Width = 38;
            // 
            // Price
            // 
            this.Price.Text = "Price";
            this.Price.Width = 51;
            // 
            // Date
            // 
            this.Date.Text = "Date";
            this.Date.Width = 53;
            // 
            // Time
            // 
            this.Time.Text = "Time";
            this.Time.Width = 53;
            // 
            // Programm
            // 
            this.Programm.Text = "Programm";
            this.Programm.Width = 218;
            // 
            // cbHidePaid
            // 
            this.cbHidePaid.AutoSize = true;
            this.cbHidePaid.Location = new System.Drawing.Point(18, 129);
            this.cbHidePaid.Name = "cbHidePaid";
            this.cbHidePaid.Size = new System.Drawing.Size(102, 17);
            this.cbHidePaid.TabIndex = 13;
            this.cbHidePaid.Text = "Hide paid media";
            this.cbHidePaid.UseVisualStyleBackColor = true;
            this.cbHidePaid.CheckedChanged += new System.EventHandler(this.cbHidePaid_CheckedChanged);
            // 
            // btReload
            // 
            this.btReload.BackColor = System.Drawing.Color.DarkOrange;
            this.btReload.ForeColor = System.Drawing.Color.DarkBlue;
            this.btReload.Image = ((System.Drawing.Image)(resources.GetObject("btReload.Image")));
            this.btReload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btReload.Location = new System.Drawing.Point(18, 161);
            this.btReload.Name = "btReload";
            this.btReload.Size = new System.Drawing.Size(70, 29);
            this.btReload.TabIndex = 12;
            this.btReload.Text = "Reload";
            this.btReload.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btReload.UseVisualStyleBackColor = false;
            this.btReload.Visible = false;
            this.btReload.Click += new System.EventHandler(this.btReload_Click);
            // 
            // btMakeOrder
            // 
            this.btMakeOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btMakeOrder.Location = new System.Drawing.Point(18, 371);
            this.btMakeOrder.Name = "btMakeOrder";
            this.btMakeOrder.Size = new System.Drawing.Size(135, 23);
            this.btMakeOrder.TabIndex = 6;
            this.btMakeOrder.Text = "Make order";
            this.btMakeOrder.UseVisualStyleBackColor = false;
            this.btMakeOrder.Click += new System.EventHandler(this.btMakeOrder_Click);
            // 
            // lbUAH_balance
            // 
            this.lbUAH_balance.AutoSize = true;
            this.lbUAH_balance.Location = new System.Drawing.Point(111, 88);
            this.lbUAH_balance.Name = "lbUAH_balance";
            this.lbUAH_balance.Size = new System.Drawing.Size(30, 13);
            this.lbUAH_balance.TabIndex = 5;
            this.lbUAH_balance.Text = "UAH";
            // 
            // tbAccountBalance
            // 
            this.tbAccountBalance.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.tbAccountBalance.Location = new System.Drawing.Point(18, 85);
            this.tbAccountBalance.Name = "tbAccountBalance";
            this.tbAccountBalance.Size = new System.Drawing.Size(85, 20);
            this.tbAccountBalance.TabIndex = 4;
            this.tbAccountBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbAccountBalance
            // 
            this.lbAccountBalance.AutoSize = true;
            this.lbAccountBalance.Location = new System.Drawing.Point(15, 69);
            this.lbAccountBalance.Name = "lbAccountBalance";
            this.lbAccountBalance.Size = new System.Drawing.Size(88, 13);
            this.lbAccountBalance.TabIndex = 3;
            this.lbAccountBalance.Text = "Account balance";
            // 
            // lbUAH
            // 
            this.lbUAH.AutoSize = true;
            this.lbUAH.Location = new System.Drawing.Point(111, 42);
            this.lbUAH.Name = "lbUAH";
            this.lbUAH.Size = new System.Drawing.Size(30, 13);
            this.lbUAH.TabIndex = 2;
            this.lbUAH.Text = "UAH";
            // 
            // tbTotalPrice
            // 
            this.tbTotalPrice.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.tbTotalPrice.Location = new System.Drawing.Point(18, 39);
            this.tbTotalPrice.Name = "tbTotalPrice";
            this.tbTotalPrice.Size = new System.Drawing.Size(85, 20);
            this.tbTotalPrice.TabIndex = 1;
            this.tbTotalPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbTotalPrice
            // 
            this.lbTotalPrice.AutoSize = true;
            this.lbTotalPrice.Location = new System.Drawing.Point(15, 23);
            this.lbTotalPrice.Name = "lbTotalPrice";
            this.lbTotalPrice.Size = new System.Drawing.Size(57, 13);
            this.lbTotalPrice.TabIndex = 0;
            this.lbTotalPrice.Text = "Total price";
            // 
            // UcFavoirute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scContainerFav);
            this.Name = "UcFavoirute";
            this.Size = new System.Drawing.Size(776, 411);
            this.scContainerFav.Panel1.ResumeLayout(false);
            this.scContainerFav.Panel2.ResumeLayout(false);
            this.scContainerFav.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scContainerFav)).EndInit();
            this.scContainerFav.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer scContainerFav;
        private System.Windows.Forms.Label lbTotalPrice;
        private System.Windows.Forms.Button btMakeOrder;
        private System.Windows.Forms.Label lbUAH_balance;
        private System.Windows.Forms.TextBox tbAccountBalance;
        private System.Windows.Forms.Label lbAccountBalance;
        private System.Windows.Forms.Label lbUAH;
        private System.Windows.Forms.TextBox tbTotalPrice;
        private System.Windows.Forms.Button btReload;
        private System.Windows.Forms.CheckBox cbHidePaid;
        private System.Windows.Forms.ListView lvFavouriteProgs;
        private System.Windows.Forms.ColumnHeader Number;
        private System.Windows.Forms.ColumnHeader ChannelName;
        private System.Windows.Forms.ColumnHeader Adult;
        private System.Windows.Forms.ColumnHeader Price;
        private System.Windows.Forms.ColumnHeader Date;
        private System.Windows.Forms.ColumnHeader Time;
        private System.Windows.Forms.ColumnHeader Programm;
    }
}
