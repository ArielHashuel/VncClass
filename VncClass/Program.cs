using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VncClass
{
    internal static class Program
    {
        private static ClientForm? CForm;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            ApplicationConfiguration.Initialize();

            SetWinEventHook(EVENT_SYSTEM_DESKTOPSWITCH, EVENT_SYSTEM_DESKTOPSWITCH,
                IntPtr.Zero, new WinEventDelegate(WinEventProc),
                0, 0, WINEVENT_OUTOFCONTEXT | WINEVENT_SKIPOWNPROCESS);

            CForm = new ClientForm();
            Application.Run(CForm);
        }

        #region Ctrl+Alt+Del Handler
        private const uint WINEVENT_OUTOFCONTEXT = 0;
        private const uint WINEVENT_SKIPOWNPROCESS = 0x0002;
        private const uint EVENT_SYSTEM_DESKTOPSWITCH = 0x0020;

        private delegate void WinEventDelegate(IntPtr hWinEventHook, uint eventType, IntPtr hwnd,
            int idObject, int idChild, uint dwEventThread, uint dwmsEventTime);

        [DllImport("user32.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        private static extern IntPtr SetWinEventHook(uint eventMin, uint eventMax, IntPtr
            hmodWinEventProc, WinEventDelegate lpfnWinEventProc, uint idProcess,
            uint idThread, uint dwFlags);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern bool UnhookWinEvent(IntPtr hWinEventHook);

        private static void WinEventProc(IntPtr hWinEventHook, uint eventType,
            IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
        {
            if (CForm?.Vnc is not null)
            {
                if (CForm.Vnc.RecieveTask.IsCompleted)
                {
                    CForm.Vnc.RecieveTask = Task.Run(async () => await CForm.Vnc.ReceiveMessage());
                }
            }
        }




        #endregion

    }
}