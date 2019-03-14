using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BJL.DVDCentral.BL;

namespace BJL.DVDCentral.WebForm
{
    public partial class ManageFormats : System.Web.UI.Page
    {
        FormatList formats;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                formats = new FormatList();
                formats.Load();

                Reload();

                //pretend someone clicked in the ddlFormats, send it with the sender and the e from this event
                ddlFormats_SelectedIndexChanged(sender, e);

                //Load data into the session
                Session["formats"] = formats;

            }
            else
            {
                //is a PostBack, kept in session, get the objects
                formats = (FormatList)Session["formats"];
            }
        }

        private void Reload()
        {
            ddlFormats.DataSource = null;
            ddlFormats.DataSource = formats;
            ddlFormats.DataTextField = "Description";
            ddlFormats.DataValueField = "Id";
            ddlFormats.DataBind();
        }

        protected void ddlFormats_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlFormats.SelectedIndex > -1)
            {
                txtFormatDescription.Text = ddlFormats.SelectedItem.Text;
            }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                Format format = new Format();

                //Set the properties
                format.Description = txtFormatDescription.Text;

                format.Insert();

                formats.Add(format);

                Reload();

                //Select the newly added format
                ddlFormats.SelectedValue = format.Id.ToString();

                Session["formats"] = formats;
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
                Format format = formats[ddlFormats.SelectedIndex];

                format.Description = txtFormatDescription.Text;

                format.Update();

                formats[ddlFormats.SelectedIndex] = format;

                Reload();

                //Select the updated program
                ddlFormats.SelectedValue = format.Id.ToString();


                Session["formats"] = formats;

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
                Format format = formats[ddlFormats.SelectedIndex];

                format.Delete();

                formats.Remove(format);

                Reload();

                ddlFormats_SelectedIndexChanged(sender, e);

                Session["formats"] = formats;

            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }
    }
}