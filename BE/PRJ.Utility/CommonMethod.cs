using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace PRJ.Utility
{
	public class CommonMethods
	{
		public static string Encrypt(string Data)
		{
			var shaM = new SHA1Managed();
			Convert.ToBase64String(shaM.ComputeHash(Encoding.ASCII.GetBytes(Data)));
			//// Getting the bytes of the encrypted data.// 
			byte[] bytEncrypt = ASCIIEncoding.ASCII.GetBytes(Data);
			//// Converting the byte into string.// 
			string strEncrypt = System.Convert.ToBase64String(bytEncrypt);
			return strEncrypt;
		}
	}
}
