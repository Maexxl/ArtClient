namespace ArtClient
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.browse_one = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button_action = new System.Windows.Forms.Button();
            this.button_style = new System.Windows.Forms.Button();
            this.textBox_style = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Deep Dream ",
            "Style Transfer"});
            this.comboBox1.Location = new System.Drawing.Point(41, 27);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(151, 28);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // browse_one
            // 
            this.browse_one.Location = new System.Drawing.Point(492, 82);
            this.browse_one.Name = "browse_one";
            this.browse_one.Size = new System.Drawing.Size(150, 27);
            this.browse_one.TabIndex = 1;
            this.browse_one.Text = "Bild auswählen";
            this.browse_one.UseVisualStyleBackColor = true;
            this.browse_one.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(41, 82);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(415, 27);
            this.textBox1.TabIndex = 2;
            // 
            // button_action
            // 
            this.button_action.Location = new System.Drawing.Point(41, 204);
            this.button_action.Name = "button_action";
            this.button_action.Size = new System.Drawing.Size(150, 30);
            this.button_action.TabIndex = 3;
            this.button_action.Text = "Verarbeiten";
            this.button_action.UseVisualStyleBackColor = true;
            this.button_action.Click += new System.EventHandler(this.button_action_Click);
            // 
            // button_style
            // 
            this.button_style.Location = new System.Drawing.Point(492, 141);
            this.button_style.Name = "button_style";
            this.button_style.Size = new System.Drawing.Size(150, 27);
            this.button_style.TabIndex = 6;
            this.button_style.Text = "Style auswählen";
            this.button_style.UseVisualStyleBackColor = true;
            this.button_style.Visible = false;
            this.button_style.Click += new System.EventHandler(this.button_style_Click);
            // 
            // textBox_style
            // 
            this.textBox_style.Location = new System.Drawing.Point(41, 141);
            this.textBox_style.Name = "textBox_style";
            this.textBox_style.Size = new System.Drawing.Size(415, 27);
            this.textBox_style.TabIndex = 7;
            this.textBox_style.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(41, 254);
            this.progressBar1.MarqueeAnimationSpeed = 0;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(415, 29);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 8;
            this.progressBar1.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 313);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.textBox_style);
            this.Controls.Add(this.button_style);
            this.Controls.Add(this.button_action);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.browse_one);
            this.Controls.Add(this.comboBox1);
            this.Name = "Form1";
            this.Text = "ArtClient";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox comboBox1;
        private Button browse_one;
        private TextBox textBox1;
        private Button button_action;
        private Button button_style;
        private TextBox textBox_style;
        private ProgressBar progressBar1;
    }
}