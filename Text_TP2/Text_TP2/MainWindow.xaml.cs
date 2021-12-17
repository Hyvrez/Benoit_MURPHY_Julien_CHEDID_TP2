using System.IO.Packaging;
using System.Windows;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace Text_TP2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private bool buff;
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // the "??" operator checks for nullability and value all at once.
            // because ConvertCheckBox.IsChecked is of type __bool ?__ which
            // is a nullable boolean, so it can either be true, false or null
            var toDecrypt = ConvertCheckBox.IsChecked ?? false;
            var inputText = InputTextBox.Text;
            var encryptionmethod = EncryptionComboBox.Text;
            Popup codePopup = new Popup();
            TextBlock popupText = new TextBlock();  
            
           /* 
            if (toDecrypt)
            {
                OutputTextBox.Text = $"{inputText} is gibberish and should be decrypted using {encryptionmethod}";
            }
            else
            {
                OutputTextBox.Text = $"{inputText} was written as an input to be encrypted using {encryptionmethod}";
            }*/

           if (toDecrypt)
           {
               if (encryptionmethod == "Binary")
               {
                   try
                   {
                       OutputTextBox.Text = Dc_binary(inputText, 8, 2);
                   }
                   catch (ArgumentOutOfRangeException es)
                   {
                       if (es.Source != null)
                       {
                           McTextBlock.Text = "Not the good lenght";
                           Popup1.IsOpen = true;
                       }
                   }
                   catch (FormatException es)
                   {
                       if (es.Source != null)
                       {
                           McTextBlock.Text = "Not good format";
                           Popup1.IsOpen = true;
                       }
                   }
               }
               else if (encryptionmethod == "Hexadecimal")
               {
                   
                   try
                   {
                       OutputTextBox.Text = Dc_binary(inputText,2,16);
                   }
                   catch (ArgumentOutOfRangeException es)
                   {
                       if (es.Source != null)
                       {
                           McTextBlock.Text = "Not the good lenght";
                           Popup1.IsOpen = true;
                       }
                   }
                   catch (FormatException es)
                   {
                       if (es.Source != null)
                       {
                           McTextBlock.Text = "Not good format";
                           Popup1.IsOpen = true;
                       }
                   }
                   
               }
               else if (encryptionmethod == "Caesar")
               {
                   try
                   {
                       OutputTextBox.Text = Dc_ceasar(inputText, int.Parse(Key.Text));
                   }
                   catch (FormatException es)
                   {
                       if (es.Source != null)
                       {
                           McTextBlock.Text = "Not good format";
                           Popup1.IsOpen = true;
                       }
                   }
               }
               else
               {
                   string key = Key.Text;
                   for (int i = 0; i < key.Length; ++i)
                       if (!char.IsLetter(key[i]))
                       {
                           McTextBlock.Text = "Put a better key";
                           Popup1.IsOpen = true;
                       }
                   OutputTextBox.Text = Vigenere(inputText, Key.Text,false);
               }
           }
           else
           {
               if (encryptionmethod == "Binary")
               {
                   OutputTextBox.Text = C_binary(inputText,2,8);
               }
               else if (encryptionmethod == "Hexadecimal")
               {
                   OutputTextBox.Text = C_binary(inputText,16,2);
               }
               else if (encryptionmethod == "Caesar")
               {
                   try
                   {
                       OutputTextBox.Text = C_ceasar(inputText, int.Parse(Key.Text));
                   }
                   catch (FormatException es)
                   {
                       if (es.Source != null)
                       {
                           McTextBlock.Text = "Not good format";
                           Popup1.IsOpen = true;
                       }
                   }
                   
               }
               else
               {
                   string key = Key.Text;
                   for (int i = 0; i < key.Length; ++i)
                       if (!char.IsLetter(key[i]))
                       {
                           McTextBlock.Text = "Put a better key";
                           Popup1.IsOpen = true;
                       }
                           
                   OutputTextBox.Text = Vigenere(inputText, Key.Text,true);
               }
           }

            
        }

        private string C_binary(string data, int bases, int width)
        {
            
                StringBuilder sb = new StringBuilder();
 
                foreach (char c in data.ToCharArray())
                {
                    sb.Append(Convert.ToString(c, bases).PadLeft(width, '0'));
                }
                return sb.ToString();
                
        }
        
        public static string Dc_binary(string data, int length, int bases)
        {
            List<Byte> byteList = new List<Byte>();
            data = data.Replace(" ",String.Empty);
            
            for (int i = 0; i < data.Length; i += length)
                {
                    byteList.Add(Convert.ToByte(data.Substring(i, length), bases));
                }

            return Encoding.ASCII.GetString(byteList.ToArray());
        }

        public static char Ceasar(char ch , int key)
        {
            if (!char.IsLetter(ch))
                return ch;

            char offset = char.IsUpper(ch) ? 'A' : 'a';
            return (char)((((ch + key) - offset) % 26) + offset);
        }
        
        public static string C_ceasar(string input, int key)
        {
            string output = string.Empty;

            foreach (char ch in input)
                output += Ceasar(ch, key);

            return output;
        }
        
        public static string Dc_ceasar(string input, int key)
        {
            return C_ceasar(input, 26 - key);
        }
        
        
        private static string Vigenere(string input, string key, bool encipher)
        {
            

            string output = string.Empty;
            int nonAlphaCharCount = 0;

            for (int i = 0; i < input.Length; ++i)
            {
                if (char.IsLetter(input[i]))
                {
                    bool cIsUpper = char.IsUpper(input[i]);
                    char offset = cIsUpper ? 'A' : 'a';
                    int keyIndex = (i - nonAlphaCharCount) % key.Length;
                    int k = (cIsUpper ? char.ToUpper(key[keyIndex]) : char.ToLower(key[keyIndex])) - offset;
                    k = encipher ? k : -k;
                    char ch = (char)((Mod(((input[i] + k) - offset), 26)) + offset);
                    output += ch;
                }
                else
                {
                    output += input[i];
                    ++nonAlphaCharCount;
                }
            }

            return output;
        }
        private static int Mod(int a, int b)
        {
            return (a % b + b) % b;
        }
        
        private void Hide_Click(object sender, RoutedEventArgs e)
        {
            Popup1.IsOpen = false;
        }
    
    }
}