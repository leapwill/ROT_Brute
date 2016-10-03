using System;
using System.IO;

namespace ROT_Brute
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BufferHeight = Int16.MaxValue - 1;

            //get ciphertext and translate easy (short) words
            Console.Write("Enter ROT ciphertext: ");
            string ciphertext = Console.ReadLine().ToUpper();
            string[] cipherwords = ciphertext.Split(' ');

            for(int i = 2; i <= 3; i++)
            {
                Console.WriteLine("For "+ i + " letter words:\nValue\tWord");
                string[] words = File.ReadAllLines(i + ".txt");

                foreach (string word in cipherwords)
                {
                    if(word.Length == i)
                    {
                        for(int k = 1; k <= 26; k++)
                        {
                            string wordROT = "";
                            foreach (char charToROT in word)
                            {
                                wordROT += doROT(charToROT, k);
                            }

                            for (int l = 0; l < words.Length; l++)
                            {
                                //Console.WriteLine(wordROT + "==" + words[l]);
                                if (wordROT.Equals(words[l]))
                                {
                                    Console.WriteLine(k + "\t" + wordROT);
                                }
                            }
                        }
                    }
                }
                Console.WriteLine("Done with " + i + "\n");
            }

            while (true)
            {
                string inROT = "";
                int inROTvalue = 0;
                do
                {
                    Console.Write("Choose ROT value for whole message (q to quit): ");
                    inROT = Console.ReadLine();
                } while ((!inROT.Equals("q")) && !int.TryParse(inROT, out inROTvalue));
                if (inROT.Equals("q")) break;

                string msgROT = "";
                foreach(char c in ciphertext)
                {
                    msgROT += doROT(c, inROTvalue);
                }
                Console.WriteLine(msgROT);
            }


            Console.WriteLine("Finished, exiting...");
            Console.ReadLine();
        }

        static char doROT(char inChar, int ROT)
        {
            if (inChar == ' ') return inChar;
            char outChar = (char)(inChar + ROT);
            if (outChar < 'A') return (char)(outChar + 26);
            if (outChar > 'Z') return (char)(outChar - 26);
            return outChar;
            
        }
    }
}
