﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.SamplePages
{
    public partial class BasicControls : System.Web.UI.Page
    {
        //create a static list<t> that will hang around between 
        //  postings of the web page
        //this could also have been done using a ViewState variable
        //using a viewState variable would require the user to
        //  retrieve the data on each posting
        public static List<DDLClass> DataCollection;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Page_Load executes EACH AND EVERY time there is a posting
            //  to this page
            //Page_Load is executed before any submit events

            //this method is an excellent place to do form initialization
            //you can test your postings using Page.IsPostBack
            //IsPostBack is the same item as IsPost in our Razor forms

            if (!Page.IsPostBack)
            {
                //this code will be executed only on the first pass 
                //  to this page

                //create an instance for the static data collection
                DataCollection = new List<DDLClass>();

                //Add instances to this collection using the DDLClass
                //  greedy constructor
                DataCollection.Add(new DDLClass(1, "COMP1008"));
                DataCollection.Add(new DDLClass(2, "CPSC1517"));
                DataCollection.Add(new DDLClass(3, "DMIT2018"));
                DataCollection.Add(new DDLClass(4, "DMIT1508"));

                //sorting a list<t>
                //use the .Sort() method
                //(x,y) this represents any two items in your list
                //compare x.Field to y.Field, ascending order
                //compare y.Field to x.Field, descending order
                DataCollection.Sort((x,y) => x.DisplayField.CompareTo(y.DisplayField));

                //put the data collection into the drop down list
                //a) assign the collection to the controls dataSource
                CollectionList.DataSource = DataCollection;

                //b) assign the field names to the properties of the
                //  drop down list for data association
                //DataValueField represents the value of the item
                //DataTextField represents the display of the line item
                CollectionList.DataValueField = "ValueField";
                CollectionList.DataTextField = nameof(DDLClass.DisplayField);

                //c) bind the data to the web control
                CollectionList.DataBind();

                //can one put a prompt on the drop down list control?
                //  short answer: yes
                CollectionList.Items.Insert(0,"select...");
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void RadioButtonListChoice_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void SubmitButtonChoice_Click(object sender, EventArgs e)
        {
            //in order to grab the contents of a control,
            //  the access technique will determine the method
            //for a TextBox, Label, Literal use .Text
            //for Lists(RadioButtonList, DropDownList) you can use
            //  a) .SelectedValue -> associated data value field
            //  b) .SelectedIndex -> the physical index location in the list
            //  c) .SelectedItem -> associated display field value
            //for a CheckBox, use .Checked (true or false)

            //for the most part, all data from a control returns as
            //  a string except for boolean type controls

            string submitchoice = TextBoxNumberChoice.Text;
            int anum = 0;
            if (string.IsNullOrEmpty(submitchoice))
            {
                MessageLabel.Text = "Enter a number from 1 to 4.";
            }
            else if (!int.TryParse(submitchoice, out anum))
            {
                MessageLabel.Text = "Entered value must be a number";
            }
            else if(anum > 4 || anum < 1)
            {
                MessageLabel.Text = "Enter a number from 1 to 4.";
            }
            else
            {
                //when positioning in a list, it is BEST to position
                //  using the .SelectedValue unless you wish to
                //  position in a specific physical location such as
                //  your prompt line. in that case, use .SelectedIndex

                //SelectedValue expects a string value
                //SelectedIndex expects a numerical value
                RadioButtonListChoice.SelectedValue = submitchoice;

                //boolean controls are set using true or false
                if (submitchoice.Equals("2") || submitchoice.Equals("3"))
                {
                    CheckBoxChoice.Checked = true;
                }
                else
                {
                    CheckBoxChoice.Checked = false;
                }

                CollectionList.SelectedValue = submitchoice;

                //display label will show the various values 
                //  obtained from a list using .SelectedValue, .SelectedIndex,
                //  and .SelectedItem

                DisplayReadOnly.Text = CollectionList.SelectedItem.Text + " at index " + CollectionList.SelectedIndex + 
                    " has a value of " + CollectionList.SelectedValue;
            }
        }

        protected void InputButtonChoice_Click(object sender, EventArgs e)
        {
            //string submitchoice = CollectionList;
            //ensure that the user has seleted a course
            //if(CollectionList.SelectedIndex ==0){messagelabel.text = "select a course"}
            //else{RadioButtonListChoice.SelectedValue = submitchoice;
            //}

            /* if (submitchoice.Equals("2") || submitchoice.Equals("3"))
                        {
                            CheckBoxChoice.Checked = true;
                        }
                        else
                        {
                            CheckBoxChoice.Checked = false;
                        }*/

            //DisplayReadOnly.Text = CollectionList.SelectedItem.Text + " at index " + CollectionList.SelectedIndex + 
            //                  " has a value of " + CollectionList.SelectedValue;

        }
    }
}

