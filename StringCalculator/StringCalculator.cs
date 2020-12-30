using System;

namespace StringCalculator.Business {
    public class StringCalculator {
        public static int Add(string numbers) {
            if (string.IsNullOrEmpty(numbers)) return 0;

            int[] arrayNumbers = Return_Numbers_in_Array_format(numbers);
            CheckNegativeNumbers(arrayNumbers)  ;
            int result = 0;
            for (int index = 0; index < arrayNumbers.Length; index++)
            {
                if(arrayNumbers[index] < 1000) result += arrayNumbers[index];
            }
            return result;

        }
        private static int[] Return_Numbers_in_Array_format(string numbers)
        {
            string[] separators = new string[] { ",", "\n" };
            string customDelimiter = Get_custom_delimiter(numbers);
            if (customDelimiter != "")
            {
                separators[0] = customDelimiter;
                numbers = numbers.Substring(numbers.IndexOf("\n", StringComparison.Ordinal) + 1);
            }
            string[] arrayNumbers = numbers.Split(separators, StringSplitOptions.None);
            return  Array.ConvertAll(arrayNumbers, int.Parse); ;
        }
        private static string Get_custom_delimiter(string numbers)
        {
            string delimiter = "";
            int startPosition = numbers.IndexOf("//", StringComparison.Ordinal);
            if (startPosition == 0)
            {
                int lastPosition = numbers.IndexOf("\n", StringComparison.Ordinal);
                delimiter = numbers.Substring(startPosition + 2, lastPosition - 2);
            }
            return delimiter;
        }
        private static void CheckNegativeNumbers(int[] arrayNumbers)
        {
            string negativeNumbers = "";
            foreach (int number in arrayNumbers)
            {
                if (number < 0 )
                {
                    negativeNumbers += number + ",";
                }
            }
            if (negativeNumbers.EndsWith(','))
            {
                negativeNumbers = negativeNumbers.Substring(0, negativeNumbers.Length - 1);
                throw new Exception("negatives not allowed: "+ negativeNumbers);
            }
        }
    }

}