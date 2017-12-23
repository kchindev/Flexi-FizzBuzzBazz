using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace FlexiFizzBuzzBazzIntf
{
    interface IFizzBuzzBazz
    {
        int Fizz { set; }
        int Buzz { set; }

        /// <summary>
        /// FizzBuzz generates an array of strings representing the consecutive sequence of
        /// integers from start to end. When the integer is a multiple of Fizz, the string
        /// "Fizz" is added instead. Likewise, for multiples of Buzz, "Buzz" is added. For
        /// multiples of both Fizz and Buzz, "FizzBuzz" is added.
        /// (e.g. With Fizz = 3, Buzz = 5, start = 1, and end = 15; the array looks like:
        /// ["1", "2", "Fizz", "4", "Buzz", "Fizz", "7", "8", ... , "14", "FizzBuzz"])
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        string[] FizzBuzz(int start, int end);

        /// <summary>
        /// FizzBuzzBazz returns the same result as FizzBuzz, except that instances of "FizzBuzz"
        /// are "FizzBuzzBazz" where the Predicate bazz is true.
        /// (e.g. With Fizz = 2, Buzz = 3, start = 1, end = 15, bazz = (x => x > 6); the array
        /// looks like ["1", "Fizz", "Buzz", "Fizz", "5", "FizzBuzz", "7", "Fizz", "Buzz", "Fizz",
        /// "11", "FizzBuzzBazz", "13", "Fizz", "Buzz"])
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="bazz"></param>
        /// <returns></returns>
        string[] FizzBuzzBazz(int start, int end, Predicate<int> bazz);
    }

    public class GoFizzBuzzBazz : IFizzBuzzBazz
    {
        public int Fizz { get; set; }

        public int Buzz { get; set; }

        public int MaxArraySizeAllowed = 2000;

        // Determine array size based on number of elements to store
        public int GetArraySize(int start, int end)
        {
            // Swap start and end if start is greater than end
            CheckStartAndEnd(ref start, ref end);

            int arraySize = end - start + 1;

            // Make sure array size of at least 1
            if (arraySize <= 0) arraySize = 1;

            return arraySize;
        }

        // Swap start and end if start is greater than end
        private void CheckStartAndEnd(ref int start, ref int end)
        {
            if (end < start)
            {
                int temp = end;
                end = start;
                start = temp;
            }
        }

        // FizzBuzz() calls FizzBuzzBazz() with an "always false" predicate to reuse code
        public string[] FizzBuzz(int start, int end)
        {
            return FizzBuzzBazz(start, end, (x => x != x + 0));
        }

        // FizzBuzzBazz() returns a string array per the given start and end index and predicate 
        public string[] FizzBuzzBazz(int start, int end, Predicate<int> bazz)
        {
            string[] strResult = new string[1];   // String array to hold result

            CheckStartAndEnd(ref start, ref end);   // Swap start and end if start is greater than end

            int arraySize = GetArraySize(start, end);

            if (Fizz == 0)
                strResult[0] = "Fizz cannot be 0!";
            else if (Buzz == 0)
                strResult[0] = "Buzz cannot be 0!";
            else if (arraySize > MaxArraySizeAllowed)
                strResult[0] = string.Format("Please use a start and end range smaller than {0}.  Thank you :)",
                                        MaxArraySizeAllowed);
            else
            {
                Array.Resize(ref strResult, arraySize);

                int Inx = 0;    // Index for string array

                // Loop to generate items
                for (int i = start; i <= end; i++)
                {
                    // Set Fizz and Buzz flags for each i
                    bool IsFizz = ((i % Fizz) == 0);
                    bool IsBuzz = ((i % Buzz) == 0);

                    // Act on the conditions for Fizz, Buzz, FizzBuzz, and FizzBuzzBazz
                    //  to create string items accordingly
                    if (IsFizz && IsBuzz)
                    {
                        if (bazz(i)) strResult[Inx++] = "FizzBuzzBazz";
                        else strResult[Inx++] = "FizzBuzz";
                    }
                    else if (IsFizz) strResult[Inx++] = "Fizz";
                    else if (IsBuzz) strResult[Inx++] = "Buzz";
                    else strResult[Inx++] = i.ToString();
                }
            }

            return strResult;
        }
    }

}
