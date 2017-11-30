using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class Inventory : MonoBehaviour
{
    //List of items in the inventory
    public List<Item> inventory = new List<Item>();

    //List of items visualised in inventorySlots
    public List<Item> inventorySlots = new List<Item>();

    private AudioClip invOpenSound, invCloseSound;

    //reference to database
    private ItemDatabase database;

    bool showInventory;

    public int slotsX = 2, slotsY = 5;

    public static Inventory instance;
    
    int indexitem = 0;

    private void Awake()
    {
        //kolla om en instans av soundmanager redan är i scenen.
        if (instance == null)
        {
            instance = this;
        }

        //ser till att det bara är en soundmanager instansierad.
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {

        showInventory = false;

        database = GameObject.FindGameObjectWithTag("Item Database").GetComponent<ItemDatabase>();

        for (int i = 0; i < (slotsX * slotsY); i++)
        {
            inventory.Add(new Item());
            inventorySlots.Add(new Item());

        }

        invOpenSound = Resources.Load<AudioClip>("Audio/Inventory/openInv");
        invCloseSound = Resources.Load<AudioClip>("Audio/Inventory/closeInv");
    }


    void Update()
    {

        //open and close inventory.
        if (Input.GetButtonDown("Inventory"))
        {
            if (!showInventory)
            {
                Debug.Log("inventory Open");
                SoundManager.instance.PlaySingle(invOpenSound);
                showInventory = true;
            }

            else
            {
                Debug.Log("inventory Closed");
                SoundManager.instance.PlaySingle(invCloseSound);
                showInventory = false;
            }
        }
    }

    //creates inventory if Inventorykey is pressed.
    private void OnGUI()
    {
        if (showInventory)
        {
            GUI.DrawTexture(new Rect(0, 0, 350, 350), Resources.Load<Texture2D>("Sprites/UI/InventoryBackground"), ScaleMode.ScaleToFit);

            OpenInventory();
        }
    }


    //creates the visual inventory and loads in itemicons.
    public void OpenInventory()
    {
        int i = 0;

        for (int y = 1; y < slotsY + 1; y++)
        {
            for (int x = 1; x < slotsX + 1; x++)
            {
                Rect slotRect = new Rect((x * 75) + 20, (y * 40) + 70, 75, 75);

                GUI.Box(slotRect, Resources.Load<Texture2D>("Sprites/UI/InventorySlot"), GUIStyle.none);

                if (inventory[i].itemName != null)
                {
                    GUI.Box(slotRect, inventory[i].itemIcon, GUIStyle.none);

                }

                i++;
            }
        }

    }
    //used to remove item from inventory by name.
    [YarnCommand("RemoveItem")]
    public void RemoveItem(string nameOfItem)
    {
        int removeIndex = -1;

        removeIndex = inventory.FindIndex(i => i.itemName == nameOfItem);

        if (removeIndex != -1)
        {
            for (int i = removeIndex; i <= inventory.Count -1; i++)
            {   
                if (i < inventory.Count - 1)
                {
                    inventory[i] = inventory[i + 1];
                }
                
                else
                {
                    inventory[i] = new Item();
                    indexitem--;
                }
            }
        }


    }

    // used to add item to inventory by name.
    [YarnCommand("AddItem")]
    public void AddItem(string nameOfItem)
    {
        int databaseIndex = -1;

        databaseIndex = database.items.FindIndex(i => i.itemName == nameOfItem);

        if (databaseIndex != -1)
        {
            inventory[indexitem] = database.items[databaseIndex];
            indexitem++;
        }

    }
}

//Stina Hedman

