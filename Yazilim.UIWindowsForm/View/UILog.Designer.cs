﻿namespace Yazilim.UIWindowsForm.View
{
    partial class UILog
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LogMasterLst = new System.Windows.Forms.DataGridView();
            this.LogDetailLst = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogMasterLst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogDetailLst)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LogMasterLst);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1462, 281);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.LogDetailLst);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 281);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1462, 644);
            this.panel2.TabIndex = 1;
            // 
            // LogMasterLst
            // 
            this.LogMasterLst.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LogMasterLst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogMasterLst.Location = new System.Drawing.Point(0, 0);
            this.LogMasterLst.Name = "LogMasterLst";
            this.LogMasterLst.Size = new System.Drawing.Size(1462, 281);
            this.LogMasterLst.TabIndex = 0;
            // 
            // LogDetailLst
            // 
            this.LogDetailLst.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LogDetailLst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogDetailLst.Location = new System.Drawing.Point(0, 0);
            this.LogDetailLst.Name = "LogDetailLst";
            this.LogDetailLst.Size = new System.Drawing.Size(1462, 644);
            this.LogDetailLst.TabIndex = 1;
            // 
            // UILog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1462, 925);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "UILog";
            this.Text = "UILog";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LogMasterLst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogDetailLst)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView LogMasterLst;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView LogDetailLst;
    }
}