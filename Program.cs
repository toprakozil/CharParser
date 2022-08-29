namespace CharParser
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1) //Error handler for multiple or no input args
            {
                Console.WriteLine("Wrong number of arguments");
                return;
            }
            int[] arr; //Static size letter counter initialization p1
            arr = new int[27]; //p2: setting size
            for (int i = 0; i < arr.Length; i++) //p3: set all elements of counter array to 0
            {
                arr[i] = 0;
            }
            for (int i = 0; i < args[0].Length; i++) //Scan every character in the given String
            {
                if ((args[0][i] > 122) || (args[0][i] < 97)) // 'a' to 'z' ASCII boundary set
                {
                    Console.WriteLine("Unexpected character in sequence");
                    return;
                }
                arr[args[0][i] - 97] += 1; //Subtract ASCII of 'a' to shift sequence to [0 26], from [97 122]
            }
            for (int i = 0; i < arr.Length; i++) //Scan over array 27 times to ensure all letters are evaluated
            {
                int maxValue = arr.Max(); //Find maximum value in the array
                int maxIndex = Array.IndexOf(arr, maxValue); //Find where maximum value can be found
                if (maxValue > 0) //Disregard if given letter doesn't actually exist in the String
                {
                    Console.Write(Convert.ToChar(maxIndex + 97)); //Add 97 to re-shift value to proper ASCII equivalent, and display numerical ASCII as actual character
                    arr[maxIndex] = 0; //Set occurance tracker to 0, to avoid re-evaluation of the same letter
                }
            }
        }
    }
}