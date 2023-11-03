
using USQLCSharpProject1;
using ConsoleApp1;
using static System.Reflection.Metadata.BlobBuilder;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {

        public static List<book> listbooks = new List<book>();
        private void start()
        {
            comboBox1.Items.AddRange(new object[] { "����� �� �������", "����� �� ������", "����� �� ��������" });
            hider();
            listbooks.Add(new book(1468, "�������", "����� � ���", 1867, 1));
            listbooks.Add(new book(1469, "�������", "���� ��������", 1877, 1));
            listbooks.Add(new book(1470, "�������", "���� ��������", 2023, 10));
        }

        public Form1()
        {
            InitializeComponent();
            start();

        }

        private void �������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hider();
            listView.Show();
            listView.Location = new System.Drawing.Point(0, 25);
            listView.Size = new System.Drawing.Size(1000, 450);
            listView.View = View.Details;
            listView.Columns.Add("��������", 75);
            listView.Columns.Add("�����", 150);
            listView.Columns.Add("��������", 150);
            listView.Columns.Add("���", 80);
            listView.Columns.Add("����������", 150);
            foreach (var book in listbooks)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                book.art.ToString(),
                book.author,
                book.naming,
                book.year.ToString(),
                book.colv.ToString()
                });

                listView.Items.Add(item);
            }


            this.Controls.Add(listView);
        }
        private void hider()
        {
            lbl.Hide();
            comboBox1.Hide();
            listView.Hide();
            listView.Clear();
            textBox1.Hide();
            textBox2.Hide();
            textBox3.Hide();
            textBox4.Hide();
            textBox5.Hide();
            textBox6.Hide();
            button1.Hide();
            button2.Hide();
        }
        private void ��������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hider();
            textBox1.Show();
            textBox2.Show();
            textBox3.Show();
            textBox4.Show();
            textBox5.Show();
            button1.Show();
            lbl.Show();
            lbl.Text = "������� �������, ������, ��������, ��� � ���-��";
            lbl.Location = new System.Drawing.Point(10, 30);
            lbl.AutoSize = true;
            Controls.Add(lbl);

        }

        private void �����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hider();
            comboBox1.Show();
            textBox6.Show();
            button2.Show();
        }

        public static void seesearch(List<book> seabooks)
        {
            if (seabooks.Count > 0)
            {
                foreach (var book in seabooks)
                {
                    MessageBox.Show($"�������: {book.art},{Environment.NewLine} �����: {book.author},{Environment.NewLine} ��������: {book.naming},{Environment.NewLine} ��� �������: {book.year},{Environment.NewLine} ���������� �����������: {book.colv}{Environment.NewLine}", "�������");
                }
            }
            else
            {
                MessageBox.Show($"����� �� �������", "�������");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            listbooks.Add(new book(int.Parse(textBox1.Text), textBox2.Text, textBox3.Text, int.Parse(textBox4.Text), int.Parse(textBox5.Text)));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "����� �� �������":
                    int art = int.Parse(textBox6.Text);
                    var seabooks = listbooks.FindAll(book => book.art == art);
                    seesearch(seabooks);
                    break;
                case "����� �� ������":
                    string author = textBox6.Text;
                    seabooks = listbooks.FindAll(book => book.author == author);
                    seesearch(seabooks);
                    break;
                case "����� �� ��������":
                    string naming = textBox6.Text;
                    seabooks = listbooks.FindAll(book => book.naming == naming);
                    seesearch(seabooks);
                    break;
                default:
                    Console.WriteLine("�������� �����. ���������� �����.");
                    break;
            }
        }
    }
}