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
    public partial class AgregarEstacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ingresarEstacionbtn_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int idEstacion = Convert.ToInt32(id.Text);
                int capacidad = Convert.ToInt32(capa.Text);
                String direccion = direccionTxt.Text;
                String region = regionTxt.Text;
                String horaInicio = horaInicioTxt.Text;
                String horaTermino = horaTerminoTxt.Text;

                estacionServicio s = new estacionServicio();
                s.idEstacion = idEstacion;
                s.Capacidad = capacidad;
                s.Direccion = direccion;
                s.Region = region;
                s.HorarioInicio = horaInicio;
                s.HorarioTermino = horaTermino;

                new EstacionesServiciosDAL().Add(s);
                mensajeLbl.Text = "Estacion de Servicio ingresado";
                limpiar();
            }
        }
        private void limpiar()
        {
            id.Text = "";
            capa.Text = "";
            direccionTxt.Text = "";
            regionTxt.Text = "";
            horaInicioTxt.Text = "";
            horaTerminoTxt.Text = "";
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            EstacionesServiciosDAL DAL = new EstacionesServiciosDAL();
            List<estacionServicio> estaciones = DAL.GetAll();
            foreach (estacionServicio e in estaciones)
            {
                if (e.idEstacion == Convert.ToInt32(id.Text))
                {
                    args.IsValid = false;
                }
            }
        }
    }
}