using System;
using Dominio;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio.ServiceReference_1;


namespace InterfazWeb.PerfilAdmin
{
    public partial class EliminarGrupo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                PanelBuscarGrupo.Visible = true;
                PanelDatosGrupo.Visible = false;
                PanelMensaje.Visible = false;
            }
        }


        protected void Button_Eliminar_Grupo_Click(object sender, EventArgs e)
        {
            //Muestro los paneles
            PanelBuscarGrupo.Visible = false;
            PanelDatosGrupo.Visible = true;
            PanelMensaje.Visible = false;

            //Acciones
            LabelNombre.Text = DropDownListGruposAEliminar.SelectedValue;
        }

        protected void ButtonEliminarProveedor_Click(object sender, EventArgs e)
        {
            //Muestro los paneles
            PanelBuscarGrupo.Visible = false;
            PanelDatosGrupo.Visible = false;
            PanelMensaje.Visible = true;

            //Muestro el mensaje
            LabelMensaje.Text = "Grupos eliminado con éxito";
        }

        protected void ButtonCancelar_Click(object sender, EventArgs e)
        {
            //Muestro los paneles
            PanelBuscarGrupo.Visible = true;
            PanelDatosGrupo.Visible = false;
            PanelMensaje.Visible = false;
        }

        protected void Button_Eliminar_Otro_Click(object sender, EventArgs e)
        {
            //Muestro los paneles
            PanelBuscarGrupo.Visible = true;
            PanelDatosGrupo.Visible = false;
            PanelMensaje.Visible = false;
        }
    }
}