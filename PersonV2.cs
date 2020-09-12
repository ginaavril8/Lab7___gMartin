using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Use these namespaces to include DB capabilities for generic components and SQL Server
using System.Data;
using System.Data.SqlClient;

namespace Lab7__gMartin
{
    class PersonV2 : Person
    {
        private string cell;
        private string instgramlink;


        public string CellPhone
        {
            get
            {
                return cell;
            }
            set
            {
                if (ValidationLib.dataEntered(value))
                {
                    cell = value;
                }
                else
                {
                    Feedback = "ERROR: Please enter a cell phone number (Ex. 1234567890).";
                }
            }
        }


        public string Instrgram
        {
            get
            {
                return instgramlink;
            }

            set
            {
                if (ValidationLib.validateIG(value))
                {
                    instgramlink = value;
                }
                else
                {
                    Feedback = "ERROR: Please enter a valid instgram handle. \n(Ex. instagram.com/username)";
                }

            }
        }

            //*****************************************************************************************************************
            public string AddARecord()
            {
                //Init string var
                string strResult = "";

                //Make a connection object
                SqlConnection Conn = new SqlConnection();

                //Initialize it's properties
                Conn.ConnectionString = @GetConnected(); //@"Server=sql.neit.edu\sqlstudentserver,4500;Database=SE245_GMartin;User Id=SE245_GMartin;Password=008003563";     
                //Set the Who/What/Where of DB


            //*******************************************************************************************************
            string strSQL = "INSERT INTO Persons (FirstName, MiddleName, LastName, AddressOne, AddressTwo, City, State, Zipcode, PhoneNumber, CellNumber, Email, InstagramURL) VALUES (@FirstName, @MiddleName, @LastName, @AddressOne, @AddressTwo, @City, @State, @Zipcode, @PhoneNumber, @CellNumber, @Email, @InstagramURL)";
            // Bark out our command
            SqlCommand comm = new SqlCommand();
            comm.CommandText = strSQL;  //Commander knows what to say
            comm.Connection = Conn;     //Where's the phone?  Here it is

            //Fill in the paramters (Has to be created in same sequence as they are used in SQL Statement)
            comm.Parameters.AddWithValue("@FirstName", FirstName);
            comm.Parameters.AddWithValue("@MiddleName", MiddleName);
            comm.Parameters.AddWithValue("@LastName", LastName);
            comm.Parameters.AddWithValue("@AddressOne", AddressOne);
            comm.Parameters.AddWithValue("@AddressTwo", AddressTwo);
            comm.Parameters.AddWithValue("@City", City);
            comm.Parameters.AddWithValue("@State", State);
            comm.Parameters.AddWithValue("@Zipcode", Zipcode);
            comm.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
            comm.Parameters.AddWithValue("@CellNumber", CellPhone);
            comm.Parameters.AddWithValue("@Email", Email);
            comm.Parameters.AddWithValue("@InstagramURL", Instrgram);


            //*******************************************************************************************************


            //attempt to connect to the server
            try
            {
                Conn.Open();                                                 //Open connection to DB - Think of dialing a friend on phone
                int intRecs = comm.ExecuteNonQuery();                        //Perofrms sql statment
                strResult = $"SUCCESS: Inserted {intRecs} records.";         //Report that we made the connection and added a record
                Conn.Close();                                                //Hanging up after phone call
            }
            catch (Exception err)                                            //If we got here, there was a problem connecting to DB
            {
                strResult = "ERROR: " + err.Message;                         //Set feedback to state there was an error & error info
            }
            finally
            {

            }


            //Return resulting feedback string
            return strResult;
        }



        //**************************************************************************************
        //  NEW - Part one of drill-down search (Takes search params to narrow the search results
        //**************************************************************************************
        
        public DataSet SearchContacts(String strFirstName, String strLastName)
        {
            //Create a dataset to return filled
            DataSet ds = new DataSet();


            //Create a command for our SQL statement
            SqlCommand comm = new SqlCommand();


            //Write a Select Statement to perform Search
            String strSQL = "SELECT PersonID, FirstName, LastName FROM Persons WHERE 0=0";

            //If the First/Last Name is filled in include it as search criteria
            if (strFirstName.Length > 0)
            {
                strSQL += " AND FirstName LIKE @FirstName";
                comm.Parameters.AddWithValue("@FirstName", "%" + strFirstName + "%");
            }
            if (strLastName.Length > 0)
            {
                strSQL += " AND LastName LIKE @LastName";
                comm.Parameters.AddWithValue("@LastName", "%" + strLastName + "%");
            }


            //Create DB tools and Configure
            //*********************************************************************************************
            SqlConnection conn = new SqlConnection();
            //Create the who, what where of the DB
            string strConn = @GetConnected();
            conn.ConnectionString = strConn;

            //Fill in basic info to command object
            comm.Connection = conn;     //tell the commander what connection to use
            comm.CommandText = strSQL;  //tell the command what to say

            //Create Data Adapter
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = comm;    //commander needs a translator(dataAdapter) to speak with datasets

            //*********************************************************************************************

            //Get Data
            conn.Open();                //Open the connection (pick up the phone)
            da.Fill(ds, "PersonV2_Temp");     //Fill the dataset with results from database and call it "PersonV2_Temp"
            conn.Close();               //Close the connection (hangs up phone)

            //Return the data
            return ds;
        }



        //NEW  - Method that returns a Data Reader filled with all the data
        // of one Person.  This one Person is specified by the ID passed
        // to this function
        public SqlDataReader FindAContact(int intPersons_ID)
        {
            //Create and Initialize the DB Tools we need
            SqlConnection conn = new SqlConnection();
            SqlCommand comm = new SqlCommand();

            //My Connection String
            string strConn = GetConnected();

            //My SQL command string to pull up one EBook's data
            string sqlString =
           "SELECT * FROM Persons WHERE PersonID = @PersonID;";

            //Tell the connection object the who, what, where, how
            conn.ConnectionString = strConn;

            //Give the command object info it needs
            comm.Connection = conn;
            comm.CommandText = sqlString;
            comm.Parameters.AddWithValue("@PersonID", intPersons_ID);

            //Open the DataBase Connection and Yell our SQL Command
            conn.Open();

            //Return some form of feedback
            return comm.ExecuteReader();   //Return the dataset to be used by others (the calling form)

        }

        

        //**************************************************************************************
        //  NEW - Utility function so that one string controls all SQL Server Login info
        //**************************************************************************************
        private string GetConnected()
        {
            return @"Server=sql.neit.edu\sqlstudentserver,4500;Database=SE245_GMartin;User Id=SE245_GMartin;Password=008003563"; 
        }



        //Default Constructor
        public PersonV2() : base() //calling Person (parent) constructor
        {
            instgramlink = "";
            cell = "";
        }

    }
}