﻿namespace WinFormThread
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSync = new DevExpress.XtraEditors.SimpleButton();
            this.btnAsyn = new DevExpress.XtraEditors.SimpleButton();
            this.btnThreadPool = new DevExpress.XtraEditors.SimpleButton();
            this.btnThread = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton5 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton6 = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // btnSync
            // 
            this.btnSync.Location = new System.Drawing.Point(42, 40);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(100, 40);
            this.btnSync.TabIndex = 0;
            this.btnSync.Text = "同步方法调用 ";
            // 
            // btnAsyn
            // 
            this.btnAsyn.Location = new System.Drawing.Point(42, 112);
            this.btnAsyn.Name = "btnAsyn";
            this.btnAsyn.Size = new System.Drawing.Size(100, 40);
            this.btnAsyn.TabIndex = 0;
            this.btnAsyn.Text = "异步方法调用";
            // 
            // btnThreadPool
            // 
            this.btnThreadPool.Location = new System.Drawing.Point(42, 252);
            this.btnThreadPool.Name = "btnThreadPool";
            this.btnThreadPool.Size = new System.Drawing.Size(100, 40);
            this.btnThreadPool.TabIndex = 1;
            this.btnThreadPool.Text = "Thread线程池";
            // 
            // btnThread
            // 
            this.btnThread.Location = new System.Drawing.Point(42, 180);
            this.btnThread.Name = "btnThread";
            this.btnThread.Size = new System.Drawing.Size(100, 40);
            this.btnThread.TabIndex = 2;
            this.btnThread.Text = "Thread线程";
            // 
            // simpleButton5
            // 
            this.simpleButton5.Location = new System.Drawing.Point(267, 40);
            this.simpleButton5.Name = "simpleButton5";
            this.simpleButton5.Size = new System.Drawing.Size(100, 40);
            this.simpleButton5.TabIndex = 0;
            this.simpleButton5.Text = "simpleButton1";
            // 
            // simpleButton6
            // 
            this.simpleButton6.Location = new System.Drawing.Point(267, 112);
            this.simpleButton6.Name = "simpleButton6";
            this.simpleButton6.Size = new System.Drawing.Size(100, 40);
            this.simpleButton6.TabIndex = 0;
            this.simpleButton6.Text = "simpleButton1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 338);
            this.Controls.Add(this.btnThreadPool);
            this.Controls.Add(this.btnThread);
            this.Controls.Add(this.simpleButton6);
            this.Controls.Add(this.btnAsyn);
            this.Controls.Add(this.simpleButton5);
            this.Controls.Add(this.btnSync);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnSync;
        private DevExpress.XtraEditors.SimpleButton btnAsyn;
        private DevExpress.XtraEditors.SimpleButton btnThreadPool;
        private DevExpress.XtraEditors.SimpleButton btnThread;
        private DevExpress.XtraEditors.SimpleButton simpleButton5;
        private DevExpress.XtraEditors.SimpleButton simpleButton6;
    }
}

