using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Dominio.ServiceReference_1;


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

                //Cargo el combo de Grupos
                DropDownList_Grupos.Items.Clear();
                DropDownList_Grupos.DataSource = a.WCFGetGrupo();
                DropDownList_Grupos.DataBind();
            }
        }


        public bool Validaciones_Campos()
        {
            bool ok = false;
            string tituloTramite = TextBox_Titulo.Text;
            if (tituloTramite.Length == 0)
            {
                Label_Titulo_Error.Text = "El nombre del tramite no puede ser vacio";
            }
            else if (a.WCFExisteNombreTramite(tituloTramite))
            {
                Label_Titulo_Error.Text = "El nombre del tramite ya existe. Ingrese uno nuevo.";
            }
            //Realizo las otras validaciones
            //
            //
            //
            //

            return ok;
        }


        protected void Button_NewTramite_Click(object sender, EventArgs e)
        {
            //Hago los controles necesarios
            if (this.Validaciones_Campos())
            {
                //Si todo OK llamo al WCF
                String titulo = TextBox_Titulo.Text;
                string desc = TextBox_Descripcion.Text;
                double costo = Convert.ToDouble(TextBox_Costo.Text);
                int tiempo = Convert.ToInt32(TextBox_Tiempo.Text);
                //List<GrupoTramite> grupo_tramites = null;


                if (a.WCFAddTramite(titulo, desc, costo, tiempo, null))
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




            }
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
            //Obtengo el id del grupo Seleccionado y obtengo el grupo
            int idSeleccionado = Convert.ToInt32(DropDownList_Grupos.SelectedValue);
            Dominio.Grupo grupo = a.WCFObtenerGrupoPorId(idSeleccionado);
            //Creo el objeto a agregar al listado



            GrupoTramite gt = new GrupoTramite();





            //Agrego el grupo seleccionado a la lista
            
            //Cargo los datos a mostrar
            ListBox_GruposAgregados.Text = DropDownList_Grupos.SelectedItem.ToString();
            if (Servicio.FindTipoEventoFroServicio(idSeleccionado).Count > 0)
            {
                ListBoxServicios.Visible = true;
                ListBoxServicios.Items.Clear();
                ListBoxServicios.DataSource = Servicio.FindTipoEventoFroServicio(idSeleccionado);
                ListBoxServicios.DataBind();
                LabelVacioTipoEvento.Text = "";
            }
        }
    }
}