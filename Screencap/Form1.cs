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
            NWBE
        }

        private const int SW_RESTORE = 9;

        private Bitmap equipmentOverview;
        public NWBE()
        {
            InitializeEquipmentslots();
            InitializeWeapons();
            InitializeComponent();
            InitializeOutputPictures();
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
                if (app == apps.Newworld)
                {
                    createGearsetOverview(hwnd);
                }
            }
        }
        private void InitializeOutputPictures()
        {
            equipmentOverview = new Bitmap(2750, 1700);
            
        }
        private void createGearsetOverview(IntPtr hwnd, int delay = 700)
        {
            //close other windows if open
            SendKeys.SendWait("{ESC}");
            Thread.Sleep(delay);
            //open inventory
            SendKeys.SendWait("{TAB}");
            Thread.Sleep(delay);

            Rectangle bounds;
            var rect = new Rect();
            GetWindowRect(hwnd, ref rect);
            bounds = new Rectangle(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);
            Cursor = new Cursor(hwnd);

            //move to gearset button position and close 
            Cursor.Position = new Point(360, 996);
            Cursor.Clip = bounds;
            Thread.Sleep(delay);
            Mouseclick();

            equipmentOverview = new Bitmap(2750, 1700);
            using (Graphics g = Graphics.FromImage(equipmentOverview))
            {
                
                foreach (Equipment item in equipmentSlots)
                {
                    Cursor.Position = item.inventoryCoordinates;
                    Thread.Sleep(delay);
                    Bitmap tmpBitmap = Cap(hwnd, item.pictureArea);
                    g.DrawImage(tmpBitmap, item.outputArea.X, item.outputArea.Y, tmpBitmap.Size.Width, tmpBitmap.Size.Height);
                    Thread.Sleep(delay / 2);
                }
                
                Bitmap overlay = new Bitmap("");// open from resources
                g.DrawImage(overlay, 0, 0, overlay.Width, overlay.Height);
                ImageSave("output1", ImageFormat.Png, equipmentOverview);
            }
            


        }
        public void Mouseclick()
        {
            uint X = (uint)Cursor.Position.X;
            uint Y = (uint)Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
        }
        public Bitmap Cap(IntPtr handle, Rectangle rect)
        {
            var result = new Bitmap(rect.Width, rect.Height);
            using (var g = Graphics.FromImage(result))
                g.CopyFromScreen(new Point(rect.Left, rect.Top), Point.Empty, rect.Size);
            return result;
        }

        public Bitmap CapFull(IntPtr handle)
        {
            Rectangle bounds;
            var _rect = new Rect();
            GetWindowRect(handle, ref _rect);
            bounds = new Rectangle(_rect.Left, _rect.Top, _rect.Right - _rect.Left, _rect.Bottom - _rect.Top);
            var result = new Bitmap(bounds.Width, bounds.Height);
            using (var g = Graphics.FromImage(result))
                g.CopyFromScreen(new Point(_rect.Left, _rect.Top), Point.Empty, bounds.Size);
            return result;
        }

        static void ImageSave(string filename, ImageFormat format, Image image)
        {
            format = format ?? ImageFormat.Png;
            filename = @"C:\Users\Finn\Desktop\" + filename + ".png";
            image.Save(filename, format);
        }
        
    }
}