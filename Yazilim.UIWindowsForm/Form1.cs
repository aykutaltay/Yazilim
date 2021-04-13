using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Yazilim.Core;
using Yazilim.Core.WebApi;
using Yazilim.Entities;
using Yazilim.Entities.Northwind;

namespace Yazilim.UIWindowsForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        #region variable

        #endregion

        #region Events
        private void Form1_Load(object sender, EventArgs e)
        {




        }



        #endregion

        #region Methods

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {



            categories mdl = new categories
            {
                id = 2,
                description = "Sweet and savory sauces relishes spreads and seasonings",
                name = "Condiments"


            };


            NorthwindApiServices.Delete<categories>(mdl);

        }


    }
}
