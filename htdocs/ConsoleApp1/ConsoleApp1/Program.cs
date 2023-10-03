using System;
using System.IO;
using System.Timers;

class Program
{
    private static Timer timer;

    static void Main()
    {
        
        timer = new Timer(5000);
        timer.Elapsed += OnTimerElapsed;

        
        timer.Start();

        Console.WriteLine("El programa está en ejecución. Presiona Enter para detenerlo.");
        Console.ReadLine();

        
        timer.Stop();
    }

    private static void OnTimerElapsed(object sender, ElapsedEventArgs e)
    {
        
        DateTime horaActual = DateTime.Now;

       
        string horaActualStr = horaActual.ToString("HH:mm");

        
        string rutaArchivo = "C:\\Apache24\\htdocs\\api\\v1\\dinamico\\hora"; 

        try
        {
            // Sobreescribir el archivo con la hora actual
            File.WriteAllText(rutaArchivo, horaActualStr);

            Console.WriteLine($"La hora actual ({horaActualStr}) se ha guardado en el archivo.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al escribir en el archivo: {ex.Message}");
        }
    }
}

