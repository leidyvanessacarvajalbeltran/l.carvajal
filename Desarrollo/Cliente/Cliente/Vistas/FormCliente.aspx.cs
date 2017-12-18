using Cliente.General;
using Ext.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cliente.Vistas
{
    public partial class FormCliente : System.Web.UI.Page
    {
        ConsumoREST co = new ConsumoREST();
        protected void Page_Load(object sender, EventArgs e)
        {

            consultaEstudiantes();            

        }


        public void consultaEstudiantes()
        {
            //DataTable dt = co.consultar("http://localhost:11877/api/Connection/ConsultarInformacion"); /*Servidor Local*/
            DataTable dt = co.consultar("http://169.60.149.178/ServiceRA/api/Connection/ConsultarInformacion"); /*Servidor BLUEMIX*/

            S_datos.DataSource = dt;
            S_datos.DataBind();
        }

        protected void registrar(object sender, DirectEventArgs e) 
        {
            string Proceso = string.Empty;
            var datos = (JObject)JsonConvert.DeserializeObject(e.ExtraParams["datosPersona"]);


            //co.registrar("http://localhost:11877/api/Connection/GuardarInformacion/", datos["txt_ESTU_ID"].ToString(), datos["txt_doc"].ToString(), datos["txt_pnomb"].ToString(), datos["txt_snomb"].ToString(), datos["txt_papell"].ToString(), datos["txt_sapell"].ToString(), datos["txt_corre"].ToString());
            co.registrar("http://169.60.149.178/api/Connection/GuardarInformacion/", datos["txt_ESTU_ID"].ToString(), datos["txt_doc"].ToString(), datos["txt_pnomb"].ToString(), datos["txt_snomb"].ToString(), datos["txt_papell"].ToString(), datos["txt_sapell"].ToString(), datos["txt_corre"].ToString());
            consultaEstudiantes();
        }
    }
}