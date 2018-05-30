using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MediaInfoNET;
using System.IO;
namespace Player {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
   
    public partial class MainWindow : Window {
        public List<Song> SongList;

        public MainWindow() {
            InitializeComponent();
            ResourceDictionary RD = new ResourceDictionary() { Source = new Uri("Gray.xaml", UriKind.Relative) };
            this.Resources.MergedDictionaries.Add(RD);
        }

        public void SelectFolder(object sender, EventArgs e)
        {
          //  MediaInfo tempData;
            Song tempSong;
            SongList = new List<Song>();
            System.Windows.Forms.FolderBrowserDialog folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            if(System.Windows.Forms.DialogResult.OK== folderBrowser.ShowDialog()){

                DirectoryInfo info = new DirectoryInfo(folderBrowser.SelectedPath);

                foreach (FileInfo item in info.GetFiles()) {
                                     
                    MediaFile media = new MediaFile(item.FullName);
                    tempSong = new Song(media.General.Description, 0, media.General.DurationString, media.Title, media.Description);

                    // ahtung !!

                    TagLib.File file = TagLib.File.Create(item.FullName);
                    tempSong.Artist = file.Tag.FirstArtist;

                    if (file.Tag.Pictures.Length >= 1) { 
                        var a = file.Tag.Pictures[0].Data.Data;
                        tempSong.Cover = (BitmapSource)new ImageSourceConverter().ConvertFrom(a);
                    }                   
                    // !! todo

                    if (item.Extension == ".mp3" || item.Extension == ".wav" || item.Extension == ".flac" || item.Extension == ".acc") 
                        SongList.Add(tempSong);
                                               
                }
                
            }
            Playlist.SelectedIndex = 0; // hob hob kostelyok
            Playlist.ItemsSource = SongList;
        }

        private void Light_Click(object sender, RoutedEventArgs e) {
            ResourceDictionary RD = new ResourceDictionary() { Source = new Uri("White.xaml", UriKind.Relative) };
            this.Resources.MergedDictionaries.Add(RD);
        }

        private void Gray_Click(object sender, RoutedEventArgs e) {
            ResourceDictionary RD = new ResourceDictionary() { Source = new Uri("Gray.xaml", UriKind.Relative) };
            this.Resources.MergedDictionaries.Add(RD);
        }

        private void Dark_Click(object sender, RoutedEventArgs e) {
            ResourceDictionary RD = new ResourceDictionary() { Source = new Uri("Dark.xaml", UriKind.Relative) };
            this.Resources.MergedDictionaries.Add(RD);
        }

        private void Playlist_SelectionChanged(object sender, SelectionChangedEventArgs e) {        
            if (SongList != null) {
                
                LabelSongInfoSizable.Content = SongList[Playlist.SelectedIndex].Title;
                LabelSongInfoState.Content = SongList[Playlist.SelectedIndex].Artist;
                ImageMainCover.Source = SongList[Playlist.SelectedIndex].Cover;
                LabelSliderSecond.Content = SongList[Playlist.SelectedIndex].Duration;

               // SliderDuration.Maximum = Convert.ToInt32(SongList[Playlist.SelectedIndex].Duration.Trim());

            }
        }
    }


}
