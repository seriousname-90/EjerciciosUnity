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
    
    [Header("Prefabs")]
    public GameObject prefabCubo;      // Arrastra aquí
    public GameObject prefabEsfera;    // Arrastra aquí
    public GameObject prefabCapsula;   // Arrastra aquí
    public GameObject prefabCuchara; 

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
                nuevoObjeto = Instantiate(prefabCubo);
                break;
            case "Esfera":
                nuevoObjeto = Instantiate(prefabEsfera);
                break;
            case "Capsula":
                nuevoObjeto = Instantiate(prefabCapsula);
                break;
            case "Cuchara":
                nuevoObjeto = Instantiate(prefabCuchara);
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