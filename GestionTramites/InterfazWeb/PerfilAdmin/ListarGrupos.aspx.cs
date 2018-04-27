using System;
using Dominio;

namespace InterfazWeb.Master
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        //ServiceClient a = new ServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              /*  ListBox_listaGrupos.Items.Clear();
                ListBox_listaGrupos.DataSource = a.WCFListarGrupos();
                ListBox_listaGrupos.DataBind();*/
                
            }
        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}