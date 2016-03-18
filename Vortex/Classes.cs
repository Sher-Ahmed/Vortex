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
        char[] ComOp = new char[] { ' ','!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '_', '+', '=', '|', '\\', '}', ']', '{', '[', '"', ',', ':', ';', '<', '>', '.', '?', '/', '~','`'};
        public static List<string> Tokens = new List<string>();
        List<char> SorChr = new List<char>();

        public void ReadSource(string SourceCode)
        {
            try
            {
                foreach (char element in SourceCode)
                {
                    SorChr.Add(element);
                    foreach (char elementcheck in ComOp)
                    { 
                        if (element == elementcheck)
                        {
                            if (SorChr.Count == 1)
                            {
                                ValuePart = Convert.ToString(element);
                                TokenMatching(ValuePart);
                                string BreakerToken = ValuePart + "   ,   " + classpart + "   ,   " + Convert.ToString(lineNumber);
                                Tokens.Add(BreakerToken);
                                ValuePart = null;
                                classpart = null;
                                Flag = 0;
                                SorChr.Clear();
                            }
                            else
                            {
                                do
                                {
                                    ValuePart = ValuePart + Convert.ToString(SorChr[Flag]);
                                    Flag++;
                                }
                                while (Flag < SorChr.Count - 1);

                                Flag = 0;
                                TokenMatching(ValuePart);
                                string Token = ValuePart + "   ,   " + classpart + "   ,   " + Convert.ToString(lineNumber);
                                Tokens.Add(Token);
                                ValuePart = null;
                                classpart = null;
                                Flag = 0;
                                SorChr.Clear();
                                ValuePart = Convert.ToString(element);
                                TokenMatching(ValuePart);
                                string BreakerToken = ValuePart + "   ,   " + classpart + "   ,   " + Convert.ToString(lineNumber);
                                Tokens.Add(BreakerToken);
                                ValuePart = null;
                                classpart = null;
                                Flag = 0;
                                break;
                            }
                        }
                        else if (Convert.ToInt32(element) == 10)
                        {
                            lineNumber++;
                            SorChr.Clear();
                            break;
                        }
                    }
                }
            }
            catch(Exception exp)
            {
                System.Windows.Forms.MessageBox.Show(Convert.ToString(exp));
            }
        }
    
        public void TokenMatching(string tempfile)
        {
            while (Flag != 1)
            {
                if (tempfile.ToLower() == "main")
                {
                    classpart = "MAIN";
                    Flag = 1;
                }
                else if (tempfile.ToLower() == "void")
                {
                    classpart = "VOID";
                    Flag = 1;
                }

                else if (tempfile == "(")
                {
                    classpart = "(";
                    Flag = 1;
                }
                else if (tempfile == ")")
                {
                    classpart = ")";
                    Flag = 1;
                }
                else if (tempfile == "{")
                {
                    classpart = "{";
                    Flag = 1;
                }
                else if (tempfile == "}")
                {
                    classpart = "}";
                    Flag = 1;
                }
                else if (tempfile.ToLower() == "num" || tempfile.ToLower() == "real" || tempfile.ToLower() == "ch" || tempfile.ToLower() == "str")
                {
                    classpart = "DT";
                    Flag = 1;
                }
                else if (tempfile == "*" || tempfile == "/" || tempfile == "%")
                {
                    classpart = "AROP";
                    Flag = 1;
                }
                else if (tempfile == "+" || tempfile == "-")
                {
                    classpart = "AROP_ADDSUB";
                    Flag = 1;
                }
                else if (tempfile == "?")
                {
                    classpart = "TERMOP";
                    Flag = 1;
                }
                else if (tempfile == " ")
                {
                    classpart = "SPACE";
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

