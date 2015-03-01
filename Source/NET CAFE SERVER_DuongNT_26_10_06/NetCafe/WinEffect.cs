using System;
using System.Collections.Generic;
using System.Text;

using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;

namespace NetCafe
{
    class WinEffect
    {
        public static bool AnimateWindowC(Control pControl, int dwTimeInMilliSeconds, AnimateWindowStyle dwFlags)
        {
            bool blnNewVisible = !pControl.Visible;
            bool r = AnimateWindow(pControl, dwTimeInMilliSeconds, dwFlags);
            pControl.Visible = blnNewVisible;
            //Wenn das Control neu sichtbar ist einen Refresh durchführen
            if (pControl.Visible)
            {
                pControl.Refresh();
            }
            return r;
        }
        #region AnimateWindow
        /// <summary>
        /// Animiert ein Control / Form
        /// </summary>  
        /// <param name="pControl">Das zu animierende Control / Form</param>
        /// <param name="dwTimeInMilliSeconds">Zeit in Milliseconds die die Animation dauern soll (Default = 200)</param>
        /// <param name="dwFlags">Die Flags wie animiert werden soll</param>
        /// <returns></returns>
        public static bool AnimateWindow(Control pControl, int dwTimeInMilliSeconds, AnimateWindowStyle dwFlags)
        {
            //Visible - Flag selber setzen
            int flags = (int)dwFlags;
            flags = pControl.Visible ? flags | 0x00010000 : flags | 0x00020000;
            //Animation
            bool ret = AnimateWindow(pControl.Handle, dwTimeInMilliSeconds, (int)flags) != 0;
            //Visible des Controls setzen (wird durch die Animation nicht gesetzt)
            
            //Return-Value 
            return ret;
        }

        /// <summary>
        /// Die Api-Function
        /// </summary>
        /// <param name="hwnd">Handle des zu animierenden Controls / Fensters</param>
        /// <param name="dwTime">Zeit in Milliseconds die die Animation dauern soll (Default = 200)</param>
        /// <param name="dwFlags">Die Flags wie animiert werden soll</param>
        /// <returns></returns>
        [DllImport("User32.dll")]
        private static extern int AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);
        #endregion

    }
    /// <summary>
    /// Die AnimateWindowStyles (ohne Hide und Activate)
    /// </summary>
    [Flags]
    public enum AnimateWindowStyle
    {
        AW_HOR_POSITIVE = 0x00000001,
        AW_HOR_NEGATIVE = 0x00000002,
        AW_VER_POSITIVE = 0x00000004,
        AW_VER_NEGATIVE = 0x00000008,
        AW_CENTER = 0x00000010,
        AW_SLIDE = 0x00040000,
        AW_BLEND = 0x00080000
    }

}
