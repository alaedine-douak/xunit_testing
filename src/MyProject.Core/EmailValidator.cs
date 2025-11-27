using System.Text.RegularExpressions;

namespace MyProject.Core;

public class EmailValidator
{

   private readonly Regex _regex;

   private const string EMAIL_PATTERN = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

   public EmailValidator()
   {
      _regex = new Regex(
         EMAIL_PATTERN, 
         RegexOptions.Compiled | RegexOptions.IgnoreCase);       
   }

   public bool IsValid(string email)
   {
      if (string.IsNullOrWhiteSpace(email)) return false;

      return _regex.IsMatch(email);
   }
}
