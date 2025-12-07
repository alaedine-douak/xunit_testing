namespace MyProject.Core;

internal class User(string name, int age)
{
   public string Name { get; set; } = name;
   public int Age { get; set; } = age;
}

internal class UserValidator
{
   public (bool, string) Validate(User user)
   {
      if (string.IsNullOrEmpty(user.Name)) return (false, "Name is required");

      if (user.Age < 0) return (false, "Age must be positive");

      return (true, string.Empty);
   }
}
