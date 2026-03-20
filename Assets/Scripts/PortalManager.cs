using UnityEngine;
using System.Collections.Generic;

public static class PortalManager
{
    public static Vector3 posicionLlegada = new Vector3(0, 1, 0);
    public static GameObject objetoATeletransportar = null; // Objeto que viaja entre escenas
    public static List<GameObject> objetosEnTransito = new List<GameObject>(); // Para múltiples objetos
    
    public static void Reset()
    {
        posicionLlegada = new Vector3(0, 1, 0);
        objetoATeletransportar = null;
        objetosEnTransito.Clear();
    }
}