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
            Lexical rs = new Lexical();             //To Call Lexical Class
            rs.ReadSource(SourceTxtBox.Text);       //Passing Source Text Box Data to Lexical class
            foreach(string element in Lexical.Tokens)  //Reading Tokens From TokensList Generated In Lexical Phase and writing it in Token Text Box
            {
               TokensTxtBox.Text = TokensTxtBox.Text + element + "\n";
            }
            
        }
        private void SourceTxtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void TokensTxtBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
