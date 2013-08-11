using System;
using System.Linq;
using MusicStore.Models;
using MusicStore.Data;
using System.Net.Http;

namespace MusicStore.Client
{
    class Program
    {
        static void Main()
        {
            var client = new HttpClient()
            {
                BaseAddress = new Uri("http://localhost:3473/api/")
            };

            Album album = new Album();
            album.Title = "Test Album";
            album.Producer = "Test Producer";
            album.ReleaseDate = DateTime.Now;
            album.Artists.Add(new Artist()
            {
                Name = "Test Artist 1", 
                Country = "Bulgaria", 
                DateOfBirth = DateTime.Now
            });

            // creating new artist
            Artist linkinPark = new Artist();
            linkinPark.Name = "Linki Park";
            linkinPark.Country = "USA";
            linkinPark.DateOfBirth = DateTime.Now;

            // adding new song to existing album
            album.Songs.Add(new Song()
            {
                Title = "Lies Greed Misery",
                Year = new DateTime(2012, 5, 24),
                Genre = "Alt Rock",
                Artist = new Artist() 
                { 
                    Name = "Test Artist 2", 
                    Country = "Bulgaria", 
                    DateOfBirth = DateTime.Now 
                }
            });

            MusicStoreDAL.CreateAlbum(client, album);

            // creating new song
            Song lpSong = new Song()
            {
                Title = "Waiting For The End",
                Year = new DateTime(2010, 10, 1),
                Genre = "Alt Rock",
                Artist = new Artist()
                {
                    Name = "Test Artist 3",
                    Country = "Bulgaria",
                    DateOfBirth = DateTime.Now
                }
            };
            MusicStoreDAL.CreateSong(client, lpSong);

            //MusicStoreDAL.PrintAlbums(client);
        }
    }
}