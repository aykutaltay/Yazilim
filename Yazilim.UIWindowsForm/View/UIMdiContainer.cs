using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Yazilim.Core.WebApi;

namespace Yazilim.UIWindowsForm.View
{
    /// <summary>
    /// Yapılsal olarak mimarinin çalışıp çalışmadığı önemli UI Kısımlarına zaman ayarlanabilir
    /// biraz kod kalabalığı olabilir normalde bunun önüne geçilebilir
    /// dev expres üzerinde getfocusedDatarow gibi pratik olduğundan dolayı burada biraz modele çevirmem
    /// gerekecek
    /// MdiContainer olarak yapacaktım fakat  formlar daha fazla olacaktı o yüzden vaz geçtim
    /// </summary>
    public partial class UIMdiContainer : Form
    {
        public UIMdiContainer()
        {
            InitializeComponent();
        }

        #region Variable
        string DonusModel = "";


        #endregion



        #region Events

        #endregion

        #region Methods

        private void ClickEvents(object sender, EventArgs e)
        {
            //accessible name üzerinden  sınıflandırdım tek nokta yönetimi için
            // farklı yöntemler kullanılabilir

            var accessibleName = (sender as ToolStripMenuItem).AccessibleName;
            DonusModel = accessibleName;


            DataListesi.DataSource = null;


            Entities.ApiResponse Response = new Entities.ApiResponse();

            switch (accessibleName)
            {
                case "Product":

                    Response = NorthwindApiServices.WebApList<Entities.Northwind.Products>();
                    if (Response.IsSuccessful)
                    {
                        DataListesi.DataSource = JsonConvert.DeserializeObject<Entities.Northwind.Products[]>(Response.Content).ToList();
                    }
                    else MessageBox.Show(Response.Content);


                    break;
                case "Category":

                    Response = NorthwindApiServices.WebApList<Entities.Northwind.Category>();
                    if (Response.IsSuccessful)
                    {
                        DataListesi.DataSource = JsonConvert.DeserializeObject<Entities.Northwind.Category[]>(Response.Content).ToList();
                    }
                    else MessageBox.Show(Response.Content);

                    break;
                case "Customer":

                    Response = NorthwindApiServices.WebApList<Entities.Northwind.Customers>();
                    if (Response.IsSuccessful)
                    {
                        DataListesi.DataSource = JsonConvert.DeserializeObject<Entities.Northwind.Customers[]>(Response.Content).ToList();
                    }
                    else MessageBox.Show(Response.Content);
                    break;

                case "Supplier":
                    Response = NorthwindApiServices.WebApList<Entities.Northwind.Supplier>();
                    if (Response.IsSuccessful)
                    {
                        DataListesi.DataSource = JsonConvert.DeserializeObject<Entities.Northwind.Supplier[]>(Response.Content).ToList();
                    }
                    else MessageBox.Show(Response.Content);
                    break;

                case "Loglistesi":


                    break;

                default:
                    throw new ArgumentNullException("Seçim hatalı");
            }



        }

        #endregion


    }


}
