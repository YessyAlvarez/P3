﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.ServiceReference;

namespace Dominio
{
    public class GestionTramites
    {

             

        #region GRUPOS

        public Boolean AddGrupo(string nombreGrupo) {
            //Verifico que no hay aotro repetido antes de mandarlo al Servicio web?
            Boolean retorno = true;
            //Llamo al ws
            //retorno = a.AddGrupo(nombreGrupo);
            return retorno;
        }

        #endregion


        #region USUARIO

        public void AddUsuario(string usuario, string NombreCompleto, EnumRol rol)
        {
            /* Usuario user = new Usuario(usuario, NombreCompleto, rol);
             ListaUsuarios.Add(user);
             ClinicaMedica.Serializar();*/
        }

        public EnumRol ValidarUsuario(string usuario, string password)
        {
            return Usuario.ObtenerRol(usuario, password); ;
        }


        public string GetNombreCompleto(string usuarioIngresado)
        {
            string nombrecompleto = "";
            /*if (ListaUsuarios.Count > 0)
            {
                foreach (Usuario usuario in ListaUsuarios)
                {
                    if (usuario.User == usuarioIngresado)
                    {
                        nombrecompleto = usuario.NombreCompleto;
                    }
                }
            }*/
            return nombrecompleto;
        }

        #endregion

        public static void generarTxtProveedores() {
            //Cargar la lista de Proveedores
            List<Proveedor> proveedores = Proveedor.ObtenerAllProveedores();

            //Crear o reemplazar el archivo
            //string path = @"C:\Users\Diseño\Desktop\proveedores.txt";
            /*if (File.Exists(path)) {
                File.Delete(path);
            }
            File.Create(path).Close();

            //Cargar Servicios al proveedor
            foreach (Proveedor p in proveedores) {
                p.ListaServicios = ProveedorServicio.traerServiciosProveedor(p.RUT);
            }
            //Crear string
            
            TextWriter tw = new StreamWriter(path);

            
            foreach (Proveedor p in proveedores) {
                string textoArchivo = null;
                textoArchivo += p.ToString2();
                foreach (ProveedorServicio s in p.ListaServicios) {
                    textoArchivo += s.ToString2();
                }
                tw.WriteLine(textoArchivo);
            }
            tw.Close();
        }
        public static void generarTxtServicios() {
       /*     List<Servicio> servicios = Servicio.ObtenerServiciosConTipoEvento();

            //Crear o reemplazar el archivo
            string path = @"C:\Users\IEUser\Desktop\proveedores.txt";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            File.Create(path);
            TextWriter tw = new StreamWriter(path);
           
                string textoArchivo = null;
                textoArchivo += s.ToString2();
            
                tw.WriteLine(textoArchivo);
            }
            tw.Close();
            foreach (Servicio s in servicios) {

            }
            */
        }

      
    }
}