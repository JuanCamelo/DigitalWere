using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ClienteBO
    {

        /// <summary>
        /// Metodo donde se im plemeta la logica del negocio y registra un cliente
        /// </summary>
        /// <param name="ObjClient"></param>
        /// <returns></returns>
        internal bool AddClient(Entidades.Cliente ObjClient)
        {
            return FachadaPersistencia.Instancia.AddClient(ObjClient);
        }

        /// <summary>
        /// Metodo que sirve para actualizar el registro de un cliente
        /// </summary>
        /// <param name="ObjClient"></param>
        /// <returns></returns>
        internal bool UpdateCliete(Entidades.Cliente ObjClient, int Id)
        {
            return FachadaPersistencia.Instancia.UpdateClient(ObjClient, Id);
        }


        /// <summary>
        /// Metodo que sirve para consultar y recuperar dats de un cliente por Id 
        /// </summary>
        /// <param name="IdClient"></param>
        /// <returns></returns>
        internal Entidades.Cliente GetClientById(int IdClient)
        {
            return FachadaPersistencia.Instancia.GetClietById(IdClient);
        }

        /// <summary>
        /// medoto que elimina un registro de cliente por el Id
        /// </summary>
        /// <param name="IdClient"></param>
        /// <returns></returns>
        internal bool DeleteCliente(int IdClient)
        {
            return FachadaPersistencia.Instancia.DeleteClient(IdClient);
        }

        /// <summary>
        /// Metodo que recupera la lista de un cliente
        /// </summary>
        /// <returns></returns>
        internal List<Entidades.Cliente> ListaClient()
        {
            return FachadaPersistencia.Instancia.ListClient();
        }
    }
}
