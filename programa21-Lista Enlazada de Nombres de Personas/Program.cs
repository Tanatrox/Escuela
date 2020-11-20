using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programa20_Lista_Enlazada_de_Numeros_Flotantes
{
    class Program
    {
        class Nodo
        {
            //campos clase nodo
            public string elemento;
            public int siguiente;
            //constructor clase nodo
            public Nodo(string e, int s)
            {
                elemento = e;
                siguiente = s;
            }
            //destructor clase nodo
            ~Nodo()
            {
                Console.WriteLine("Recursos del Nodo Liberados.");
            }
        }
        public class ListaEnlazada
        {
            // campos clase lista enlazada
            int inicio, disponible, Max;
            Nodo[] listanumeros;
            // variables auxiliares
            int tamaño, auxiliar, posición, temporal;
            char otra;
            // constructor clase lista enlazada
            public ListaEnlazada(int capacidad)
            {
                Max = capacidad;
                inicio = 0;
                disponible = 0;
                tamaño = 0;
                listanumeros = new Nodo[Max];
                for (int c = 0; c < Max; c++)
                {
                    listanumeros[c] = new Nodo("", c + 1);
                }
                listanumeros[Max - 1] = new Nodo("", -1);

                Console.WriteLine("La Lista enlazada a sido creada!");
                Console.WriteLine("Presione <Enter> para continuar...");

            }
            // métodos clase lista enlazada
            public void Insertar()
            {
                string dato;

                do
                {
                    if (tamaño == Max)
                    {
                        Console.Clear();
                        Console.WriteLine("La lista esta llena");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("inserte un dato:");
                        dato = Convert.ToString(Console.ReadLine());
                        temporal = listanumeros[disponible].siguiente;
                        listanumeros[disponible].elemento = dato;
                        Lugar_Insertar(dato);
                        if (posición == inicio)
                        {
                            listanumeros[disponible].siguiente = inicio;
                            inicio = disponible;
                        }
                        else
                        {
                            listanumeros[disponible].siguiente = listanumeros[auxiliar].siguiente;
                            listanumeros[auxiliar].siguiente = disponible;
                        }
                        disponible = temporal;
                        tamaño = tamaño + 1;
                    }
                    Console.WriteLine("Desea otra insercion (S/N)?");
                    otra = char.Parse(Console.ReadLine());
                } while (otra == 'S' || otra == 's');
            }

            public void Lugar_Insertar(string dato)
            {
                int encontrado = 0;
                posición = inicio;
                auxiliar = 0;
                while (posición != -1 && encontrado != 1)
                {
                    if (string.Compare(listanumeros[posición].elemento,dato) > 0)
                    {
                        encontrado = 1;
                    }
                    else
                    {
                        auxiliar = posición;
                        posición = listanumeros[posición].siguiente;
                    }
                }

            }

            public void Eliminar()
            {
                int encontrado;
                string dato;
                do
                {
                    if (tamaño == 0)
                    {
                        Console.WriteLine("\n\tLA lista esta vacia");
                        Console.WriteLine("\n\tPresione <enter> para continuar.");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("\n\tDijite el valor a eliminar: ");
                        dato = Convert.ToString(Console.ReadLine());
                        encontrado = BuscarEliminar(dato);
                        if (encontrado == 1)
                        {
                            if (auxiliar != -1)
                            {
                                listanumeros[auxiliar].siguiente = listanumeros[posición].siguiente;
                            }
                            else
                            {
                                inicio = listanumeros[posición].siguiente;
                            }
                            listanumeros[posición].elemento = "";
                            listanumeros[posición].siguiente = -1;
                            temporal = disponible;//actulizacion del espacio disponible
                            while (temporal != -1)
                            {
                                if (listanumeros[temporal].siguiente != 0)
                                {
                                    temporal = listanumeros[temporal].siguiente;
                                }
                                else
                                {
                                    listanumeros[temporal].siguiente = posición;
                                }
                            }
                            tamaño = tamaño - 1;//decremento por la eliminacion
                        }
                    }
                    Console.WriteLine("\n\tDecea otra eliminacion (S/N): ");
                    otra = char.Parse(Console.ReadLine());
                } while (otra == 'S' || otra == 's');
            }
            public int BuscarEliminar(string dato = "")
            {
                int encontrado = 0;
                posición = inicio;
                auxiliar = -1;
                while (posición != -1 && encontrado != 1)
                {
                    if (listanumeros[posición].elemento == dato)
                    {
                        encontrado = 1;
                    }
                    else
                    {
                        auxiliar = posición;
                        posición = listanumeros[posición].siguiente;
                    }
                }
                if (encontrado == 0)
                {
                    Console.WriteLine("\n\tEl elemento {0} no esta en la lista.", dato);
                }
                else
                {
                    Console.WriteLine("\n\tEl elemento {0} sera eliminado de la lista.", dato);
                }
                return encontrado;
            }
            public void Desplegar()
            {
                posición = inicio;
                if (tamaño == 0)
                {
                    Console.WriteLine("\n\tLa lista esta vacia.");
                    Console.Write("\n\tPresione <enter> para continuar.");
                    return;
                }
                else
                {
                    while (posición != -1 && listanumeros[posición].elemento != "")
                    {
                        Console.WriteLine("\n\tElemento: {0} Posicion: {1}", listanumeros[posición].elemento, posición);
                        posición = listanumeros[posición].siguiente;
                    }
                }
            }
            public void Contar()
            {
                int contador = 0;
                posición = inicio;
                if (tamaño == 0)
                {
                    Console.WriteLine("\n\tLa lista esta vacia.");
                    return;
                }
                else
                {
                    while (posición != -1 && listanumeros[posición].elemento != "")
                    {
                        contador = contador + 1;
                        posición = listanumeros[posición].siguiente;
                    }
                    Console.WriteLine("\n\tEl total de elementos en la lista es {0}", contador);
                    Console.WriteLine("\n\tPresione <enter> para continuar.");
                }
            }
            public void Buscar()
            {
                string dato;
                int encontrado = 0;
                if (tamaño == 0)
                {
                    Console.WriteLine("\n\tLa lista esta vacia.");
                    Console.WriteLine("\n\tPresione <enter> para continuar.");
                    return;
                }
                else
                {
                    do
                    {
                        posición = inicio;
                        Console.WriteLine("\n\tDijite el valor a buscar: ");
                        dato = Convert.ToString(Console.ReadLine());
                        while (posición != -1 && encontrado != 1)
                        {
                            if (listanumeros[posición].elemento == dato)
                            {
                                encontrado = 1;
                            }
                            else
                            {
                                posición = listanumeros[posición].siguiente;
                            }
                        }
                        if (encontrado == 0)
                        {
                            Console.WriteLine("\n\tEL elemento {0} no esta en la lista", dato);
                        }
                        else
                        {
                            Console.WriteLine("\n\tEL elemento {0} esta en la posicion {1}", dato, posición);
                        }
                        Console.Write("\n\tDecea buscar de nuevo (S/N): ");
                        otra = char.Parse(Console.ReadLine());
                    } while (otra == 'S' || otra == 's');
                }
            }


            // destructor clase lista enlazada
            ~ListaEnlazada()
            {
                Console.WriteLine("Recursos de la Lista Enlazada Liberados.");
            }
        }

        static void Main(string[] args)
        {
            Console.Title = "Daniel Galindo Ontiveros #18210991";
            Console.BackgroundColor = ConsoleColor.Black;

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            ListaEnlazada L = null;
            char opcion;


            do
            {
                Console.WriteLine("|***************************************************************|");
                Console.WriteLine("|*      Menu Lista Enlazada de Nombres de Personas.            *|");
                Console.WriteLine("|*        a.- Crear la lista.                                  *|");
                Console.WriteLine("|*        b.- Insertar un Elemento en la Lista.                *|");
                Console.WriteLine("|*        c.- Eliminar un Dato de la Lista.                    *|");
                Console.WriteLine("|*        d.- Recorrer la Lista.                               *|");
                Console.WriteLine("|*        e.- Determinar el Número de Elementos en la Lista.   *|");
                Console.WriteLine("|*        f.- Localizar un Elemento en Particular de la Lista. *|");
                Console.WriteLine("|*        g.- Salir del programa.                              *|");
                Console.WriteLine("|*                                                             *|");
                Console.WriteLine("|***************************************************************|");
                Console.Write("\n");
                Console.Write("Ingresa la opcion deseada:");
                opcion = Convert.ToChar(Console.ReadLine());

                switch (opcion)
                {
                    case 'a':
                        {
                            Console.Clear();
                            Console.WriteLine("-----------------------------------------");
                            Console.Write("De que tamaño quieres la lista?:");
                            L = new ListaEnlazada(int.Parse(Console.ReadLine()));
                            Console.ReadKey();
                            Console.WriteLine("-----------------------------------------");

                        }
                        break;
                    case 'b':
                        {
                            Console.Clear();
                            Console.WriteLine("b.- Insertar un Elemento en la Lista.\n ");
                            L.Insertar();
                            Console.ReadKey();




                        }
                        break;
                    case 'c':
                        {
                            Console.WriteLine("-----------------------------------------");
                            Console.WriteLine("c.- Eliminar un Dato de la Lista.  \n ");
                            L.Eliminar();

                            Console.WriteLine("-----------------------------------------");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    case 'd':
                        {
                            Console.WriteLine("-----------------------------------------");
                            Console.WriteLine("d.- Recorrer la Lista. \n ");
                            L.Desplegar();

                            Console.WriteLine("-----------------------------------------");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    case 'e':
                        {
                            Console.WriteLine("-----------------------------------------");
                            Console.WriteLine("e.- Determinar el Número de Elementos en la Lista.\n ");
                            L.Contar();

                            Console.WriteLine("-----------------------------------------");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    case 'f':
                        {
                            Console.WriteLine("-----------------------------------------");
                            Console.WriteLine("f.- Localizar un Elemento en Particular de la Lista.\n ");
                            L.Buscar();

                            Console.WriteLine("-----------------------------------------");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    case 'g':
                        {
                            Console.WriteLine("-----------------------------------------");
                            Environment.Exit('g');

                            Console.WriteLine("-----------------------------------------");
                            Console.ReadKey();
                        }
                        break;

                    default:
                        {
                            Console.WriteLine("Opcion invalida!");
                        }
                        break;
                }

                Console.WriteLine("-----------------------------------------");
                Console.Clear();
            } while (opcion != 'f');
        }
    }
}
