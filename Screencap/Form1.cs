using System.Diagnostics;
using System.Runtime.InteropServices;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using System.Reflection.Metadata;
using System.Collections.Generic;
using static Screencap.NWBE;

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
            SetupUI();
        }

        private IntPtr SwitchApp(apps app)
        {
            string appname = (app == apps.Newworld) ? "NewWorld" : "NWBE.exe";

            Process[] processes = Process.GetProcessesByName(appname);
            if (processes.Length == 1)
            {
                Debug.WriteLine("Found process");
                IntPtr hwnd = processes[0].MainWindowHandle;
                ShowWindowAsync(hwnd, SW_RESTORE);
                SetForegroundWindow(hwnd);
                Debug.WriteLine($"Set process to {appname}");
                return (hwnd);
            }
            return (IntPtr.Zero);
        }
        private void CreateGearsetOverview(IntPtr hwnd, int delay = 700)
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
                Bitmap overlay = new Bitmap(Properties.Resources.ClearOverlay);// open from resources
                g.DrawImage(overlay, 0, 0, overlay.Width, overlay.Height);
                ImageSave("Gearoverview", ImageFormat.Png, equipmentOverview);
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

        private void ImageSave(string filename, ImageFormat format, Image image)
        {
            format = format ?? ImageFormat.Png;
            filename = Path.Join(this.ouputFolderBrowser.SelectedPath, $"{filename}.png");
            image.Save(filename, format);
        }
        private void CreateSkilltreeOverview(IntPtr hwnd, int delay = 700)
        {
            List<string> selectedWeapons = new List<string>();
            selectedWeapons.Add(weapon1Combobox.GetItemText(weapon1Combobox.SelectedItem));
            selectedWeapons.Add(weapon2Combobox.GetItemText(weapon2Combobox.SelectedItem));

            foreach (string weapon in selectedWeapons)
            {
                //close other windows if open
                SendKeys.SendWait("{ESC}");
                Thread.Sleep(delay);
                //open inventory
                SendKeys.SendWait("{K}");
                Thread.Sleep(delay);

                Rectangle bounds;
                var rect = new Rect();
                GetWindowRect(hwnd, ref rect);
                bounds = new Rectangle(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);
                Cursor = new Cursor(hwnd);

                //move to weaponmastery coordinates position and click 
                Cursor.Position = weaponMasteryCoordinates;
                Cursor.Clip = bounds;
                Thread.Sleep(delay);
                Mouseclick();
                Thread.Sleep(delay);


                Weapon w = weapons.Where(i => i.name == weapon).FirstOrDefault();
                Cursor.Position = w.masteryCoordinates;
                Cursor.Clip = bounds;
                Thread.Sleep(delay);
                Mouseclick();
                Thread.Sleep(delay);
                Cursor.Position = new Point(5, 5);
                Cursor.Clip = bounds;
                Thread.Sleep(delay);

                Bitmap skilltreeOverview = new Bitmap(1550, 740);
                using (Graphics g = Graphics.FromImage(skilltreeOverview))
                {
                    Rectangle subsection = new Rectangle(224, 222, 1550, 740);
                    Bitmap tmpBitmap = Cap(hwnd, subsection);
                    g.DrawImage(tmpBitmap, 0, 0, subsection.Size.Width, subsection.Size.Height);
                    ImageSave($"{weapon}_Skilltree", ImageFormat.Png, skilltreeOverview);
                    Thread.Sleep(delay);
                }
            }
        }
        private void CreateAttributeOverview(IntPtr hwnd, int delay = 700)
        {
            //close other windows if open
            SendKeys.SendWait("{ESC}");
            Thread.Sleep(delay);
            //open inventory
            SendKeys.SendWait("{K}");
            Thread.Sleep(delay);

            Rectangle bounds;
            var rect = new Rect();
            GetWindowRect(hwnd, ref rect);
            bounds = new Rectangle(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);
            Cursor = new Cursor(hwnd);

            //move to gearset button position and close 
            Cursor.Position = attributeCoordinates;
            Cursor.Clip = bounds;
            Thread.Sleep(delay);
            Mouseclick();
            Thread.Sleep(delay);

            Bitmap attributeOverview = new Bitmap(1120, 575);
            using (Graphics g = Graphics.FromImage(attributeOverview))
            {
                Rectangle subsection = new Rectangle(453, 231, 1120, 575);
                Bitmap tmpBitmap = Cap(hwnd, subsection);
                g.DrawImage(tmpBitmap, 0, 0, subsection.Size.Width, subsection.Size.Height);
                ImageSave("Attributes", ImageFormat.Png, attributeOverview);
            }
            Thread.Sleep(delay);
        }


        private void weapon1Combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateComboboxes(weapon1Combobox);
        }

        private void weapon2Combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateComboboxes(weapon2Combobox);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            DialogResult result = this.ouputFolderBrowser.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(this.ouputFolderBrowser.SelectedPath))
            {
                Debug.WriteLine(this.ouputFolderBrowser.SelectedPath);
                linkLabel1.Text = this.ouputFolderBrowser.SelectedPath;
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (weapon1Combobox.SelectedItem != null && weapon2Combobox.SelectedItem != null)
            {
                IntPtr i = SwitchApp(apps.Newworld);
                if (i == IntPtr.Zero)
                {
                    MessageBox.Show("New world is not running");
                }
                else
                {
                    CreateGearsetOverview(i);
                    CreateAttributeOverview(i);
                    CreateSkilltreeOverview(i);
                    SendKeys.SendWait("{ESC}");
                    MessageBox.Show("Build has been exported!");
                }

            }
            else
            {
                MessageBox.Show("Please select both weapons");
            }
        }
    }
}