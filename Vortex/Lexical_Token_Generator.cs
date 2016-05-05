using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vortex
{
    public partial class Lexical_Token_Generator : Form
    {
        public Lexical_Token_Generator()
        {
            InitializeComponent();
        }

        private void TokGenBtn_Click(object sender, EventArgs e)
        {
            Lexical CS = new Lexical();
            CS.ReadCode(SourceTxtBox.Text);
            int count=0;
            Syntax.Tokens = new string[Convert.ToInt32(Lexical.Tokens.Count)]; //Declearing Array To Move tokens In it
            foreach (string element in Lexical.Tokens)  //Reading Tokens From TokensList Generated In Lexical Phase and writing it in Token Text Box
            {
                TokensTxtBox.Text = TokensTxtBox.Text + element + "\n";
                Syntax.Tokens[count] = element;
                count++;
            }
            Syntax stx = new Syntax();
            stx.CallingAndMatching();
            Lexical.Tokens.Clear();
        }
        private void SourceTxtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void TokensTxtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SourceTxtBox.Clear();
            TokensTxtBox.Clear();
        }
    }
}
