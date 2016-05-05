using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Vortex
{
    class Lexical
    {
        public static string classpart;
        int Flag = 0, OtherCheck = 0;
        string ValuePart, tempVar = null;
        int lineNumber = 1;
        string[] MultiOP = new string[] { "==", "+=", "-=", "*=", "/=", "&&", "||", "++", "--", ">=", "<=", "!=" };
        char[] ComOp = new char[] { '.', '\n', ' ', '!', '@', '#', '%', '^', '&', '*', '=', '(', ')', '-', '_', '+', '|', '\\', '}', ']', '{', '[', ',', ':', ';', '<', '>', '?', '/', '~', '`','$'};
        public static List<string> Tokens = new List<string>();
        List<char> SorChr = new List<char>();
        Regex REID = new Regex("(\\$*[A-Za-z]+)+[$A-Za-z0-9]*");              //RE FOR IDENTIFIER.
        Regex RERealCons = new Regex("([0-9]*\\.{1})+[0-9]+");                  //RE FOR RealCons.
        Regex REStrCons = new Regex("(\"){1}[a-zA-Z0-9\\S ]+(\"){1}");        //RE FOR StrCons.
        Regex RENumCons = new Regex("[0-9]+");                                //RE FOR NumCons.
        Regex REChCons = new Regex("(')?[a-zA-Z0-9 ]?(')?");                  // RE For CharConst

        public void ReadCode(string SourceCode)
        {
            foreach (char element in SourceCode)
            {
                SorChr.Add(element);
                if (element == '_' || OtherCheck == 1 || (SorChr[0] == '_' && SorChr[1] == '*'))        //Single Line and Multiy Line Comments
                {
                    if(Flag == 0)
                    {
                        Flag = 1;
                        continue;
                    }
                    else if(Flag == 1)
                    {
                        Flag = 2;
                        OtherCheck = 1;
                        continue;
                    }
                    if(element == '\n' && (SorChr[0] == '_' && SorChr[1] != '*'))
                    {
                        OtherCheck = 0;
                        Flag = 0;
                        lineNumber++;
                        SorChr.Clear();
                        continue;
                    }
                    if (SorChr[(SorChr.Count)-1] == '_' && SorChr[(SorChr.Count) - 2] == '*')
                    {
                        OtherCheck = 0;
                        Flag = 0;
                        lineNumber++;
                        SorChr.Clear();
                        continue;
                    }
                    continue;   
                }

                CodeMatching(element);


                //if(element == '.')
                //{
                //    if(Check == 1)
                //    {
                //        Check = 2;
                //        CodeMatching(element);
                //        continue;
                //    }
                //    else
                //    {
                //        Check = 1;
                //        continue;
                //    }
                //}
            }
            if(OtherCheck == 1)
            {
                SorChr.Clear();
            }

            if (tempVar != null && SorChr.Count == 1)
            {
                Flag = 0;
                ValuePart = tempVar;
                TokenMatching(ValuePart);
                string Token = ValuePart + "   ,   " + classpart + "   ,   " + Convert.ToString(lineNumber);
                Tokens.Add(Token);
                ValuePart = null;
                classpart = null;
                Flag = 0;
                SorChr.Clear();
                tempVar = null;
            }
            if (SorChr.Count > 0 && Flag != 1)
            {
                Flag = 0;
                do
                {
                    ValuePart = ValuePart + Convert.ToString(SorChr[Flag]);
                    Flag++;
                }
                while (Flag < SorChr.Count);
                Flag = 0;
                int Returnedvalue = RegularExpression(Flag);
                RegularExpressionTokenGeneration(Returnedvalue);
            }
        }


        public void CodeMatching(char element)
        {
            Flag = 0;
            if (element == '=' || element == '+' || element == '-' || element == '*' || element == '/' || element == '&' || element == '|' || element == '>' || element == '<' || element == '!')  //For Multiple Operators
            {
                if (tempVar != null)
                {
                    if (SorChr.Count >= 1)          //To Check With RE
                    {
                        Flag = 0;
                        do
                        {
                            ValuePart = ValuePart + Convert.ToString(SorChr[Flag]);
                            Flag++;
                        }
                        while (Flag < SorChr.Count - 2);
                        int Returnedvalue = RegularExpression(Flag);
                        if(Returnedvalue != 11)
                        {
                            string OldTemp = tempVar;
                            RegularExpressionTokenGeneration(Returnedvalue);
                            tempVar = OldTemp;
                        }
                    }
                    if ((element == Convert.ToChar(tempVar)) || (element != '!' && element != '*' && element != '/' && element != '>' && element != '<'))    //To match multiple operators
                    {
                        tempVar = tempVar + Convert.ToString(element);
                        foreach (string SearchElement in MultiOP)
                        {
                            if (SearchElement == tempVar)
                            {
                                Flag = 0;
                                ValuePart = tempVar;
                                TokenMatching(ValuePart);
                                string Token = ValuePart + "   ,   " + classpart + "   ,   " + Convert.ToString(lineNumber);
                                Tokens.Add(Token);
                                ValuePart = null;
                                classpart = null;
                                tempVar = null;
                                Flag = 0;
                                SorChr.Clear();
                                break;
                            }
                            else
                            {
                                Flag = 1;
                            }
                        }
                        if (Flag == 1 && SorChr.Count >= 1) /// Tstaments like *&
                        {
                            Flag = 0;
                            foreach (char value in tempVar)
                            {
                                if (Flag == 1)
                                {
                                    tempVar = Convert.ToString(value);
                                    SorChr.Add(value);
                                    break;
                                }
                                else
                                {
                                    ValuePart = Convert.ToString(value);
                                    Flag = 0;
                                    TokenMatching(ValuePart);
                                    string Token = ValuePart + "   ,   " + classpart + "   ,   " + Convert.ToString(lineNumber);
                                    Tokens.Add(Token);
                                    ValuePart = null;
                                    classpart = null;
                                    Flag = 1;
                                }
                            }
                            SorChr.Clear();
                        }
                    }
                    else                                    // for checking  like =! or like that
                    {
                        TokenMatching(ValuePart);
                        string Token = ValuePart + "   ,   " + classpart + "   ,   " + Convert.ToString(lineNumber);
                        Tokens.Add(Token);
                        ValuePart = null;
                        classpart = null;
                        tempVar = null;
                        tempVar = Convert.ToString(element);
                        SorChr.Clear();
                        SorChr.Add(element);
                    }
                }
                else
                {
                    tempVar = Convert.ToString(element);
                }
            }




            else
            {
                if ((tempVar == "=" || tempVar == "+" || tempVar == "-" || tempVar == "*" || tempVar == "/" || tempVar == "&" || tempVar == "|" || tempVar == ">" || tempVar == "<" || tempVar == "!") && SorChr.Count == 2) //to add the data in temp to tokens.
                {
                    ValuePart = tempVar;
                    TokenMatching(ValuePart);
                    string BreakerToken = ValuePart + "   ,   " + classpart + "   ,   " + Convert.ToString(lineNumber);
                    Tokens.Add(BreakerToken);
                    ValuePart = null;
                    classpart = null;
                    Flag = 0;
                    tempVar = null;
                    tempVar = Convert.ToString(SorChr[1]);
                    SorChr.Clear();
                    SorChr.Add(Convert.ToChar(tempVar));
                    tempVar = null;
                }
                else if (tempVar == "=" || tempVar == "+" || tempVar == "-" || tempVar == "*" || tempVar == "/" || tempVar == "&" || tempVar == "|" || tempVar == ">" || tempVar == "<" || tempVar == "!")  //print value in tempvar
                {
                    Flag = 0;
                    do
                    {
                        ValuePart = ValuePart + Convert.ToString(SorChr[Flag]);
                        Flag++;
                    }
                    while (Flag < SorChr.Count - 2);
                    int Returnedvalue = RegularExpression(Flag);
                    string OldTemp = tempVar;
                    RegularExpressionTokenGeneration(Returnedvalue);
                    tempVar = OldTemp;
                    ValuePart = Convert.ToString(tempVar);
                    TokenMatching(ValuePart);
                    string BreakerToken = ValuePart + "   ,   " + classpart + "   ,   " + Convert.ToString(lineNumber);
                    Tokens.Add(BreakerToken);
                    ValuePart = null;
                    classpart = null;
                    Flag = 0;
                    tempVar = null;
                    SorChr.Add(element);
                }




                foreach (char elementcheck in ComOp)                                     //Checks For Word Breaker
                {
                    if (element == elementcheck || OtherCheck == 2)
                    {
                        if (element == ' ')                                                        //for white space
                        {
                            Flag = 0;
                            do
                            {
                                ValuePart = ValuePart + Convert.ToString(SorChr[Flag]);
                                Flag++;
                            }
                            while (Flag < SorChr.Count - 1);

                            if (ValuePart == " ")
                            {
                                SorChr.Clear();
                                ValuePart = null;
                                Flag = 0;
                                break;
                            }
                            else
                            {
                                Flag = 0;
                                int Returnedvalue = RegularExpression(Flag);
                                RegularExpressionTokenGeneration(Returnedvalue);
                                break;
                            }
                        }


                        else if (OtherCheck == 2)                                       //For Real Numbers or Float Numbers
                        {

                            if (Convert.ToChar(SorChr[SorChr.Count - 2]) != '.')        //checking values before . and about previus .
                            {
                                Flag = 0;
                                do
                                {
                                    ValuePart = ValuePart + Convert.ToString(SorChr[Flag]);
                                    Flag++;
                                }
                                while (Flag < SorChr.Count - 1);
                                int Returnedvalue = RegularExpression(Flag);
                                RegularExpressionTokenGeneration(Returnedvalue);
                                SorChr.Add(element);
                                OtherCheck = 1;
                                break;
                            }
                            else if (OtherCheck == 2 && element == '.')                             // Checking .. used
                            {
                                Flag = 0;
                                do
                                {
                                    ValuePart = ValuePart + Convert.ToString(SorChr[Flag]);
                                    Flag++;
                                }
                                while (Flag < SorChr.Count - 2);
                                int Returnedvalue = RegularExpression(Flag);
                                RegularExpressionTokenGeneration(Returnedvalue);
                                ValuePart = Convert.ToString(element);
                                classpart = "DOT";
                                string BreakerToken = ValuePart + "   ,   " + classpart + "   ,   " + Convert.ToString(lineNumber);
                                Tokens.Add(BreakerToken);
                                ValuePart = null;
                                classpart = null;
                                Flag = 0;
                                tempVar = null;
                                SorChr.Add('.');
                                break;
                            }

                            else if (SorChr[SorChr.Count - 2] > 57 || SorChr[SorChr.Count - 2] < 48)             //chercking non numbers before .
                            {
                                Flag = 0;
                                do
                                {
                                    ValuePart = ValuePart + Convert.ToString(SorChr[Flag]);
                                    Flag++;
                                }
                                while (Flag < SorChr.Count - 1);
                                int Returnedvalue = RegularExpression(Flag);
                                RegularExpressionTokenGeneration(Returnedvalue);
                                SorChr.Add(element);
                                break;
                            }
                        }



                        else if (SorChr.Count == 1)                                               //Checking for Single Breaker
                        {
                            if (element == '\n')
                            {
                                lineNumber++;
                                SorChr.Clear();
                                break;
                            }
                            Flag = 0;
                            ValuePart = null;
                            ValuePart = Convert.ToString(element);
                            int Returnedvalue = RegularExpression(Flag);
                            if(Returnedvalue == 11)
                            {
                                Flag = 0;
                                TokenMatching(ValuePart);
                                if(classpart == "Not Found")
                                {
                                    string Token = ValuePart + "   ,  Invalid  ,   " + Convert.ToString(lineNumber);
                                    Tokens.Add(Token);
                                    ValuePart = null;
                                    classpart = null;
                                    Flag = 0;
                                    SorChr.Clear();
                                }
                                else
                                {
                                    string Token = ValuePart + "   ,   " + classpart + "   ,   " + Convert.ToString(lineNumber);
                                    Tokens.Add(Token);
                                    ValuePart = null;
                                    classpart = null;
                                    Flag = 0;
                                    SorChr.Clear();
                                }
                            }
                            else
                            {
                                RegularExpressionTokenGeneration(Returnedvalue);
                            }
                            break;
                        }

                        else
                        {
                            Flag = 0;
                            do
                            {
                                ValuePart = ValuePart + Convert.ToString(SorChr[Flag]);
                                Flag++;
                            }
                            while (Flag < SorChr.Count - 1);

                            Flag = 0;
                            int Returnedvalue = RegularExpression(Flag);
                            RegularExpressionTokenGeneration(Returnedvalue);
                            if (element == '\n')
                            {
                                lineNumber++;
                                break;
                            }
                            ValuePart = Convert.ToString(element);
                            TokenMatching(ValuePart);
                            if (classpart == "Not Found")
                            {
                                string BreakerToken = ValuePart + "   ,  Invalid  ,   " + Convert.ToString(lineNumber);
                                Tokens.Add(BreakerToken);
                                ValuePart = null;
                                classpart = null;
                                Flag = 0;
                                tempVar = null;
                                break;
                            }
                            else
                            {
                                string BreakerToken = ValuePart + "   ,   " + classpart + "   ,   " + Convert.ToString(lineNumber);
                                Tokens.Add(BreakerToken);
                                ValuePart = null;
                                classpart = null;
                                Flag = 0;
                                tempVar = null;
                                break;
                            }
                        }
                    }
                }
            }
        }

        public void RegularExpressionTokenGeneration(int Returnedvalue)
        {
            if (Returnedvalue == 2 || Returnedvalue == 4 || Returnedvalue == 6 || Returnedvalue == 8 || Returnedvalue == 10)      //IF ClassPart Found In Tokens
            {
                string Token = ValuePart + "   ,   " + classpart + "   ,   " + Convert.ToString(lineNumber);
                Tokens.Add(Token);
                ValuePart = null;
                classpart = null;
                Flag = 0;
                SorChr.Clear();
                tempVar = null;
            }
            else if (Returnedvalue == 1)
            {
                string Token = ValuePart + "   , ID ,   " + Convert.ToString(lineNumber);
                Tokens.Add(Token);
                ValuePart = null;
                classpart = null;
                Flag = 0;
                SorChr.Clear();
                tempVar = null;
            }
            else if (Returnedvalue == 3)
            {
                string Token = ValuePart + "   , REALCONS ,   " + Convert.ToString(lineNumber);
                Tokens.Add(Token);
                ValuePart = null;
                classpart = null;
                Flag = 0;
                SorChr.Clear();
                tempVar = null;
            }
            else if (Returnedvalue == 5)
            {
                string Token = ValuePart + "   , STRCONS ,   " + Convert.ToString(lineNumber);
                Tokens.Add(Token);
                ValuePart = null;
                classpart = null;
                Flag = 0;
                SorChr.Clear();
                tempVar = null;
            }
            else if (Returnedvalue == 7)
            {
                string Token = ValuePart + "   , NUMCONS ,   " + Convert.ToString(lineNumber);
                Tokens.Add(Token);
                ValuePart = null;
                classpart = null;
                Flag = 0;
                SorChr.Clear();
                tempVar = null;
            }
            else if (Returnedvalue == 9)
            {
                string Token = ValuePart + "   , CHCONS ,   " + Convert.ToString(lineNumber);
                Tokens.Add(Token);
                ValuePart = null;
                classpart = null;
                Flag = 0;
                SorChr.Clear();
                tempVar = null;
            }
            else if (Returnedvalue == 11)
            {
                classpart = "Invalid";
                string Token = ValuePart + "   ,   " + classpart + "   ,   " + Convert.ToString(lineNumber);
                Tokens.Add(Token);
                ValuePart = null;
                classpart = null;
                Flag = 0;
                SorChr.Clear();
                tempVar = null;

            }
        }



        public int RegularExpression(int Results)                                            //Matching Of RE
        {
            Flag = 0;
            Match MID = REID.Match(ValuePart);                                      //Identifer
            Match MRealCons = RERealCons.Match(ValuePart);                          //RealCons.
            Match MREStrCons = REStrCons.Match(ValuePart);                          //StrCons.
            Match MRENumCons = RENumCons.Match(ValuePart);                          //NumCons     
            Match MREChCons = REChCons.Match(ValuePart);                            //ChCons


            if (MID.Value == ValuePart)
            {
                TokenMatching(ValuePart);

                if (classpart == "Not Found")
                {
                    Results = 1;
                }
                else
                {
                    Results = 2;
                }
            }
            else if (MRealCons.Value == ValuePart)
            {
                TokenMatching(ValuePart);

                if (classpart == "Not Found")
                {
                    Results = 3;
                }
                else
                {
                    Results = 4;
                }
            }
            else if (MREStrCons.Value == ValuePart)
            {
                TokenMatching(ValuePart);

                if (classpart == "Not Found")
                {
                    Results = 5;
                }
                else
                {
                    Results = 6;
                }
            }
            else if (MRENumCons.Value == ValuePart)
            {
                TokenMatching(ValuePart);

                if (classpart == "Not Found")
                {
                    Results = 7;
                }
                else
                {
                    Results = 8;
                }
            }
            else if (MREChCons.Value == ValuePart)
            {
                TokenMatching(ValuePart);

                if (classpart == "Not Found")
                {
                    Results = 9;
                }
                else
                {
                    Results = 10;
                }
            }
            else
            {
                return 11;
            }
            return Results;
        }



        public void TokenMatching(string tempfile)                                         //Match Value Part With Tokens In DB
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
                else if (tempfile == "[")
                {
                    classpart = "[";
                    Flag = 1;
                }
                else if (tempfile == "]")
                {
                    classpart = "]";
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
                else if (tempfile == "for")
                {
                    classpart = "FORL";
                    Flag = 1;
                }
                else if (tempfile == "do")
                {
                    classpart = "DOUNL";
                    Flag = 1;
                }
                else if (tempfile == "until")
                {
                    classpart = "UNL";
                    Flag = 1;
                }
                else if (tempfile == "if")
                {
                    classpart = "IFORCONSTA";
                    Flag = 1;
                }
                else if (tempfile == "orif")
                {
                    classpart = "IFORCONSTA";
                    Flag = 1;
                }
                else if (tempfile == "or")
                {
                    classpart = "ORCONSTA";
                    Flag = 1;
                }
                else if (tempfile == "change")
                {
                    classpart = "SWITCH";
                    Flag = 1;
                }
                else if (tempfile == "class")
                {
                    classpart = "CLASS";
                    Flag = 1;
                }
                else if (tempfile == "general" || tempfile == "secret" || tempfile == "inherited")
                {
                    classpart = "ACCMOD";
                    Flag = 1;
                }
                else if (tempfile == "either")
                {
                    classpart = "CASE";
                    Flag = 1;
                }
                else if (tempfile == "neutral")
                {
                    classpart = "DEFAULT";
                    Flag = 1;
                }
                else if (tempfile == "--")
                {
                    classpart = "DECOP";
                    Flag = 1;
                }
                else if (tempfile == "++")
                {
                    classpart = "INCOP";
                    Flag = 1;
                }
                else if (tempfile.ToLower() == "+=" || tempfile.ToLower() == "-=" || tempfile.ToLower() == "/=" || tempfile.ToLower() == "*=")
                {
                    classpart = "ASS_OP";
                    Flag = 1;
                }
                else if (tempfile == "&&")
                {
                    classpart = "AND";
                    Flag = 1;
                }
                else if (tempfile == "||")
                {
                    classpart = "OR";
                    Flag = 1;
                }
                else if (tempfile == "!")
                {
                    classpart = "NOT";
                    Flag = 1;
                }
                else if (tempfile.ToLower() == "<" || tempfile.ToLower() == ">" || tempfile.ToLower() == "<=" || tempfile.ToLower() == ">=" || tempfile.ToLower() == "==" || tempfile.ToLower() == "!=")
                {
                    classpart = "REL_OP";
                    Flag = 1;
                }
                else if (tempfile == "=")
                {
                    classpart = "EQUAL";
                    Flag = 1;
                }
                else if (tempfile == ".")
                {
                    classpart = "DOT";
                    Flag = 1;
                }
                else if (tempfile == "_ _")
                {
                    classpart = "SINGLELC";
                    Flag = 1;
                }
                else if (tempfile == "_* *_")
                {
                    classpart = "MULTILC";
                    Flag = 1;
                }
                else if (tempfile == "?")
                {
                    classpart = "TERMINATOR";
                    Flag = 1;
                }
                else
                {
                    classpart = "Not Found";
                    Flag = 1;
                }
            }
        }
    }
}
