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
        Iconnection conn = null;

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn = clMySql.getInstance();
            MessageBox.Show(conn.getConnection().ConnectionString);
            try
            {
                conn.Open();
                MessageBox.Show("Conectado com sucesso");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao connectar");
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn = clMsSql.getInstance();
            MessageBox.Show(conn.getConnection().ConnectionString);
            try
            {
                conn.Open();
                MessageBox.Show("Conectado com sucesso");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao connectar");
            }
        }
    }
}
