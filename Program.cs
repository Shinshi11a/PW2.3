using System;

public class CaesarCipher
{
    private int shift; // сдвиг шифра

    public CaesarCipher(int shift)
    {
        this.shift = shift;
    }

    // Метод, шифрующий строку
    public string Encrypt(string plainText)
    {
        char[] chars = plainText.ToCharArray();

        for (int i = 0; i < chars.Length; i++)
        {
            char c = chars[i];

            if (char.IsLetter(c))
            {
                // Определить новую букву с учетом сдвига
                c = (char)(c + shift);

                if ((char.IsLower(chars[i]) && c > 'z') || (char.IsUpper(chars[i]) && c > 'Z'))
                {
                    c = (char)(c - 26);
                }
            }

            chars[i] = c;
        }

        return new string(chars);
    }

    // Метод, расшифровывающий строку
    public string Decrypt(string cipherText)
    {
        // Расшифрование - это просто шифрование с обратным сдвигом
        int reverseShift = 26 - shift;
        CaesarCipher reverseCipher = new CaesarCipher(reverseShift);
        return reverseCipher.Encrypt(cipherText);
    }
}

class Program
{
    static void Main()
    {
        CaesarCipher cipher = new CaesarCipher(3);

        string plainText = "Ah shit, here we go again.";
        string cipherText = cipher.Encrypt(plainText);
        string decryptedText = cipher.Decrypt(cipherText);

        Console.WriteLine($"Исходный текст: {plainText}");
        Console.WriteLine($"Зашифрованный текст: {cipherText}");
        Console.WriteLine($"Расшифрованный текст: {decryptedText}");
    }
}