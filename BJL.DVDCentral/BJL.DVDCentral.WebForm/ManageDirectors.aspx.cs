using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BJL.DVDCentral.BL;

namespace BJL.DVDCentral.WebForm
{
    public partial class ManageDirectors : System.Web.UI.Page
    {
        DirectorList directors;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                directors = new DirectorList();
                directors.Load();

                Reload();

                //pretend someone clicked in the ddlDirectors, send it with the sender and the e from this event
                ddlDirectors_SelectedIndexChanged(sender, e);

                //Load data into the session
                Session["directors"] = directors;

            }
            else
            {
                //is a PostBack, kept in session, get the objects
                directors = (DirectorList)Session["directors"];
            }
        }

        private void Reload()
        {
            ddlDirectors.DataSource = null;
            ddlDirectors.DataSource = directors;
            ddlDirectors.DataTextField = "FullName";
            ddlDirectors.DataValueField = "Id";
            ddlDirectors.DataBind();
        }

        protected void ddlDirectors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDirectors.SelectedIndex > -1)
            {
                txtFirstName.Text = directors[ddlDirectors.SelectedIndex].FirstName;
                txtLastName.Text = directors[ddlDirectors.SelectedIndex].LastName;
            }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                Director director = new Director();

                //Set the properties
                director.FirstName = txtFirstName.Text;
                director.LastName = txtLastName.Text;

                director.Insert();

                directors.Add(director);

                Reload();

                //Select the newly added director
                ddlDirectors.SelectedValue = director.Id.ToString();

                Session["directors"] = directors;
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
                Director director = directors[ddlDirectors.SelectedIndex];

                director.FirstName = txtFirstName.Text;
                director.LastName = txtLastName.Text;

                director.Update();

                directors[ddlDirectors.SelectedIndex] = director;

                Reload();

                //Select the updated program
                ddlDirectors.SelectedValue = director.Id.ToString();


                Session["directors"] = directors;

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
                Director director = directors[ddlDirectors.SelectedIndex];

                director.Delete();

                directors.Remove(director);

                Reload();

                ddlDirectors_SelectedIndexChanged(sender, e);

                Session["directors"] = directors;

            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }
    }
}