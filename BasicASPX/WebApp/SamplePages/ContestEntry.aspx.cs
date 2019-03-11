using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.SamplePages
{
    public partial class ContestEntry : System.Web.UI.Page
    {
        public static List<ContestEntry> entryData;
        protected void Page_Load(object sender, EventArgs e)
        {
            Message.Text = "";
            if (!Page.IsPostBack)
            {
                entryData = new List<ContestEntry>();
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                //this test will fire the validation controls on the server side
               
                //if additional validation is required, do that first
                if(Terms.Checked == true)
                {
                    //user has agreed to the terms and conditions of the contest
                    //collect the data
                    //create/load a contest entry to the collection
                    //display the collection
                }
                else
                {
                    Message.Text = "Please agree to our terms of service before being entered into our contest.";
                }
            }

            EntryList.DataSource = entryData;
            EntryList.DataBind();            
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            FirstName.Text = "";
            LastName.Text = "";
            StreetAddress1.Text = "";
            StreetAddress2.Text = "";
            City.Text = "";
            Province.ClearSelection();
            PostalCode.Text = "";
            EmailAddress.Text = "";
            Terms.Checked = false;
            CheckAnswer.Text = "";
        }
    }
}