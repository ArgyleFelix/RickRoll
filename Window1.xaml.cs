using System;
using System.Windows;
using System.Windows.Threading;

namespace RickRoll
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            StartCloseTimer();
        }

        private void StartCloseTimer()
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
            Close();
            //System.Diagnostics.Process.Start("https://discord.com/invite/hp3pyxGaxW");
        }

    }
}
