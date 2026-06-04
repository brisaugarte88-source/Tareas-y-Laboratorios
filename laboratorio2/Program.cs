using System;

class Program
{
    // METODO PARA VALIDAR NOTAS
    static double ValidarNota()
    {
        double nota;

        Console.Write("Ingrese nota (0-100): ");
        nota = double.Parse(Console.ReadLine());

        while (nota < 0 || nota > 100)
        {
            Console.WriteLine("Nota invalida.");

            Console.Write("Ingrese nuevamente la nota: ");
            nota = double.Parse(Console.ReadLine());
        }

        return nota;
    }

    // METODO PARA CALCULAR BONO
    static double CalcularBono(string carnet)
    {
        string ultimosDos = carnet.Substring(carnet.Length - 2);

        int numero = int.Parse(ultimosDos);

        return numero * 0.07;
    }

    // METODO PARA CLASIFICAR RENDIMIENTO
    static string ClasificarRendimiento(double promedioFinal)
    {
        if (promedioFinal >= 90)
        {
            return "Excelente";
        }
        else if (promedioFinal >= 70)
        {
            return "Bueno";
        }
        else if (promedioFinal >= 51)
        {
            return "Regular";
        }
        else
        {
            return "Observado";
        }
    }

    static void Main()
    {
        // DATOS DEL ESTUDIANTE
        Console.WriteLine("=== SISTEMA ACADEMICO ===");

        Console.Write("Ingrese nombre: ");
        string nombre = Console.ReadLine();

        Console.Write("Ingrese apellido: ");
        string apellido = Console.ReadLine();

        Console.Write("Ingrese carnet: ");
        string carnet = Console.ReadLine();

        Console.Write("Ingrese carrera: ");
        string carrera = Console.ReadLine();

        Console.Write("Ingrese paralelo: ");
        int paralelo = int.Parse(Console.ReadLine());

        // VARIABLES
        double suma = 0;
        int aprobadas = 0;

        // NOTA 1
        Console.WriteLine("\nMATERIA 1");
        double nota1 = ValidarNota();

        suma = suma + nota1;

        if (nota1 >= 51)
        {
            aprobadas++;
        }

        // NOTA 2
        Console.WriteLine("\nMATERIA 2");
        double nota2 = ValidarNota();

        suma = suma + nota2;

        if (nota2 >= 51)
        {
            aprobadas++;
        }

        // NOTA 3
        Console.WriteLine("\nMATERIA 3");
        double nota3 = ValidarNota();

        suma = suma + nota3;

        if (nota3 >= 51)
        {
            aprobadas++;
        }

        // NOTA 4
        Console.WriteLine("\nMATERIA 4");
        double nota4 = ValidarNota();

        suma = suma + nota4;

        if (nota4 >= 51)
        {
            aprobadas++;
        }

        // NOTA 5
        Console.WriteLine("\nMATERIA 5");
        double nota5 = ValidarNota();

        suma = suma + nota5;

        if (nota5 >= 51)
        {
            aprobadas++;
        }

        // PROMEDIO ORIGINAL
        double promedio = suma / 5;

        // BONO ACADEMICO
        double bono = CalcularBono(carnet);

        // PROMEDIO FINAL
        double promedioFinal = promedio + bono;

        if (promedioFinal > 100)
        {
            promedioFinal = 100;
        }

        // CLASIFICACION
        string clasificacion = ClasificarRendimiento(promedioFinal);

        // MOSTRAR RESULTADOS
        Console.WriteLine("\n===== RESULTADOS =====");

        Console.WriteLine("Nombre: " + nombre + " " + apellido);
        Console.WriteLine("Carnet: " + carnet);
        Console.WriteLine("Carrera: " + carrera);
        Console.WriteLine("Paralelo: " + paralelo);

        Console.WriteLine("Promedio original: " + promedio.ToString("F2"));
        Console.WriteLine("Bono calculado: " + bono.ToString("F2"));
        Console.WriteLine("Promedio final: " + promedioFinal.ToString("F2"));
        Console.WriteLine("Cantidad aprobadas: " + aprobadas);
        Console.WriteLine("Clasificacion: " + clasificacion);

        Console.WriteLine("\nGracias por usar el sistema.");
        Console.ReadKey();
    }
}