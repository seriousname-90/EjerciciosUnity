using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AjustePosicionInicial : MonoBehaviour
{
    public GameObject xrOrigin;
    public GestorDestino gestorDestino; // Opcional
    
    void Start()
    {
        if (xrOrigin != null)
        {
            xrOrigin.transform.position = PortalManager.posicionLlegada;
        }
        
        // Si hay un gestor en esta escena, se encargará de crear objetos
        // El Start() de GestorDestino se ejecutará automáticamente
    }
}