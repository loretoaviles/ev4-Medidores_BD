using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MedidoresDatos;
using MedidoresDatos.DAL;

namespace Medidores_web
{
    public partial class AgregarPunto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                EstacionesServiciosDAL DAL = new EstacionesServiciosDAL();
                List<estacionServicio> estaciones = DAL.GetAll();
                
                foreach (estacionServicio E in estaciones)
                {
                    estacionDdl.Items.Add(E.idEstacion.ToString());
                }
            }
            
            
        }

        protected void ingresarPuntobtn_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                EstacionesServiciosDAL DAL = new EstacionesServiciosDAL();

                int idPuntoCarga = Convert.ToInt32(id.Text);
                int capacidad = Convert.ToInt32(capa.Text);
                int tipo = Convert.ToInt32(tipoRbl.SelectedValue);
                estacionServicio estacion = DAL.Buscar(Convert.ToInt32(estacionDdl.SelectedValue));
                String vida = vidaTxt.Text;

                PuntoCarga p = new PuntoCarga();
                p.IdPuntoCarga = idPuntoCarga;
                p.Capacidad = capacidad;
                p.Tipo = tipo;
                p.Vida = vida;
                p.idEstacionP = estacion.idEstacion;

                new PuntosCargaDAL().Add(p);

                mensajeLbl.Text = "Punto de carga ingresado";
                limpiar();

            }
        }

        private void limpiar()
        {
            id.Text = "";
            capa.Text = "";
            vidaTxt.Text = "";
            tipoRbl.SelectedIndex = 0;

        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            PuntosCargaDAL DAL = new PuntosCargaDAL();
            List<PuntoCarga> puntos = DAL.GetAll();
            foreach(PuntoCarga p in puntos)
            {
                if (p.IdPuntoCarga == Convert.ToInt32(id.Text))
                {
                    args.IsValid = false;
                }
            }

        }
    }
}