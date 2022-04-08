using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CuadradosApp.Datos;
using CuadradosApp.Modelos;

namespace CuadradosApp.Windows
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void SalirToolStripButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        RepositorioDeCuadrados repo = new RepositorioDeCuadrados();
        private List<Cuadrado> lista;

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            lista = repo.GetLista();
            MostrarDatosEnGrilla();
            MostrarCantidadDeRegistros();

        }

        private void MostrarCantidadDeRegistros()
        {
            CantidadRegistrosLabel.Text = repo.GetCantidad().ToString();
        }

        private void MostrarDatosEnGrilla()
        {
            DatosDataGridView.Rows.Clear();
            foreach (var cuadrado in lista)
            {
                var r = CrearFila(DatosDataGridView);

                SetearFila(r, cuadrado);

                AgregarFila(DatosDataGridView, r);
            }
        }

        private void NuevoToolStripButton_Click(object sender, EventArgs e)
        {
            var frm = new frmCuadradoEdit();
            frm.Text = "Agregar un Cuadrado";
            var dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            var cuadrado = frm.GetCuadrado();
            repo.Agregar(cuadrado);

            var r = CrearFila(DatosDataGridView);

            SetearFila(r, cuadrado);

            AgregarFila(DatosDataGridView, r);
            MostrarCantidadDeRegistros();
        }

        //Método para crear una fila con divisiones
        public DataGridViewRow CrearFila(DataGridView grilla)
        {
            var r = new DataGridViewRow();
            r.CreateCells(grilla);
            return r;
        }

        //Método para setear o establecer lo que quiero mostra en Grilla
        public void SetearFila(DataGridViewRow r, Cuadrado c)
        {
            r.Cells[colLado.Index].Value = c.Lado;
            r.Cells[colSuperficie.Index].Value = c.GetSuperficie();
            r.Cells[colPerimetro.Index].Value = c.GetPerimetro();
            r.Tag = c; //guardando el objeto
        }

        //Método para agregar una fila a una grilla
        public void AgregarFila(DataGridView dataGridView, DataGridViewRow r)
        {
            dataGridView.Rows.Add(r);
        }

        private void BorrarToolStripButton_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count == 0)
            {
                return;
            }

            DialogResult dr = MessageBox.Show($"¿Desea borrar el registro seleccionado?",
                "Confirmar Baja",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No)
            {
                MessageBox.Show("Baja Cancelada", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var r = DatosDataGridView.SelectedRows[0];
            Cuadrado c = (Cuadrado) r.Tag;
            repo.Borrar(c);

            QuitarFila(DatosDataGridView, r);

            MostrarCantidadDeRegistros();
            MessageBox.Show("Registro dado de baja", "Mensaje",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void QuitarFila(DataGridView datosDataGridView, DataGridViewRow r)
        {
            datosDataGridView.Rows.Remove(r);
        }

        private void EditarToolStripButton_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count==0)
            {
                return;
            }

            var r = DatosDataGridView.SelectedRows[0];
            Cuadrado cuadrado = (Cuadrado) r.Tag;
            frmCuadradoEdit frm=new frmCuadradoEdit();
            frm.Text = "Editar un Cuadrado";
            frm.SetCuadrado(cuadrado);
            DialogResult dr = frm.ShowDialog(this);
            if (dr==DialogResult.Cancel)
            {
                return;
            }

            cuadrado = frm.GetCuadrado();
            SetearFila(r,cuadrado);
            MessageBox.Show("Registro Modificado", "Mensaje",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        
    }
}