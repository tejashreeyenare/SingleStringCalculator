using System;
using System.Text.RegularExpressions;

namespace SingleStringCalculator
{
    public class Program
    {
        public static int Add(string numbers)
        {
            var total = 0;

            //check if the input string is empty, if so return 0
            if (numbers != "")
            {
                var numbersToAdd = numbers;

                //search for the pattern to get new delimiter, pattern should be : "//[delimiter]\n[numbers…]"
                var pattern = @"^//(?<dlm>.+)\n(?<nm>.+)";
                Regex rx = new (pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);

                MatchCollection matches = rx.Matches(numbers);

                var newDelimiter = "";

                //if new delimiter pattern is found
                if (matches.Count > 0)
                {
                    //if the match found get the delimiter and numbers 
                    newDelimiter = matches[0].Groups["dlm"].Value;
                    numbersToAdd = matches[0].Groups["nm"].Value;
                }

                //add the new delimiter (if there is any) to the default delimiters which is comma and new line character
                string[] delimiters = { ",", "\n", newDelimiter };

                //split the numbers based on the delimiters
                string[] values = numbersToAdd.Split(delimiters, System.StringSplitOptions.RemoveEmptyEntries);

                //check for the negative numbers, and convert it into the string separated by comma.
                var negativeNumbers = string.Join(",", Array.FindAll(values, x => x.StartsWith("-")));

                if (negativeNumbers == "")
                {
                    foreach (string val in values)
                    {
                        if (val != "")
                        {
                            int num = Convert.ToInt32(val);

                            //check for the negative numbers and greater than 1000
                            if (num >= 0 && num < 1000)
                                total += num;
                        }
                    }
                }
                else
                {
                    //throw exception if negative numbers are found
                    throw new Exception("Negatives not allowed " + negativeNumbers);
                }
            }

            return total;
        }
    }
}
