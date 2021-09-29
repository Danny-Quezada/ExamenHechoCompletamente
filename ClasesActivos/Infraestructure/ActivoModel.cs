using ClasesActivos.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesActivos.Infraestructure
{
    public class ActivoModel
    {
        public ActivoFijo[] activos { get; set; }

        public void Add(ActivoFijo Activo)
        {
            if (activos == null)
            {
                activos = new ActivoFijo[1];
                activos[0] = Activo;
            }
            else
            {
                ActivoFijo[] temp = new ActivoFijo[activos.Length + 1];
                Array.Copy(activos, temp, activos.Length);
                temp[temp.Length - 1] = Activo;
                activos = temp;
            }
        }
        public decimal[] SDA(ActivoFijo e)
        {
            int Suma = 0;
            decimal[] depreciacion = new decimal[e.VidaUtil];

            for (int i = 1; i <= e.VidaUtil; i++)
            {
                Suma += i;
            }
            for (int i = 0; i < e.VidaUtil; i++)
            {
                decimal a = (i + 1) * (e.ValorActivo - e.ValorResidual);

                decimal total = a / Suma;

                depreciacion[i] = total;
            }
            return depreciacion;
        }
        public decimal[] linearecta(ActivoFijo e)
        {
            decimal[] LineaRecta=new decimal[e.VidaUtil];
          for(int i=0; i < e.VidaUtil;i++)
			{
                decimal a = (e.ValorActivo - e.ValorResidual) / e.VidaUtil;
                LineaRecta[i] = a;
            }
            return LineaRecta;

        }
        public int VidaUtil(EnumsTipoActivo e)
        {
            int i = 0;
            if (e == Enums.EnumsTipoActivo.Edificio)
            {
                i = 20;
                
            }
            else if (e == EnumsTipoActivo.Vehiculo)
            {
                i = 5;
            }
            else if (e == EnumsTipoActivo.Maquinaria)
            {
                i = 3;
                
            }
            else if (e == EnumsTipoActivo.Mobiliaria)
			{
                i = 2;
			}
            else if (e == EnumsTipoActivo.EquipoComputo)
			{
                i = 1;
			}
            return i;
        }

    }
}