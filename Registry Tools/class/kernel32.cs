using System;
using System.Reflection;
using System.Runtime.InteropServices; //"Marshal", "DllImport"

[StructLayout(LayoutKind.Sequential)]
public struct OSVERSIONINFO
{
    public int dwOSVersionInfoSize;
    public int dwMajorVersion;
    public int dwMinorVersion;
    public int dwBuildNumber;
    public int dwPlatformId;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
    public string szCSDVersion;
}

public static class Kernel
{
    //http://support.microsoft.com/kb/304721/es
    [DllImport("kernel32.Dll")]
    public static extern short GetVersionEx(ref OSVERSIONINFO o);

    static public string GetServicePack()
    {
        OSVERSIONINFO os = new OSVERSIONINFO();
        os.dwOSVersionInfoSize = Marshal.SizeOf(typeof(OSVERSIONINFO));
        GetVersionEx(ref os);
        if (os.szCSDVersion == "")
            return "NO hay ningún Service Pack instalado";
        else
            return os.szCSDVersion;
    }
}
