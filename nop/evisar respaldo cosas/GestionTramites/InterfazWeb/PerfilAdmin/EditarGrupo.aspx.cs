using System;
using Dominio;

namespace InterfazWeb.PerfilAdmin
{
    public partial class EditarGrupo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Panel_Seleccion_Grupo.Visible = true;
            Panel_Edicion_Grupo.Visible = false;
        }

        protected void combo_change(object sender, EventArgs e) {
            //Asigno el nombre del seleccionado
            TextBox_Nombre_Grupo.Text = DropDownList_Grupos.SelectedValue;
        }

        protected void Button_Editar_Grupo_Click(object sender, EventArgs e)
        {
            Panel_Seleccion_Grupo.Visible = false;
            Panel_Edicion_Grupo.Visible = true;
        }

        protected void Button_Cancelar_Click(object sender, EventArgs e)
        {
            Panel_Seleccion_Grupo.Visible = true;
            Panel_Edicion_Grupo.Visible = false;
        }










    }
}