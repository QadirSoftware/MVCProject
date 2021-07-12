using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.HasingHelperFunction
{
  public class HasingHelper
    {
        public static void  CreatPasswordHash(string userpasssword, string username,out byte[] usernamehash,out byte[] passwordhash,out byte[] passwordsalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordsalt = hmac.Key;
                passwordhash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userpasssword));
                usernamehash = hmac.ComputeHash(Encoding.UTF8.GetBytes(username));

            }
        }
        public static bool VeritfyPasswordHash(string userpasssword, string username,  byte[] usernamehash,  byte[] passwordhash, byte[] passwordsalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordsalt)) 
                {
                var computedhash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userpasssword));
                var computedhashuseer = hmac.ComputeHash(Encoding.UTF8.GetBytes(username));
                    for (int i = 0; i < computedhash.Length; i++) {
                    if (computedhashuseer[i] != usernamehash[i] && computedhash[i] != passwordhash[i])
                        {
                        return false;
                    }

                }
                return true;
            }
            }
    }
}
