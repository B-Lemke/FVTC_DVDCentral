using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BJL.DVDCentral.BL;

namespace BJL.DVDCentral.WebForm
{
    public partial class ManageGenres : System.Web.UI.Page
    {
        GenreList genres;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                genres = new GenreList();
                genres.Load();

                Reload();

                //pretend someone clicked in the ddlGenres, send it with the sender and the e from this event
                ddlGenres_SelectedIndexChanged(sender, e);

                //Load data into the session
                Session["genres"] = genres;

            }
            else
            {
                //is a PostBack, kept in session, get the objects
                genres = (GenreList)Session["genres"];
            }
        }

        private void Reload()
        {
            ddlGenres.DataSource = null;
            ddlGenres.DataSource = genres;
            ddlGenres.DataTextField = "Description";
            ddlGenres.DataValueField = "Id";
            ddlGenres.DataBind();
        }

        protected void ddlGenres_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlGenres.SelectedIndex > -1)
            {
                txtGenreDescription.Text = ddlGenres.SelectedItem.Text;
            }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                Genre genre = new Genre();

                //Set the properties
                genre.Description = txtGenreDescription.Text;

                genre.Insert();

                genres.Add(genre);

                Reload();

                //Select the newly added genre
                ddlGenres.SelectedValue = genre.Id.ToString();

                Session["genres"] = genres;
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Genre genre = genres[ddlGenres.SelectedIndex];

                genre.Description = txtGenreDescription.Text;

                genre.Update();

                genres[ddlGenres.SelectedIndex] = genre;

                Reload();

                //Select the updated program
                ddlGenres.SelectedValue = genre.Id.ToString();


                Session["genres"] = genres;

            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Genre genre = genres[ddlGenres.SelectedIndex];

                genre.Delete();

                genres.Remove(genre);

                Reload();

                ddlGenres_SelectedIndexChanged(sender, e);

                Session["genres"] = genres;

            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }
    }
}