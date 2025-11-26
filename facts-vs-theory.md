## Decision Framework: Facts vs Theories

Here's a practical framework to guide our decision:

1.**Choose *Facts* when:**

- **Testing specific business scenarios**

```csharp
[Fact] // GOOD - specific business rule
public void Premium_Customer_With_Large_Order_Gets_Free_Shipping() {}
```

- **Each test case has a unique setup or assertions**

```csharp
[Fact] // GOOD - Unique setup for each scenario
public void New_User_Registration_Creates_Welcome_Email() {}

[Fact] // GOOD - Different assertions needed
public void Existing_User_Registration_Returns_Conflict_Error() {}
```

- **The test name explains a complete requirement**

```csharp
[Fact] // GOOD - Complete business requirement
public void Order_Above_100_Dollars_Qualifies_For_Express_Shipping() {}
```

2. **Choose *Theory When:***

- **Testing the same logic with different inputs**

```csharp
[Theory] // GOOD - Same validation logic
[InlineData(["username@example.com", true])]
[InlineData(["user@", false])]
[InlineData(["email.invalid", false])]
public void ValidateEmail_WithVariousInputs_ReturnsExpectedResutls(string email, bool expected) {}
```

- **Testing boundary conditions**

```csharp
[Theory] // GOOD - Testing boundaries
[InlineData([0, 0])] // Minimum
[InlineData([1, 0.1])] // Just above minimum
[InlineData([100, 10])] // Maximum
public void CalculateInterest_WithValidAmounts_ReturnsCorrectInterest(decimal amount, decimal expectedInterest) {}
```

- **Mathematical or algorithmic functions**

```csharp
[Theory] // GOOD - Pure function testing
[InlineData([2, 4])]
[InlineData([3, 9])]
[InlineData([5, 25])]
public void Square_WithPositiveIntegers_ReturnsSquaredValue(int input, int expected) {}
```

**Real-World Decision Example:**

**Example 1: User Authentication**

**Poor choice - Over-Parameterized Fact:**

```csharp

[Theory]
[InlineData(["admin", "password123", true])]
public void Authenticate_WithValidCredentials_ReturnsTrue(
	string username, string password, bool expected)

// THis should be a Fact - It's testing one specific scenario
```

**Better approach:**

```csharp

[Fact]
public void Authenticate_WithValidCredentials_ReturnsTrue()
{
   var auth = new AuthService();
   var result = auth.Authenticate("admin", "password123")
   Assert.True(result);
}


[Theory]
[InlineData("", "password")]
[InlineData("admin", "")]
[InlineData(null, "password")]
[InlineData("admin", null)]
public void Authenticate_WithInvalidCredentials_ReturnsFalse(string username, string password)
{
   var auth = new AuthService();
   var result = auth.Authenticate(username, password);
   Assert.False(result);
}

```

**Example 2: Price Calculation**

**Poor Choice - Multiple Facts for similar logic:**
```csharp
[Fact]
public void CalculatePrice_WithQuantity1_Returns10()
{
   var calculator = new PriceCalculator();
   var price = calculator.Calculate(quantity: 1);
   Assert.Equal(10, price);
}

[Fact]
public void CalculatePrice_WithQuantity5_Returns50()
{
   var calculator = new PriceCalculator();
   var price = calculator.Calculate(quantity: 5);
   Assert.Equal(50, price);
}
```

**Better approach:**

```csharp
[Theory]
[InlineData([1, 10])]
[InlineData([5, 50])]
[InlineData([10, 100])]
[InlineData([0, 0])]
public void CalculatePrice_WithValidQuantity_ReturnsCorrectPrice(int quantity, decimal expectedPrice)
{
   var calculator = new PriceCalculator();
   var price = calculator.Calculate(quantity: quantity);
   Assert.Equal(expectedPrice, price);
}

```


✅ Simple rule: When in doubt, use Facts
- Facts are clearer and easier to debug
- You can always refactor to Theories later when patterns emerge
- Start simple, evolve as needed

