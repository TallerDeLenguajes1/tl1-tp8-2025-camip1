using ToDo;

Random rand = new Random();
string [] descrip = { "prueba del programa", "crear nuevo proyecto de consola", "cargar datos", "subir archivos", "mostrar listas", "generar aleatorios"};
int id, duracion, opcion;
string descripcion;

List<Tarea> TareasPendientes = new List<Tarea>();
List<Tarea> TareasRealizadas = new List<Tarea>();

Console.WriteLine("Ingrese el numero de tareas:");
string input = Console.ReadLine();
bool esValido = int.TryParse(input, out int N);

for (int i = 0; i < N; i++)
{
    id = rand.Next(100);
    descripcion = descrip[rand.Next(6)];
    duracion = rand.Next(10, 100);
    Tarea nuevaTarea = new Tarea(id,descripcion,duracion);
    TareasPendientes.Add(nuevaTarea);
}

mostrarListas(TareasPendientes, "pendientes");

do
{
    Console.WriteLine("\nMenu: Presione 0-Salir del programa | 1-Marcar como realizada una tarea| 2-Buscar tarea pendiente por descripción | 3-Listar tareas pendientes y realizadas");
    input = Console.ReadLine();
    esValido = int.TryParse(input, out opcion);

    switch (opcion)
    {
        case 1:
            agregarRealizada(TareasPendientes, TareasRealizadas);
            break;
        case 2:
            buscarPendiente(TareasPendientes);
            break;
        case 3:
            mostrarListas(TareasPendientes, "pendientes");
            mostrarListas(TareasRealizadas, "realizadas");
            break;
        case 0:
            Console.WriteLine("Saliendo del programa...");
            break;
        default:
            Console.WriteLine("opcion invalida");
            break;
    }
} while (opcion != 0);


void mostrarListas(List<Tarea> tareas1, string tipo)
{
    Console.WriteLine("\nTareas " + tipo);
    foreach (Tarea informacion in tareas1)
    {
        informacion.MostrarTareas();
    }
}

void agregarRealizada(List<Tarea> tareas1, List<Tarea> tareas2)
{
    Console.WriteLine("Ingrese el ID de la tarea Realizada: ");
    esValido = int.TryParse(Console.ReadLine(), out int tRealizadaID);
    bool encontrada = false;
    if (esValido)
    {
        for (int i = 0; i < tareas1.Count; i++)
        {
            if (tareas1[i].TareaID == tRealizadaID)
            {
                Tarea TareaMovida = tareas1[i];
                tareas1.Remove(TareaMovida);
                tareas2.Add(TareaMovida);
                encontrada = true;
                Console.WriteLine("Tarea marcada como realizada");
            }
        }
        if (encontrada == false)
        {
            Console.WriteLine("Tarea no encontrada");
        }
    }
    else
    {
        Console.WriteLine("ID invalido");
    }
}

void buscarPendiente(List<Tarea> tareas1)
{
    int indice;
    Console.WriteLine("Ingrese la palabra o frase de la descripcion: ");
    string subcadena = Console.ReadLine();
    Console.WriteLine("Coincidencias:\n");

    foreach (Tarea tarea in tareas1)
    {
        indice = tarea.Descripcion.IndexOf(subcadena);
        if (indice != -1)
        {
            tarea.MostrarTareas();
        }
    }
}


