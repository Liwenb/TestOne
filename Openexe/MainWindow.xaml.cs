using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Openexe
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        [DllImport("user32.dll")]
        static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
        //定义变量
        private IntPtr prsmwh;//外部EXE文件运行句柄
        private IntPtr prsmwh1;
        private IntPtr prsmwh2;
        private IntPtr prsmwh3;
        private Process app;//外部exe文件对象
        private Process app1;
        private Process app2;
        private Process app3;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(System.Diagnostics.Process.Start(@"C:\Users\TN\Desktop\Exe文件\AudioBasics-WPF.exe").ProcessName.ToString());
            //System.Diagnostics.Process.Start(@"C:\Users\TN\Desktop\Exe文件\AudioBasics-WPF.exe");
        }
        private void Init()
        {
            IntPtr handle = new WindowInteropHelper(this).Handle;
            app = Process.Start(@"C:\Users\TN\Desktop\Exe文件\AudioBasics-WPF.exe");
            app1 = Process.Start(@"C:\Users\TN\Desktop\Exe文件\BodyBasics-WPF.exe");
            //app2 = Process.Start(@"C:\Users\TN\Desktop\Testface\FaceBasics-WPF\bin\x64\Debug\FaceBasics-WPF.exe");
            //app3 = Process.Start(@"C:\Users\TN\Desktop\Testface1\FaceBasics-D2D\Debug\FaceBasics-D2D.exe");
            prsmwh = app.MainWindowHandle;
            while (prsmwh == IntPtr.Zero)
            {
                prsmwh = app.MainWindowHandle;
            }
            //设置父窗口
            SetParent(prsmwh, handle);
            ShowWindowAsync(prsmwh, 1);



            prsmwh1 = app1.MainWindowHandle;
            while (prsmwh1 == IntPtr.Zero)
            {
                prsmwh1 = app1.MainWindowHandle;
            }
            //设置父窗口
            SetParent(prsmwh1, handle);
            ShowWindowAsync(prsmwh1, 1);

            //prsmwh2 = app2.MainWindowHandle;
            //while (prsmwh2 == IntPtr.Zero)
            //{
            //    prsmwh2 = app2.MainWindowHandle;
            //}
            ////设置父窗口
            //SetParent(prsmwh2, handle);
            //ShowWindowAsync(prsmwh2, 1);


            //prsmwh3 = app3.MainWindowHandle;
            //while (prsmwh3 == IntPtr.Zero)
            //{
            //    prsmwh3 = app3.MainWindowHandle;
            //}
            ////设置父窗口
            //SetParent(prsmwh3, handle);
            //ShowWindowAsync(prsmwh3, 1);
        }
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
       
        [DllImport("user32.dll", EntryPoint = "SendMessage", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hwnd, uint wMsg, int wParam, int lParam); //对外部软件窗口发送一些消息(如 窗口最大化、最小化等)

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Init();
        }
    }
}
