using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Lab7__gMartin
{
    class Person
    {
        //Public varibales representing demograpgic information
        private string firstname;
        private string middlename;
        private string lastname;
        private string addressone;
        private string addresstwo;
        private string city;
        private string state;
        private string zipcode;
        private string phonenumber;
        private string email;
        protected string feedback = "";


        public string FirstName
        {
            get
            {
                return firstname;
            }

            set
            {
                if (ValidationLib.notAllowed(value))
                {
                    firstname = value;
                }
                else if (ValidationLib.dataEntered(value))
                {
                    firstname = value;
                }
                else
                {
                    Feedback = "ERROR: Please enter a valid first name.";
                }

            }
        }


        public string MiddleName
        {
            get
            {
                return middlename;
            }
            set
            {
                // if (ValidationLib.dataEntered(value)) /
                {
                    middlename = value;
                }

            }
        }

        public string LastName
        {
            get
            {
                return lastname;
            }
            set
            {
                if (ValidationLib.notAllowed(value))
                {
                    lastname = value;

                }
                else if (ValidationLib.dataEntered(value))
                {
                    lastname = value;
                }
                else
                {
                    Feedback = "ERROR: Please enter a valid last name.";
                }

            }
        }


        public string AddressOne
        {
            get
            {
                return addressone;
            }

            set
            {
                if (ValidationLib.dataEntered(value))
                {
                    addressone = value;
                }
                else
                {
                    Feedback = "ERROR: Please enter a valid mailing address.";
                }
            }
        }

        public string AddressTwo
        {
            get
            {
                return addresstwo;
            }
            set
            {
                addresstwo = value;
            }

        }

        public string City
        {
            get
            {
                return city;
            }

            set
            {
                if (ValidationLib.dataEntered(value))
                {
                    city = value;
                }
                else
                {
                    Feedback = "ERROR: Please enter a valid city or town.";
                }
            }
        }

        public string State
        {
            get
            {
                return state;
            }

            set
            {
                if (ValidationLib.validateState(value))
                {
                    state = value;
                }
                else
                {
                    Feedback = "ERROR: Please enter a valid state. (Ex. TX)";
                }
            }
        }

        public string Zipcode
        {
            get
            {
                return zipcode;
            }

            set
            {
                if (ValidationLib.validateZipCode(value))
                {
                    zipcode = value;
                }
                else
                {
                    Feedback = "ERROR: Please enter a valid zipcode. (Ex. 12345)";
                }
            }
        }

        public string PhoneNumber
        {
            get
            {
                return phonenumber;
            }
            set
            {
                if (ValidationLib.dataEntered(value))
                {
                    phonenumber = value;
                }
                else
                {
                    Feedback = "ERROR: Please enter a ten digit phone number. (Ex. 1234567890)";
                }
            }
        }

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                if (ValidationLib.validateEmail(value))
                {
                    email = value;
                }
                else
                {
                    Feedback = "ERROR: Please enter a valid email. \n(Ex. myemail@email.com)";
                }

            }

        }

        public string Feedback
        {
            get
            {
                return feedback;
            }
            set
            {
                feedback = value;
            }
        }


        //NEW- Allows class to communicate with outside programs
        public string moreFeedback
        {
            get { return feedback; }        //allows outside code to see feedback
            // Notice there is no SET...This is because only the class can change feedback  
        }


        //Default Constructor

        public Person()
        {
            firstname = "";
            middlename = "";
            lastname = "";
            addressone = "";
            addresstwo = "";
            city = "";
            state = "";
            zipcode = "";
            phonenumber = "";
            email = "";
            feedback = "";
        }

    }
}
