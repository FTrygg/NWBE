using System.Diagnostics;
using System.Runtime.InteropServices;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using System.Reflection.Metadata;

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

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

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
            string appname = (app == apps.Newworld) ? "NewWorld" : "NWGE.exe";

            Process[] processes = Process.GetProcessesByName(appname);
            if (processes.Length == 1 )
            {
                Debug.WriteLine("Found process");
                IntPtr hwnd = processes[0].MainWindowHandle;
                ShowWindowAsync(hwnd, SW_RESTORE);
                SetForegroundWindow(hwnd);
                Debug.WriteLine($"Set process to {appname}");


                SendKeys.SendWait("{ESC}");
                Thread.Sleep(700);
                SendKeys.SendWait("{TAB}");
                Thread.Sleep(500);

                Rectangle bounds;
                var rect = new Rect();
                GetWindowRect(hwnd, ref rect);
                bounds = new Rectangle(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);
                
                Cursor = new Cursor(hwnd);
                Cursor.Position = new Point(360,996);
                Cursor.Clip = bounds;
                
                Thread.Sleep(500);

                uint X = (uint)Cursor.Position.X;
                uint Y = (uint)Cursor.Position.Y;
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);

                Cursor.Position = new Point(360, 996);
                Thread.Sleep(500);
                ImageSave("",ImageFormat.Png,Cap(hwnd));

            }
        }
        private void createGearsetOverview(IntPtr hwnd)
        {
            
            //Cursor.Clip = new Rectangle(this.Location, this.Size);
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
            filename = @"C:\Users\Finn\Desktop\testpic.png";
            image.Save(filename, format);
        }

        
    }
}