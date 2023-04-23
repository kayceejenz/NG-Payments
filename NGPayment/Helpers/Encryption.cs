using System;
using System.Security.Cryptography;
using System.Text;


namespace NGPayments.Helpers
{
    public class Encryption
    {
        public static string SHA512(string input)
        {
            byte[] hash;
            var data = Encoding.UTF8.GetBytes(input);
            using (SHA512 shaM = new SHA512Managed())
            {
                hash = shaM.ComputeHash(data);
            }

            return BitConverter.ToString(hash).Replace("-", "");
        }
    }
}
