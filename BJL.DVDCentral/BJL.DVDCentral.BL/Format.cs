using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BJL.DVDCentral.PL;

namespace BJL.DVDCentral.BL
{
    public class Format
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
                        tblFormat format = dc.tblFormats.FirstOrDefault(f => f.Id == this.Id);

                        //Make sure that a format was retrieved
                        if (format != null)
                        {
                            //Set the properties on this format
                            this.Description = format.Description;

                        }
                        else
                        {
                            throw new Exception("No format to load with this Id");
                        }
                    }
                    else
                    {
                        throw new Exception("Format Id not Valid");
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

                    tblFormat format = new tblFormat
                    {
                        Description = this.Description,
                        Id = dc.tblFormats.Any() ? dc.tblFormats.Max(f => f.Id) + 1 : 1

                    };
                    this.Id = format.Id;
                    dc.tblFormats.Add(format);

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
                        tblFormat format = dc.tblFormats.FirstOrDefault(f => f.Id == this.Id);

                        //Make sure that a format was retrieved
                        if (format != null)
                        {
                            //Update the proterties on the format
                            format.Description = this.Description;

                            //return the number of rows effected
                            return dc.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("No format to load with this Id");
                        }
                    }
                    else
                    {
                        throw new Exception("Format Id not Valid");
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
                        tblFormat format = dc.tblFormats.FirstOrDefault(f => f.Id == this.Id);

                        //Make sure that a format was retrieved
                        if (format != null)
                        {
                            //Update the proterties on the format
                            dc.tblFormats.Remove(format);

                            //return the number of rows effected
                            return dc.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("No format to load with this Id");
                        }
                    }
                    else
                    {
                        throw new Exception("Format Id not Valid");
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }

    public class FormatList : List<Format>
    {
        public void Load()
        {
            try
            {
                using (DVDEntities dc = new DVDEntities())
                {
                    //Get the genrs from the database
                    var formats = dc.tblFormats;

                    //For each format
                    foreach (tblFormat f in formats)
                    {
                        //Make a new format and set its properties
                        Format format = new Format
                        {
                            Id = f.Id,
                            Description = f.Description
                        };

                        //Add it to the format list
                        this.Add(format);
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
