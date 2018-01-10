using System;
using System.Data; //DataTable, DataRow, DataViewManager, DataSet
using System.Windows.Forms;
//using Microsoft.Win32; //Registry (Depreciado)
using System.Runtime.InteropServices; //"Marshal"
using System.Data.OleDb; // OleDbConnection

namespace Registry_Tools
{
    public struct RegValType
    {//Utilizada para llenar combos
        private string _shortName, _longName;

        public RegValType(string longName, string shortName)
        {
            this._shortName = shortName;
            this._longName = longName;
        }

        public string ShortName { get { return _shortName; } }
        public string LongName { get { return _longName; } }
    }
    public partial class principal : Form
    {
        private OleDbConnection dbConexionAccess;

        public static principal formMain;
        public static DataSet ds = new DataSet();
        private DataTable dtNavVal = new DataTable();
        public static string so = "", soString = "";
        //private cTiming cClock = new cTiming(); 
        
        public principal()
        {
            InitializeComponent();
        }
        private void principal_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'northwindDataSet.Customers' Puede moverla o quitarla según sea necesario.
            //this.customersTableAdapter.Fill(this.northwindDataSet.Customers);
            //Creo instancia statica del formulario -------------------------------
            formMain = this;
            // Obtengo el sistema operativo usado ---------------------------------
            OSVERSIONINFO os = new OSVERSIONINFO();
            os.dwOSVersionInfoSize = Marshal.SizeOf(typeof(OSVERSIONINFO));
            Kernel.GetVersionEx(ref os);

            switch (os.dwMajorVersion)
            {//Sistema operativo
                case 3:
                    soString = "Windows NT 3.51";
                    break;
                case 4:
                    soString = "Windows 95, 98, Me y NT 4.0";
                    break;
                case 5:
                    so = "XP";
                    //Console.WriteLine("Windows 2000, XP y 2003");
                    switch (os.dwMinorVersion)
                    {//Sistema operativo
                        case 0: soString = "Windows 2000"; break;
                        case 1: soString = "Windows XP"; break;
                        case 2: soString = "Windows 2003"; break;
                    }
                    break;
                case 6:
                    so = "7";
                    //Console.WriteLine("Windows Vista/Longhorn");
                    switch (os.dwMinorVersion)
                    {//Sistema operativo
                        case 0: soString = "Windows Vista/Longhorn"; break;
                        case 1: soString = "Windows 7"; break;
                        case 2: soString = "Windows 8"; break;
                    }
                    break;
                default: break;
            }
            //Cargo las llaves raiz del control TreeView --------------------------
            tView_reg.ImageList = imgL;
            tView_reg.ImageIndex = 1;
            tView_reg.SelectedImageIndex = 1;

            tView_reg.Nodes.Add("Equipo", "Equipo", 0, 0);
            tView_reg.Nodes["Equipo"].Nodes.Add("HKCR", "HKEY_CLASSES_ROOT", 1);
            tView_reg.Nodes["Equipo"].Nodes.Add("HKCU", "HKEY_CURRENT_USER", 1);
            tView_reg.Nodes["Equipo"].Nodes.Add("HKLM", "HKEY_LOCAL_MACHINE", 1);
            tView_reg.Nodes["Equipo"].Nodes.Add("HKU", "HKEY_USERS", 1);
            tView_reg.Nodes["Equipo"].Nodes.Add("HKCC", "HKEY_CURRENT_CONFIG", 1);

            TreeNode HKCR = tView_reg.Nodes["Equipo"].Nodes["HKCR"];
            TreeNode HKCU = tView_reg.Nodes["Equipo"].Nodes["HKCU"];
            TreeNode HKLM = tView_reg.Nodes["Equipo"].Nodes["HKLM"];
            TreeNode HKU = tView_reg.Nodes["Equipo"].Nodes["HKU"];
            TreeNode HKCC = tView_reg.Nodes["Equipo"].Nodes["HKCC"];

            cargarSubNivel(ref HKCR, ROOT_KEY.HKEY_CLASSES_ROOT, "");
            cargarSubNivel(ref HKCU, ROOT_KEY.HKEY_CURRENT_USER, "");
            cargarSubNivel(ref HKLM, ROOT_KEY.HKEY_LOCAL_MACHINE, "");
            cargarSubNivel(ref HKU, ROOT_KEY.HKEY_USERS, "");
            cargarSubNivel(ref HKCC, ROOT_KEY.HKEY_CURRENT_CONFIG, "");

            tView_reg.Nodes["Equipo"].Expand();
            //Realizo la conexion a Access ----------------------------------------
            string strCnnAccess;
            strCnnAccess = "Provider=Microsoft.ACE.OLEDB.12.0; ";
            strCnnAccess += "Data Source=";
            strCnnAccess += Application.StartupPath + "\\Base de Datos.accdb; ";
            strCnnAccess += "Persist Security Info=False; ";

            try
            {
                dbConexionAccess = new OleDbConnection(strCnnAccess);
                dbConexionAccess.Open();
                dbConexionAccess.Close();
            }
            catch
            {
                dbConexionAccess.Close();
                //Mensaje base de datos no encontrada cerrar
            }
            //Obtengo el valor de una fila (plantilla)
            string query = "SELECT * FROM Valores";
            OleDbDataAdapter da = new OleDbDataAdapter();
            da.SelectCommand = new OleDbCommand(query, dbConexionAccess);
            //sBuilder = new OleDbCommandBuilder(da);
            //da.SelectCommand.CommandTimeout = 0;
            Application.DoEvents();
            try
            {
                da.Fill(ds);
                ds.Tables["Table"].TableName = "Valores";
                dtNavVal = ds.Tables["Valores"].Clone(); //Plantilla
                dbConexionAccess.Close();
            }
            catch
            {
                if (dbConexionAccess != null) dbConexionAccess.Close();
            }
            dtNavVal.Columns["dangerous"].DefaultValue = 0;
            dtNavVal.Columns["Kind"].DefaultValue = "OTROS";
            //---------------------------------------------------------------------
          
            Databindings(); //Relaciono controles
        }
        #region Databinding Controls
        private void Databindings()
        {
            //Nota: Genero las vinculaciones en tiempo de ejecucion, por que si lo
            //definiera en el designer. Podria ser modificado por alguna función del IDE.

            txt_KeyRoot.DataPropertyName = "RootKey";
            txt_SubKey.DataPropertyName = "SubKey";
            txt_Name.DataPropertyName = "Name";
            txt_Type.DataPropertyName = "Type";
            txt_Data.DataPropertyName = "Value";
            txt_DataO.DataPropertyName = "Value Optimal";
            txt_Kind.DataPropertyName = "Kind";
            txt_Desc.DataPropertyName = "Description";
            txt_ver.DataPropertyName = "Version";
            txt_danger.DataPropertyName = "dangerous";
            txt_RegId.DataPropertyName = "registry";

            dgv_values.AutoGenerateColumns = false;
            dgv_values.AutoSize = true;

            dgv_values.DataSource = dtNavVal;
            //dgv_values.ReadOnly = true;
            //dgv_values.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //Cargo el combobox: "cmb_type"
            System.Collections.ArrayList ARR_NEW = new System.Collections.ArrayList();
            System.Array ARR_BRUTO = Enum.GetValues(typeof(VALUE_TYPE));
            foreach (var value in ARR_BRUTO)
            {
                bool seguro = true;
                foreach (string item in ARR_NEW)
                    if (item == value.ToString()) seguro = false;

                if (seguro) ARR_NEW.Add(value.ToString());
            }
            RegValType[] tipoValor = new RegValType[ARR_NEW.Count];
            for (int i = 0; i < ARR_NEW.Count; i++)
            {
                string valorStr = ARR_NEW[i].ToString();
                tipoValor[i] = new RegValType(valorStr, valorStr);
            }

            //Cargo el combobox: "cmb_KindVal"
            RegValType[] classValor = new RegValType[4];
            classValor[0] = new RegValType("BLOQUEO", "BLOQUEO");
            classValor[1] = new RegValType("DESEMPEÑO", "DESEMPEÑO");
            classValor[2] = new RegValType("ESTILO", "ESTILO");
            classValor[3] = new RegValType("OTROS", "OTROS");

            // ComboBox Vinculando-Datos(Databinding) -----------------------------
            cmb_typeVal.DataSource = tipoValor;
            cmb_typeVal.DisplayMember = "LongName";
            cmb_typeVal.ValueMember = "ShortName";
            cmb_typeVal.DataBindings.Add("SelectedValue", dtNavVal, "Type");

            cmb_KindVal.DataSource = classValor;
            cmb_KindVal.DisplayMember = "LongName";
            cmb_KindVal.ValueMember = "ShortName";
            cmb_KindVal.DataBindings.Add("SelectedValue", dtNavVal, "Kind");

            // Columnas de texto Vinculando-Datos(Databinding)
            cmb_nameVal.DataBindings.Add("Text", dtNavVal, "Name");
            txt_description.DataBindings.Add("Text", dtNavVal, "Description");
            txt_descVal.DataBindings.Add("Text", dtNavVal, "Description");
            txt_valueVal.DataBindings.Add("Text", dtNavVal, "Value");
            txt_valueOpVal.DataBindings.Add("Text", dtNavVal, "Value Optimal");
            chk_danger.DataBindings.Add("checked", dtNavVal, "dangerous");

            Binding a = new Binding("checked", dtNavVal, "Version",true);
            a.Format += new ConvertEventHandler(chk_xp_ConvertEvent);
            a.Parse += new ConvertEventHandler(b_Parse);
            chk_xp.DataBindings.Add(a);

            Binding b = new Binding("checked", dtNavVal, "Version", true);
            b.Format += new ConvertEventHandler(chk_7_ConvertEvent);
            b.Parse += new ConvertEventHandler(b_Parse);
            chk_7.DataBindings.Add(b);
        }
        private void chk_xp_ConvertEvent(object sender, ConvertEventArgs e)
        {
            if (e.Value == null) return;
            e.Value = (e.Value.ToString().IndexOf("XP") > -1);
        }
        private void chk_7_ConvertEvent(object sender, ConvertEventArgs e)
        {
            if (e.Value == null) return;
            e.Value = (e.Value.ToString().IndexOf("7") > -1);
        }
        private void b_Parse(object sender, ConvertEventArgs e)
        {//Aun no entiendo que significa parse
            if (e.Value == null) return;
            string version = "";
            if (chk_xp.Checked) version += "XP,";
            if (chk_7.Checked) version += "7,";
            if (version != "") version = version.Substring(0, version.Length-1);
            e.Value = version;
            //e.Value = ((bool)e.Value == true) ? "7" : "";
        }
        #endregion

        #region Pruebas del registro de sistema
        /*private void test()
        {//Realiza pruebas de desempeño y generales
            bool ModuleReg = MyReg.exist(ROOT_KEY.HKEY_LOCAL_MACHINE, "SOFTWARE\\ModuleReg", "");
            if (ModuleReg == false) ModuleReg = MyReg.newKey(ROOT_KEY.HKEY_LOCAL_MACHINE, "SOFTWARE\\ModuleReg");

            object objIn = int.MaxValue; //int.MaxValue = 2147483647
            ModuleReg = MyReg.setValue(ROOT_KEY.HKEY_LOCAL_MACHINE, "SOFTWARE\\ModuleReg", "Test", ref objIn, VALUE_TYPE.REG_DWORD);
            Console.WriteLine("Prueba de velocidad en lectura de valores REG_DWORD 50k");
            myTestGetValue("SOFTWARE\\ModuleReg", "Test");

            objIn = "Cadena de texto";
            ModuleReg = MyReg.setValue(ROOT_KEY.HKEY_LOCAL_MACHINE, "SOFTWARE\\ModuleReg", "Test", ref objIn, VALUE_TYPE.REG_SZ);
            Console.WriteLine("Prueba de velocidad en lectura de valores REG_SZ 50k");
            myTestGetValue("SOFTWARE\\ModuleReg", "Test");

            Console.WriteLine("Prueba de velocidad en enumeracion de keys 10k");
            testEnumKeys();

            Console.WriteLine("Prueba de velocidad en enumeracion de valores 10k");
            testEnumValues();

            MyReg.allTest(false);
        }
        private void myTestGetValue(string SubKey, string Name)
        {
            double mT = 0;
            int i = 0, limit = 50000;
            object objOut = new object();
            bool ModuleReg = false;

            cClock.Start();
            do
            {
                ModuleReg = MyReg.getValue(ROOT_KEY.HKEY_LOCAL_MACHINE, 
                SubKey, Name, ref objOut);
                if (ModuleReg == false) Console.WriteLine("1 Error de lectura");
                i++;
            } while (i < limit);
            mT = cClock.Elapsed() / 1000;
            Console.WriteLine("API: " + mT.ToString("#.######"));

            i = 0;
            cClock.Start();
            do
            {
                Registry.GetValue("HKEY_LOCAL_MACHINE\\" + SubKey, Name, objOut);
                i++;
            } while (i < limit);
            mT = cClock.Elapsed() / 1000;
            Console.WriteLine(".Net: " + mT.ToString("#.######"));
        }  
        private void testEnumKeys()  
        {
            double mT = 0;
            bool ModuleReg = false;
            int i = 0, limit = 10000;
            System.Collections.ArrayList arrayL = new System.Collections.ArrayList();

            cClock.Start();  
            do 
            {    
                ModuleReg = MyReg.EnumKeys(ROOT_KEY.HKEY_LOCAL_MACHINE, "SOFTWARE", ref arrayL);
                if (arrayL.Count == 0) Console.WriteLine("1 Error de lectura");
                i++;  
            } while (i < limit);
            mT = cClock.Elapsed() / 1000;
            Console.WriteLine("API: " + mT.ToString("#.######"));
 
            i = 0;
            cClock.Start();
            RegistryKey rkey = Registry.LocalMachine;
            do
            {
                RegistryKey rkey2 = rkey.OpenSubKey("SOFTWARE");  
                rkey2.GetSubKeyNames();  
                rkey2.Close();  
                i++;  
            } while (i < limit);
            rkey.Close();
            mT = cClock.Elapsed() / 1000;
            Console.WriteLine(".Net: " + mT.ToString("#.######"));
        }  
        private void testEnumValues()
        {
            double mT = 0;
            bool ModuleReg = false;
            int i = 0, limit = 10000;
            System.Collections.ArrayList arrayL = new System.Collections.ArrayList();
 
            cClock.Start();  
            do 
            {
                ModuleReg = MyReg.EnumRegs(ROOT_KEY.HKEY_LOCAL_MACHINE, "SOFTWARE", ref arrayL);
                if (ModuleReg == false) Console.WriteLine("1 Error de lectura");
                i++;  
            } while (i < limit);
            mT = cClock.Elapsed() / 1000;
            Console.WriteLine("API: " + mT.ToString("#.######"));
 
            mT = 0;  
            i = 0;  
            // start timer  
            cClock.Start();
            RegistryKey rkey = Registry.LocalMachine;
            do 
            {
                RegistryKey rkey2 = rkey.OpenSubKey("SOFTWARE");  
                rkey2.GetValueNames();  
                rkey2.Close();  
                i++;  
            } while (i < limit);
            rkey.Close(); 
            mT = cClock.Elapsed() / 1000;
            Console.WriteLine(".Net: " + mT.ToString("#.######"));
        }*/
        #endregion


        #region Exploracion (tView_reg y dgv_values)
        private void tView_reg_AfterExpand(object sender, TreeViewEventArgs e)
        {//Enumero las sub sub llaves, antes de expandir.
            string[] fullPath = e.Node.FullPath.Split('\\');
            if (fullPath.Length < 2) return;
            int removeLen = fullPath[0].Length + fullPath[1].Length + 2;

            foreach (TreeNode thisNode in e.Node.Nodes)
            {
                TreeNode iNode = thisNode;
                string iPath = thisNode.FullPath.Substring(removeLen);
                System.Collections.ArrayList arrayL = new System.Collections.ArrayList();
                cargarSubNivel(ref iNode, MyReg.cad(fullPath[1]), iPath);
            }
        }
        private void cargarSubNivel(ref TreeNode RootKeyNode, ROOT_KEY RootKey, string SubKey)
        {
            System.Collections.ArrayList arrayL = new System.Collections.ArrayList();
            bool ModuleReg = MyReg.EnumKeys(RootKey, SubKey, ref arrayL);
            foreach (string item in arrayL) RootKeyNode.Nodes.Add(item, item);
        }

        private void tView_reg_AfterCollapse(object sender, TreeViewEventArgs e)
        {//Elimino las sub sub llaves, para ahorrar memoria
            string[] fullPath = e.Node.FullPath.Split('\\');
            if (fullPath.Length < 2) return;

            foreach (TreeNode thisNode in e.Node.Nodes) thisNode.Nodes.Clear();
        }

        private void tView_reg_AfterSelect(object sender, TreeViewEventArgs e)
        {//Al seleccionar un nodo/key
            string[] fullPath = e.Node.FullPath.Split('\\');
            if (fullPath.Length <= 1) return;

            //Escribo la ruta del nodo
            int removeLen = fullPath[0].Length + 1;
            txt_addr.Text = e.Node.FullPath.Substring(removeLen);

            if (fullPath.Length <= 2) return;
            //Enumero los valores
            removeLen += fullPath[1].Length + 1;
            ROOT_KEY root = MyReg.cad(fullPath[1]);
            string iPath = e.Node.FullPath.Substring(removeLen);
            System.Collections.ArrayList arrayL = new System.Collections.ArrayList();
            bool ModuleReg = MyReg.EnumRegs(root, iPath, ref arrayL);

            dtNavVal.Rows.Clear();
            object obj = new object();
            foreach (string item in arrayL)
            {
                if (item == "") continue;

                VALUE_TYPE type = VALUE_TYPE.REG_DWORD;
                MyReg.getValue(root, iPath, item, ref obj, ref type);


                DataTable dtDesc = new DataTable();
                String querySelect = "SELECT * FROM Valores " +
                " WHERE RootKey='" + fullPath[1] +
                "' AND SubKey='" + iPath +
                "' AND Name='" + item + "'";

                dbConexionAccess.Open();
                OleDbCommand sCommand = new OleDbCommand(querySelect, dbConexionAccess);
                OleDbDataAdapter sAdapter = new OleDbDataAdapter(sCommand);
                sAdapter.Fill(dtDesc);
                dbConexionAccess.Close();


                DataRow dRow = dtNavVal.NewRow();

                dRow["RootKey"] = fullPath[1];
                dRow["SubKey"] = iPath;
                dRow["Name"] = item;
                dRow["Type"] = type.ToString();
                dRow["Value"] = (obj == null) ? "" : obj.ToString();

                if (dtDesc.Rows.Count > 0)
                {
                    dRow["Value Optimal"] = dtDesc.Rows[0]["Value Optimal"].ToString();
                    dRow["Kind"] = dtDesc.Rows[0]["Kind"].ToString();
                    dRow["Description"] = dtDesc.Rows[0]["Description"].ToString();
                    dRow["Version"] = dtDesc.Rows[0]["Version"].ToString();
                    dRow["dangerous"] = dtDesc.Rows[0]["dangerous"].ToString();
                    dRow["registry"] = dtDesc.Rows[0]["registry"].ToString();
                }

                dtNavVal.Rows.Add(dRow);


                DataGridViewRow sRow = dgv_values.Rows[dgv_values.Rows.Count - 1];
                sRow.Cells[0].Value = (type == VALUE_TYPE.REG_SZ
                || type == VALUE_TYPE.REG_MULTI_SZ
                || type == VALUE_TYPE.REG_EXPAND_SZ) ? imgL.Images[2]:imgL.Images[3];

                if (dtDesc.Rows.Count > 0) 
                    sRow.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(0, 5, 5, 210);
            }

        }
        
        private void dgv_values_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //txt_description.Text = dgv_values["txt_Desc", e.RowIndex].Value.ToString();
        }
        #endregion

        #region Lista de comandos (dgv_values_CellDoubleClick)
        list list_form;
        private void listaDeComandosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            list_form = new list();
            list_form.Visible = true;
        }
        #endregion

        #region Opciones del menu
        private void acercaDeRegistryToolsToolStripMenuItem_Click(object sender, EventArgs e)
        {//Muestra mensaje con la informacion de la compilacion
            MessageBox.Show("Registry Tools Ver. 1.0\n" + "By Ascenso Empresarial",
            "Acerca de Registry Tools", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region Dirección
        private void btn_go_Click(object sender, EventArgs e)
        {//Busca una ruta
            string[] SubKeys = txt_addr.Text.Split('\\');
            if (SubKeys.Length < 2) return;

            bool found = true, createKeys = false;
            //Expande la ruta buscada ---------------------------------------
            tView_reg.SelectedNode = tView_reg.Nodes[0];
            tView_reg.SelectedNode.Expand();

            foreach (string SubKey1 in SubKeys)
                if (list.expandT(tView_reg, SubKey1) == false)
                {
                    found = false;
                    break;
                } //break end(0)
            //---------------------------------------------------------------
            if (found == false)
            {
                DialogResult result = MessageBox.Show(
                "¿Desea crearlas?", "Sub llaves no encontradas",
                MessageBoxButtons.YesNo);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    string SubKeyL = "";
                    for (int i = 1; i < SubKeys.Length; i++)
                        SubKeyL += SubKeys[i] + "\\";

                    SubKeyL = SubKeyL.Substring(0, SubKeyL.Length - 1);

                    createKeys = MyReg.newKey(
                    MyReg.cad(SubKeys[0]), SubKeyL);
                }
            }
            //Expande la ruta buscada ---------------------------------------
            if (createKeys)
            {
                tView_reg.CollapseAll();
                tView_reg.SelectedNode = tView_reg.Nodes[0];
                tView_reg.SelectedNode.Expand();

                foreach (string SubKey1 in SubKeys)
                    if (list.expandT(tView_reg, SubKey1) == false)
                    {
                        break;
                    } //break end(0)
            }
            //---------------------------------------------------------------

        }
        #endregion

        private void btn_save_Click(object sender, EventArgs e)
        {//Guarda la documentacion del valor
            //BUG001: No se pueden dejar parametros sin utilizar.
            //Por que entonces no se ejecutan las consultas.
            if (dgv_values.SelectedRows.Count < 0) return;

            int pos = dgv_values.SelectedRows[0].Index;
            System.Data.DataRow dtRow = dtNavVal.Rows[pos];
            dtRow.EndEdit();

            string queryInsert = "", queryUpdate = "";
            queryInsert = "INSERT INTO Valores (" +
            "Kind,RootKey,SubKey,Name,Type," +
            "Description,[Value],[Value Optimal],Version,dangerous)" +
            " VALUES (@Kind,@RootKey,@SubKey,@Name,@Type," +
            "@Description,@Value,@ValueOptimal,@Version,@dangerous); ";

            queryUpdate = "UPDATE Valores SET " +
            "Kind=@Kind,RootKey=@RootKey," +
            "SubKey=@SubKey,Name=@Name,Type=@Type," +
            "Description=@Description,[Value]=@Value," +
            "[Value Optimal]=@ValueOptimal," +
            "Version=@Version,dangerous=@dangerous " +
            " WHERE registry=@registry";

            int i = 0;
            long insertedId = 0; 
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                //cmd.Parameters.Add("@registry", dtRow["registry"]);
                cmd.Parameters.Add("@Kind", dtRow["Kind"]);
                cmd.Parameters.Add("@RootKey", dtRow["RootKey"]);
                cmd.Parameters.Add("@SubKey", dtRow["SubKey"]);
                cmd.Parameters.Add("@Name", dtRow["Name"]);
                cmd.Parameters.Add("@Type", dtRow["Type"]);
                cmd.Parameters.Add("@Description", dtRow["Description"]);
                cmd.Parameters.Add("@Value", dtRow["Value"]);
                cmd.Parameters.Add("@ValueOptimal", dtRow["Value Optimal"]);
                cmd.Parameters.Add("@Version", dtRow["Version"]);
                cmd.Parameters.Add("@dangerous", dtRow["dangerous"]);


                if (dtRow["registry"].ToString() == "")
                {
                    cmd.CommandText = queryInsert;
                }
                else
                {
                    cmd.Parameters.Add("@registry", dtRow["registry"]);
                    cmd.CommandText = queryUpdate;
                }

                cmd.Connection = dbConexionAccess;
                //cmd.Transaction = OleDbTransaction;
                //cmd.UpdatedRowSource = true;
                
                dbConexionAccess.Open();
                i = cmd.ExecuteNonQuery();
                dbConexionAccess.Close(); 
            }
            catch
            {
                dbConexionAccess.Close();
            }

            if (i > 0)
            {
                MessageBox.Show("Fila actualizada exitosamente!!",
                "Salvando documentacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (insertedId > 0)
                {
                    dtNavVal.Rows[pos]["registry"] = insertedId;
                    dgv_values.SelectedRows[0].DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(0, 5, 5, 210);
                }
            }
        }
        private void btn_saveVal_Click(object sender, EventArgs e)
        {//Aplica el nuevo valor a la configuración
            if (dgv_values.SelectedRows.Count < 1) return;
            DataGridViewRow dRowLoc = dgv_values.SelectedRows[0];

            string RootKey = dRowLoc.Cells["txt_KeyRoot"].Value.ToString();
            ROOT_KEY RootKeyR = MyReg.cad(RootKey);
            string SubKey = dRowLoc.Cells["txt_SubKey"].Value.ToString();
            string KeyName = dRowLoc.Cells["txt_Name"].Value.ToString();
            string Type = dRowLoc.Cells["txt_Type"].Value.ToString();
            VALUE_TYPE TypeR = MyReg.tip(Type);
            string currentVal = txt_valueVal.Text.Trim();

            bool ModuleReg = MyReg.exist(RootKeyR, SubKey, "");
            if (ModuleReg == false) ModuleReg = MyReg.newKey(RootKeyR, SubKey);

            object objIn = new object();
            objIn = currentVal;
            ModuleReg = MyReg.setValue(RootKeyR, SubKey, KeyName, ref objIn, TypeR);
            if (ModuleReg) dRowLoc.Cells["txt_Data"].Value = currentVal;
        }

    }  
}  





