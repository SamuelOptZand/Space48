using UnityEngine;
public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject laserPrefab;
    private float cooldowntime = 3f;
    private float cooldownCounter = 0f;
    public float CoolDownTime { get { return cooldowntime; } set { cooldowntime = value; } }
    void Update()
    {
        cooldownCounter += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && cooldownCounter > CoolDownTime)
        {
            GameObject laser = Instantiate(laserPrefab);
            laser.transform.position = transform.position;
            laser.transform.rotation = transform.rotation;
            Destroy(laser, 3f);

            cooldownCounter = 0f;
        }
    }
}