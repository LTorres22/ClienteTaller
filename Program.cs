using ClienteTaller.Comunicacion;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteTaller
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Ingrese el puerto:");
            int puerto = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese la IP:");
            string servidor = Console.ReadLine();

            Console.WriteLine("Conectado a Servidor {0} en puerto {1}", servidor, puerto);
            ClienteSocket clienteSocket = new ClienteSocket(servidor, puerto);

            bool Validacion = true;

            if (clienteSocket.conectar())
            {
                Console.WriteLine("Conectado");
                do
                {
                    string mensaje = clienteSocket.Leer();
                    Console.WriteLine("Mensaje del Servidor: {0}", mensaje);
                    string respuesta = Console.ReadLine().Trim();
                    clienteSocket.Escribir(respuesta);

                    mensaje = clienteSocket.Leer();
                    Console.WriteLine("Mensaje del Servidor: {0}", mensaje);

                    if (mensaje == "chao")
                    {
                        clienteSocket.Escribir("El cliente se retira.");
                        clienteSocket.Desconectar();
                        Validacion = false;
                    }
                } while (Validacion);                
            } 
            else
            {
                Console.WriteLine("Error de comunicacion");
            }
            Console.ReadKey();
        }
    }
}