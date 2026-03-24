namespace Assignment_A
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            double x, z;

            do
            {
                Console.Write("x: ");
                input = Console.ReadLine(); 
            } while (IsNotValid(input,out x));
            Console.WriteLine($"z={ComputeZ(x)}");


            int n, rn;
            
            do
            {
                Console.Write("n: ");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out n) || n <= 3);
            rn = RandomNumber(n, out int count);
            Console.WriteLine($"Generated number: {rn}"+
                $", number of random values: {count}");
            int[]arr=new int[25];
            Method3(arr, out int smallest, out int largest,
                out double avg);
            Console.WriteLine($"Smallest: {smallest}, Largest: {largest}, " +
                $"Average: {avg:F2}");
            for (int i = 0; i < arr.Length; i++) 
              Console.Write(arr[i]+(i<arr.Length-1?", ":""));
            Console.WriteLine();
        }

        static void Method3(int[] arr, out int smallest, out int largest,
            out double avg)
        {   smallest = 10; largest = -10; avg = 0;
            Random rnd=new Random();
            for (int i = 0; i < arr.Length; i++)
            {   arr[i]=rnd.Next(-10,11);
                if (arr[i]<smallest)
                    smallest = arr[i];
                if(arr[i]>largest)
                    largest = arr[i];
                avg = avg + arr[i];
            }
            avg=avg/arr.Length; 
        }

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


        private static bool IsNotValid(string? input, out double x)
        {
            x= 0;
            if (!double.TryParse(input, out x)||
                x==-3 || x==3)
                return true;


            return false;
        }

        static double ComputeZ(double x)
        { 
            return (Math.Sqrt(x*x+6*x+9)+2)/(x*x-9);
        }
    }
}
