using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Utils
{
    public static class Methods
    {
        public static bool IsValidPhoneNumber(string phoneNumber)//method for validation of phone numbeer 
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                return false;
            }

            var pattern = @"^[\+]?[{1}]?[(]?[2-9]\d{2}[)]?[-\s\.]?[2-9]\d{2}[-\s\.]?[0-9]{4}$";
            var options = System.Text.RegularExpressions.RegexOptions.Compiled | System.Text.RegularExpressions.RegexOptions.IgnoreCase;
            return System.Text.RegularExpressions.Regex.IsMatch(phoneNumber, pattern, options);

        }

        public static bool RegexEmailCheck(string input)//method for validation Email
        {
            // returns true if the input is a valid email
            return Regex.IsMatch(input, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
    }
}