namespace WebSaleRepository.Helper
{
    public static class CipherPlantextHelper
    {
        public static string Encrypt(string plainText, string salt)
        {
            return BCrypt.Net.BCrypt.HashPassword(plainText, salt);
        }

        public static string GenerateSalt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt();
        }

        public static bool Verify(string plainText, string hash, string salt)
        {
            return Encrypt(plainText, salt) == hash;
        }
    }
}