using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float velocidad = 50f;

    void Update()
    {
        transform.Rotate(velocidad * Time.deltaTime, velocidad * Time.deltaTime, 0);
    }
}