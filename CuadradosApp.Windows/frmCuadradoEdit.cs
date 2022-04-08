using System;
using System.Windows.Forms;
using CuadradosApp.Modelos;

namespace CuadradosApp.Windows
{
    public partial class frmCuadradoEdit : Form
    {
        private Cuadrado cuadrado;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (cuadrado!=null)
            {
                LadoTextBox.Text = cuadrado.Lado.ToString();
            }
        }

        public frmCuadradoEdit()
        {
            InitializeComponent();
        }

        private void CancelarButton_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        
        private void OkButton_Click(object sender, System.EventArgs e)
        {
            if (ValidarDatos())
            {
                if (cuadrado == null)
                {
                    cuadrado = new Cuadrado();
                }

                cuadrado.Lado = int.Parse(LadoTextBox.Text);
                if (!cuadrado.Validar())
                {
                    errorProvider1.SetError(LadoTextBox,"Lado no válido, debe ser mayor a 0");
                    return;
                }
                this.DialogResult = DialogResult.OK; 
            }
        }

        public bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (!int.TryParse(LadoTextBox.Text,out int lado))
            {
                valido= false;
                errorProvider1.SetError(LadoTextBox,"Lado no válido");
            }

            return valido;
        }

        public Cuadrado GetCuadrado()
        {
            return cuadrado;
        }

        public  void SetCuadrado(Cuadrado cuadrado)
        {
           this.cuadrado = cuadrado;
        }

       
    }
}
