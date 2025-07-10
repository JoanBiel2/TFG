using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    //=========ITEM DATA=========//
    public string Itemname;
    public Sprite Itemsprite;
    public bool isFull;


    //=========ITEM SLOT=========//
    [SerializeField] private Image ItemImage;


    public void AddItem(string name, Mesh mesh, Sprite sprite) //lo del mesh tiene que estar vinculado a un Sprite
    {
        this.Itemname = name;
        this.Itemsprite = sprite;
        isFull = true;
        //this.Itemsprite = mesh //El mesh tiene que saber que sprite usar.

        ItemImage.sprite = sprite;
    }
}
