using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventaryController : MonoBehaviour
{
    public Inventary inventary;
    public GameObject[] items;
    public Image[] images;

    void Start()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++) {
            items[i] = gameObject.transform.GetChild(i).gameObject;
            images[i] = items[i].GetComponent<Image>();
        }
    }

    void Update()
    {
        for (int i = 0;  i < gameObject.transform.childCount; i++) {
            if (inventary.items[i])
            images[i].sprite = inventary.items[i].sprite;
        }
    }
}
