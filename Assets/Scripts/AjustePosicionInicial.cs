using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables; 

public class AjustePosicionInicial : MonoBehaviour
{
    public GameObject TPObject;

    [System.Obsolete]
    void Start()
    {
        // Mover al jugador
        if (TPObject != null)
        {
            TPObject.transform.position = PortalManager.posicionLlegada;
        }
        
        // Mover objetos que vinieron con el jugador
        if (PortalManager.objetoATeletransportar != null)
        {
            GameObject obj = PortalManager.objetoATeletransportar;
            obj.transform.position = PortalManager.posicionLlegada + Vector3.up * 0.5f; // Un poco arriba
            
            // Opcional: Añadir pequeña fuerza para que sea visible
            Rigidbody rb = obj.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
            
            PortalManager.objetoATeletransportar = null;
        }
        
        // Procesar múltiples objetos si es necesario
        foreach (GameObject obj in PortalManager.objetosEnTransito)
        {
            if (obj != null)
            {
                obj.transform.position = PortalManager.posicionLlegada + Random.insideUnitSphere * 0.3f;
            }
        }
        PortalManager.objetosEnTransito.Clear();
    }
}