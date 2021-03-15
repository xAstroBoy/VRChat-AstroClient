using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Colorful
{
    internal static class OperationSystemDetector
    {
        private static readonly bool _isAnniversaryUpdate;

        static OperationSystemDetector()
        {
            // OS Detection for all CLR implementations (.NET Framework,Mono,.NET Core)
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                // windows
                int version = NativeMethods.GetVersion();
                int major = version & 0xFF;
                int minor = (version >> 8) & 0xFF;
                if ((major < 6) || (minor < 2))
                {
                    _isAnniversaryUpdate = false;
                }
                else
                {
                    // Windows 6.2 is Windows 8 or later - first which supports Windows RT
                    _isAnniversaryUpdate = DetectAnniversaryUpdate();
                }

            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                // linux
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                // Mac OS
            }

        }

        public static bool IsAnniversaryUpdate
        {
            get { return _isAnniversaryUpdate; }
        }

        /// <summary>
        /// ALL version info functions are DEPRECATED since Windows 10
        /// https://msdn.microsoft.com/en-ca/library/windows/desktop/dn481241(v=vs.85).aspx
        /// this code modified version of code:
        /// http://answers.unity3d.com/questions/1249727/detect-if-windows-10-anniversary-version-number.html
        /// </summary>
        /// <returns></returns>
        private static bool DetectAnniversaryUpdate()
        {
            const string kAppExtensionClassName = "Windows.ApplicationModel.AppExtensions.AppExtensionCatalog";
            var classNameHString = IntPtr.Zero;
            bool ok = false;
            try
            {
                if (NativeMethods.WindowsCreateString(kAppExtensionClassName, kAppExtensionClassName.Length, out classNameHString) == 0)
                {
                    IntPtr appExtensionCatalogStatics;
                    var IID_IAppExtensionCatalogStatics = new Guid(1010198154, 24344, 20235, 156, 229, 202, 182, 29, 25, 111, 17);

                    if (NativeMethods.RoGetActivationFactory(classNameHString, ref IID_IAppExtensionCatalogStatics, out appExtensionCatalogStatics) == 0)
                    {
                        if (appExtensionCatalogStatics != IntPtr.Zero)
                        {
                            Marshal.Release(appExtensionCatalogStatics);
                            ok = true;
                        }
                    }
                }
            }
            finally
            {
                if (IntPtr.Zero != classNameHString)
                {
                    NativeMethods.WindowsDeleteString(classNameHString);
                }
            }
            return ok;
        }



    }
}