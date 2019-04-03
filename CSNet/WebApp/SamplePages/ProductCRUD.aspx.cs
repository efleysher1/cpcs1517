using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additional Namespaces
using NorthwindSystem.Data;
using NorthwindSystem.BLL;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core;
#endregion

namespace WebApp.NorthwindPages
{
    public partial class ProductCRUD : System.Web.UI.Page
    {
        List<string> errormsgs = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            //clear all old messages from the DataList control
            Message.DataSource = null;
            Message.DataBind();


            //page initialization
            if (!Page.IsPostBack)
            {
                BindProductList();
                BindSupplierList();
                BindCategoryList();
            }
        }

        //use this method to discover the inner most error message.
        //this rotuing has been created by the user
        protected Exception GetInnerException(Exception ex)
        {
            //drill down to the inner most exception
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            return ex;
        }

        //use this method to load a DataList with a variable
        //number of message lines.
        //each line is a string
        //the strings (lines) are passed to this routine in
        //   a List<string>
        //second parameter is the bootstrap cssclass
        protected void LoadMessageDisplay(List<string> errormsglist, string cssclass)
        {
            Message.CssClass = cssclass;
            Message.DataSource = errormsglist;
            Message.DataBind();
        }

        protected void BindProductList()
        {
            try
            {
                ProductController sysmgr = new ProductController();
                List<Product> datainfo = sysmgr.Product_List();
                datainfo.Sort((x, y) => x.ProductName.CompareTo(y.ProductName));
                ProductList.DataSource = datainfo;
                ProductList.DataTextField = nameof(Product.ProductName);
                ProductList.DataValueField = nameof(Product.ProductID);
                ProductList.DataBind();
                ProductList.Items.Insert(0, "select . . .");
            }
            catch (Exception ex)
            {
                errormsgs.Add(GetInnerException(ex).ToString());
                LoadMessageDisplay(errormsgs, "alert alert-danger");
            }
        }

        protected void BindSupplierList()
        {
            try
            {
                SupplierController sysmgr = new SupplierController();
                List<Supplier> datainfo = sysmgr.Supplier_List();
                datainfo.Sort((x, y) => x.CompanyName.CompareTo(y.CompanyName));
                SupplierList.DataSource = datainfo;
                SupplierList.DataTextField = nameof(Product.ProductName);
                SupplierList.DataValueField = nameof(Product.ProductID);
                SupplierList.DataBind();
                SupplierList.Items.Insert(0, "select . . .");
            }
            catch(Exception ex)
            {
                errormsgs.Add(GetInnerException(ex).ToString());
                LoadMessageDisplay(errormsgs, "alert alert-danger");
            }
        }

        protected void BindCategoryList()
        {
            try
            {
                CategoryController sysmgr = new CategoryController();
                List<Category> datainfo = sysmgr.Category_List();
                datainfo.Sort((x, y) => x.CategoryName.CompareTo(y.CategoryName));
                CategoryList.DataSource = datainfo;
                CategoryList.DataTextField = nameof(Product.ProductName);
                CategoryList.DataValueField = nameof(Product.ProductID);
                CategoryList.DataBind();
                CategoryList.Items.Insert(0, "select . . .");
            }
            catch (Exception ex)
            {
                errormsgs.Add(GetInnerException(ex).ToString());
                LoadMessageDisplay(errormsgs, "alert alert-danger");
            }
        }

        protected void AddProduct_Click(object sender, EventArgs e)
        {
            //if (Page.IsValid) { 
            //this is the part where you add any additional logic validation required
            //  for processing
            //in this example, we're going to assume that the supplier id and category id are required
            if(SupplierList.SelectedIndex == 0)
            {
                errormsgs.Add("Please select a supplier");
               

            }
            if (CategoryList.SelectedIndex == 0)
            {
                errormsgs.Add("Please select a category");
            }

            //all code behind logical validation errors
            //  are captured and reported at once
            if (errormsgs.Count() > 0)
            {
                LoadMessageDisplay(errormsgs, "alert alert-info");
            }
            else
            {
                try
                {
                    //create an instance of Product
                    Product item = new Product();
                    //collect the data from the web form and place
                    //  in the Product instance
                    item.ProductName = ProductName.Text;
                    item.SupplierID = int.Parse(SupplierList.SelectedValue);
                    item.CategoryID = int.Parse(CategoryList.SelectedValue);
                    if (string.IsNullOrEmpty(UnitPrice.Text))
                    {
                        item.UnitPrice = null;
                    }
                    else
                    {
                        item.UnitPrice = decimal.Parse(UnitPrice.Text);
                    }

                    if (string.IsNullOrEmpty(UnitsInStock.Text))
                    {
                        item.UnitsInStock = null;
                    }
                    else
                    {
                        item.UnitsInStock = Int16.Parse(UnitsInStock.Text);
                    }

                    if (string.IsNullOrEmpty(UnitsOnOrder.Text))
                    {
                        item.UnitsOnOrder = null;
                    }
                    else
                    {
                        item.UnitsOnOrder = Int16.Parse(UnitsOnOrder.Text);
                    }

                    if (string.IsNullOrEmpty(ReorderLevel.Text))
                    {
                        item.ReorderLevel = null;
                    }
                    else
                    {
                        item.ReorderLevel = Int16.Parse(ReorderLevel.Text);
                    }
                    //handling the discontinued can be done manually 
                    //  or logically
                    item.Discontinued = false;
                    //connect to the appropriate BLL controller
                    ProductController sysmgr = new ProductController();
                    //issue a call to the appropriate BLL controller method
                    int newProductID = sysmgr.Product_Add(item);
                    //Handle the results
                    errormsgs.Add(ProductName.Text + " has been added to the database with a key of " + newProductID.ToString());
                    LoadMessageDisplay(errormsgs, "alert alert-success");

                    //also if any control on this form uses this new instance,
                    //  for a query, or other action, you must update the (refresh)
                    //  that control
                    BindProductList();
                    ProductID.Text = newProductID.ToString();
                    ProductList.SelectedValue = ProductID.Text;

                }
                catch (DbUpdateException ex)
                {
                    UpdateException updateException = (UpdateException)ex.InnerException;
                    if (updateException.InnerException != null)
                    {
                        errormsgs.Add(updateException.InnerException.Message.ToString());
                    }
                    else
                    {
                        errormsgs.Add(updateException.Message);
                    }
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var entityValidationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationErrors.ValidationErrors)
                        {
                            errormsgs.Add(validationError.ErrorMessage);
                        }
                    }
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
                catch (Exception ex)
                {
                    errormsgs.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }

            }
            //}
        }

        protected void UpdateProduct_Click(object sender, EventArgs e)
        {
            //if (Page.IsValid) { 
            //this is the part where you add any additional logic validation required
            //  for processing
            //in this example, we're going to assume that the supplier id and category id are required
            if (SupplierList.SelectedIndex == 0)
            {
                errormsgs.Add("Please select a supplier");


            }
            if (CategoryList.SelectedIndex == 0)
            {
                errormsgs.Add("Please select a category");
            }

            //on an update, you MUST ENSURE that the primary key value
            //  exists for use by the update
            int ProductID = 0;
            if(!int.TryParse(ProductID.Text.Trim(), out productid))
            {
                errormsgs.Add("Invalid or missing Product ID");
            }

            //all code behind logical validation errors
            //  are captured and reported at once
            if (errormsgs.Count() > 0)
            {
                LoadMessageDisplay(errormsgs, "alert alert-info");
            }
            else
            {
                try
                {
                    //create an instance of Product
                    Product item = new Product();
                    //collect the data from the web form and place
                    //  in the Product instance

                    //on the update, the primary identity key value
                    //  MUST ALSO be loaded to the instance
                    item.ProductID = int.Parse(ProductID.Text.Trim());
                    item.ProductName = ProductName.Text;
                    item.SupplierID = int.Parse(SupplierList.SelectedValue);
                    item.CategoryID = int.Parse(CategoryList.SelectedValue);
                    if (string.IsNullOrEmpty(UnitPrice.Text))
                    {
                        item.UnitPrice = null;
                    }
                    else
                    {
                        item.UnitPrice = decimal.Parse(UnitPrice.Text);
                    }

                    if (string.IsNullOrEmpty(UnitsInStock.Text))
                    {
                        item.UnitsInStock = null;
                    }
                    else
                    {
                        item.UnitsInStock = Int16.Parse(UnitsInStock.Text);
                    }

                    if (string.IsNullOrEmpty(UnitsOnOrder.Text))
                    {
                        item.UnitsOnOrder = null;
                    }
                    else
                    {
                        item.UnitsOnOrder = Int16.Parse(UnitsOnOrder.Text);
                    }

                    if (string.IsNullOrEmpty(ReorderLevel.Text))
                    {
                        item.ReorderLevel = null;
                    }
                    else
                    {
                        item.ReorderLevel = Int16.Parse(ReorderLevel.Text);
                    }
                    //handling the discontinued needs to take the current value
                    //  from the form
                    item.Discontinued = Discontinued.Checked;
                    //connect to the appropriate BLL controller
                    ProductController sysmgr = new ProductController();
                    //issue a call to the appropriate BLL controller method
                    int rowsaffected = sysmgr.Product_Update(item);
                    //Handle the results
                    if (rowsaffected == 0)
                    {
                        errormsgs.Add(ProductName.Text + " has not been updated. Search for product again.");
                        LoadMessageDisplay(errormsgs, "alert alert-warning");
                        BindProductList();
                    }
                    else
                    {


                        errormsgs.Add(ProductName.Text + " has been updated");
                        LoadMessageDisplay(errormsgs, "alert alert-success");
                        BindProductList();
                        ProductList.SelectedValue = ProductID.Text;

                    }
                    //also if any control on this form uses this new instance,
                    //  for a query, or other action, you must update the (refresh)
                    //  that control

                }
                catch (DbUpdateException ex)
                {
                    UpdateException updateException = (UpdateException)ex.InnerException;
                    if (updateException.InnerException != null)
                    {
                        errormsgs.Add(updateException.InnerException.Message.ToString());
                    }
                    else
                    {
                        errormsgs.Add(updateException.Message);
                    }
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var entityValidationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationErrors.ValidationErrors)
                        {
                            errormsgs.Add(validationError.ErrorMessage);
                        }
                    }
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
                catch (Exception ex)
                {
                    errormsgs.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }

            }
            //}
        }

        protected void RemoveProduct_Click(object sender, EventArgs e)
        {
            //on an update, you MUST ENSURE that the primary key value
            //  exists for use by the update
            int ProductID = 0;
            if (!int.TryParse(ProductID.Text.Trim(), out productid))
            {
                errormsgs.Add("Invalid or missing Product ID");
            }

            //all code behind logical validation errors
            //  are captured and reported at once
            if (errormsgs.Count() > 0)
            {
                LoadMessageDisplay(errormsgs, "alert alert-info");
            }
            else
            {
                try
                {
                   
                    //connect to the appropriate BLL controller
                    ProductController sysmgr = new ProductController();
                    //issue a call to the appropriate BLL controller method
                    int rowsaffected = sysmgr.Product_Delete(int.Parse(ProductID.Text.Trim()));
                    //Handle the results
                    if (rowsaffected == 0)
                    {
                        errormsgs.Add(ProductName.Text + " has not been discontinued. Search for product again.");
                        LoadMessageDisplay(errormsgs, "alert alert-warning");
                        BindProductList();
                        
                    }
                    else
                    {
                        errormsgs.Add(ProductName.Text + " has been discontinued");
                        LoadMessageDisplay(errormsgs, "alert alert-success");
                        BindProductList();
                        //ONLY if this is a LOGICAL DELETE
                        ProductList.SelectedValue = ProductID.Text;
                        Discontinued.Checked = true;
                    }
                    //also if any control on this form uses this new instance,
                    //  for a query, or other action, you must update the (refresh)
                    //  that control

                }
                catch (DbUpdateException ex)
                {
                    UpdateException updateException = (UpdateException)ex.InnerException;
                    if (updateException.InnerException != null)
                    {
                        errormsgs.Add(updateException.InnerException.Message.ToString());
                    }
                    else
                    {
                        errormsgs.Add(updateException.Message);
                    }
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var entityValidationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationErrors.ValidationErrors)
                        {
                            errormsgs.Add(validationError.ErrorMessage);
                        }
                    }
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
                catch (Exception ex)
                {
                    errormsgs.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }

            }
        }
    }
}