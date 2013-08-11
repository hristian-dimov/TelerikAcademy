using MusicStore.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MusicStore.Data
{
    public static class MusicStoreDAL
    {
        #region Album Operations
        public static void PrintAlbums(HttpClient httpClient)
        {
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = httpClient.GetAsync("albums").Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Albums");
                var albums = response.Content.ReadAsAsync<IEnumerable<Album>>().Result;

                foreach (var a in albums)
                {
                    Console.WriteLine("{0} --- {1}", a.Title, a.AlbumId);

                    // artists in album
                    foreach (var artist in a.Artists)
                    {
                        Console.WriteLine(artist.Name);
                    }
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        public static void CreateAlbum(HttpClient httpClient, Album theAlbum)
        {
            HttpContent postContent = new StringContent(JsonConvert.SerializeObject(theAlbum));
            postContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = httpClient.PostAsync("albums", postContent).Result;

            try
            {
                response.EnsureSuccessStatusCode();
                Console.WriteLine("Album created!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void DeleteAlbum(HttpClient httpClient, int albumId)
        {
            HttpResponseMessage response = httpClient.DeleteAsync("albums/" + albumId).Result;

            try
            {
                response.EnsureSuccessStatusCode();
                Console.WriteLine("Album deleted!");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
            }

        }
        #endregion

        #region Artist Operations
        public static void PrintArtists(HttpClient httpClient)
        {
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = httpClient.GetAsync("artists").Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Artists");
                var artists = response.Content.ReadAsAsync<IEnumerable<Artist>>().Result;
                foreach (var a in artists)
                {
                    Console.WriteLine("{0} --- {1}", a.Name, a.Country);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        public static void CreateArtist(HttpClient httpClient, Artist theArtist)
        {
            HttpContent postContent = new StringContent(JsonConvert.SerializeObject(theArtist));
            postContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = httpClient.PostAsync("artists", postContent).Result;

            try
            {
                response.EnsureSuccessStatusCode();
                Console.WriteLine("Artists created!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion

        #region Song Operations
        public static void CreateSong(HttpClient httpClient, Song theSong)
        {
            HttpContent postContent = new StringContent(JsonConvert.SerializeObject(theSong));
            postContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = httpClient.PostAsync("songs", postContent).Result;

            try
            {
                response.EnsureSuccessStatusCode();
                Console.WriteLine("Song created!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion
    }
}
