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
    
    void OnTriggerEnter(Collider other)
    {
        if (teleportando) return;
        
        // CASO 1: Es el jugador - CAMBIA DE ESCENA
        if (other.CompareTag("Player"))
        {
            teleportando = true;
            PortalManager.posicionLlegada = posicionDestino;
           // PortalManager.objetoATeletransportar = null;
            SceneManager.LoadScene(nombreEscenaDestino);
        }
        // CASO 2: Es un objeto - SOLO LO TELETRANSPORTA, NO CAMBIA ESCENA
        else if (teletransportarObjetos && other.CompareTag("Teletransportable"))
        {
            TeletransportarObjeto(other.gameObject);
        }
    }
    
    void TeletransportarObjeto(GameObject obj)
    {
        // Guardar datos del objeto antes de destruirlo
        GuardarDatosObjeto(obj);
        
        // Destruir el objeto original
        Destroy(obj);
        
        // Crear copia en el destino
        Invoke("CrearObjetoEnDestino", 0.1f);
    }
    
    void GuardarDatosObjeto(GameObject obj)
    {
        // Guardar posición relativa al portal
        PortalManager.ultimoObjeto = obj.tag;
        PortalManager.ultimaPosicion = posicionDestino;
        
        // Guardar escala y rotación
        PortalManager.ultimaEscala = obj.transform.localScale;
        PortalManager.ultimaRotacion = obj.transform.rotation;
        
        // Guardar color si tiene material
        Renderer r = obj.GetComponent<Renderer>();
        if (r != null && r.material != null)
        {
            PortalManager.ultimoColor = r.material.color;
        }
    }
    
    void CrearObjetoEnDestino()
    {
        // Este método se llama DESDE la escena destino
        // Necesitamos un objeto gestor allí
    }
}