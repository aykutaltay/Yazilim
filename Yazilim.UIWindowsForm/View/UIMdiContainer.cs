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
        int Secim = 0;
        #endregion

        #region Events
        private void DataListesi_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Edit(e);
        }
        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Secim == 0)
            {
                MessageBox.Show("Lütfen Satır Seçiniz");
                return;
            }

            Delete();
            Secim = 0;

        }
        private void DataListesi_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                Secim = e.RowIndex;
            }
        }
        #endregion

        #region Methods
        private void ClickEvents(object sender, EventArgs e)
        {
            //accessible name üzerinden  sınıflandırdım tek nokta yönetimi için
            // farklı yöntemler kullanılabilir

            var accessibleName = (sender as ToolStripMenuItem).AccessibleName;
            DonusModel = accessibleName;
            Listele();
        }
        private void Edit(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            Entities.ApiResponse Response = new Entities.ApiResponse();

            var selectedRow = DataListesi.Rows[e.RowIndex];


            switch (DonusModel)
            {
                case "Product":

                    var Products = (Entities.Northwind.Products)selectedRow.DataBoundItem;
                    Response = NorthwindApiServices.PUT<Entities.Northwind.Products>(Products);
                    MessageBox.Show(Response.Content);
                    break;
                case "Category":


                    var Category = (Entities.Northwind.Category)selectedRow.DataBoundItem;

                    Response = NorthwindApiServices.PUT<Entities.Northwind.Category>(Category);
                    MessageBox.Show(Response.Content);

                    break;
                case "Customer":

                    var Customers = (Entities.Northwind.Customers)selectedRow.DataBoundItem;
                    Response = NorthwindApiServices.PUT<Entities.Northwind.Customers>(Customers);
                    MessageBox.Show(Response.Content);
                    break;

                case "Supplier":

                    var Supplier = (Entities.Northwind.Supplier)selectedRow.DataBoundItem;
                    Response = NorthwindApiServices.PUT<Entities.Northwind.Supplier>(Supplier);
                    MessageBox.Show(Response.Content);
                    break;

                default:
                    throw new ArgumentNullException("Seçim hatalı");
            }
        }
        private void Delete()
        {

            Entities.ApiResponse Response = new Entities.ApiResponse();
            var selectedRow = DataListesi.Rows[Secim];
            switch (DonusModel)
            {
                case "Product":

                    var Products = (Entities.Northwind.Products)selectedRow.DataBoundItem;
                    Response = NorthwindApiServices.Delete<Entities.Northwind.Products>(Products);
                    MessageBox.Show(Response.Content);
                    break;
                case "Category":


                    var Category = (Entities.Northwind.Category)selectedRow.DataBoundItem;

                    Response = NorthwindApiServices.Delete<Entities.Northwind.Category>(Category);
                    MessageBox.Show(Response.Content);

                    break;
                case "Customer":

                    var Customers = (Entities.Northwind.Customers)selectedRow.DataBoundItem;
                    Response = NorthwindApiServices.Delete<Entities.Northwind.Customers>(Customers);
                    MessageBox.Show(Response.Content);
                    break;

                case "Supplier":

                    var Supplier = (Entities.Northwind.Supplier)selectedRow.DataBoundItem;
                    Response = NorthwindApiServices.Delete<Entities.Northwind.Supplier>(Supplier);
                    MessageBox.Show(Response.Content);
                    break;

                default:
                    throw new ArgumentNullException("Seçim hatalı");
            }

            if (Response.IsSuccessful)
            {
                Listele();
            }
        }
        private void Listele()
        {
            DataListesi.DataSource = null;
            Entities.ApiResponse Response = new Entities.ApiResponse();

            switch (DonusModel)
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

                    var frm = new UILog();
                    frm.Show();

                    break;

                default:
                    throw new ArgumentNullException("Seçim hatalı");
            }
        }
        #endregion



    }


}
