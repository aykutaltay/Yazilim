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
namespace Yazilim.Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DbLogger.LogDb("aaa", "aa", "aaa", Core.Enums.eLogType.DELETE);
            using (var db=new Core.DbTools.Repository(eConnectionType.LogSqliteConnection))
            {

             dataGridView1.DataSource=db.GetAll<Entities.Log.Logs>();

            }

        }
    }
}
