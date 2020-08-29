using System;
using System.Security.Cryptography;

namespace TemplateFramework.Helpers
{
    public class TestDataGenerator
    {
        private static readonly RandomNumberGenerator Generator = RandomNumberGenerator.Create();

        public static string NewRandomNumber(int minLength)
        {
            return NewRandomNumber(minLength, minLength);
        }

        public static string NewRandomNumber(int minLength, int maxLength)
        {
            var randomNumber = string.Empty;
            do
            {
                randomNumber += Next(100000000, 999999999).ToString();
            } while (randomNumber.Length < maxLength);

            randomNumber = randomNumber.Substring(0, Next(minLength, maxLength));
            return randomNumber;
        }

        private static int Next(int minValue, int maxValue)
        {
            var intBytes = new byte[4];
            Generator.GetBytes(intBytes);
            var randomNumber = BitConverter.ToUInt32(intBytes, 0);

            return (int)(randomNumber % (maxValue - minValue + 1)) + minValue;
        }
    }
}
