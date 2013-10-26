using _01.CarSearchForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01.CarSearchForm
{
    public partial class CarSearch : System.Web.UI.Page
    {
        List<Producer> producers = new List<Producer>();
        List<string> engines = new List<string>();
        List<CarExtra> extras = new List<CarExtra>();

        protected void Page_Init(object sender, EventArgs e)
        {
            this.producers.Add(new Producer()
            {
                Name = "BMW",
                Models = new List<CarModel>()
                {
                    new CarModel(){ Name = "M3" },
                    new CarModel(){ Name = "M5" },
                    new CarModel(){ Name = "M6" },
                    new CarModel(){ Name = "X5" },
                }
            });

            this.producers.Add(new Producer()
            {
                Name = "Audi",
                Models = new List<CarModel>()
                {
                    new CarModel(){ Name = "A3" },
                    new CarModel(){ Name = "A4" },
                    new CarModel(){ Name = "A5" },
                    new CarModel(){ Name = "A6" },
                }
            });

            this.producers.Add(new Producer()
            {
                Name = "Mercedes",
                Models = new List<CarModel>()
                {
                    new CarModel(){ Name = "C220" },
                    new CarModel(){ Name = "E320" },
                    new CarModel(){ Name = "S65" },
                    new CarModel(){ Name = "CL65" },
                }
            });

            this.engines.Add("Gasoline");
            this.engines.Add("Diesel");

            this.extras.Add(new CarExtra() { Name = "Air Conditioner" });
            this.extras.Add(new CarExtra() { Name = "Climatronic" });
            this.extras.Add(new CarExtra() { Name = "Leather seats" });
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlProducers.DataSource = this.producers;
                ddlProducers.DataTextField = "Name";
                ddlProducers.DataValueField = "Name";
                ddlProducers.DataBind();
                ddlProducers_SelectedIndexChanged(ddlProducers, null);

                rblEngines.DataSource = this.engines;
                rblEngines.DataBind();

                cblExtras.DataSource = this.extras;
                cblExtras.DataTextField = "Name";
                cblExtras.DataValueField = "Name";
                cblExtras.DataBind();
                btnSearch.Click +=btnSearch_Click;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            var producer = ddlProducers.SelectedValue;
            var model = ddlModels.SelectedValue;
            var engine = rblEngines.SelectedValue;
            var extras = string.Empty;

            foreach (ListItem item in cblExtras.Items)
            {
                if (item.Selected)
                {
                    extras += item.Text + ", ";
                }
            }

            string result = string.Format
                ("Producer: {0}, Model: {1}, Engine: {2}, Extras: {3}", producer, model, engine, extras);
            searchResult.Text = result;
        }

        protected void ddlProducers_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedName = ddlProducers.SelectedValue;

            var selectedModels = (from producer in this.producers
                                 where producer.Name == selectedName
                                 select producer.Models).FirstOrDefault();

            ddlModels.DataSource = selectedModels;
            ddlModels.DataTextField = "Name";
            ddlModels.DataValueField = "Name";
            ddlModels.DataBind();
        }
    }
}