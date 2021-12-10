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

namespace InterfazApi
{
    public partial class Lsitad : Form
    {
        HttpClient client;
        Random random;
        public Lsitad()
        {
            InitializeComponent();
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44352/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            random = new Random();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Agregar frm2 = new Agregar();
            frm2.Show();
            this.Close();
        }

        private async Task<Product> GetProduct()
        {
            Product product = null;
            int random_id = random.Next(1);
            HttpResponseMessage response = await client.GetAsync("api/products/"+random_id);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                product = JsonConvert.DeserializeObject<Product>(json);
            }
            return product;
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            Product product = await GetProduct();
            if(product != null)
            {
                pictureBox1.Load(product.url_image);
                label2.Text = product.code;
            }
        }

    }
}
