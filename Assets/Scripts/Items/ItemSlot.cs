using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class ItemSlot : MonoBehaviour, IPointerClickHandler, ISelectHandler
{

    public string itemname;
    public Sprite itemsprite;
    public bool isFull;
    public string itemdesc;

    [SerializeField] private Image ItemImage;

    public GameObject selectedShader;
    public bool itemSelected;

    private InventoryManager inventorymanager;

    public Image itemDescriptionimage;
    public TMP_Text ItemDesciptionNameText;
    public TMP_Text ItemDesciptionText;

    private void Start()
    {
        inventorymanager = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();
    }
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
        if (itemname == "") {
            Debug.Log("No hay objeto en este slot");
            itemDescriptionimage.sprite = Resources.Load<Sprite>("UI/PNG/PanelWindow");
        }
        else {
            itemDescriptionimage.sprite = itemsprite;
        }
    }
}
