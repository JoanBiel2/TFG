using UnityEngine;
using UnityEngine.InputSystem;

public class Item : MonoBehaviour
{
    [SerializeField] private string evidencename; //Nombre del objeto
    [SerializeField] private int quantity; //No se usa
    [SerializeField] private Sprite sprite; //Como se ve en el inventario
    [TextArea][SerializeField] private string desc; //Descripción del objeto

    private InventoryManager inventorymanager;
    private PlayerInput pi; //Para recoger pruebas con un botón

    private bool playernear;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        inventorymanager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>(); //Recupera el script de InventoryManager
        pi = GameObject.Find("Player").GetComponentInChildren<PlayerInput>();
        playernear = false;
    }
    // Update is called once per frame
    private void Update()
    {
        if (playernear && pi.actions["Interact"].IsPressed()) //Cuando el personaje este en el area de colision, deberia de recoger el objeto pulsando la E.
            {
                inventorymanager.AddItem(evidencename, quantity, sprite, desc);
                Destroy(gameObject);
            }
    }

    private void OnTriggerEnter(Collider collision)
    //Hacer que aparezca un panel donde indique cuando se puede recoger el objeto
    {
        if (collision.gameObject.tag == "Player")
        {
            playernear = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playernear = false;
        }
    }

}
