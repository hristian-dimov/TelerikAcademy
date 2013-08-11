using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.Models
{
    public class AlbumModel
    {
        public int AlbumId { get; set; }

        public string Title { get; set; }

        public DateTime? RealeaseDate { get; set; }

        public string Producer { get; set; }
    }

    public class AlbumModelFull : AlbumModel
    {
        public IEnumerable<ArtistModel> Artists { get; set; }

        public IEnumerable<SongModel> Songs { get; set; }
    }
}