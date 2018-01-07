using System;
using System.Collections.Generic;
using System.Runtime.InteropServices; //DLLImport
using System.Text;
/**************************************************************************************
*  MyReg        2.5 Standalone Registry Control Class                                 *
*                                                                                     *
*  Created:     November 13, 2005 (vb6)                                               *
*  Updated:     October 18, 2008                                                      *
*  Purpose:     Comprehensive Registry Control Class                                  *
*  Methods:     (listed)                                                              *
*  Revision:    2.5.1                                                                 *
*  IDE:         C# 2008 SP1                                                           *
*  Author:      Miguel Angel Gonzalez Alonso (mgrc45@gmail.com)                       *
*                                                                                     *
***************************************************************************************/

public enum ROOT_KEY : uint
{//Predefinidos valores HKEY (hkey)
    HKEY_CLASSES_ROOT = 0x80000000,
    HKEY_CURRENT_USER = 0x80000001,
    HKEY_LOCAL_MACHINE = 0x80000002,
    HKEY_USERS = 0x80000003,
    HKEY_PERFORMANCE_DATA = 0x80000004,
    HKEY_CURRENT_CONFIG = 0x80000005,
    HKEY_DYN_DATA = 0x80000006
    //HKEY_CLASSES_ROOT es un duplicado de HKEY_LOCAL_MACHINE\Software\Classes
    //HKEY_CURRENT_USER es un duplicado de HKEY_USERS\[Usuario]
};

public enum VALUE_TYPE : int
{// Tipos de valores de registro
    REG_NONE = 0,
    REG_SZ = 1,
    REG_EXPAND_SZ = 2,
    REG_BINARY = 3,
    REG_DWORD = 4,
    REG_DWORD_LITTLE_ENDIAN = REG_DWORD,
    REG_DWORD_BIG_ENDIAN = 5,
    REG_LINK = 6,
    REG_MULTI_SZ = 7,
    REG_RESOURCE_LIST = 8,
    REG_FULL_RESOURCE_DESCRIPTOR = 9,
    REG_RESOURCE_REQUIREMENTS_LIST = 10,
    REG_QWORD = 11,
    REG_QWORD_LITTLE_ENDIAN = REG_QWORD
    //http://msdn.microsoft.com/en-us/library/windows/desktop/ms724884%28v=vs.85%29.aspx
};


public static class MyReg
{

    private enum KEY_ACCESS : int
    {// Privilegios de registro de acceso (samDesired)
        KEY_ALL_ACCESS = 0xF003F,
        KEY_CREATE_LINK = 0x0020,
        KEY_CREATE_SUB_KEY = 0x0004,
        KEY_ENUMERATE_SUB_KEYS = 0x0008,
        KEY_EXECUTE = 0x20019,
        KEY_NOTIFY = 0x0010,
        KEY_QUERY_VALUE = 0x0001,
        KEY_READ = 0x20019,
        KEY_SET_VALUE = 0x0002,
        KEY_WOW64_32KEY = 0x0200,
        KEY_WOW64_64KEY = 0x0100,
        KEY_WRITE = 0x20006,
        //http://msdn.microsoft.com/en-us/library/windows/desktop/ms724878%28v=vs.85%29.aspx
    };

    //Constantes requeridas para checar un error :)
    private const int ERROR_SUCCESS = 0x0; //Aplica al abrir la key
    private const int ERROR_FILE_NOT_FOUND = 0x2; //Key(valor) no encontrada
    private const int ERROR_NO_MORE_ITEMS = 259; //EnumKeys
    //http://msdn.microsoft.com/en-us/library/windows/desktop/ms681381%28v=vs.85%29.aspx

    // permissions  
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct SECURITY_ATTRIBUTES
    {
        public int nLength;
        public int lpSecurityDescriptor;
        public bool bInheritHandle;
    }


    //Para abrir una key de sistema (32 Bits - Unicode)
    [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegOpenKeyExW", SetLastError = true)]
    private static extern int RegOpenKeyEx(ROOT_KEY hKey, [MarshalAs(UnmanagedType.LPWStr)]string subKey,
    int options, KEY_ACCESS samDesired, ref UIntPtr phkResult);

    //Para cerrar la key en 16 y 32 bits (Cerramos para evitar que se corrompa)
    [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegCloseKey", SetLastError = true)]
    private static extern int RegCloseKey(UIntPtr hKey);

    //Para obtener valor y tipo. De un registro (32 Bits - Unicode)
    [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegQueryValueExW", SetLastError = true)]
    static extern int RegQueryValueEx(UIntPtr hKey, [MarshalAs(UnmanagedType.LPWStr)]string lpValueName,
    int lpReserved, out VALUE_TYPE lpType, [Optional] System.Text.StringBuilder lpData, ref uint lpcbData);
    [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegQueryValueExW", SetLastError = true)]
    static extern int RegQueryValueEx(UIntPtr hKey, [MarshalAs(UnmanagedType.LPWStr)]string lpValueName,
    int lpReserved, ref VALUE_TYPE lpType, [Optional] ref byte lpData, ref uint lpcbData);
    [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegQueryValueExW", SetLastError = true)]
    static extern int RegQueryValueEx(UIntPtr hKey, [MarshalAs(UnmanagedType.LPWStr)]string lpValueName,
    int lpReserved, ref VALUE_TYPE lpType, [Optional] ref int lpData, ref uint lpcbData);
    [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegQueryValueExW", SetLastError = true)]
    static extern int RegQueryValueEx(UIntPtr hKey, [MarshalAs(UnmanagedType.LPWStr)]string lpValueName,
    int lpReserved, ref VALUE_TYPE lpType, [Optional] ref long lpData, ref uint lpcbData);

    //Para enumerar el nombre de las keys y los valores/registros (32 Bits - Unicode)
    [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegEnumKeyExW", SetLastError = true)]
    private static extern int RegEnumKeyEx(UIntPtr hKey, uint index, StringBuilder lpName, ref uint lpcbName,
    IntPtr reserved, IntPtr lpClass, IntPtr lpcbClass, out long lpftLastWriteTime);
    [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegEnumValueW", SetLastError = true)]
    private static extern int RegEnumValue(UIntPtr hKey, uint dwIndex, StringBuilder lpValueName,
    ref uint lpcValueName, IntPtr lpReserved, IntPtr lpType, IntPtr lpData, IntPtr lpcbData);

    //Para crear valores/registros (32 Bits - Unicode)
    [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegSetValueExW", SetLastError = true)]
    private static extern int RegSetValueEx(UIntPtr hKey, [MarshalAs(UnmanagedType.LPWStr)]string lpValueName,
    int Reserved, VALUE_TYPE dwType, ref int lpData, int cbData);
    [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegSetValueExW", SetLastError = true)]
    private static extern int RegSetValueEx(UIntPtr hKey, [MarshalAs(UnmanagedType.LPWStr)]string lpValueName,
    int Reserved, VALUE_TYPE dwType, ref long lpData, int cbData);
    [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegSetValueExW", SetLastError = true)]
    private static extern int RegSetValueEx(UIntPtr hKey, [MarshalAs(UnmanagedType.LPWStr)]string lpValueName,
    int Reserved, VALUE_TYPE dwType, IntPtr lpData, int cbData);
    [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegSetValueExW", SetLastError = true)]
    private static extern int RegSetValueEx(UIntPtr hKey, [MarshalAs(UnmanagedType.LPWStr)]string lpValueName,
    int Reserved, VALUE_TYPE dwType, ref byte lpData, int cbData);

    //Para crear una key (16 y 32 Bits - Unicode)
    [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegCreateKeyW", SetLastError = true)]
    private static extern int RegCreateKey(ROOT_KEY hKey, [MarshalAs(UnmanagedType.LPWStr)]string subKey,
    ref UIntPtr phkResult);
    [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegCreateKeyExW", SetLastError = true)]
    private static extern int RegCreateKeyEx(ROOT_KEY hKey, [MarshalAs(UnmanagedType.LPWStr)]string subKey,
    int Reserved, [MarshalAs(UnmanagedType.LPWStr)]string lpClass, int dwOptions, KEY_ACCESS samDesired,
    ref SECURITY_ATTRIBUTES lpSecurityAttributes, ref UIntPtr phkResult, ref int lpdwDisposition);

    //Para eliminar una key (16 y 32 Bits - Unicode)
    //Windows 95: RegDeleteKey elimina una llave y todas sus decendientes
    //Windows NT: RegDeleteKey elimina una llave especifica y no debe tener sub_llaves
    [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegDeleteKeyW", SetLastError = true)]
    private static extern int RegDeleteKey(ROOT_KEY hKey, [MarshalAs(UnmanagedType.LPStr)]string subKey);
    [DllImport("advapi32.dll", CharSet = CharSet.Ansi, EntryPoint = "RegDeleteKeyA", SetLastError = true)]
    private static extern int RegDeleteKeyA(ROOT_KEY hKey, [MarshalAs(UnmanagedType.LPStr)]string subKey);
    //Para eliminar un registro (16 y 32 Bits - Unicode)
    [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegDeleteValueW", SetLastError = true)]
    private static extern int RegDeleteValue(UIntPtr hKey, [MarshalAs(UnmanagedType.LPWStr)]string lpValueName);
    //--------------------------------------------------------------------------------------------------------


    //Para obtener informacion de las keys 32 Bits
    /*  Private Declare Function RegQueryInfoKey Lib "advapi32.dll" Alias "RegQueryInfoKeyA" (ByVal hkey As Long, ByVal lpClass As String, lpcbClass As Long, ByVal lpReserved As Long, ByRef lpcSubKeys As Long, lpcbMaxSubKeyLen As Long, lpcbMaxClassLen As Long, ByRef lpcValues As Long, ByRef lpcbMaxValueNameLen As Long, lpcbMaxValueLen As Long, lpcbSecurityDescriptor As Long, lpftLastWriteTime As FILETIME) As Long
    [DllImport("advapi32.dll", EntryPoint = "RegQueryInfoKeyA", CharSet = CharSet.Ansi, SetLastError = true)]
    private static extern int RegQueryInfoKey(int hkey, string lpClass, int lpcbClass, int lpReserved,
    ref int lpcSubKeys, int lpcbMaxSubKeyLen, int lpcbMaxClassLen, ref int lpcValues, ref int lpcbMaxValueNameLen,
    int lpcbMaxValueLen, int lpcbSecurityDescriptor, FILETIME lpftLastWriteTime); // 32 bits*/

    public static ROOT_KEY cad(string input)
    {//Convierte una cadena de texto en un tipo root key
        switch (input) 
        {
            case "HKEY_CLASSES_ROOT":
            return ROOT_KEY.HKEY_CLASSES_ROOT;
            case "HKEY_CURRENT_USER":
            return ROOT_KEY.HKEY_CURRENT_USER;
            case "HKEY_LOCAL_MACHINE":
            return ROOT_KEY.HKEY_LOCAL_MACHINE;
            case "HKEY_USERS":
            return ROOT_KEY.HKEY_USERS;
            case "HKEY_PERFORMANCE_DATA":
            return ROOT_KEY.HKEY_PERFORMANCE_DATA;
            case "HKEY_CURRENT_CONFIG":
            return ROOT_KEY.HKEY_CURRENT_CONFIG;
            case "HKEY_DYN_DATA":
            return ROOT_KEY.HKEY_DYN_DATA;
            default:
            return 0;
        }
    }
    public static VALUE_TYPE tip(string input)
    {//Convierte una cadena de texto en un tipo de dato
        switch (input)
        {
            case "REG_NONE":
                return VALUE_TYPE.REG_NONE;
            case "REG_SZ":
                return VALUE_TYPE.REG_SZ;
            case "REG_EXPAND_SZ":
                return VALUE_TYPE.REG_EXPAND_SZ;
            case "REG_BINARY":
                return VALUE_TYPE.REG_BINARY;
            case "REG_DWORD":
                return VALUE_TYPE.REG_DWORD;
            case "REG_DWORD_LITTLE_ENDIAN":
                return VALUE_TYPE.REG_DWORD_LITTLE_ENDIAN;
            case "REG_DWORD_BIG_ENDIAN":
                return VALUE_TYPE.REG_DWORD_BIG_ENDIAN;
            case "REG_LINK":
                return VALUE_TYPE.REG_LINK;
            case "REG_MULTI_SZ":
                return VALUE_TYPE.REG_MULTI_SZ;
            case "REG_RESOURCE_LIST":
                return VALUE_TYPE.REG_RESOURCE_LIST;
            case "REG_FULL_RESOURCE_DESCRIPTOR":
                return VALUE_TYPE.REG_FULL_RESOURCE_DESCRIPTOR;
            case "REG_RESOURCE_REQUIREMENTS_LIST":
                return VALUE_TYPE.REG_RESOURCE_REQUIREMENTS_LIST;
            case "REG_QWORD":
                return VALUE_TYPE.REG_QWORD;
            case "REG_QWORD_LITTLE_ENDIAN":
                return VALUE_TYPE.REG_DWORD_LITTLE_ENDIAN;
            default:
                return 0;
        }
    }

    public static void allTest(bool onErrorStop)
    {//Realiza pruebas de todos los valores
        bool ModuleReg = exist(ROOT_KEY.HKEY_LOCAL_MACHINE, "SOFTWARE\\ModuleReg", "");
        if (ModuleReg) ModuleReg = delete(ROOT_KEY.HKEY_LOCAL_MACHINE, "SOFTWARE\\ModuleReg", "");

        ModuleReg = newKey(ROOT_KEY.HKEY_LOCAL_MACHINE, "SOFTWARE\\ModuleReg");
        if (ModuleReg) Console.WriteLine("Funciona para crear keys");


        object objOut = new object();
        object objIn = int.MaxValue; //int.MaxValue = 2147483647
        ModuleReg = setValue(ROOT_KEY.HKEY_LOCAL_MACHINE, "SOFTWARE\\ModuleReg", "Test", ref objIn, VALUE_TYPE.REG_DWORD);
        ModuleReg = getValue(ROOT_KEY.HKEY_LOCAL_MACHINE, "SOFTWARE\\ModuleReg", "Test", ref objOut);
        if (objIn.ToString() == objOut.ToString()) Console.WriteLine("Funciona para leer y escribir valores REG_DWORD");

        objIn = long.MaxValue; //long.MaxValue = 9223372036854775807
        ModuleReg = setValue(ROOT_KEY.HKEY_LOCAL_MACHINE, "SOFTWARE\\ModuleReg", "Test", ref objIn, VALUE_TYPE.REG_QWORD);
        ModuleReg = getValue(ROOT_KEY.HKEY_LOCAL_MACHINE, "SOFTWARE\\ModuleReg", "Test", ref objOut);
        if (objIn.ToString() == objOut.ToString()) Console.WriteLine("Funciona para leer y escribir valores REG_QWORD");

        objIn = "Cadena de texto";
        ModuleReg = setValue(ROOT_KEY.HKEY_LOCAL_MACHINE, "SOFTWARE\\ModuleReg", "Test", ref objIn, VALUE_TYPE.REG_SZ);
        ModuleReg = getValue(ROOT_KEY.HKEY_LOCAL_MACHINE, "SOFTWARE\\ModuleReg", "Test", ref objOut);
        if (objIn.ToString() == objOut.ToString()) Console.WriteLine("Funciona para leer y escribir valores REG_SZ");

        objIn = "Cadena de texto\nMulti linea";
        ModuleReg = setValue(ROOT_KEY.HKEY_LOCAL_MACHINE, "SOFTWARE\\ModuleReg", "Test", ref objIn, VALUE_TYPE.REG_MULTI_SZ);
        ModuleReg = getValue(ROOT_KEY.HKEY_LOCAL_MACHINE, "SOFTWARE\\ModuleReg", "Test", ref objOut);
        if (objIn.ToString() == objOut.ToString()) Console.WriteLine("Funciona para leer y escribir valores REG_MULTI_SZ");

        objIn = new byte[5];
        ModuleReg = setValue(ROOT_KEY.HKEY_LOCAL_MACHINE, "SOFTWARE\\ModuleReg", "Test", ref objIn, VALUE_TYPE.REG_BINARY);
        ModuleReg = getValue(ROOT_KEY.HKEY_LOCAL_MACHINE, "SOFTWARE\\ModuleReg", "Test", ref objOut);
        if ("00000" == (string)objOut) Console.WriteLine("Funciona para leer y escribir valores REG_BINARY");

        ModuleReg = setValue(ROOT_KEY.HKEY_LOCAL_MACHINE, "SOFTWARE\\ModuleReg", "Test", ref objIn, VALUE_TYPE.REG_LINK);
        ModuleReg = getValue(ROOT_KEY.HKEY_LOCAL_MACHINE, "SOFTWARE\\ModuleReg", "Test", ref objOut);
        if ("00000" == (string)objOut) Console.WriteLine("Funciona para leer y escribir valores REG_LINK");


        System.Collections.ArrayList arrayL = new System.Collections.ArrayList();
        ModuleReg = EnumKeys(ROOT_KEY.HKEY_LOCAL_MACHINE, "SOFTWARE\\Microsoft", ref arrayL);
        if (arrayL.Count > 0) Console.WriteLine("Funciona para leer keys");
        ModuleReg = EnumRegs(ROOT_KEY.HKEY_LOCAL_MACHINE, 
        "SOFTWARE\\Microsoft\\Internet Explorer", ref arrayL);
        if (arrayL.Count > 0) Console.WriteLine("Funciona para leer values");

        ModuleReg = delete(ROOT_KEY.HKEY_LOCAL_MACHINE, "SOFTWARE\\ModuleReg", "Test");
        if (ModuleReg) Console.WriteLine("Funciona para eliminar values");
        ModuleReg = delete(ROOT_KEY.HKEY_LOCAL_MACHINE, "SOFTWARE\\ModuleReg", "");
        if (ModuleReg) Console.WriteLine("Funciona para eliminar keys");
    }

    #region Leer: getValue,getType,exist
    /// <summary>
    /// Esta funcion evalua la existencia de una llave o registro.
    /// </summary>
    /// <param name="RootKey">
    /// Llave principal o raiz.
    /// Ejemplo: HKEY_CURRENT_USER, HKEY_LOCAL_MACHINE</param>
    /// <param name="SubKey">
    /// Ruta de las llaves.
    /// Ejemplo: "SYSTEM\\CurrentControlSet\\Control"</param>
    /// <param name="Name">
    /// Nombre del registro, es opcional cuando se evalua la llave.
    /// Ejemplo: "WaitToKillServiceTimeout"</param>
    /// <returns>bool</returns>
    public static bool exist(ROOT_KEY RootKey, string SubKey, string Name)
    {
        object Value = new object();
        return getValue(RootKey, SubKey, Name, ref Value);
    }

    /// <summary>
    /// Esta funcion obtiene el tipo de un registro.
    /// </summary>
    /// <param name="RootKey">
    /// Llave principal o raiz.
    /// Ejemplo: HKEY_CURRENT_USER, HKEY_LOCAL_MACHINE</param>
    /// <param name="SubKey">
    /// Ruta de las llaves.
    /// Ejemplo: "SYSTEM\\CurrentControlSet\\Control"</param>
    /// <param name="Name">
    /// Nombre del registro.
    /// Ejemplo: "WaitToKillServiceTimeout"</param>
    /// <param name="Type">
    /// Nombre del registro.
    /// Ejemplo: REG_DWORD, REG_SZ</param>
    /// <returns>bool</returns>
    public static bool getType(ROOT_KEY RootKey, string SubKey, string Name, VALUE_TYPE Type)
    {
        object Value = new object();
        return getValue(RootKey, SubKey, Name, ref Value, ref Type);
    }

    /// <summary>
    /// Esta funcion obtiene el valor de un registro.
    /// </summary>
    /// <param name="RootKey">
    /// Llave principal o raiz.
    /// Ejemplo: HKEY_CURRENT_USER, HKEY_LOCAL_MACHINE</param>
    /// <param name="SubKey">
    /// Ruta de las llaves.
    /// Ejemplo: "SYSTEM\\CurrentControlSet\\Control"</param>
    /// <param name="Name">
    /// Nombre del registro.
    /// Ejemplo: "WaitToKillServiceTimeout"</param>
    /// <param name="Value">
    /// Valor del registro. Deuvuelve el contenido del registro.</param>
    /// <returns>bool</returns>
    public static bool getValue(ROOT_KEY RootKey, string SubKey, string Name, ref object Value)
    {
        VALUE_TYPE Tipo = VALUE_TYPE.REG_DWORD;
        return getValue(RootKey, SubKey, Name, ref Value, ref Tipo);
    }

    /// <summary>
    /// Esta funcion obtiene el valor y tipo de un registro.
    /// </summary>
    /// <param name="RootKey">
    /// Llave principal o raiz.
    /// Ejemplo: HKEY_CURRENT_USER, HKEY_LOCAL_MACHINE</param>
    /// <param name="SubKey">
    /// Ruta de las llaves.
    /// Ejemplo: "SYSTEM\\CurrentControlSet\\Control"</param>
    /// <param name="Name">
    /// Nombre del registro.
    /// Ejemplo: "WaitToKillServiceTimeout"</param>
    /// <param name="Value">
    /// Valor del registro. Deuvuelve el contenido del registro.</param>
    /// <param name="Type">
    /// Nombre del registro.
    /// Ejemplo: REG_DWORD, REG_SZ</param>
    /// <returns>bool</returns>
    public static bool getValue(ROOT_KEY RootKey, string SubKey,
    string Name, ref object Value, ref VALUE_TYPE Tipo)
    {
        /*__________________________________________________________________
         * Descripcion: Esta funcion obtiene el valor y tipo de un registro.
         * Parameteros:
         *       RootKey - HKEY_CURRENT_USER, HKEY_LOCAL_MACHINE, etc..
         *       SubKey - La direccion ó ruta de las sub llaves.
         *       Name - El nombre del registro.
         *       Value - Valor del registro.
         *       Tipo - Tipo de registro.
         * Syntaxis:
         *       object obj = new object();
         *       VALUE_TYPE tipo = VALUE_TYPE.REG_DWORD;
         *       bool result = MyReg.getValue(ROOT_KEY.HKEY_LOCAL_MACHINE, 
         *       "SOFTWARE\\Microsoft\\Internet Explorer", "Build", 
         *       ref obj, ref tipo);
         * Regresa:
         *       bool - Determina si la funcion termino sin errores.
         *__________________________________________________________________
         */
        Value = null;
        UIntPtr hkeyResult = UIntPtr.Zero;

        int returnValue = RegOpenKeyEx(RootKey, SubKey,
        0, KEY_ACCESS.KEY_READ, ref hkeyResult); //32 Bits
        //Si todo sale bien entonces devuelve 'ERROR_SUCCESS'
        if (returnValue != ERROR_SUCCESS)
        {//En caso de que no exista el key
            if (hkeyResult != UIntPtr.Zero) RegCloseKey(hkeyResult);
            return false;
        }

        if (Name.Trim() == "") return true;

        //Obtengo el valor del registro
        int pvDataDWORD = 0; uint pvSize = 4;
        Tipo = VALUE_TYPE.REG_DWORD;

        returnValue = RegQueryValueEx(hkeyResult,
        Name, 0, ref Tipo, ref pvDataDWORD, ref pvSize);
        if (returnValue == ERROR_FILE_NOT_FOUND)
        {//No existe el registro
            if (hkeyResult != UIntPtr.Zero) RegCloseKey(hkeyResult);
            return false;
        }

        if (Tipo == VALUE_TYPE.REG_DWORD
        || Tipo == VALUE_TYPE.REG_DWORD_LITTLE_ENDIAN
        || Tipo == VALUE_TYPE.REG_DWORD_BIG_ENDIAN)
        {//Si fuese correcto el valor buscado
            Value = pvDataDWORD;
        }

        //Si el valor es diferente al buscado
        if (Tipo == VALUE_TYPE.REG_QWORD
        || Tipo == VALUE_TYPE.REG_QWORD_LITTLE_ENDIAN)
        {
            long pvDataQDWORD = 0; //Tipo = 8
            returnValue = RegQueryValueEx(hkeyResult,
            Name, 0, ref Tipo, ref pvDataQDWORD, ref pvSize);
            Value = pvDataQDWORD;
        }

        if (Tipo == VALUE_TYPE.REG_SZ
        || Tipo == VALUE_TYPE.REG_EXPAND_SZ
        || Tipo == VALUE_TYPE.REG_MULTI_SZ)
        {
            System.Text.StringBuilder pvData = new System.Text.StringBuilder(0);
            pvData = new System.Text.StringBuilder((int)(pvSize / 2));
            RegQueryValueEx(hkeyResult, Name, 0, out Tipo, pvData, ref pvSize);
            Value = pvData;
        }

        if (Tipo == VALUE_TYPE.REG_BINARY)
        {
            byte[] bBuffer = new byte[1024];
            RegQueryValueEx(hkeyResult, Name, 0, ref Tipo, ref bBuffer[0], ref pvSize);
            string sRet = String.Empty;
            for (int i = 0; i < (pvSize); i++) sRet += bBuffer[i].ToString();
            //byte[] bRet = new byte[pvSize];
            //for (int i = 0; i < (pvSize); i++) bRet[i] = (byte)bBuffer[i];
            Value = sRet;
        }

        if (Tipo == VALUE_TYPE.REG_LINK
        || Tipo == VALUE_TYPE.REG_FULL_RESOURCE_DESCRIPTOR
        || Tipo == VALUE_TYPE.REG_RESOURCE_LIST
        || Tipo == VALUE_TYPE.REG_RESOURCE_REQUIREMENTS_LIST)
        {
            byte[] bBuffer = new byte[1024];
            RegQueryValueEx(hkeyResult, Name, 0, ref Tipo, ref bBuffer[0], ref pvSize);
            string sRet = String.Empty;
            for (int i = 0; i < (pvSize); i++) sRet += bBuffer[i].ToString();
            //byte[] bRet = new byte[pvSize];
            //for (int i = 0; i < (pvSize); i++) bRet[i] = (byte)bBuffer[i];
            Value = sRet;
        }

        if (hkeyResult != UIntPtr.Zero) RegCloseKey(hkeyResult);
        return (Value != null);
    }
    #endregion

    #region Leer: Enumerar: EnumRegs,EnumKeys
    /// <summary>
    /// Enumera y obtiene el nombre de los registros.
    /// </summary>
    /// <param name="RootKey">
    /// Llave principal o raiz.
    /// Ejemplo: HKEY_CURRENT_USER, HKEY_LOCAL_MACHINE</param>
    /// <param name="SubKey">
    /// Ruta de las llaves.
    /// Ejemplo: "SYSTEM\\CurrentControlSet\\Control"</param>
    /// <param name="RegList">
    /// Obtiene una lista de registros.</param>
    /// <returns>bool</returns>
    public static bool EnumRegs(ROOT_KEY RootKey,
    string SubKey, ref System.Collections.ArrayList RegList)
    {
        /*__________________________________________________________________
         * Descripcion: Funcion para consultar el numero valores que existen
         * Parameteros:
         *       Root - HKEY_CURRENT_USER, HKEY_LOCAL_MACHINE, etc..
         *       Key - La direccion ó ruta de las sub llaves.
         *       RegList - Devuelve una lista de los valores existentes.
         * Syntaxis:
         *       ArrayList arrayL = new ArrayList();
         *       bool result = MyReg.EnumRegs(ROOT_KEY.HKEY_LOCAL_MACHINE, 
         *       "SOFTWARE\\Microsoft\\Internet Explorer", ref arrayL);
         * Regresa:
         *       bool - Determina si la funcion termino sin errores.
         *__________________________________________________________________
         */
        UIntPtr hkeyResult = UIntPtr.Zero;

        int returnValue = RegOpenKeyEx(RootKey, SubKey, 0,
        KEY_ACCESS.KEY_QUERY_VALUE, ref hkeyResult); //32 Bits
        //Si todo sale bien entonces devuelve 'ERROR_SUCCESS'
        if (returnValue != ERROR_SUCCESS)
        {//En caso de que no exista el key
            if (hkeyResult != UIntPtr.Zero) RegCloseKey(hkeyResult);
            return false;
        }

        uint index = 0;
        uint regLen = 255;
        StringBuilder regName = new StringBuilder(0);
        RegList = new System.Collections.ArrayList();
        do
        {
            regLen = 255;
            regName = new StringBuilder(255);
            returnValue = RegEnumValue(hkeyResult, index, regName,
            ref regLen, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);
            if (returnValue == 0) RegList.Add(regName.ToString());
            index += 1;
        }
        while (returnValue == 0);

        if (hkeyResult != UIntPtr.Zero) RegCloseKey(hkeyResult);
        return (returnValue == ERROR_NO_MORE_ITEMS);
    }

    /// <summary>
    /// Enumera y obtiene el nombre de las sub llaves.
    /// </summary>
    /// <param name="RootKey">
    /// Llave principal o raiz.
    /// Ejemplo: HKEY_CURRENT_USER, HKEY_LOCAL_MACHINE</param>
    /// <param name="SubKey">
    /// Ruta de las llaves.
    /// Ejemplo: "SYSTEM\\CurrentControlSet\\Control"</param>
    /// <param name="RegList">
    /// Obtiene una lista de llaves.</param>
    /// <returns>bool</returns>
    public static bool EnumKeys(ROOT_KEY RootKey,
    string SubKey, ref System.Collections.ArrayList keyList)
    {
        /*_________________________________________________________________
         * Descripcion: Funcion para consultar el numero llaves que existen
         * Parameteros:
         *       Root - HKEY_CURRENT_USER, HKEY_LOCAL_MACHINE, etc..
         *       Key - La direccion ó ruta de las sub llaves.
         *       keyList - Devuelve una lista de las llaves existentes.
         * Syntaxis:
         *       ArrayList arrayL = new ArrayList();
         *       bool result = MyReg.EnumKeys(ROOT_KEY.HKEY_LOCAL_MACHINE, 
         *       "SOFTWARE\\Microsoft", ref arrayL);
         * Regresa:
         *       bool - Determina si la funcion termino sin errores.
         *_________________________________________________________________
         */
        UIntPtr hkeyResult = UIntPtr.Zero;

        int returnValue = RegOpenKeyEx(RootKey, SubKey, 0,
        KEY_ACCESS.KEY_ENUMERATE_SUB_KEYS, ref hkeyResult); //32 Bits
        //Si todo sale bien entonces devuelve 'ERROR_SUCCESS'
        if (returnValue != ERROR_SUCCESS)
        {//En caso de que no exista el key
            if (hkeyResult != UIntPtr.Zero) RegCloseKey(hkeyResult);
            return false;
        }

        uint index = 0;
        uint keyLen = 255;
        long lastWrite = 0;
        StringBuilder keyName = new StringBuilder(0);
        keyList = new System.Collections.ArrayList();
        do
        {
            keyLen = 255;
            keyName = new StringBuilder(255);
            returnValue = RegEnumKeyEx(hkeyResult, index, keyName,
            ref keyLen, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, out lastWrite);
            if (returnValue == 0) keyList.Add(keyName.ToString());
            index += 1;
        } 
        while (returnValue == 0);

        if (hkeyResult != UIntPtr.Zero) RegCloseKey(hkeyResult);
        return (returnValue == ERROR_NO_MORE_ITEMS);
    }
    #endregion

    #region Escribir: setValue,newKey,newKeyEx
    /// <summary>
    /// Esta funcion establece el valor y tipo de un registro.
    /// </summary>
    /// <param name="RootKey">
    /// Llave principal o raiz.
    /// Ejemplo: HKEY_CURRENT_USER, HKEY_LOCAL_MACHINE</param>
    /// <param name="SubKey">
    /// Ruta de las llaves.
    /// Ejemplo: "SYSTEM\\CurrentControlSet\\Control"</param>
    /// <param name="Name">
    /// Nombre del registro.
    /// Ejemplo: "WaitToKillServiceTimeout"</param>
    /// <param name="Value">
    /// Valor del registro. Deuvuelve el contenido del registro.</param>
    /// <param name="Type">
    /// Nombre del registro.
    /// Ejemplo: REG_DWORD, REG_SZ</param>
    /// <returns>bool</returns>
    public static bool setValue(ROOT_KEY RootKey, string SubKey,
    string Name, ref object Value, VALUE_TYPE Type)
    {
        /*__________________________________________________________________
         * Descripcion: Esta funcion define el valor y tipo de un registro.
         * Parameteros:
         *       RootKey - HKEY_CURRENT_USER, HKEY_LOCAL_MACHINE, etc..
         *       SubKey - La direccion ó ruta de las sub llaves.
         *       Name - El nombre del registro.
         *       Value - Valor del registro.
         *       Type - Tipo de registro.
         * Syntaxis:
         *       object obj = "87600";
         *       bool result = MyReg.setValue(ROOT_KEY.HKEY_LOCAL_MACHINE, 
         *       "SOFTWARE\\Microsoft\\Internet Explorer", "Build", 
         *       ref obj, VALUE_TYPE.REG_SZ);
         * Regresa:
         *       bool - Determina si la funcion termino sin errores.
         *__________________________________________________________________
         */
        UIntPtr hkeyResult = UIntPtr.Zero;

        int returnValue = RegOpenKeyEx(RootKey, SubKey,
        0, KEY_ACCESS.KEY_ALL_ACCESS, ref hkeyResult); //32 Bits
        //Si todo sale bien entonces devuelve 'ERROR_SUCCESS'
        if (returnValue != ERROR_SUCCESS)
        {//En caso de que no exista el key
            if (hkeyResult != UIntPtr.Zero) RegCloseKey(hkeyResult);
            return false;
        }
        //Debemos tener el nombre
        if (Name.Trim() == "") return false;

        //Defino el valor del registro
        if (Type == VALUE_TYPE.REG_DWORD
        || Type == VALUE_TYPE.REG_DWORD_LITTLE_ENDIAN
        || Type == VALUE_TYPE.REG_DWORD_BIG_ENDIAN)
        {
            int pvDataDWORD = Convert.ToInt32(Value);
            returnValue = RegSetValueEx(hkeyResult, Name, 0, Type, ref pvDataDWORD, 4);
        }

        if (Type == VALUE_TYPE.REG_QWORD
        || Type == VALUE_TYPE.REG_QWORD_LITTLE_ENDIAN)
        {
            //long pvDataQWORD = (long)Value;
            long pvDataQWORD = Convert.ToInt64(Value);
            returnValue = RegSetValueEx(hkeyResult, Name, 0, Type, ref pvDataQWORD, 8);
        }

        if (Type == VALUE_TYPE.REG_SZ
        || Type == VALUE_TYPE.REG_EXPAND_SZ
        || Type == VALUE_TYPE.REG_MULTI_SZ)
        {
            string Data = (string)Value;
            IntPtr pStr = Marshal.StringToHGlobalAuto(Data);
            int pvSize = (Data.Length + 1) * Marshal.SystemDefaultCharSize;
            returnValue = RegSetValueEx(hkeyResult, Name, 0, Type, pStr, pvSize);
        }

        if (Type == VALUE_TYPE.REG_BINARY)
        {
            byte[] bBuffer = (byte[])Value;
            int pvSize = (bBuffer.GetUpperBound(0) + 1);
            returnValue = RegSetValueEx(hkeyResult, Name, 0, Type, ref bBuffer[0], pvSize);
        }

        if (Type == VALUE_TYPE.REG_LINK
        || Type == VALUE_TYPE.REG_FULL_RESOURCE_DESCRIPTOR
        || Type == VALUE_TYPE.REG_RESOURCE_LIST
        || Type == VALUE_TYPE.REG_RESOURCE_REQUIREMENTS_LIST)
        {
            byte[] bBuffer = (byte[])Value;
            int pvSize = (bBuffer.GetUpperBound(0) + 1);
            returnValue = RegSetValueEx(hkeyResult, Name, 0, Type, ref bBuffer[0], pvSize);
        }

        if (hkeyResult != UIntPtr.Zero) RegCloseKey(hkeyResult);
        return (returnValue == 0);
    }

    /// <summary>
    /// Crea una clave nueva.
    /// </summary>
    /// <param name="RootKey">
    /// Llave principal o raiz.
    /// Ejemplo: HKEY_CURRENT_USER, HKEY_LOCAL_MACHINE</param>
    /// <param name="SubKey">
    /// Ruta y nombre de la llave nueva.
    /// Ejemplo: "SYSTEM\\CurrentControlSet\\Control"</param>
    /// <returns>bool</returns>
    public static bool newKey(ROOT_KEY RootKey, string SubKey)
    {
        UIntPtr hkeyResult = UIntPtr.Zero;
        int returnValue = RegCreateKey(RootKey, SubKey, ref hkeyResult);

        if (hkeyResult != UIntPtr.Zero) RegCloseKey(hkeyResult);
        return (returnValue == 0);
    }

    /// <summary>
    /// Crea una clave nueva.
    /// </summary>
    /// <param name="RootKey">
    /// Llave principal o raiz.
    /// Ejemplo: HKEY_CURRENT_USER, HKEY_LOCAL_MACHINE</param>
    /// <param name="SubKey">
    /// Ruta y nombre de la llave nueva.
    /// Ejemplo: "SYSTEM\\CurrentControlSet\\Control"</param>
    /// <returns>bool</returns>
    public static bool newKeyEx(ROOT_KEY RootKey, string SubKey)
    {
        UIntPtr hkeyResult = UIntPtr.Zero;
        int lDeposit = 0;
        SECURITY_ATTRIBUTES tSecAttrib = new SECURITY_ATTRIBUTES();

        tSecAttrib.nLength = Marshal.SizeOf(tSecAttrib);
        tSecAttrib.lpSecurityDescriptor = 0;
        tSecAttrib.bInheritHandle = true;

        int returnValue = RegCreateKeyEx(RootKey, SubKey, 0, "", 0,
        KEY_ACCESS.KEY_WRITE, ref tSecAttrib, ref hkeyResult, ref lDeposit);

        returnValue = RegCreateKey(RootKey, SubKey, ref hkeyResult);

        if (hkeyResult != UIntPtr.Zero) RegCloseKey(hkeyResult);
        return (returnValue == 0);
    }
    #endregion

    #region Escribir: DeleteKey,DeleteVal
    /// <summary>
    /// Elimina una llave ó valor.
    /// </summary>
    /// <param name="RootKey">
    /// Llave principal o raiz.
    /// Ejemplo: HKEY_CURRENT_USER, HKEY_LOCAL_MACHINE</param>
    /// <param name="SubKey">
    /// Ruta de las llaves.
    /// Ejemplo: "SYSTEM\\CurrentControlSet\\Control"</param>
    /// <param name="Name">
    /// Nombre del registro, es opcional cuando se evalua la llave.
    /// Ejemplo: "WaitToKillServiceTimeout"</param>
    /// <returns>bool</returns>
    public static bool delete(ROOT_KEY RootKey, string SubKey, string Name)
    {
        if (Name.Trim() == "")
            return DeleteKey(RootKey, SubKey);
        else return DeleteValue(RootKey, SubKey, Name);
    }

    private static bool DeleteKey(ROOT_KEY RootKey, string SubKey)
    {//Elimina una llave
        return (RegDeleteKeyA(RootKey, SubKey) == 0);
    }
    private static bool DeleteValue(ROOT_KEY RootKey, string SubKey, string Name)
    {//Elimina un registro
        UIntPtr hkeyResult = UIntPtr.Zero;
        
        int returnValue = RegOpenKeyEx(RootKey, SubKey,
        0, KEY_ACCESS.KEY_WRITE, ref hkeyResult);
        //Si todo sale bien entonces devuelve 'ERROR_SUCCESS'
        if (returnValue != ERROR_SUCCESS)
        {//En caso de que no exista el key
            if (hkeyResult != UIntPtr.Zero) RegCloseKey(hkeyResult);
            return false;
        }

        returnValue = RegDeleteValue(hkeyResult, Name);

        if (hkeyResult != UIntPtr.Zero) RegCloseKey(hkeyResult);
        return (returnValue == 0);
    }
    #endregion

}

