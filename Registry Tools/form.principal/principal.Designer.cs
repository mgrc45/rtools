namespace Registry_Tools
{
    partial class principal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(principal));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle59 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle60 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle51 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle52 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle53 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle54 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle55 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle56 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle57 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle58 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tView_reg = new System.Windows.Forms.TreeView();
            this.imgL = new System.Windows.Forms.ImageList(this.components);
            this.dgv_values = new System.Windows.Forms.DataGridView();
            this.img_Type = new System.Windows.Forms.DataGridViewImageColumn();
            this.txt_KeyRoot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_SubKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_DataO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_Kind = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_Desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_ver = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_danger = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_RegId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btn_saveVal = new System.Windows.Forms.Button();
            this.lb_valueVal = new System.Windows.Forms.Label();
            this.txt_valueVal = new System.Windows.Forms.MaskedTextBox();
            this.lb_typeVal = new System.Windows.Forms.Label();
            this.cmb_typeVal = new System.Windows.Forms.ComboBox();
            this.lb_nameVal = new System.Windows.Forms.Label();
            this.cmb_nameVal = new System.Windows.Forms.ComboBox();
            this.txt_description = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.chk_danger = new System.Windows.Forms.CheckBox();
            this.chk_7 = new System.Windows.Forms.CheckBox();
            this.chk_xp = new System.Windows.Forms.CheckBox();
            this.lb_valueOpVal = new System.Windows.Forms.Label();
            this.txt_valueOpVal = new System.Windows.Forms.MaskedTextBox();
            this.lb_descVal = new System.Windows.Forms.Label();
            this.txt_descVal = new System.Windows.Forms.TextBox();
            this.lb_KindVal = new System.Windows.Forms.Label();
            this.cmb_KindVal = new System.Windows.Forms.ComboBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.verToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listaDeComandosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeRegistryToolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txt_addr = new System.Windows.Forms.TextBox();
            this.btn_go = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_values)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tView_reg
            // 
            this.tView_reg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.tView_reg.Location = new System.Drawing.Point(6, 27);
            this.tView_reg.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.tView_reg.Name = "tView_reg";
            this.tView_reg.Size = new System.Drawing.Size(236, 476);
            this.tView_reg.TabIndex = 0;
            this.tView_reg.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.tView_reg_AfterCollapse);
            this.tView_reg.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tView_reg_AfterSelect);
            this.tView_reg.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tView_reg_AfterExpand);
            // 
            // imgL
            // 
            this.imgL.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgL.ImageStream")));
            this.imgL.TransparentColor = System.Drawing.Color.Transparent;
            this.imgL.Images.SetKeyName(0, "equipo16.ico");
            this.imgL.Images.SetKeyName(1, "Carpeta abierta 16px.ico");
            this.imgL.Images.SetKeyName(2, "reg_sz 16px.ico");
            this.imgL.Images.SetKeyName(3, "reg_binary 16px.ico");
            // 
            // dgv_values
            // 
            this.dgv_values.AllowUserToAddRows = false;
            this.dgv_values.AllowUserToDeleteRows = false;
            this.dgv_values.AllowUserToResizeRows = false;
            this.dgv_values.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_values.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv_values.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_values.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_values.ColumnHeadersHeight = 30;
            this.dgv_values.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_values.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.img_Type,
            this.txt_KeyRoot,
            this.txt_SubKey,
            this.txt_Name,
            this.txt_Type,
            this.txt_Data,
            this.txt_DataO,
            this.txt_Kind,
            this.txt_Desc,
            this.txt_ver,
            this.txt_danger,
            this.txt_RegId});
            dataGridViewCellStyle59.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle59.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle59.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle59.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle59.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle59.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle59.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_values.DefaultCellStyle = dataGridViewCellStyle59;
            this.dgv_values.GridColor = System.Drawing.SystemColors.Window;
            this.dgv_values.Location = new System.Drawing.Point(248, 55);
            this.dgv_values.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.dgv_values.MultiSelect = false;
            this.dgv_values.Name = "dgv_values";
            dataGridViewCellStyle60.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle60.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle60.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle60.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle60.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle60.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle60.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_values.RowHeadersDefaultCellStyle = dataGridViewCellStyle60;
            this.dgv_values.RowHeadersVisible = false;
            this.dgv_values.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_values.Size = new System.Drawing.Size(621, 260);
            this.dgv_values.TabIndex = 2;
            this.dgv_values.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_values_RowEnter);
            // 
            // img_Type
            // 
            this.img_Type.HeaderText = "";
            this.img_Type.Name = "img_Type";
            this.img_Type.ReadOnly = true;
            this.img_Type.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.img_Type.Width = 30;
            // 
            // txt_KeyRoot
            // 
            dataGridViewCellStyle51.NullValue = "\"\"";
            this.txt_KeyRoot.DefaultCellStyle = dataGridViewCellStyle51;
            this.txt_KeyRoot.HeaderText = "KeyRoot";
            this.txt_KeyRoot.Name = "txt_KeyRoot";
            this.txt_KeyRoot.ReadOnly = true;
            this.txt_KeyRoot.Visible = false;
            // 
            // txt_SubKey
            // 
            dataGridViewCellStyle52.NullValue = "\"\"";
            this.txt_SubKey.DefaultCellStyle = dataGridViewCellStyle52;
            this.txt_SubKey.HeaderText = "SubKey";
            this.txt_SubKey.Name = "txt_SubKey";
            this.txt_SubKey.ReadOnly = true;
            this.txt_SubKey.Visible = false;
            // 
            // txt_Name
            // 
            dataGridViewCellStyle53.NullValue = "\"\"";
            this.txt_Name.DefaultCellStyle = dataGridViewCellStyle53;
            this.txt_Name.HeaderText = "Nombre";
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.ReadOnly = true;
            this.txt_Name.Width = 200;
            // 
            // txt_Type
            // 
            dataGridViewCellStyle54.NullValue = "REG_NONE";
            this.txt_Type.DefaultCellStyle = dataGridViewCellStyle54;
            this.txt_Type.HeaderText = "Tipo";
            this.txt_Type.Name = "txt_Type";
            this.txt_Type.ReadOnly = true;
            this.txt_Type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.txt_Type.Width = 120;
            // 
            // txt_Data
            // 
            this.txt_Data.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle55.NullValue = "\"\"";
            this.txt_Data.DefaultCellStyle = dataGridViewCellStyle55;
            this.txt_Data.HeaderText = "Datos";
            this.txt_Data.Name = "txt_Data";
            this.txt_Data.ReadOnly = true;
            this.txt_Data.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // txt_DataO
            // 
            dataGridViewCellStyle56.NullValue = "\"\"";
            this.txt_DataO.DefaultCellStyle = dataGridViewCellStyle56;
            this.txt_DataO.HeaderText = "Recomendado";
            this.txt_DataO.Name = "txt_DataO";
            this.txt_DataO.ReadOnly = true;
            this.txt_DataO.Visible = false;
            // 
            // txt_Kind
            // 
            dataGridViewCellStyle57.NullValue = "\"\"";
            this.txt_Kind.DefaultCellStyle = dataGridViewCellStyle57;
            this.txt_Kind.HeaderText = "Tipo de bloqueo";
            this.txt_Kind.Name = "txt_Kind";
            this.txt_Kind.ReadOnly = true;
            this.txt_Kind.Visible = false;
            // 
            // txt_Desc
            // 
            dataGridViewCellStyle58.NullValue = "\"\"";
            this.txt_Desc.DefaultCellStyle = dataGridViewCellStyle58;
            this.txt_Desc.HeaderText = "Descripcion";
            this.txt_Desc.Name = "txt_Desc";
            this.txt_Desc.ReadOnly = true;
            this.txt_Desc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.txt_Desc.Visible = false;
            // 
            // txt_ver
            // 
            this.txt_ver.HeaderText = "Versiones soportadas";
            this.txt_ver.Name = "txt_ver";
            this.txt_ver.Visible = false;
            // 
            // txt_danger
            // 
            this.txt_danger.HeaderText = "Peligroso";
            this.txt_danger.Name = "txt_danger";
            this.txt_danger.Visible = false;
            // 
            // txt_RegId
            // 
            this.txt_RegId.HeaderText = "Identificador";
            this.txt_RegId.Name = "txt_RegId";
            this.txt_RegId.Visible = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(248, 321);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(621, 182);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Window;
            this.tabPage1.Controls.Add(this.btn_saveVal);
            this.tabPage1.Controls.Add(this.lb_valueVal);
            this.tabPage1.Controls.Add(this.txt_valueVal);
            this.tabPage1.Controls.Add(this.lb_typeVal);
            this.tabPage1.Controls.Add(this.cmb_typeVal);
            this.tabPage1.Controls.Add(this.lb_nameVal);
            this.tabPage1.Controls.Add(this.cmb_nameVal);
            this.tabPage1.Controls.Add(this.txt_description);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(613, 156);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Valor";
            // 
            // btn_saveVal
            // 
            this.btn_saveVal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_saveVal.Location = new System.Drawing.Point(502, 116);
            this.btn_saveVal.Margin = new System.Windows.Forms.Padding(8, 3, 10, 3);
            this.btn_saveVal.Name = "btn_saveVal";
            this.btn_saveVal.Size = new System.Drawing.Size(98, 25);
            this.btn_saveVal.TabIndex = 29;
            this.btn_saveVal.Text = "Guardar";
            this.btn_saveVal.UseVisualStyleBackColor = true;
            this.btn_saveVal.Click += new System.EventHandler(this.btn_saveVal_Click);
            // 
            // lb_valueVal
            // 
            this.lb_valueVal.AutoSize = true;
            this.lb_valueVal.BackColor = System.Drawing.SystemColors.Window;
            this.lb_valueVal.Location = new System.Drawing.Point(336, 102);
            this.lb_valueVal.Margin = new System.Windows.Forms.Padding(8, 8, 3, 0);
            this.lb_valueVal.Name = "lb_valueVal";
            this.lb_valueVal.Size = new System.Drawing.Size(68, 13);
            this.lb_valueVal.TabIndex = 21;
            this.lb_valueVal.Text = "Valor actual";
            // 
            // txt_valueVal
            // 
            this.txt_valueVal.Location = new System.Drawing.Point(339, 119);
            this.txt_valueVal.Margin = new System.Windows.Forms.Padding(8, 3, 3, 3);
            this.txt_valueVal.Name = "txt_valueVal";
            this.txt_valueVal.Size = new System.Drawing.Size(152, 22);
            this.txt_valueVal.TabIndex = 22;
            // 
            // lb_typeVal
            // 
            this.lb_typeVal.AutoSize = true;
            this.lb_typeVal.Location = new System.Drawing.Point(173, 102);
            this.lb_typeVal.Margin = new System.Windows.Forms.Padding(8, 8, 3, 0);
            this.lb_typeVal.Name = "lb_typeVal";
            this.lb_typeVal.Size = new System.Drawing.Size(73, 13);
            this.lb_typeVal.TabIndex = 19;
            this.lb_typeVal.Text = "Tipo de valor";
            // 
            // cmb_typeVal
            // 
            this.cmb_typeVal.FormattingEnabled = true;
            this.cmb_typeVal.Location = new System.Drawing.Point(176, 119);
            this.cmb_typeVal.Margin = new System.Windows.Forms.Padding(8, 3, 3, 3);
            this.cmb_typeVal.Name = "cmb_typeVal";
            this.cmb_typeVal.Size = new System.Drawing.Size(152, 21);
            this.cmb_typeVal.TabIndex = 20;
            // 
            // lb_nameVal
            // 
            this.lb_nameVal.AutoSize = true;
            this.lb_nameVal.Location = new System.Drawing.Point(10, 102);
            this.lb_nameVal.Margin = new System.Windows.Forms.Padding(8, 8, 3, 0);
            this.lb_nameVal.Name = "lb_nameVal";
            this.lb_nameVal.Size = new System.Drawing.Size(95, 13);
            this.lb_nameVal.TabIndex = 17;
            this.lb_nameVal.Text = "Nombre del valor";
            // 
            // cmb_nameVal
            // 
            this.cmb_nameVal.FormattingEnabled = true;
            this.cmb_nameVal.Location = new System.Drawing.Point(13, 119);
            this.cmb_nameVal.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.cmb_nameVal.Name = "cmb_nameVal";
            this.cmb_nameVal.Size = new System.Drawing.Size(152, 21);
            this.cmb_nameVal.TabIndex = 18;
            // 
            // txt_description
            // 
            this.txt_description.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_description.BackColor = System.Drawing.SystemColors.Window;
            this.txt_description.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_description.Location = new System.Drawing.Point(13, 6);
            this.txt_description.Multiline = true;
            this.txt_description.Name = "txt_description";
            this.txt_description.Size = new System.Drawing.Size(587, 85);
            this.txt_description.TabIndex = 3;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Window;
            this.tabPage3.Controls.Add(this.chk_danger);
            this.tabPage3.Controls.Add(this.chk_7);
            this.tabPage3.Controls.Add(this.chk_xp);
            this.tabPage3.Controls.Add(this.lb_valueOpVal);
            this.tabPage3.Controls.Add(this.txt_valueOpVal);
            this.tabPage3.Controls.Add(this.lb_descVal);
            this.tabPage3.Controls.Add(this.txt_descVal);
            this.tabPage3.Controls.Add(this.lb_KindVal);
            this.tabPage3.Controls.Add(this.cmb_KindVal);
            this.tabPage3.Controls.Add(this.btn_save);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(613, 156);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Documentacion";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // chk_danger
            // 
            this.chk_danger.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chk_danger.AutoSize = true;
            this.chk_danger.Location = new System.Drawing.Point(496, 129);
            this.chk_danger.Name = "chk_danger";
            this.chk_danger.Size = new System.Drawing.Size(105, 17);
            this.chk_danger.TabIndex = 31;
            this.chk_danger.Text = "Valor peligroso";
            this.chk_danger.UseVisualStyleBackColor = true;
            // 
            // chk_7
            // 
            this.chk_7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chk_7.AutoSize = true;
            this.chk_7.Location = new System.Drawing.Point(496, 103);
            this.chk_7.Name = "chk_7";
            this.chk_7.Size = new System.Drawing.Size(64, 17);
            this.chk_7.TabIndex = 30;
            this.chk_7.Text = "7 Value";
            this.chk_7.UseVisualStyleBackColor = true;
            // 
            // chk_xp
            // 
            this.chk_xp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chk_xp.AutoSize = true;
            this.chk_xp.Location = new System.Drawing.Point(496, 78);
            this.chk_xp.Name = "chk_xp";
            this.chk_xp.Size = new System.Drawing.Size(70, 17);
            this.chk_xp.TabIndex = 29;
            this.chk_xp.Text = "XP Value";
            this.chk_xp.UseVisualStyleBackColor = true;
            // 
            // lb_valueOpVal
            // 
            this.lb_valueOpVal.AutoSize = true;
            this.lb_valueOpVal.Location = new System.Drawing.Point(5, 10);
            this.lb_valueOpVal.Name = "lb_valueOpVal";
            this.lb_valueOpVal.Size = new System.Drawing.Size(108, 13);
            this.lb_valueOpVal.TabIndex = 22;
            this.lb_valueOpVal.Text = "Valor recomendado";
            // 
            // txt_valueOpVal
            // 
            this.txt_valueOpVal.Location = new System.Drawing.Point(8, 26);
            this.txt_valueOpVal.Margin = new System.Windows.Forms.Padding(8, 3, 3, 3);
            this.txt_valueOpVal.Name = "txt_valueOpVal";
            this.txt_valueOpVal.Size = new System.Drawing.Size(152, 22);
            this.txt_valueOpVal.TabIndex = 23;
            // 
            // lb_descVal
            // 
            this.lb_descVal.AutoSize = true;
            this.lb_descVal.Location = new System.Drawing.Point(5, 59);
            this.lb_descVal.Name = "lb_descVal";
            this.lb_descVal.Size = new System.Drawing.Size(67, 13);
            this.lb_descVal.TabIndex = 25;
            this.lb_descVal.Text = "Descripción";
            // 
            // txt_descVal
            // 
            this.txt_descVal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_descVal.Location = new System.Drawing.Point(8, 76);
            this.txt_descVal.Multiline = true;
            this.txt_descVal.Name = "txt_descVal";
            this.txt_descVal.Size = new System.Drawing.Size(482, 70);
            this.txt_descVal.TabIndex = 24;
            // 
            // lb_KindVal
            // 
            this.lb_KindVal.AutoSize = true;
            this.lb_KindVal.Location = new System.Drawing.Point(168, 10);
            this.lb_KindVal.Margin = new System.Windows.Forms.Padding(8, 8, 3, 0);
            this.lb_KindVal.Name = "lb_KindVal";
            this.lb_KindVal.Size = new System.Drawing.Size(71, 13);
            this.lb_KindVal.TabIndex = 26;
            this.lb_KindVal.Text = "Clasificacion";
            // 
            // cmb_KindVal
            // 
            this.cmb_KindVal.FormattingEnabled = true;
            this.cmb_KindVal.Location = new System.Drawing.Point(171, 26);
            this.cmb_KindVal.Margin = new System.Windows.Forms.Padding(8, 3, 3, 3);
            this.cmb_KindVal.Name = "cmb_KindVal";
            this.cmb_KindVal.Size = new System.Drawing.Size(152, 21);
            this.cmb_KindVal.TabIndex = 27;
            // 
            // btn_save
            // 
            this.btn_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_save.Location = new System.Drawing.Point(496, 22);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(105, 25);
            this.btn_save.TabIndex = 28;
            this.btn_save.Text = "Guardar";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(876, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // verToolStripMenuItem
            // 
            this.verToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listaDeComandosToolStripMenuItem});
            this.verToolStripMenuItem.Name = "verToolStripMenuItem";
            this.verToolStripMenuItem.Size = new System.Drawing.Size(36, 20);
            this.verToolStripMenuItem.Text = "Ver";
            // 
            // listaDeComandosToolStripMenuItem
            // 
            this.listaDeComandosToolStripMenuItem.Name = "listaDeComandosToolStripMenuItem";
            this.listaDeComandosToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.listaDeComandosToolStripMenuItem.Text = "Lista de comandos";
            this.listaDeComandosToolStripMenuItem.Click += new System.EventHandler(this.listaDeComandosToolStripMenuItem_Click);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acercaDeRegistryToolsToolStripMenuItem});
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // acercaDeRegistryToolsToolStripMenuItem
            // 
            this.acercaDeRegistryToolsToolStripMenuItem.Name = "acercaDeRegistryToolsToolStripMenuItem";
            this.acercaDeRegistryToolsToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.acercaDeRegistryToolsToolStripMenuItem.Text = "Acerca de registry tools";
            this.acercaDeRegistryToolsToolStripMenuItem.Click += new System.EventHandler(this.acercaDeRegistryToolsToolStripMenuItem_Click);
            // 
            // txt_addr
            // 
            this.txt_addr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_addr.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_addr.Location = new System.Drawing.Point(248, 27);
            this.txt_addr.Name = "txt_addr";
            this.txt_addr.Size = new System.Drawing.Size(557, 25);
            this.txt_addr.TabIndex = 7;
            // 
            // btn_go
            // 
            this.btn_go.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_go.Location = new System.Drawing.Point(809, 27);
            this.btn_go.Name = "btn_go";
            this.btn_go.Size = new System.Drawing.Size(60, 25);
            this.btn_go.TabIndex = 8;
            this.btn_go.Text = "Ir";
            this.btn_go.UseVisualStyleBackColor = true;
            this.btn_go.Click += new System.EventHandler(this.btn_go_Click);
            // 
            // principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(876, 515);
            this.Controls.Add(this.txt_addr);
            this.Controls.Add(this.btn_go);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.dgv_values);
            this.Controls.Add(this.tView_reg);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registry Tools: Explorador";
            this.Load += new System.EventHandler(this.principal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_values)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem verToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listaDeComandosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeRegistryToolsToolStripMenuItem;
        public System.Windows.Forms.ImageList imgL;
        private System.Windows.Forms.TextBox txt_description;
        public System.Windows.Forms.TreeView tView_reg;
        public System.Windows.Forms.DataGridView dgv_values;
        private System.Windows.Forms.TextBox txt_addr;
        private System.Windows.Forms.Button btn_go;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label lb_valueOpVal;
        private System.Windows.Forms.MaskedTextBox txt_valueOpVal;
        private System.Windows.Forms.Label lb_descVal;
        private System.Windows.Forms.TextBox txt_descVal;
        private System.Windows.Forms.Label lb_KindVal;
        private System.Windows.Forms.ComboBox cmb_KindVal;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.CheckBox chk_danger;
        private System.Windows.Forms.CheckBox chk_7;
        private System.Windows.Forms.CheckBox chk_xp;
        private System.Windows.Forms.Button btn_saveVal;
        private System.Windows.Forms.Label lb_valueVal;
        private System.Windows.Forms.MaskedTextBox txt_valueVal;
        private System.Windows.Forms.Label lb_typeVal;
        private System.Windows.Forms.ComboBox cmb_typeVal;
        private System.Windows.Forms.Label lb_nameVal;
        private System.Windows.Forms.ComboBox cmb_nameVal;
        private System.Windows.Forms.DataGridViewImageColumn img_Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_KeyRoot;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_SubKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_DataO;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_Kind;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_Desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_ver;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_danger;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_RegId;
        private System.Windows.Forms.BindingSource customersBindingSource;

    }
}