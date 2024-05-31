using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea_1_2024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ejercicio #1

            // Declara las variables
            string cedula = "";
            string nombre_empleado = "";
            int tipo_empleado = 0; // 1 = Operario; 2 = Técnico; 3 = Profesional;
            double horas_trabajadas = 0;
            double hora_precio = 0;
            string aumento;

            //Salarios
            double salario_ordi;
            double salario_bruto;
            double salario_neto;
            double deduccion_CCSS;

            double salario_neto_OP = 0;
            double salario_neto_TEC = 0;
            double salario_neto_PRO = 0;


            // Declara los arreglos
            string[] Operarios = new string[255];   // Cantidad de cada tipo de empleado
            int ope_amount = 0;
            string[] Tecnicos = new string[255];
            int tec_amount = 0;
            string[] Profesionales = new string[255];
            int pro_amount = 0;

            double[] salneto_OP_Acumulado = new double[255];
            double[] salneto_TEC_Acumulado = new double[255];
            double[] salneto_PRO_Acumulado = new double[255];

            // Menú
            bool salir = false;
            int menu_decision;

            while (salir != true)
            {
                // Presenta el menú
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("+-----[Aumentos salariales]-----+");
                Console.WriteLine("|                               |");
                Console.WriteLine("|         Bienvenido/a          |");
                Console.WriteLine("|      ¿Desea añadir datos      |");
                Console.WriteLine("| o revizar los ya existentes?  |");
                Console.WriteLine("|                               |");
                Console.WriteLine("+-------------------------------+");
                Console.WriteLine("(1) Añadir datos.");
                Console.WriteLine("(2) Revizar los datos presentes.");
                Console.WriteLine("(3) Salir del programa.");

                try
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Ingrese el número correspondiente a la opción deseada: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    menu_decision = int.Parse(Console.ReadLine());

                    switch (menu_decision)
                    {
                        case 1:
                            anadir_datos();
                            break;

                        case 2:
                            show_datos();
                            break;

                        case 3:
                            salir = true;
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SE HA PRODUCIDO UN ERROR DEBIDO A QUE SE INGRESÓ UN VALOR INVÁLIDO");
                }

            }

            void anadir_datos()
            {
                int paso = 0;
                try
                {
                    Console.Clear();
                    // Solicita la cédula
                    while (paso == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Por favor, ingrese su cédula: ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        cedula = Console.ReadLine();
                        bool cedula_num = cedula.All(char.IsDigit);
                        if (cedula.Length == 9)
                        {
                            if (cedula_num == true)
                            {
                                paso++;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("NÚMERO DE CÉDULA INVÁLIDO. SOLO SE ADMITEN DIGITOS NUMÉRICOS");
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("NÚMERO DE CÉDULA INVÁLIDO. DEBE SER DE 9 DIGITOS");
                        }
                    }

                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SE HA PRODUCIDO UN ERROR");
                }

                //Solicita el nombre del empleado
                Console.Clear();

                while (paso == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Por favor, ingrese su nombre: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    nombre_empleado = Console.ReadLine();
                    bool name_letters = nombre_empleado.All(char.IsLetter);
                    switch (name_letters)
                    {
                        case true:
                            paso++;
                            break;
                        case false:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("El nombre ingresado no es válido. Absténgase de emplear números.");
                            break;
                    }
                }

                // Solicita el tipo de empleado
                Console.Clear();

                while (paso == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("+-----[Tipos de empleados]-----+");
                    Console.WriteLine("|                              |");
                    Console.WriteLine("|  (1) Operario.               |");
                    Console.WriteLine("|  (2) Técnico.                |");
                    Console.WriteLine("|  (3) Profesional.            |");
                    Console.WriteLine("|                              |");
                    Console.WriteLine("+------------------------------+");

                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Por favor, digite el número correspondiente al tipo de empleado que le corresponde: ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        tipo_empleado = int.Parse(Console.ReadLine());
                        if (tipo_empleado > 0 && tipo_empleado < 4)
                        {
                            switch (tipo_empleado)
                            {
                                case 1:
                                    for (int i = 0; i <= 255; i++)
                                    {
                                        if (Operarios[i] == null)
                                        {
                                            Operarios[i] = nombre_empleado;
                                            ope_amount++;
                                            i = 256;
                                            paso++;
                                        }
                                        else if (i == 255)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("NO HAY ESPACIOS PARA NUEVOS EMPLEADOS DE TIPO OPERARIO");
                                        }
                                    }
                                    break;

                                case 2:
                                    for (int i = 0; i <= 255; i++)
                                    {
                                        if (Tecnicos[i] == null)
                                        {
                                            Tecnicos[i] = nombre_empleado;
                                            tec_amount++;
                                            i = 256;
                                            paso++;
                                        }
                                        else if (i == 255)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("NO HAY ESPACIOS PARA NUEVOS EMPLEADOS DE TIPO TÉCNICO");
                                        }
                                    }
                                    break;

                                case 3:
                                    for (int i = 0; i <= 255; i++)
                                    {
                                        if (Profesionales[i] == null)
                                        {
                                            Profesionales[i] = nombre_empleado;
                                            pro_amount++;
                                            i = 256;
                                            paso++;
                                        }
                                        else if (i == 255)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("NO HAY ESPACIOS PARA NUEVOS EMPLEADOS DE TIPO PROFESIONAL");
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    catch (FormatException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                }

                //Solicita las horas trabajadas
                Console.Clear();

                while (paso == 3)
                {
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Por favor, digite el número correspondiente a la cantidad de horas laboradas: ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        horas_trabajadas = double.Parse(Console.ReadLine());

                        if (horas_trabajadas >= 0)
                        {
                            paso++;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("NO SE ADMITEN VALORES NEGATIVOS PARA LAS HORAS TRABAJADAS");
                        }

                    }
                    catch (FormatException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("DEBE INTRODUCIR VALORES NUMERICOS PARA REGISTRAR LAS HORAS TRABAJADAS");
                    }
                }

                // Solicita el precio por hora
                while (paso == 4)
                {
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Digite el precio que se paga por hora trabajada: ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        hora_precio = double.Parse(Console.ReadLine());

                        if (hora_precio >= 0)
                        {
                            paso++;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("NO SE ADMITEN VALORES NEGATIVOS PARA LAS HORAS TRABAJADAS");
                        }

                    }
                    catch (FormatException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("SOLO SE ADMITEN VALORES NUMERICOS");
                    }
                }

                // Calcula el salario ordinario
                salario_ordi = horas_trabajadas * hora_precio;

                // Calcula el aumento salarial
                double new_salary = 0;
                switch (tipo_empleado)
                {
                    case 1:
                        new_salary = salario_ordi * 0.15;
                        aumento = "15%";
                        break;
                    case 2:
                        new_salary = salario_ordi * 0.10;
                        aumento = "10%";
                        break;
                    case 3:
                        new_salary = salario_ordi * 0.05;
                        aumento = "5%";
                        break;
                }

                // Calcula el salario bruto
                salario_bruto = salario_ordi + new_salary;
                // Deducciones de ley
                deduccion_CCSS = 0.0917 * salario_bruto;
                // Calcula el salario neto
                salario_neto = salario_bruto - deduccion_CCSS;
                switch (tipo_empleado)
                {
                    case 1:
                        salario_neto_OP += salario_neto;
                        break;
                    case 2:
                        salario_neto_TEC += salario_neto;
                        break;
                    case 3:
                        salario_neto_PRO += salario_neto;
                        break;
                }

                // Presenta los datos
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("+----------------------------------------[DATOS INGRESADOS]----------------------------------------+");
                Console.WriteLine($"Cédula:     {cedula}");
                Console.WriteLine($"Nombre del Empleado:     {nombre_empleado}");
                Console.WriteLine($"Tipo Empleado:     {tipo_empleado}");
                Console.WriteLine($"Salario por Hora:     {hora_precio}");
                Console.WriteLine($"Cantidad de Horas:     {horas_trabajadas}");
                Console.WriteLine($"Salario Ordinario:     ₡{salario_ordi}");
                Console.WriteLine($"Aumento:     ₡{new_salary}");
                Console.WriteLine($"Salario Bruto:     {salario_bruto}");
                Console.WriteLine($"Deducción CSS:     {deduccion_CCSS}");
                Console.WriteLine($"Salario Neto:     {salario_neto}");
            }

            void show_datos()
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Cantidad de Operarios:      {ope_amount}");
                Console.WriteLine($"Salario Neto acumulado para Operarios:      ₡{salario_neto_OP}");
            }
        }
    }
}

