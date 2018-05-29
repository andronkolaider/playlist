using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using MediaInfoNET;
namespace Player
{
    class Song
    {
        public double Duration { get; }
        public short Rating { get; }
        public string Artist { get; }
        public string Title { get; }
        public string SupportInfo { get; }
        public Song(string _artist,short _rating,double _duration)
        {
            Duration = _duration;
            Rating = _rating;
            Artist = _artist;

        }
    }
}
