using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemHandler : MonoBehaviour
{
    [SerializeField] private Image itemImageHolder;
    private Movement MoveM;
    private Gun ShootS;
    private Message MSG;
    private List<Color> items = new List<Color>();
    private int activeItemIndex = -1;
    private void Start()
    {
        MSG = FindObjectOfType<Message>();
        MoveM = GetComponent<Movement>();
        ShootS = GetComponent<Gun>();
    }
    private void Update()
    {
        CycleItems();
        UseItem();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            PickUpItem(other.gameObject);
        }
    }
    private void PickUpItem(GameObject item)
    {
        Color color = item.gameObject.GetComponent<Renderer>().material.color;

        Destroy(item);
        items.Add(color);

        activeItemIndex = items.Count - 1;

        itemImageHolder.color = items[activeItemIndex];
        itemImageHolder.enabled = true;
    }
    private void CycleItems()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (items.Count > 0)
            {
                if (activeItemIndex < items.Count - 1)
                {
                    activeItemIndex++;
                }
                else
                {
                    activeItemIndex = 0;
                }
                itemImageHolder.color = items[activeItemIndex];
            }
            else
            {
                itemImageHolder.color = Color.white;
                activeItemIndex = -1;
                itemImageHolder.enabled = false;
            }
        }
    }
    private void UseItem()
    {
        if (Input.GetKeyDown(KeyCode.E) && items.Count > 0 && activeItemIndex != -1)
        {
            if (items[activeItemIndex] == Color.blue)
            {
                StartCoroutine(MSG.ShowMessage("+ Move Speed"));
                MoveM.MoveSpeed += 5;
            }
            else if (items[activeItemIndex] == Color.red)
            {
                StartCoroutine(MSG.ShowMessage("+ Fire Rate"));
                ShootS.CoolDownTime -= 0.1f;
            }
            else if (items[activeItemIndex] == Color.green)
            {
                StartCoroutine(MSG.ShowMessage("+ Rotation Speed"));
                MoveM.RotationSpeed += 10;
            }
            items.RemoveAt(activeItemIndex);
            if (activeItemIndex > 0)
            {
                activeItemIndex--;
                itemImageHolder.color = items[activeItemIndex];
            }
            else if (items.Count == 0)
            {
                itemImageHolder.color = Color.white;
                activeItemIndex = -1;
                itemImageHolder.enabled = false;
            }
        }
    }
}