using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class MenuInstanciador : MonoBehaviour
{
    [Header("Referencias UI")]
    public Dropdown dropdownObjetos;
    public Toggle toggleGravedad;
    public Slider sliderMin;
    public Slider sliderMax;
    public Button botonCrear;
    
    [Header("Posición de creación")]
    public Vector3 posicionCreacion = new Vector3(0, 2.5f, -3f);
    
    void Start()
    {
        if (botonCrear != null)
            botonCrear.onClick.AddListener(CrearObjeto);
    }
    
    void CrearObjeto()
    {
        // Obtener tipo
        string tipo = dropdownObjetos.options[dropdownObjetos.value].text;
        
        // Obtener escala (valor aleatorio entre min y max)
        float escala = Random.Range(sliderMin.value, sliderMax.value);
        
        // Obtener gravedad
        bool gravedad = toggleGravedad.isOn;
        
        // Crear objeto
        GameObject nuevoObjeto = null;
        
        switch (tipo)
        {
            case "Cubo":
                nuevoObjeto = GameObject.CreatePrimitive(PrimitiveType.Cube);
                break;
            case "Esfera":
                nuevoObjeto = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                break;
            case "Capsula":
                nuevoObjeto = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                break;
        }
        
        if (nuevoObjeto != null)
        {
            // Posición
            nuevoObjeto.transform.position = posicionCreacion;
            
            // Escala
            nuevoObjeto.transform.localScale = Vector3.one * escala;
            
            // Rigidbody
            Rigidbody rb = nuevoObjeto.AddComponent<Rigidbody>();
            rb.useGravity = gravedad;
            
             // XR Grab Interactable con configuración específica
            XRGrabInteractable grab = nuevoObjeto.AddComponent<XRGrabInteractable>();
            grab.movementType = XRBaseInteractable.MovementType.Kinematic;
            grab.useDynamicAttach = true;
            
            Debug.Log($"Creado: {tipo}, Escala: {escala}, Gravedad: {gravedad}");
        }
    }
}