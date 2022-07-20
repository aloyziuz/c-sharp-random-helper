using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RandomHelper
{
    public class RandomGenerator
    {
        protected Random randomGenerator;

        public RandomGenerator(int? seed = null)
        {
            this.randomGenerator = seed.HasValue ? new Random(seed.Value) : new Random();
        }

        /// <summary>
        /// generate a random string of fixed length
        /// </summary>
        /// <param name="length">length of the random string</param>
        /// <returns></returns>
        public string GenerateString(int length)
        {
            // creating a StringBuilder object()
            StringBuilder str_build = new StringBuilder();

            char letter;

            for (int i = 0; i < length; i++)
            {
                double flt = this.randomGenerator.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);
            }
            return str_build.ToString();
        }

        /// <summary>
        /// generate random number within a given limit
        /// </summary>
        /// <param name="min">minimum generated number</param>
        /// <param name="max">maximum generated number</param>
        /// <returns></returns>
        public int GenerateNumber(int min, int max)
        {
            return this.randomGenerator.Next(min, max);
        }

        /// <summary>
        /// generate a random string of random length
        /// </summary>
        /// <param name="min">minimum string length</param>
        /// <param name="max">maximum string length</param>
        /// <returns></returns>
        public string GenerateString(int min, int max)
        {
            var len = GenerateNumber(min, max);
            return GenerateString(len);
        }

        public IEnumerable<string> GenerateMultipleStrings(int noOfStrings, int minLength, int maxLength)
        {
            var res = new List<string>();
            for(int i = 0;i < noOfStrings; i++)
            {
                res.Add(GenerateString(minLength, maxLength));
            }
            return res;
        }
    }
}
