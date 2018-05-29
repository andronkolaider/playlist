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
                    tempSong = new Song(media.General.Description,0,media.General.DurationString,media.Title,media.General.Description);
                    SongList.Add(tempSong);

                }
                
            }
            Playlist.ItemsSource = SongList;
        }
    }


}
