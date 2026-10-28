using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Interop;


namespace Shake_to_find
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [DllImport("user32.dll")]
        static extern int GetWindowLongPtr(IntPtr hWnd, int index);
        [DllImport("user32.dll")]
        static extern int SetWindowLongPtr(IntPtr hwnd, int index, int dwNewLong);

        const int GWL_EXstyle = -20;
        const int WS_EX_TRANSPARENT = 0x00000020;
        const int WS_EX_LAYERED = 0x00080000;

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);

            var hwnd = new WindowInteropHelper(this).Handle;
            var style = GetWindowLongPtr(hwnd, GWL_EXstyle);
            SetWindowLongPtr(hwnd, GWL_EXstyle, style | WS_EX_TRANSPARENT | WS_EX_LAYERED);
        }

        public MainWindow()
        {
            InitializeComponent();
        }
    }
}