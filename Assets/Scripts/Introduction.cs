using System.Collections;
using TMPro;
using UnityEngine;
public class Introduction : MonoBehaviour
{
    [SerializeField] private TMP_Text introductionField;
    void Start()
    {
        StartCoroutine(IntroductionText());
    }
    IEnumerator IntroductionText()
    {
        introductionField.enabled = true;
        introductionField.text = "Welcome to Space 4 8. \n Move your ship with the arrows or WASD. \n Shoot with SPACE. \n Gather pickups and cycle with 'Left CTR'.  \n  Use pickups with 'E'.";
        yield return new WaitForSeconds(5f);
        introductionField.enabled = false;
    }

}