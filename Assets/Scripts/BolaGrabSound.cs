using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class BolaGrabSound : MonoBehaviour
{
    public AudioClip grabSound;
    public float volumen = 1f;
    public float minDistancia = 1f;
    public float maxDistancia = 20f;
    
    void Start()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        
        // Configuración óptima para VR
        audioSource.spatialBlend = 1f;          // 3D completo
        audioSource.rolloffMode = AudioRolloffMode.Linear;
        audioSource.minDistance = minDistancia;
        audioSource.maxDistance = maxDistancia;
        audioSource.playOnAwake = false;
        
        XRGrabInteractable grab = GetComponent<XRGrabInteractable>();
        grab.selectEntered.AddListener(args => {
            if (grabSound != null)
                audioSource.PlayOneShot(grabSound, volumen);
        });
    }
}