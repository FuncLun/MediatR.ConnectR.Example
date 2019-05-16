using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autofac;
//using Facilities;
//using HumanResources;
using IContainer = System.ComponentModel.IContainer;

namespace CrudForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var builder = new ContainerBuilder();

            builder.RegisterModule<HumanResources.HumanResourcesLibModule>();
            builder.RegisterModule<Facilities.FacilitiesLibModule>();

            RootContainer = builder.Build();
        }

        public Autofac.IContainer RootContainer { get; }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (var scope = RootContainer.BeginLifetimeScope())
            {
                var req = new HumanResources.EmployeeGetRequest();

                var mediator = req
            }
        }
    }
}
