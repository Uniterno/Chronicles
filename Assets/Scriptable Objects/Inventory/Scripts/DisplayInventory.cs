using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DisplayInventory : MonoBehaviour
{
    public InventoryObject inventory;
    //public int X_between_item;
    //public int columns;
    //public int y_space_between;
    public Dictionary<inventorySlots, Card> ItemsDisplayed = new Dictionary<inventorySlots, Card>();
    //public int x_start;
    //public int y_start;
    private void Start()
    {
        CreateDisplay();
    }


    private void Update()
    {
        //UpdateDisplay();
    }

    public void CreateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
            //obj.GetComponent<RectTransform>().localPosition = getPos(i);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].ammount.ToString("n0");

        }


    }


    /* public void updateDisplay()
     {
         TextMeshPro temp;
         for (int i = 0; i < inventory.Container.Count; i++)
         {
             if (ItemsDisplayed.ContainsKey(inventory.Container[i])){

                //temp = (Instantiate)ItemsDisplayed[inventory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].ammount.ToString("n0");
                 //ItemsDisplayed[inventory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].ammount.ToString("n0");
             }

             else
             {
                 var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
                 obj.GetComponent<RectTransform>().localPosition = getPos(i);
                 obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].ammount.ToString("n0");
             }

         }
     }*/

    /*public Vector3 getPos(int i )
    {
        return new Vector3(x_start + X_between_item*(i%columns), y_start + ( y_space_between*(i/columns)),0f);
    }*/
}
