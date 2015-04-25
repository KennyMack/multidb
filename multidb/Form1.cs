using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace multidb
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                var cmd = clCommand.Command(DBName.MsSql, "Select * from tbperson");
                var dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                dgvmssql.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao connectar");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            try
            {
                var cmd = clCommand.Command(DBName.MySql, "Select * from tbperson");
                var dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                dgvmysql.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao connectar");
            }
        }

        private void dgvmysql_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
