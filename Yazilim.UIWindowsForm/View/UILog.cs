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
using Yazilim.Core;


namespace Yazilim.UIWindowsForm.View
{
    public partial class UILog : Form
    {
        public UILog()
        {
            InitializeComponent();
        }


        #region Variable

        #endregion

        #region Events
        private void UILog_Load(object sender, EventArgs e)
        {
            LogListele();
        }

        private void LogMasterLst_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LogDetay();
        }
        #endregion

        #region Methods
        private void LogListele()
        {
            using (var db = new Core.DbTools.Repository(eConnectionType.LogSqliteConnection))
            {
                LogMasterLst.DataSource = db.GetAll<Entities.Log.Logs>().ToList();
            }
        }

        private void LogDetay()
        {
            LogDetailLst.Visible = true;
            string Deger = "";

            try
            {


                if (LogMasterLst.SelectedCells.Count > 0)
                {
                    //master detail olarak oluştrulması gerekmektedir.
                    int selectedrowindex = LogMasterLst.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = LogMasterLst.Rows[selectedrowindex];
                    Deger = Convert.ToString(selectedRow.Cells["LogObject"].Value);
                    LogDetailLst.DataSource = null;
                    LogDetailLst.DataSource = JsonConvert.DeserializeObject<DataTable>(Deger);
                    LogDetailLst.Visible = true;
                    DetayText.Visible = false;


                }
            }
            catch
            {
                LogDetailLst.Visible = false;
                DetayText.Text = Deger;
                DetayText.Visible = true;
            }
        }

        #endregion


    }
}
