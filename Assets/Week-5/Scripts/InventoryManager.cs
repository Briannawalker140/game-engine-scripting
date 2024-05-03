using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    
    public List<AllItems> _inventoryItems = new List<AllItems>();

    public void Awake()
    {
        Instance = this;
    }

    //Adds items to inventory
    public void AddItems(AllItems item)
    {
        if (!_inventoryItems.Contains(item))
        {
            _inventoryItems.Add(item);
        }
    }

    //Removes items from inventory
    public void RemoveItems(AllItems item)
    {
        if (_inventoryItems.Contains(item))
        {
            _inventoryItems.Remove(item);
        }
    }
    //All available inventory items in game
    public enum AllItems
    {
        Key,
        Coins
    }

}
