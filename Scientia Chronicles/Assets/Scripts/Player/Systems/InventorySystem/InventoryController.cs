using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public List<InventorySlot> slots;
    public ListItem itensList;
    public int maxSlots;
    public GameObject inventoryPanel;
    public GameObject slotPrefab;
    public Text title;
    public Transform inventoryPainel;

    public bool isInventoryOpen = false;

    private void Awake()
    {
        inventoryPanel.SetActive(false);
        title.enabled = false;
        InitializeSlots();
        CreateInventoryUI();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleInventory();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            AddGetItem();
        }
    }

    private void InitializeSlots()
    {
        slots = new List<InventorySlot>(maxSlots);
        for (int i = 0; i < maxSlots; i++)
        {
            slots.Add(new InventorySlot());
        }
    }

    private void CreateInventoryUI()
    {
        slots = new List<InventorySlot>(maxSlots);

        for (int i = 0; i < maxSlots; i++)
        {
            // Instancia o slotPrefab dentro do painel do inventário
            GameObject slotGo = Instantiate(slotPrefab, inventoryPainel);
            Image slotImage = slotGo.GetComponent<Image>();

            InventorySlot slot = new InventorySlot();
            slot.Initialize(slotImage, null);

            slots.Add(slot);
        }
    }

    private void ToggleInventory()
    {
        isInventoryOpen = !isInventoryOpen;
        inventoryPanel.SetActive(isInventoryOpen);
        Debug.Log("Inventário" + (isInventoryOpen ? "aberto" : "fechado"));
    }


    // Teste da função do inventario
    public void AddGetItem()
    {
        if (itensList == null || itensList.itens == null || itensList.itens.Count == 0)
        {
             Debug.Log("Nenhum item disponível na lista.");
             return;
        }

        // pega um item da posição zero da lista
        
        Itens getItem = itensList.itens[0];
        
        addItensInventory(getItem, 1);  // Passando o item resgatado e a quantidade 1
    }


    public void addItensInventory(Itens itens, int amount)
    {
        bool itemAdded = false;

        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].isEmpty())
            {
                slots[i].AddItens(itens, amount);  // Adiciona o item ao slot
                itemAdded = true;
                break;  // Sai do loop após adicionar o item
            }
        }

        if (!itemAdded)
        {
            Debug.Log("Inventário cheio! Não foi possível adicionar o item.");
        }

    }

}