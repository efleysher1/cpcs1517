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
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void RadioButtonListChoice_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void SubmitButtonChoice_Click(object sender, EventArgs e)
        {
            MessageLabel.Text = "You pressed the submit button!";
        }
    }
}