using UnityEngine;

public class ColeccionableTrigger : MonoBehaviour
{
    public AudioClip sonidoPop;
    public AudioClip sonidoWrong;
    public string saborAceptado; 
    
    private AudioSource miAudioSource;
    
    void Start()
    {
        miAudioSource = GetComponent<AudioSource>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Vainilla") || 
            other.CompareTag("Chocolate") || 
            other.CompareTag("Fresa"))
        {
            string saborBola = other.tag;
            
            if (saborBola == saborAceptado)
            {
                Debug.Log($" ¡Correcto! {saborBola}");
                if (miAudioSource != null && sonidoPop != null)
                    miAudioSource.PlayOneShot(sonidoPop);
            }
            else
            {
                Debug.Log($" Error: {saborBola} en contenedor de {saborAceptado}");
                if (miAudioSource != null && sonidoWrong != null)
                    miAudioSource.PlayOneShot(sonidoWrong);
            }
            
            Destroy(other.gameObject);
        }
    }
}