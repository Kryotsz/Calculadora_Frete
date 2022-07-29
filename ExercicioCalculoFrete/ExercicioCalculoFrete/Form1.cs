using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExercicioCalculoFrete
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Cria a função pra calcular o frete
        void CalcularFrete()
        {
            // JEITO DO SOR
            //var frete = 0.0;
            //var total = 0.0;
            //var valor = 0.0;
            //string uf = cbxUf.Text;
            //valor = double.Parse(txtValor.Text);

            //if (valor > 1000.0)
            //    frete = 0;
            //else if (uf == "SP")
            //    frete = 5.0;
            //else if (uf == "RJ")
            //    frete = 10.0;
            //else if (uf == "AM")
            //    frete = 20.0;
            //else if (uf != "SP" && uf != "RJ" && uf != "AM")
            //    frete = 15.0;

            //total = valor + frete;

            //lblValorCompra.Text = valor.ToString("C");
            //lblFrete.Text = frete.ToString("C");
            //lblTotal.Text = total.ToString("C");

            // cria variavel frete com valor padrão 0
            decimal frete = 0M;

            // se o valor for vazio
            if (txtValor.Text == "")
            {
                // aparece a mensagem de erro
                MessageBox.Show("O campo Valor deve ser preenchido.",
                                "Erro",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                // retorna para que o usuário continue escrevendo
                return;
            }

            // se o estado for vazio
            if (cbxUf.Text == "")
            {
                // aparece a mensagem de erro
                MessageBox.Show("O campo Estado deve ser preenchido.",
                                "Erro",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                // retorna para que o usuário continue escrevendo
                return;
            }

            // se o valor for maior ou igual a 1000
            if (decimal.Parse(txtValor.Text)>=1000M)
            {
                // o frete é 0
                frete = 0M;
            }
            // se não, verifica se o estado é São Paulo
            else if (cbxUf.Text == "SP")
            {
                // se sim, o frete é 5.00
                frete = 5.00M;
            }
            // se o estado é Rio de Janeiro
            else if (cbxUf.Text == "RJ")
            {
                // o frete é 10.00
                frete = 10.00M;
            }
            // se o estado é Amazonas
            else if (cbxUf.Text == "AM")
            {
                // o frete é 20.00
                frete = 20.00M;
            }
            // se for qualquer outro estado
            else
            {
                // o frete é 15.00
                frete = 15.00M;
            }

            // mostrar o valor na label Valor da Compra
            lblValorCompra.Text = decimal.Parse(txtValor.Text).ToString("F2",CultureInfo.InvariantCulture);

            // mostrar o frete na label Frete
            lblFrete.Text = frete.ToString("F2",CultureInfo.InvariantCulture);

            // soma o valor e o frete e mostra o resultado na label Total
            lblTotal.Text = (decimal.Parse(txtValor.Text) + frete).ToString("F2",CultureInfo.InvariantCulture);
        }

        // Cria a função pra limpar campos
        void LimparCampos()
        {
            // limpa o campo Nome
            txtNome.Text=String.Empty;
            // limpa o campo Valor
            txtValor.Text=String.Empty;
            // limpa o campo Estado
            cbxUf.Text = String.Empty;
            // volta o campo Valor da Compra ao padrão
            lblValorCompra.Text = "________";
            // volta o campo Frete ao padrão
            lblFrete.Text = "________";
            // volta o campo Total ao padrão
            lblTotal.Text = "________";
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            // chama o método CalcularFrete
            CalcularFrete();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            // chama o método LimparCampos
            LimparCampos();
        }

        private void txtNome_KeyDown(object sender, KeyEventArgs e)
        {
            // quando pressionar Enter
            if (e.KeyCode == Keys.Enter)
            {
                // seleciona o campo Valor
                txtValor.Select();
            }
        }

        private void txtValor_KeyDown(object sender, KeyEventArgs e)
        {
            // quando pressionar Enter
            if (e.KeyCode == Keys.Enter)
            {
                // seleciona o campo Estado
                cbxUf.Select();
            }
        }

        private void cbxUf_KeyDown(object sender, KeyEventArgs e)
        {
            // quando pressionar Enter
            if (e.KeyCode == Keys.Enter)
            {
                // seleciona o botão Calcular
                btnCalcular.Select();
            }
        }
    }
}
