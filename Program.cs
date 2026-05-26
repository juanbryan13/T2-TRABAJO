using System;

class Notas
{
  static (double promedio, int maximo, int minimo) Estadisticas(int[] notas, int n)
    {
        int suma = 0;
        int maximo = notas[0];
        int minimo = notas[0];

        for (int i = 0; i < n; i++)
        {
            suma += notas[i];
            if (notas[i] > maximo) maximo = notas[i];
            if (notas[i] < minimo) minimo = notas[i];
        }

        double promedio = (double)suma / n;
     return (promedio, maximo, minimo);
    }

    static int Aprobados(int[] notas, int n)
    {
        int count = 0;
        for (int i = 0; i < n; i++)
        {
            if (notas[i] >= 12) count++;
        }
        return count;
    } static void Main()
    {
        int n;
        while (true)
        {
            Console.Write("¿Cuántas notas deseas ingresar?: ");
            if (int.TryParse(Console.ReadLine(), out n) && n > 0)
            {
                break;
            }
            Console.WriteLine("Por favor, ingresa un número entero mayor a 0.");
        }

        int[] notas = new int[n];
        int i = 0;

        while (i < n)
        {
            Console.Write($"Ingresa la nota {i + 1}: ");

            if (int.TryParse(Console.ReadLine(), out int nota) && nota >= 0 && nota <= 20)
            {
                notas[i] = nota;
                i++;
            }
            else
            {
                Console.WriteLine("Nota inválida. Debe ser un número entero entre 0 y 20.");
            }
        }
       var (promedio, maximo, minimo) = Estadisticas(notas, n);

        int apro = Aprobados(notas, n);
        int desap = n - apro;
        double pApro = Math.Round((double)apro / n * 100, 2);
        double pDesap = Math.Round((double)desap / n * 100, 2);

        Console.WriteLine("\n--- Reporte del Salón ---");
        Console.Write("Notas ingresadas: [");
        for (int j = 0; j < n; j++)
        {
            Console.Write(notas[j]);
            if (j < n - 1) Console.Write(", ");
        }
        Console.WriteLine("]");
        Console.WriteLine($"Promedio    : {promedio:F2}");
        Console.WriteLine($"Nota máxima : {maximo}");
        Console.WriteLine($"Nota mínima : {minimo}");
        Console.WriteLine($"\nAprobados   : {apro} ({pApro:F2}%)");
        Console.WriteLine($"Desaprobados: {desap} ({pDesap:F2}%)");

        if (pDesap > 75.0)
        {
            Console.WriteLine("\n⚠ ALERTA: Más del 75% del salón ha desaprobado.");
        }
    }
}