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
        
        // SOLO jugador u objetos con tag "Teletransportable" activan el portal
        if (other.CompareTag("Player") || other.CompareTag("Teletransportable"))
        {
            if (other.CompareTag("Player"))
            {
                teleportando = true;
                PortalManager.posicionLlegada = posicionDestino;
                PortalManager.objetoATeletransportar = null;
                SceneManager.LoadScene(nombreEscenaDestino);
            }
            else if (teletransportarObjetos)
            {
                TeletransportarObjeto(other.gameObject);
            }
        }
    }
    
    void TeletransportarObjeto(GameObject obj)
    {
        ObjetoTeletransportable objTele = obj.GetComponent<ObjetoTeletransportable>();
        if (objTele != null)
        {
            objTele.PrepararParaTeletransporte();
        }
        
        PortalManager.objetoATeletransportar = obj;
        PortalManager.posicionLlegada = posicionDestino;
        
        DontDestroyOnLoad(obj);
        SceneManager.LoadScene(nombreEscenaDestino);
    }
}