using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using static MyMusicPlayerApp.Model.Music;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MyMusicPlayerApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PlayerPage : Page
    {
        private ObservableCollection<MusicCategory> categories;
        private MediaPlayer mediaPlayer;
        public PlayerPage()
        {
            this.InitializeComponent();
            categories = new ObservableCollection<MusicCategory>();
            categories.Add(MusicCategory.Classical);
            categories.Add(MusicCategory.Country);
            categories.Add(MusicCategory.International);
            categories.Add(MusicCategory.Others);
            categories.Add(MusicCategory.Rock);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void TxtFilePath_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                TextBox tbPath = sender as TextBox;

                if (tbPath != null)
                {
                    LoadMediaFromString(tbPath.Text);
                }
            }
        }

        private void LoadMediaFromString(string path)
        {
            try
            {
                mediaPlayer = new MediaPlayer();
                Uri pathUri = new Uri(path);
                mediaPlayer.Source = MediaSource.CreateFromUri(pathUri);
            }
            catch (Exception ex)
            {
                if (ex is FormatException)
                {
                    // handle exception.
                    // For example: Log error or notify user problem with file
                }
            }
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_songname.Text))
            {
                txt_songname.Text = string.Empty;
            }

            if (!string.IsNullOrEmpty(txtImagePath.Text))
            {
                txtImagePath.Text = string.Empty;
            }

            if (!string.IsNullOrEmpty(drop_category.Text))
            {
                drop_category.Text = string.Empty;
            }
        }

    }
}
