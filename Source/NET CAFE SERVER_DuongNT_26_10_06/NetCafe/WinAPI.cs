using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
namespace NetCafe
{
    class WinAPI
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        public const int WS_DLGFRAME = 0x400000;
        public const int WS_CAPTION = 0xC00000;
        public const int GWL_STYLE = -16;
        public const int WS_BORDER = 0x800000; 
        public const int GWL_EXSTYLE = -20;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, 
                 int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImportAttribute("user32.dll")]
        public static extern bool SetWindowLong(IntPtr hWnd, int nIndex, int nNewLong);
        [DllImportAttribute("user32.dll")]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        // loai bo thanh caption
        public static void KillWinCaption(IntPtr handle)
        {
            int dwStyle = GetWindowLong(handle, GWL_STYLE);
            if ((dwStyle & WS_CAPTION) == WS_CAPTION)
            {
                dwStyle = (dwStyle - WS_CAPTION) | WS_DLGFRAME | 0x100;
                SetWindowLong(handle, GWL_STYLE, dwStyle);
                dwStyle = GetWindowLong(handle, GWL_EXSTYLE);
                dwStyle = dwStyle | 0x100 | 1 | 0x200;
                SetWindowLong(handle, GWL_EXSTYLE, dwStyle);
            }
        }
    }
}
