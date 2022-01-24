namespace ArtClient
{
    using DeepAI;
    using Newtonsoft.Json.Linq;
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

        private void button_action_Click(object sender, EventArgs e)
        {
            DeepAI_API api = new DeepAI_API(apiKey: "522bba4f-8592-4d4a-b09e-b461fe49fedd");

            if (selectedIndex == 0)
            {
                Thread thread = new Thread(delegate ()
                {
                    StandardApiResponse resp = api.callStandardApi("deepdream", new
                    {
                        image = File.OpenRead(textBox1.Text),
                    });
                    JObject json = JObject.Parse(api.objectAsJsonString(resp));
                    string output_url = get_output_url(json);
                    Invoke((MethodInvoker)delegate
                    {
                        end_progress_bar();
                    });
                    Form form2 = new Form2(output_url);
                    form2.ShowDialog();
                });
                thread.SetApartmentState(ApartmentState.STA);
                thread.IsBackground = true;
                thread.Start();
            }

            if (selectedIndex == 1)
            {
                Thread thread = new Thread(delegate ()
                {
                    StandardApiResponse resp = api.callStandardApi("fast-style-transfer", new
                    {
                        content = File.OpenRead(textBox1.Text),
                        style = File.OpenRead(textBox_style.Text),
                    });
                    JObject json = JObject.Parse(api.objectAsJsonString(resp));
                    string output_url = get_output_url(json);
                    Invoke((MethodInvoker)delegate
                    {
                        end_progress_bar();
                    });
                    Form form2 = new Form2(output_url);
                    form2.ShowDialog();
                });
                thread.SetApartmentState(ApartmentState.STA);
                thread.IsBackground = true;
                thread.Start();
            }
            start_progress_bar(5);
        }

        private string get_output_url(JObject json)
        {
            string output_url = (string)json["output_url"];
            return output_url;
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
                ShowReadOnly = true,
                Filter = "All files (*.*)|*.*",
                FilterIndex = 0,
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