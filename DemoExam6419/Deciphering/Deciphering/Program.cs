using System;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace Deciphering
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string cipher = Console.ReadLine();
            string[] replacers = Console.ReadLine().Split().ToArray();
            string matchez = @"[defghijklmnopqrstuvwxyz\{\,\}|\#]+";
            MatchCollection matches = Regex.Matches(cipher, matchez);
            bool isNotValid = false;
            foreach (Match vqerno in matches)
            {
                if (vqerno.ToString() != cipher)
                {
                    isNotValid = true;
                }
            }
            char[] chekCipher = cipher.ToCharArray();
            for (int i = 0; i < chekCipher.Length; i++)
            {
                if (char.IsUpper(chekCipher[i]))
                {
                    isNotValid = true;
                }
            }
            if (isNotValid)
            {
                Console.WriteLine("This is not the book you are looking for.");
                return;
            }
            StringBuilder decipher = new StringBuilder();
            for (int i = 0; i < cipher.Length; i++)
            {
                char threeback = (char)((int)(cipher[i] - 3));
                decipher.Append(threeback);
            }
            string[] separateDecipher = decipher.ToString().Split();
            StringBuilder replaced = new StringBuilder();
            for (int i = 0; i < separateDecipher.Length; i++)
            {
                int indexOf = -1;
                indexOf = separateDecipher[i].IndexOf(replacers[0]);
                if (indexOf != -1)
                {
                    separateDecipher[i] = separateDecipher[i].Replace(replacers[0], replacers[1]);
                }
                replaced.Append(separateDecipher[i]+" ");
            }
            Console.WriteLine(replaced);

        }
    }
}
