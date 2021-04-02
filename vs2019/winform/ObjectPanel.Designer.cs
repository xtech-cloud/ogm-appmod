

namespace OGM.Module.File
{
    partial class ObjectPanel
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
            // tabPagePrepare
            //
            this.tabPagePrepare = new System.Windows.Forms.TabPage();
            this.tabPagePrepare.Location = new System.Drawing.Point(4, 48);
            this.tabPagePrepare.Name = "Prepare";
            this.tabPagePrepare.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePrepare.Size = new System.Drawing.Size(459, 373);
            this.tabPagePrepare.TabIndex = 0;
            this.tabPagePrepare.Text = "Prepare";
            this.tabPagePrepare.UseVisualStyleBackColor = true;
            this.tcPages.Controls.Add(tabPagePrepare);
    
            //
            // tlpPrepare
            //
            this.tlpPrepare = new System.Windows.Forms.TableLayoutPanel();
            this.tlpPrepare.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpPrepare.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpPrepare.ColumnCount = 3;
            this.tlpPrepare.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpPrepare.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpPrepare.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpPrepare.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpPrepare.Location = new System.Drawing.Point(17, 15);
            this.tlpPrepare.Name = "tlp";
            this.tlpPrepare.RowCount = 5;
            this.tlpPrepare.Size = new System.Drawing.Size(400, 260);
            this.tlpPrepare.TabIndex = 1;
            this.tabPagePrepare.Controls.Add(this.tlpPrepare);

            this.label_Prepare_name = new System.Windows.Forms.Label();
            this.label_Prepare_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Prepare_name.AutoSize = true;
            this.label_Prepare_name.Location = new System.Drawing.Point(3, 113);
            this.label_Prepare_name.Name = "label_Prepare_name";
            this.label_Prepare_name.Size = new System.Drawing.Size(43, 17);
            this.label_Prepare_name.TabIndex = 0;
            this.label_Prepare_name.Text = "参数名";
            this.tlpPrepare.Controls.Add(this.label_Prepare_name, 0, 0);

            this.label_Prepare_value = new System.Windows.Forms.Label();
            this.label_Prepare_value.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Prepare_value.AutoSize = true;
            this.label_Prepare_value.Location = new System.Drawing.Point(3, 113);
            this.label_Prepare_value.Name = "label_Prepare_value";
            this.label_Prepare_value.Size = new System.Drawing.Size(43, 17);
            this.label_Prepare_value.TabIndex = 0;
            this.label_Prepare_value.Text = "参数值";
            this.tlpPrepare.Controls.Add(this.label_Prepare_value, 1, 0);

            this.label_Prepare_remark= new System.Windows.Forms.Label();
            this.label_Prepare_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Prepare_remark.AutoSize = true;
            this.label_Prepare_remark.Location = new System.Drawing.Point(3, 113);
            this.label_Prepare_remark.Name = "label_Prepare_name";
            this.label_Prepare_remark.Size = new System.Drawing.Size(43, 17);
            this.label_Prepare_remark.TabIndex = 0;
            this.label_Prepare_remark.Text = "说明";
            this.tlpPrepare.Controls.Add(this.label_Prepare_remark, 2, 0);
            
            //
            // label_Prepare_bucket
            //
            this.label_Prepare_bucket_name = new System.Windows.Forms.Label();
            this.label_Prepare_bucket_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Prepare_bucket_name.AutoSize = true;
            this.label_Prepare_bucket_name.Location = new System.Drawing.Point(3, 113);
            this.label_Prepare_bucket_name.Name = "label_Prepare_bucket";
            this.label_Prepare_bucket_name.Size = new System.Drawing.Size(43, 17);
            this.label_Prepare_bucket_name.TabIndex = 0;
            this.label_Prepare_bucket_name.Text = "bucket";
            this.tlpPrepare.Controls.Add(this.label_Prepare_bucket_name, 0, 1);
    
            //
            // label_Prepare_bucket
            //
            this.label_Prepare_bucket_remark = new System.Windows.Forms.Label();
            this.label_Prepare_bucket_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Prepare_bucket_remark.AutoSize = true;
            this.label_Prepare_bucket_remark.Location = new System.Drawing.Point(3, 113);
            this.label_Prepare_bucket_remark.Name = "label_Prepare_bucket";
            this.label_Prepare_bucket_remark.Size = new System.Drawing.Size(43, 17);
            this.label_Prepare_bucket_remark.TabIndex = 0;
            this.label_Prepare_bucket_remark.Text = "存储桶";
            this.tlpPrepare.Controls.Add(this.label_Prepare_bucket_remark, 2, 1);
    
            //
            // tb_Prepare_bucket
            //
            this.tb_Prepare_bucket = new System.Windows.Forms.TextBox();
            this.tb_Prepare_bucket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Prepare_bucket.Location = new System.Drawing.Point(189, 50);
            this.tb_Prepare_bucket.Name = "tb_Prepare_bucket";
            this.tb_Prepare_bucket.Size = new System.Drawing.Size(363, 23);
            this.tb_Prepare_bucket.TabIndex = 1;
            this.tlpPrepare.Controls.Add(this.tb_Prepare_bucket, 1, 1);
            this.tlpPrepare.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
    
            //
            // label_Prepare_uname
            //
            this.label_Prepare_uname_name = new System.Windows.Forms.Label();
            this.label_Prepare_uname_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Prepare_uname_name.AutoSize = true;
            this.label_Prepare_uname_name.Location = new System.Drawing.Point(3, 113);
            this.label_Prepare_uname_name.Name = "label_Prepare_uname";
            this.label_Prepare_uname_name.Size = new System.Drawing.Size(43, 17);
            this.label_Prepare_uname_name.TabIndex = 0;
            this.label_Prepare_uname_name.Text = "uname";
            this.tlpPrepare.Controls.Add(this.label_Prepare_uname_name, 0, 2);
    
            //
            // label_Prepare_uname
            //
            this.label_Prepare_uname_remark = new System.Windows.Forms.Label();
            this.label_Prepare_uname_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Prepare_uname_remark.AutoSize = true;
            this.label_Prepare_uname_remark.Location = new System.Drawing.Point(3, 113);
            this.label_Prepare_uname_remark.Name = "label_Prepare_uname";
            this.label_Prepare_uname_remark.Size = new System.Drawing.Size(43, 17);
            this.label_Prepare_uname_remark.TabIndex = 0;
            this.label_Prepare_uname_remark.Text = "存储引擎中的唯一名";
            this.tlpPrepare.Controls.Add(this.label_Prepare_uname_remark, 2, 2);
    
            //
            // tb_Prepare_uname
            //
            this.tb_Prepare_uname = new System.Windows.Forms.TextBox();
            this.tb_Prepare_uname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Prepare_uname.Location = new System.Drawing.Point(189, 50);
            this.tb_Prepare_uname.Name = "tb_Prepare_uname";
            this.tb_Prepare_uname.Size = new System.Drawing.Size(363, 23);
            this.tb_Prepare_uname.TabIndex = 1;
            this.tlpPrepare.Controls.Add(this.tb_Prepare_uname, 1, 2);
            this.tlpPrepare.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
    
            //
            // label_Prepare_size
            //
            this.label_Prepare_size_name = new System.Windows.Forms.Label();
            this.label_Prepare_size_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Prepare_size_name.AutoSize = true;
            this.label_Prepare_size_name.Location = new System.Drawing.Point(3, 113);
            this.label_Prepare_size_name.Name = "label_Prepare_size";
            this.label_Prepare_size_name.Size = new System.Drawing.Size(43, 17);
            this.label_Prepare_size_name.TabIndex = 0;
            this.label_Prepare_size_name.Text = "size";
            this.tlpPrepare.Controls.Add(this.label_Prepare_size_name, 0, 3);
    
            //
            // label_Prepare_size
            //
            this.label_Prepare_size_remark = new System.Windows.Forms.Label();
            this.label_Prepare_size_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Prepare_size_remark.AutoSize = true;
            this.label_Prepare_size_remark.Location = new System.Drawing.Point(3, 113);
            this.label_Prepare_size_remark.Name = "label_Prepare_size";
            this.label_Prepare_size_remark.Size = new System.Drawing.Size(43, 17);
            this.label_Prepare_size_remark.TabIndex = 0;
            this.label_Prepare_size_remark.Text = "对象大小";
            this.tlpPrepare.Controls.Add(this.label_Prepare_size_remark, 2, 3);
    
            //
            // tb_Prepare_size
            //
            this.tb_Prepare_size = new System.Windows.Forms.TextBox();
            this.tb_Prepare_size.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Prepare_size.Location = new System.Drawing.Point(189, 50);
            this.tb_Prepare_size.Name = "tb_Prepare_size";
            this.tb_Prepare_size.Size = new System.Drawing.Size(363, 23);
            this.tb_Prepare_size.TabIndex = 1;
            this.tlpPrepare.Controls.Add(this.tb_Prepare_size, 1, 3);
            this.tlpPrepare.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
    
            //
            // btnSubmitPrepare
            //
            this.btnSubmitPrepare = new System.Windows.Forms.Button();
            this.btnSubmitPrepare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSubmitPrepare.Location = new System.Drawing.Point(17, 300);
            this.btnSubmitPrepare.Name = "btnSubmitPrepare";
            this.btnSubmitPrepare.Size = new System.Drawing.Size(120, 29);
            this.btnSubmitPrepare.TabIndex = 0;
            this.btnSubmitPrepare.Text = "Submit";
            this.btnSubmitPrepare.UseVisualStyleBackColor = true;
            this.btnSubmitPrepare.Click += new System.EventHandler(this.btnSubmitPrepare_Click);
            this.tabPagePrepare.Controls.Add(this.btnSubmitPrepare);
    
            //
            // tabPageFlush
            //
            this.tabPageFlush = new System.Windows.Forms.TabPage();
            this.tabPageFlush.Location = new System.Drawing.Point(4, 48);
            this.tabPageFlush.Name = "Flush";
            this.tabPageFlush.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFlush.Size = new System.Drawing.Size(459, 373);
            this.tabPageFlush.TabIndex = 0;
            this.tabPageFlush.Text = "Flush";
            this.tabPageFlush.UseVisualStyleBackColor = true;
            this.tcPages.Controls.Add(tabPageFlush);
    
            //
            // tlpFlush
            //
            this.tlpFlush = new System.Windows.Forms.TableLayoutPanel();
            this.tlpFlush.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpFlush.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpFlush.ColumnCount = 3;
            this.tlpFlush.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpFlush.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpFlush.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpFlush.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpFlush.Location = new System.Drawing.Point(17, 15);
            this.tlpFlush.Name = "tlp";
            this.tlpFlush.RowCount = 5;
            this.tlpFlush.Size = new System.Drawing.Size(400, 260);
            this.tlpFlush.TabIndex = 1;
            this.tabPageFlush.Controls.Add(this.tlpFlush);

            this.label_Flush_name = new System.Windows.Forms.Label();
            this.label_Flush_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Flush_name.AutoSize = true;
            this.label_Flush_name.Location = new System.Drawing.Point(3, 113);
            this.label_Flush_name.Name = "label_Flush_name";
            this.label_Flush_name.Size = new System.Drawing.Size(43, 17);
            this.label_Flush_name.TabIndex = 0;
            this.label_Flush_name.Text = "参数名";
            this.tlpFlush.Controls.Add(this.label_Flush_name, 0, 0);

            this.label_Flush_value = new System.Windows.Forms.Label();
            this.label_Flush_value.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Flush_value.AutoSize = true;
            this.label_Flush_value.Location = new System.Drawing.Point(3, 113);
            this.label_Flush_value.Name = "label_Flush_value";
            this.label_Flush_value.Size = new System.Drawing.Size(43, 17);
            this.label_Flush_value.TabIndex = 0;
            this.label_Flush_value.Text = "参数值";
            this.tlpFlush.Controls.Add(this.label_Flush_value, 1, 0);

            this.label_Flush_remark= new System.Windows.Forms.Label();
            this.label_Flush_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Flush_remark.AutoSize = true;
            this.label_Flush_remark.Location = new System.Drawing.Point(3, 113);
            this.label_Flush_remark.Name = "label_Flush_name";
            this.label_Flush_remark.Size = new System.Drawing.Size(43, 17);
            this.label_Flush_remark.TabIndex = 0;
            this.label_Flush_remark.Text = "说明";
            this.tlpFlush.Controls.Add(this.label_Flush_remark, 2, 0);
            
            //
            // label_Flush_bucket
            //
            this.label_Flush_bucket_name = new System.Windows.Forms.Label();
            this.label_Flush_bucket_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Flush_bucket_name.AutoSize = true;
            this.label_Flush_bucket_name.Location = new System.Drawing.Point(3, 113);
            this.label_Flush_bucket_name.Name = "label_Flush_bucket";
            this.label_Flush_bucket_name.Size = new System.Drawing.Size(43, 17);
            this.label_Flush_bucket_name.TabIndex = 0;
            this.label_Flush_bucket_name.Text = "bucket";
            this.tlpFlush.Controls.Add(this.label_Flush_bucket_name, 0, 1);
    
            //
            // label_Flush_bucket
            //
            this.label_Flush_bucket_remark = new System.Windows.Forms.Label();
            this.label_Flush_bucket_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Flush_bucket_remark.AutoSize = true;
            this.label_Flush_bucket_remark.Location = new System.Drawing.Point(3, 113);
            this.label_Flush_bucket_remark.Name = "label_Flush_bucket";
            this.label_Flush_bucket_remark.Size = new System.Drawing.Size(43, 17);
            this.label_Flush_bucket_remark.TabIndex = 0;
            this.label_Flush_bucket_remark.Text = "存储桶";
            this.tlpFlush.Controls.Add(this.label_Flush_bucket_remark, 2, 1);
    
            //
            // tb_Flush_bucket
            //
            this.tb_Flush_bucket = new System.Windows.Forms.TextBox();
            this.tb_Flush_bucket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Flush_bucket.Location = new System.Drawing.Point(189, 50);
            this.tb_Flush_bucket.Name = "tb_Flush_bucket";
            this.tb_Flush_bucket.Size = new System.Drawing.Size(363, 23);
            this.tb_Flush_bucket.TabIndex = 1;
            this.tlpFlush.Controls.Add(this.tb_Flush_bucket, 1, 1);
            this.tlpFlush.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
    
            //
            // label_Flush_uname
            //
            this.label_Flush_uname_name = new System.Windows.Forms.Label();
            this.label_Flush_uname_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Flush_uname_name.AutoSize = true;
            this.label_Flush_uname_name.Location = new System.Drawing.Point(3, 113);
            this.label_Flush_uname_name.Name = "label_Flush_uname";
            this.label_Flush_uname_name.Size = new System.Drawing.Size(43, 17);
            this.label_Flush_uname_name.TabIndex = 0;
            this.label_Flush_uname_name.Text = "uname";
            this.tlpFlush.Controls.Add(this.label_Flush_uname_name, 0, 2);
    
            //
            // label_Flush_uname
            //
            this.label_Flush_uname_remark = new System.Windows.Forms.Label();
            this.label_Flush_uname_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Flush_uname_remark.AutoSize = true;
            this.label_Flush_uname_remark.Location = new System.Drawing.Point(3, 113);
            this.label_Flush_uname_remark.Name = "label_Flush_uname";
            this.label_Flush_uname_remark.Size = new System.Drawing.Size(43, 17);
            this.label_Flush_uname_remark.TabIndex = 0;
            this.label_Flush_uname_remark.Text = "存储引擎中的唯一名";
            this.tlpFlush.Controls.Add(this.label_Flush_uname_remark, 2, 2);
    
            //
            // tb_Flush_uname
            //
            this.tb_Flush_uname = new System.Windows.Forms.TextBox();
            this.tb_Flush_uname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Flush_uname.Location = new System.Drawing.Point(189, 50);
            this.tb_Flush_uname.Name = "tb_Flush_uname";
            this.tb_Flush_uname.Size = new System.Drawing.Size(363, 23);
            this.tb_Flush_uname.TabIndex = 1;
            this.tlpFlush.Controls.Add(this.tb_Flush_uname, 1, 2);
            this.tlpFlush.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
    
            //
            // label_Flush_path
            //
            this.label_Flush_path_name = new System.Windows.Forms.Label();
            this.label_Flush_path_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Flush_path_name.AutoSize = true;
            this.label_Flush_path_name.Location = new System.Drawing.Point(3, 113);
            this.label_Flush_path_name.Name = "label_Flush_path";
            this.label_Flush_path_name.Size = new System.Drawing.Size(43, 17);
            this.label_Flush_path_name.TabIndex = 0;
            this.label_Flush_path_name.Text = "path";
            this.tlpFlush.Controls.Add(this.label_Flush_path_name, 0, 3);
    
            //
            // label_Flush_path
            //
            this.label_Flush_path_remark = new System.Windows.Forms.Label();
            this.label_Flush_path_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Flush_path_remark.AutoSize = true;
            this.label_Flush_path_remark.Location = new System.Drawing.Point(3, 113);
            this.label_Flush_path_remark.Name = "label_Flush_path";
            this.label_Flush_path_remark.Size = new System.Drawing.Size(43, 17);
            this.label_Flush_path_remark.TabIndex = 0;
            this.label_Flush_path_remark.Text = "对象存储的路径";
            this.tlpFlush.Controls.Add(this.label_Flush_path_remark, 2, 3);
    
            //
            // tb_Flush_path
            //
            this.tb_Flush_path = new System.Windows.Forms.TextBox();
            this.tb_Flush_path.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Flush_path.Location = new System.Drawing.Point(189, 50);
            this.tb_Flush_path.Name = "tb_Flush_path";
            this.tb_Flush_path.Size = new System.Drawing.Size(363, 23);
            this.tb_Flush_path.TabIndex = 1;
            this.tlpFlush.Controls.Add(this.tb_Flush_path, 1, 3);
            this.tlpFlush.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
    
            //
            // btnSubmitFlush
            //
            this.btnSubmitFlush = new System.Windows.Forms.Button();
            this.btnSubmitFlush.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSubmitFlush.Location = new System.Drawing.Point(17, 300);
            this.btnSubmitFlush.Name = "btnSubmitFlush";
            this.btnSubmitFlush.Size = new System.Drawing.Size(120, 29);
            this.btnSubmitFlush.TabIndex = 0;
            this.btnSubmitFlush.Text = "Submit";
            this.btnSubmitFlush.UseVisualStyleBackColor = true;
            this.btnSubmitFlush.Click += new System.EventHandler(this.btnSubmitFlush_Click);
            this.tabPageFlush.Controls.Add(this.btnSubmitFlush);
    
            //
            // tabPageLink
            //
            this.tabPageLink = new System.Windows.Forms.TabPage();
            this.tabPageLink.Location = new System.Drawing.Point(4, 48);
            this.tabPageLink.Name = "Link";
            this.tabPageLink.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLink.Size = new System.Drawing.Size(459, 373);
            this.tabPageLink.TabIndex = 0;
            this.tabPageLink.Text = "Link";
            this.tabPageLink.UseVisualStyleBackColor = true;
            this.tcPages.Controls.Add(tabPageLink);
    
            //
            // tlpLink
            //
            this.tlpLink = new System.Windows.Forms.TableLayoutPanel();
            this.tlpLink.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpLink.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpLink.ColumnCount = 3;
            this.tlpLink.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpLink.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpLink.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpLink.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpLink.Location = new System.Drawing.Point(17, 15);
            this.tlpLink.Name = "tlp";
            this.tlpLink.RowCount = 6;
            this.tlpLink.Size = new System.Drawing.Size(400, 260);
            this.tlpLink.TabIndex = 1;
            this.tabPageLink.Controls.Add(this.tlpLink);

            this.label_Link_name = new System.Windows.Forms.Label();
            this.label_Link_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Link_name.AutoSize = true;
            this.label_Link_name.Location = new System.Drawing.Point(3, 113);
            this.label_Link_name.Name = "label_Link_name";
            this.label_Link_name.Size = new System.Drawing.Size(43, 17);
            this.label_Link_name.TabIndex = 0;
            this.label_Link_name.Text = "参数名";
            this.tlpLink.Controls.Add(this.label_Link_name, 0, 0);

            this.label_Link_value = new System.Windows.Forms.Label();
            this.label_Link_value.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Link_value.AutoSize = true;
            this.label_Link_value.Location = new System.Drawing.Point(3, 113);
            this.label_Link_value.Name = "label_Link_value";
            this.label_Link_value.Size = new System.Drawing.Size(43, 17);
            this.label_Link_value.TabIndex = 0;
            this.label_Link_value.Text = "参数值";
            this.tlpLink.Controls.Add(this.label_Link_value, 1, 0);

            this.label_Link_remark= new System.Windows.Forms.Label();
            this.label_Link_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Link_remark.AutoSize = true;
            this.label_Link_remark.Location = new System.Drawing.Point(3, 113);
            this.label_Link_remark.Name = "label_Link_name";
            this.label_Link_remark.Size = new System.Drawing.Size(43, 17);
            this.label_Link_remark.TabIndex = 0;
            this.label_Link_remark.Text = "说明";
            this.tlpLink.Controls.Add(this.label_Link_remark, 2, 0);
            
            //
            // label_Link_bucket
            //
            this.label_Link_bucket_name = new System.Windows.Forms.Label();
            this.label_Link_bucket_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Link_bucket_name.AutoSize = true;
            this.label_Link_bucket_name.Location = new System.Drawing.Point(3, 113);
            this.label_Link_bucket_name.Name = "label_Link_bucket";
            this.label_Link_bucket_name.Size = new System.Drawing.Size(43, 17);
            this.label_Link_bucket_name.TabIndex = 0;
            this.label_Link_bucket_name.Text = "bucket";
            this.tlpLink.Controls.Add(this.label_Link_bucket_name, 0, 1);
    
            //
            // label_Link_bucket
            //
            this.label_Link_bucket_remark = new System.Windows.Forms.Label();
            this.label_Link_bucket_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Link_bucket_remark.AutoSize = true;
            this.label_Link_bucket_remark.Location = new System.Drawing.Point(3, 113);
            this.label_Link_bucket_remark.Name = "label_Link_bucket";
            this.label_Link_bucket_remark.Size = new System.Drawing.Size(43, 17);
            this.label_Link_bucket_remark.TabIndex = 0;
            this.label_Link_bucket_remark.Text = "存储桶";
            this.tlpLink.Controls.Add(this.label_Link_bucket_remark, 2, 1);
    
            //
            // tb_Link_bucket
            //
            this.tb_Link_bucket = new System.Windows.Forms.TextBox();
            this.tb_Link_bucket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Link_bucket.Location = new System.Drawing.Point(189, 50);
            this.tb_Link_bucket.Name = "tb_Link_bucket";
            this.tb_Link_bucket.Size = new System.Drawing.Size(363, 23);
            this.tb_Link_bucket.TabIndex = 1;
            this.tlpLink.Controls.Add(this.tb_Link_bucket, 1, 1);
            this.tlpLink.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
    
            //
            // label_Link_filepath
            //
            this.label_Link_filepath_name = new System.Windows.Forms.Label();
            this.label_Link_filepath_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Link_filepath_name.AutoSize = true;
            this.label_Link_filepath_name.Location = new System.Drawing.Point(3, 113);
            this.label_Link_filepath_name.Name = "label_Link_filepath";
            this.label_Link_filepath_name.Size = new System.Drawing.Size(43, 17);
            this.label_Link_filepath_name.TabIndex = 0;
            this.label_Link_filepath_name.Text = "filepath";
            this.tlpLink.Controls.Add(this.label_Link_filepath_name, 0, 2);
    
            //
            // label_Link_filepath
            //
            this.label_Link_filepath_remark = new System.Windows.Forms.Label();
            this.label_Link_filepath_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Link_filepath_remark.AutoSize = true;
            this.label_Link_filepath_remark.Location = new System.Drawing.Point(3, 113);
            this.label_Link_filepath_remark.Name = "label_Link_filepath";
            this.label_Link_filepath_remark.Size = new System.Drawing.Size(43, 17);
            this.label_Link_filepath_remark.TabIndex = 0;
            this.label_Link_filepath_remark.Text = "文件路径";
            this.tlpLink.Controls.Add(this.label_Link_filepath_remark, 2, 2);
    
            //
            // tb_Link_filepath
            //
            this.tb_Link_filepath = new System.Windows.Forms.TextBox();
            this.tb_Link_filepath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Link_filepath.Location = new System.Drawing.Point(189, 50);
            this.tb_Link_filepath.Name = "tb_Link_filepath";
            this.tb_Link_filepath.Size = new System.Drawing.Size(363, 23);
            this.tb_Link_filepath.TabIndex = 1;
            this.tlpLink.Controls.Add(this.tb_Link_filepath, 1, 2);
            this.tlpLink.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
    
            //
            // label_Link_url
            //
            this.label_Link_url_name = new System.Windows.Forms.Label();
            this.label_Link_url_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Link_url_name.AutoSize = true;
            this.label_Link_url_name.Location = new System.Drawing.Point(3, 113);
            this.label_Link_url_name.Name = "label_Link_url";
            this.label_Link_url_name.Size = new System.Drawing.Size(43, 17);
            this.label_Link_url_name.TabIndex = 0;
            this.label_Link_url_name.Text = "url";
            this.tlpLink.Controls.Add(this.label_Link_url_name, 0, 3);
    
            //
            // label_Link_url
            //
            this.label_Link_url_remark = new System.Windows.Forms.Label();
            this.label_Link_url_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Link_url_remark.AutoSize = true;
            this.label_Link_url_remark.Location = new System.Drawing.Point(3, 113);
            this.label_Link_url_remark.Name = "label_Link_url";
            this.label_Link_url_remark.Size = new System.Drawing.Size(43, 17);
            this.label_Link_url_remark.TabIndex = 0;
            this.label_Link_url_remark.Text = "地址";
            this.tlpLink.Controls.Add(this.label_Link_url_remark, 2, 3);
    
            //
            // tb_Link_url
            //
            this.tb_Link_url = new System.Windows.Forms.TextBox();
            this.tb_Link_url.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Link_url.Location = new System.Drawing.Point(189, 50);
            this.tb_Link_url.Name = "tb_Link_url";
            this.tb_Link_url.Size = new System.Drawing.Size(363, 23);
            this.tb_Link_url.TabIndex = 1;
            this.tlpLink.Controls.Add(this.tb_Link_url, 1, 3);
            this.tlpLink.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
    
            //
            // label_Link_overwrite
            //
            this.label_Link_overwrite_name = new System.Windows.Forms.Label();
            this.label_Link_overwrite_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Link_overwrite_name.AutoSize = true;
            this.label_Link_overwrite_name.Location = new System.Drawing.Point(3, 113);
            this.label_Link_overwrite_name.Name = "label_Link_overwrite";
            this.label_Link_overwrite_name.Size = new System.Drawing.Size(43, 17);
            this.label_Link_overwrite_name.TabIndex = 0;
            this.label_Link_overwrite_name.Text = "overwrite";
            this.tlpLink.Controls.Add(this.label_Link_overwrite_name, 0, 4);
    
            //
            // label_Link_overwrite
            //
            this.label_Link_overwrite_remark = new System.Windows.Forms.Label();
            this.label_Link_overwrite_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Link_overwrite_remark.AutoSize = true;
            this.label_Link_overwrite_remark.Location = new System.Drawing.Point(3, 113);
            this.label_Link_overwrite_remark.Name = "label_Link_overwrite";
            this.label_Link_overwrite_remark.Size = new System.Drawing.Size(43, 17);
            this.label_Link_overwrite_remark.TabIndex = 0;
            this.label_Link_overwrite_remark.Text = "是否覆盖已有对象";
            this.tlpLink.Controls.Add(this.label_Link_overwrite_remark, 2, 4);
    
            //
            // tb_Link_overwrite
            //
            this.tb_Link_overwrite = new System.Windows.Forms.TextBox();
            this.tb_Link_overwrite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Link_overwrite.Location = new System.Drawing.Point(189, 50);
            this.tb_Link_overwrite.Name = "tb_Link_overwrite";
            this.tb_Link_overwrite.Size = new System.Drawing.Size(363, 23);
            this.tb_Link_overwrite.TabIndex = 1;
            this.tlpLink.Controls.Add(this.tb_Link_overwrite, 1, 4);
            this.tlpLink.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
    
            //
            // btnSubmitLink
            //
            this.btnSubmitLink = new System.Windows.Forms.Button();
            this.btnSubmitLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSubmitLink.Location = new System.Drawing.Point(17, 300);
            this.btnSubmitLink.Name = "btnSubmitLink";
            this.btnSubmitLink.Size = new System.Drawing.Size(120, 29);
            this.btnSubmitLink.TabIndex = 0;
            this.btnSubmitLink.Text = "Submit";
            this.btnSubmitLink.UseVisualStyleBackColor = true;
            this.btnSubmitLink.Click += new System.EventHandler(this.btnSubmitLink_Click);
            this.tabPageLink.Controls.Add(this.btnSubmitLink);
    
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
            // tlpGet
            //
            this.tlpGet = new System.Windows.Forms.TableLayoutPanel();
            this.tlpGet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpGet.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpGet.ColumnCount = 3;
            this.tlpGet.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpGet.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpGet.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpGet.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpGet.Location = new System.Drawing.Point(17, 15);
            this.tlpGet.Name = "tlp";
            this.tlpGet.RowCount = 3;
            this.tlpGet.Size = new System.Drawing.Size(400, 260);
            this.tlpGet.TabIndex = 1;
            this.tabPageGet.Controls.Add(this.tlpGet);

            this.label_Get_name = new System.Windows.Forms.Label();
            this.label_Get_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Get_name.AutoSize = true;
            this.label_Get_name.Location = new System.Drawing.Point(3, 113);
            this.label_Get_name.Name = "label_Get_name";
            this.label_Get_name.Size = new System.Drawing.Size(43, 17);
            this.label_Get_name.TabIndex = 0;
            this.label_Get_name.Text = "参数名";
            this.tlpGet.Controls.Add(this.label_Get_name, 0, 0);

            this.label_Get_value = new System.Windows.Forms.Label();
            this.label_Get_value.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Get_value.AutoSize = true;
            this.label_Get_value.Location = new System.Drawing.Point(3, 113);
            this.label_Get_value.Name = "label_Get_value";
            this.label_Get_value.Size = new System.Drawing.Size(43, 17);
            this.label_Get_value.TabIndex = 0;
            this.label_Get_value.Text = "参数值";
            this.tlpGet.Controls.Add(this.label_Get_value, 1, 0);

            this.label_Get_remark= new System.Windows.Forms.Label();
            this.label_Get_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Get_remark.AutoSize = true;
            this.label_Get_remark.Location = new System.Drawing.Point(3, 113);
            this.label_Get_remark.Name = "label_Get_name";
            this.label_Get_remark.Size = new System.Drawing.Size(43, 17);
            this.label_Get_remark.TabIndex = 0;
            this.label_Get_remark.Text = "说明";
            this.tlpGet.Controls.Add(this.label_Get_remark, 2, 0);
            
            //
            // label_Get_uuid
            //
            this.label_Get_uuid_name = new System.Windows.Forms.Label();
            this.label_Get_uuid_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Get_uuid_name.AutoSize = true;
            this.label_Get_uuid_name.Location = new System.Drawing.Point(3, 113);
            this.label_Get_uuid_name.Name = "label_Get_uuid";
            this.label_Get_uuid_name.Size = new System.Drawing.Size(43, 17);
            this.label_Get_uuid_name.TabIndex = 0;
            this.label_Get_uuid_name.Text = "uuid";
            this.tlpGet.Controls.Add(this.label_Get_uuid_name, 0, 1);
    
            //
            // label_Get_uuid
            //
            this.label_Get_uuid_remark = new System.Windows.Forms.Label();
            this.label_Get_uuid_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Get_uuid_remark.AutoSize = true;
            this.label_Get_uuid_remark.Location = new System.Drawing.Point(3, 113);
            this.label_Get_uuid_remark.Name = "label_Get_uuid";
            this.label_Get_uuid_remark.Size = new System.Drawing.Size(43, 17);
            this.label_Get_uuid_remark.TabIndex = 0;
            this.label_Get_uuid_remark.Text = "唯一ID";
            this.tlpGet.Controls.Add(this.label_Get_uuid_remark, 2, 1);
    
            //
            // tb_Get_uuid
            //
            this.tb_Get_uuid = new System.Windows.Forms.TextBox();
            this.tb_Get_uuid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Get_uuid.Location = new System.Drawing.Point(189, 50);
            this.tb_Get_uuid.Name = "tb_Get_uuid";
            this.tb_Get_uuid.Size = new System.Drawing.Size(363, 23);
            this.tb_Get_uuid.TabIndex = 1;
            this.tlpGet.Controls.Add(this.tb_Get_uuid, 1, 1);
            this.tlpGet.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
    
            //
            // btnSubmitGet
            //
            this.btnSubmitGet = new System.Windows.Forms.Button();
            this.btnSubmitGet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSubmitGet.Location = new System.Drawing.Point(17, 300);
            this.btnSubmitGet.Name = "btnSubmitGet";
            this.btnSubmitGet.Size = new System.Drawing.Size(120, 29);
            this.btnSubmitGet.TabIndex = 0;
            this.btnSubmitGet.Text = "Submit";
            this.btnSubmitGet.UseVisualStyleBackColor = true;
            this.btnSubmitGet.Click += new System.EventHandler(this.btnSubmitGet_Click);
            this.tabPageGet.Controls.Add(this.btnSubmitGet);
    
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
            // tlpFind
            //
            this.tlpFind = new System.Windows.Forms.TableLayoutPanel();
            this.tlpFind.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpFind.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpFind.ColumnCount = 3;
            this.tlpFind.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpFind.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpFind.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpFind.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpFind.Location = new System.Drawing.Point(17, 15);
            this.tlpFind.Name = "tlp";
            this.tlpFind.RowCount = 4;
            this.tlpFind.Size = new System.Drawing.Size(400, 260);
            this.tlpFind.TabIndex = 1;
            this.tabPageFind.Controls.Add(this.tlpFind);

            this.label_Find_name = new System.Windows.Forms.Label();
            this.label_Find_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Find_name.AutoSize = true;
            this.label_Find_name.Location = new System.Drawing.Point(3, 113);
            this.label_Find_name.Name = "label_Find_name";
            this.label_Find_name.Size = new System.Drawing.Size(43, 17);
            this.label_Find_name.TabIndex = 0;
            this.label_Find_name.Text = "参数名";
            this.tlpFind.Controls.Add(this.label_Find_name, 0, 0);

            this.label_Find_value = new System.Windows.Forms.Label();
            this.label_Find_value.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Find_value.AutoSize = true;
            this.label_Find_value.Location = new System.Drawing.Point(3, 113);
            this.label_Find_value.Name = "label_Find_value";
            this.label_Find_value.Size = new System.Drawing.Size(43, 17);
            this.label_Find_value.TabIndex = 0;
            this.label_Find_value.Text = "参数值";
            this.tlpFind.Controls.Add(this.label_Find_value, 1, 0);

            this.label_Find_remark= new System.Windows.Forms.Label();
            this.label_Find_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Find_remark.AutoSize = true;
            this.label_Find_remark.Location = new System.Drawing.Point(3, 113);
            this.label_Find_remark.Name = "label_Find_name";
            this.label_Find_remark.Size = new System.Drawing.Size(43, 17);
            this.label_Find_remark.TabIndex = 0;
            this.label_Find_remark.Text = "说明";
            this.tlpFind.Controls.Add(this.label_Find_remark, 2, 0);
            
            //
            // label_Find_bucket
            //
            this.label_Find_bucket_name = new System.Windows.Forms.Label();
            this.label_Find_bucket_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Find_bucket_name.AutoSize = true;
            this.label_Find_bucket_name.Location = new System.Drawing.Point(3, 113);
            this.label_Find_bucket_name.Name = "label_Find_bucket";
            this.label_Find_bucket_name.Size = new System.Drawing.Size(43, 17);
            this.label_Find_bucket_name.TabIndex = 0;
            this.label_Find_bucket_name.Text = "bucket";
            this.tlpFind.Controls.Add(this.label_Find_bucket_name, 0, 1);
    
            //
            // label_Find_bucket
            //
            this.label_Find_bucket_remark = new System.Windows.Forms.Label();
            this.label_Find_bucket_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Find_bucket_remark.AutoSize = true;
            this.label_Find_bucket_remark.Location = new System.Drawing.Point(3, 113);
            this.label_Find_bucket_remark.Name = "label_Find_bucket";
            this.label_Find_bucket_remark.Size = new System.Drawing.Size(43, 17);
            this.label_Find_bucket_remark.TabIndex = 0;
            this.label_Find_bucket_remark.Text = "存储桶";
            this.tlpFind.Controls.Add(this.label_Find_bucket_remark, 2, 1);
    
            //
            // tb_Find_bucket
            //
            this.tb_Find_bucket = new System.Windows.Forms.TextBox();
            this.tb_Find_bucket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Find_bucket.Location = new System.Drawing.Point(189, 50);
            this.tb_Find_bucket.Name = "tb_Find_bucket";
            this.tb_Find_bucket.Size = new System.Drawing.Size(363, 23);
            this.tb_Find_bucket.TabIndex = 1;
            this.tlpFind.Controls.Add(this.tb_Find_bucket, 1, 1);
            this.tlpFind.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
    
            //
            // label_Find_filepath
            //
            this.label_Find_filepath_name = new System.Windows.Forms.Label();
            this.label_Find_filepath_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Find_filepath_name.AutoSize = true;
            this.label_Find_filepath_name.Location = new System.Drawing.Point(3, 113);
            this.label_Find_filepath_name.Name = "label_Find_filepath";
            this.label_Find_filepath_name.Size = new System.Drawing.Size(43, 17);
            this.label_Find_filepath_name.TabIndex = 0;
            this.label_Find_filepath_name.Text = "filepath";
            this.tlpFind.Controls.Add(this.label_Find_filepath_name, 0, 2);
    
            //
            // label_Find_filepath
            //
            this.label_Find_filepath_remark = new System.Windows.Forms.Label();
            this.label_Find_filepath_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Find_filepath_remark.AutoSize = true;
            this.label_Find_filepath_remark.Location = new System.Drawing.Point(3, 113);
            this.label_Find_filepath_remark.Name = "label_Find_filepath";
            this.label_Find_filepath_remark.Size = new System.Drawing.Size(43, 17);
            this.label_Find_filepath_remark.TabIndex = 0;
            this.label_Find_filepath_remark.Text = "文件路径";
            this.tlpFind.Controls.Add(this.label_Find_filepath_remark, 2, 2);
    
            //
            // tb_Find_filepath
            //
            this.tb_Find_filepath = new System.Windows.Forms.TextBox();
            this.tb_Find_filepath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Find_filepath.Location = new System.Drawing.Point(189, 50);
            this.tb_Find_filepath.Name = "tb_Find_filepath";
            this.tb_Find_filepath.Size = new System.Drawing.Size(363, 23);
            this.tb_Find_filepath.TabIndex = 1;
            this.tlpFind.Controls.Add(this.tb_Find_filepath, 1, 2);
            this.tlpFind.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
    
            //
            // btnSubmitFind
            //
            this.btnSubmitFind = new System.Windows.Forms.Button();
            this.btnSubmitFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSubmitFind.Location = new System.Drawing.Point(17, 300);
            this.btnSubmitFind.Name = "btnSubmitFind";
            this.btnSubmitFind.Size = new System.Drawing.Size(120, 29);
            this.btnSubmitFind.TabIndex = 0;
            this.btnSubmitFind.Text = "Submit";
            this.btnSubmitFind.UseVisualStyleBackColor = true;
            this.btnSubmitFind.Click += new System.EventHandler(this.btnSubmitFind_Click);
            this.tabPageFind.Controls.Add(this.btnSubmitFind);
    
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
            // tlpRemove
            //
            this.tlpRemove = new System.Windows.Forms.TableLayoutPanel();
            this.tlpRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpRemove.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpRemove.ColumnCount = 3;
            this.tlpRemove.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpRemove.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpRemove.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpRemove.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpRemove.Location = new System.Drawing.Point(17, 15);
            this.tlpRemove.Name = "tlp";
            this.tlpRemove.RowCount = 3;
            this.tlpRemove.Size = new System.Drawing.Size(400, 260);
            this.tlpRemove.TabIndex = 1;
            this.tabPageRemove.Controls.Add(this.tlpRemove);

            this.label_Remove_name = new System.Windows.Forms.Label();
            this.label_Remove_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Remove_name.AutoSize = true;
            this.label_Remove_name.Location = new System.Drawing.Point(3, 113);
            this.label_Remove_name.Name = "label_Remove_name";
            this.label_Remove_name.Size = new System.Drawing.Size(43, 17);
            this.label_Remove_name.TabIndex = 0;
            this.label_Remove_name.Text = "参数名";
            this.tlpRemove.Controls.Add(this.label_Remove_name, 0, 0);

            this.label_Remove_value = new System.Windows.Forms.Label();
            this.label_Remove_value.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Remove_value.AutoSize = true;
            this.label_Remove_value.Location = new System.Drawing.Point(3, 113);
            this.label_Remove_value.Name = "label_Remove_value";
            this.label_Remove_value.Size = new System.Drawing.Size(43, 17);
            this.label_Remove_value.TabIndex = 0;
            this.label_Remove_value.Text = "参数值";
            this.tlpRemove.Controls.Add(this.label_Remove_value, 1, 0);

            this.label_Remove_remark= new System.Windows.Forms.Label();
            this.label_Remove_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Remove_remark.AutoSize = true;
            this.label_Remove_remark.Location = new System.Drawing.Point(3, 113);
            this.label_Remove_remark.Name = "label_Remove_name";
            this.label_Remove_remark.Size = new System.Drawing.Size(43, 17);
            this.label_Remove_remark.TabIndex = 0;
            this.label_Remove_remark.Text = "说明";
            this.tlpRemove.Controls.Add(this.label_Remove_remark, 2, 0);
            
            //
            // label_Remove_uuid
            //
            this.label_Remove_uuid_name = new System.Windows.Forms.Label();
            this.label_Remove_uuid_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Remove_uuid_name.AutoSize = true;
            this.label_Remove_uuid_name.Location = new System.Drawing.Point(3, 113);
            this.label_Remove_uuid_name.Name = "label_Remove_uuid";
            this.label_Remove_uuid_name.Size = new System.Drawing.Size(43, 17);
            this.label_Remove_uuid_name.TabIndex = 0;
            this.label_Remove_uuid_name.Text = "uuid";
            this.tlpRemove.Controls.Add(this.label_Remove_uuid_name, 0, 1);
    
            //
            // label_Remove_uuid
            //
            this.label_Remove_uuid_remark = new System.Windows.Forms.Label();
            this.label_Remove_uuid_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Remove_uuid_remark.AutoSize = true;
            this.label_Remove_uuid_remark.Location = new System.Drawing.Point(3, 113);
            this.label_Remove_uuid_remark.Name = "label_Remove_uuid";
            this.label_Remove_uuid_remark.Size = new System.Drawing.Size(43, 17);
            this.label_Remove_uuid_remark.TabIndex = 0;
            this.label_Remove_uuid_remark.Text = "uuid";
            this.tlpRemove.Controls.Add(this.label_Remove_uuid_remark, 2, 1);
    
            //
            // tb_Remove_uuid
            //
            this.tb_Remove_uuid = new System.Windows.Forms.TextBox();
            this.tb_Remove_uuid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Remove_uuid.Location = new System.Drawing.Point(189, 50);
            this.tb_Remove_uuid.Name = "tb_Remove_uuid";
            this.tb_Remove_uuid.Size = new System.Drawing.Size(363, 23);
            this.tb_Remove_uuid.TabIndex = 1;
            this.tlpRemove.Controls.Add(this.tb_Remove_uuid, 1, 1);
            this.tlpRemove.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
    
            //
            // btnSubmitRemove
            //
            this.btnSubmitRemove = new System.Windows.Forms.Button();
            this.btnSubmitRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSubmitRemove.Location = new System.Drawing.Point(17, 300);
            this.btnSubmitRemove.Name = "btnSubmitRemove";
            this.btnSubmitRemove.Size = new System.Drawing.Size(120, 29);
            this.btnSubmitRemove.TabIndex = 0;
            this.btnSubmitRemove.Text = "Submit";
            this.btnSubmitRemove.UseVisualStyleBackColor = true;
            this.btnSubmitRemove.Click += new System.EventHandler(this.btnSubmitRemove_Click);
            this.tabPageRemove.Controls.Add(this.btnSubmitRemove);
    
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
            // tlpList
            //
            this.tlpList = new System.Windows.Forms.TableLayoutPanel();
            this.tlpList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpList.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpList.ColumnCount = 3;
            this.tlpList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpList.Location = new System.Drawing.Point(17, 15);
            this.tlpList.Name = "tlp";
            this.tlpList.RowCount = 5;
            this.tlpList.Size = new System.Drawing.Size(400, 260);
            this.tlpList.TabIndex = 1;
            this.tabPageList.Controls.Add(this.tlpList);

            this.label_List_name = new System.Windows.Forms.Label();
            this.label_List_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_List_name.AutoSize = true;
            this.label_List_name.Location = new System.Drawing.Point(3, 113);
            this.label_List_name.Name = "label_List_name";
            this.label_List_name.Size = new System.Drawing.Size(43, 17);
            this.label_List_name.TabIndex = 0;
            this.label_List_name.Text = "参数名";
            this.tlpList.Controls.Add(this.label_List_name, 0, 0);

            this.label_List_value = new System.Windows.Forms.Label();
            this.label_List_value.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_List_value.AutoSize = true;
            this.label_List_value.Location = new System.Drawing.Point(3, 113);
            this.label_List_value.Name = "label_List_value";
            this.label_List_value.Size = new System.Drawing.Size(43, 17);
            this.label_List_value.TabIndex = 0;
            this.label_List_value.Text = "参数值";
            this.tlpList.Controls.Add(this.label_List_value, 1, 0);

            this.label_List_remark= new System.Windows.Forms.Label();
            this.label_List_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_List_remark.AutoSize = true;
            this.label_List_remark.Location = new System.Drawing.Point(3, 113);
            this.label_List_remark.Name = "label_List_name";
            this.label_List_remark.Size = new System.Drawing.Size(43, 17);
            this.label_List_remark.TabIndex = 0;
            this.label_List_remark.Text = "说明";
            this.tlpList.Controls.Add(this.label_List_remark, 2, 0);
            
            //
            // label_List_offset
            //
            this.label_List_offset_name = new System.Windows.Forms.Label();
            this.label_List_offset_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_List_offset_name.AutoSize = true;
            this.label_List_offset_name.Location = new System.Drawing.Point(3, 113);
            this.label_List_offset_name.Name = "label_List_offset";
            this.label_List_offset_name.Size = new System.Drawing.Size(43, 17);
            this.label_List_offset_name.TabIndex = 0;
            this.label_List_offset_name.Text = "offset";
            this.tlpList.Controls.Add(this.label_List_offset_name, 0, 1);
    
            //
            // label_List_offset
            //
            this.label_List_offset_remark = new System.Windows.Forms.Label();
            this.label_List_offset_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_List_offset_remark.AutoSize = true;
            this.label_List_offset_remark.Location = new System.Drawing.Point(3, 113);
            this.label_List_offset_remark.Name = "label_List_offset";
            this.label_List_offset_remark.Size = new System.Drawing.Size(43, 17);
            this.label_List_offset_remark.TabIndex = 0;
            this.label_List_offset_remark.Text = "偏移值";
            this.tlpList.Controls.Add(this.label_List_offset_remark, 2, 1);
    
            //
            // tb_List_offset
            //
            this.tb_List_offset = new System.Windows.Forms.TextBox();
            this.tb_List_offset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_List_offset.Location = new System.Drawing.Point(189, 50);
            this.tb_List_offset.Name = "tb_List_offset";
            this.tb_List_offset.Size = new System.Drawing.Size(363, 23);
            this.tb_List_offset.TabIndex = 1;
            this.tlpList.Controls.Add(this.tb_List_offset, 1, 1);
            this.tlpList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
    
            //
            // label_List_count
            //
            this.label_List_count_name = new System.Windows.Forms.Label();
            this.label_List_count_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_List_count_name.AutoSize = true;
            this.label_List_count_name.Location = new System.Drawing.Point(3, 113);
            this.label_List_count_name.Name = "label_List_count";
            this.label_List_count_name.Size = new System.Drawing.Size(43, 17);
            this.label_List_count_name.TabIndex = 0;
            this.label_List_count_name.Text = "count";
            this.tlpList.Controls.Add(this.label_List_count_name, 0, 2);
    
            //
            // label_List_count
            //
            this.label_List_count_remark = new System.Windows.Forms.Label();
            this.label_List_count_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_List_count_remark.AutoSize = true;
            this.label_List_count_remark.Location = new System.Drawing.Point(3, 113);
            this.label_List_count_remark.Name = "label_List_count";
            this.label_List_count_remark.Size = new System.Drawing.Size(43, 17);
            this.label_List_count_remark.TabIndex = 0;
            this.label_List_count_remark.Text = "数量";
            this.tlpList.Controls.Add(this.label_List_count_remark, 2, 2);
    
            //
            // tb_List_count
            //
            this.tb_List_count = new System.Windows.Forms.TextBox();
            this.tb_List_count.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_List_count.Location = new System.Drawing.Point(189, 50);
            this.tb_List_count.Name = "tb_List_count";
            this.tb_List_count.Size = new System.Drawing.Size(363, 23);
            this.tb_List_count.TabIndex = 1;
            this.tlpList.Controls.Add(this.tb_List_count, 1, 2);
            this.tlpList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
    
            //
            // label_List_bucket
            //
            this.label_List_bucket_name = new System.Windows.Forms.Label();
            this.label_List_bucket_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_List_bucket_name.AutoSize = true;
            this.label_List_bucket_name.Location = new System.Drawing.Point(3, 113);
            this.label_List_bucket_name.Name = "label_List_bucket";
            this.label_List_bucket_name.Size = new System.Drawing.Size(43, 17);
            this.label_List_bucket_name.TabIndex = 0;
            this.label_List_bucket_name.Text = "bucket";
            this.tlpList.Controls.Add(this.label_List_bucket_name, 0, 3);
    
            //
            // label_List_bucket
            //
            this.label_List_bucket_remark = new System.Windows.Forms.Label();
            this.label_List_bucket_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_List_bucket_remark.AutoSize = true;
            this.label_List_bucket_remark.Location = new System.Drawing.Point(3, 113);
            this.label_List_bucket_remark.Name = "label_List_bucket";
            this.label_List_bucket_remark.Size = new System.Drawing.Size(43, 17);
            this.label_List_bucket_remark.TabIndex = 0;
            this.label_List_bucket_remark.Text = "储存桶";
            this.tlpList.Controls.Add(this.label_List_bucket_remark, 2, 3);
    
            //
            // tb_List_bucket
            //
            this.tb_List_bucket = new System.Windows.Forms.TextBox();
            this.tb_List_bucket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_List_bucket.Location = new System.Drawing.Point(189, 50);
            this.tb_List_bucket.Name = "tb_List_bucket";
            this.tb_List_bucket.Size = new System.Drawing.Size(363, 23);
            this.tb_List_bucket.TabIndex = 1;
            this.tlpList.Controls.Add(this.tb_List_bucket, 1, 3);
            this.tlpList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
    
            //
            // btnSubmitList
            //
            this.btnSubmitList = new System.Windows.Forms.Button();
            this.btnSubmitList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSubmitList.Location = new System.Drawing.Point(17, 300);
            this.btnSubmitList.Name = "btnSubmitList";
            this.btnSubmitList.Size = new System.Drawing.Size(120, 29);
            this.btnSubmitList.TabIndex = 0;
            this.btnSubmitList.Text = "Submit";
            this.btnSubmitList.UseVisualStyleBackColor = true;
            this.btnSubmitList.Click += new System.EventHandler(this.btnSubmitList_Click);
            this.tabPageList.Controls.Add(this.btnSubmitList);
    
            //
            // tabPageSearch
            //
            this.tabPageSearch = new System.Windows.Forms.TabPage();
            this.tabPageSearch.Location = new System.Drawing.Point(4, 48);
            this.tabPageSearch.Name = "Search";
            this.tabPageSearch.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSearch.Size = new System.Drawing.Size(459, 373);
            this.tabPageSearch.TabIndex = 0;
            this.tabPageSearch.Text = "Search";
            this.tabPageSearch.UseVisualStyleBackColor = true;
            this.tcPages.Controls.Add(tabPageSearch);
    
            //
            // tlpSearch
            //
            this.tlpSearch = new System.Windows.Forms.TableLayoutPanel();
            this.tlpSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpSearch.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpSearch.ColumnCount = 3;
            this.tlpSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpSearch.Location = new System.Drawing.Point(17, 15);
            this.tlpSearch.Name = "tlp";
            this.tlpSearch.RowCount = 6;
            this.tlpSearch.Size = new System.Drawing.Size(400, 260);
            this.tlpSearch.TabIndex = 1;
            this.tabPageSearch.Controls.Add(this.tlpSearch);

            this.label_Search_name = new System.Windows.Forms.Label();
            this.label_Search_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Search_name.AutoSize = true;
            this.label_Search_name.Location = new System.Drawing.Point(3, 113);
            this.label_Search_name.Name = "label_Search_name";
            this.label_Search_name.Size = new System.Drawing.Size(43, 17);
            this.label_Search_name.TabIndex = 0;
            this.label_Search_name.Text = "参数名";
            this.tlpSearch.Controls.Add(this.label_Search_name, 0, 0);

            this.label_Search_value = new System.Windows.Forms.Label();
            this.label_Search_value.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Search_value.AutoSize = true;
            this.label_Search_value.Location = new System.Drawing.Point(3, 113);
            this.label_Search_value.Name = "label_Search_value";
            this.label_Search_value.Size = new System.Drawing.Size(43, 17);
            this.label_Search_value.TabIndex = 0;
            this.label_Search_value.Text = "参数值";
            this.tlpSearch.Controls.Add(this.label_Search_value, 1, 0);

            this.label_Search_remark= new System.Windows.Forms.Label();
            this.label_Search_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Search_remark.AutoSize = true;
            this.label_Search_remark.Location = new System.Drawing.Point(3, 113);
            this.label_Search_remark.Name = "label_Search_name";
            this.label_Search_remark.Size = new System.Drawing.Size(43, 17);
            this.label_Search_remark.TabIndex = 0;
            this.label_Search_remark.Text = "说明";
            this.tlpSearch.Controls.Add(this.label_Search_remark, 2, 0);
            
            //
            // label_Search_offset
            //
            this.label_Search_offset_name = new System.Windows.Forms.Label();
            this.label_Search_offset_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Search_offset_name.AutoSize = true;
            this.label_Search_offset_name.Location = new System.Drawing.Point(3, 113);
            this.label_Search_offset_name.Name = "label_Search_offset";
            this.label_Search_offset_name.Size = new System.Drawing.Size(43, 17);
            this.label_Search_offset_name.TabIndex = 0;
            this.label_Search_offset_name.Text = "offset";
            this.tlpSearch.Controls.Add(this.label_Search_offset_name, 0, 1);
    
            //
            // label_Search_offset
            //
            this.label_Search_offset_remark = new System.Windows.Forms.Label();
            this.label_Search_offset_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Search_offset_remark.AutoSize = true;
            this.label_Search_offset_remark.Location = new System.Drawing.Point(3, 113);
            this.label_Search_offset_remark.Name = "label_Search_offset";
            this.label_Search_offset_remark.Size = new System.Drawing.Size(43, 17);
            this.label_Search_offset_remark.TabIndex = 0;
            this.label_Search_offset_remark.Text = "偏移值";
            this.tlpSearch.Controls.Add(this.label_Search_offset_remark, 2, 1);
    
            //
            // tb_Search_offset
            //
            this.tb_Search_offset = new System.Windows.Forms.TextBox();
            this.tb_Search_offset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Search_offset.Location = new System.Drawing.Point(189, 50);
            this.tb_Search_offset.Name = "tb_Search_offset";
            this.tb_Search_offset.Size = new System.Drawing.Size(363, 23);
            this.tb_Search_offset.TabIndex = 1;
            this.tlpSearch.Controls.Add(this.tb_Search_offset, 1, 1);
            this.tlpSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
    
            //
            // label_Search_count
            //
            this.label_Search_count_name = new System.Windows.Forms.Label();
            this.label_Search_count_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Search_count_name.AutoSize = true;
            this.label_Search_count_name.Location = new System.Drawing.Point(3, 113);
            this.label_Search_count_name.Name = "label_Search_count";
            this.label_Search_count_name.Size = new System.Drawing.Size(43, 17);
            this.label_Search_count_name.TabIndex = 0;
            this.label_Search_count_name.Text = "count";
            this.tlpSearch.Controls.Add(this.label_Search_count_name, 0, 2);
    
            //
            // label_Search_count
            //
            this.label_Search_count_remark = new System.Windows.Forms.Label();
            this.label_Search_count_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Search_count_remark.AutoSize = true;
            this.label_Search_count_remark.Location = new System.Drawing.Point(3, 113);
            this.label_Search_count_remark.Name = "label_Search_count";
            this.label_Search_count_remark.Size = new System.Drawing.Size(43, 17);
            this.label_Search_count_remark.TabIndex = 0;
            this.label_Search_count_remark.Text = "数量";
            this.tlpSearch.Controls.Add(this.label_Search_count_remark, 2, 2);
    
            //
            // tb_Search_count
            //
            this.tb_Search_count = new System.Windows.Forms.TextBox();
            this.tb_Search_count.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Search_count.Location = new System.Drawing.Point(189, 50);
            this.tb_Search_count.Name = "tb_Search_count";
            this.tb_Search_count.Size = new System.Drawing.Size(363, 23);
            this.tb_Search_count.TabIndex = 1;
            this.tlpSearch.Controls.Add(this.tb_Search_count, 1, 2);
            this.tlpSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
    
            //
            // label_Search_bucket
            //
            this.label_Search_bucket_name = new System.Windows.Forms.Label();
            this.label_Search_bucket_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Search_bucket_name.AutoSize = true;
            this.label_Search_bucket_name.Location = new System.Drawing.Point(3, 113);
            this.label_Search_bucket_name.Name = "label_Search_bucket";
            this.label_Search_bucket_name.Size = new System.Drawing.Size(43, 17);
            this.label_Search_bucket_name.TabIndex = 0;
            this.label_Search_bucket_name.Text = "bucket";
            this.tlpSearch.Controls.Add(this.label_Search_bucket_name, 0, 3);
    
            //
            // label_Search_bucket
            //
            this.label_Search_bucket_remark = new System.Windows.Forms.Label();
            this.label_Search_bucket_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Search_bucket_remark.AutoSize = true;
            this.label_Search_bucket_remark.Location = new System.Drawing.Point(3, 113);
            this.label_Search_bucket_remark.Name = "label_Search_bucket";
            this.label_Search_bucket_remark.Size = new System.Drawing.Size(43, 17);
            this.label_Search_bucket_remark.TabIndex = 0;
            this.label_Search_bucket_remark.Text = "储存桶";
            this.tlpSearch.Controls.Add(this.label_Search_bucket_remark, 2, 3);
    
            //
            // tb_Search_bucket
            //
            this.tb_Search_bucket = new System.Windows.Forms.TextBox();
            this.tb_Search_bucket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Search_bucket.Location = new System.Drawing.Point(189, 50);
            this.tb_Search_bucket.Name = "tb_Search_bucket";
            this.tb_Search_bucket.Size = new System.Drawing.Size(363, 23);
            this.tb_Search_bucket.TabIndex = 1;
            this.tlpSearch.Controls.Add(this.tb_Search_bucket, 1, 3);
            this.tlpSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
    
            //
            // label_Search_prefix
            //
            this.label_Search_prefix_name = new System.Windows.Forms.Label();
            this.label_Search_prefix_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Search_prefix_name.AutoSize = true;
            this.label_Search_prefix_name.Location = new System.Drawing.Point(3, 113);
            this.label_Search_prefix_name.Name = "label_Search_prefix";
            this.label_Search_prefix_name.Size = new System.Drawing.Size(43, 17);
            this.label_Search_prefix_name.TabIndex = 0;
            this.label_Search_prefix_name.Text = "prefix";
            this.tlpSearch.Controls.Add(this.label_Search_prefix_name, 0, 4);
    
            //
            // label_Search_prefix
            //
            this.label_Search_prefix_remark = new System.Windows.Forms.Label();
            this.label_Search_prefix_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Search_prefix_remark.AutoSize = true;
            this.label_Search_prefix_remark.Location = new System.Drawing.Point(3, 113);
            this.label_Search_prefix_remark.Name = "label_Search_prefix";
            this.label_Search_prefix_remark.Size = new System.Drawing.Size(43, 17);
            this.label_Search_prefix_remark.TabIndex = 0;
            this.label_Search_prefix_remark.Text = "路径前缀";
            this.tlpSearch.Controls.Add(this.label_Search_prefix_remark, 2, 4);
    
            //
            // tb_Search_prefix
            //
            this.tb_Search_prefix = new System.Windows.Forms.TextBox();
            this.tb_Search_prefix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Search_prefix.Location = new System.Drawing.Point(189, 50);
            this.tb_Search_prefix.Name = "tb_Search_prefix";
            this.tb_Search_prefix.Size = new System.Drawing.Size(363, 23);
            this.tb_Search_prefix.TabIndex = 1;
            this.tlpSearch.Controls.Add(this.tb_Search_prefix, 1, 4);
            this.tlpSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
    
            //
            // btnSubmitSearch
            //
            this.btnSubmitSearch = new System.Windows.Forms.Button();
            this.btnSubmitSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSubmitSearch.Location = new System.Drawing.Point(17, 300);
            this.btnSubmitSearch.Name = "btnSubmitSearch";
            this.btnSubmitSearch.Size = new System.Drawing.Size(120, 29);
            this.btnSubmitSearch.TabIndex = 0;
            this.btnSubmitSearch.Text = "Submit";
            this.btnSubmitSearch.UseVisualStyleBackColor = true;
            this.btnSubmitSearch.Click += new System.EventHandler(this.btnSubmitSearch_Click);
            this.tabPageSearch.Controls.Add(this.btnSubmitSearch);
    
            //
            // tabPagePublish
            //
            this.tabPagePublish = new System.Windows.Forms.TabPage();
            this.tabPagePublish.Location = new System.Drawing.Point(4, 48);
            this.tabPagePublish.Name = "Publish";
            this.tabPagePublish.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePublish.Size = new System.Drawing.Size(459, 373);
            this.tabPagePublish.TabIndex = 0;
            this.tabPagePublish.Text = "Publish";
            this.tabPagePublish.UseVisualStyleBackColor = true;
            this.tcPages.Controls.Add(tabPagePublish);
    
            //
            // tlpPublish
            //
            this.tlpPublish = new System.Windows.Forms.TableLayoutPanel();
            this.tlpPublish.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpPublish.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpPublish.ColumnCount = 3;
            this.tlpPublish.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpPublish.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpPublish.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpPublish.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpPublish.Location = new System.Drawing.Point(17, 15);
            this.tlpPublish.Name = "tlp";
            this.tlpPublish.RowCount = 4;
            this.tlpPublish.Size = new System.Drawing.Size(400, 260);
            this.tlpPublish.TabIndex = 1;
            this.tabPagePublish.Controls.Add(this.tlpPublish);

            this.label_Publish_name = new System.Windows.Forms.Label();
            this.label_Publish_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Publish_name.AutoSize = true;
            this.label_Publish_name.Location = new System.Drawing.Point(3, 113);
            this.label_Publish_name.Name = "label_Publish_name";
            this.label_Publish_name.Size = new System.Drawing.Size(43, 17);
            this.label_Publish_name.TabIndex = 0;
            this.label_Publish_name.Text = "参数名";
            this.tlpPublish.Controls.Add(this.label_Publish_name, 0, 0);

            this.label_Publish_value = new System.Windows.Forms.Label();
            this.label_Publish_value.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Publish_value.AutoSize = true;
            this.label_Publish_value.Location = new System.Drawing.Point(3, 113);
            this.label_Publish_value.Name = "label_Publish_value";
            this.label_Publish_value.Size = new System.Drawing.Size(43, 17);
            this.label_Publish_value.TabIndex = 0;
            this.label_Publish_value.Text = "参数值";
            this.tlpPublish.Controls.Add(this.label_Publish_value, 1, 0);

            this.label_Publish_remark= new System.Windows.Forms.Label();
            this.label_Publish_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Publish_remark.AutoSize = true;
            this.label_Publish_remark.Location = new System.Drawing.Point(3, 113);
            this.label_Publish_remark.Name = "label_Publish_name";
            this.label_Publish_remark.Size = new System.Drawing.Size(43, 17);
            this.label_Publish_remark.TabIndex = 0;
            this.label_Publish_remark.Text = "说明";
            this.tlpPublish.Controls.Add(this.label_Publish_remark, 2, 0);
            
            //
            // label_Publish_uuid
            //
            this.label_Publish_uuid_name = new System.Windows.Forms.Label();
            this.label_Publish_uuid_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Publish_uuid_name.AutoSize = true;
            this.label_Publish_uuid_name.Location = new System.Drawing.Point(3, 113);
            this.label_Publish_uuid_name.Name = "label_Publish_uuid";
            this.label_Publish_uuid_name.Size = new System.Drawing.Size(43, 17);
            this.label_Publish_uuid_name.TabIndex = 0;
            this.label_Publish_uuid_name.Text = "uuid";
            this.tlpPublish.Controls.Add(this.label_Publish_uuid_name, 0, 1);
    
            //
            // label_Publish_uuid
            //
            this.label_Publish_uuid_remark = new System.Windows.Forms.Label();
            this.label_Publish_uuid_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Publish_uuid_remark.AutoSize = true;
            this.label_Publish_uuid_remark.Location = new System.Drawing.Point(3, 113);
            this.label_Publish_uuid_remark.Name = "label_Publish_uuid";
            this.label_Publish_uuid_remark.Size = new System.Drawing.Size(43, 17);
            this.label_Publish_uuid_remark.TabIndex = 0;
            this.label_Publish_uuid_remark.Text = "uuid";
            this.tlpPublish.Controls.Add(this.label_Publish_uuid_remark, 2, 1);
    
            //
            // tb_Publish_uuid
            //
            this.tb_Publish_uuid = new System.Windows.Forms.TextBox();
            this.tb_Publish_uuid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Publish_uuid.Location = new System.Drawing.Point(189, 50);
            this.tb_Publish_uuid.Name = "tb_Publish_uuid";
            this.tb_Publish_uuid.Size = new System.Drawing.Size(363, 23);
            this.tb_Publish_uuid.TabIndex = 1;
            this.tlpPublish.Controls.Add(this.tb_Publish_uuid, 1, 1);
            this.tlpPublish.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
    
            //
            // label_Publish_expiry
            //
            this.label_Publish_expiry_name = new System.Windows.Forms.Label();
            this.label_Publish_expiry_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Publish_expiry_name.AutoSize = true;
            this.label_Publish_expiry_name.Location = new System.Drawing.Point(3, 113);
            this.label_Publish_expiry_name.Name = "label_Publish_expiry";
            this.label_Publish_expiry_name.Size = new System.Drawing.Size(43, 17);
            this.label_Publish_expiry_name.TabIndex = 0;
            this.label_Publish_expiry_name.Text = "expiry";
            this.tlpPublish.Controls.Add(this.label_Publish_expiry_name, 0, 2);
    
            //
            // label_Publish_expiry
            //
            this.label_Publish_expiry_remark = new System.Windows.Forms.Label();
            this.label_Publish_expiry_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Publish_expiry_remark.AutoSize = true;
            this.label_Publish_expiry_remark.Location = new System.Drawing.Point(3, 113);
            this.label_Publish_expiry_remark.Name = "label_Publish_expiry";
            this.label_Publish_expiry_remark.Size = new System.Drawing.Size(43, 17);
            this.label_Publish_expiry_remark.TabIndex = 0;
            this.label_Publish_expiry_remark.Text = "有效期";
            this.tlpPublish.Controls.Add(this.label_Publish_expiry_remark, 2, 2);
    
            //
            // tb_Publish_expiry
            //
            this.tb_Publish_expiry = new System.Windows.Forms.TextBox();
            this.tb_Publish_expiry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Publish_expiry.Location = new System.Drawing.Point(189, 50);
            this.tb_Publish_expiry.Name = "tb_Publish_expiry";
            this.tb_Publish_expiry.Size = new System.Drawing.Size(363, 23);
            this.tb_Publish_expiry.TabIndex = 1;
            this.tlpPublish.Controls.Add(this.tb_Publish_expiry, 1, 2);
            this.tlpPublish.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
    
            //
            // btnSubmitPublish
            //
            this.btnSubmitPublish = new System.Windows.Forms.Button();
            this.btnSubmitPublish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSubmitPublish.Location = new System.Drawing.Point(17, 300);
            this.btnSubmitPublish.Name = "btnSubmitPublish";
            this.btnSubmitPublish.Size = new System.Drawing.Size(120, 29);
            this.btnSubmitPublish.TabIndex = 0;
            this.btnSubmitPublish.Text = "Submit";
            this.btnSubmitPublish.UseVisualStyleBackColor = true;
            this.btnSubmitPublish.Click += new System.EventHandler(this.btnSubmitPublish_Click);
            this.tabPagePublish.Controls.Add(this.btnSubmitPublish);
    
            //
            // tabPagePreview
            //
            this.tabPagePreview = new System.Windows.Forms.TabPage();
            this.tabPagePreview.Location = new System.Drawing.Point(4, 48);
            this.tabPagePreview.Name = "Preview";
            this.tabPagePreview.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePreview.Size = new System.Drawing.Size(459, 373);
            this.tabPagePreview.TabIndex = 0;
            this.tabPagePreview.Text = "Preview";
            this.tabPagePreview.UseVisualStyleBackColor = true;
            this.tcPages.Controls.Add(tabPagePreview);
    
            //
            // tlpPreview
            //
            this.tlpPreview = new System.Windows.Forms.TableLayoutPanel();
            this.tlpPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpPreview.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpPreview.ColumnCount = 3;
            this.tlpPreview.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpPreview.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpPreview.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpPreview.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpPreview.Location = new System.Drawing.Point(17, 15);
            this.tlpPreview.Name = "tlp";
            this.tlpPreview.RowCount = 3;
            this.tlpPreview.Size = new System.Drawing.Size(400, 260);
            this.tlpPreview.TabIndex = 1;
            this.tabPagePreview.Controls.Add(this.tlpPreview);

            this.label_Preview_name = new System.Windows.Forms.Label();
            this.label_Preview_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Preview_name.AutoSize = true;
            this.label_Preview_name.Location = new System.Drawing.Point(3, 113);
            this.label_Preview_name.Name = "label_Preview_name";
            this.label_Preview_name.Size = new System.Drawing.Size(43, 17);
            this.label_Preview_name.TabIndex = 0;
            this.label_Preview_name.Text = "参数名";
            this.tlpPreview.Controls.Add(this.label_Preview_name, 0, 0);

            this.label_Preview_value = new System.Windows.Forms.Label();
            this.label_Preview_value.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Preview_value.AutoSize = true;
            this.label_Preview_value.Location = new System.Drawing.Point(3, 113);
            this.label_Preview_value.Name = "label_Preview_value";
            this.label_Preview_value.Size = new System.Drawing.Size(43, 17);
            this.label_Preview_value.TabIndex = 0;
            this.label_Preview_value.Text = "参数值";
            this.tlpPreview.Controls.Add(this.label_Preview_value, 1, 0);

            this.label_Preview_remark= new System.Windows.Forms.Label();
            this.label_Preview_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Preview_remark.AutoSize = true;
            this.label_Preview_remark.Location = new System.Drawing.Point(3, 113);
            this.label_Preview_remark.Name = "label_Preview_name";
            this.label_Preview_remark.Size = new System.Drawing.Size(43, 17);
            this.label_Preview_remark.TabIndex = 0;
            this.label_Preview_remark.Text = "说明";
            this.tlpPreview.Controls.Add(this.label_Preview_remark, 2, 0);
            
            //
            // label_Preview_uuid
            //
            this.label_Preview_uuid_name = new System.Windows.Forms.Label();
            this.label_Preview_uuid_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Preview_uuid_name.AutoSize = true;
            this.label_Preview_uuid_name.Location = new System.Drawing.Point(3, 113);
            this.label_Preview_uuid_name.Name = "label_Preview_uuid";
            this.label_Preview_uuid_name.Size = new System.Drawing.Size(43, 17);
            this.label_Preview_uuid_name.TabIndex = 0;
            this.label_Preview_uuid_name.Text = "uuid";
            this.tlpPreview.Controls.Add(this.label_Preview_uuid_name, 0, 1);
    
            //
            // label_Preview_uuid
            //
            this.label_Preview_uuid_remark = new System.Windows.Forms.Label();
            this.label_Preview_uuid_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Preview_uuid_remark.AutoSize = true;
            this.label_Preview_uuid_remark.Location = new System.Drawing.Point(3, 113);
            this.label_Preview_uuid_remark.Name = "label_Preview_uuid";
            this.label_Preview_uuid_remark.Size = new System.Drawing.Size(43, 17);
            this.label_Preview_uuid_remark.TabIndex = 0;
            this.label_Preview_uuid_remark.Text = "uuid";
            this.tlpPreview.Controls.Add(this.label_Preview_uuid_remark, 2, 1);
    
            //
            // tb_Preview_uuid
            //
            this.tb_Preview_uuid = new System.Windows.Forms.TextBox();
            this.tb_Preview_uuid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Preview_uuid.Location = new System.Drawing.Point(189, 50);
            this.tb_Preview_uuid.Name = "tb_Preview_uuid";
            this.tb_Preview_uuid.Size = new System.Drawing.Size(363, 23);
            this.tb_Preview_uuid.TabIndex = 1;
            this.tlpPreview.Controls.Add(this.tb_Preview_uuid, 1, 1);
            this.tlpPreview.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
    
            //
            // btnSubmitPreview
            //
            this.btnSubmitPreview = new System.Windows.Forms.Button();
            this.btnSubmitPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSubmitPreview.Location = new System.Drawing.Point(17, 300);
            this.btnSubmitPreview.Name = "btnSubmitPreview";
            this.btnSubmitPreview.Size = new System.Drawing.Size(120, 29);
            this.btnSubmitPreview.TabIndex = 0;
            this.btnSubmitPreview.Text = "Submit";
            this.btnSubmitPreview.UseVisualStyleBackColor = true;
            this.btnSubmitPreview.Click += new System.EventHandler(this.btnSubmitPreview_Click);
            this.tabPagePreview.Controls.Add(this.btnSubmitPreview);
    
            //
            // tabPageRetract
            //
            this.tabPageRetract = new System.Windows.Forms.TabPage();
            this.tabPageRetract.Location = new System.Drawing.Point(4, 48);
            this.tabPageRetract.Name = "Retract";
            this.tabPageRetract.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRetract.Size = new System.Drawing.Size(459, 373);
            this.tabPageRetract.TabIndex = 0;
            this.tabPageRetract.Text = "Retract";
            this.tabPageRetract.UseVisualStyleBackColor = true;
            this.tcPages.Controls.Add(tabPageRetract);
    
            //
            // tlpRetract
            //
            this.tlpRetract = new System.Windows.Forms.TableLayoutPanel();
            this.tlpRetract.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpRetract.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpRetract.ColumnCount = 3;
            this.tlpRetract.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpRetract.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpRetract.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpRetract.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpRetract.Location = new System.Drawing.Point(17, 15);
            this.tlpRetract.Name = "tlp";
            this.tlpRetract.RowCount = 3;
            this.tlpRetract.Size = new System.Drawing.Size(400, 260);
            this.tlpRetract.TabIndex = 1;
            this.tabPageRetract.Controls.Add(this.tlpRetract);

            this.label_Retract_name = new System.Windows.Forms.Label();
            this.label_Retract_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Retract_name.AutoSize = true;
            this.label_Retract_name.Location = new System.Drawing.Point(3, 113);
            this.label_Retract_name.Name = "label_Retract_name";
            this.label_Retract_name.Size = new System.Drawing.Size(43, 17);
            this.label_Retract_name.TabIndex = 0;
            this.label_Retract_name.Text = "参数名";
            this.tlpRetract.Controls.Add(this.label_Retract_name, 0, 0);

            this.label_Retract_value = new System.Windows.Forms.Label();
            this.label_Retract_value.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Retract_value.AutoSize = true;
            this.label_Retract_value.Location = new System.Drawing.Point(3, 113);
            this.label_Retract_value.Name = "label_Retract_value";
            this.label_Retract_value.Size = new System.Drawing.Size(43, 17);
            this.label_Retract_value.TabIndex = 0;
            this.label_Retract_value.Text = "参数值";
            this.tlpRetract.Controls.Add(this.label_Retract_value, 1, 0);

            this.label_Retract_remark= new System.Windows.Forms.Label();
            this.label_Retract_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Retract_remark.AutoSize = true;
            this.label_Retract_remark.Location = new System.Drawing.Point(3, 113);
            this.label_Retract_remark.Name = "label_Retract_name";
            this.label_Retract_remark.Size = new System.Drawing.Size(43, 17);
            this.label_Retract_remark.TabIndex = 0;
            this.label_Retract_remark.Text = "说明";
            this.tlpRetract.Controls.Add(this.label_Retract_remark, 2, 0);
            
            //
            // label_Retract_uuid
            //
            this.label_Retract_uuid_name = new System.Windows.Forms.Label();
            this.label_Retract_uuid_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Retract_uuid_name.AutoSize = true;
            this.label_Retract_uuid_name.Location = new System.Drawing.Point(3, 113);
            this.label_Retract_uuid_name.Name = "label_Retract_uuid";
            this.label_Retract_uuid_name.Size = new System.Drawing.Size(43, 17);
            this.label_Retract_uuid_name.TabIndex = 0;
            this.label_Retract_uuid_name.Text = "uuid";
            this.tlpRetract.Controls.Add(this.label_Retract_uuid_name, 0, 1);
    
            //
            // label_Retract_uuid
            //
            this.label_Retract_uuid_remark = new System.Windows.Forms.Label();
            this.label_Retract_uuid_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Retract_uuid_remark.AutoSize = true;
            this.label_Retract_uuid_remark.Location = new System.Drawing.Point(3, 113);
            this.label_Retract_uuid_remark.Name = "label_Retract_uuid";
            this.label_Retract_uuid_remark.Size = new System.Drawing.Size(43, 17);
            this.label_Retract_uuid_remark.TabIndex = 0;
            this.label_Retract_uuid_remark.Text = "uuid";
            this.tlpRetract.Controls.Add(this.label_Retract_uuid_remark, 2, 1);
    
            //
            // tb_Retract_uuid
            //
            this.tb_Retract_uuid = new System.Windows.Forms.TextBox();
            this.tb_Retract_uuid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Retract_uuid.Location = new System.Drawing.Point(189, 50);
            this.tb_Retract_uuid.Name = "tb_Retract_uuid";
            this.tb_Retract_uuid.Size = new System.Drawing.Size(363, 23);
            this.tb_Retract_uuid.TabIndex = 1;
            this.tlpRetract.Controls.Add(this.tb_Retract_uuid, 1, 1);
            this.tlpRetract.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
    
            //
            // btnSubmitRetract
            //
            this.btnSubmitRetract = new System.Windows.Forms.Button();
            this.btnSubmitRetract.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSubmitRetract.Location = new System.Drawing.Point(17, 300);
            this.btnSubmitRetract.Name = "btnSubmitRetract";
            this.btnSubmitRetract.Size = new System.Drawing.Size(120, 29);
            this.btnSubmitRetract.TabIndex = 0;
            this.btnSubmitRetract.Text = "Submit";
            this.btnSubmitRetract.UseVisualStyleBackColor = true;
            this.btnSubmitRetract.Click += new System.EventHandler(this.btnSubmitRetract_Click);
            this.tabPageRetract.Controls.Add(this.btnSubmitRetract);
    

            //
            // ObjectPanel
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

        private System.Windows.Forms.TabPage tabPagePrepare;
    
        private System.Windows.Forms.TableLayoutPanel tlpPrepare;
        private System.Windows.Forms.Label label_Prepare_name;
        private System.Windows.Forms.Label label_Prepare_value;
        private System.Windows.Forms.Label label_Prepare_remark;
    
        private System.Windows.Forms.Label label_Prepare_bucket_name;
    
        private System.Windows.Forms.Label label_Prepare_bucket_remark;
    
        private System.Windows.Forms.TextBox tb_Prepare_bucket;
    
        private System.Windows.Forms.Label label_Prepare_uname_name;
    
        private System.Windows.Forms.Label label_Prepare_uname_remark;
    
        private System.Windows.Forms.TextBox tb_Prepare_uname;
    
        private System.Windows.Forms.Label label_Prepare_size_name;
    
        private System.Windows.Forms.Label label_Prepare_size_remark;
    
        private System.Windows.Forms.TextBox tb_Prepare_size;
    
        private System.Windows.Forms.Button btnSubmitPrepare;
        private void btnSubmitPrepare_Click(object sender, System.EventArgs e)
        {
            IObjectViewBridge bridge =  facade.getViewBridge() as IObjectViewBridge;
            
            string bucket = this.tb_Prepare_bucket.Text;
    
            string uname = this.tb_Prepare_uname.Text;
    
            long size;
            long.TryParse(this.tb_Prepare_size.Text, out size);
    
            bridge.OnPrepareSubmit(bucket, uname, size);
        }
    
        private System.Windows.Forms.TabPage tabPageFlush;
    
        private System.Windows.Forms.TableLayoutPanel tlpFlush;
        private System.Windows.Forms.Label label_Flush_name;
        private System.Windows.Forms.Label label_Flush_value;
        private System.Windows.Forms.Label label_Flush_remark;
    
        private System.Windows.Forms.Label label_Flush_bucket_name;
    
        private System.Windows.Forms.Label label_Flush_bucket_remark;
    
        private System.Windows.Forms.TextBox tb_Flush_bucket;
    
        private System.Windows.Forms.Label label_Flush_uname_name;
    
        private System.Windows.Forms.Label label_Flush_uname_remark;
    
        private System.Windows.Forms.TextBox tb_Flush_uname;
    
        private System.Windows.Forms.Label label_Flush_path_name;
    
        private System.Windows.Forms.Label label_Flush_path_remark;
    
        private System.Windows.Forms.TextBox tb_Flush_path;
    
        private System.Windows.Forms.Button btnSubmitFlush;
        private void btnSubmitFlush_Click(object sender, System.EventArgs e)
        {
            IObjectViewBridge bridge =  facade.getViewBridge() as IObjectViewBridge;
            
            string bucket = this.tb_Flush_bucket.Text;
    
            string uname = this.tb_Flush_uname.Text;
    
            string path = this.tb_Flush_path.Text;
    
            bridge.OnFlushSubmit(bucket, uname, path);
        }
    
        private System.Windows.Forms.TabPage tabPageLink;
    
        private System.Windows.Forms.TableLayoutPanel tlpLink;
        private System.Windows.Forms.Label label_Link_name;
        private System.Windows.Forms.Label label_Link_value;
        private System.Windows.Forms.Label label_Link_remark;
    
        private System.Windows.Forms.Label label_Link_bucket_name;
    
        private System.Windows.Forms.Label label_Link_bucket_remark;
    
        private System.Windows.Forms.TextBox tb_Link_bucket;
    
        private System.Windows.Forms.Label label_Link_filepath_name;
    
        private System.Windows.Forms.Label label_Link_filepath_remark;
    
        private System.Windows.Forms.TextBox tb_Link_filepath;
    
        private System.Windows.Forms.Label label_Link_url_name;
    
        private System.Windows.Forms.Label label_Link_url_remark;
    
        private System.Windows.Forms.TextBox tb_Link_url;
    
        private System.Windows.Forms.Label label_Link_overwrite_name;
    
        private System.Windows.Forms.Label label_Link_overwrite_remark;
    
        private System.Windows.Forms.TextBox tb_Link_overwrite;
    
        private System.Windows.Forms.Button btnSubmitLink;
        private void btnSubmitLink_Click(object sender, System.EventArgs e)
        {
            IObjectViewBridge bridge =  facade.getViewBridge() as IObjectViewBridge;
            
            string bucket = this.tb_Link_bucket.Text;
    
            string filepath = this.tb_Link_filepath.Text;
    
            string url = this.tb_Link_url.Text;
    
            bool overwrite;
            bool.TryParse(this.tb_Link_overwrite.Text, out overwrite);
    
            bridge.OnLinkSubmit(bucket, filepath, url, overwrite);
        }
    
        private System.Windows.Forms.TabPage tabPageGet;
    
        private System.Windows.Forms.TableLayoutPanel tlpGet;
        private System.Windows.Forms.Label label_Get_name;
        private System.Windows.Forms.Label label_Get_value;
        private System.Windows.Forms.Label label_Get_remark;
    
        private System.Windows.Forms.Label label_Get_uuid_name;
    
        private System.Windows.Forms.Label label_Get_uuid_remark;
    
        private System.Windows.Forms.TextBox tb_Get_uuid;
    
        private System.Windows.Forms.Button btnSubmitGet;
        private void btnSubmitGet_Click(object sender, System.EventArgs e)
        {
            IObjectViewBridge bridge =  facade.getViewBridge() as IObjectViewBridge;
            
            string uuid = this.tb_Get_uuid.Text;
    
            bridge.OnGetSubmit(uuid);
        }
    
        private System.Windows.Forms.TabPage tabPageFind;
    
        private System.Windows.Forms.TableLayoutPanel tlpFind;
        private System.Windows.Forms.Label label_Find_name;
        private System.Windows.Forms.Label label_Find_value;
        private System.Windows.Forms.Label label_Find_remark;
    
        private System.Windows.Forms.Label label_Find_bucket_name;
    
        private System.Windows.Forms.Label label_Find_bucket_remark;
    
        private System.Windows.Forms.TextBox tb_Find_bucket;
    
        private System.Windows.Forms.Label label_Find_filepath_name;
    
        private System.Windows.Forms.Label label_Find_filepath_remark;
    
        private System.Windows.Forms.TextBox tb_Find_filepath;
    
        private System.Windows.Forms.Button btnSubmitFind;
        private void btnSubmitFind_Click(object sender, System.EventArgs e)
        {
            IObjectViewBridge bridge =  facade.getViewBridge() as IObjectViewBridge;
            
            string bucket = this.tb_Find_bucket.Text;
    
            string filepath = this.tb_Find_filepath.Text;
    
            bridge.OnFindSubmit(bucket, filepath);
        }
    
        private System.Windows.Forms.TabPage tabPageRemove;
    
        private System.Windows.Forms.TableLayoutPanel tlpRemove;
        private System.Windows.Forms.Label label_Remove_name;
        private System.Windows.Forms.Label label_Remove_value;
        private System.Windows.Forms.Label label_Remove_remark;
    
        private System.Windows.Forms.Label label_Remove_uuid_name;
    
        private System.Windows.Forms.Label label_Remove_uuid_remark;
    
        private System.Windows.Forms.TextBox tb_Remove_uuid;
    
        private System.Windows.Forms.Button btnSubmitRemove;
        private void btnSubmitRemove_Click(object sender, System.EventArgs e)
        {
            IObjectViewBridge bridge =  facade.getViewBridge() as IObjectViewBridge;
            
            string uuid = this.tb_Remove_uuid.Text;
    
            bridge.OnRemoveSubmit(uuid);
        }
    
        private System.Windows.Forms.TabPage tabPageList;
    
        private System.Windows.Forms.TableLayoutPanel tlpList;
        private System.Windows.Forms.Label label_List_name;
        private System.Windows.Forms.Label label_List_value;
        private System.Windows.Forms.Label label_List_remark;
    
        private System.Windows.Forms.Label label_List_offset_name;
    
        private System.Windows.Forms.Label label_List_offset_remark;
    
        private System.Windows.Forms.TextBox tb_List_offset;
    
        private System.Windows.Forms.Label label_List_count_name;
    
        private System.Windows.Forms.Label label_List_count_remark;
    
        private System.Windows.Forms.TextBox tb_List_count;
    
        private System.Windows.Forms.Label label_List_bucket_name;
    
        private System.Windows.Forms.Label label_List_bucket_remark;
    
        private System.Windows.Forms.TextBox tb_List_bucket;
    
        private System.Windows.Forms.Button btnSubmitList;
        private void btnSubmitList_Click(object sender, System.EventArgs e)
        {
            IObjectViewBridge bridge =  facade.getViewBridge() as IObjectViewBridge;
            
            long offset;
            long.TryParse(this.tb_List_offset.Text, out offset);
    
            long count;
            long.TryParse(this.tb_List_count.Text, out count);
    
            string bucket = this.tb_List_bucket.Text;
    
            bridge.OnListSubmit(offset, count, bucket);
        }
    
        private System.Windows.Forms.TabPage tabPageSearch;
    
        private System.Windows.Forms.TableLayoutPanel tlpSearch;
        private System.Windows.Forms.Label label_Search_name;
        private System.Windows.Forms.Label label_Search_value;
        private System.Windows.Forms.Label label_Search_remark;
    
        private System.Windows.Forms.Label label_Search_offset_name;
    
        private System.Windows.Forms.Label label_Search_offset_remark;
    
        private System.Windows.Forms.TextBox tb_Search_offset;
    
        private System.Windows.Forms.Label label_Search_count_name;
    
        private System.Windows.Forms.Label label_Search_count_remark;
    
        private System.Windows.Forms.TextBox tb_Search_count;
    
        private System.Windows.Forms.Label label_Search_bucket_name;
    
        private System.Windows.Forms.Label label_Search_bucket_remark;
    
        private System.Windows.Forms.TextBox tb_Search_bucket;
    
        private System.Windows.Forms.Label label_Search_prefix_name;
    
        private System.Windows.Forms.Label label_Search_prefix_remark;
    
        private System.Windows.Forms.TextBox tb_Search_prefix;
    
        private System.Windows.Forms.Button btnSubmitSearch;
        private void btnSubmitSearch_Click(object sender, System.EventArgs e)
        {
            IObjectViewBridge bridge =  facade.getViewBridge() as IObjectViewBridge;
            
            long offset;
            long.TryParse(this.tb_Search_offset.Text, out offset);
    
            long count;
            long.TryParse(this.tb_Search_count.Text, out count);
    
            string bucket = this.tb_Search_bucket.Text;
    
            string prefix = this.tb_Search_prefix.Text;
    
            bridge.OnSearchSubmit(offset, count, bucket, prefix);
        }
    
        private System.Windows.Forms.TabPage tabPagePublish;
    
        private System.Windows.Forms.TableLayoutPanel tlpPublish;
        private System.Windows.Forms.Label label_Publish_name;
        private System.Windows.Forms.Label label_Publish_value;
        private System.Windows.Forms.Label label_Publish_remark;
    
        private System.Windows.Forms.Label label_Publish_uuid_name;
    
        private System.Windows.Forms.Label label_Publish_uuid_remark;
    
        private System.Windows.Forms.TextBox tb_Publish_uuid;
    
        private System.Windows.Forms.Label label_Publish_expiry_name;
    
        private System.Windows.Forms.Label label_Publish_expiry_remark;
    
        private System.Windows.Forms.TextBox tb_Publish_expiry;
    
        private System.Windows.Forms.Button btnSubmitPublish;
        private void btnSubmitPublish_Click(object sender, System.EventArgs e)
        {
            IObjectViewBridge bridge =  facade.getViewBridge() as IObjectViewBridge;
            
            string uuid = this.tb_Publish_uuid.Text;
    
            long expiry;
            long.TryParse(this.tb_Publish_expiry.Text, out expiry);
    
            bridge.OnPublishSubmit(uuid, expiry);
        }
    
        private System.Windows.Forms.TabPage tabPagePreview;
    
        private System.Windows.Forms.TableLayoutPanel tlpPreview;
        private System.Windows.Forms.Label label_Preview_name;
        private System.Windows.Forms.Label label_Preview_value;
        private System.Windows.Forms.Label label_Preview_remark;
    
        private System.Windows.Forms.Label label_Preview_uuid_name;
    
        private System.Windows.Forms.Label label_Preview_uuid_remark;
    
        private System.Windows.Forms.TextBox tb_Preview_uuid;
    
        private System.Windows.Forms.Button btnSubmitPreview;
        private void btnSubmitPreview_Click(object sender, System.EventArgs e)
        {
            IObjectViewBridge bridge =  facade.getViewBridge() as IObjectViewBridge;
            
            string uuid = this.tb_Preview_uuid.Text;
    
            bridge.OnPreviewSubmit(uuid);
        }
    
        private System.Windows.Forms.TabPage tabPageRetract;
    
        private System.Windows.Forms.TableLayoutPanel tlpRetract;
        private System.Windows.Forms.Label label_Retract_name;
        private System.Windows.Forms.Label label_Retract_value;
        private System.Windows.Forms.Label label_Retract_remark;
    
        private System.Windows.Forms.Label label_Retract_uuid_name;
    
        private System.Windows.Forms.Label label_Retract_uuid_remark;
    
        private System.Windows.Forms.TextBox tb_Retract_uuid;
    
        private System.Windows.Forms.Button btnSubmitRetract;
        private void btnSubmitRetract_Click(object sender, System.EventArgs e)
        {
            IObjectViewBridge bridge =  facade.getViewBridge() as IObjectViewBridge;
            
            string uuid = this.tb_Retract_uuid.Text;
    
            bridge.OnRetractSubmit(uuid);
        }
    
    }
}
