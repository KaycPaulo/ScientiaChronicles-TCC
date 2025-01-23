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
        for (int i = 0; i < maxSlots; i++)
        {
            // Instancia o slotPrefab dentro do painel do inventário
            GameObject slotGo = Instantiate(slotPrefab, inventoryPainel);

            // Aqui, vamos garantir que o slotPrefab tem uma imagem para o fundo do slot
            Image slotImage = slotGo.GetComponent<Image>();  // 
            Image iconItem = slotGo.GetComponentInChildren<Image>();  

            // Inicializa o slot com o Image do ícone
            InventorySlot slot = new InventorySlot();
            slot.Initialize(slotImage, iconItem);  // Passando o iconItem corretamente

            slots[i] = slot;
        }
    }

    private void ToggleInventory()
    {
        isInventoryOpen = !isInventoryOpen;
        inventoryPanel.SetActive(isInventoryOpen);
    }


    // Teste da função do inventario
    public void AddGetItem()
    {
        if (itensList != null && itensList.itens.Count > 0)
        {
            Itens getItem = itensList.itens[0];
            addItensInventory(getItem, 1);
        }
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
    }

    public int GetItemQuantity(Itens item){
        int totalAmount = 0;

        foreach(var slot in slots){
            if(slot.itens != null && slot.itens.id == item.id){
                totalAmount += slot.GetQuantity();
            }
        }
        return totalAmount;
    }
}