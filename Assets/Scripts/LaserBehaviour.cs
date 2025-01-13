using UnityEngine;
public class LaserBehaviour : MonoBehaviour
{
    private float LaserSpeed = 300;
    void Update()
    {
        transform.position = transform.position + transform.forward * LaserSpeed * Time.deltaTime;
    }
}