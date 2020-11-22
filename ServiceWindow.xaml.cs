using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Interop;
namespace Autom8
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {
        MainWindow win = new MainWindow();
        HotKeyPopupWindow winPopup = new HotKeyPopupWindow();
        double w = SystemParameters.PrimaryScreenWidth;
        double h = SystemParameters.PrimaryScreenHeight;

        NotifyIcon nIcon = new NotifyIcon();
        public Window1()
        {
            InitializeComponent();
            winPopup.Left = h/2;
            winPopup.Top = w/2.5;

            Debug.WriteLine("RES: " + w + "x" + h);
        }

        private void MoveToTray(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("MoveTray");
            if (nIcon.Visible != true)
            {
                Hide();
                nIcon.Icon = new Icon("Images/Autom8_Icon_win.ico");
                nIcon.Text = "Autom8 Running...";
                nIcon.BalloonTipText = "Open Autom8 Config";
                nIcon.ShowBalloonTip(2000);
                nIcon.Click += new EventHandler(ShowWindow);
                nIcon.Visible = true;
            }
        }

        public void ShowWindow(object sender, EventArgs e)
        {
            if(win.IsVisible == false)
                win.Show();
        }

        [DllImport("User32.dll")]
        private static extern bool RegisterHotKey(
            [In] IntPtr hWnd,
            [In] int id,
            [In] uint fsModifiers,
            [In] uint vk);

        [DllImport("User32.dll")]
        private static extern bool UnregisterHotKey(
            [In] IntPtr hWnd,
            [In] int id);

        private HwndSource _source;
        private const int HOTKEY_ID = 9000;

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            Debug.WriteLine("Initialized");
            var helper = new WindowInteropHelper(this);
            _source = HwndSource.FromHwnd(helper.Handle);
            _source.AddHook(HwndHook);
            RegisterHotKey();
        }

        protected override void OnClosed(EventArgs e)
        {
            _source.RemoveHook(HwndHook);
            _source = null;
            UnregisterHotKey();
            base.OnClosed(e);
        }

        private void RegisterHotKey()
        {
            var helper = new WindowInteropHelper(this);
            const uint VK_8 = 0x38;
            const uint MOD_CTRL = 0x0002;
            const uint MOD_SHIFT = 0x0004; //SHIFT
            if (!RegisterHotKey(helper.Handle, HOTKEY_ID, MOD_CTRL | MOD_SHIFT, VK_8))//ctrl+shift+8
            {
                // handle error
                Debug.WriteLine("HotKey Failed");
            }
        }

        private void UnregisterHotKey()
        {
            var helper = new WindowInteropHelper(this);
            UnregisterHotKey(helper.Handle, HOTKEY_ID);
        }

        private IntPtr HwndHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            const int WM_HOTKEY = 0x0312;

            switch (msg)
            {
                case WM_HOTKEY:
                    Debug.WriteLine("HotKey Detect");
                    switch (wParam.ToInt32())
                    {
                        case HOTKEY_ID:
                            OnHotKeyPressed();
                            handled = true;
                            break;
                    }
                    break;
            }
            return IntPtr.Zero;
        }

        private void OnHotKeyPressed()
        {
            // do stuff
            if (winPopup.IsVisible == false)
                winPopup.Show();
        }

    }
}
