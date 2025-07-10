using UnityEngine;
using UnityEngine.InputSystem;

public class Item : MonoBehaviour
{
    [SerializeField] private string evidencename;
    [SerializeField] private int quantity; //Deberia de haber solo una prueba de cada
    [SerializeField] private Mesh mesh;
    [SerializeField] private Sprite sprite;

    private InventoryManager inventorymanager;
    private PlayerInput pi;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inventorymanager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>(); //Recupera el script de InventoryManager
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //if (pi.actions["Interact"].IsPressed()) //Cuando el personaje este en el area de colision, deberia de recoger el objeto pulsando la E.
            //{
                inventorymanager.AddItem(evidencename, quantity, mesh, sprite);
                Destroy(gameObject);
            //}
        }
    }
}
