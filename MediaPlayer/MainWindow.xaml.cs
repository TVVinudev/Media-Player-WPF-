using Microsoft.Win32;
using System;
using System.Windows;

namespace MediaPlayer
{
    public partial class MainWindow : Window
    {
        bool mediaPlay = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        // Open Media File
        private void BtnOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Media Files|*.mp4;*.mp3;*.avi;*.wav"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                mediaPlayer.Source = new Uri(openFileDialog.FileName);
                mediaPlayer.Play();
                mediaPlay = true;

                // Hide Play button, Show Pause button
                btnPlay.Visibility = Visibility.Collapsed;
                btnPause.Visibility = Visibility.Visible;
            }
        }

        // Play Media
        private void BtnPlay_Click(object sender, RoutedEventArgs e)
        {
            if (mediaPlay)
            {
                mediaPlayer.Play();
                btnPause.Visibility = Visibility.Visible;
                btnPlay.Visibility = Visibility.Collapsed;
                btnStop.Visibility = Visibility.Visible;
                volumeSlider.Visibility = Visibility.Visible;
            }
        }

        // Pause Media
        private void BtnPause_Click(object sender, RoutedEventArgs e)
        {
            if (mediaPlay)
            {
                mediaPlayer.Pause();
                btnPlay.Visibility = Visibility.Visible;
                btnPause.Visibility = Visibility.Collapsed;
            }
        }

        // Stop Media
        private void BtnStop_Click(object sender, RoutedEventArgs e)
        {
            if (mediaPlay)
            {
                mediaPlayer.Stop();
                btnPlay.Visibility = Visibility.Visible;
                btnPause.Visibility = Visibility.Collapsed;
            }
        }

        // Adjust Volume
        private void VolumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            mediaPlayer.Volume = volumeSlider.Value;
        }
    }
}
