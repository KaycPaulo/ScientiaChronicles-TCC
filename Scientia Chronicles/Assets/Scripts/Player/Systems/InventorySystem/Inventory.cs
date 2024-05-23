using System;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory Singleton;
    public static InventoryItem carriedItens;

    [SerializeField]InventorySlot[] inventorySlots;
    [SerializeField] Transform draggablesTransform;
    [SerializeField] InventoryItem itensPrefabs;

    [SerializeField] Itens[] itens;
    [SerializeField] Button giveItensB;

    private void Awake(){
        Singleton = this;
        giveItensB.onClick.AddListener(delegate{SpawnInventoryItens();});
    }

    public void Update(){
        if(carriedItens == null){
            return;
        }

        carriedItens.transform.position = Input.mousePosition;
    }

    public void SetCarriedItens(InventoryItem itens){
        if(carriedItens != null){
            itens.activeSlot.setItem(carriedItens);
        }

        carriedItens = itens;
        carriedItens.canvasGroup.blocksRaycasts = false;
        itens.transform.SetParent(draggablesTransform);
    }

    public void SpawnInventoryItens(Itens itens = null){
        Itens _itens = itens;
        if(_itens != null){
            _itens = PickRandomItens();
        }

        for(int i = 0; i < inventorySlots.Length; i++){
            if(inventorySlots[i] == null){
                Instantiate(itensPrefabs, inventorySlots[i].transform).Initialize(_itens, inventorySlots[i]);
                break;
            }
        }
    }

    private Itens PickRandomItens()
    {
        int random = UnityEngine.Random.Range(0, itens.Length);
        return itens[random];
    }
}
