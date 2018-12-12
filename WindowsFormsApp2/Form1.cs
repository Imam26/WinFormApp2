using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;
using System.Configuration;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DbProviderFactory factory = DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings["SqlClient"].ProviderName);

            DbConnectionStringBuilder strBuilder = new DbConnectionStringBuilder();
            strBuilder.ConnectionString = ConfigurationManager.ConnectionStrings["SqlClient"].ConnectionString;
            strBuilder.Add("Data source", textBox1.Text);
            strBuilder.Add("Initial Catalog", textBox2.Text);

            DbConnection cnStr = factory.CreateConnection();
            cnStr.ConnectionString = strBuilder.ConnectionString;

            cnStr.Open();

            MessageBox.Show("Подключение успешно произведено!!!");

            cnStr.Close();
        }
    }
}
