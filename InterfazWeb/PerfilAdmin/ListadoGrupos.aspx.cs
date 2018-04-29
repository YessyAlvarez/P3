using System;

namespace InterfazWeb.Master
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        //ServiceClient servicio = new ServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListBox_listaGrupos.Items.Clear();
                //ListBox_listaGrupos.DataSource = servicio.WCFListarGrupos();
                ListBox_listaGrupos.DataBind();
                
            }
        }

        
    }
}