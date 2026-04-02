using UnityEngine;

public class AjustePosicionInicial : MonoBehaviour
{
    public GameObject xrOrigin;
    
    void Start()
    {
        if (xrOrigin != null)
        {
            xrOrigin.transform.position = PortalManager.posicionLlegada;
        }
    }
}