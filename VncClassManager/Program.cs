using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace VncClassManager
{
    internal static class Program
    {
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;

        private static readonly LowLevelKeyboardProc _proc;
        private static IntPtr _hookID;
        private static readonly Login login;

        static Program()
        {
            ApplicationConfiguration.Initialize();
            login = new Login();
            _proc = HookCallback;
            _hookID = IntPtr.Zero;
        }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {

            _hookID = SetHook(_proc);
            Application.Run(login);
            UnhookWindowsHookEx(_hookID);
        }

        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using Process curProcess = Process.GetCurrentProcess();
            using ProcessModule? curModule = curProcess.MainModule;
            if (curModule?.ModuleName is not null)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
            return IntPtr.Zero;
        }

        private static IntPtr HookCallback(
            int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (login.vncView.IsViewFull)
            {
                if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
                {
                    int vkCode = Marshal.ReadInt32(lParam);
                    //Console.WriteLine((Keys)vkCode);
                    login.vncView.KeysCaptured((Keys)vkCode);
                }
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        private delegate IntPtr LowLevelKeyboardProc(
            int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
            LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
            IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
    }
}