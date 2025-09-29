namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello!");

            Console.WriteLine("Input the first number: ");
            string firstNumberInput = Console.ReadLine();
            int firstNumber = int.Parse(firstNumberInput);

            Console.WriteLine("Input the second number: ");
            string secondNumberInput = Console.ReadLine();
            int secondNumber = int.Parse(secondNumberInput);

            Console.WriteLine("What do you want to do with those numbers?");
            Console.WriteLine("[A]dd");
            Console.WriteLine("[S]ubtract");
            Console.WriteLine("[M]ultiply");

            bool isCalculated = false;
            string @operator = "";
            int result = 0;


            string userChoice = Console.ReadLine();

            if(userChoice.ToLower() == "a")
            {
                @operator = "+";
                result = Add(firstNumber, secondNumber);
                isCalculated = true;
            }
            else if(userChoice.ToLower() == "s")
            {
                @operator = "-";
                result = Subtract(firstNumber, secondNumber);
                isCalculated = true;
            }
            else if(userChoice.ToLower() == "m")
            {
                @operator = "*";
                result = Multiply(firstNumber, secondNumber);
                isCalculated = true;
            }
            else
            {
                Console.WriteLine("Invalid option.");
            }

            if(isCalculated)
            {
                Console.WriteLine(PrintResult(firstNumber, secondNumber, @operator, result));
            }

            Console.WriteLine("Press any key to close.");
            Console.ReadKey();
        }
        
       
        public static string PrintResult(int firstNumber, int secondNumber, string @operator, int result)
        {
            return firstNumber + " " + @operator + " " + secondNumber + " = " + result;
        }

        public static int Add(int a, int b)
        {
            return a + b;
        }

        public static int Subtract(int a, int b)
        {
            return a - b;
        }

        public static int Multiply(int a, int b)
        {
            return a * b;
        }
    }
}
