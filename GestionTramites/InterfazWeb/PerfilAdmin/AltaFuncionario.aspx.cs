using System;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using InterfazWeb.ServiceReference;

namespace InterfazWeb.PerfilAdmin
{
    public partial class AltaProveedor : System.Web.UI.Page
    {
        ServiceClient servicio = new ServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Muestro los paneles
            PanelStep_Datos.Visible = true;
            PanelStep_Grupos.Visible = false;
            PanelStep_Mensaje.Visible = false;

            

            //Cargo el combo de grupos
            cargarGrupos();
        }


        protected void cargarGrupos()
        {
            List<DTOGrupo> grupos = servicio.WCFListarGrupos();
            if (grupos != null){
                DropDownList_Grupos.Items.Clear();
                DropDownList_Grupos.DataSource = grupos;
                DropDownList_Grupos.DataBind();

                //Despliego acciones para grupos
                Label_MsjSinGrupos.Text = "Sin grupos asignados";
                ListBox_GruposAsignados.Visible = false;
            }
            else
            {
                Label_MsjSinGrupos.Text = "No hay grupos disponibles por el momento.";
                ListBox_GruposAsignados.Visible = false;
                DropDownList_Grupos.Visible = false;
            }

            
        }

        protected void ButtonSiguiente_Click(object sender, EventArgs e)
        {
            //Muestro los paneles
            PanelStep_Datos.Visible = false;
            PanelStep_Grupos.Visible = true;
            PanelStep_Mensaje.Visible = false;
        }

        protected void LinkButton_1_1_Datos_Click(object sender, EventArgs e)
        {
            //Muestro los paneles
            PanelStep_Datos.Visible = true;
            PanelStep_Grupos.Visible = false;
            PanelStep_Mensaje.Visible = false;
        }

        protected void LinkButton_1_2_Grupos_Click(object sender, EventArgs e)
        {
            //Muestro los paneles
            PanelStep_Datos.Visible = false;
            PanelStep_Grupos.Visible = true;
            PanelStep_Mensaje.Visible = false;
        }

        protected void LinkButton_2_1_Datos_Click(object sender, EventArgs e)
        {
            //Muestro los paneles
            PanelStep_Datos.Visible = true;
            PanelStep_Grupos.Visible = false;
            PanelStep_Mensaje.Visible = false;
        }

        protected void LinkButton_2_2_Datos_Click(object sender, EventArgs e)
        {
            //Muestro los paneles
            PanelStep_Datos.Visible = false;
            PanelStep_Grupos.Visible = true;
            PanelStep_Mensaje.Visible = false;
        }

        protected void Button_Anterior_Click(object sender, EventArgs e)
        {
            //Muestro los paneles
            PanelStep_Datos.Visible = true;
            PanelStep_Grupos.Visible = false;
            PanelStep_Mensaje.Visible = false;
        }

        protected void Button_AltaFuncionario_Click(object sender, EventArgs e)
        {
            //Hago los controles necesarios
            if (this.Validaciones_Campos())
            {
                //Si todo OK llamo al WCF
                string email = TextBox_Email.Text;
                string password = TextBox_Password.Text;
                string nombreCompleto = TextBox_NombreCompleto.Text;
                List<int> grupo = new List<int>();

            
                /*   if (a.WCFAddTramite(titulo, desc, costo, tiempo, null))
                   {
                       //Si todo OK

                       //Muestro los paneles
                       Panel_Paso1.Visible = false;
                       Panel_Paso2.Visible = false;
                       Panel_Msj.Visible = true;
                       //Muestro los mensajes
                       Label_Msj.Text = "Tramite creado con exito.";
                   }
                   else
                   {
                       //Si hay un error al cargar el tramite en la base
                       //Muestro los paneles
                       Panel_Paso1.Visible = false;
                       Panel_Paso2.Visible = false;
                       Panel_Msj.Visible = true;
                       //Muestro los mensajes
                       Label_Msj.Text = "NO SE PUDO CARGAR EL TRAMITE. INTENTE NUEVAMENTE.";
                   }

                */
            }
        }

        public bool Validaciones_Campos()
        {
            bool ok = false;
            //Limpio los mensajes de validación
            Label_ErrorEmail.Text = "";
            Label_ErrorPassword.Text = "";
            Label_ErrorNombre.Text = "";

            //Realizo las validaciones
            int cont = 0;
            string email = TextBox_Email.Text;
            string password = TextBox_Password.Text;
            string nombreCompleto = TextBox_NombreCompleto.Text;
            if (email.Length == 0)
            {
                Label_ErrorEmail.Text = "El email no puede ser vacio";
                cont++;
            }
            else if (!email.Contains("@") || !email.Contains("."))
            {
                Label_ErrorEmail.Text = "El email debe contener un @ y al menos un .";
                cont++;
            }
            if(password.Length == 0)
            {
                Label_ErrorPassword.Text = "La contraseña no puede ser vacía";
                cont++;
            }
            if (nombreCompleto.Length == 0)
            {
                Label_ErrorNombre.Text = "Debe ingresar el nombre completo";
                cont++;
            }
            if (cont == 0)
            {
                ok = true;
            }

            
            /*
            else if (a.WCFExisteNombreTramite(tituloTramite))
            {
                Label_Titulo_Error.Text = "El nombre del tramite ya existe. Ingrese uno nuevo.";
            }
            //Realizo las otras validaciones
            //
            //
            //
            //*/

            return ok;
        }

        
    }
}