namespace Registry_Tools
{
    partial class list
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(list));
            this.dgv_values = new System.Windows.Forms.DataGridView();
            this.gbox_ver = new System.Windows.Forms.GroupBox();
            this.chk_otros = new System.Windows.Forms.CheckBox();
            this.chk_style = new System.Windows.Forms.CheckBox();
            this.chk_perf = new System.Windows.Forms.CheckBox();
            this.chk_block = new System.Windows.Forms.CheckBox();
            this.gbox_cargar = new System.Windows.Forms.GroupBox();
            this.cmb_cargar = new System.Windows.Forms.ComboBox();
            this.btn_del = new System.Windows.Forms.Button();
            this.btn_cargar = new System.Windows.Forms.Button();
            this.imgL = new System.Windows.Forms.ImageList(this.components);
            this.txt_ListEnum = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.txt_KeyRoot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_SubKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_DataO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_Desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_values)).BeginInit();
            this.gbox_ver.SuspendLayout();
            this.gbox_cargar.SuspendLayout();
            this.SuspendLayout();
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
            this.txt_ListEnum,
            this.txt_KeyRoot,
            this.txt_SubKey,
            this.txt_Name,
            this.txt_Type,
            this.txt_Data,
            this.txt_DataO,
            this.txt_Desc});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_values.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_values.GridColor = System.Drawing.SystemColors.Window;
            this.dgv_values.Location = new System.Drawing.Point(12, 12);
            this.dgv_values.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.dgv_values.MultiSelect = false;
            this.dgv_values.Name = "dgv_values";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_values.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_values.RowHeadersVisible = false;
            this.dgv_values.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_values.Size = new System.Drawing.Size(667, 232);
            this.dgv_values.TabIndex = 3;
            this.dgv_values.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_values_CellValueChanged);
            this.dgv_values.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_values_CellDoubleClick);
            this.dgv_values.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_values_CellDoubleClick);
            this.dgv_values.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_values_CellEnter);
            // 
            // gbox_ver
            // 
            this.gbox_ver.Controls.Add(this.chk_otros);
            this.gbox_ver.Controls.Add(this.chk_style);
            this.gbox_ver.Controls.Add(this.chk_perf);
            this.gbox_ver.Controls.Add(this.chk_block);
            this.gbox_ver.Location = new System.Drawing.Point(12, 250);
            this.gbox_ver.Name = "gbox_ver";
            this.gbox_ver.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.gbox_ver.Size = new System.Drawing.Size(315, 55);
            this.gbox_ver.TabIndex = 0;
            this.gbox_ver.TabStop = false;
            this.gbox_ver.Text = "Ver";
            // 
            // chk_otros
            // 
            this.chk_otros.AutoSize = true;
            this.chk_otros.Checked = true;
            this.chk_otros.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_otros.Location = new System.Drawing.Point(250, 21);
            this.chk_otros.Name = "chk_otros";
            this.chk_otros.Size = new System.Drawing.Size(55, 17);
            this.chk_otros.TabIndex = 3;
            this.chk_otros.Text = "Otros";
            this.chk_otros.UseVisualStyleBackColor = true;
            this.chk_otros.CheckedChanged += new System.EventHandler(this.chk_otros_CheckedChanged);
            // 
            // chk_style
            // 
            this.chk_style.AutoSize = true;
            this.chk_style.Checked = true;
            this.chk_style.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_style.Location = new System.Drawing.Point(190, 21);
            this.chk_style.Name = "chk_style";
            this.chk_style.Size = new System.Drawing.Size(54, 17);
            this.chk_style.TabIndex = 2;
            this.chk_style.Text = "Estilo";
            this.chk_style.UseVisualStyleBackColor = true;
            this.chk_style.CheckedChanged += new System.EventHandler(this.chk_style_CheckedChanged);
            // 
            // chk_perf
            // 
            this.chk_perf.AutoSize = true;
            this.chk_perf.Checked = true;
            this.chk_perf.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_perf.Location = new System.Drawing.Point(97, 21);
            this.chk_perf.Name = "chk_perf";
            this.chk_perf.Size = new System.Drawing.Size(87, 17);
            this.chk_perf.TabIndex = 1;
            this.chk_perf.Text = "Desempeño";
            this.chk_perf.UseVisualStyleBackColor = true;
            this.chk_perf.CheckedChanged += new System.EventHandler(this.chk_perf_CheckedChanged);
            // 
            // chk_block
            // 
            this.chk_block.AutoSize = true;
            this.chk_block.Checked = true;
            this.chk_block.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_block.Location = new System.Drawing.Point(16, 21);
            this.chk_block.Name = "chk_block";
            this.chk_block.Size = new System.Drawing.Size(75, 17);
            this.chk_block.TabIndex = 0;
            this.chk_block.Text = "Bloqueos";
            this.chk_block.UseVisualStyleBackColor = true;
            this.chk_block.CheckedChanged += new System.EventHandler(this.chk_block_CheckedChanged);
            // 
            // gbox_cargar
            // 
            this.gbox_cargar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbox_cargar.Controls.Add(this.cmb_cargar);
            this.gbox_cargar.Controls.Add(this.btn_del);
            this.gbox_cargar.Controls.Add(this.btn_cargar);
            this.gbox_cargar.Location = new System.Drawing.Point(333, 250);
            this.gbox_cargar.Name = "gbox_cargar";
            this.gbox_cargar.Size = new System.Drawing.Size(346, 55);
            this.gbox_cargar.TabIndex = 1;
            this.gbox_cargar.TabStop = false;
            this.gbox_cargar.Text = "Cargar/Eliminar una lista";
            // 
            // cmb_cargar
            // 
            this.cmb_cargar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_cargar.FormattingEnabled = true;
            this.cmb_cargar.Location = new System.Drawing.Point(6, 21);
            this.cmb_cargar.Name = "cmb_cargar";
            this.cmb_cargar.Size = new System.Drawing.Size(172, 21);
            this.cmb_cargar.TabIndex = 2;
            // 
            // btn_del
            // 
            this.btn_del.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_del.Location = new System.Drawing.Point(184, 19);
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(75, 23);
            this.btn_del.TabIndex = 3;
            this.btn_del.Text = "Eliminar";
            this.btn_del.UseVisualStyleBackColor = true;
            // 
            // btn_cargar
            // 
            this.btn_cargar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cargar.Location = new System.Drawing.Point(265, 19);
            this.btn_cargar.Name = "btn_cargar";
            this.btn_cargar.Size = new System.Drawing.Size(75, 23);
            this.btn_cargar.TabIndex = 2;
            this.btn_cargar.Text = "Cargar";
            this.btn_cargar.UseVisualStyleBackColor = true;
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
            // txt_ListEnum
            // 
            this.txt_ListEnum.HeaderText = "";
            this.txt_ListEnum.Name = "txt_ListEnum";
            this.txt_ListEnum.Width = 30;
            // 
            // txt_KeyRoot
            // 
            this.txt_KeyRoot.HeaderText = "KeyRoot";
            this.txt_KeyRoot.Name = "txt_KeyRoot";
            this.txt_KeyRoot.ReadOnly = true;
            this.txt_KeyRoot.Visible = false;
            // 
            // txt_SubKey
            // 
            this.txt_SubKey.HeaderText = "SubKey";
            this.txt_SubKey.Name = "txt_SubKey";
            this.txt_SubKey.ReadOnly = true;
            this.txt_SubKey.Visible = false;
            // 
            // txt_Name
            // 
            this.txt_Name.HeaderText = "Nombre";
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.ReadOnly = true;
            this.txt_Name.Width = 300;
            // 
            // txt_Type
            // 
            this.txt_Type.HeaderText = "Tipo";
            this.txt_Type.Name = "txt_Type";
            this.txt_Type.Visible = false;
            // 
            // txt_Data
            // 
            this.txt_Data.HeaderText = "Actual";
            this.txt_Data.Name = "txt_Data";
            this.txt_Data.ReadOnly = true;
            this.txt_Data.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.txt_Data.Width = 120;
            // 
            // txt_DataO
            // 
            this.txt_DataO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.txt_DataO.HeaderText = "Recomendado";
            this.txt_DataO.Name = "txt_DataO";
            this.txt_DataO.ReadOnly = true;
            this.txt_DataO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // txt_Desc
            // 
            this.txt_Desc.HeaderText = "Descripcion";
            this.txt_Desc.Name = "txt_Desc";
            this.txt_Desc.ReadOnly = true;
            this.txt_Desc.Visible = false;
            // 
            // list
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 317);
            this.Controls.Add(this.gbox_ver);
            this.Controls.Add(this.gbox_cargar);
            this.Controls.Add(this.dgv_values);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "list";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de comandos";
            this.Load += new System.EventHandler(this.list_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_values)).EndInit();
            this.gbox_ver.ResumeLayout(false);
            this.gbox_ver.PerformLayout();
            this.gbox_cargar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_values;
        public System.Windows.Forms.ImageList imgL;
        private System.Windows.Forms.GroupBox gbox_ver;
        private System.Windows.Forms.CheckBox chk_otros;
        private System.Windows.Forms.CheckBox chk_style;
        private System.Windows.Forms.CheckBox chk_perf;
        private System.Windows.Forms.CheckBox chk_block;
        private System.Windows.Forms.GroupBox gbox_cargar;
        private System.Windows.Forms.Button btn_cargar;
        private System.Windows.Forms.ComboBox cmb_cargar;
        private System.Windows.Forms.Button btn_del;
        private System.Windows.Forms.DataGridViewCheckBoxColumn txt_ListEnum;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_KeyRoot;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_SubKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_DataO;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_Desc;
    }
}