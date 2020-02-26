using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using MyMusicPlayerApp.Model;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using static MyMusicPlayerApp.Model.Music;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.Storage;
using Windows.Media.Core;
using Windows.Media.Playback;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MyMusicPlayerApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Music> audios;
        private List<MenuItem> menuItems;
        private MediaPlayer mediaPlayer;

        public MainPage()
        {
            this.InitializeComponent();
            audios = new ObservableCollection<Music>();
            MusicManager.GetAllSounds(audios);
            menuItems = new List<MenuItem>();
            // Load Pane
            menuItems.Add(new MenuItem
            {
                IconFile = "Assets/Icons/Rock.png",
                Category = MusicCategory.Rock
            });
            menuItems.Add(new MenuItem
            {
                IconFile = "Assets/Icons/Classical.png",
                Category = MusicCategory.Classical
            });
            menuItems.Add(new MenuItem
            {
                IconFile = "Assets/Icons/International.png",
                Category = MusicCategory.International
            });
            menuItems.Add(new MenuItem
            {
                IconFile = "Assets/Icons/Country.png",
                Category = MusicCategory.Country
            });
            menuItems.Add(new MenuItem
            {
                IconFile = "Assets/Icons/Others.png",
                Category = MusicCategory.Others
            });
        }
        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MusicManager.GetAllSounds(audios);
            CategoryTextBlock.Text = "All Music";
            MenuItemsListView.SelectedItem = null;
            BackButton.Visibility = Visibility.Collapsed;
        }

        private void MusicGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var music = (Music)e.ClickedItem;
            MyMediaElement.Source = MediaSource.CreateFromUri(new Uri(this.BaseUri, music.AudioFile));
          /*  mediaPlayer = new MediaPlayer();
            mediaPlayer = MyMediaElement.MediaPlayer;
            mediaPlayer.Play();  */         
        }

        private void MenuItemsListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var menuItem = (MenuItem)e.ClickedItem;
            CategoryTextBlock.Text = menuItem.Category.ToString();
            MusicManager.GetSoundsByCategory(audios, menuItem.Category);
            BackButton.Visibility = Visibility.Visible;
        }
        private async void User_song_click(object sender, ItemClickEventArgs e)
        {
            var clicked_song = (Music)e.ClickedItem;
            //if song clicked it will add to media userplaylist                
            StorageFile file = await KnownFolders.VideosLibrary.GetFileAsync(clicked_song.AudioFile);               
            if (file != null)                
            {                    
                var filestream = await file.OpenAsync(FileAccessMode.Read);
                // mediaControl is a MediaElement defined in XAML 
                MyMediaElement.Source = MediaSource.CreateFromStream(filestream, file.ContentType);                   
                mediaPlayer = new MediaPlayer();                   
                mediaPlayer = MyMediaElement.MediaPlayer;                    
                //_mediaPlayer.AutoPlay = false;                    
                mediaPlayer.Play();
            //  mediaElement.Source = MediaSource.CreateFromUri(new Uri(this.BaseUri, clicked_song.AudioFormat));
        }
    }
    private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer = new MediaPlayer();
            mediaPlayer = MyMediaElement.MediaPlayer;
            mediaPlayer.Pause();
            this.Frame.Navigate(typeof(PlayerPage));
        }

        private void playSoundButton_Click(object sender, RoutedEventArgs e)
        {          
            mediaPlayer.Play();
        }



        /*    private async void openFile_Click(object sender, RoutedEventArgs e)
            {
                FileOpenPicker fop = new FileOpenPicker();
                fop.SuggestedStartLocation = PickerLocationId.Desktop;
                fop.ViewMode = PickerViewMode.Thumbnail;
                fop.FileTypeFilter.Add(".mp4");

                StorageFile file = await fop.PickSingleFileAsync();
                if (file != null)
                {
                    IRandomAccessStream stream = await file.OpenAsync(FileAccessMode.Read);
                    MyMediaElement.SetSource(stream, file.ContentType);
                    MyMediaElement.Play();
                }

            }

            private void play_Click(object sender, RoutedEventArgs e)
            {
                if(MyMediaElement.DefaultPlaybackRate != 1)
                {
                    MyMediaElement.DefaultPlaybackRate = 1.0;
                }
                MyMediaElement.Play();
            }
            private void pause_Click(object sender, RoutedEventArgs e)
            {
                MyMediaElement.Pause();
            }

            private void stop_Click(object sender, RoutedEventArgs e)
            {
                MyMediaElement.Stop();
            }
            private void mute_Click(object sender, RoutedEventArgs e)
            {
                MyMediaElement.IsMuted = !MyMediaElement.IsMuted;
            }
            private void backward_Click(object sender, RoutedEventArgs e)
            {
                MyMediaElement.DefaultPlaybackRate = -2.0;
                MyMediaElement.Play();
            }
            private void forward_Click(object sender, RoutedEventArgs e)
            {
                MyMediaElement.DefaultPlaybackRate = 2.0;
                MyMediaElement.Play();
            }

            private void volumePlus_Click(object sender, RoutedEventArgs e)
            {
                if (MyMediaElement.IsMuted)
                {
                    MyMediaElement.IsMuted = false;
                }
                if(MyMediaElement.Volume >= 0)
                {
                    MyMediaElement.Volume += .1;
                }
            }

            private void volumeMinus_Click(object sender, RoutedEventArgs e)
            {
                if (MyMediaElement.IsMuted)
                {
                    MyMediaElement.IsMuted = false;
                }
                if (MyMediaElement.Volume < 1)
                {
                    MyMediaElement.Volume -= .1;
                }
            }*/
    }
}
