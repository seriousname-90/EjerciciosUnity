using UnityEngine;
using System.Collections.Generic;

public static class PortalManager
{
    public static Vector3 posicionLlegada = new Vector3(0, 1, 0);
    
    // Datos del objeto a recrear
    public static string ultimoObjeto = "";
    public static Vector3 ultimaPosicion = Vector3.zero;
    public static Vector3 ultimaEscala = Vector3.one;
    public static Quaternion ultimaRotacion = Quaternion.identity;
    public static Color ultimoColor = Color.white;
    
    public static void Reset()
    {
        posicionLlegada = new Vector3(0, 1, 0);
        ultimoObjeto = "";
    }
}