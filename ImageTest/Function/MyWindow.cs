using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;

namespace SNTImageConverter.Function
{
    class MyWindow
    {
        public static string[] getAllProcessName()
        {
            Process[] currentProcesss = Process.GetProcesses();
            //string[] myProcessNames = new string[currentProcesss.Count()];
            List<string> myProcessNames = new List<string>();
            
            foreach (var process in currentProcesss)
            {
                if (process.MainWindowHandle != IntPtr.Zero)
                {
                    myProcessNames.Add(process.ProcessName);
                }
            }
            return myProcessNames.ToArray();
        }
        public static IntPtr getWindowByProcessName(string name)
        {
           
            return Process.GetProcessesByName(name)[0].MainWindowHandle;
        }

        public static Image getImageByProcessName(string name)
        {
            try
            {
                if(string.IsNullOrEmpty(name))
                    return null;

                if (getWindowByProcessName(name) != IntPtr.Zero)
                {
                    return CppScreenCapture.CaptureWindow(getWindowByProcessName(name));
                }
                else return null;
                //string assemblyName = name + ".exe";
                //Assembly a = Assembly.LoadFrom(assemblyName);
                
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
