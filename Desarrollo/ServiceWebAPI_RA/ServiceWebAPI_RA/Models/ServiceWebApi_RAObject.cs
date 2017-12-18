using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceWebAPI_RA.Models
{
    public class ServiceWebApi_RAObject
    {
        public string ESTU_ID { get; set; }
        public string identificacion { get; set; }
        public string Pnombre { get; set; }
        public string Snombre { get; set; }
        public string Papellido { get; set; }
        public string Sapellido { get; set; }
        public string correo { get; set; }
        public string evaluacion { get; set; }
        public string ejer_id { get; set; }

        public ServiceWebApi_RAObject() { }
    }
}