using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace CryptoServiceHelper
{
	/// <summary>
	/// Classe auxiliar para criptografica de texto.
	/// <para>
	/// Extraído de http://stackoverflow.com/questions/7148745/c-sharp-encrypt-text-output
	/// </para>
	/// </summary>
	public class RijndaelHelper
	{
		string passPhrase = "E03C984D-3FF0-4DB6-A07B-4C552C5FEAEE";        // can be any string
		string saltValue = "fç~`de´~cw3";        // can be any string
		string hashAlgorithm = "SHA1";             // can be "MD5"
		int passwordIterations = 7;                  // can be any number
		string initVector = "~1B2v,tospjssjW8"; // must be 16 bytes
		int keySize = 256;                // can be 192 or 128
		static RijndaelHelper defaultInstance;

		/// <summary>
		/// Instância padrão para serviço de criptografia.
		/// </summary>
		public static RijndaelHelper Default
		{
			get
			{
				if (RijndaelHelper.defaultInstance == null)
				{
					RijndaelHelper.defaultInstance = new RijndaelHelper();
				}
				return RijndaelHelper.defaultInstance;
			}
		}

		/// <summary>
		/// Criptografa o texto passado.
		/// </summary>
		/// <param name="data">Dado textual a criptografar.</param>
		/// <returns>Retorna o dado criptografado.</returns>
		public byte[] Encrypt(string data)
		{
            byte[] bytes = null;
            byte[] rgbSalt = null;
            byte[] buffer = null;
            byte[] rgbKey = null;
            RijndaelManaged managed = null;
            ICryptoTransform transform = null;
            MemoryStream stream = null;
            CryptoStream stream2 = null;

            try
            {
                bytes = Encoding.ASCII.GetBytes(this.initVector);
                rgbSalt = Encoding.ASCII.GetBytes(this.saltValue);
                buffer = Encoding.UTF8.GetBytes(data);
                rgbKey = new PasswordDeriveBytes(this.passPhrase, rgbSalt, this.hashAlgorithm, this.passwordIterations).GetBytes(this.keySize / 8);
                managed = new RijndaelManaged();
                managed.Mode = CipherMode.CBC;
                transform = managed.CreateEncryptor(rgbKey, bytes);
                stream = new MemoryStream();
                stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Write);
                stream2.Write(buffer, 0, buffer.Length);
                stream2.FlushFinalBlock();
                byte[] inArray = stream.ToArray();
                stream.Close();
                stream2.Close();
                return inArray;
            }
            finally
            {
                bytes = null;
                rgbSalt = null;
                buffer = null;
                rgbKey = null;
                managed = null;
                transform = null;
                stream = null;
                stream2 = null;
            }
		}

		/// <summary>
		/// Descriptografa o texto passado.
		/// </summary>
		/// <param name="data">Dado textual a descriptografar.</param>
		/// <returns>Retorna o dado descriptografado.</returns>
		public string Decrypt(byte[] data)
		{
            byte[] bytes = null;
            byte[] rgbSalt = null;
            byte[] rgbKey = null;
            RijndaelManaged managed = null;
            ICryptoTransform transform = null;
            MemoryStream stream = null;
            CryptoStream stream2 = null;

            try
            {
                bytes = Encoding.ASCII.GetBytes(this.initVector);
                rgbSalt = Encoding.ASCII.GetBytes(this.saltValue);
                rgbKey = new PasswordDeriveBytes(this.passPhrase, rgbSalt, this.hashAlgorithm, this.passwordIterations).GetBytes(this.keySize / 8);
                managed = new RijndaelManaged();
                managed.Mode = CipherMode.CBC;
                transform = managed.CreateDecryptor(rgbKey, bytes);
                stream = new MemoryStream(data);
                stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Read);
                byte[] buffer5 = new byte[data.Length];
                int count = stream2.Read(buffer5, 0, buffer5.Length);
                stream.Close();
                stream2.Close();
                return Encoding.UTF8.GetString(buffer5, 0, count);
            }
            finally
            {
                bytes = null;
                rgbSalt = null;
                rgbKey = null;
                managed = null;
                transform = null;
                stream = null;
                stream2 = null;
            }
		}
	}
}
