using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TestFixScript
{
    internal class DLL
    {
        const string dllFile = "i3BaseDx_Cli.dll";

        [DllImport(dllFile, EntryPoint = "?CheckProtectionCode@i3ResourceFile@@SA_NPBD0H@Z", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CheckProtectionCode(string SRC, string md5_context, int INT);       
        
        [DllImport(dllFile, EntryPoint = "?SetProtectionCode@i3ResourceFile@@SA_NPBD0H@Z", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetProtectionCode(string SRC, string md5_context, int INT);
    }
}
