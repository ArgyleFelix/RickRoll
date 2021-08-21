using System;
using System.IO;
using System.Windows;
using System.Windows.Threading;

namespace RickRoll
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            ExtractRickRoll();
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenRickRollWindow();
            DeleteRickRolTimer();
            Close();
        }

        private void OpenRickRollWindow()
        {
            Window1 Window1 = new Window1();
            Window1.Show();
            
        }

        private void ExtractRickRoll()
        {
            byte[] mp4Bytes = Properties.Resources.BlueRoll;
            string mp4ToRun = Path.Combine("C:/windows/temp", "surprise.mp4");
            if (File.Exists(mp4ToRun))
                File.Delete(mp4ToRun);

            using (FileStream mp4File = new FileStream(mp4ToRun, FileMode.CreateNew))
            {
                mp4File.Write(mp4Bytes, 0, mp4Bytes.Length);
            }
        }

        private void DeleteRickRolTimer()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(38d);
            timer.Tick += TimerTick;
            timer.Start();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            DispatcherTimer timer = (DispatcherTimer)sender;
            timer.Stop();
            timer.Tick -= TimerTick;
            File.Delete("C:/windows/temp/surprise.mp4");
        }
    }
}
