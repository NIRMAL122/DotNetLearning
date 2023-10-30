using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp
{
    public class NextSequence
    {
        public string GetNextValue(string input)
        {
            char[] characters = input.ToCharArray();
            int lastIndex = characters.Length - 1;

            for (int i = lastIndex; i >= 0; i--)
            {
                if (characters[i] < 'Z')
                {
                    characters[i]++;
                    break;
                }
                else
                {
                    characters[i] = 'A';
                    if (i == 0)
                    {
                        // If the first character becomes 'A', insert a new character 'A' at the beginning.
                        char[] newCharacters = new char[characters.Length + 1];
                        newCharacters[0] = 'A';
                        characters.CopyTo(newCharacters, 1);
                        characters = newCharacters;
                    }
                }
            }

            

            return new string(characters);
        }
    }
}
