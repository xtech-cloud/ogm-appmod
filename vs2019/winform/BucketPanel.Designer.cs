

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
            // tlpMake
            //
            this.tlpMake = new System.Windows.Forms.TableLayoutPanel();
            this.tlpMake.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpMake.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpMake.ColumnCount = 3;
            this.tlpMake.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpMake.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpMake.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpMake.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpMake.Location = new System.Drawing.Point(17, 15);
            this.tlpMake.Name = "tlp";
            this.tlpMake.RowCount = 9;
            this.tlpMake.Size = new System.Drawing.Size(400, 260);
            this.tlpMake.TabIndex = 1;
            this.tabPageMake.Controls.Add(this.tlpMake);

            this.label_Make_name = new System.Windows.Forms.Label();
            this.label_Make_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Make_name.AutoSize = true;
            this.label_Make_name.Location = new System.Drawing.Point(3, 113);
            this.label_Make_name.Name = "label_Make_name";
            this.label_Make_name.Size = new System.Drawing.Size(43, 17);
            this.label_Make_name.TabIndex = 0;
            this.label_Make_name.Text = "参数名";
            this.tlpMake.Controls.Add(this.label_Make_name, 0, 0);

            this.label_Make_value = new System.Windows.Forms.Label();
            this.label_Make_value.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Make_value.AutoSize = true;
            this.label_Make_value.Location = new System.Drawing.Point(3, 113);
            this.label_Make_value.Name = "label_Make_value";
            this.label_Make_value.Size = new System.Drawing.Size(43, 17);
            this.label_Make_value.TabIndex = 0;
            this.label_Make_value.Text = "参数值";
            this.tlpMake.Controls.Add(this.label_Make_value, 1, 0);

            this.label_Make_remark= new System.Windows.Forms.Label();
            this.label_Make_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Make_remark.AutoSize = true;
            this.label_Make_remark.Location = new System.Drawing.Point(3, 113);
            this.label_Make_remark.Name = "label_Make_name";
            this.label_Make_remark.Size = new System.Drawing.Size(43, 17);
            this.label_Make_remark.TabIndex = 0;
            this.label_Make_remark.Text = "说明";
            this.tlpMake.Controls.Add(this.label_Make_remark, 2, 0);
            
            //
            // label_Make_name
            //
            this.label_Make_name_name = new System.Windows.Forms.Label();
            this.label_Make_name_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Make_name_name.AutoSize = true;
            this.label_Make_name_name.Location = new System.Drawing.Point(3, 113);
            this.label_Make_name_name.Name = "label_Make_name";
            this.label_Make_name_name.Size = new System.Drawing.Size(43, 17);
            this.label_Make_name_name.TabIndex = 0;
            this.label_Make_name_name.Text = "name";
            this.tlpMake.Controls.Add(this.label_Make_name_name, 0, 1);
    
            //
            // label_Make_name
            //
            this.label_Make_name_remark = new System.Windows.Forms.Label();
            this.label_Make_name_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Make_name_remark.AutoSize = true;
            this.label_Make_name_remark.Location = new System.Drawing.Point(3, 113);
            this.label_Make_name_remark.Name = "label_Make_name";
            this.label_Make_name_remark.Size = new System.Drawing.Size(43, 17);
            this.label_Make_name_remark.TabIndex = 0;
            this.label_Make_name_remark.Text = "名称";
            this.tlpMake.Controls.Add(this.label_Make_name_remark, 2, 1);
    
            //
            // tb_Make_name
            //
            this.tb_Make_name = new System.Windows.Forms.TextBox();
            this.tb_Make_name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Make_name.Location = new System.Drawing.Point(189, 50);
            this.tb_Make_name.Name = "tb_Make_name";
            this.tb_Make_name.Size = new System.Drawing.Size(363, 23);
            this.tb_Make_name.TabIndex = 1;
            this.tlpMake.Controls.Add(this.tb_Make_name, 1, 1);
            this.tlpMake.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
    
            //
            // label_Make_capacity
            //
            this.label_Make_capacity_name = new System.Windows.Forms.Label();
            this.label_Make_capacity_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Make_capacity_name.AutoSize = true;
            this.label_Make_capacity_name.Location = new System.Drawing.Point(3, 113);
            this.label_Make_capacity_name.Name = "label_Make_capacity";
            this.label_Make_capacity_name.Size = new System.Drawing.Size(43, 17);
            this.label_Make_capacity_name.TabIndex = 0;
            this.label_Make_capacity_name.Text = "capacity";
            this.tlpMake.Controls.Add(this.label_Make_capacity_name, 0, 2);
    
            //
            // label_Make_capacity
            //
            this.label_Make_capacity_remark = new System.Windows.Forms.Label();
            this.label_Make_capacity_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Make_capacity_remark.AutoSize = true;
            this.label_Make_capacity_remark.Location = new System.Drawing.Point(3, 113);
            this.label_Make_capacity_remark.Name = "label_Make_capacity";
            this.label_Make_capacity_remark.Size = new System.Drawing.Size(43, 17);
            this.label_Make_capacity_remark.TabIndex = 0;
            this.label_Make_capacity_remark.Text = "初始容量";
            this.tlpMake.Controls.Add(this.label_Make_capacity_remark, 2, 2);
    
            //
            // tb_Make_capacity
            //
            this.tb_Make_capacity = new System.Windows.Forms.TextBox();
            this.tb_Make_capacity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Make_capacity.Location = new System.Drawing.Point(189, 50);
            this.tb_Make_capacity.Name = "tb_Make_capacity";
            this.tb_Make_capacity.Size = new System.Drawing.Size(363, 23);
            this.tb_Make_capacity.TabIndex = 1;
            this.tlpMake.Controls.Add(this.tb_Make_capacity, 1, 2);
            this.tlpMake.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
    
            //
            // label_Make_engine
            //
            this.label_Make_engine_name = new System.Windows.Forms.Label();
            this.label_Make_engine_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Make_engine_name.AutoSize = true;
            this.label_Make_engine_name.Location = new System.Drawing.Point(3, 113);
            this.label_Make_engine_name.Name = "label_Make_engine";
            this.label_Make_engine_name.Size = new System.Drawing.Size(43, 17);
            this.label_Make_engine_name.TabIndex = 0;
            this.label_Make_engine_name.Text = "engine";
            this.tlpMake.Controls.Add(this.label_Make_engine_name, 0, 3);
    
            //
            // label_Make_engine
            //
            this.label_Make_engine_remark = new System.Windows.Forms.Label();
            this.label_Make_engine_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Make_engine_remark.AutoSize = true;
            this.label_Make_engine_remark.Location = new System.Drawing.Point(3, 113);
            this.label_Make_engine_remark.Name = "label_Make_engine";
            this.label_Make_engine_remark.Size = new System.Drawing.Size(43, 17);
            this.label_Make_engine_remark.TabIndex = 0;
            this.label_Make_engine_remark.Text = "存储引擎";
            this.tlpMake.Controls.Add(this.label_Make_engine_remark, 2, 3);
    
            //
            // tb_Make_engine
            //
            this.tb_Make_engine = new System.Windows.Forms.TextBox();
            this.tb_Make_engine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Make_engine.Location = new System.Drawing.Point(189, 50);
            this.tb_Make_engine.Name = "tb_Make_engine";
            this.tb_Make_engine.Size = new System.Drawing.Size(363, 23);
            this.tb_Make_engine.TabIndex = 1;
            this.tlpMake.Controls.Add(this.tb_Make_engine, 1, 3);
            this.tlpMake.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
    
            //
            // label_Make_address
            //
            this.label_Make_address_name = new System.Windows.Forms.Label();
            this.label_Make_address_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Make_address_name.AutoSize = true;
            this.label_Make_address_name.Location = new System.Drawing.Point(3, 113);
            this.label_Make_address_name.Name = "label_Make_address";
            this.label_Make_address_name.Size = new System.Drawing.Size(43, 17);
            this.label_Make_address_name.TabIndex = 0;
            this.label_Make_address_name.Text = "address";
            this.tlpMake.Controls.Add(this.label_Make_address_name, 0, 4);
    
            //
            // label_Make_address
            //
            this.label_Make_address_remark = new System.Windows.Forms.Label();
            this.label_Make_address_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Make_address_remark.AutoSize = true;
            this.label_Make_address_remark.Location = new System.Drawing.Point(3, 113);
            this.label_Make_address_remark.Name = "label_Make_address";
            this.label_Make_address_remark.Size = new System.Drawing.Size(43, 17);
            this.label_Make_address_remark.TabIndex = 0;
            this.label_Make_address_remark.Text = "存储引擎的地址";
            this.tlpMake.Controls.Add(this.label_Make_address_remark, 2, 4);
    
            //
            // tb_Make_address
            //
            this.tb_Make_address = new System.Windows.Forms.TextBox();
            this.tb_Make_address.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Make_address.Location = new System.Drawing.Point(189, 50);
            this.tb_Make_address.Name = "tb_Make_address";
            this.tb_Make_address.Size = new System.Drawing.Size(363, 23);
            this.tb_Make_address.TabIndex = 1;
            this.tlpMake.Controls.Add(this.tb_Make_address, 1, 4);
            this.tlpMake.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
    
            //
            // label_Make_scope
            //
            this.label_Make_scope_name = new System.Windows.Forms.Label();
            this.label_Make_scope_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Make_scope_name.AutoSize = true;
            this.label_Make_scope_name.Location = new System.Drawing.Point(3, 113);
            this.label_Make_scope_name.Name = "label_Make_scope";
            this.label_Make_scope_name.Size = new System.Drawing.Size(43, 17);
            this.label_Make_scope_name.TabIndex = 0;
            this.label_Make_scope_name.Text = "scope";
            this.tlpMake.Controls.Add(this.label_Make_scope_name, 0, 5);
    
            //
            // label_Make_scope
            //
            this.label_Make_scope_remark = new System.Windows.Forms.Label();
            this.label_Make_scope_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Make_scope_remark.AutoSize = true;
            this.label_Make_scope_remark.Location = new System.Drawing.Point(3, 113);
            this.label_Make_scope_remark.Name = "label_Make_scope";
            this.label_Make_scope_remark.Size = new System.Drawing.Size(43, 17);
            this.label_Make_scope_remark.TabIndex = 0;
            this.label_Make_scope_remark.Text = "存储引擎的作用范围";
            this.tlpMake.Controls.Add(this.label_Make_scope_remark, 2, 5);
    
            //
            // tb_Make_scope
            //
            this.tb_Make_scope = new System.Windows.Forms.TextBox();
            this.tb_Make_scope.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Make_scope.Location = new System.Drawing.Point(189, 50);
            this.tb_Make_scope.Name = "tb_Make_scope";
            this.tb_Make_scope.Size = new System.Drawing.Size(363, 23);
            this.tb_Make_scope.TabIndex = 1;
            this.tlpMake.Controls.Add(this.tb_Make_scope, 1, 5);
            this.tlpMake.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
    
            //
            // label_Make_accessKey
            //
            this.label_Make_accessKey_name = new System.Windows.Forms.Label();
            this.label_Make_accessKey_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Make_accessKey_name.AutoSize = true;
            this.label_Make_accessKey_name.Location = new System.Drawing.Point(3, 113);
            this.label_Make_accessKey_name.Name = "label_Make_accessKey";
            this.label_Make_accessKey_name.Size = new System.Drawing.Size(43, 17);
            this.label_Make_accessKey_name.TabIndex = 0;
            this.label_Make_accessKey_name.Text = "accessKey";
            this.tlpMake.Controls.Add(this.label_Make_accessKey_name, 0, 6);
    
            //
            // label_Make_accessKey
            //
            this.label_Make_accessKey_remark = new System.Windows.Forms.Label();
            this.label_Make_accessKey_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Make_accessKey_remark.AutoSize = true;
            this.label_Make_accessKey_remark.Location = new System.Drawing.Point(3, 113);
            this.label_Make_accessKey_remark.Name = "label_Make_accessKey";
            this.label_Make_accessKey_remark.Size = new System.Drawing.Size(43, 17);
            this.label_Make_accessKey_remark.TabIndex = 0;
            this.label_Make_accessKey_remark.Text = "存储引擎的访问key";
            this.tlpMake.Controls.Add(this.label_Make_accessKey_remark, 2, 6);
    
            //
            // tb_Make_accessKey
            //
            this.tb_Make_accessKey = new System.Windows.Forms.TextBox();
            this.tb_Make_accessKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Make_accessKey.Location = new System.Drawing.Point(189, 50);
            this.tb_Make_accessKey.Name = "tb_Make_accessKey";
            this.tb_Make_accessKey.Size = new System.Drawing.Size(363, 23);
            this.tb_Make_accessKey.TabIndex = 1;
            this.tlpMake.Controls.Add(this.tb_Make_accessKey, 1, 6);
            this.tlpMake.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
    
            //
            // label_Make_accessSecret
            //
            this.label_Make_accessSecret_name = new System.Windows.Forms.Label();
            this.label_Make_accessSecret_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Make_accessSecret_name.AutoSize = true;
            this.label_Make_accessSecret_name.Location = new System.Drawing.Point(3, 113);
            this.label_Make_accessSecret_name.Name = "label_Make_accessSecret";
            this.label_Make_accessSecret_name.Size = new System.Drawing.Size(43, 17);
            this.label_Make_accessSecret_name.TabIndex = 0;
            this.label_Make_accessSecret_name.Text = "accessSecret";
            this.tlpMake.Controls.Add(this.label_Make_accessSecret_name, 0, 7);
    
            //
            // label_Make_accessSecret
            //
            this.label_Make_accessSecret_remark = new System.Windows.Forms.Label();
            this.label_Make_accessSecret_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Make_accessSecret_remark.AutoSize = true;
            this.label_Make_accessSecret_remark.Location = new System.Drawing.Point(3, 113);
            this.label_Make_accessSecret_remark.Name = "label_Make_accessSecret";
            this.label_Make_accessSecret_remark.Size = new System.Drawing.Size(43, 17);
            this.label_Make_accessSecret_remark.TabIndex = 0;
            this.label_Make_accessSecret_remark.Text = "存储引擎的访问secret";
            this.tlpMake.Controls.Add(this.label_Make_accessSecret_remark, 2, 7);
    
            //
            // tb_Make_accessSecret
            //
            this.tb_Make_accessSecret = new System.Windows.Forms.TextBox();
            this.tb_Make_accessSecret.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Make_accessSecret.Location = new System.Drawing.Point(189, 50);
            this.tb_Make_accessSecret.Name = "tb_Make_accessSecret";
            this.tb_Make_accessSecret.Size = new System.Drawing.Size(363, 23);
            this.tb_Make_accessSecret.TabIndex = 1;
            this.tlpMake.Controls.Add(this.tb_Make_accessSecret, 1, 7);
            this.tlpMake.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
    
            //
            // btnSubmitMake
            //
            this.btnSubmitMake = new System.Windows.Forms.Button();
            this.btnSubmitMake.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSubmitMake.Location = new System.Drawing.Point(17, 300);
            this.btnSubmitMake.Name = "btnSubmitMake";
            this.btnSubmitMake.Size = new System.Drawing.Size(120, 29);
            this.btnSubmitMake.TabIndex = 0;
            this.btnSubmitMake.Text = "Submit";
            this.btnSubmitMake.UseVisualStyleBackColor = true;
            this.btnSubmitMake.Click += new System.EventHandler(this.btnSubmitMake_Click);
            this.tabPageMake.Controls.Add(this.btnSubmitMake);
    
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
            this.tlpList.RowCount = 4;
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
            this.label_Get_uuid_remark.Text = "uuid";
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
            this.tlpFind.RowCount = 3;
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
            // label_Find_name
            //
            this.label_Find_name_name = new System.Windows.Forms.Label();
            this.label_Find_name_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Find_name_name.AutoSize = true;
            this.label_Find_name_name.Location = new System.Drawing.Point(3, 113);
            this.label_Find_name_name.Name = "label_Find_name";
            this.label_Find_name_name.Size = new System.Drawing.Size(43, 17);
            this.label_Find_name_name.TabIndex = 0;
            this.label_Find_name_name.Text = "name";
            this.tlpFind.Controls.Add(this.label_Find_name_name, 0, 1);
    
            //
            // label_Find_name
            //
            this.label_Find_name_remark = new System.Windows.Forms.Label();
            this.label_Find_name_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Find_name_remark.AutoSize = true;
            this.label_Find_name_remark.Location = new System.Drawing.Point(3, 113);
            this.label_Find_name_remark.Name = "label_Find_name";
            this.label_Find_name_remark.Size = new System.Drawing.Size(43, 17);
            this.label_Find_name_remark.TabIndex = 0;
            this.label_Find_name_remark.Text = "name";
            this.tlpFind.Controls.Add(this.label_Find_name_remark, 2, 1);
    
            //
            // tb_Find_name
            //
            this.tb_Find_name = new System.Windows.Forms.TextBox();
            this.tb_Find_name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Find_name.Location = new System.Drawing.Point(189, 50);
            this.tb_Find_name.Name = "tb_Find_name";
            this.tb_Find_name.Size = new System.Drawing.Size(363, 23);
            this.tb_Find_name.TabIndex = 1;
            this.tlpFind.Controls.Add(this.tb_Find_name, 1, 1);
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
            // tlpUpdateEngine
            //
            this.tlpUpdateEngine = new System.Windows.Forms.TableLayoutPanel();
            this.tlpUpdateEngine.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpUpdateEngine.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpUpdateEngine.ColumnCount = 3;
            this.tlpUpdateEngine.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpUpdateEngine.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpUpdateEngine.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpUpdateEngine.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpUpdateEngine.Location = new System.Drawing.Point(17, 15);
            this.tlpUpdateEngine.Name = "tlp";
            this.tlpUpdateEngine.RowCount = 8;
            this.tlpUpdateEngine.Size = new System.Drawing.Size(400, 260);
            this.tlpUpdateEngine.TabIndex = 1;
            this.tabPageUpdateEngine.Controls.Add(this.tlpUpdateEngine);

            this.label_UpdateEngine_name = new System.Windows.Forms.Label();
            this.label_UpdateEngine_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_UpdateEngine_name.AutoSize = true;
            this.label_UpdateEngine_name.Location = new System.Drawing.Point(3, 113);
            this.label_UpdateEngine_name.Name = "label_UpdateEngine_name";
            this.label_UpdateEngine_name.Size = new System.Drawing.Size(43, 17);
            this.label_UpdateEngine_name.TabIndex = 0;
            this.label_UpdateEngine_name.Text = "参数名";
            this.tlpUpdateEngine.Controls.Add(this.label_UpdateEngine_name, 0, 0);

            this.label_UpdateEngine_value = new System.Windows.Forms.Label();
            this.label_UpdateEngine_value.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_UpdateEngine_value.AutoSize = true;
            this.label_UpdateEngine_value.Location = new System.Drawing.Point(3, 113);
            this.label_UpdateEngine_value.Name = "label_UpdateEngine_value";
            this.label_UpdateEngine_value.Size = new System.Drawing.Size(43, 17);
            this.label_UpdateEngine_value.TabIndex = 0;
            this.label_UpdateEngine_value.Text = "参数值";
            this.tlpUpdateEngine.Controls.Add(this.label_UpdateEngine_value, 1, 0);

            this.label_UpdateEngine_remark= new System.Windows.Forms.Label();
            this.label_UpdateEngine_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_UpdateEngine_remark.AutoSize = true;
            this.label_UpdateEngine_remark.Location = new System.Drawing.Point(3, 113);
            this.label_UpdateEngine_remark.Name = "label_UpdateEngine_name";
            this.label_UpdateEngine_remark.Size = new System.Drawing.Size(43, 17);
            this.label_UpdateEngine_remark.TabIndex = 0;
            this.label_UpdateEngine_remark.Text = "说明";
            this.tlpUpdateEngine.Controls.Add(this.label_UpdateEngine_remark, 2, 0);
            
            //
            // label_UpdateEngine_uuid
            //
            this.label_UpdateEngine_uuid_name = new System.Windows.Forms.Label();
            this.label_UpdateEngine_uuid_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_UpdateEngine_uuid_name.AutoSize = true;
            this.label_UpdateEngine_uuid_name.Location = new System.Drawing.Point(3, 113);
            this.label_UpdateEngine_uuid_name.Name = "label_UpdateEngine_uuid";
            this.label_UpdateEngine_uuid_name.Size = new System.Drawing.Size(43, 17);
            this.label_UpdateEngine_uuid_name.TabIndex = 0;
            this.label_UpdateEngine_uuid_name.Text = "uuid";
            this.tlpUpdateEngine.Controls.Add(this.label_UpdateEngine_uuid_name, 0, 1);
    
            //
            // label_UpdateEngine_uuid
            //
            this.label_UpdateEngine_uuid_remark = new System.Windows.Forms.Label();
            this.label_UpdateEngine_uuid_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_UpdateEngine_uuid_remark.AutoSize = true;
            this.label_UpdateEngine_uuid_remark.Location = new System.Drawing.Point(3, 113);
            this.label_UpdateEngine_uuid_remark.Name = "label_UpdateEngine_uuid";
            this.label_UpdateEngine_uuid_remark.Size = new System.Drawing.Size(43, 17);
            this.label_UpdateEngine_uuid_remark.TabIndex = 0;
            this.label_UpdateEngine_uuid_remark.Text = "uuid";
            this.tlpUpdateEngine.Controls.Add(this.label_UpdateEngine_uuid_remark, 2, 1);
    
            //
            // tb_UpdateEngine_uuid
            //
            this.tb_UpdateEngine_uuid = new System.Windows.Forms.TextBox();
            this.tb_UpdateEngine_uuid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_UpdateEngine_uuid.Location = new System.Drawing.Point(189, 50);
            this.tb_UpdateEngine_uuid.Name = "tb_UpdateEngine_uuid";
            this.tb_UpdateEngine_uuid.Size = new System.Drawing.Size(363, 23);
            this.tb_UpdateEngine_uuid.TabIndex = 1;
            this.tlpUpdateEngine.Controls.Add(this.tb_UpdateEngine_uuid, 1, 1);
            this.tlpUpdateEngine.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
    
            //
            // label_UpdateEngine_engine
            //
            this.label_UpdateEngine_engine_name = new System.Windows.Forms.Label();
            this.label_UpdateEngine_engine_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_UpdateEngine_engine_name.AutoSize = true;
            this.label_UpdateEngine_engine_name.Location = new System.Drawing.Point(3, 113);
            this.label_UpdateEngine_engine_name.Name = "label_UpdateEngine_engine";
            this.label_UpdateEngine_engine_name.Size = new System.Drawing.Size(43, 17);
            this.label_UpdateEngine_engine_name.TabIndex = 0;
            this.label_UpdateEngine_engine_name.Text = "engine";
            this.tlpUpdateEngine.Controls.Add(this.label_UpdateEngine_engine_name, 0, 2);
    
            //
            // label_UpdateEngine_engine
            //
            this.label_UpdateEngine_engine_remark = new System.Windows.Forms.Label();
            this.label_UpdateEngine_engine_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_UpdateEngine_engine_remark.AutoSize = true;
            this.label_UpdateEngine_engine_remark.Location = new System.Drawing.Point(3, 113);
            this.label_UpdateEngine_engine_remark.Name = "label_UpdateEngine_engine";
            this.label_UpdateEngine_engine_remark.Size = new System.Drawing.Size(43, 17);
            this.label_UpdateEngine_engine_remark.TabIndex = 0;
            this.label_UpdateEngine_engine_remark.Text = "存储引擎";
            this.tlpUpdateEngine.Controls.Add(this.label_UpdateEngine_engine_remark, 2, 2);
    
            //
            // tb_UpdateEngine_engine
            //
            this.tb_UpdateEngine_engine = new System.Windows.Forms.TextBox();
            this.tb_UpdateEngine_engine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_UpdateEngine_engine.Location = new System.Drawing.Point(189, 50);
            this.tb_UpdateEngine_engine.Name = "tb_UpdateEngine_engine";
            this.tb_UpdateEngine_engine.Size = new System.Drawing.Size(363, 23);
            this.tb_UpdateEngine_engine.TabIndex = 1;
            this.tlpUpdateEngine.Controls.Add(this.tb_UpdateEngine_engine, 1, 2);
            this.tlpUpdateEngine.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
    
            //
            // label_UpdateEngine_address
            //
            this.label_UpdateEngine_address_name = new System.Windows.Forms.Label();
            this.label_UpdateEngine_address_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_UpdateEngine_address_name.AutoSize = true;
            this.label_UpdateEngine_address_name.Location = new System.Drawing.Point(3, 113);
            this.label_UpdateEngine_address_name.Name = "label_UpdateEngine_address";
            this.label_UpdateEngine_address_name.Size = new System.Drawing.Size(43, 17);
            this.label_UpdateEngine_address_name.TabIndex = 0;
            this.label_UpdateEngine_address_name.Text = "address";
            this.tlpUpdateEngine.Controls.Add(this.label_UpdateEngine_address_name, 0, 3);
    
            //
            // label_UpdateEngine_address
            //
            this.label_UpdateEngine_address_remark = new System.Windows.Forms.Label();
            this.label_UpdateEngine_address_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_UpdateEngine_address_remark.AutoSize = true;
            this.label_UpdateEngine_address_remark.Location = new System.Drawing.Point(3, 113);
            this.label_UpdateEngine_address_remark.Name = "label_UpdateEngine_address";
            this.label_UpdateEngine_address_remark.Size = new System.Drawing.Size(43, 17);
            this.label_UpdateEngine_address_remark.TabIndex = 0;
            this.label_UpdateEngine_address_remark.Text = "存储引擎的地址";
            this.tlpUpdateEngine.Controls.Add(this.label_UpdateEngine_address_remark, 2, 3);
    
            //
            // tb_UpdateEngine_address
            //
            this.tb_UpdateEngine_address = new System.Windows.Forms.TextBox();
            this.tb_UpdateEngine_address.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_UpdateEngine_address.Location = new System.Drawing.Point(189, 50);
            this.tb_UpdateEngine_address.Name = "tb_UpdateEngine_address";
            this.tb_UpdateEngine_address.Size = new System.Drawing.Size(363, 23);
            this.tb_UpdateEngine_address.TabIndex = 1;
            this.tlpUpdateEngine.Controls.Add(this.tb_UpdateEngine_address, 1, 3);
            this.tlpUpdateEngine.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
    
            //
            // label_UpdateEngine_scope
            //
            this.label_UpdateEngine_scope_name = new System.Windows.Forms.Label();
            this.label_UpdateEngine_scope_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_UpdateEngine_scope_name.AutoSize = true;
            this.label_UpdateEngine_scope_name.Location = new System.Drawing.Point(3, 113);
            this.label_UpdateEngine_scope_name.Name = "label_UpdateEngine_scope";
            this.label_UpdateEngine_scope_name.Size = new System.Drawing.Size(43, 17);
            this.label_UpdateEngine_scope_name.TabIndex = 0;
            this.label_UpdateEngine_scope_name.Text = "scope";
            this.tlpUpdateEngine.Controls.Add(this.label_UpdateEngine_scope_name, 0, 4);
    
            //
            // label_UpdateEngine_scope
            //
            this.label_UpdateEngine_scope_remark = new System.Windows.Forms.Label();
            this.label_UpdateEngine_scope_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_UpdateEngine_scope_remark.AutoSize = true;
            this.label_UpdateEngine_scope_remark.Location = new System.Drawing.Point(3, 113);
            this.label_UpdateEngine_scope_remark.Name = "label_UpdateEngine_scope";
            this.label_UpdateEngine_scope_remark.Size = new System.Drawing.Size(43, 17);
            this.label_UpdateEngine_scope_remark.TabIndex = 0;
            this.label_UpdateEngine_scope_remark.Text = "存储引擎的作用范围";
            this.tlpUpdateEngine.Controls.Add(this.label_UpdateEngine_scope_remark, 2, 4);
    
            //
            // tb_UpdateEngine_scope
            //
            this.tb_UpdateEngine_scope = new System.Windows.Forms.TextBox();
            this.tb_UpdateEngine_scope.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_UpdateEngine_scope.Location = new System.Drawing.Point(189, 50);
            this.tb_UpdateEngine_scope.Name = "tb_UpdateEngine_scope";
            this.tb_UpdateEngine_scope.Size = new System.Drawing.Size(363, 23);
            this.tb_UpdateEngine_scope.TabIndex = 1;
            this.tlpUpdateEngine.Controls.Add(this.tb_UpdateEngine_scope, 1, 4);
            this.tlpUpdateEngine.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
    
            //
            // label_UpdateEngine_accessKey
            //
            this.label_UpdateEngine_accessKey_name = new System.Windows.Forms.Label();
            this.label_UpdateEngine_accessKey_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_UpdateEngine_accessKey_name.AutoSize = true;
            this.label_UpdateEngine_accessKey_name.Location = new System.Drawing.Point(3, 113);
            this.label_UpdateEngine_accessKey_name.Name = "label_UpdateEngine_accessKey";
            this.label_UpdateEngine_accessKey_name.Size = new System.Drawing.Size(43, 17);
            this.label_UpdateEngine_accessKey_name.TabIndex = 0;
            this.label_UpdateEngine_accessKey_name.Text = "accessKey";
            this.tlpUpdateEngine.Controls.Add(this.label_UpdateEngine_accessKey_name, 0, 5);
    
            //
            // label_UpdateEngine_accessKey
            //
            this.label_UpdateEngine_accessKey_remark = new System.Windows.Forms.Label();
            this.label_UpdateEngine_accessKey_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_UpdateEngine_accessKey_remark.AutoSize = true;
            this.label_UpdateEngine_accessKey_remark.Location = new System.Drawing.Point(3, 113);
            this.label_UpdateEngine_accessKey_remark.Name = "label_UpdateEngine_accessKey";
            this.label_UpdateEngine_accessKey_remark.Size = new System.Drawing.Size(43, 17);
            this.label_UpdateEngine_accessKey_remark.TabIndex = 0;
            this.label_UpdateEngine_accessKey_remark.Text = "存储引擎的访问key";
            this.tlpUpdateEngine.Controls.Add(this.label_UpdateEngine_accessKey_remark, 2, 5);
    
            //
            // tb_UpdateEngine_accessKey
            //
            this.tb_UpdateEngine_accessKey = new System.Windows.Forms.TextBox();
            this.tb_UpdateEngine_accessKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_UpdateEngine_accessKey.Location = new System.Drawing.Point(189, 50);
            this.tb_UpdateEngine_accessKey.Name = "tb_UpdateEngine_accessKey";
            this.tb_UpdateEngine_accessKey.Size = new System.Drawing.Size(363, 23);
            this.tb_UpdateEngine_accessKey.TabIndex = 1;
            this.tlpUpdateEngine.Controls.Add(this.tb_UpdateEngine_accessKey, 1, 5);
            this.tlpUpdateEngine.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
    
            //
            // label_UpdateEngine_accessSecret
            //
            this.label_UpdateEngine_accessSecret_name = new System.Windows.Forms.Label();
            this.label_UpdateEngine_accessSecret_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_UpdateEngine_accessSecret_name.AutoSize = true;
            this.label_UpdateEngine_accessSecret_name.Location = new System.Drawing.Point(3, 113);
            this.label_UpdateEngine_accessSecret_name.Name = "label_UpdateEngine_accessSecret";
            this.label_UpdateEngine_accessSecret_name.Size = new System.Drawing.Size(43, 17);
            this.label_UpdateEngine_accessSecret_name.TabIndex = 0;
            this.label_UpdateEngine_accessSecret_name.Text = "accessSecret";
            this.tlpUpdateEngine.Controls.Add(this.label_UpdateEngine_accessSecret_name, 0, 6);
    
            //
            // label_UpdateEngine_accessSecret
            //
            this.label_UpdateEngine_accessSecret_remark = new System.Windows.Forms.Label();
            this.label_UpdateEngine_accessSecret_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_UpdateEngine_accessSecret_remark.AutoSize = true;
            this.label_UpdateEngine_accessSecret_remark.Location = new System.Drawing.Point(3, 113);
            this.label_UpdateEngine_accessSecret_remark.Name = "label_UpdateEngine_accessSecret";
            this.label_UpdateEngine_accessSecret_remark.Size = new System.Drawing.Size(43, 17);
            this.label_UpdateEngine_accessSecret_remark.TabIndex = 0;
            this.label_UpdateEngine_accessSecret_remark.Text = "存储引擎的访问secret";
            this.tlpUpdateEngine.Controls.Add(this.label_UpdateEngine_accessSecret_remark, 2, 6);
    
            //
            // tb_UpdateEngine_accessSecret
            //
            this.tb_UpdateEngine_accessSecret = new System.Windows.Forms.TextBox();
            this.tb_UpdateEngine_accessSecret.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_UpdateEngine_accessSecret.Location = new System.Drawing.Point(189, 50);
            this.tb_UpdateEngine_accessSecret.Name = "tb_UpdateEngine_accessSecret";
            this.tb_UpdateEngine_accessSecret.Size = new System.Drawing.Size(363, 23);
            this.tb_UpdateEngine_accessSecret.TabIndex = 1;
            this.tlpUpdateEngine.Controls.Add(this.tb_UpdateEngine_accessSecret, 1, 6);
            this.tlpUpdateEngine.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
    
            //
            // btnSubmitUpdateEngine
            //
            this.btnSubmitUpdateEngine = new System.Windows.Forms.Button();
            this.btnSubmitUpdateEngine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSubmitUpdateEngine.Location = new System.Drawing.Point(17, 300);
            this.btnSubmitUpdateEngine.Name = "btnSubmitUpdateEngine";
            this.btnSubmitUpdateEngine.Size = new System.Drawing.Size(120, 29);
            this.btnSubmitUpdateEngine.TabIndex = 0;
            this.btnSubmitUpdateEngine.Text = "Submit";
            this.btnSubmitUpdateEngine.UseVisualStyleBackColor = true;
            this.btnSubmitUpdateEngine.Click += new System.EventHandler(this.btnSubmitUpdateEngine_Click);
            this.tabPageUpdateEngine.Controls.Add(this.btnSubmitUpdateEngine);
    
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
            // tlpUpdateCapacity
            //
            this.tlpUpdateCapacity = new System.Windows.Forms.TableLayoutPanel();
            this.tlpUpdateCapacity.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpUpdateCapacity.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpUpdateCapacity.ColumnCount = 3;
            this.tlpUpdateCapacity.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpUpdateCapacity.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpUpdateCapacity.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpUpdateCapacity.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpUpdateCapacity.Location = new System.Drawing.Point(17, 15);
            this.tlpUpdateCapacity.Name = "tlp";
            this.tlpUpdateCapacity.RowCount = 4;
            this.tlpUpdateCapacity.Size = new System.Drawing.Size(400, 260);
            this.tlpUpdateCapacity.TabIndex = 1;
            this.tabPageUpdateCapacity.Controls.Add(this.tlpUpdateCapacity);

            this.label_UpdateCapacity_name = new System.Windows.Forms.Label();
            this.label_UpdateCapacity_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_UpdateCapacity_name.AutoSize = true;
            this.label_UpdateCapacity_name.Location = new System.Drawing.Point(3, 113);
            this.label_UpdateCapacity_name.Name = "label_UpdateCapacity_name";
            this.label_UpdateCapacity_name.Size = new System.Drawing.Size(43, 17);
            this.label_UpdateCapacity_name.TabIndex = 0;
            this.label_UpdateCapacity_name.Text = "参数名";
            this.tlpUpdateCapacity.Controls.Add(this.label_UpdateCapacity_name, 0, 0);

            this.label_UpdateCapacity_value = new System.Windows.Forms.Label();
            this.label_UpdateCapacity_value.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_UpdateCapacity_value.AutoSize = true;
            this.label_UpdateCapacity_value.Location = new System.Drawing.Point(3, 113);
            this.label_UpdateCapacity_value.Name = "label_UpdateCapacity_value";
            this.label_UpdateCapacity_value.Size = new System.Drawing.Size(43, 17);
            this.label_UpdateCapacity_value.TabIndex = 0;
            this.label_UpdateCapacity_value.Text = "参数值";
            this.tlpUpdateCapacity.Controls.Add(this.label_UpdateCapacity_value, 1, 0);

            this.label_UpdateCapacity_remark= new System.Windows.Forms.Label();
            this.label_UpdateCapacity_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_UpdateCapacity_remark.AutoSize = true;
            this.label_UpdateCapacity_remark.Location = new System.Drawing.Point(3, 113);
            this.label_UpdateCapacity_remark.Name = "label_UpdateCapacity_name";
            this.label_UpdateCapacity_remark.Size = new System.Drawing.Size(43, 17);
            this.label_UpdateCapacity_remark.TabIndex = 0;
            this.label_UpdateCapacity_remark.Text = "说明";
            this.tlpUpdateCapacity.Controls.Add(this.label_UpdateCapacity_remark, 2, 0);
            
            //
            // label_UpdateCapacity_uuid
            //
            this.label_UpdateCapacity_uuid_name = new System.Windows.Forms.Label();
            this.label_UpdateCapacity_uuid_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_UpdateCapacity_uuid_name.AutoSize = true;
            this.label_UpdateCapacity_uuid_name.Location = new System.Drawing.Point(3, 113);
            this.label_UpdateCapacity_uuid_name.Name = "label_UpdateCapacity_uuid";
            this.label_UpdateCapacity_uuid_name.Size = new System.Drawing.Size(43, 17);
            this.label_UpdateCapacity_uuid_name.TabIndex = 0;
            this.label_UpdateCapacity_uuid_name.Text = "uuid";
            this.tlpUpdateCapacity.Controls.Add(this.label_UpdateCapacity_uuid_name, 0, 1);
    
            //
            // label_UpdateCapacity_uuid
            //
            this.label_UpdateCapacity_uuid_remark = new System.Windows.Forms.Label();
            this.label_UpdateCapacity_uuid_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_UpdateCapacity_uuid_remark.AutoSize = true;
            this.label_UpdateCapacity_uuid_remark.Location = new System.Drawing.Point(3, 113);
            this.label_UpdateCapacity_uuid_remark.Name = "label_UpdateCapacity_uuid";
            this.label_UpdateCapacity_uuid_remark.Size = new System.Drawing.Size(43, 17);
            this.label_UpdateCapacity_uuid_remark.TabIndex = 0;
            this.label_UpdateCapacity_uuid_remark.Text = "uuid";
            this.tlpUpdateCapacity.Controls.Add(this.label_UpdateCapacity_uuid_remark, 2, 1);
    
            //
            // tb_UpdateCapacity_uuid
            //
            this.tb_UpdateCapacity_uuid = new System.Windows.Forms.TextBox();
            this.tb_UpdateCapacity_uuid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_UpdateCapacity_uuid.Location = new System.Drawing.Point(189, 50);
            this.tb_UpdateCapacity_uuid.Name = "tb_UpdateCapacity_uuid";
            this.tb_UpdateCapacity_uuid.Size = new System.Drawing.Size(363, 23);
            this.tb_UpdateCapacity_uuid.TabIndex = 1;
            this.tlpUpdateCapacity.Controls.Add(this.tb_UpdateCapacity_uuid, 1, 1);
            this.tlpUpdateCapacity.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
    
            //
            // label_UpdateCapacity_capacity
            //
            this.label_UpdateCapacity_capacity_name = new System.Windows.Forms.Label();
            this.label_UpdateCapacity_capacity_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_UpdateCapacity_capacity_name.AutoSize = true;
            this.label_UpdateCapacity_capacity_name.Location = new System.Drawing.Point(3, 113);
            this.label_UpdateCapacity_capacity_name.Name = "label_UpdateCapacity_capacity";
            this.label_UpdateCapacity_capacity_name.Size = new System.Drawing.Size(43, 17);
            this.label_UpdateCapacity_capacity_name.TabIndex = 0;
            this.label_UpdateCapacity_capacity_name.Text = "capacity";
            this.tlpUpdateCapacity.Controls.Add(this.label_UpdateCapacity_capacity_name, 0, 2);
    
            //
            // label_UpdateCapacity_capacity
            //
            this.label_UpdateCapacity_capacity_remark = new System.Windows.Forms.Label();
            this.label_UpdateCapacity_capacity_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_UpdateCapacity_capacity_remark.AutoSize = true;
            this.label_UpdateCapacity_capacity_remark.Location = new System.Drawing.Point(3, 113);
            this.label_UpdateCapacity_capacity_remark.Name = "label_UpdateCapacity_capacity";
            this.label_UpdateCapacity_capacity_remark.Size = new System.Drawing.Size(43, 17);
            this.label_UpdateCapacity_capacity_remark.TabIndex = 0;
            this.label_UpdateCapacity_capacity_remark.Text = "容量";
            this.tlpUpdateCapacity.Controls.Add(this.label_UpdateCapacity_capacity_remark, 2, 2);
    
            //
            // tb_UpdateCapacity_capacity
            //
            this.tb_UpdateCapacity_capacity = new System.Windows.Forms.TextBox();
            this.tb_UpdateCapacity_capacity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_UpdateCapacity_capacity.Location = new System.Drawing.Point(189, 50);
            this.tb_UpdateCapacity_capacity.Name = "tb_UpdateCapacity_capacity";
            this.tb_UpdateCapacity_capacity.Size = new System.Drawing.Size(363, 23);
            this.tb_UpdateCapacity_capacity.TabIndex = 1;
            this.tlpUpdateCapacity.Controls.Add(this.tb_UpdateCapacity_capacity, 1, 2);
            this.tlpUpdateCapacity.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
    
            //
            // btnSubmitUpdateCapacity
            //
            this.btnSubmitUpdateCapacity = new System.Windows.Forms.Button();
            this.btnSubmitUpdateCapacity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSubmitUpdateCapacity.Location = new System.Drawing.Point(17, 300);
            this.btnSubmitUpdateCapacity.Name = "btnSubmitUpdateCapacity";
            this.btnSubmitUpdateCapacity.Size = new System.Drawing.Size(120, 29);
            this.btnSubmitUpdateCapacity.TabIndex = 0;
            this.btnSubmitUpdateCapacity.Text = "Submit";
            this.btnSubmitUpdateCapacity.UseVisualStyleBackColor = true;
            this.btnSubmitUpdateCapacity.Click += new System.EventHandler(this.btnSubmitUpdateCapacity_Click);
            this.tabPageUpdateCapacity.Controls.Add(this.btnSubmitUpdateCapacity);
    
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
            // tlpResetToken
            //
            this.tlpResetToken = new System.Windows.Forms.TableLayoutPanel();
            this.tlpResetToken.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpResetToken.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpResetToken.ColumnCount = 3;
            this.tlpResetToken.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpResetToken.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpResetToken.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpResetToken.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpResetToken.Location = new System.Drawing.Point(17, 15);
            this.tlpResetToken.Name = "tlp";
            this.tlpResetToken.RowCount = 3;
            this.tlpResetToken.Size = new System.Drawing.Size(400, 260);
            this.tlpResetToken.TabIndex = 1;
            this.tabPageResetToken.Controls.Add(this.tlpResetToken);

            this.label_ResetToken_name = new System.Windows.Forms.Label();
            this.label_ResetToken_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_ResetToken_name.AutoSize = true;
            this.label_ResetToken_name.Location = new System.Drawing.Point(3, 113);
            this.label_ResetToken_name.Name = "label_ResetToken_name";
            this.label_ResetToken_name.Size = new System.Drawing.Size(43, 17);
            this.label_ResetToken_name.TabIndex = 0;
            this.label_ResetToken_name.Text = "参数名";
            this.tlpResetToken.Controls.Add(this.label_ResetToken_name, 0, 0);

            this.label_ResetToken_value = new System.Windows.Forms.Label();
            this.label_ResetToken_value.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_ResetToken_value.AutoSize = true;
            this.label_ResetToken_value.Location = new System.Drawing.Point(3, 113);
            this.label_ResetToken_value.Name = "label_ResetToken_value";
            this.label_ResetToken_value.Size = new System.Drawing.Size(43, 17);
            this.label_ResetToken_value.TabIndex = 0;
            this.label_ResetToken_value.Text = "参数值";
            this.tlpResetToken.Controls.Add(this.label_ResetToken_value, 1, 0);

            this.label_ResetToken_remark= new System.Windows.Forms.Label();
            this.label_ResetToken_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_ResetToken_remark.AutoSize = true;
            this.label_ResetToken_remark.Location = new System.Drawing.Point(3, 113);
            this.label_ResetToken_remark.Name = "label_ResetToken_name";
            this.label_ResetToken_remark.Size = new System.Drawing.Size(43, 17);
            this.label_ResetToken_remark.TabIndex = 0;
            this.label_ResetToken_remark.Text = "说明";
            this.tlpResetToken.Controls.Add(this.label_ResetToken_remark, 2, 0);
            
            //
            // label_ResetToken_uuid
            //
            this.label_ResetToken_uuid_name = new System.Windows.Forms.Label();
            this.label_ResetToken_uuid_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_ResetToken_uuid_name.AutoSize = true;
            this.label_ResetToken_uuid_name.Location = new System.Drawing.Point(3, 113);
            this.label_ResetToken_uuid_name.Name = "label_ResetToken_uuid";
            this.label_ResetToken_uuid_name.Size = new System.Drawing.Size(43, 17);
            this.label_ResetToken_uuid_name.TabIndex = 0;
            this.label_ResetToken_uuid_name.Text = "uuid";
            this.tlpResetToken.Controls.Add(this.label_ResetToken_uuid_name, 0, 1);
    
            //
            // label_ResetToken_uuid
            //
            this.label_ResetToken_uuid_remark = new System.Windows.Forms.Label();
            this.label_ResetToken_uuid_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_ResetToken_uuid_remark.AutoSize = true;
            this.label_ResetToken_uuid_remark.Location = new System.Drawing.Point(3, 113);
            this.label_ResetToken_uuid_remark.Name = "label_ResetToken_uuid";
            this.label_ResetToken_uuid_remark.Size = new System.Drawing.Size(43, 17);
            this.label_ResetToken_uuid_remark.TabIndex = 0;
            this.label_ResetToken_uuid_remark.Text = "uuid";
            this.tlpResetToken.Controls.Add(this.label_ResetToken_uuid_remark, 2, 1);
    
            //
            // tb_ResetToken_uuid
            //
            this.tb_ResetToken_uuid = new System.Windows.Forms.TextBox();
            this.tb_ResetToken_uuid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_ResetToken_uuid.Location = new System.Drawing.Point(189, 50);
            this.tb_ResetToken_uuid.Name = "tb_ResetToken_uuid";
            this.tb_ResetToken_uuid.Size = new System.Drawing.Size(363, 23);
            this.tb_ResetToken_uuid.TabIndex = 1;
            this.tlpResetToken.Controls.Add(this.tb_ResetToken_uuid, 1, 1);
            this.tlpResetToken.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
    
            //
            // btnSubmitResetToken
            //
            this.btnSubmitResetToken = new System.Windows.Forms.Button();
            this.btnSubmitResetToken.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSubmitResetToken.Location = new System.Drawing.Point(17, 300);
            this.btnSubmitResetToken.Name = "btnSubmitResetToken";
            this.btnSubmitResetToken.Size = new System.Drawing.Size(120, 29);
            this.btnSubmitResetToken.TabIndex = 0;
            this.btnSubmitResetToken.Text = "Submit";
            this.btnSubmitResetToken.UseVisualStyleBackColor = true;
            this.btnSubmitResetToken.Click += new System.EventHandler(this.btnSubmitResetToken_Click);
            this.tabPageResetToken.Controls.Add(this.btnSubmitResetToken);
    

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
    
        private System.Windows.Forms.TableLayoutPanel tlpMake;
        private System.Windows.Forms.Label label_Make_name;
        private System.Windows.Forms.Label label_Make_value;
        private System.Windows.Forms.Label label_Make_remark;
    
        private System.Windows.Forms.Label label_Make_name_name;
    
        private System.Windows.Forms.Label label_Make_name_remark;
    
        private System.Windows.Forms.TextBox tb_Make_name;
    
        private System.Windows.Forms.Label label_Make_capacity_name;
    
        private System.Windows.Forms.Label label_Make_capacity_remark;
    
        private System.Windows.Forms.TextBox tb_Make_capacity;
    
        private System.Windows.Forms.Label label_Make_engine_name;
    
        private System.Windows.Forms.Label label_Make_engine_remark;
    
        private System.Windows.Forms.TextBox tb_Make_engine;
    
        private System.Windows.Forms.Label label_Make_address_name;
    
        private System.Windows.Forms.Label label_Make_address_remark;
    
        private System.Windows.Forms.TextBox tb_Make_address;
    
        private System.Windows.Forms.Label label_Make_scope_name;
    
        private System.Windows.Forms.Label label_Make_scope_remark;
    
        private System.Windows.Forms.TextBox tb_Make_scope;
    
        private System.Windows.Forms.Label label_Make_accessKey_name;
    
        private System.Windows.Forms.Label label_Make_accessKey_remark;
    
        private System.Windows.Forms.TextBox tb_Make_accessKey;
    
        private System.Windows.Forms.Label label_Make_accessSecret_name;
    
        private System.Windows.Forms.Label label_Make_accessSecret_remark;
    
        private System.Windows.Forms.TextBox tb_Make_accessSecret;
    
        private System.Windows.Forms.Button btnSubmitMake;
        private void btnSubmitMake_Click(object sender, System.EventArgs e)
        {
            IBucketViewBridge bridge =  facade.getViewBridge() as IBucketViewBridge;
            
            string name = this.tb_Make_name.Text;
    
            long capacity;
            long.TryParse(this.tb_Make_capacity.Text, out capacity);
    
            int engine;
            int.TryParse(this.tb_Make_engine.Text, out engine);
    
            string address = this.tb_Make_address.Text;
    
            string scope = this.tb_Make_scope.Text;
    
            string accessKey = this.tb_Make_accessKey.Text;
    
            string accessSecret = this.tb_Make_accessSecret.Text;
    
            bridge.OnMakeSubmit(name, capacity, engine, address, scope, accessKey, accessSecret);
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
    
        private System.Windows.Forms.Button btnSubmitList;
        private void btnSubmitList_Click(object sender, System.EventArgs e)
        {
            IBucketViewBridge bridge =  facade.getViewBridge() as IBucketViewBridge;
            
            long offset;
            long.TryParse(this.tb_List_offset.Text, out offset);
    
            long count;
            long.TryParse(this.tb_List_count.Text, out count);
    
            bridge.OnListSubmit(offset, count);
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
            IBucketViewBridge bridge =  facade.getViewBridge() as IBucketViewBridge;
            
            string uuid = this.tb_Remove_uuid.Text;
    
            bridge.OnRemoveSubmit(uuid);
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
            IBucketViewBridge bridge =  facade.getViewBridge() as IBucketViewBridge;
            
            string uuid = this.tb_Get_uuid.Text;
    
            bridge.OnGetSubmit(uuid);
        }
    
        private System.Windows.Forms.TabPage tabPageFind;
    
        private System.Windows.Forms.TableLayoutPanel tlpFind;
        private System.Windows.Forms.Label label_Find_name;
        private System.Windows.Forms.Label label_Find_value;
        private System.Windows.Forms.Label label_Find_remark;
    
        private System.Windows.Forms.Label label_Find_name_name;
    
        private System.Windows.Forms.Label label_Find_name_remark;
    
        private System.Windows.Forms.TextBox tb_Find_name;
    
        private System.Windows.Forms.Button btnSubmitFind;
        private void btnSubmitFind_Click(object sender, System.EventArgs e)
        {
            IBucketViewBridge bridge =  facade.getViewBridge() as IBucketViewBridge;
            
            string name = this.tb_Find_name.Text;
    
            bridge.OnFindSubmit(name);
        }
    
        private System.Windows.Forms.TabPage tabPageUpdateEngine;
    
        private System.Windows.Forms.TableLayoutPanel tlpUpdateEngine;
        private System.Windows.Forms.Label label_UpdateEngine_name;
        private System.Windows.Forms.Label label_UpdateEngine_value;
        private System.Windows.Forms.Label label_UpdateEngine_remark;
    
        private System.Windows.Forms.Label label_UpdateEngine_uuid_name;
    
        private System.Windows.Forms.Label label_UpdateEngine_uuid_remark;
    
        private System.Windows.Forms.TextBox tb_UpdateEngine_uuid;
    
        private System.Windows.Forms.Label label_UpdateEngine_engine_name;
    
        private System.Windows.Forms.Label label_UpdateEngine_engine_remark;
    
        private System.Windows.Forms.TextBox tb_UpdateEngine_engine;
    
        private System.Windows.Forms.Label label_UpdateEngine_address_name;
    
        private System.Windows.Forms.Label label_UpdateEngine_address_remark;
    
        private System.Windows.Forms.TextBox tb_UpdateEngine_address;
    
        private System.Windows.Forms.Label label_UpdateEngine_scope_name;
    
        private System.Windows.Forms.Label label_UpdateEngine_scope_remark;
    
        private System.Windows.Forms.TextBox tb_UpdateEngine_scope;
    
        private System.Windows.Forms.Label label_UpdateEngine_accessKey_name;
    
        private System.Windows.Forms.Label label_UpdateEngine_accessKey_remark;
    
        private System.Windows.Forms.TextBox tb_UpdateEngine_accessKey;
    
        private System.Windows.Forms.Label label_UpdateEngine_accessSecret_name;
    
        private System.Windows.Forms.Label label_UpdateEngine_accessSecret_remark;
    
        private System.Windows.Forms.TextBox tb_UpdateEngine_accessSecret;
    
        private System.Windows.Forms.Button btnSubmitUpdateEngine;
        private void btnSubmitUpdateEngine_Click(object sender, System.EventArgs e)
        {
            IBucketViewBridge bridge =  facade.getViewBridge() as IBucketViewBridge;
            
            string uuid = this.tb_UpdateEngine_uuid.Text;
    
            int engine;
            int.TryParse(this.tb_UpdateEngine_engine.Text, out engine);
    
            string address = this.tb_UpdateEngine_address.Text;
    
            string scope = this.tb_UpdateEngine_scope.Text;
    
            string accessKey = this.tb_UpdateEngine_accessKey.Text;
    
            string accessSecret = this.tb_UpdateEngine_accessSecret.Text;
    
            bridge.OnUpdateEngineSubmit(uuid, engine, address, scope, accessKey, accessSecret);
        }
    
        private System.Windows.Forms.TabPage tabPageUpdateCapacity;
    
        private System.Windows.Forms.TableLayoutPanel tlpUpdateCapacity;
        private System.Windows.Forms.Label label_UpdateCapacity_name;
        private System.Windows.Forms.Label label_UpdateCapacity_value;
        private System.Windows.Forms.Label label_UpdateCapacity_remark;
    
        private System.Windows.Forms.Label label_UpdateCapacity_uuid_name;
    
        private System.Windows.Forms.Label label_UpdateCapacity_uuid_remark;
    
        private System.Windows.Forms.TextBox tb_UpdateCapacity_uuid;
    
        private System.Windows.Forms.Label label_UpdateCapacity_capacity_name;
    
        private System.Windows.Forms.Label label_UpdateCapacity_capacity_remark;
    
        private System.Windows.Forms.TextBox tb_UpdateCapacity_capacity;
    
        private System.Windows.Forms.Button btnSubmitUpdateCapacity;
        private void btnSubmitUpdateCapacity_Click(object sender, System.EventArgs e)
        {
            IBucketViewBridge bridge =  facade.getViewBridge() as IBucketViewBridge;
            
            string uuid = this.tb_UpdateCapacity_uuid.Text;
    
            long capacity;
            long.TryParse(this.tb_UpdateCapacity_capacity.Text, out capacity);
    
            bridge.OnUpdateCapacitySubmit(uuid, capacity);
        }
    
        private System.Windows.Forms.TabPage tabPageResetToken;
    
        private System.Windows.Forms.TableLayoutPanel tlpResetToken;
        private System.Windows.Forms.Label label_ResetToken_name;
        private System.Windows.Forms.Label label_ResetToken_value;
        private System.Windows.Forms.Label label_ResetToken_remark;
    
        private System.Windows.Forms.Label label_ResetToken_uuid_name;
    
        private System.Windows.Forms.Label label_ResetToken_uuid_remark;
    
        private System.Windows.Forms.TextBox tb_ResetToken_uuid;
    
        private System.Windows.Forms.Button btnSubmitResetToken;
        private void btnSubmitResetToken_Click(object sender, System.EventArgs e)
        {
            IBucketViewBridge bridge =  facade.getViewBridge() as IBucketViewBridge;
            
            string uuid = this.tb_ResetToken_uuid.Text;
    
            bridge.OnResetTokenSubmit(uuid);
        }
    
    }
}
