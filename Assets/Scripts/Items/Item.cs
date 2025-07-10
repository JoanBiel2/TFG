using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private string evidencename;
    [SerializeField] private int quantity; //Deberia de haber solo una prueba de cada
    [SerializeField] private Mesh mesh;

    private InventoryManager inventorymanager;
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
            inventorymanager.AddItem(evidencename, quantity, mesh);
            Destroy(gameObject);
        }
    }
}
