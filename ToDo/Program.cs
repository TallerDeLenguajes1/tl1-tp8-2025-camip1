using System.Linq.Expressions;
using ToDo;

Random rand = new Random();
string [] descrip = { "prueba del programa", "crear nuevo proyecto de consola", "cargar datos", "subir archivos", "mostrar listas", "generar aleatorios"};

List<Tarea> TareasPendientes = new List<Tarea>();
List<Tarea> TareasRealizadas = new List<Tarea>();

Console.WriteLine("Ingrese el numero de tareas:");
string input = Console.ReadLine();
bool esValido = int.TryParse(input, out int N);

for (int i = 0; i < N; i++)
{
    Tarea nuevaTarea = new Tarea();
    nuevaTarea.TareaID = rand.Next(100);
    nuevaTarea.Descripcion = descrip[rand.Next(6)];
    nuevaTarea.Duracion = rand.Next(10, 100);
    TareasPendientes.Add(nuevaTarea);
}

int op;

do
{
    Console.WriteLine("\nMenu: Presione 0-Salir del programa | 1-Marcar como realizada una tarea| 2-Buscar tarea pendiente por descripción | 3-Listar tareas pendientes y realizadas");
    input = Console.ReadLine();
    esValido = int.TryParse(input, out op);

    switch (op)
    {
        case 1:
            Console.WriteLine("Ingrese el ID de la tarea Realizada: ");
            input = Console.ReadLine();
            esValido = int.TryParse(input, out int tRealizadaID);
            agregarRealizada(TareasPendientes, TareasRealizadas, tRealizadaID);
            break;
        case 2:
            Console.WriteLine("Ingrese la palabra o frase de la descripcion: ");
            input = Console.ReadLine();
            buscarPendiente(TareasPendientes, input);
            break;
        case 3:
            mostrarListas(TareasPendientes, "pendientes");
            mostrarListas(TareasRealizadas, "realizadas");
            break;
        case 0:
            Console.WriteLine("Saliendo del programa...");
            break;
        default:
            Console.WriteLine("Opcion invalida");
            break;
    }
} while (op != 0);


void mostrarListas(List<Tarea> tareas1, string tipo)
{
    Console.WriteLine("\nTareas " + tipo);
    foreach (Tarea informacion in tareas1)
    {
        Console.WriteLine("\nTarea " + informacion.TareaID);
        Console.WriteLine("Descripcion: " + informacion.Descripcion);
        Console.WriteLine("Duracion: " + informacion.Duracion);
    }
}

void agregarRealizada(List<Tarea> tareas1, List<Tarea> tareas2, int id)
{
    for (int i = 0; i < tareas1.Count; i++)
    {
        if (tareas1[i].TareaID == id)
        {
            Tarea TareaMovida = tareas1[i];
            tareas1.Remove(TareaMovida);
            tareas2.Add(TareaMovida);
        }
    }
}

void buscarPendiente(List<Tarea> tareas1, string subcadena)
{
    int indice;
    Console.WriteLine("Coincidencias:\n");

    foreach (Tarea tarea in tareas1)
    {
        indice = tarea.Descripcion.IndexOf(subcadena);
        if (indice != -1)
        {
            Console.WriteLine($"Tarea {tarea.TareaID}");
            Console.WriteLine($"Descripcion: {tarea.Descripcion}");
            Console.WriteLine($"Duracion: {tarea.Duracion}");
        }
    }
}


string texto = "Este es un ejemplo de texto";
string subcadena = "ejemplo";
int indice = texto.IndexOf(subcadena);

