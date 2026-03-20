using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;  // Para XRGrabInteractable

public class GestorDestino : MonoBehaviour
{
    [Header("Prefabs de objetos")]
    public GameObject prefabPorDefecto; // Modelo genérico por si acaso
    
    void Start()  // Se ejecuta automáticamente al iniciar la escena
    {
        // Verifica si hay un objeto esperando ser creado
        if (!string.IsNullOrEmpty(PortalManager.ultimoObjeto))
        {
            CrearObjetoTeletransportado();  // Si sí, lo crea
        }
    }
    
    void CrearObjetoTeletransportado()
    {
        GameObject nuevoObjeto = null;  // Variable para el objeto que crearemos
        
        // Elegir qué tipo de objeto crear según el tag guardado
        switch (PortalManager.ultimoObjeto)
        {
            case "Teletransportable":  // Si el objeto original tenía este tag
                nuevoObjeto = Instantiate(prefabPorDefecto,  // Crea copia del modelo
                    PortalManager.ultimaPosicion,  // En la posición guardada
                    PortalManager.ultimaRotacion); // Con la rotación guardada
                break;
            default:  // Por si acaso (fallback)
                nuevoObjeto = Instantiate(prefabPorDefecto, 
                    PortalManager.ultimaPosicion, 
                    PortalManager.ultimaRotacion);
                break;
        }
        
        if (nuevoObjeto != null)  // Si se creó correctamente
        {
            // Restaurar el tamaño original
            nuevoObjeto.transform.localScale = PortalManager.ultimaEscala;
            
            // Restaurar el color original
            Renderer r = nuevoObjeto.GetComponent<Renderer>();
            if (r != null)
            {
                r.material.color = PortalManager.ultimoColor;
            }
            
            // Asegurar que tiene Rigidbody para física
            if (nuevoObjeto.GetComponent<Rigidbody>() == null)
                nuevoObjeto.AddComponent<Rigidbody>();
                
            // Asegurar que se puede agarrar en VR
            if (nuevoObjeto.GetComponent<XRGrabInteractable>() == null)
                nuevoObjeto.AddComponent<XRGrabInteractable>();
                
            // Darle un pequeño impulso al aparecer (para que se note)
            Rigidbody rb = nuevoObjeto.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.up * 2f, ForceMode.Impulse);
            
            Debug.Log("Objeto recreado en destino");
        }
        
        PortalManager.Reset();  // Limpia los datos guardados
    }
}