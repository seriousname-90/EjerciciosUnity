using UnityEngine;

public class ObjetoTeletransportable : MonoBehaviour
{
    public bool destruirAlTeletransportar = false; // Para objetos descartables
    
    // Este método se llama cuando el objeto pasa por un portal
    public void PrepararParaTeletransporte()
    {
        // Opcional: Desactivar físicas temporalmente
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true; // Para que no se mueva durante el viaje
        }
        
        // Opcional: Efecto visual
        Debug.Log($"{gameObject.name} está siendo teletransportado");
    }
    
    // Este método se llama cuando aparece en el destino
    public void CompletarTeletransporte()
    {
        // Reactivar físicas
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false;
        }
        
        // Pequeño impulso para que sea obvio que llegó
        if (rb != null)
        {
            rb.AddForce(Vector3.up * 2f, ForceMode.Impulse);
        }
        
        Debug.Log($"{gameObject.name} ha llegado a su destino");
    }
}