using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BJL.DVDCentral.PL;

namespace BJL.DVDCentral.BL
{
    public class Genre
    {
        //Properties
        public int Id { get; set; }
        public string Description { get; set; }

        public void LoadById()
        {

            try
            {
                using (DVDEntities dc = new DVDEntities())
                {
                    //Make sure that the ID is set and valid
                    if (this.Id >= 0)
                    {
                        tblGenre genre = dc.tblGenres.FirstOrDefault(g => g.Id == this.Id);

                        //Make sure that a genre was retrieved
                        if (genre != null)
                        {
                            //Set the properties on this genre
                            this.Description = genre.Description;

                        }
                        else
                        {
                            throw new Exception("No genre to load with this Id");
                        }
                    }
                    else
                    {
                        throw new Exception("Genre Id not Valid");
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

                    tblGenre genre = new tblGenre
                    {
                        Description = this.Description,
                        Id = dc.tblGenres.Any() ? dc.tblGenres.Max(g => g.Id) + 1 : 1

                    };

                    dc.tblGenres.Add(genre);

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
                        tblGenre genre = dc.tblGenres.FirstOrDefault(g => g.Id == this.Id);

                        //Make sure that a genre was retrieved
                        if (genre != null)
                        {
                            //Update the proterties on the genre
                            genre.Description = this.Description;

                            //return the number of rows effected
                            return dc.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("No genre to load with this Id");
                        }
                    }
                    else
                    {
                        throw new Exception("Genre Id not Valid");
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
                        tblGenre genre = dc.tblGenres.FirstOrDefault(g => g.Id == this.Id);

                        //Make sure that a genre was retrieved
                        if (genre != null)
                        {
                            //Update the proterties on the genre
                            dc.tblGenres.Remove(genre);

                            //return the number of rows effected
                            return dc.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("No genre to load with this Id");
                        }
                    }
                    else
                    {
                        throw new Exception("Genre Id not Valid");
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }

    public class GenreList : List<Genre>
    {
        public void Load()
        {
            try
            {
                using (DVDEntities dc = new DVDEntities())
                {
                    //Get the genrs from the database
                    var genres = dc.tblGenres;

                    //For each genre
                    foreach (tblGenre g in genres)
                    {
                        //Make a new genre and set its properties
                        Genre genre = new Genre
                        {
                            Id = g.Id,
                            Description = g.Description
                        };

                        //Add it to the genre list
                        this.Add(genre);
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
