using System.Text.RegularExpressions;

namespace MyProject.Core;

public class EmailValidator
{
   public bool IsValid(string? email)
   {
      if (string.IsNullOrWhiteSpace(email)) return false;

      if (!email.Contains("@")) return false;

      return true;
   }
}
