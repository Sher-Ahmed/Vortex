namespace Vortex
{
    partial class Lexical_Token_Generator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.SourceTxtBox = new System.Windows.Forms.RichTextBox();
            this.TokensTxtBox = new System.Windows.Forms.RichTextBox();
            this.TokGenBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Vortex.Properties.Resources.Logo;
            this.pictureBox1.Location = new System.Drawing.Point(338, -4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(237, 128);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // SourceTxtBox
            // 
            this.SourceTxtBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SourceTxtBox.Location = new System.Drawing.Point(13, 156);
            this.SourceTxtBox.Name = "SourceTxtBox";
            this.SourceTxtBox.Size = new System.Drawing.Size(431, 303);
            this.SourceTxtBox.TabIndex = 1;
            this.SourceTxtBox.Text = "";
            this.SourceTxtBox.TextChanged += new System.EventHandler(this.SourceTxtBox_TextChanged);
            // 
            // TokensTxtBox
            // 
            this.TokensTxtBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TokensTxtBox.Location = new System.Drawing.Point(470, 156);
            this.TokensTxtBox.Name = "TokensTxtBox";
            this.TokensTxtBox.Size = new System.Drawing.Size(431, 303);
            this.TokensTxtBox.TabIndex = 2;
            this.TokensTxtBox.Text = "";
            this.TokensTxtBox.TextChanged += new System.EventHandler(this.TokensTxtBox_TextChanged);
            // 
            // TokGenBtn
            // 
            this.TokGenBtn.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TokGenBtn.Location = new System.Drawing.Point(301, 465);
            this.TokGenBtn.Name = "TokGenBtn";
            this.TokGenBtn.Size = new System.Drawing.Size(157, 41);
            this.TokGenBtn.TabIndex = 3;
            this.TokGenBtn.Text = "Generate Tokens";
            this.TokGenBtn.UseVisualStyleBackColor = true;
            this.TokGenBtn.Click += new System.EventHandler(this.TokGenBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(156, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Source Code";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(654, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tokens";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(454, 465);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 41);
            this.button1.TabIndex = 6;
            this.button1.Text = "Clear All";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Lexical_Token_Generator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(913, 518);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TokGenBtn);
            this.Controls.Add(this.TokensTxtBox);
            this.Controls.Add(this.SourceTxtBox);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Lexical_Token_Generator";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lexical Analyzer";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox SourceTxtBox;
        private System.Windows.Forms.RichTextBox TokensTxtBox;
        private System.Windows.Forms.Button TokGenBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}

