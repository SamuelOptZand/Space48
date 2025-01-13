using UnityEngine;
public class Movement : MonoBehaviour
{
    private float movespeed = 5f;
    private float rotationspeed = 25f;
    public float MoveSpeed {get{return movespeed;} set{movespeed = value;}}
    public float RotationSpeed {get{return rotationspeed;} set{rotationspeed = value;}}
    void Update()
    {
        transform.position = transform.position + transform.forward * MoveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
        transform.Rotate(transform.up * RotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));
    }
}
