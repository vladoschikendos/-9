using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace дз9
{
    interface ICipher
    {
        string Encode(string s);
        string Decode(string s);
    }

    class ACipher : ICipher
    {
        public string Encode(string s)
        {
            string result = "";
            foreach (char c in s)
            {
                if (c >= 'А' && c <= 'я')
                {
                    result += (c == 'я') ? 'а' : (c == 'Я') ? 'А' : (char)(c + 1);
                }
                else
                {
                    result += c;
                }
            }
            return result;
        }

        public string Decode(string s)
        {
            string result = "";
            foreach (char c in s)
            {
                
                if (c >= 'А' && c <= 'я')
                {
                    result += (c == 'а') ? 'я' : (c == 'А') ? 'Я' : (char)(c - 1);
                }
                else
                {
                    result += c;
                }
            }
            return result; 
        }
    }
    class BCipher : ICipher
    {
        string alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        string ALPHABET = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        public string Encode(string s)
        {
            string result = "";
            foreach (char c in s)
            {
                int index = alphabet.IndexOf(char.ToLower(c));
                if (index != -1)
                {
                    if (char.IsUpper(c)) result += ALPHABET[32 - index];
                    else result += alphabet[32 - index];
                }
                else result += c;
            }
            return result;
        }
        public string Decode(string s) => Encode(s);
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = "Привет, Мир!";

            
            ICipher a = new ACipher();
            ICipher b = new BCipher();

            Console.WriteLine("Исходный текст: " + text);
            Console.WriteLine("---------------------------------");

            string encA = a.Encode(text);
            Console.WriteLine("ACipher зашифровано: " + encA);
            Console.WriteLine("ACipher расшифровано: " + a.Decode(encA));
            Console.WriteLine("---------------------------------");

            
            string encB = b.Encode(text);
            Console.WriteLine("BCipher зашифровано: " + encB);
            Console.WriteLine("BCipher расшифровано: " + b.Decode(encB));
        }
    }
}
