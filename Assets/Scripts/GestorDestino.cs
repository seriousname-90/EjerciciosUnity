using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;  // Para XRGrabInteractable

public class GestorDestino : MonoBehaviour
{
    [Header("Prefab del objeto teletransportable")]
    public GameObject prefabObjeto;
    
    void Start()  
    {
        if (!string.IsNullOrEmpty(PortalManager.ultimoObjeto)) // Verifica si hay un objeto esperando ser creado
        {
            CrearObjetoTeletransportado();  // Si sí, lo crea
        }
    }
    
    void CrearObjetoTeletransportado()
    {
        
        GameObject nuevoObjeto = Instantiate(prefabObjeto,
            PortalManager.ultimaPosicion,
            PortalManager.ultimaRotacion);

        nuevoObjeto.transform.localScale = PortalManager.ultimaEscala;

        if (nuevoObjeto.GetComponent<Rigidbody>() == null)
            nuevoObjeto.AddComponent<Rigidbody>();

        if (nuevoObjeto.GetComponent<XRGrabInteractable>() == null)
            nuevoObjeto.AddComponent<XRGrabInteractable>();

        Rigidbody rb = nuevoObjeto.GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * 2f, ForceMode.Impulse);

        Debug.Log("Objeto recreado en destino");

        PortalManager.Reset();
    }
}