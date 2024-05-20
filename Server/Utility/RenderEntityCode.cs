using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Utility
{
    public class RenderEntityCode
    {
        public static string RandomEntityCode(int numberChar)
        {
            Random random = new Random();

            const string CHARACTERS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < numberChar; i++)
            {
                sb.Append(CHARACTERS[random.Next(CHARACTERS.Length)]);
            }

            return sb.ToString();
        }
        public static string RenderByFormat(string pre, string mainString)
        {
            string numberString = mainString.Substring(pre.Length);
            long numberNext = Convert.ToInt32(numberString) + 1;
            int p = mainString.Length - pre.Length;
            return pre + Math.Round((decimal)(numberNext / Math.Pow(10, p)), p).ToString().Substring(2);
        }
        public static class EntityCode
        {
            public static string Company = "CT";
            public static string UserPlatform = "UP";
            public static string User = "USER";
            public static string Account = "ACC";
        }
    }
}
