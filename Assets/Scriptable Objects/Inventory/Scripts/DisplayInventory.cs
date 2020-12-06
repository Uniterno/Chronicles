using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class DisplayInventory : MonoBehaviour
{
    public MouseItem mouseItem = new MouseItem();
    public InventoryObject inventory;
   
    public Dictionary<GameObject, inventorySlots> ItemsDisplayed = new Dictionary<GameObject, inventorySlots>();
    
    //public Dictionary<GameObject, inventorySlots> GetItem = new Dictionary<GameObject, inventorySlots>();
    public GameObject inventoryPrefab;
    
    private void Start()
    {
       CreateSpaces();
    }


    private void Update()
    {
       UpdateSlot();

        for (int i = 0; i < inventory.Container.Cards.Length; i++)
        {
            Debug.Log(inventory.Container.Cards[i].ID);
        }
        
    }

    public void UpdateSlot()
    {
        foreach (KeyValuePair<GameObject,inventorySlots>_slot in ItemsDisplayed)
        {
            if (_slot.Value.ID >=0)
            {
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().sprite  = inventory.database.GetCard[_slot.Value.item.ID].toDisplay;
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(1, 1, 1, 1);
                _slot.Key.GetComponentInChildren<TextMeshProUGUI>().text = _slot.Value.ammount == 1 ? "" : _slot.Value.ammount.ToString("n0");
            }
            else
            {
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().sprite = null;
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(1, 1, 1, 0);
                _slot.Key.GetComponentInChildren<TextMeshProUGUI>().text = "";
            }
        }
    }

    public void CreateSpaces()
    {
        /*
         for (int i = 0; i < inventory.Container.Cards.Count; i++)
         {
             inventorySlots slot = inventory.Container.Cards[i];
             var obj = Instantiate(inventoryPrefab, Vector3.zero, Quaternion.identity, transform);
             obj.transform.GetChild(0).GetComponentInChildren<Image>().sprite = inventory.database.GetCard[slot.item.ID].toDisplay;
             //obj.GetComponent<RectTransform>().localPosition = getPos(i);
             obj.GetComponentInChildren<TextMeshProUGUI>().text = slot.ammount.ToString("n0");
             addEvent(obj,EventTriggerType.PointerEnter, delegate { OnEnter(obj);});
             addEvent(obj, EventTriggerType.PointerExit, delegate { OnExit(obj); });
             addEvent(obj, EventTriggerType.BeginDrag, delegate { OnDragStart(obj); });
             addEvent(obj, EventTriggerType.EndDrag, delegate { OnDragEnd(obj); });
             addEvent(obj, EventTriggerType.Drag, delegate { OnDrag(obj); });
             ItemsDisplayed.Add(slot, obj);
         }*/
        ItemsDisplayed = new Dictionary<GameObject, inventorySlots>();
        
        for (int i = 0; i < inventory.Container.Cards.Length; i++)
        {
            var obj = Instantiate(inventoryPrefab, Vector3.zero, Quaternion.identity, transform);
            //obj.GetComponent<RectTransform>

            addEvent(obj, EventTriggerType.PointerExit, delegate { OnExit(obj); });
            addEvent(obj, EventTriggerType.BeginDrag, delegate { OnDragStart(obj); });
            addEvent(obj, EventTriggerType.EndDrag, delegate { OnDragEnd(obj); });
            addEvent(obj, EventTriggerType.Drag, delegate { OnDrag(obj); });
            
            ItemsDisplayed.Add(obj,inventory.Container.Cards[i]);
        }



    }
    public void addEvent(GameObject obj, EventTriggerType type, UnityAction<BaseEventData> action)
    {
        EventTrigger trigger = obj.GetComponent<EventTrigger>();
        var eventTrigger = new EventTrigger.Entry();
        eventTrigger.eventID = type;
        eventTrigger.callback.AddListener(action);
        trigger.triggers.Add(eventTrigger);
    }

    public void OnEnter(GameObject obj)
    {
        mouseItem.hoverobj = obj;
        if (ItemsDisplayed.ContainsKey(obj))
        {
            mouseItem.hoverItem = ItemsDisplayed[obj];
        }
    }
    public void OnExit(GameObject obj)
    {
        mouseItem.hoverobj = null;       
        mouseItem.hoverItem = null;
        
    }
    public void OnDragStart(GameObject obj)
    {
        var mouseObject = new GameObject();
        var rt = mouseObject.AddComponent<RectTransform>();
        rt.sizeDelta = new Vector2(70, 90);
        mouseObject.transform.SetParent(transform.parent);
        if (ItemsDisplayed[obj].ID >= 0)
        {
            var img = mouseObject.AddComponent<Image>();
            img.sprite = inventory.database.GetCard[ItemsDisplayed[obj].ID].toDisplay;
            img.raycastTarget = false;
        }
        mouseItem.obj = mouseObject;
        mouseItem.card = ItemsDisplayed[obj];
    }
    public void OnDragEnd(GameObject obj)
    {
        if (mouseItem.hoverobj)
        {
            inventory.move(ItemsDisplayed[obj], ItemsDisplayed[mouseItem.hoverobj]);
        }
        else
        {
            inventory.burn(ItemsDisplayed[obj].item);
        }
        Destroy(mouseItem.obj);
        mouseItem.card = null;
    }
    public void OnDrag(GameObject obj)
    {
        if (mouseItem.obj !=null)
        {
            mouseItem.obj.GetComponent<RectTransform>().position = Input.mousePosition;
        }
    }

    public void OnApplicationQuit()
    {
        //inventory.Container.Cards = new inventorySlots[40];
    }

}

public class MouseItem
{
    public GameObject obj;
    public inventorySlots card;
    public inventorySlots hoverItem;
    public GameObject hoverobj;
}
