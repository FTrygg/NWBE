using System.Diagnostics;
using System.Runtime.InteropServices;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Screencap
{
    public partial class NWBE : Form
    {
        [DllImport("user32.dll")]
        private static extern bool
        SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(
        IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowRect(IntPtr hWnd, ref Rect rect);

        [StructLayout(LayoutKind.Sequential)]
        private struct Rect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        private enum apps
        {
            Newworld,
            NWGE
        }

        private const int SW_RESTORE = 9;

        public NWBE()
        {
            InitializeComponent();
            SwitchApp(apps.Newworld);
        }
        
        private void SwitchApp(apps app)
        {
            string appname = (app == apps.Newworld) ? "Newworld.exe" : "NWGE.exe";

            Process[] procs = Process.GetProcesses();
            if (procs.Length != 0)
            {
                for (int i = 0; i < procs.Length; i++)
                {   
                    try
                    {
                        if (procs[i].MainModule.ModuleName == "CiscoCollabHost.exe")
                        {
                            IntPtr hwnd = procs[i].MainWindowHandle;
                            ShowWindowAsync(hwnd, SW_RESTORE);
                            SetForegroundWindow(hwnd);
                            Bitmap pic = Cap(GetForegroundWindow());
                            ImageSave("webextestpic",ImageFormat.Png,pic);
                            return;
                        }
                        else
                        {
                            //Debug.WriteLine(procs[i].MainModule.ModuleName);
                        }
                    }
                    catch
                    {
                    }
                }
            }
            else
            { 
                return;
            }
            MessageBox.Show("New World does not seem to be running...");
        }

        public Bitmap Cap(IntPtr handle)
        {
            Rectangle bounds;
            var rect = new Rect();
            GetWindowRect(handle, ref rect);
            bounds = new Rectangle(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);
            //CursorPosition = new Point(Cursor.Position.X - rect.Left, Cursor.Position.Y - rect.Top);

            var result = new Bitmap(bounds.Width, bounds.Height);
            using (var g = Graphics.FromImage(result))
                g.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);

            return result;
        }
        
        static void ImageSave(string filename, ImageFormat format, Image image)
        {
            format = format ?? ImageFormat.Png;
            filename = @"C:\Users\Finn Tryggvason\Desktop\testpic.png";
            image.Save(filename, format);
        }

        
    }
}