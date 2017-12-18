using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceWebAPI_RA.Models
{
   public class PAPROAD
    {
        public string Nombre { get; set; }
        public string Valor { get; set; }
        public SqlDbType Tipo { get; set; }
        public ParameterDirection Direccion { get; set; }
        public int Ubicacion { get; set; }
        public int Size { get; set; }

        /// <summary>
        /// Crea un parámetro para ser añadido a un OracleCommand cuando se ejecuta un procedimiento
        /// </summary>
        /// <param name="nombre">Nombre del parámetro</param>
        /// <param name="valor">Valor del parámetro</param>
        /// <param name="tipo">Tipo del parámetro. Valores permitidos: CURSOR, NUMBER, VARCHAR2, DATE, CLOB, BLOB</param>
        /// <param name="direccion">Indica si es de entrada o salida</param>
        public PAPROAD(string nombre, string valor, string tipo, ParameterDirection direccion, int size = 5000)
        {
            Nombre = nombre;
            Valor = valor;
            Tipo = OraTipo(tipo);
            Direccion = direccion;
            Size = size;
        }

        /// <summary>
        /// Crea un parámetro para ser añadido a un OracleCommand, para ejecutar instrucciones Insert, Update, Delete
        /// </summary>
        /// <param name="nombre">Nombre del parámetro</param>
        /// <param name="valor">Valor del parámetro</param>
        /// <param name="tipo">Tipo del parámetro. Valores permitidos: CURSOR, NUMBER, VARCHAR2, DATE, CLOB, BLOB</param>
        /// <param name="ubicacion">El parámetro se usa en un SQL determinado de una transacción</param>
        public PAPROAD(string nombre, string valor, string tipo, int ubicacion)
        {
            Nombre = nombre;
            Valor = valor;
            Tipo = OraTipo(tipo);
            Ubicacion = ubicacion;
        }

        private SqlDbType OraTipo(string tipo)
        {
            switch (tipo)
            {
                case "CURSOR":
                    return SqlDbType.Variant;
                case "TABLA":
                    return SqlDbType.Structured;
                case "NUMBER":
                    return SqlDbType.BigInt;
                case "VARCHAR2":
                    return SqlDbType.VarChar;
                case "NVARCHAR":
                    return SqlDbType.NVarChar;
                case "DATE":
                    return SqlDbType.DateTime;
                case "CHAR":
                    return SqlDbType.Char;
                case "CLOB":
                    return SqlDbType.Text;
                case "BLOB":
                    return SqlDbType.Binary;
                case "DECIMAL":
                    return SqlDbType.Decimal;
                default:
                    return SqlDbType.VarChar;
            }
        }


        
    }
}
