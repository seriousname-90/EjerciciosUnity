using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalOrigen : MonoBehaviour
{
    [Header("Configuración del Portal")]
    public string nombreEscenaDestino = "DemoScene"; // Nombre de la otra escena
    public Vector3 posicionDestino = new Vector3(0, 1, 0); // (0,1,0) para que no caiga por el suelo
    
    private bool teleportando = false; // Evita múltiples teletransportes
    
    void OnTriggerEnter(Collider other)
    {
        // Verificar que quien entró es el jugador y no estamos ya teletransportando
        if (other.CompareTag("Player") && !teleportando)
        {
            teleportando = true;
            
            // Guardar la posición de destino en un lugar accesible
            // (usamos un objeto estático para pasar datos entre escenas)
            PortalManager.posicionLlegada = posicionDestino;
            
            // Cargar la escena destino
            SceneManager.LoadScene(nombreEscenaDestino);
        }
    }
}