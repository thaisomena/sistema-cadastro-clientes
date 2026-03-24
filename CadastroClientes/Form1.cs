using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadastroClientes
{
    public partial class Form1 : Form
    {
        List<Cliente> clientes = new List<Cliente>();
        int linhaSelecionada = -1;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente(txtNome.Text, txtEmail.Text);

            clientes.Add(cliente);

            dataGridView1.Rows.Add(cliente.Nome, cliente.Email);

            txtNome.Clear();
            txtEmail.Clear();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index;

                // remove da lista
                clientes.RemoveAt(index);

                // remove da tabela
                dataGridView1.Rows.RemoveAt(index);

                linhaSelecionada = -1;
            }
            else
            {
                MessageBox.Show("Selecione um cliente para excluir.");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                linhaSelecionada = e.RowIndex;

                txtNome.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtEmail.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (linhaSelecionada >= 0)
            {
                // atualiza na lista
                clientes[linhaSelecionada].Nome = txtNome.Text;
                clientes[linhaSelecionada].Email = txtEmail.Text;

                // atualiza na tabela
                dataGridView1.Rows[linhaSelecionada].Cells[0].Value = txtNome.Text;
                dataGridView1.Rows[linhaSelecionada].Cells[1].Value = txtEmail.Text;

                txtNome.Clear();
                txtEmail.Clear();

                linhaSelecionada = -1;
            }
            else
            {
                MessageBox.Show("Selecione um cliente para editar.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
