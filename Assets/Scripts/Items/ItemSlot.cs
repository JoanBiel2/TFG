using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerClickHandler, ISelectHandler
{
    //=========ITEM DATA=========//
    public string itemname;
    public Sprite itemsprite;
    public bool isFull;
    public string itemdesc;


    //=========ITEM SLOT=========//
    [SerializeField] private Image ItemImage;

    public GameObject selectedShader;
    public bool itemSelected;

    private InventoryManager inventorymanager;


    private void Start()
    {
        inventorymanager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    //=========ITEM DESCRIPTION SLOT=========//
    public Image itemDescriptionimage;
    public TMP_Text ItemDesciptionNameText;
    public TMP_Text ItemDesciptionText;


    public void AddItem(string name, Sprite sprite, string desc) //lo del mesh tiene que estar vinculado a un Sprite
    {
        this.itemname = name;
        this.itemsprite = sprite;
        this.itemdesc = desc;
        isFull = true;

        ItemImage.sprite = sprite;
    }
    //Detecta cuando el click izquierdo y derecho se presionan
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
    }

    public void OnSelect(BaseEventData eventData)
    {
        OnLeftClick();
    }


    public void OnLeftClick()
    {
        inventorymanager.DeselectAllSlots();
        selectedShader.SetActive(true);
        itemSelected = true;
        ItemDesciptionNameText.text = itemname;
        ItemDesciptionText.text = itemdesc;
        itemDescriptionimage.sprite = itemsprite;

    }
}
