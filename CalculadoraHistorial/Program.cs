using EspacioCalculadora;

Calculadora calc = new Calculadora();

int opcion;
double valor=0;
bool valido;

do
{
    Console.WriteLine("Menu: Presione 0-Salir del programa | 1-Suma | 2-Resta | 3-Multiplicacion | 4-Division | 5-Limpiar | 6-Ver historial");
    valido = int.TryParse(Console.ReadLine(), out opcion);
    if (valido && opcion != 0)
    {
        if (opcion != 5 && opcion != 6) {
            Console.WriteLine("Ingrese un numero: ");
            while (!double.TryParse(Console.ReadLine(), out valor))
            {
                Console.WriteLine("Número invalido. Ingrese nuevamente.");
            }
        }
        switch (opcion)
        {
            case 1:
                calc.Suma(valor);
                Console.WriteLine("El valor actual de la calculadora es: " + calc.Resultado);
                break;
            case 2:
                calc.Resta(valor);
                Console.WriteLine("El valor actual de la calculadora es: " + calc.Resultado);
                break;
            case 3:
                calc.Multiplicacion(valor);
                Console.WriteLine("El valor actual de la calculadora es: " + calc.Resultado);
                break;
            case 4:
                calc.Division(valor);
                Console.WriteLine("El valor actual de la calculadora es: " + calc.Resultado);
                break;
            case 5:
                calc.Limpiar();
                Console.WriteLine("El valor actual de la calculadora es: " + calc.Resultado);
                break;
            case 6:
                calc.MostrarHistorial();
                break;
            default:
                Console.WriteLine("Opcion Invalida");
                break;
        }
    }
}while(opcion != 0);
