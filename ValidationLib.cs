using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions; //activates regex

namespace Lab7__gMartin
{
    class ValidationLib
    {

        //Words that cannot not be included in form entry
      /*       public static bool notAllowed(String s) //try (string temp)
             {
                 bool blnResult = false;
                 if (s.Contains("HOMEWORK") ||  s.Contains("POOP") || s.Contains("CACA"))
                 {
                     blnResult = true;
                 }
                 else
                 {
                     blnResult = false;
                 }

                 return blnResult;
             }
      */
             
        public static bool notAllowed(String s)
     {
         bool result = true;

         string[] strBadWords = {"POOP", "HOMEWORK", "CACA" };

         foreach (string strBW in strBadWords)
         if (s.Contains(strBW))
         {
             result = false;
         }

         return result;
     }
             
            

        //Requires input 
        public static bool dataEntered(string temp)
        {
            bool result = false;

            if (temp.Length > 0)
            {
                result = true;
            }
            return result;
        }



        //Validate State
        public static bool validateState(string temp)
        {
            string stateVal = @"[A-Z]{2}"; 
            Regex regEx = new Regex(stateVal);

            bool result = false;

            if (temp.Length == 2 && regEx.IsMatch(temp))
            {
                result = true;
            }
            return result;
        }


        //Validate Phone number
        public static bool validatePhoneNumber(string temp)
        {
            string regPhoneNumber = @"[0-9]{10}";
            Regex regEx = new Regex(regPhoneNumber);


            bool result = false;

            if (temp.Length == 10 && regEx.IsMatch(temp))
            {
                result = true;
            }
            return result;
        }

        //Validate Cell number
        public static bool validateCellNumber(string temp)
        {
            string regCellNumber = @"[0-9]{10}";
            Regex regEx = new Regex(regCellNumber);


            bool result = false;

            if (temp.Length == 10 && regEx.IsMatch(temp))
            {
                result = true;
            }
            return result;
        }


        //Validate Zipcode
        public static bool validateZipCode(string temp)
        {
            string regZipcode = @"[0-9]{5}"; 
            Regex regEx = new Regex(regZipcode);


            bool result = false;

            if (temp.Length == 5 && regEx.IsMatch(temp))
            {
                result = true;
            }
            return result;
        }


        //Validate that the email is formatted correctly
        public static bool validateEmail(string temp)
        {

            bool blnResult = true;

            if (temp.Contains("@gmail") || temp.Contains(".com") || temp.Contains(".net") || temp.Contains("@aol") || temp.Contains("@edu") || temp.Contains("@yahoo"))
            { 
                blnResult = true;
            }
            else
            {
                blnResult = false;
            } 
                return blnResult;
            }
            
        


        //Format IG Link

        public static bool validateIG(string temp)
        {
            bool blnResult = true;
            int atLocation = temp.IndexOf(".");
            int NextLocation = temp.IndexOf("/", atLocation + 1);

            // http: //www.instagram.com/johnsmith

            int periodLocation = temp.LastIndexOf(".");

            if (temp.Length < 18)
            {
                blnResult = false;
            }
            else if (temp.Contains("instagram.com/"))
            {
                blnResult = true;
            }

            else if (periodLocation + 2 > (temp.Length))
            {
                blnResult = false;
            }

            return blnResult;
        }

        /*

        //Member Since Valdiation  
        public static bool futureDate(DateTime temp)
        {
            bool blnresult;

            if (temp <= DateTime.Now)
            {
                blnresult = true;
            }
            else
            {
                blnresult = false;
            }
            return blnresult;
        }
        */
        /*
        //Discount Member
        public static bool discountBool(string temp)
        {
            bool blnresult;

            if (temp == "y" || temp == "Y")
            {
                blnresult = true;
            }
            else if (temp == "n" || temp == "N")
            {
                blnresult = true;
            }
            else
            {
                blnresult = false;
            }
            return blnresult;
        } */

    }
}