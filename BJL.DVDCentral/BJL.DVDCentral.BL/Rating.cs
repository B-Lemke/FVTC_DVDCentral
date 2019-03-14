using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BJL.DVDCentral.PL;

namespace BJL.DVDCentral.BL
{
    public class Rating
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
                        tblRating rating = dc.tblRatings.FirstOrDefault(r => r.Id == this.Id);

                        //Make sure that a rating was retrieved
                        if (rating != null)
                        {
                            //Set the properties on this rating
                            this.Description = rating.Description;

                        }
                        else
                        {
                            throw new Exception("No rating to load with this Id");
                        }
                    }
                    else
                    {
                        throw new Exception("Rating Id not Valid");
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

                    tblRating rating = new tblRating
                    {
                        Description = this.Description,
                        Id = dc.tblRatings.Any() ? dc.tblRatings.Max(r => r.Id) + 1 : 1

                    };
                    this.Id = rating.Id;
                    dc.tblRatings.Add(rating);

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
                        tblRating rating = dc.tblRatings.FirstOrDefault(r => r.Id == this.Id);

                        //Make sure that a rating was retrieved
                        if (rating != null)
                        {
                            //Update the proterties on the rating
                            rating.Description = this.Description;

                            //return the number of rows effected
                            return dc.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("No rating to load with this Id");
                        }
                    }
                    else
                    {
                        throw new Exception("Rating Id not Valid");
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
                        tblRating rating = dc.tblRatings.FirstOrDefault(r => r.Id == this.Id);

                        //Make sure that a rating was retrieved
                        if (rating != null)
                        {
                            //Update the proterties on the rating
                            dc.tblRatings.Remove(rating);

                            //return the number of rows effected
                            return dc.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("No rating to load with this Id");
                        }
                    }
                    else
                    {
                        throw new Exception("Rating Id not Valid");
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }

    public class RatingList : List<Rating>
    {
        public void Load()
        {
            try
            {
                using (DVDEntities dc = new DVDEntities())
                {
                    //Get the genrs from the database
                    var ratings = dc.tblRatings;

                    //For each rating
                    foreach (tblRating r in ratings)
                    {
                        //Make a new rating and set its properties
                        Rating rating = new Rating
                        {
                            Id = r.Id,
                            Description = r.Description
                        };

                        //Add it to the rating list
                        this.Add(rating);
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
