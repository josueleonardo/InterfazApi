using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;

namespace InterfazApi
{
    public partial class Agregar : Form
    {
        HttpClient client;
        public Agregar()
        {
            InitializeComponent();
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44352/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            clearWindow();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clearWindow();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
            row.Cells[0].Value = textBox4.Text;
            row.Cells[1].Value = textBox5.Text;
            row.Cells[2].Value = numericUpDown1.Value;

            dataGridView1.Rows.Add(row);

            textBox5.Text = "";
            numericUpDown1.Value = 0;
            textBox4.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            Model model = new Model();

            product.name = textBox1.Text;
            product.code = textBox2.Text;
            product.url_image = textBox3.Text;



            for (int fila = 0; fila < dataGridView1.Rows.Count - 1; fila++)
            {
                model.value = dataGridView1.Rows[fila].Cells[0].Value.ToString();
                model.name = dataGridView1.Rows[fila].Cells[1].Value.ToString();
                //model.stock = Convert.ToInt32(dataGridView1.Rows[fila].Cells[2].Value);
                product.models.Add(model);
            }

            clearWindow();
        }

        private void clearWindow()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

            textBox4.Text = "";
            textBox5.Text = "";
            numericUpDown1.Value = 0;

            dataGridView1.Rows.Clear();
        }
    }
}
