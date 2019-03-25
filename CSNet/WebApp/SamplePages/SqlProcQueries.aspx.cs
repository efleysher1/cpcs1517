
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

        protected void Submit_Click(object sender, EventArgs e)
        {
            //ensure a selection was made
            if (CategoryList.SelectedIndex == 0)
            {
                MessageLabel.Text = "Select a category of products to view!";
            }
            else
            {
                //within user friendly error handling
                try
                {
                    //  connect to the appropriate controller
                    ProductController sysmgr = new ProductController();
                    //  issue a request to the controller's appropriate method
                    List<Product> datainfo = sysmgr.Product_GetByCategory(int.Parse(CategoryList.SelectedValue));
                    //  check results 
                    if (datainfo.Count() == 0)
                    {

                        //  none: (.count() == 0): message to user 
                        MessageLabel.Text = "No products for the selected category were found.";
                        //optionally clear out display
                        CategoryList.ClearSelection();
                        CategoryProductList.DataSource = null;
                    }
                    else
                    {
                        //  found: load a gridview
                        datainfo.Sort((x, y) => x.ProductName.CompareTo (y.CategoryID) );
                        CategoryProductList.DataSource = datainfo;
                        CategoryProductList.DataBind();
                    }

                }
                catch (Exception ex)
                {
                    MessageLabel.Text = ex.Message;
                }
               
            }
            
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            CategoryList.ClearSelection();
            CategoryProductList.DataSource = null;
            CategoryProductList.DataBind();
        }

        protected void CategoryProductList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //the e parameter will suppy the new page index that is requested
            //you must set the grid control page index to this supplied value
            CategoryProductList.PageIndex = e.NewPageIndex;

            //you must refresh your grid view with a call
            // to the database
            ProductController sysmgr = new ProductController();
            
            List<Product> datainfo = sysmgr.Product_GetByCategory(int.Parse(CategoryList.SelectedValue));

            try
            {
                //  connect to the appropriate controller
                ProductController symgr = new ProductController();
                //  issue a request to the controller's appropriate method
                List<Product> datinfo = symgr.Product_GetByCategory(int.Parse(CategoryList.SelectedValue));
                //  check results 
                if (datainfo.Count() == 0)
                {

                    //  none: (.count() == 0): message to user 
                    MessageLabel.Text = "No products for the selected category were found.";
                    //optionally clear out display
                    CategoryList.ClearSelection();
                    CategoryProductList.DataSource = null;
                }
                else
                {
                    //  found: load a gridview
                    datainfo.Sort((x, y) => x.ProductName.CompareTo(y.CategoryID));
                    CategoryProductList.DataSource = datainfo;
                    CategoryProductList.DataBind();
                }

            }
            catch (Exception ex)
            {
                MessageLabel.Text = ex.Message;
            }

        }

        protected void CategoryProductList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this event belongs to the Command Select button
            //accessing the data is wholly dependent on the type of data display used 
            //  used in the gridview cell.
            //there are four different ways to access your data 
            //  (because there are four ways to set up your gridview cell)
            //we have used the generic template technique to create 
            //  our gridview cell contents
            //templates allow the developer to place web controls
            //  within each cell
            //when you access a web control within the gridview cell
            //  you WILL reference the control type and then use
            //  the control type access technique

            string productid;
            string discontinued;
            string productname;

            //personal style:
            GridViewRow agvrow = CategoryProductList.Rows[CategoryProductList.SelectedIndex];

            //grab ProductID
            //syntax
            // agvrow: this points to the selected gridview row
            //FindControl("controlidname"): this is the id value on the gridview cell
            //as controltype: this indicates the type of web control
            //  within the gridview cell that you are accessing
            // (xxxxxx).Text : indicates the web control access technique
            productid = (agvrow.FindControl("ProductID") as Label).Text;
            productname = (agvrow.FindControl("ProductName") as Label).Text;
            if ((agvrow.FindControl("Discontinued") as CheckBox).Checked)
            {
                discontinued = "discontinued";
            }
            else
            {
                discontinued = "available";
            }

            MessageLabel.Text = productname + " ( " + productid + " ) " + "is " + discontinued;
        }
    }
}
