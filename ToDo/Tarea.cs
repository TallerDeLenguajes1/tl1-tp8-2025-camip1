namespace ToDo
{
    public class Tarea
    {
        private int tareaID;
        private string descripcion;
        private int duracion;

        public int TareaID
        {
            get => tareaID;
            set => tareaID = value;
        }
        public string Descripcion
        {
            get => descripcion;
            set => descripcion = value;
        }
        public int Duracion
        {
            get => duracion;
            set
            {
                if (value < 10 || value > 100)
                {
                    duracion = 0;
                }
                else
                {
                    duracion = value;
                }
            }
        }
        
        
    }
}