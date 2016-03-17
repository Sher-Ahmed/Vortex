using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Vortex
{
    public class Lexical
    {
        public static string classpart;
        int Flag = 0;
        string ValuePart;
        int lineNumber = 1;
        public static List<string> Tokens = new List<string>();
        List<char> SorChr = new List<char>();

        public void ReadSource(string SourceCode)
        {
            foreach (char element in SourceCode)
            {
                SorChr.Add(element);
                if (element == ' ')
                {
                    foreach (char elements in SorChr)
                    {
                        ValuePart = ValuePart + Convert.ToString(elements);
                    }
                    TokenMatching(ValuePart);
                    string Token = ValuePart   +   "   ,   "   +   classpart   +   "   ,   "   +   Convert.ToString(lineNumber);
                    Tokens.Add(Token);
                    ValuePart = null;
                    classpart = null;
                    Flag = 0;
                    SorChr.Clear();
                }
                else if (Convert.ToInt32(element) == 10)
                {
                    lineNumber++;
                    SorChr.Clear();
                }
                //else if (SorChr.FindLastIndex(0) == '.' && element <= Convert.ToChar(9))
                //{
                //    var previousitem = SorChr.ElementAt(0);
                //    foreach (char elements in SorChr)
                //    {
                //        string temp = Convert.ToString(elements);

                //    }
                //}

            }
        }

        public void TokenMatching(string tempfile)
        {
            while (Flag != 1)
            {
                if (tempfile.ToLower() == "main ")
                {
                    classpart = "MAIN";
                    Flag = 1;
                }
                else if (tempfile.ToLower() == "void ")
                {
                    classpart = "VOID";
                    Flag = 1;
                }

                else if (tempfile == "( ")
                {
                    classpart = "(";
                    Flag = 1;
                }
                else if (tempfile == ") ")
                {
                    classpart = ")";
                    Flag = 1;
                }
                else if (tempfile == "{ ")
                {
                    classpart = "{";
                    Flag = 1;
                }
                else if (tempfile == "} ")
                {
                    classpart = "}";
                    Flag = 1;
                }
                else if (tempfile.ToLower() == "num " || tempfile.ToLower() == "real " || tempfile.ToLower() == "ch " || tempfile.ToLower() == "str ")
                {
                    classpart = "DT";
                    Flag = 1;
                }
                else if (tempfile == "* " || tempfile == "/ " || tempfile == "% ")
                {
                    classpart = "AROP";
                    Flag = 1;
                }
                else if (tempfile == "+ " || tempfile == "- ")
                {
                    classpart = "AROP_ADDSUB";
                    Flag = 1;
                }
                else if (tempfile == "? ")
                {
                    classpart = "TERMOP";
                    Flag = 1;
                }
                else
                {
                    classpart = "Invalid Token";
                    Flag = 1;
                }
            }
        }
    }
}

