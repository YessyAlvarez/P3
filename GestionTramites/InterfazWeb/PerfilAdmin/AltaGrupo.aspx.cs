using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Dominio.ServiceReference222;

namespace InterfazWeb.PerfilAdmin
{
    public partial class AltaGrupo : System.Web.UI.Page
    {
        ServiceClient a = new ServiceClient();

       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Despliego los paneles
                PanelAdd.Visible = true;
                PanelMsj.Visible = false;
                Label_MsjError.Visible = false;
            }
        }

        protected void Alta_crearGrupo_Click(object sender, EventArgs e)
        {
            //Obtengo el nombre del grupo ingresado
            string nombreGrupo = TextBox_NombreGrupo.Text;
            if(nombreGrupo.Length>0 && nombreGrupo != null)
            {
                if (a.WCFAddGrupo(nombreGrupo))
                {
                    /*
                >> muestro mensaje y limpio formulario
                */
                    //Despliego los paneles
                    PanelAdd.Visible = false;
                    PanelMsj.Visible = true;

                    LabelMensaje.Text = "Grupo creado con éxito.";
                    ButtonNewGrupo.Visible = true;
                }
                else
                {
                    /*
                >> muestro mensaje y limpio formulario
                */
                    //Despliego los paneles
                    PanelAdd.Visible = false;
                    PanelMsj.Visible = true;

                    LabelMensaje.Text = "Error al crear el formulario. Vuelva a intentarlo.";
                    ButtonNewGrupo.Visible = true;
                }
            }
            else
            {
                //Muestro error!!!
                Label_MsjError.Visible = true;
                Label_MsjError.Text = "Ingrese un nombre correcto!";

            }
        }

        protected void ButtonNewGrupo_Click(object sender, EventArgs e)
        {
            //Despliego los paneles
            PanelAdd.Visible = true;
            PanelMsj.Visible = false;
            TextBox_NombreGrupo.Text = "";
            Label_MsjError.Visible = false;
        }
    }
}