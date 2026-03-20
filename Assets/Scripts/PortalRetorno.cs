using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalRetorno : MonoBehaviour
{
    [Header("Configuración del Portal de Retorno")]
    public string nombreEscenaOrigen = "Main VR Scene"; // Cambia por el nombre de tu primera escena
    public Vector3 posicionRetorno = new Vector3(0, 1, 0); // Donde aparecerá al volver
    
    private bool teleportando = false;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !teleportando)
        {
            teleportando = true;
            
            // Guardar la posición de retorno
            PortalManager.posicionLlegada = posicionRetorno;
            
            // Cargar la escena original
            SceneManager.LoadScene(nombreEscenaOrigen);
        }
    }
}