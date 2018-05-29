using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using MediaInfoNET;
namespace Player
{
  public  class Song
    {
        short rating;
        public string Duration { get; set; }
        public short Rating
        {
            get 
            {
                return rating;
            }
            set
            {
                rating = Convert.ToInt16(value + 1);
            }
        }
        public string Artist { get; set; }
        public string Title { get; set; }
        public string SupportInfo { get; set; }

        public Song(string _artist, short _rating, string _duration, string _title, string _supportInfo)
        {
            Duration = _duration;
            Rating = _rating;
            Artist = _artist;
            Title = _title;
            SupportInfo = _supportInfo;
        }
    }
}
