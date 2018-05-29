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
        public string Duration { get; }
        public short Rating { get; }
        public string Artist { get; }
        public string Title { get; }
        public string SupportInfo { get; }
        public Song(string _artist,short _rating,string _duration,string _title,string _supportInfo)
        {
            Duration = _duration;
            Rating = _rating;
            Artist = _artist;

        }
    }
}
