﻿namespace _01.StringExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Contains extensions to String class
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Encrypts string using MD5 algorithm
        /// </summary>
        /// <param name="input">Contains string to be encrypted</param>
        /// <returns><see cref="System.String"/> containing MD5 hash code</returns>
        public static string ToMd5Hash(this string input)
        {
            var md5Hash = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new StringBuilder to collect the bytes
            // and create a string.
            var builder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return builder.ToString();
        }

        /// <summary>
        /// Checks if string can be interpreted as <see cref="System.Boolean"/> "true" value
        /// </summary>
        /// <param name="input">String instance</param>
        /// <returns>True if the string can be interpreted as "true"</returns>
        public static bool ToBoolean(this string input)
        {
            var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
            return stringTrueValues.Contains(input.ToLower());
        }

        /// <summary>
        /// Converts string to <see cref="System.Int16"/>
        /// </summary>
        /// <param name="input">String instance</param>
        /// <returns>String value as <see cref="System.Int16"/></returns>
        public static short ToShort(this string input)
        {
            short shortValue;
            short.TryParse(input, out shortValue);
            return shortValue;
        }

        /// <summary>
        /// Converts string to <see cref="System.Int32"/>
        /// </summary>
        /// <param name="input">String instance</param>
        /// <returns>String value as <see cref="System.Int32"/></returns>
        public static int ToInteger(this string input)
        {
            int integerValue;
            int.TryParse(input, out integerValue);
            return integerValue;
        }

        /// <summary>
        /// Converts string to <see cref="System.Int64"/>
        /// </summary>
        /// <param name="input">String instance</param>
        /// <returns>String value as <see cref="System.Int64"/></returns>
        public static long ToLong(this string input)
        {
            long longValue;
            long.TryParse(input, out longValue);
            return longValue;
        }

        /// <summary>
        /// Converts string to <see cref="System.DateTime"/>
        /// </summary>
        /// <param name="input">String instance</param>
        /// <returns>String value as <see cref="System.DateTime"/></returns>
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue;
            DateTime.TryParse(input, out dateTimeValue);
            return dateTimeValue;
        }

        /// <summary>
        /// Makes first letter of string capital
        /// </summary>
        /// <param name="input">String instance</param>
        /// <returns>Returns the same string as input but with capitalized first letter</returns>
        public static string CapitalizeFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + input.Substring(1, input.Length - 1);
        }

        /// <summary>
        /// Gets substring between <paramref name="startString"/> and <paramref name="endString"/>
        /// </summary>
        /// <param name="input">String instance</param>
        /// <param name="startString">Left border of the substring</param>
        /// <param name="endString">Right border of the substring</param>
        /// <param name="startFrom">Starting position</param>
        /// <returns>String equivalent to the substring between <paramref name="startString"/> and <paramref name="endString"/>
        /// searching from <paramref name="startFrom"/>
        /// </returns>
        public static string GetStringBetween(this string input, string startString, string endString, int startFrom = 0)
        {
            input = input.Substring(startFrom);
            startFrom = 0;
            if (!input.Contains(startString) || !input.Contains(endString))
            {
                return string.Empty;
            }

            var startPosition = input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
            if (startPosition == -1)
            {
                return string.Empty;
            }

            var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
            if (endPosition == -1)
            {
                return string.Empty;
            }

            return input.Substring(startPosition, endPosition - startPosition);
        }

        /// <summary>
        /// Converts <see cref="System.String"/> from Cyrillic to Latin letters
        /// </summary>
        /// <param name="input">String instance</param>
        /// <returns>String in Latin letters</returns>
        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            var bulgarianLetters = new[]
                                       {
                                           "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п",
                                           "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
                                       };
            var latinRepresentationsOfBulgarianLetters = new[]
                                                             {
                                                                 "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
                                                                 "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
                                                                 "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
                                                             };
            for (var i = 0; i < bulgarianLetters.Length; i++)
            {
                input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
                input = input.Replace(bulgarianLetters[i].ToUpper(), latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
            }

            return input;
        }

        /// <summary>
        /// Converts <see cref="System.String"/> from Latin to Cyrillic letters
        /// </summary>
        /// <param name="input">String instance</param>
        /// <returns>String in Cyrillic letters</returns>
        public static string ConvertLatinToCyrillicKeyboard(this string input)
        {
            var latinLetters = new[]
                                   {
                                       "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
                                       "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
                                   };

            var bulgarianRepresentationOfLatinKeyboard = new[]
                                                             {
                                                                 "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
                                                                 "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
                                                                 "в", "ь", "ъ", "з"
                                                             };

            for (int i = 0; i < latinLetters.Length; i++)
            {
                input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
                input = input.Replace(latinLetters[i].ToUpper(), bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
            }

            return input;
        }

        /// <summary>
        /// Replaces all Cyrillic letters with their Latin equivalents and removes all non-alphanumerical characters
        /// </summary>
        /// <param name="input">String instance</param>
        /// <returns>
        /// String where all Cyrillic letters are replaced with their Latin equivalents and
        /// all non-alphanumerical characters are removed. 
        /// </returns>
        public static string ToValidUsername(this string input)
        {
            input = input.ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
        }

        /// <summary>
        /// Replaces all Cyrillic letters with their Latin equivalents, replaces spaces with hyphens
        /// and removes all non-alphanumerical characters.
        /// </summary>
        /// <param name="input">String instance</param>
        /// <returns>
        /// String where all Cyrillic letters are replaced with their Latin equivalents, spaces are
        /// replaced with hyphens and all non-alphanumerical characters are removed. 
        /// </returns>
        public static string ToValidLatinFileName(this string input)
        {
            input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }

        /// <summary>
        /// Gets substring which starts at position 0 and whose lenght is the lesser of it's length and
        /// <paramref name="charsCount"/>.
        /// </summary>
        /// <param name="input">String instance</param>
        /// <param name="charsCount">Length of the substring</param>
        /// <returns>
        /// Substring which starts at position 0 and whose lenght is the lesser of it's length and
        /// <paramref name="charsCount"/>.
        /// </returns>
        public static string GetFirstCharacters(this string input, int charsCount)
        {
            return input.Substring(0, Math.Min(input.Length, charsCount));
        }

        /// <summary>
        /// Gets file extension of the string <paramref name="fileName"/>(interpreted as file name).
        /// </summary>
        /// <param name="fileName">String instance</param>
        /// <returns>
        /// <see cref="System.String"/> containing file extension of file with file name <paramref name="fileName"/>.
        /// </returns>
        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }

            return fileParts.Last().Trim().ToLower();
        }

        /// <summary>
        /// Gets content type based on it's extension <paramref name="fileExtension"/>.
        /// </summary>
        /// <param name="fileExtension">String instance</param>
        /// <returns>
        /// <see cref="System.String"/> containing content type based on it's <paramref name="fileExtension"/>. 
        /// </returns>
        public static string ToContentType(this string fileExtension)
        {
            var fileExtensionToContentType = new Dictionary<string, string>
                                                 {
                                                     { "jpg", "image/jpeg" },
                                                     { "jpeg", "image/jpeg" },
                                                     { "png", "image/x-png" },
                                                     {
                                                         "docx",
                                                         "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                                                     },
                                                     { "doc", "application/msword" },
                                                     { "pdf", "application/pdf" },
                                                     { "txt", "text/plain" },
                                                     { "rtf", "application/rtf" }
                                                 };
            if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
            {
                return fileExtensionToContentType[fileExtension.Trim()];
            }

            return "application/octet-stream";
        }

        /// <summary>
        /// Converts string to sequence of bytes
        /// </summary>
        /// <param name="input">String instance</param>
        /// <returns>Byte array containing input string</returns>
        public static byte[] ToByteArray(this string input)
        {
            var bytesArray = new byte[input.Length * sizeof(char)];
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
            return bytesArray;
        }
    }
}
