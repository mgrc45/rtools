using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace Registry_Tools
{
    public partial class list : Form
    {
        public string RootKey = "", SubKey = "", ValueName = "";
        public string ValueType = "", ValueData = "", ValueDesc = "";
        public string ValueDataOrg = "", ValueDataO = "", ValueDataDesc = "";
        //private DataViewManager dsView;
        BindingSource dSource = new BindingSource();

        public list()
        {
            InitializeComponent();
        }
        private void list_Load(object sender, EventArgs e)
        {
            // Vinculo el Datagrid view
            txt_KeyRoot.DataPropertyName = "RootKey";
            txt_SubKey.DataPropertyName = "SubKey";
            txt_Name.DataPropertyName = "Name";
            txt_Type.DataPropertyName = "Type";
            //txt_Data.DataPropertyName = "";
            txt_DataO.DataPropertyName = "Value Optimal";
            //txt_Kind.DataPropertyName = "Kind";
            txt_Desc.DataPropertyName = "Description";
            //txt_ver.DataPropertyName = "Version";
            //txt_danger.DataPropertyName = "dangerous";
            //txt_RegId.DataPropertyName = "registry";

            dgv_values.AutoGenerateColumns = false;
            dgv_values.AutoSize = true;
            //dsView = principal.ds.DefaultViewManager;
            //dgv_values.DataSource = dsView;
            //dgv_values.DataMember = "Valores";
            //dgv_values.ReadOnly = true;
            //dgv_values.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dSource = new BindingSource();
            dSource.DataSource = principal.ds.DefaultViewManager;
            dSource.DataMember = "Valores";
            dSource.Filter = ""; //Ejem. "Kind = 'DESEMPEÑO'"
            dgv_values.DataSource = dSource;
        }

        #region Pestaña:Opciones > Ver
        private void chk_block_CheckedChanged(object sender, EventArgs e)
        {//Changed ocurre despus de cambiar el valor
            recargar();
        }
        private void chk_perf_CheckedChanged(object sender, EventArgs e)
        {
            recargar();
        }
        private void chk_style_CheckedChanged(object sender, EventArgs e)
        {
            recargar();
        }
        private void chk_otros_CheckedChanged(object sender, EventArgs e)
        {
            recargar();
        }

        private void recargar()
        {//Cargo la lista de comandos
            string Kind = "";
            if (chk_block.Checked) Kind += "Kind='BLOQUEO' OR ";
            if (chk_perf.Checked) Kind += "Kind='DESEMPEÑO' OR ";
            if (chk_style.Checked) Kind += "Kind='ESTILO' OR ";
            if (chk_otros.Checked) Kind += "Kind='OTROS' OR ";
            if (Kind != "") Kind = Kind.Substring(0, Kind.Length - 4);
            dSource.Filter = Kind;
        }
        #endregion

        #region dgv_values_CellDoubleClick:Expandir
        private void dgv_values_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {//Al dar doble click a una fila ó al contenido de una fila
            if (dgv_values.Rows.Count < 1) return;
            DataGridViewRow dRowLoc = dgv_values.Rows[e.RowIndex];

            string RootKey = dRowLoc.Cells["txt_KeyRoot"].Value.ToString();
            string SubKey = dRowLoc.Cells["txt_SubKey"].Value.ToString();
            string KeyName = dRowLoc.Cells["txt_Name"].Value.ToString();
            string[] SubKeys = SubKey.Split('\\');


            principal.formMain.tView_reg.SelectedNode = principal.formMain.tView_reg.Nodes[0];
            principal.formMain.tView_reg.SelectedNode.Expand();

            expandT(principal.formMain.tView_reg, RootKey);
            foreach(string SubKey1 in SubKeys)
                if (expandT(principal.formMain.tView_reg, SubKey1)==false) 
                    break;//Donde termina?
        }
        public static bool expandT(TreeView tView, string KeyFind)
        {//Expande el nodo de un TreeView
            bool found = false;
            foreach (TreeNode a in tView.SelectedNode.Nodes)
            {
                if (a.Text.ToLower() == KeyFind.ToLower())
                {
                    tView.SelectedNode = a;
                    a.Expand();
                    found = true;
                    break;
                }
            }
            return found;//break(0) end
        }
        #endregion

        
        private void dgv_values_CellEnter(object sender, DataGridViewCellEventArgs e)
        {//Este evento se activa cuando cambia de fila
            cargar_controles();
        }
        private void dgv_values_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {//Este evento se activa cuando se cambia el valor
            cargar_controles();
        }
        private void cargar_controles()
        {//Carga los controles ante algun cambio del data grid view
        }

 

    }
}
