using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vortex
{
    class Syntax
    {
        //public static List<string> TokensPassed = new List<string>();
        public static string[] Tokens;
        String CurrentToken = null,Error;
        bool ClasspartCecking = false;
        public static int Count=0;
        public string PassingData = null;

        public string CallingAndMatching()
        {
            foreach(string Token in Tokens)
            {
                if (ClasspartCecking = Token.Contains("DT") == true) 
                {
                    Intialization();
                }
                else if (ClasspartCecking = Token.Contains("FORLOOP") == true)
                {
                    CurrentToken = "Hello";
                }
                else if (ClasspartCecking = Token.Contains("DOWLOOP") == true)
                {
                    CurrentToken = "Hello";
                }
                else if (ClasspartCecking = Token.Contains("WHILELOOP") == true)
                {
                    CurrentToken = "Hello";
                }
                else if (ClasspartCecking = Token.Contains("IFELSECST") == true)
                {
                    CurrentToken = "Hello";
                }
                else if (ClasspartCecking = Token.Contains("SWITCHCST") == true)
                {
                    CurrentToken = "Hello";
                }
                else if (ClasspartCecking = Token.Contains("ARRAY") == true)
                {
                    CurrentToken = "Hello";
                }
                else if (ClasspartCecking = Token.Contains("DO") == true)
                {
                    CurrentToken = "Hello";
                }

                else
                {
                    CurrentToken = "There is an error on Line Number";
                }
                Count++;
            }
            return CurrentToken;
        }

        public void Intialization()
        {
            if (Tokens[Count + 1].Contains("ID") == true)
            {
                Rules RulesClass = new Rules();
                if (RulesClass.InitRule() == true)
                {

                }
            }
            else
            {
                Error = "Syntax error";
            }
        }
    }
    class Rules : Syntax
        {
        public bool InitRule()          //Initaliazation Rule
        {
            if (Tokens[Count + 2].Contains("=") == true)
            {
                PassingData = Tokens[Count + 3];
                if (ConsRule(PassingData) == true)
                {

                }
                else
                {
                    return false;
                }

            }
            return false;
        }
        public bool ConsRule(string DataPassed)       //Rule For Constant checking
        {
            if(DataPassed.Contains("NUMCONS") == true)
            {
                return true;
            }
            if (DataPassed.Contains("REALCONS") == true)
            {
                return true;
            }
            if (DataPassed.Contains("STRCONS") == true)
            {
                return true;
            }
            if (DataPassed.Contains("CHCONS") == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}






