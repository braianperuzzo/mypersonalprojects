using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeuBlocoDeNotas
{
    public partial class frmInicio : Form
    {
        public frmInicio()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void SalvarClick(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void SalvarOK(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string sCaminho = saveFileDialog1.FileName;
            File.WriteAllText(sCaminho, txbJanela.Text);
        }

        private void SairClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AbrirClick(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void AbrirOK(object sender, CancelEventArgs e)
        {
            string sCaminho2 = openFileDialog1.FileName;
            using (FileStream fileStream = File.OpenRead(sCaminho2))
            {
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    string conteudo = reader.ReadToEnd();
                    txbJanela.Text = conteudo;
                }
            }
        }

        private void txbJanela_TextChanged(object sender, EventArgs e)
        {

        }
    }
}