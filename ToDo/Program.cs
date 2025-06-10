using System.Linq.Expressions;
using ToDo;

Random rand = new Random();
string [] descrip = { "Prueba del programa", "Crear proyecto", "Cargar Datos", "Subir archivos", "Mostrar proyecto", "Generar aleatorios"};

List<Tarea> TareasPendientes = new List<Tarea>();

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

foreach (Tarea informacion in TareasPendientes)
{
    Console.WriteLine("\nTarea " + informacion.TareaID);
    Console.WriteLine("Descripcion: " + informacion.Descripcion);
    Console.WriteLine("Duracion: " + informacion.Duracion);
}