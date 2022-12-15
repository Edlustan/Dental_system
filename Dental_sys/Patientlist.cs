using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dental_sys
{
    public partial class frmPatientlist : Form
    {
        public frmPatientlist()
        {
            InitializeComponent();
        }
        string sSQL = @"SELECT CONCAT(p_fname,' ' , p_lname) as p_name , p_pnumber, p_address, p_sex, p_balance
            FROM patientprofiling";

        private void frmPatientlist_Load(object sender, EventArgs e)
        {
            //Display the first item in the droplist
            cmbfilter.SelectedIndex = 0;
            try
            {

                DataTable dtPatientlist = clsDatabase.QueryData(sSQL);
                if (dtPatientlist.Rows.Count > 0)
                {
                    dgPatientlist.DataSource = dtPatientlist;

                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (String.IsNullOrEmpty(txtSearch.Text)) return;
            //query for search

            string query = "";
            string keySearch = cmbfilter.Text;
            query = sSQL + @"WHERE p_fname LIKE '%" + keySearch + "%'
                            OR p_lname LIKE '%500%'
                            OR p_pnumber LIKE '%500%'
                            OR p_address LIKE '%500%'
                            OR p_sex LIKE '%500%'
                            OR p_balance LIKE '%500%'";

                /*" WHERE p_fname LIKE '%" + keySearch + "%' " +
                "OR p_lname '%" + keySearch + "%' " +
                "OR p_pnumber '%" + keySearch + "%' " +
                "OR p_address '%" + keySearch + "%'" +
                "OR p_sex '%" + keySearch + "%' " +
                "OR p_balance '%" + keySearch + "%'" ;*/

        }
    }
}
