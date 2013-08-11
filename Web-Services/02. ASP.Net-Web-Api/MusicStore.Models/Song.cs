using System;

namespace MusicStore.Models
{
    public class Song
    {
        public int SongId { get; set; }

        public string Title { get; set; }

        public virtual DateTime? Year { get; set; }

        public string Genre { get; set; }

        public Artist Artist { get; set; }
    }
}
