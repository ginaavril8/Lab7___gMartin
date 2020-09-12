using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab7__gMartin
{
    public partial class SearchContact : Form
    {
        public SearchContact()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Event-Handler Method - When we double-click a data cell, get the ID and use it to search for the
        ///   whole record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void dgvResults_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //Gather the information (Gathers the row clicked, then chooses the first cell's data
            string strPersons_ID = dgvResults.Rows[e.RowIndex].Cells[0].Value.ToString();

            //Display data in Pop-up
            MessageBox.Show(strPersons_ID);

            //Convert the string over to an integer
            int intPersons_ID = Convert.ToInt32(strPersons_ID);

            //Create the editor form, passing it one Persons's ID and show it
            // NOTE THAT THE ID BEING PASSED WILL CALL THE OVERLOADED VERSION
            // OF THE CONSTRUCTOR...TELL IT, IN ESSENCE THAT WE ARE PULLING UP
            // RATHER THAN ADDING DATA 
            Form1 Editor = new Form1(intPersons_ID);
            Editor.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Get Data
            PersonV2 temp = new PersonV2();
            //Perform the search we created in Persons class and store the returned dataset
            DataSet ds = temp.SearchContacts(txtFirstName.Text, txtLastName.Text);

            //Display data (dataset)
            dgvResults.DataSource = ds;                                  //point datagrid to dataset
            dgvResults.DataMember = ds.Tables["PersonV2_Temp"].ToString();     // What table in the dataset?
        }


    }
}
