using System;
using System.Collections.Generic;

public class RespuestaIPParser
{
    public static List<string> ParsearRespuesta(string respuesta)
    {
        List<string> nombres = new List<string>();

        // Dividir la respuesta en tres partes usando las comas y par�ntesis
        string[] partes = respuesta.Split(new[] { '(', ')', '[', ']', ',', '\'' }, StringSplitOptions.RemoveEmptyEntries);

        // La primera parte contiene los pares de nombre e IP, as� que empezamos desde el �ndice 0 y avanzamos de 2 en 2
        for (int i = 0; i < partes.Length; i += 2)
        {
            nombres.Add(partes[i].Trim());
        }

        return nombres;
    }
}

