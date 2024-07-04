using System.Globalization;

namespace WebSaleRepository.Helper
{
    public static class StringHelper
    {
        public static string CapitalizeAfterSpaceOrFirstLetter(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }
            // nguyen van a => Nguyen Van A
            string[] words = input.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > 0)
                {
                    words[i] = char.ToUpper(words[i][0]) + words[i][i..].ToLower();
                }
            }
            words[0] = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(words[0]);
            return string.Join(" ", words);
        }
    }
}