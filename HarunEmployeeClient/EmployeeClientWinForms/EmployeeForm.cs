using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmployeeClientWinForms.Models;
using Newtonsoft.Json;

namespace EmployeeClientWinForms
{
    public partial class EmployeeForm : Form
    {
        private HttpClient client = new HttpClient();

        public EmployeeForm()
        {
            client.BaseAddress = new Uri("https://localhost:44378/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            InitializeComponent();
        }

        
        private async void EmployeeForm_Load(object sender, EventArgs e)
        {
            await List();
        }

        private async Task List()
        {
            HttpResponseMessage httpResponse = await client.GetAsync("api/Employees");
            httpResponse.EnsureSuccessStatusCode();
            var stringValue = await httpResponse.Content.ReadAsStringAsync();
            var movies = JsonConvert.DeserializeObject<List<Employee>>(stringValue);
            dgvEmployee.DataSource = movies;
        }

        private async void btnInsert_Click(object sender, EventArgs e)
        {
            var employee = new Employee
            {
                ID = Convert.ToInt32(tbID.Text),
                FirstName = tbFirstName.Text,
                LastName = tbLastName.Text,
                Email = tbEmail.Text,
                Phone = tbPhone.Text
            };
            var json = JsonConvert.SerializeObject(employee);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponse = await client.PostAsync("api/Employees", data);
            httpResponse.EnsureSuccessStatusCode();
            await List();
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            var employee = new Employee
            {
                ID = Convert.ToInt32(tbID.Text),
                FirstName = tbFirstName.Text,
                LastName = tbLastName.Text,
                Email = tbEmail.Text,
                Phone = tbPhone.Text
            };
            var json = JsonConvert.SerializeObject(employee);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var httpResponse = await client.PostAsync($"api/Employees/{employee.ID}", data);
            httpResponse.EnsureSuccessStatusCode();
            await List();
        }

        private void dgvEmployee_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            tbID.Text = dgvEmployee.Rows[e.RowIndex].Cells["ID"].Value.ToString();
            tbFirstName.Text = dgvEmployee.Rows[e.RowIndex].Cells["FirstName"].Value.ToString();
            tbLastName.Text = dgvEmployee.Rows[e.RowIndex].Cells["LastName"].Value.ToString();
            tbEmail.Text = dgvEmployee.Rows[e.RowIndex].Cells["Email"].Value.ToString();
            tbPhone.Text = dgvEmployee.Rows[e.RowIndex].Cells["Phone"].Value.ToString();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            HttpResponseMessage httpResponse = 
                await client.DeleteAsync($"api/Employees/{Convert.ToInt32(tbID.Text)}");
            MessageBox.Show(httpResponse.StatusCode.ToString());
            await List();
        }
    }
}
