﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MedidoresDatos;
using MedidoresDatos.DAL;

namespace Medidores_web
{
    public partial class VerEstaciones : System.Web.UI.Page
    {
        EstacionesServiciosDAL estacionesDAL = new EstacionesServiciosDAL();
        private void CargarTabla(List<estacionServicio> estaciones)
        {
            estacionesGrid.DataSource = estaciones;
            estacionesGrid.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTabla(estacionesDAL.GetAll());
            }
        }

        protected void estacionesGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "eliminar")
            {
                //obtengo rut seleccionado en la grilla
                String idAEliminar = e.CommandArgument.ToString();

                //busco si la estacion esta asociada a algun punto de carga
                if (estacionesDAL.Buscar(Convert.ToInt32(idAEliminar)).PuntoCarga.Count == 0)
                {

                    //elimino el rut de la lista
                    estacionesDAL.Remove(Convert.ToInt32(idAEliminar));
                    //actualiza la grilla
                    CargarTabla(estacionesDAL.GetAll());
                }
                else
                {
                    //no se puede
                    Response.Write("<script>alert('La estación tiene puntos de carga asociados')</script>");
                }




            }

        }
    }
}