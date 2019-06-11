using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventary : MonoBehaviour
{
    public InventaryItem[] items;
    public void AddItem(InventaryItem item) {
        for (int i = 0; i < items.Length; i++) {
            if (items[i] == null) {
                items[i] = item;
                return;
            }
        }
    }

    public void RemoveItem(InventaryItem item) {
        for (int i = 0; i < items.Length; i++) {
            if (items[i] == item) {
                items[i] = null;
                return;
            }
        }
    }
}
