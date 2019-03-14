using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BJL.DVDCentral.PL;

namespace BJL.DVDCentral.BL
{
    public class Director
    {
        //Properties
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";

        public void LoadById()
        {

            try
            {
                using (DVDEntities dc = new DVDEntities())
                {
                    //Make sure that the ID is set and valid
                    if (this.Id >= 0)
                    {
                        tblDirector director = dc.tblDirectors.FirstOrDefault(d => d.Id == this.Id);

                        //Make sure that a director was retrieved
                        if (director != null)
                        {
                            //Set the properties on this director
                            this.FirstName = director.FirstName;
                            this.LastName = director.LastName;

                        }
                        else
                        {
                            throw new Exception("No director to load with this Id");
                        }
                    }
                    else
                    {
                        throw new Exception("Director Id not Valid");
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

                    tblDirector director = new tblDirector
                    {
                        FirstName = this.FirstName,
                        LastName = this.LastName,
                        Id = dc.tblDirectors.Any() ? dc.tblDirectors.Max(d => d.Id) + 1 : 1

                    };
                    this.Id = director.Id;
                    dc.tblDirectors.Add(director);

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
                        tblDirector director = dc.tblDirectors.FirstOrDefault(d => d.Id == this.Id);

                        //Make sure that a director was retrieved
                        if (director != null)
                        {
                            //Update the proterties on the director
                            director.FirstName = this.FirstName;
                            director.LastName = this.LastName;

                            //return the number of rows effected
                            return dc.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("No director to load with this Id");
                        }
                    }
                    else
                    {
                        throw new Exception("Director Id not Valid");
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
                        tblDirector director = dc.tblDirectors.FirstOrDefault(d => d.Id == this.Id);

                        //Make sure that a director was retrieved
                        if (director != null)
                        {
                            //Update the proterties on the director
                            dc.tblDirectors.Remove(director);

                            //return the number of rows effected
                            return dc.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("No director to load with this Id");
                        }
                    }
                    else
                    {
                        throw new Exception("Director Id not Valid");
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }

    public class DirectorList : List<Director>
    {
        public void Load()
        {
            try
            {
                using (DVDEntities dc = new DVDEntities())
                {
                    //Get the genrs from the database
                    var directors = dc.tblDirectors;

                    //For each director
                    foreach (tblDirector d in directors)
                    {
                        //Make a new director and set its properties
                        Director director = new Director
                        {
                            Id = d.Id,
                            FirstName = d.FirstName,
                            LastName = d.LastName
                        };

                        //Add it to the director list
                        this.Add(director);
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
