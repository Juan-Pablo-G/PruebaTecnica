using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Prueba_Tecnica
{
    /// <summary>
    /// Representa una tarea en la lista de tareas.
    /// </summary>
    public class Task
    {
        /// <summary>
        /// Descripción de la tarea.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Fecha límite para completar la tarea.
        /// </summary>
        public DateTime DueDate { get; set; }

        /// <summary>
        /// Estado de la tarea (completada o no).
        /// </summary>
        public bool IsCompleted { get; set; }

        /// <summary>
        /// Constructor para inicializar una nueva tarea.
        /// </summary>
        /// <param name="description">Descripción de la tarea.</param>
        /// <param name="dueDate">Fecha límite para completar la tarea.</param>
        public Task(string description, DateTime dueDate)
        {
            Description = description;
            DueDate = dueDate;
            IsCompleted = false;
        }

        /// <summary>
        /// Marca la tarea como completada.
        /// </summary>
        public void CompleteTask()
        {
            IsCompleted = true;
        }

        /// <summary>
        /// Retorna una representación en cadena de la tarea.
        /// </summary>
        /// <returns>Cadena que representa la tarea.</returns>
        public override string ToString()
        {
            return $"Descripción: {Description}, Fecha Límite: {DueDate.ToShortDateString()}, Completada: {IsCompleted}";
        }
    }

    internal class Program
    {
        // Lista para almacenar las tareas
        static List<Task> tasks = new List<Task>();

        private static int filaNum = 0;
        private static int colNum = 27;
        private static int textBoxLeft;
        private static int textBoxTop;
        private static string idiomaCliente;
        private static bool running;

        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        static void Main(string[] args)
        {
            // Configura el idioma del cliente
            Idioma();

            running = true;

            while (running)
            {
                // Muestra el menú principal según el idioma seleccionado
                if (idiomaCliente == "1")
                {
                    Console.Clear();
                    Console.WriteLine("\n    === GESTIÓN DE TAREAS ===\n");
                    Console.WriteLine("1. Agregar nueva tarea");
                    Console.WriteLine("2. Listar todas las tareas");
                    Console.WriteLine("3. Marcar tarea como completada");
                    Console.WriteLine("4. Eliminar tarea");
                    Console.WriteLine("5. Salir");
                    Console.Write("\nSelecciona una opción: ");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\n    === TASK MANAGEMENT ===\n");
                    Console.WriteLine("1. Add new task");
                    Console.WriteLine("2. List all tasks");
                    Console.WriteLine("3. Mark task as completed");
                    Console.WriteLine("4. Delete task");
                    Console.WriteLine("5. Exit");
                    Console.Write("\nSelect an option: ");
                }

                // Maneja la selección del usuario
                switch (Console.ReadLine())
                {
                    case "1":
                        AddTask();
                        break;
                    case "2":
                        ListTasks();
                        break;
                    case "3":
                        CompleteTask();
                        break;
                    case "4":
                        DeleteTask();
                        break;
                    case "5":
                        ExitApp();
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intenta de nuevo.");
                        break;
                }
            }
        }

        /// <summary>
        /// Dibuja un marco en la consola para animaciones.
        /// </summary>
        /// <param name="left">Posición horizontal del marco.</param>
        /// <param name="top">Posición vertical del marco.</param>
        /// <param name="width">Ancho del marco.</param>
        /// <param name="height">Alto del marco.</param>
        public static void Box(int left, int top, int width, int height)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(left, top);
            Console.Write("╔" + new string('═', width - 2) + "╗");

            for (int i = 1; i < height - 1; i++)
            {
                Console.SetCursorPosition(left, top + i);
                Console.Write("║" + new string(' ', width - 2) + "║");
            }

            Console.SetCursorPosition(left, top + height - 1);
            Console.Write("╚" + new string('═', width - 2) + "╝");
        }

        /// <summary>
        /// Configura el idioma del cliente y muestra la introducción de la aplicación.
        /// </summary>
        public static void Idioma()
        {
            Console.Title = "Proyecto / By: Juan Pablo Giraldo";
            int width = 112, height = 20;
            Console.SetWindowSize(width, height);
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();

            string marco_horizontal = "═══════════════════════════";
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(14, filaNum);
            Console.WriteLine("╔" + marco_horizontal + marco_horizontal + marco_horizontal + "══╗");

            string autor = "APP By: Juan Pablo Giraldo, Version: 1.0";
            Console.ForegroundColor = ConsoleColor.Black;

            string msj1, msj2, msj3, msj4, msj5;
            int retardo = 700;
            Thread.Sleep(retardo);
            msj1 = "          ____ ___________   ___    _________   __________  ____  _____";
            msj2 = "   / __ )/  _/ ____/ | / / |  / / ____/ | / /  _/ __ \\/ __ \\/ ___/";
            msj3 = "  / __  |/ // __/ /  |/ /| | / / __/ /  |/ // // / / / / / /\\__ \\ ";
            msj4 = " / /_/ // // /___/ /|  / | |/ / /___/ /|  // // /_/ / /_/ /___/ / ";
            msj5 = "/_____/___/_____/_/ |_/  |___/_____/_/ |_/___/_____/\\____//____/  ";
            filaNum = filaNum + 1;
            Console.SetCursorPosition(20, filaNum);
            Console.WriteLine(msj1);
            filaNum = filaNum + 1;
            Thread.Sleep(retardo / 3);
            Console.SetCursorPosition(25, filaNum);
            Console.WriteLine(msj2);
            filaNum = filaNum + 1;
            Thread.Sleep(retardo / 3);
            Console.SetCursorPosition(25, filaNum);
            Console.WriteLine(msj3);
            filaNum = filaNum + 1;
            Thread.Sleep(retardo / 3);
            Console.SetCursorPosition(25, filaNum);
            Console.WriteLine(msj4);
            filaNum = filaNum + 1;
            Thread.Sleep(retardo / 3);
            Console.SetCursorPosition(25, filaNum);
            Console.WriteLine(msj5);
            filaNum = filaNum + 1;
            Thread.Sleep(retardo / 3);

            int textBoxLeft, textBoxTop;

            Console.SetCursorPosition(colNum + 8, filaNum + 1);
            Console.WriteLine(autor.ToUpper());
            Console.ForegroundColor = ConsoleColor.Black;
            filaNum = filaNum + 1;
            Console.SetCursorPosition(29, filaNum + 1);
            Console.WriteLine("╚" + marco_horizontal + marco_horizontal + "╝");
            Thread.Sleep(retardo);

            bool idiomaValido = false;
            width = 112;
            height = 30;
            Console.SetWindowSize(width, height);
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            Box(24, 9, 66, 13);
            Console.SetCursorPosition(34, 12);
            Console.WriteLine("SELLECCIONE EL IDIOMA        SELECT THE LANGUAGE");
            Console.SetCursorPosition(43, 14);
            Console.WriteLine("ESPAÑOL= 1       ENGLISH = 2");
            Box(44, 15 + 1, 25, 3);
            textBoxLeft = 46;
            textBoxTop = 17;
            Console.SetCursorPosition(textBoxLeft, textBoxTop);
            string idioma = Console.ReadLine();
            while (!idiomaValido)
            {
                if (idioma == "1" || idioma == "2")
                {
                    idiomaValido = true;
                }
                else
                {
                    Box(24, 9, 66, 13);
                    Console.SetCursorPosition(34, 12);
                    Console.WriteLine("SELLECCIONE EL IDIOMA        SELECT THE LANGUAGE");
                    Console.SetCursorPosition(43, 14);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("ESPAÑOL= 1       ENGLISH = 2");
                    Box(44, 15 + 1, 25, 3);
                    textBoxLeft = 46;
                    textBoxTop = 17;
                    Console.SetCursorPosition(textBoxLeft, textBoxTop);
                    idioma = Console.ReadLine();
                }
                idiomaCliente = idioma;
            }
        }

        /// <summary>
        /// Permite agregar una nueva tarea a la lista.
        /// </summary>
        static void AddTask()
        {
            if (idiomaCliente == "1")
            {
                Console.Write("\nDescripción de la tarea: ");
                string description = Console.ReadLine();

                DateTime dueDate;
                while (true)
                {
                    Console.Write("Fecha límite (dd/mm/yyyy): ");
                    if (DateTime.TryParse(Console.ReadLine(), out dueDate))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Fecha no válida. Intenta de nuevo.");
                    }
                }

                tasks.Add(new Task(description, dueDate));
                Console.WriteLine("Tarea agregada exitosamente.");
                Console.ReadKey();
            }
            else
            {
                Console.Write("\nTask description: ");
                string description = Console.ReadLine();

                DateTime dueDate;
                while (true)
                {
                    Console.Write("Due date (dd/mm/yyyy): ");
                    if (DateTime.TryParse(Console.ReadLine(), out dueDate))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid date. Please try again.");
                    }
                }

                tasks.Add(new Task(description, dueDate));
                Console.WriteLine("Task added successfully.");
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Muestra todas las tareas registradas.
        /// </summary>
        static void ListTasks()
        {
            if (idiomaCliente == "1")
            {
                Console.WriteLine("\n=== LISTA DE TAREAS ===");

                if (tasks.Count == 0)
                {
                    Console.WriteLine("No hay tareas registradas.");
                }
                else
                {
                    for (int i = 0; i < tasks.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {tasks[i]}");
                    }
                }
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\n=== TASK LIST ===");

                if (tasks.Count == 0)
                {
                    Console.WriteLine("No tasks registered.");
                }
                else
                {
                    for (int i = 0; i < tasks.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {tasks[i]}");
                    }
                }
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Permite marcar una tarea como completada.
        /// </summary>
        static void CompleteTask()
        {
            if (idiomaCliente == "1")
            {
                ListTasks();

                Console.Write("Número de tarea a completar: ");
                int taskNumber;
                if (int.TryParse(Console.ReadLine(), out taskNumber) && taskNumber > 0 && taskNumber <= tasks.Count)
                {
                    tasks[taskNumber - 1].CompleteTask();
                    Console.WriteLine("Tarea completada exitosamente.");
                }
                else
                {
                    Console.WriteLine("Número de tarea no válido.");
                }
                Console.ReadKey();
            }
            else
            {
                ListTasks();

                Console.Write("Task number to complete: ");
                int taskNumber;
                if (int.TryParse(Console.ReadLine(), out taskNumber) && taskNumber > 0 && taskNumber <= tasks.Count)
                {
                    tasks[taskNumber - 1].CompleteTask();
                    Console.WriteLine("Task completed successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid task number.");
                }
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Permite eliminar una tarea de la lista.
        /// </summary>
        static void DeleteTask()
        {
            if (idiomaCliente == "1")
            {
                ListTasks();

                Console.Write("Número de tarea a eliminar: ");
                int taskNumber;
                if (int.TryParse(Console.ReadLine(), out taskNumber) && taskNumber > 0 && taskNumber <= tasks.Count)
                {
                    tasks.RemoveAt(taskNumber - 1);
                    Console.WriteLine("Tarea eliminada exitosamente.");
                }
                else
                {
                    Console.WriteLine("Número de tarea no válido.");
                }
                Console.ReadKey();
            }
            else
            {
                ListTasks();

                Console.Write("Task number to delete: ");
                int taskNumber;
                if (int.TryParse(Console.ReadLine(), out taskNumber) && taskNumber > 0 && taskNumber <= tasks.Count)
                {
                    tasks.RemoveAt(taskNumber - 1);
                    Console.WriteLine("Task deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid task number.");
                }
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Sale de la aplicación mostrando un mensaje de despedida.
        /// </summary>
        static void ExitApp()
        {
            Console.Clear();
            if (idiomaCliente == "1")
            {
                string msj1, msj2;
                int retardo = 700;
                Thread.Sleep(retardo);
                msj1 = "█▀▀ █▀█ ▄▀█ █▀▀ █ ▄▀█ █▀   █▀█ █▀█ █▀█   █ █ ▀█▀ █ █   █ ▀█ ▄▀█ █▀█   █   ▄▀█   ▄▀█ █▀█ █▀█";
                msj2 = "█▄█ █▀▄ █▀█ █▄▄ █ █▀█ ▄█   █▀▀ █▄█ █▀▄   █▄█  █  █ █▄▄ █ █▄ █▀█ █▀▄   █▄▄ █▀█   █▀█ █▀▀ █▀▀";
                filaNum = filaNum;
                Console.SetCursorPosition(10, filaNum);
                Console.WriteLine(msj1);
                filaNum = filaNum + 1;
                Thread.Sleep(retardo / 3);
                Console.SetCursorPosition(10, filaNum);
                Console.WriteLine(msj2);

                Thread.Sleep(retardo + 2000);
                running = false;
            }
            else
            {
                string msj1, msj2;
                int retardo = 700;
                Thread.Sleep(retardo);
                msj1 = "▀█▀ █ █ ▄▀█ █▄ █ █▄▀   █▄█ █▀█ █ █   █▀▀ █▀█ █▀█   █ █ █▀ █ █▄ █ █▀▀   █▀█ █ █ █▀█   ▄▀█ █▀█ █▀█";
                msj2 = " █  █▀█ █▀█ █ ▀█ █ █    █  █▄█ █▄█   █▀  █▄█ █▀▄   █▄█ ▄█ █ █ ▀█ █▄█   █▄█ █▄█ █▀▄   █▀█ █▀▀ █▀▀";
                filaNum = filaNum;
                Console.SetCursorPosition(3, filaNum);
                Console.WriteLine(msj1);
                filaNum = filaNum + 1;
                Thread.Sleep(retardo / 3);
                Console.SetCursorPosition(3, filaNum);
                Console.WriteLine(msj2);

                Thread.Sleep(retardo + 2000);
                running = false;
            }
        }
    }
}