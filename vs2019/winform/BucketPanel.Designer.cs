

namespace OGM.Module.File
{
    partial class BucketPanel
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tcPages = new System.Windows.Forms.TabControl();
            this.tcPages.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcPages
            // 
            this.tcPages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcPages.Location = new System.Drawing.Point(10, 10);
            this.tcPages.Multiline = true;
            this.tcPages.Name = "tcPages";
            this.tcPages.SelectedIndex = 0;
            this.tcPages.Size = new System.Drawing.Size(720, 620);
            this.tcPages.TabIndex = 0;


            //
            // tabPageMake
            //
            this.tabPageMake = new System.Windows.Forms.TabPage();
            this.tabPageMake.Location = new System.Drawing.Point(4, 48);
            this.tabPageMake.Name = "Make";
            this.tabPageMake.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMake.Size = new System.Drawing.Size(459, 373);
            this.tabPageMake.TabIndex = 0;
            this.tabPageMake.Text = "Make";
            this.tabPageMake.UseVisualStyleBackColor = true;
            this.tcPages.Controls.Add(tabPageMake);
    
            //
            // tabPageList
            //
            this.tabPageList = new System.Windows.Forms.TabPage();
            this.tabPageList.Location = new System.Drawing.Point(4, 48);
            this.tabPageList.Name = "List";
            this.tabPageList.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageList.Size = new System.Drawing.Size(459, 373);
            this.tabPageList.TabIndex = 0;
            this.tabPageList.Text = "List";
            this.tabPageList.UseVisualStyleBackColor = true;
            this.tcPages.Controls.Add(tabPageList);
    
            //
            // tabPageRemove
            //
            this.tabPageRemove = new System.Windows.Forms.TabPage();
            this.tabPageRemove.Location = new System.Drawing.Point(4, 48);
            this.tabPageRemove.Name = "Remove";
            this.tabPageRemove.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRemove.Size = new System.Drawing.Size(459, 373);
            this.tabPageRemove.TabIndex = 0;
            this.tabPageRemove.Text = "Remove";
            this.tabPageRemove.UseVisualStyleBackColor = true;
            this.tcPages.Controls.Add(tabPageRemove);
    
            //
            // tabPageGet
            //
            this.tabPageGet = new System.Windows.Forms.TabPage();
            this.tabPageGet.Location = new System.Drawing.Point(4, 48);
            this.tabPageGet.Name = "Get";
            this.tabPageGet.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGet.Size = new System.Drawing.Size(459, 373);
            this.tabPageGet.TabIndex = 0;
            this.tabPageGet.Text = "Get";
            this.tabPageGet.UseVisualStyleBackColor = true;
            this.tcPages.Controls.Add(tabPageGet);
    
            //
            // tabPageFind
            //
            this.tabPageFind = new System.Windows.Forms.TabPage();
            this.tabPageFind.Location = new System.Drawing.Point(4, 48);
            this.tabPageFind.Name = "Find";
            this.tabPageFind.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFind.Size = new System.Drawing.Size(459, 373);
            this.tabPageFind.TabIndex = 0;
            this.tabPageFind.Text = "Find";
            this.tabPageFind.UseVisualStyleBackColor = true;
            this.tcPages.Controls.Add(tabPageFind);
    
            //
            // tabPageUpdateEngine
            //
            this.tabPageUpdateEngine = new System.Windows.Forms.TabPage();
            this.tabPageUpdateEngine.Location = new System.Drawing.Point(4, 48);
            this.tabPageUpdateEngine.Name = "UpdateEngine";
            this.tabPageUpdateEngine.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUpdateEngine.Size = new System.Drawing.Size(459, 373);
            this.tabPageUpdateEngine.TabIndex = 0;
            this.tabPageUpdateEngine.Text = "UpdateEngine";
            this.tabPageUpdateEngine.UseVisualStyleBackColor = true;
            this.tcPages.Controls.Add(tabPageUpdateEngine);
    
            //
            // tabPageUpdateCapacity
            //
            this.tabPageUpdateCapacity = new System.Windows.Forms.TabPage();
            this.tabPageUpdateCapacity.Location = new System.Drawing.Point(4, 48);
            this.tabPageUpdateCapacity.Name = "UpdateCapacity";
            this.tabPageUpdateCapacity.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUpdateCapacity.Size = new System.Drawing.Size(459, 373);
            this.tabPageUpdateCapacity.TabIndex = 0;
            this.tabPageUpdateCapacity.Text = "UpdateCapacity";
            this.tabPageUpdateCapacity.UseVisualStyleBackColor = true;
            this.tcPages.Controls.Add(tabPageUpdateCapacity);
    
            //
            // tabPageResetToken
            //
            this.tabPageResetToken = new System.Windows.Forms.TabPage();
            this.tabPageResetToken.Location = new System.Drawing.Point(4, 48);
            this.tabPageResetToken.Name = "ResetToken";
            this.tabPageResetToken.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageResetToken.Size = new System.Drawing.Size(459, 373);
            this.tabPageResetToken.TabIndex = 0;
            this.tabPageResetToken.Text = "ResetToken";
            this.tabPageResetToken.UseVisualStyleBackColor = true;
            this.tcPages.Controls.Add(tabPageResetToken);
    

            // 
            // BucketPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tcPages);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "{{Service}}Panel";
            this.Size = new System.Drawing.Size(740, 640);
            this.tcPages.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tcPages;

        private System.Windows.Forms.TabPage tabPageMake;
    
        private System.Windows.Forms.TabPage tabPageList;
    
        private System.Windows.Forms.TabPage tabPageRemove;
    
        private System.Windows.Forms.TabPage tabPageGet;
    
        private System.Windows.Forms.TabPage tabPageFind;
    
        private System.Windows.Forms.TabPage tabPageUpdateEngine;
    
        private System.Windows.Forms.TabPage tabPageUpdateCapacity;
    
        private System.Windows.Forms.TabPage tabPageResetToken;
    
    }
}
