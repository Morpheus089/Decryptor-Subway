using System;
using System.IO;
using System.Security.Cryptography;

for (;;)
{
    var input = Console.ReadLine() ArgumentNullException();
        
    var aes = Aes.Create();
    aes.Key = new byte[] {57,114,107,120,67,80,108,106,83,77,49,71,86,81,104,87,119,49,114,49,114,75,79,72,71,99,99,98,50,105,74,53};
    aes.IV = new byte[16];
	
    try
    {
        byte[] buffer = Convert.FromBase64String(input);
        MemoryStream memoryStream = new MemoryStream(buffer);
        CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Read, false);
        StreamReader streamReader = new StreamReader(cryptoStream);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(streamReader.ReadToEnd());
        Console.ResetColor();
    }
    catch (Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(ex.Message);
        Console.ResetColor();
    }
}
