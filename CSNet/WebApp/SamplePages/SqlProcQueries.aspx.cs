
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


#region Additional Namespaces
using NorthwindSystem.BLL;
using NorthwindSystem.Data;
#endregion

namespace WebApp.SamplePages
{
    public partial class SqlProcQueries : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //clear old messages
            MessageLabel.Text = "";

            //load the dropdownlist on the first time processing this page
            if (!Page.IsPostBack)
            {

            
                //all calls should be done in user friendly error handling
                try
                {

                    //when the page is first loaded, obtain the 
                    //  complete list of categories from the 
                    //  database
                    CategoryController sysmgr = new CategoryController();
                    List<Category> results = sysmgr.Category_List();

                    //sort this list alphabetically
                    results.Sort((x, y) => x.CategoryName.CompareTo(y.CategoryName));

                    //assign the data to the dropdownlist control
                    CategoryList.DataSource = results;

                    //indicate the DataTextField and DataValueField
                    CategoryList.DataTextField = nameof(Category.CategoryName);
                    CategoryList.DataValueField = nameof(Category.CategoryID);
                    //bind the dataSource
                    CategoryList.DataBind();
                    //add a prompt
                    CategoryList.Items.Insert(0, "select . . . ");


                }
                catch (Exception ex)
                {
                    MessageLabel.Text = ex.Message;
                }
            }
        }

       
    }
}