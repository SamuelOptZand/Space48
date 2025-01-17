using System.Collections;
using TMPro;
using UnityEngine;

public class Message : MonoBehaviour
{
    [SerializeField] private TMP_Text messageField;
    void Start()
    {
        StartCoroutine(ShowMessage("Welcome to Space 4 8. \n Move your ship with the arrows or WASD. \n Shoot with SPACE. \n Gather pickups and cycle with 'Left CTR'.  \n  Use pickups with 'E'.", 5f));
    }
    public IEnumerator ShowMessage(string message, float wait)
    {
        messageField.enabled = true;
        messageField.text = message;
        yield return new WaitForSeconds(wait);
        messageField.enabled = false;
    }
}