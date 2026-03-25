/*
 # Assignment_A

1) (8 points)
Create a method that computes the value of
$z = \frac{\sqrt{x^2 + 6x + 9} + 2}{x^2 - 9}$
for a real input value x.
The program should:
- Ask the user to enter a value for x.
- Validate the input before calling the method (e.g., avoid division by zero, ensure 
  the expression under the square root is non-negative).
- Call the method to compute and return the value of z if it is mathematically defined.
- Display the result.

2) (10 points)
Write a method that repeatedly generates non-negative random integers 
until one is found such that dividing it by a user-provided number 
n>3 gives a remainder of 3.
The program should:
- Ask the user for an integer greater than three (validate input).
- Call the method to:
  - Generate random non-negative integers,
  - Check the remainder condition,
  - Print every generated number,
- Stop when the condition is satisfied,
- Return the matching number and the count of attempts.
- Display the final result including how many numbers were generated.

3) (12 points)
Write a C# method that:
- Creates and fills an array of 25 integers, each randomly selected 
  from the closed interval [−10,10].
- Finds and returns the smallest value in the array.
- Finds and returns the largest value in the array.
- Computes and returns the average of all elements in the array.
- The program should call this method and display:
  - The generated array,
  - The smallest value,
  - The largest value,
  - The average (formatted to 2 decimal places).
 */
namespace Assignment_A
{
  internal class Program
  {
    static void Main(string[] args)
    {
      string? input;
      double x, z;
      // Loop until a valid input for x is provided. The IsNotValid method 
      // checks if the input is a valid number and not equal to -3 or 3
      // to avoid division by zero.
      do
      {
        Console.Write("x: ");
        input = Console.ReadLine();
      } while (IsNotValid(input, out x));
      // Call the ComputeZ method to calculate the value of z based on the valid input x.
      z = ComputeZ(x);
      Console.WriteLine($"z={z}");

      int n, rn;
      // Loop until a valid input for n is provided.
      // The input must be an integer greater than 3.
      do
      {
        Console.Write("Enter an integer value greater than 3: ");
        input = Console.ReadLine();
      } while (!int.TryParse(input, out n) || n <= 3);
      // Call the RandomNumber method to generate random numbers until one satisfies the condition.
      rn = RandomNumber(n, out int count);
      Console.WriteLine($"Generated number: {rn}, number of random values: {count}");
      int[] arr = new int[25];
      // Call Method3 to fill the array and compute the smallest, largest, and average values.
      Method3(arr, out int smallest, out int largest, out double avg);
      Console.WriteLine($"Smallest: {smallest}, Largest: {largest}, " + $"Average: {avg:F2}");
      for (int i = 0; i < arr.Length; i++)
        Console.Write(arr[i] + (i < arr.Length - 1 ? ", " : ""));
      Console.WriteLine();
    }

    // Creates and fills an array of 25 integers, each randomly selected.
    // Finds and returns the smallest and the largest value in the array.
    // Computes and returns the average of all elements in the array.
    static void Method3(int[] arr, out int smallest, out int largest, out double avg)
    {
      // Initialize smallest and largest to the opposite extremes of the possible values
      // so that any value in the array will update them correctly.
      // Initialize avg to 0 to accumulate the sum of the elements.
      smallest = 10; largest = -10; avg = 0;
      Random rnd = new Random();
      for (int i = 0; i < arr.Length; i++)
      {
        arr[i] = rnd.Next(-10, 11);
        if (arr[i] < smallest)
          smallest = arr[i];
        if (arr[i] > largest)
          largest = arr[i];
        avg = avg + arr[i];
      }
      // Compute the average by dividing the total sum by the number of elements.
      avg = avg / arr.Length;
    }

    // Generates random non-negative integers until one is found such that
    // dividing it by n gives a remainder of 3. Counts the number of attempts
    // and returns the matching number.
    static int RandomNumber(int n, out int count)
    {
      count = 0;
      Random rnd = new Random();
      int rn;
      do
      {
        rn = rnd.Next();
        count++;
      } while (rn % n != 3);
      return rn;
    }

    // Validates the input for method 1
    // x is not valid if it is not a number, or if it is -3 or 3 (division by zero)
    private static bool IsNotValid(string? input, out double x)
    {
      x = 0;
      if (!double.TryParse(input, out x) || x == -3 || x == 3)
        return true;
      // The expression under the square root is x^2 + 6x + 9 = (x+3)^2, which is always non-negative
      // So we don't need to check for that condition
      // If we reach this point, the input is valid
      return false;
    }

    static double ComputeZ(double x)
    {
      return (Math.Sqrt(x * x + 6 * x + 9) + 2) / (x * x - 9);
    }
  }
}
