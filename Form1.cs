using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Lab7__gMartin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        /// <summary>
        /// NEW - Constructor that Receives an Persons ID....this means we need to look up the data and populate fields (View/Edit/Del)
        /// </summary>
        /// <param name="intPersons_ID"></param>
        public Form1(Int32 intPersons_ID)
        {
            InitializeComponent();  //Creates and init's all form objects

            //Gather info about this one person and store it in a datareader
            PersonV2 temp = new PersonV2();
            SqlDataReader dr = temp.FindAContact(intPersons_ID);
            //OleDbDataReader dr = temp.FindAContact(intPersons_ID);


            //Use that info to fill out the form
            //Loop thru the records stored in the reader 1 record at a time
            // Note that since this is based on one person's ID, then we
            //  should only have one record
            while (dr.Read())
            {
                //Take the Name(s) from the datareader and copy them
                // into the appropriate text fields
                txtFirstName.Text = dr["FirstName"].ToString();
                txtMiddleName.Text = dr["MiddleName"].ToString();
                txtLastName.Text = dr["LastName"].ToString();
                txtAddressOne.Text = dr["AddressOne"].ToString();
                txtAddressTwo.Text = dr["AddressTwo"].ToString();
                txtCity.Text = dr["City"].ToString();
                txtState.Text = dr["State"].ToString();
                txtZipcode.Text = dr["Zipcode"].ToString();
                txtPhoneNumber.Text = dr["PhoneNumber"].ToString();
                txtCellNumber.Text = dr["CellNumber"].ToString();
                txtEmail.Text = dr["Email"].ToString();


                //ID Label for selected Person
                lblPerson_ID.Text = dr["PersonID"].ToString();
            }
        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            PersonV2 temp = new PersonV2();
            temp.FirstName = txtFirstName.Text;
            temp.MiddleName = txtMiddleName.Text;
            temp.LastName = txtLastName.Text;
            temp.AddressOne = txtAddressOne.Text;
            temp.AddressTwo = txtAddressTwo.Text;
            temp.City = txtCity.Text;
            temp.State = txtState.Text;
            temp.Zipcode = txtZipcode.Text;
            temp.PhoneNumber = txtPhoneNumber.Text;
            temp.Email = txtEmail.Text;
            temp.CellPhone = txtCellNumber.Text;
            temp.Instrgram = txtInstrgram.Text;


            /*
            
            if (ValidationLib.notAllowed(txtFirstName.Text))
                temp.FirstName = txtFirstName.Text;
            else
                temp.Feedback += "\nERROR: First Name may not contain 'homework', 'caca', 'poop'. Please reenter.";

            if (ValidationLib.notAllowed(txtMiddleName.Text))
                temp.MiddleName = txtMiddleName.Text;
            else
                temp.Feedback += "\nERROR: Middle Name may not contain 'homework', 'caca', 'poop'. Please reenter.";

            if (ValidationLib.notAllowed(txtLastName.Text))
                temp.LastName = txtLastName.Text;
            else
                temp.Feedback += "\nERROR: Last Name may not contain 'homework', 'caca', 'poop'. Please reenter.";

            if (ValidationLib.validateState(txtState.Text))
                temp.State = txtState.Text;
            else
                temp.Feedback += "\nERROR: Please enter a valid state. (Ex. TX)";

            if (ValidationLib.validateZipCode(txtZipcode.Text))
                temp.Zipcode = txtZipcode.Text;
            else
                temp.Feedback += "\nERROR: Please enter a valid zipcode. (Ex. 02999)";

            if (ValidationLib.validatePhoneNumber(txtPhoneNumber.Text))
                temp.PhoneNumber = txtPhoneNumber.Text;
            else
                temp.Feedback += "\nERROR: Please enter a valid phone number. (Ex. 8889991010)";

            if (ValidationLib.validateCellNumber(txtCellNumber.Text))
                temp.CellPhone = txtCellNumber.Text;
            else
                temp.Feedback += "\nERROR: Please enter a valid cellphone number. (Ex. 8889991010)";

            if (ValidationLib.validateEmail(txtEmail.Text))
                temp.Email = txtEmail.Text;
            else
                temp.Feedback += "\nERROR: Please enter a valid email. (Ex. youremail@gmail.com)"; 

            if (ValidationLib.validateIG(txtInstrgram.Text))
                temp.Instrgram = txtInstrgram.Text;
            else
                temp.Feedback += "\nERROR: Please enter a valid instagram URL. (Ex. instagram.com/myinstagram99)"; 
 
           */

            if (temp.Feedback.Contains("ERROR:"))
            {
                lblFeedback.Text = temp.Feedback;
            }

            else
            {
                lblFeedback.Text = temp.AddARecord();

                /* "\nFirst Name: " + temp.FirstName + "\nMiddle Name: " + temp.MiddleName +
                "\nLast Name: " + temp.LastName + "\nAddress One: " + temp.AddressOne + "\nAddress Two: " + temp.AddressTwo +
                "\nCity: " + temp.City + "\nState: " + temp.State + "\nZipcode: " + temp.Zipcode + "\nPhone Number: " + temp.PhoneNumber
                + "\nCellphone Number: " + temp.CellPhone + "\nEmail: " + temp.Email + "\nInstagram URL: " + temp.Instrgram;*/
            }


        }


    }
}