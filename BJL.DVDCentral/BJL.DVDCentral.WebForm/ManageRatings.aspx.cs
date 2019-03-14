using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BJL.DVDCentral.BL;

namespace BJL.DVDCentral.WebForm
{
    public partial class ManageRatings : System.Web.UI.Page
    {
        RatingList ratings;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ratings = new RatingList();
                ratings.Load();

                Reload();

                //pretend someone clicked in the ddlRatings, send it with the sender and the e from this event
                ddlRatings_SelectedIndexChanged(sender, e);

                //Load data into the session
                Session["ratings"] = ratings;

            }
            else
            {
                //is a PostBack, kept in session, get the objects
                ratings = (RatingList)Session["ratings"];
            }
        }

        private void Reload()
        {
            ddlRatings.DataSource = null;
            ddlRatings.DataSource = ratings;
            ddlRatings.DataTextField = "Description";
            ddlRatings.DataValueField = "Id";
            ddlRatings.DataBind();
        }

        protected void ddlRatings_SelectedIndexChanged(object sender, EventArgs e)
        {
                if (ddlRatings.SelectedIndex > -1)
                {
                    txtRatingDescription.Text = ddlRatings.SelectedItem.Text;
                }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                Rating rating = new Rating();

                //Set the properties
                rating.Description = txtRatingDescription.Text;

                rating.Insert();

                ratings.Add(rating);

                Reload();

                //Select the newly added rating
                ddlRatings.SelectedValue = rating.Id.ToString();

                Session["ratings"] = ratings;
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
                Rating rating = ratings[ddlRatings.SelectedIndex];

                rating.Description = txtRatingDescription.Text;

                rating.Update();

                ratings[ddlRatings.SelectedIndex] = rating;

                Reload();

                //Select the updated program
                ddlRatings.SelectedValue = rating.Id.ToString();


                Session["ratings"] = ratings;

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
                Rating rating = ratings[ddlRatings.SelectedIndex];

                rating.Delete();

                ratings.Remove(rating);

                Reload();

                ddlRatings_SelectedIndexChanged(sender, e);

                Session["ratings"] = ratings;

            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }
    }
}