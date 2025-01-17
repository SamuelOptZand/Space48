using UnityEngine;

public class Movement : MonoBehaviour
{
    private float movespeed = 5f;
    private float rotationspeed = 25f;
    private float LaserSpeed = 300;

    public float MoveSpeed {get{return movespeed;} set{movespeed = value;}}
    public float RotationSpeed {get{return rotationspeed;} set{rotationspeed = value;}}

    void Update()
    {
        if (CompareTag("Player"))
        {
            MovePlayer(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
        }
        else
        {
            MovePlayer(new Vector2(0, 1));
        }
    }
    private void MovePlayer(Vector2 input)
    {
        transform.position = transform.position + transform.forward * MoveSpeed * input.y * Time.deltaTime;
        transform.Rotate(transform.up * RotationSpeed * Time.deltaTime * input.x);
    }
}