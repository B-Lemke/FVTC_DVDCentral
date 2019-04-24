using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BJL.DVDCentral.PL;

namespace BJL.DVDCentral.BL
{
    public class Movie
    {
        //Properties
        public int Id { get; set; }
        public decimal Cost { get; set; }
        public int FormatId { get; set; }
        [DisplayName("Format")]
        public string FormatName { get; set; }
        public int Quantity { get; set; }
        public int DirectorId { get; set; }
        [DisplayName("Director")]
        public string DirectorFullName { get; set; }
        [DisplayName("Image Path")]
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public int RatingId { get; set; }
        [DisplayName("Rating")]
        public string RatingName { get; set; }
        public string Title { get; set; }
        public GenreList Genres { get; set; }

        public void LoadById()
        {

            try
            {
                using (DVDEntities dc = new DVDEntities())
                {
                    //Make sure that the ID is set and valid
                    if (this.Id >= 0)
                    {
                        tblMovie movie = dc.tblMovies.FirstOrDefault(m => m.Id == this.Id);

                        //Make sure that a movie was retrieved
                        if (movie != null)
                        {
                            //Set the properties on this movie
                            this.Description = movie.Description;
                            this.Cost = movie.Cost;
                            this.DirectorId = movie.DirectorId;
                            this.FormatId = movie.FormatId;
                            this.Id = movie.Id;
                            this.Title = movie.Title;
                            this.ImagePath = movie.ImagePath;
                            this.Quantity = movie.Quantity;
                            this.RatingId = movie.RatingId;

                            this.LoadGenres();
                        }
                        else
                        {
                            throw new Exception("No movie to load with this Id");
                        }
                    }
                    else
                    {
                        throw new Exception("Movie Id not Valid");
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int Insert()
        {
            try
            {
                using (DVDEntities dc = new DVDEntities())
                {

                    tblMovie movie = new tblMovie
                    {
                        Description = this.Description,
                        Cost = this.Cost,
                        DirectorId = this.DirectorId,
                        FormatId = this.FormatId,
                        ImagePath = this.ImagePath,
                        Quantity = this.Quantity,
                        RatingId = this.RatingId,
                        Title = this.Title,
                        Id = dc.tblMovies.Any() ? dc.tblMovies.Max(m => m.Id) + 1 : 1

                    };
                    this.Id = movie.Id;
                    dc.tblMovies.Add(movie);

                    //Return the rows effected
                    return dc.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public int Update()
        {
            try
            {
                using (DVDEntities dc = new DVDEntities())
                {
                    //Make sure that the ID is set and valid
                    if (this.Id >= 0)
                    {
                        tblMovie movie = dc.tblMovies.FirstOrDefault(m => m.Id == this.Id);

                        //Make sure that a movie was retrieved
                        if (movie != null)
                        {
                            //Update the proterties on the movie
                            movie.Description = this.Description;
                            movie.Cost = this.Cost;
                            movie.DirectorId = this.DirectorId;
                            movie.FormatId = this.FormatId;
                            movie.ImagePath = this.ImagePath;
                            movie.Quantity = this.Quantity;
                            movie.RatingId = this.RatingId;
                            movie.Title = this.Title;


                            //return the number of rows effected
                            return dc.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("No movie to load with this Id");
                        }
                    }
                    else
                    {
                        throw new Exception("Movie Id not Valid");
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int Delete()
        {
            try
            {
                using (DVDEntities dc = new DVDEntities())
                {
                    //Make sure that the ID is set and valid
                    if (this.Id >= 0)
                    {
                        tblMovie movie = dc.tblMovies.FirstOrDefault(m => m.Id == this.Id);

                        //Make sure that a movie was retrieved
                        if (movie != null)
                        {
                            //Update the proterties on the movie
                            dc.tblMovies.Remove(movie);

                            //return the number of rows effected
                            return dc.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("No movie to load with this Id");
                        }
                    }
                    else
                    {
                        throw new Exception("Movie Id not Valid");
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public void LoadGenres()
        {
            using (DVDEntities dc = new DVDEntities())
            {
                Genres = new GenreList();
                Genres.Clear();

                var genres = from mg in dc.tblMovieGenres
                               join g in dc.tblGenres on mg.GenreId equals g.Id
                               where mg.MovieId == this.Id
                               select new
                               {
                                   g.Id,
                                   g.Description
                               };

                foreach (var genre in genres)
                {
                    Genre newGenre = new Genre
                    {
                        Id = genre.Id,
                        Description = genre.Description
                    };

                    this.Genres.Add(newGenre);
                }
            }
        }

    }

    public class MovieList : List<Movie>
    {
        public void Load()
        {
            try
            {
                using (DVDEntities dc = new DVDEntities())
                {
                    //Get the genrs from the database
                    var movies = (from m in dc.tblMovies
                                  join r in dc.tblRatings on m.RatingId equals r.Id
                                  join f in dc.tblFormats on m.FormatId equals f.Id
                                  join d in dc.tblDirectors on m.DirectorId equals d.Id
                                  orderby m.Title
                                  select new
                                  {
                                      MovieId = m.Id,
                                      m.Description,
                                      m.Cost,
                                      m.DirectorId,
                                      DirectorName = d.FirstName + " " + d.LastName,
                                      m.FormatId,
                                      FormatName = f.Description,
                                      m.ImagePath,
                                      m.Quantity,
                                      m.RatingId,
                                      RatingName = r.Description,
                                      m.Title
                                  }).ToList();
                    //For each movie
                    foreach (var m in movies)
                    {

                            //Movie not already in collection

                            //Make a new movie and set its properties
                            Movie movie = new Movie
                            {
                                Id = m.MovieId,
                                Description = m.Description,
                                Cost = m.Cost,
                                DirectorId = m.DirectorId,
                                DirectorFullName = m.DirectorName,
                                FormatId = m.FormatId,
                                FormatName = m.FormatName,
                                ImagePath = m.ImagePath,
                                Quantity = m.Quantity,
                                RatingId = m.RatingId,
                                RatingName = m.RatingName,
                                Title = m.Title,
                            };
                            movie.LoadGenres();
                            //Add it to the movie list


                            this.Add(movie);
                        

              
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    


        public void LoadByGenreId(int? genreId)
        {
            try
            {
                using (DVDEntities dc = new DVDEntities())
                {
                    //Get the genrs from the database
                    var movies = (from m in dc.tblMovies
                                  join r in dc.tblRatings on m.RatingId equals r.Id
                                  join f in dc.tblFormats on m.FormatId equals f.Id
                                  join d in dc.tblDirectors on m.DirectorId equals d.Id
                                  join mg in dc.tblMovieGenres on m.Id equals mg.MovieId
                                  join g in dc.tblGenres on mg.GenreId equals g.Id
                                  where (mg.GenreId == genreId || genreId == null)
                                  orderby m.Title
                                  select new
                                  {
                                      MovieId = m.Id,
                                      m.Description,
                                      m.Cost,
                                      m.DirectorId,
                                      DirectorName = d.FirstName + " " + d.LastName,
                                      m.FormatId,
                                      FormatName = f.Description,
                                      m.ImagePath,
                                      m.Quantity,
                                      m.RatingId,
                                      RatingName = r.Description,
                                      m.Title,
                                      GenreId = g.Id
                                  }).ToList();
                    //For each movie
                    foreach (var m in movies)
                    {
                        if (this.Any(mov => mov.Id == m.MovieId))
                        {

                        }
                        else
                        {
                            //Movie not already in collection

                            //Make a new movie and set its properties
                            Movie movie = new Movie
                            {
                                Id = m.MovieId,
                                Description = m.Description,
                                Cost = m.Cost,
                                DirectorId = m.DirectorId,
                                DirectorFullName = m.DirectorName,
                                FormatId = m.FormatId,
                                FormatName = m.FormatName,
                                ImagePath = m.ImagePath,
                                Quantity = m.Quantity,
                                RatingId = m.RatingId,
                                RatingName = m.RatingName,
                                Title = m.Title,
                            };
                            movie.LoadGenres();

                            //Add it to the movie list
                            this.Add(movie);
                        }
                     
                    
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }



        }
    }
}
