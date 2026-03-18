using UnityEngine;

public class MultiplicarBola : MonoBehaviour
{
    void Start()
    {
        float alturaBola = 0.5f; // La altura de cada bola 
        float desplazamientoHorizontal = 0.05f; // Pequeño desplazamiento para que resbalen
        
        for (int i = 0; i < 39; i++)
        {
            // Calcular posición:
            // - En Y: sube cada bola por su altura (para que queden en torre)
            // - En X y Z: pequeño desplazamiento aleatorio para que resbalen
            Vector3 posicion = transform.position + new Vector3(
                Random.Range(-desplazamientoHorizontal, desplazamientoHorizontal), // X aleatorio
                (i + 1) * alturaBola, // Y: cada bola más arriba
                Random.Range(-desplazamientoHorizontal, desplazamientoHorizontal) // Z aleatorio
            );
            
            // Crea la copia
            GameObject nuevaBola = Instantiate(gameObject, posicion, transform.rotation);
            nuevaBola.name = gameObject.name + " (Copia)";
            
            // Quitar el script de la copia para que no se multiplique otra vez
            Destroy(nuevaBola.GetComponent<MultiplicarBola>());
        }
        
        Debug.Log("14 bolas creadas en torre con desplazamiento");
    }
}