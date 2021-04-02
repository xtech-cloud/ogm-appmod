

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
            // label_name
            //
            this.label_name_name = new System.Windows.Forms.Label();
            this.label_name_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_name_name.AutoSize = true;
            this.label_name_name.Location = new System.Drawing.Point(3, 113);
            this.label_name_name.Name = "label_name";
            this.label_name_name.Size = new System.Drawing.Size(43, 17);
            this.label_name_name.TabIndex = 0;
            this.label_name_name.Text = "name";
            this.tlpMake.Controls.Add(this.label_name_name, 0, 1);
    
            //
            // label_name
            //
            this.label_name_remark = new System.Windows.Forms.Label();
            this.label_name_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_name_remark.AutoSize = true;
            this.label_name_remark.Location = new System.Drawing.Point(3, 113);
            this.label_name_remark.Name = "label_name";
            this.label_name_remark.Size = new System.Drawing.Size(43, 17);
            this.label_name_remark.TabIndex = 0;
            this.label_name_remark.Text = "名称";
            this.tlpMake.Controls.Add(this.label_name_remark, 2, 1);
    
            //
            // tb_name
            //
            this.tb_name = new System.Windows.Forms.TextBox();
            this.tb_name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_name.Location = new System.Drawing.Point(189, 50);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(363, 23);
            this.tb_name.TabIndex = 1;
            this.tlpMake.Controls.Add(this.tb_name, 1, 1);
            this.tlpMake.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
    
            //
            // label_capacity
            //
            this.label_capacity_name = new System.Windows.Forms.Label();
            this.label_capacity_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_capacity_name.AutoSize = true;
            this.label_capacity_name.Location = new System.Drawing.Point(3, 113);
            this.label_capacity_name.Name = "label_capacity";
            this.label_capacity_name.Size = new System.Drawing.Size(43, 17);
            this.label_capacity_name.TabIndex = 0;
            this.label_capacity_name.Text = "capacity";
            this.tlpMake.Controls.Add(this.label_capacity_name, 0, 2);
    
            //
            // label_capacity
            //
            this.label_capacity_remark = new System.Windows.Forms.Label();
            this.label_capacity_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_capacity_remark.AutoSize = true;
            this.label_capacity_remark.Location = new System.Drawing.Point(3, 113);
            this.label_capacity_remark.Name = "label_capacity";
            this.label_capacity_remark.Size = new System.Drawing.Size(43, 17);
            this.label_capacity_remark.TabIndex = 0;
            this.label_capacity_remark.Text = "初始容量";
            this.tlpMake.Controls.Add(this.label_capacity_remark, 2, 2);
    
            //
            // tb_capacity
            //
            this.tb_capacity = new System.Windows.Forms.TextBox();
            this.tb_capacity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_capacity.Location = new System.Drawing.Point(189, 50);
            this.tb_capacity.Name = "tb_capacity";
            this.tb_capacity.Size = new System.Drawing.Size(363, 23);
            this.tb_capacity.TabIndex = 1;
            this.tlpMake.Controls.Add(this.tb_capacity, 1, 2);
            this.tlpMake.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
    
            //
            // label_engine
            //
            this.label_engine_name = new System.Windows.Forms.Label();
            this.label_engine_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_engine_name.AutoSize = true;
            this.label_engine_name.Location = new System.Drawing.Point(3, 113);
            this.label_engine_name.Name = "label_engine";
            this.label_engine_name.Size = new System.Drawing.Size(43, 17);
            this.label_engine_name.TabIndex = 0;
            this.label_engine_name.Text = "engine";
            this.tlpMake.Controls.Add(this.label_engine_name, 0, 3);
    
            //
            // label_engine
            //
            this.label_engine_remark = new System.Windows.Forms.Label();
            this.label_engine_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_engine_remark.AutoSize = true;
            this.label_engine_remark.Location = new System.Drawing.Point(3, 113);
            this.label_engine_remark.Name = "label_engine";
            this.label_engine_remark.Size = new System.Drawing.Size(43, 17);
            this.label_engine_remark.TabIndex = 0;
            this.label_engine_remark.Text = "存储引擎";
            this.tlpMake.Controls.Add(this.label_engine_remark, 2, 3);
    
            //
            // tb_engine
            //
            this.tb_engine = new System.Windows.Forms.TextBox();
            this.tb_engine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_engine.Location = new System.Drawing.Point(189, 50);
            this.tb_engine.Name = "tb_engine";
            this.tb_engine.Size = new System.Drawing.Size(363, 23);
            this.tb_engine.TabIndex = 1;
            this.tlpMake.Controls.Add(this.tb_engine, 1, 3);
            this.tlpMake.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
    
            //
            // label_address
            //
            this.label_address_name = new System.Windows.Forms.Label();
            this.label_address_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_address_name.AutoSize = true;
            this.label_address_name.Location = new System.Drawing.Point(3, 113);
            this.label_address_name.Name = "label_address";
            this.label_address_name.Size = new System.Drawing.Size(43, 17);
            this.label_address_name.TabIndex = 0;
            this.label_address_name.Text = "address";
            this.tlpMake.Controls.Add(this.label_address_name, 0, 4);
    
            //
            // label_address
            //
            this.label_address_remark = new System.Windows.Forms.Label();
            this.label_address_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_address_remark.AutoSize = true;
            this.label_address_remark.Location = new System.Drawing.Point(3, 113);
            this.label_address_remark.Name = "label_address";
            this.label_address_remark.Size = new System.Drawing.Size(43, 17);
            this.label_address_remark.TabIndex = 0;
            this.label_address_remark.Text = "存储引擎的地址";
            this.tlpMake.Controls.Add(this.label_address_remark, 2, 4);
    
            //
            // tb_address
            //
            this.tb_address = new System.Windows.Forms.TextBox();
            this.tb_address.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_address.Location = new System.Drawing.Point(189, 50);
            this.tb_address.Name = "tb_address";
            this.tb_address.Size = new System.Drawing.Size(363, 23);
            this.tb_address.TabIndex = 1;
            this.tlpMake.Controls.Add(this.tb_address, 1, 4);
            this.tlpMake.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
    
            //
            // label_scope
            //
            this.label_scope_name = new System.Windows.Forms.Label();
            this.label_scope_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_scope_name.AutoSize = true;
            this.label_scope_name.Location = new System.Drawing.Point(3, 113);
            this.label_scope_name.Name = "label_scope";
            this.label_scope_name.Size = new System.Drawing.Size(43, 17);
            this.label_scope_name.TabIndex = 0;
            this.label_scope_name.Text = "scope";
            this.tlpMake.Controls.Add(this.label_scope_name, 0, 5);
    
            //
            // label_scope
            //
            this.label_scope_remark = new System.Windows.Forms.Label();
            this.label_scope_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_scope_remark.AutoSize = true;
            this.label_scope_remark.Location = new System.Drawing.Point(3, 113);
            this.label_scope_remark.Name = "label_scope";
            this.label_scope_remark.Size = new System.Drawing.Size(43, 17);
            this.label_scope_remark.TabIndex = 0;
            this.label_scope_remark.Text = "存储引擎的作用范围";
            this.tlpMake.Controls.Add(this.label_scope_remark, 2, 5);
    
            //
            // tb_scope
            //
            this.tb_scope = new System.Windows.Forms.TextBox();
            this.tb_scope.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_scope.Location = new System.Drawing.Point(189, 50);
            this.tb_scope.Name = "tb_scope";
            this.tb_scope.Size = new System.Drawing.Size(363, 23);
            this.tb_scope.TabIndex = 1;
            this.tlpMake.Controls.Add(this.tb_scope, 1, 5);
            this.tlpMake.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
    
            //
            // label_accessKey
            //
            this.label_accessKey_name = new System.Windows.Forms.Label();
            this.label_accessKey_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_accessKey_name.AutoSize = true;
            this.label_accessKey_name.Location = new System.Drawing.Point(3, 113);
            this.label_accessKey_name.Name = "label_accessKey";
            this.label_accessKey_name.Size = new System.Drawing.Size(43, 17);
            this.label_accessKey_name.TabIndex = 0;
            this.label_accessKey_name.Text = "accessKey";
            this.tlpMake.Controls.Add(this.label_accessKey_name, 0, 6);
    
            //
            // label_accessKey
            //
            this.label_accessKey_remark = new System.Windows.Forms.Label();
            this.label_accessKey_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_accessKey_remark.AutoSize = true;
            this.label_accessKey_remark.Location = new System.Drawing.Point(3, 113);
            this.label_accessKey_remark.Name = "label_accessKey";
            this.label_accessKey_remark.Size = new System.Drawing.Size(43, 17);
            this.label_accessKey_remark.TabIndex = 0;
            this.label_accessKey_remark.Text = "存储引擎的访问key";
            this.tlpMake.Controls.Add(this.label_accessKey_remark, 2, 6);
    
            //
            // tb_accessKey
            //
            this.tb_accessKey = new System.Windows.Forms.TextBox();
            this.tb_accessKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_accessKey.Location = new System.Drawing.Point(189, 50);
            this.tb_accessKey.Name = "tb_accessKey";
            this.tb_accessKey.Size = new System.Drawing.Size(363, 23);
            this.tb_accessKey.TabIndex = 1;
            this.tlpMake.Controls.Add(this.tb_accessKey, 1, 6);
            this.tlpMake.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
    
            //
            // label_accessSecret
            //
            this.label_accessSecret_name = new System.Windows.Forms.Label();
            this.label_accessSecret_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_accessSecret_name.AutoSize = true;
            this.label_accessSecret_name.Location = new System.Drawing.Point(3, 113);
            this.label_accessSecret_name.Name = "label_accessSecret";
            this.label_accessSecret_name.Size = new System.Drawing.Size(43, 17);
            this.label_accessSecret_name.TabIndex = 0;
            this.label_accessSecret_name.Text = "accessSecret";
            this.tlpMake.Controls.Add(this.label_accessSecret_name, 0, 7);
    
            //
            // label_accessSecret
            //
            this.label_accessSecret_remark = new System.Windows.Forms.Label();
            this.label_accessSecret_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_accessSecret_remark.AutoSize = true;
            this.label_accessSecret_remark.Location = new System.Drawing.Point(3, 113);
            this.label_accessSecret_remark.Name = "label_accessSecret";
            this.label_accessSecret_remark.Size = new System.Drawing.Size(43, 17);
            this.label_accessSecret_remark.TabIndex = 0;
            this.label_accessSecret_remark.Text = "存储引擎的访问secret";
            this.tlpMake.Controls.Add(this.label_accessSecret_remark, 2, 7);
    
            //
            // tb_accessSecret
            //
            this.tb_accessSecret = new System.Windows.Forms.TextBox();
            this.tb_accessSecret.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_accessSecret.Location = new System.Drawing.Point(189, 50);
            this.tb_accessSecret.Name = "tb_accessSecret";
            this.tb_accessSecret.Size = new System.Drawing.Size(363, 23);
            this.tb_accessSecret.TabIndex = 1;
            this.tlpMake.Controls.Add(this.tb_accessSecret, 1, 7);
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
            // label_offset
            //
            this.label_offset_name = new System.Windows.Forms.Label();
            this.label_offset_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_offset_name.AutoSize = true;
            this.label_offset_name.Location = new System.Drawing.Point(3, 113);
            this.label_offset_name.Name = "label_offset";
            this.label_offset_name.Size = new System.Drawing.Size(43, 17);
            this.label_offset_name.TabIndex = 0;
            this.label_offset_name.Text = "offset";
            this.tlpList.Controls.Add(this.label_offset_name, 0, 1);
    
            //
            // label_offset
            //
            this.label_offset_remark = new System.Windows.Forms.Label();
            this.label_offset_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_offset_remark.AutoSize = true;
            this.label_offset_remark.Location = new System.Drawing.Point(3, 113);
            this.label_offset_remark.Name = "label_offset";
            this.label_offset_remark.Size = new System.Drawing.Size(43, 17);
            this.label_offset_remark.TabIndex = 0;
            this.label_offset_remark.Text = "偏移值";
            this.tlpList.Controls.Add(this.label_offset_remark, 2, 1);
    
            //
            // tb_offset
            //
            this.tb_offset = new System.Windows.Forms.TextBox();
            this.tb_offset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_offset.Location = new System.Drawing.Point(189, 50);
            this.tb_offset.Name = "tb_offset";
            this.tb_offset.Size = new System.Drawing.Size(363, 23);
            this.tb_offset.TabIndex = 1;
            this.tlpList.Controls.Add(this.tb_offset, 1, 1);
            this.tlpList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
    
            //
            // label_count
            //
            this.label_count_name = new System.Windows.Forms.Label();
            this.label_count_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_count_name.AutoSize = true;
            this.label_count_name.Location = new System.Drawing.Point(3, 113);
            this.label_count_name.Name = "label_count";
            this.label_count_name.Size = new System.Drawing.Size(43, 17);
            this.label_count_name.TabIndex = 0;
            this.label_count_name.Text = "count";
            this.tlpList.Controls.Add(this.label_count_name, 0, 2);
    
            //
            // label_count
            //
            this.label_count_remark = new System.Windows.Forms.Label();
            this.label_count_remark.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_count_remark.AutoSize = true;
            this.label_count_remark.Location = new System.Drawing.Point(3, 113);
            this.label_count_remark.Name = "label_count";
            this.label_count_remark.Size = new System.Drawing.Size(43, 17);
            this.label_count_remark.TabIndex = 0;
            this.label_count_remark.Text = "数量";
            this.tlpList.Controls.Add(this.label_count_remark, 2, 2);
    
            //
            // tb_count
            //
            this.tb_count = new System.Windows.Forms.TextBox();
            this.tb_count.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_count.Location = new System.Drawing.Point(189, 50);
            this.tb_count.Name = "tb_count";
            this.tb_count.Size = new System.Drawing.Size(363, 23);
            this.tb_count.TabIndex = 1;
            this.tlpList.Controls.Add(this.tb_count, 1, 2);
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
    
        private System.Windows.Forms.TableLayoutPanel tlpMake;
        private System.Windows.Forms.Label label_Make_name;
        private System.Windows.Forms.Label label_Make_value;
        private System.Windows.Forms.Label label_Make_remark;
    
        private System.Windows.Forms.Label label_name_name;
    
        private System.Windows.Forms.Label label_name_remark;
    
        private System.Windows.Forms.TextBox tb_name;
    
        private System.Windows.Forms.Label label_capacity_name;
    
        private System.Windows.Forms.Label label_capacity_remark;
    
        private System.Windows.Forms.TextBox tb_capacity;
    
        private System.Windows.Forms.Label label_engine_name;
    
        private System.Windows.Forms.Label label_engine_remark;
    
        private System.Windows.Forms.TextBox tb_engine;
    
        private System.Windows.Forms.Label label_address_name;
    
        private System.Windows.Forms.Label label_address_remark;
    
        private System.Windows.Forms.TextBox tb_address;
    
        private System.Windows.Forms.Label label_scope_name;
    
        private System.Windows.Forms.Label label_scope_remark;
    
        private System.Windows.Forms.TextBox tb_scope;
    
        private System.Windows.Forms.Label label_accessKey_name;
    
        private System.Windows.Forms.Label label_accessKey_remark;
    
        private System.Windows.Forms.TextBox tb_accessKey;
    
        private System.Windows.Forms.Label label_accessSecret_name;
    
        private System.Windows.Forms.Label label_accessSecret_remark;
    
        private System.Windows.Forms.TextBox tb_accessSecret;
    
        private System.Windows.Forms.Button btnSubmitMake;
        private void btnSubmitMake_Click(object sender, System.EventArgs e)
        {
            IBucketViewBridge bridge =  facade.getViewBridge() as IBucketViewBridge;
            
            string name = this.tb_name.Text;
    
            long capacity;
            long.TryParse(this.tb_capacity.Text, out capacity);
    
            int engine;
            int.TryParse(this.tb_engine.Text, out engine);
    
            string address = this.tb_address.Text;
    
            string scope = this.tb_scope.Text;
    
            string accessKey = this.tb_accessKey.Text;
    
            string accessSecret = this.tb_accessSecret.Text;
    
            bridge.OnMakeSubmit(name, capacity, engine, address, scope, accessKey, accessSecret);
        }
    
        private System.Windows.Forms.TabPage tabPageList;
    
        private System.Windows.Forms.TableLayoutPanel tlpList;
        private System.Windows.Forms.Label label_List_name;
        private System.Windows.Forms.Label label_List_value;
        private System.Windows.Forms.Label label_List_remark;
    
        private System.Windows.Forms.Label label_offset_name;
    
        private System.Windows.Forms.Label label_offset_remark;
    
        private System.Windows.Forms.TextBox tb_offset;
    
        private System.Windows.Forms.Label label_count_name;
    
        private System.Windows.Forms.Label label_count_remark;
    
        private System.Windows.Forms.TextBox tb_count;
    
        private System.Windows.Forms.Button btnSubmitList;
        private void btnSubmitList_Click(object sender, System.EventArgs e)
        {
            IBucketViewBridge bridge =  facade.getViewBridge() as IBucketViewBridge;
            
            long offset;
            long.TryParse(this.tb_offset.Text, out offset);
    
            long count;
            long.TryParse(this.tb_count.Text, out count);
    
            bridge.OnListSubmit(offset, count);
        }
    
        private System.Windows.Forms.TabPage tabPageRemove;
    
        private System.Windows.Forms.TabPage tabPageGet;
    
        private System.Windows.Forms.TabPage tabPageFind;
    
        private System.Windows.Forms.TabPage tabPageUpdateEngine;
    
        private System.Windows.Forms.TabPage tabPageUpdateCapacity;
    
        private System.Windows.Forms.TabPage tabPageResetToken;
    
    }
}
