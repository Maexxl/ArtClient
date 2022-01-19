namespace ArtClient
{
    using DeepAI;
    using Newtonsoft.Json.Linq;
    using System.Net;
    using System.Threading;
    public partial class Form1 : Form
    {
        int selectedIndex;

        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedIndex = comboBox1.SelectedIndex;

            if (selectedIndex == 0)
            {
                textBox_style.Visible = false;
                button_style.Visible = false;
            }
            if (selectedIndex == 1)
            {
                textBox_style.Visible = true;
                button_style.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse Image Files",
                CheckFileExists = true,
                CheckPathExists = true,
                RestoreDirectory = true,
                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }
        private void button_save_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog saveFolderDialog1 = new FolderBrowserDialog();
            if (saveFolderDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = saveFolderDialog1.SelectedPath;
            }
        }

        private void button_action_Click(object sender, EventArgs e)
        {
            DeepAI_API api = new DeepAI_API(apiKey: "522bba4f-8592-4d4a-b09e-b461fe49fedd");

            if (selectedIndex == 0)
            {
                new Thread(delegate()
                {
                    Thread.CurrentThread.IsBackground = true;
                    StandardApiResponse resp = api.callStandardApi("deepdream", new
                    {
                        image = File.OpenRead(textBox1.Text),
                    });
                    JObject json = JObject.Parse(api.objectAsJsonString(resp));
                    saveImage(json);
                }).Start();
            }
            if (selectedIndex == 1)
            {
                new Thread(delegate()
                {
                    Thread.CurrentThread.IsBackground = true;
                    StandardApiResponse resp = api.callStandardApi("fast-style-transfer", new
                    {
                        content = File.OpenRead(textBox1.Text),
                        style = File.OpenRead(textBox_style.Text),
                    });
                    JObject json = JObject.Parse(api.objectAsJsonString(resp));
                    saveImage(json);
                }).Start();
            }
            start_progress_bar(5);
        }

        private void saveImage(JObject json)
        {
            string output_url = (string)json["output_url"];
            string[] subs = output_url.Split("/");
            string output_path = textBox2.Text + "/" + subs[4] + ".jpg";
            using (var client = new WebClient())
            {
                client.DownloadFile(output_url, output_path);
            }
            Invoke((MethodInvoker)delegate
            {
                end_progress_bar();
            });
            MessageBox.Show("Bild erfolgreich gespeichert");
        }

        private void button_style_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog2 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse Image Files",
                CheckFileExists = true,
                CheckPathExists = true,
                RestoreDirectory = true,
                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                textBox_style.Text = openFileDialog2.FileName;
            }
        }

        private void start_progress_bar(int speed)
        {
            progressBar1.Visible = true;
            progressBar1.MarqueeAnimationSpeed = speed;
        }
        private void end_progress_bar()
        {
            progressBar1.MarqueeAnimationSpeed = 0;
            progressBar1.Visible = false;
        }

    }
}