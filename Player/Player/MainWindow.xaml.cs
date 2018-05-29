﻿using System;
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
            ResourceDictionary RD = new ResourceDictionary() { Source = new Uri("White.xaml", UriKind.Relative) };
            this.Resources.MergedDictionaries.Add(RD);
        }

        public void SelectFolder(object sender, EventArgs e)
        {
          //  MediaInfo tempData;
            Song tempSong;
            SongList = new List<Song>();
            System.Windows.Forms.FolderBrowserDialog folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            if(System.Windows.Forms.DialogResult.OK== folderBrowser.ShowDialog())
            {
                DirectoryInfo info = new DirectoryInfo(folderBrowser.SelectedPath);
                foreach (FileInfo item in info.GetFiles())
                {
                   
                   
                    MediaFile media = new MediaFile(item.FullName);
                    tempSong = new Song(media.General.Description, 0, media.General.DurationString, media.Title, media.Description);

                    // ahtung !!

                    var file = new TagLib.Mpeg4.File(item.FullName);
                    if (file.Tag.Pictures.Length >= 1) {
                        var bin = (byte[])(file.Tag.Pictures[0].Data.Data);
                        BitmapImage image = new BitmapImage();
                        using (MemoryStream str = new MemoryStream(bin)) {
                            image. = BitmapFrame.Create(str, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                        }
                            tempSong.Cover = BitmapImage.FromStream(new MemoryStream(bin)).GetThumbnailImage(100, 100, null, IntPtr.Zero);
                    }
                    // !! todo

                    if (item.Extension == ".mp3" || item.Extension == ".wav" || item.Extension == ".flac") 
                        SongList.Add(tempSong);
                                               
                }
                
            }
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
    }


}
