﻿using InterfazWeb.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterfazWeb.PerfilFMantenimiento
{
    public partial class AltaTramite : System.Web.UI.Page
    {

        ServiceClient a = new ServiceClient();
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Muestro los paneles
                Panel_Paso1.Visible = true;
                Panel_Paso2.Visible = false;
                Panel_Msj.Visible = false;
            }
        }

        protected void Button_NewTramite_Click(object sender, EventArgs e)
        {
            //Hago los controles necesarios y llamo al WCF








            //Si todo OK
            //Muestro los paneles
            Panel_Paso1.Visible = false;
            Panel_Paso2.Visible = false;
            Panel_Msj.Visible = true;
            //Muestro los mensajes
            Label_Msj.Text = "Tramite creado con exito.";
        }

        protected void LinkButton_1_datos_Click(object sender, EventArgs e)
        {
            //Muestro los paneles
            Panel_Paso1.Visible = true;
            Panel_Paso2.Visible = false;
            Panel_Msj.Visible = false;
        }

        protected void LinkButton_2_add_grupos_Click(object sender, EventArgs e)
        {
            //Muestro los paneles
            Panel_Paso1.Visible = false;
            Panel_Paso2.Visible = true;
            Panel_Msj.Visible = false;
        }

        protected void Button_Siguiente_Click(object sender, EventArgs e)
        {
            //Muestro los paneles
            Panel_Paso1.Visible = false;
            Panel_Paso2.Visible = true;
            Panel_Msj.Visible = false;
        }

        protected void LinkButton_2_add_gruposP2_Click(object sender, EventArgs e)
        {
            //Muestro los paneles
            Panel_Paso1.Visible = false;
            Panel_Paso2.Visible = true;
            Panel_Msj.Visible = false;
        }

        protected void LinkButton_1_datos_P2_Click(object sender, EventArgs e)
        {
            //Muestro los paneles
            Panel_Paso1.Visible = true;
            Panel_Paso2.Visible = false;
            Panel_Msj.Visible = false;
        }

        
        protected void Button_NuevoTramite_Click(object sender, EventArgs e)
        {
            //Muestro los paneles
            Panel_Paso1.Visible = true;
            Panel_Paso2.Visible = false;
            Panel_Msj.Visible = false;
        }

        protected void Button_AgregarGrupo_Click(object sender, EventArgs e)
        {

        }
    }
}