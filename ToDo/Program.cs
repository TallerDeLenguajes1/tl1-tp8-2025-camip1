using System.Linq.Expressions;
using ToDo;

Random rand = new Random();
string [] descrip = { "Prueba del programa", "Crear proyecto", "Cargar Datos", "Subir archivos", "Mostrar proyecto", "Generar aleatorios"};

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

mostrarListas(TareasPendientes, "pendientes");
mostrarListas(TareasRealizadas, "realizadas");

Console.WriteLine("Ingrese el ID de la tarea Realizada: ");
input = Console.ReadLine();
esValido = int.TryParse(input, out int tRealizadaID);
agregarRealizada(TareasPendientes, TareasRealizadas, tRealizadaID);

mostrarListas(TareasPendientes, "pendientes");
mostrarListas(TareasRealizadas, "realizadas");


void agregarRealizada(List<Tarea> tareas1, List<Tarea> tareas2, int id)
{
    for (int i = 0; i < N; i++)
    {
        if (tareas1[i].TareaID == id)
        {
            Tarea TareaMovida = tareas1[i];
            tareas1.Remove(TareaMovida);
            tareas2.Add(TareaMovida);
        }
    }
} 

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