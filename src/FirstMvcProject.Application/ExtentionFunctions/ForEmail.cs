using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FirstMvcProject.Application.ExtentionFunctions
{
    public class ForEmail
    {
        public static bool ValidEmail(string email)
        {
            const string emailRegex = @"^[a-zA-Z0-9]+[\.]?([a-zA-Z0-9]+)?[\@][a-z]{2,9}[\.][a-z]{2,5}$";
            var regex = new Regex(emailRegex, RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }
    }
}
