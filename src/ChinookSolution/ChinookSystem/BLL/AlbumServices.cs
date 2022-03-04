﻿#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additonal Namespace
using ChinookSystem.DAL;
using ChinookSystem.Entities;
using ChinookSystem.ViewModels;
using Microsoft.EntityFrameworkCore.ChangeTracking;
#endregion


namespace ChinookSystem.BLL
{
    public class AlbumServices
    {
        #region Constructor and Context Dependency
        private readonly ChinookContext _context;

        internal AlbumServices(ChinookContext context)
        {
            _context = context;
        }
        #endregion

        #region Services : Queries
        public List<AlbumsListBy> AlbumsByGenre(int genreid,
                                                int pageNumber,
                                                int pagesize,
                                                out int totalrows)
        {
            // return raw data and let the presentation layer decide ordering
            // pageNumber, pageSize, totalrows are input parameters used for
            //  paging on the presentation layer
            // this query will return ONLY the rows that will be displayed on the
            //  browser
            IEnumerable<AlbumsListBy> info = _context.Tracks
                                        .Where(x => x.GenreId == genreid
                                            && x.AlbumId.HasValue)
                                        .Select(x => new AlbumsListBy
                                        {
                                            AlbumId = (int)x.AlbumId,
                                            Title = x.Album.Title,
                                            ArtistId = x.Album.ArtistId,
                                            ReleaseYear = x.Album.ReleaseYear,
                                            ReleaseLabel = x.Album.ReleaseLabel,
                                            ArtistName = x.Album.Artist.Name,
                                            TrackCount = 0
                                        })
                                        .Distinct()
                                        .OrderBy(x => x.Title);

            // determine the size of the whole query collection
            totalrows = info.Count();

            // calculate the number of rows to SKIP in the query collection
            // this calculation depends on the page number and page size
            // page 1: skip 0 rows; page 2: skip pagesize rows; page 3: skip 2*pagesize rows ...
            int skipRows = (pageNumber - 1) * pagesize;
            // On the return, use the .Skip() and .Take() Linq extensions to extract the 
            //  actually row data to return

            return info.Skip(skipRows).Take(pagesize).ToList();
        }

        public AlbumItem Albums_GetAlbumById(int albumid)
        {
            //linq to entity therefore you need to access the DbSet in your
            //      context class

            AlbumItem info = _context.Albums
                            .Where(x => x.AlbumId == albumid)
                            .Select(x => new AlbumItem
                            {
                                AlbumId = x.AlbumId,
                                Title = x.Title,
                                ArtistId = x.ArtistId,
                                ReleaseYear = x.ReleaseYear,
                                ReleaseLabel = x.ReleaseLabel
                            }).FirstOrDefault();
            return info;
        }

        #endregion

        #region Add,Update and Delete
        public int AddAlbum(AlbumItem item)
        {
            //this method will return the new album id if the add was successful
            //REMINDER: AlbumItem is NOT an entity; it is a view model class
            //          This means you MUST move the data from the view model class
            //              to an instance of your desired entity

            //add a business rule to the method
            //     rule: no album with the same title, same year, same artist
            //     result: this will be considered a duplicate album

            //how can one do such a test
            //1) use a search loop pattern: set a flag as found or not found
            //2) use can use Linq and test the result of a query: .FirstOrDefault()
            Album exist = _context.Albums
                            .Where(x => x.Title.Equals(item.Title)
                                     && x.ArtistId == item.ArtistId
                                     && x.ReleaseYear == item.ReleaseYear)
                            .FirstOrDefault();
            if (exist != null)
            {
                throw new Exception("Album already exists on file");
            }

            //setup the entity instance with the data from the view model parameter
            //NOTE: Album has a identity pkey; therefore one does NOT need to set
            //      the AlbumId
            exist = new Album
            {
                Title = item.Title,
                ArtistId = item.ArtistId,
                ReleaseYear = item.ReleaseYear,
                ReleaseLabel = item.ReleaseLabel
            };
            //stage add in local memory
            _context.Add(exist);
            //do any validation within the entity (validation anotation)
            //send stage request to the database for processing (transaction)
            _context.SaveChanges();
            return exist.AlbumId;
        }
        public int UpdateAlbum(AlbumItem item)
        {
            Album exist = _context.Albums
                            .Where(x => x.AlbumId == item.AlbumId)
                            .FirstOrDefault();
            if (exist == null)
            {
                throw new Exception("Album does not exist on file");
            }
            //setup the entity instance with the data from the view model parameter
            //NOTE: For an update you need the pkey value
            //if the album was found, then you have a copy of that record (instance)
            //  in your  variable
            //You the pkey, you need to move your rest of the fields into the
            //  appropriate columns

            exist.Title = item.Title;
            exist.ArtistId = item.ArtistId;
            exist.ReleaseYear = item.ReleaseYear;
            exist.ReleaseLabel = item.ReleaseLabel;

            //stage add in local memory
            EntityEntry<Album> updating = _context.Entry(exist);
            updating.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            //do any validation within the entity (validation anotation)
            //send stage request to the database for processing
            //the returned value is the number of rows altered
            return _context.SaveChanges();

        }

        public int DeleteAlbum(AlbumItem item)
        {
            Album exist = _context.Albums
                           .Where(x => x.AlbumId == item.AlbumId)
                           .FirstOrDefault();
            if (exist == null)
            {
                throw new Exception("Album does not exist on file");
            }
            //setup the entity instance with the data from the view model parameter
            //NOTE: For an update you need the pkey value
            //if the album was found, then you have a copy of that record (instance)
            //  in your  variable
            //You the pkey, you need to move your rest of the fields into the
            //  appropriate columns

            exist.Title = item.Title;
            exist.ArtistId = item.ArtistId;
            exist.ReleaseYear = item.ReleaseYear;
            exist.ReleaseLabel = item.ReleaseLabel;

            EntityEntry<Album> deleting = _context.Entry(exist);
            deleting.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;

            return _context.SaveChanges();
        }
        #endregion


    }
}
