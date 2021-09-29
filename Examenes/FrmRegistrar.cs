using ClasesActivos;
using ClasesActivos.Enums;
using ClasesActivos.Infraestructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examenes
{
    public partial class FrmRegistrar : Form
    {
       
        public ActivoModel activos{ get;set;}
        int a=0;
        public FrmRegistrar(int aa)
        {
            activos =new ActivoModel();
            this.a = aa;
            InitializeComponent();
        }
        
        private void FrmRegistrar_Load(object sender, EventArgs e)
        {
            cmbTipoActivo.Items.AddRange(Enum.GetValues(typeof(EnumsTipoActivo)).Cast<object>().ToArray());
            

        }

        private void TxtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("no se puede numeros");
            }
        }

        private void TxtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("no se puede numeros");
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
			if (String.IsNullOrWhiteSpace(txtNombre.Text)&&cmbdepreciacion.SelectedItem==null && String.IsNullOrWhiteSpace(txtCodigo.Text) && String.IsNullOrWhiteSpace(txtValorActivo.Text) && String.IsNullOrWhiteSpace(txtValorResidual.Text))
			{
                MessageBox.Show("La mayoria de estos parametros son obligatorios.");

                return;
			}
            
            ActivoFijo activo = new ActivoFijo()
            {
                Nombre = txtNombre.Text,
                
                codigo = txtCodigo.Text,
                descripcion = txtDescripcion.Text,
                FechaDeAdquisicion = dtpAdquision.Value,
                ValorActivo = decimal.Parse(txtValorActivo.Text),
                ValorResidual = decimal.Parse(txtValorResidual.Text),
                TipoActivo = (EnumsTipoActivo)cmbTipoActivo.SelectedIndex,
                depreciacion = (Depreciacion)cmbdepreciacion.SelectedIndex,
                Id = a     
                
            };
            activo.VidaUtil = activos.VidaUtil(activo.TipoActivo);
            activos.Add(activo);
            
            Dispose();
        }

        private void Cmbdepreciacion_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void CmbTipoActivo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

		private void txtValorActivo_TextChanged(object sender, EventArgs e)
		{
            
		}

		private void txtValorActivo_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (Char.IsLetter(e.KeyChar))
			{
                e.Handled = true;
                MessageBox.Show("No se pueden letras");
			}
		}
	}
}
