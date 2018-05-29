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
        short rating;
        public double Duration { get; set; }
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
        public Song(string _artist,short _rating,double _duration)
        {
            Duration = _duration;
            Rating = _rating;
            Artist = _artist;

        }
    }
}
