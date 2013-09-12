using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarsStore
{
    public partial class Store : System.Web.UI.Page
    {
        private IList<Producer> cars = new List<Producer>
        {
            new Producer()
            {
                Name = "Toyota",
                Models = {  "Yaris", "Avensis", "LandCruiser" }
            },
            new Producer()
            {
                Name = "Reno",
                Models = { "Megan", "Clio", "Laguna" }
            }
        };

        private IList<Extra> extras = new List<Extra>
        {
            new Extra("GPS"),
            new Extra("ABS"),
            new Extra("Parktronic")
        };

        private IList<string> engines = new List<string> { "diesel", "gasoline" };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                return;
            }

            FillProducers();
            FillModels(0);

            this.CheckBoxListExtras.DataSource = extras;
            this.RadioButtonsEngines.DataSource = engines;

            Page.DataBind();
        }

        public void DropDownProducers_SelectedIndexChanged(object sender, EventArgs e)
        {
            int producerID = this.DropDownProducers.SelectedIndex;
            FillModels(producerID);
        }

        public void SubmitButton_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Producer: {0}<br/>", this.DropDownProducers.SelectedItem.Text);
            sb.AppendFormat("Model: {0}<br/>", this.DropDownModels.SelectedItem.Text);

            if (this.CheckBoxListExtras.Items.Count > 0)
            {
                sb.Append("Extras: <br />");
                sb.Append("<ul>");

                for (int i = 0; i < this.CheckBoxListExtras.Items.Count; i++)
                {
                    if (this.CheckBoxListExtras.Items[i].Selected == true)
                    {
                        sb.AppendFormat("<li>{0}</li>", this.CheckBoxListExtras.Items[i].Text);
                    }
                }

                sb.Append("</ul>");
            }

            sb.AppendFormat("Engine: {0}", this.RadioButtonsEngines.SelectedItem.Text);

            this.ResultLabel.Text = sb.ToString();
        }


        private void FillProducers()
        {
            this.DropDownProducers.DataSource = cars;
            this.DropDownProducers.DataBind();
        }

        private void FillModels(int producerID)
        {
            this.DropDownModels.DataSource = cars[producerID].Models;
            this.DropDownModels.DataBind();
        }

    }
}