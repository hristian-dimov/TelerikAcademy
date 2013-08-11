using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.Models
{
    public class ArtistModel
    {
        public int ArtistId { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public DateTime? DateOfBirth { get; set; }
    }

    public class ArtistModelFull : ArtistModel
    {
        public IEnumerable<AlbumModel> Albums { get; set; }
    }
}