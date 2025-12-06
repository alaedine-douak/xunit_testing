using System.Text.RegularExpressions;

namespace MyProject.Core;

public class ValidationResult
{
   public bool IsValid { get; set; }
   public string ErrorMessage { get; set; } = string.Empty;
}

public class EmailValidator
{
   private readonly Regex _regex;

   private const string EMAIL_PATTERN = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

   public EmailValidator()
   {
      _regex = new Regex(
         EMAIL_PATTERN,
         RegexOptions.Compiled | RegexOptions.IgnoreCase
      );
   }

   public ValidationResult Validate(string email)
   {
      if (string.IsNullOrWhiteSpace(email))
      {
         return new ValidationResult
         {
            IsValid = false,
            ErrorMessage = "Email address cannot be null or empty"
         };
      }

      if (!email.Contains("@"))
      {
         return new ValidationResult
         {
            IsValid = false,
            ErrorMessage = "Email address must contain an @ symbol"
         };
      }

      if (!_regex.IsMatch(email))
      {
         return new ValidationResult
         {
            IsValid = false,
            ErrorMessage = "Email address format is invalid"
         };
      }

      return new ValidationResult { IsValid = true };
   }



   //public bool IsValid(string email)
   //{
   //   if (string.IsNullOrWhiteSpace(email)) return false;

   //   return _regex.IsMatch(email);
   //}
}
