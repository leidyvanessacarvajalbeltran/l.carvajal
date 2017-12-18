using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using ServiceWebAPI_RA.Models;



namespace ServiceWebAPI_RA.Controllers
{
    public class ConnectionController : ApiController
    {
         ConnectionModel _ConnectionModel = new ConnectionModel();

        /*Valida el estado de la conexión con la BD y así garantizar la disponibilidad del servicio.*/
         public IHttpActionResult getTestConnection()
           {
               return Json(_ConnectionModel.TestConnection());
           }

        /*Consulta la información del estudiante mediante número de cédula para verificar si ya está registrado y devolver la infomamción*/
         [HttpGet]
         public IHttpActionResult ConsultarInformacion()
         {
             return Json(_ConnectionModel.getInformacionEstudiante());
         }

        /*Consulta el listado de ejercicios creados disponibles para desarrollar por parte del estudiante*/
         [HttpGet]
         public IHttpActionResult ConsultarEjercicios()
         {
             return Json(_ConnectionModel.ConsultarEjercicios());
         }

         [HttpGet]
         public IHttpActionResult ConsultarSolucion(string id_ejercicio)
         {
             return Json(_ConnectionModel.ConsultarSolucion(id_ejercicio));
         }

        /*Consulta los componentes asociados al ejercicio enviado.*/
         [HttpGet]
         public IHttpActionResult ConsultarComponente(int idtejercicio)
         {
             return Json(_ConnectionModel.getInformacionComponente(idtejercicio));
         }

        /*Guarda la información del estudiante*/
         [HttpPost]
         public IHttpActionResult GuardarInformacion(ServiceWebApi_RAObject obj)
         {
             return Json(_ConnectionModel.GuardarInformacion(obj.ESTU_ID,obj.identificacion,obj.Pnombre,obj.Snombre,obj.Papellido,obj.Sapellido,obj.correo));
         }

         [HttpPost]
         public IHttpActionResult GuardarEvaluacion(ServiceWebApi_RAObject obj)
         {
             return Json(_ConnectionModel.GuardarEvaluacion(obj.ESTU_ID, obj.ejer_id,obj.evaluacion));
         }



    }
        
        
}