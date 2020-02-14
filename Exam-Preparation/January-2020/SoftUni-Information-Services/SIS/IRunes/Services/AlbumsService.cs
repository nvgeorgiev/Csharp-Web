using IRunes.Models;
using IRunes.ViewModels.Albums;
using IRunes.ViewModels.Tracks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRunes.Services
{
    public class AlbumsService : IAlbumsService
    {
        private readonly IRunesDbContext db;

        public AlbumsService(IRunesDbContext db)
        {
            this.db = db;
        }

        public void Create(string name, string cover)
        {
            var album = new Album
            {
                Name = name,
                Cover = cover,
                Price = 0
            };

            this.db.Albums.Add(album);
            this.db.SaveChanges();
        }

        public IEnumerable<AlbumInfoViewModel> GetAll()
        {
            var allAlbums = this.db.Albums.Select(x => new AlbumInfoViewModel
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();

            return allAlbums;
        }

        public AlbumsDetailsViewModel GetDetails(string id)
        {
            var album = this.db.Albums
                .Where(x => x.Id == id)
                .Select(x => new AlbumsDetailsViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Cover = x.Cover,
                    Price = x.Price,
                    Tracks = x.Tracks.Select(t => new TrackInfoViewModel
                    {
                        Id = t.Id,
                        Name = t.Name
                    })
                })
                .FirstOrDefault();

            return album;
        }
    }
}
