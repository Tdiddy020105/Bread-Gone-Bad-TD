using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum ItemType
{
    Weapon,
    Armor,
    Consumable
}

class Item
{
    public string Name;
    public ItemType Type;
}

class Player
{
    public string Name;
    public int Health;
    public Item[] Inventory;
}

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SaveStateSerializer saveStateSerializer = new SaveStateSerializer();

        var player = new Player
        {
            Name = "Bob",
            Health = 100,
            Inventory = new[]
            {
                new Item {Name = "Sword", Type = ItemType.Weapon},
                new Item {Name = "Shield", Type = ItemType.Armor},
                new Item {Name = "Health Potion", Type = ItemType.Consumable}
            }
        };

        bool serialized = saveStateSerializer.JSONToFile<Player>("player", player);

        Debug.Log(serialized);

        Player data = saveStateSerializer.FileToJSON<Player>("player");

        Debug.Log(data.Name);
        Debug.Log(data.Health);
        Debug.Log($"{data.Inventory[0].Name} {data.Inventory[0].Type}");
        Debug.Log($"{data.Inventory[1].Name} {data.Inventory[1].Type}");
        Debug.Log($"{data.Inventory[2].Name} {data.Inventory[2].Type}");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
