using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;


    // Struct in C#: Variable of variables
    // Creates a struct where each new memeber of the struct contains a name and Game Object
    [System.Serializable]
    struct InventoryItem

    {
        public string itemName;
        public GameObject item;
    }
    List<InventoryItem> invItems = new List<InventoryItem>();

    private void Awake()
    {
        // Prevents there from being more than one Inventory Manager
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // Prevents from being destroyed when loading new scene
        DontDestroyOnLoad(gameObject);
        instance = this;
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToInventory(string itemName, GameObject item)
    {
        InventoryItem invItem = new InventoryItem();
        invItem.itemName = itemName;
        invItem.item = item;
        invItems.Add(invItem);
    }
}
