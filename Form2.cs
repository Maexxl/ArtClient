using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArtClient
{
    using System.Net;
    public partial class Form2 : Form
    {
        string output_url;
        public Form2(string output_url)
        {
            InitializeComponent();
            this.output_url = output_url;
            pictureBox1.ImageLocation = output_url;
        }

        private void button1_save_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog2 = new SaveFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Save Image File",
                CheckFileExists = false,
                OverwritePrompt = true,
                CheckPathExists = true,
                DefaultExt = "jpg",
                Filter = "Image file (*.jpg)|*.jpg",
                FilterIndex = 0,
                RestoreDirectory = true,
                FileName = get_image_name(output_url),
            };

            if (saveFileDialog2.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(saveFileDialog2.FileName);
            }
        }

        private string get_image_name(string output_url)
        {
            string[] subs = output_url.Split("/");
            return subs[4];
        }
    }
}
