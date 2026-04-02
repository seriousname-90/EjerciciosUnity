using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalAvanzado : MonoBehaviour
{
    [Header("Configuración del Portal")]
    public string nombreEscenaDestino;
    public Vector3 posicionDestino = new Vector3(0, 1, 0);
    
    [Header("Configuración de Objetos")]
    public bool teletransportarObjetos = true;
    
    private bool teleportando = false;
    
    void OnTriggerEnter(Collider other) // Detecta al jugador o a objetos teletransportables
    {
        if (teleportando) return; // Evita múltiples activaciones mientras se carga la escena
        
        if (other.CompareTag("Player")) // Si el jugador entra, carga la nueva escena
        {
            teleportando = true;
            PortalManager.posicionLlegada = posicionDestino;
            SceneManager.LoadScene(nombreEscenaDestino);
        }
        else if (teletransportarObjetos && other.CompareTag("Teletransportable")) // Si un objeto teletransportable entra, guarda sus datos para recrearlo en la nueva escena
        {
            TeletransportarObjeto(other.gameObject);
        }
    }
    
    void TeletransportarObjeto(GameObject obj) // Guarda los datos del objeto y lo destruye para que el gestor de destino lo recree en la nueva escena
    {
        GuardarDatosObjeto(obj);
        Destroy(obj);
    }
    
    void GuardarDatosObjeto(GameObject obj) // Guarda la información del objeto para recrearlo en el destino 
    {
        PortalManager.ultimoObjeto = obj.tag;
        PortalManager.ultimaPosicion = posicionDestino;
        PortalManager.ultimaEscala = obj.transform.localScale;
        PortalManager.ultimaRotacion = obj.transform.rotation;
    }
}