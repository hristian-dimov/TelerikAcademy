using System;
using System.Linq;

namespace MusicStore.Models
{
    public class SongModel
    {
        public int SongId { get; set; }

        public string Title { get; set; }

        public virtual DateTime? Year { get; set; }

        public string Genre { get; set; }

        public int ArtistId { get; set; }
    }
}