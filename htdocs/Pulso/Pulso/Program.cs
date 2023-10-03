using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Timers;
using System.Threading;

namespace Pulso
{
    class Program
    {
        static void Main()
        {
            string filePath = "C:\\Apache24\\htdocs\\api\\v1\\dinamico\\pulso"; 
            int intervaloMinutos = 5; 

            while (true)
            {
                int pulso = CapturarPulsoDesdeConsola();


                File.WriteAllText(filePath, $"{pulso}");

                Console.WriteLine($"Pulso guardado: {pulso} BPM");

                Thread.Sleep(TimeSpan.FromMinutes(intervaloMinutos));
            }
        }

        static int CapturarPulsoDesdeConsola()
        {
            int pulso;
            while (true)
            {
                Console.Write("ingresa el pulso cardíaco: ");
                if (int.TryParse(Console.ReadLine(), out pulso))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Valor no válido. Intente nuevamente.");
                }
            }
            return pulso;
        }
    }

}
