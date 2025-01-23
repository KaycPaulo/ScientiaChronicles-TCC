using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    // Start is called before the first frame update
    public Itens itemData;
    public int amount = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            Debug.Log("Jogador detectado!");
            InventoryController inventory = player.inventoryController;

            if (inventory != null)
            {
                Debug.Log($"Adicionando {itemData.name} ao inventário");
                inventory.addItensInventory(itemData, amount);
                Destroy(gameObject);
            }
            else
            {
                Debug.LogWarning("Nenhum InventoryController encontrado no jogador!");
            }
        }
    }
}
