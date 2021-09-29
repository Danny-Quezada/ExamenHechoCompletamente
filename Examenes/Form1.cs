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
    public partial class Form1 : Form
    {
        private ActivoModel activoModel;
        int i=0;
        public Form1()
        {
            activoModel = new ActivoModel();
            InitializeComponent();
        }

        private void RtboxActivos_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            
        }

		private void btnNew_Click(object sender, EventArgs e)
		{
            i++;
            decimal[] a;
            FrmRegistrar registrar = new FrmRegistrar(i);
            registrar.activos = activoModel;
            registrar.ShowDialog();
            if (rtboxActivos.Text.Length > 0)
            {
                rtboxActivos.Text = String.Empty;
            }
           
            if (activoModel == null) {
                rtboxActivos.Text = "";
            }
            else
            {
                for (int i = 0; i < activoModel.activos.Length; i++)
                {

                    rtboxActivos.Text += $"{activoModel.activos[i].toString()}";
					if (activoModel.activos[i].depreciacion == Depreciacion.LineaRecta)
					{
                        a = activoModel.linearecta(activoModel.activos[i]);
                        for(int o=0; o < a.Length; o++)
						{
                            rtboxActivos.Text += $"Año {o+1} :{a[o]}{Environment.NewLine}";
						}
					}
					else
					{
                        a = activoModel.SDA(activoModel.activos[i]);
                        for (int o = 0; o < a.Length; o++)
                        {
                            rtboxActivos.Text += $"Año {o+1} : {a[o]}{Environment.NewLine}";
                        }

                    }
                }

            }

        

        }
	}
}
