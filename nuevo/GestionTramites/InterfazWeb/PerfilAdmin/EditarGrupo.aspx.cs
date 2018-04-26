using System;

namespace InterfazWeb.PerfilAdmin
{
    public partial class EditarGrupo : System.Web.UI.Page
    {
        //ServiceClient servicio = new ServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Muestro los paneles
            Panel_Seleccion_Grupo.Visible = true;
            Panel_Edicion_Grupo.Visible = false;

            //Cargo el combo de grupos
            cargarGrupos();
        }

        protected void cargarGrupos()
        {
            DropDownList_Grupos.Items.Clear();
            //DropDownList_Grupos.DataSource = servicio.WCFListarGrupos();
            DropDownList_Grupos.DataBind();
        }



        protected void combo_change(object sender, EventArgs e) {
            //Obtengo el seleccionado
            Label_CodigoGrupo.Text = DropDownList_Grupos.SelectedValue;
            TextBox_Nombre_Grupo.Text = DropDownList_Grupos.SelectedItem.Text;
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

        protected void Button_Guardar_Click(object sender, EventArgs e)
        {
            //Le paso los datos al WCF para que guarde los cambios
            //servicio.WCFEditGrupo();

            //Cargo nuevamente el combo
            cargarGrupos();

            //Muestro los paneles
            Panel_Seleccion_Grupo.Visible = true;
            Panel_Edicion_Grupo.Visible = false;
        }
    }
}