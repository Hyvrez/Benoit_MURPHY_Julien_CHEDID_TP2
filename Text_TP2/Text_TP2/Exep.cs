using System;

namespace Text_TP2
{
    public class Exep
    {
         public void dc_binary_test(string text)
        {
            
        }
    }
   [Serializable]
    public class ExeptionNobinary : Exception
    {
        public ExeptionNobinary()
        {
        }

        public ExeptionNobinary(string message)
            : base(message)
        {
            
        }

        public ExeptionNobinary(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ExeptionNobinary(string message, string text)
            : this(message)
        {
            foreach(char x in text )
            {
                Char.IsLetter(x);
            }
        }
        
    }
}