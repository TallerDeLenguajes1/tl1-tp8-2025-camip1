namespace EspacioCalculadora
{
    public class Calculadora
    {
        private double resultado;
        private List<Operacion> operacion;
        public double Resultado
        {
            get => resultado;
        }
        public Calculadora()
        {
            resultado = 0;
            operacion = new List<Operacion>();
        }
        public void Suma(double operando)
        {
            AgregarHistorial(operando, TipoOperacion.Suma);
        }
        public void Resta(double operando)
        {
            AgregarHistorial(operando, TipoOperacion.Resta);
        }
        public void Multiplicacion(double operando)
        {
            AgregarHistorial(operando, TipoOperacion.Multiplicacion);
        }
        public void Division(double operando)
        {
            AgregarHistorial(operando, TipoOperacion.Division);
        }
        public void Limpiar()
        {
            operacion.Add(new Operacion(resultado, 0, TipoOperacion.Limpiar));
            resultado = 0;
        }

        public void AgregarHistorial(double operando, TipoOperacion tipoOperacion)
        {
            Operacion opNueva = new Operacion(resultado, operando, tipoOperacion);
            operacion.Add(opNueva);
            resultado = opNueva.Resultado;
        }

        public void MostrarHistorial()
        {
            Console.WriteLine("\n-------------- HISTORIAL DE OPERACIONES --------------");

            if (operacion.Count == 0)
            {
                Console.WriteLine("Sin operaciones registradas.");
                return;
            }
            else
            {
                foreach (var operacion in operacion)
                {
                    string simbolo = " ";
                    switch (operacion.TipoOperacion)
                    {
                        case TipoOperacion.Suma:
                            simbolo = "+";
                            break;
                        case TipoOperacion.Resta:
                            simbolo = "-";
                            break;
                        case TipoOperacion.Multiplicacion:
                            simbolo = "*";
                            break;
                        case TipoOperacion.Division:
                            simbolo = "/";
                            break;
                        case TipoOperacion.Limpiar:
                            Console.WriteLine($"Limpiar - resultado previo a la limpieza: {operacion.ResultadoAnterior}");
                            break;
                    }
                    if (simbolo != " ")
                    {
                        Console.WriteLine($"{operacion.ResultadoAnterior} {simbolo} {operacion.NuevoValor} = {operacion.Resultado}");
                    }
                }
            }
        }
    }

    public class Operacion
    {
        private double resultadoAnterior; // Almacena el resultado previo al cálculo actual
        private double nuevoValor; //El valor con el que se opera sobre el
        private TipoOperacion operacion;// El tipo de operación realizada
        public double Resultado
        {
            /* Lógica para calcular o devolver el resultado */
            get
            {
                switch (operacion)
                {
                    case TipoOperacion.Suma:
                        return resultadoAnterior + nuevoValor;
                    case TipoOperacion.Resta:
                        return resultadoAnterior - nuevoValor;
                    case TipoOperacion.Multiplicacion:
                        return resultadoAnterior * nuevoValor;
                    case TipoOperacion.Division:
                        if (nuevoValor != 0)
                        {
                            return resultadoAnterior / nuevoValor;
                        }
                        else
                        {
                            return 0;
                        }
                    case TipoOperacion.Limpiar:
                        return 0;
                    default:
                        return 0;
                }
            }
        }
        // Propiedad pública para acceder al nuevo valor utilizado en la operación
        public double ResultadoAnterior
        {
            get => resultadoAnterior;
        }
        public double NuevoValor
        {
            get => nuevoValor;
        }
        public TipoOperacion TipoOperacion
        {
            get => operacion;
        }
        // Constructor u otros métodos necesarios para inicializar y gestionar la operación
        public Operacion(double resultadoAnterior, double nuevoValor, TipoOperacion operacion)
        {
            this.resultadoAnterior = resultadoAnterior;
            this.nuevoValor = nuevoValor;
            this.operacion = operacion;
        }
    }
    public enum TipoOperacion
    {
        Suma,
        Resta,
        Multiplicacion,
        Division,
        Limpiar // Representa la acción de borrar el resultado actual o el historial
    }
        
        
}
