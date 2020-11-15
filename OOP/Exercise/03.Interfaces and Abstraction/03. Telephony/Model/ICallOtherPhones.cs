using System;
using System.Collections.Generic;
using System.Text;

namespace _03._Telephony.Model
{
    interface ICallOtherPhones
    {
        protected const string INVALID_PHONE_MSG = "Invalid number!";
        protected const string CALLING_MSG = "{0}... {1}";
        protected const string TYPE = "";
        protected virtual void CheckAndCall(string phoneNumber, string TYPE)
        {
            bool isNumberInValid = false;

            for (int i = 0; i < phoneNumber.Length; i++)
            {
                if (char.IsLetter(phoneNumber[i]))
                {
                    isNumberInValid = true;
                    break;
                }
            }

            PrintResult(isNumberInValid, phoneNumber, TYPE);
        }

        protected virtual void PrintResult(bool isNumberInValid, string phoneNumber, string TYPE)
        {
            if (isNumberInValid)
            {
                Console.WriteLine(INVALID_PHONE_MSG);
            }
            else
            {
                Console.WriteLine(String.Format(CALLING_MSG, phoneNumber, TYPE));
            }
        }
    }
}
