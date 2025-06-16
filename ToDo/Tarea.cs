namespace ToDo
{
    public class Tarea
    {
        public int TareaID { get; set; }
        public string Descripcion { get; set; }
        private int Duracion; // Validar que esté entre 10 y 100

        public int DuracionTarea
        {
            get => Duracion;
            set {
                if (value < 10 || value > 100)
                {
                    DuracionTarea = 0;
                }
                else
                {
                    DuracionTarea = value;
                }
            }
        }
        
        public Tarea(int TareaID, string Descripcion, int Duracion)
        {
            this.TareaID = TareaID;
            this.Descripcion = Descripcion;
            this.Duracion = Duracion;
        }

        public void MostrarTareas()
        {
            Console.WriteLine($"ID tarea:{TareaID} | Descripcion: {Descripcion} | Duracion: {Duracion} minutos");
        }
    }
}