using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public class SerializableDictionary<Tkey, Tvalue>:Dictionary<Tkey, Tvalue>, ISerializationCallbackReceiver
{

    [SerializeField] private List<Tkey> keys = new List<Tkey>();
    [SerializeField] private List<Tvalue> values = new List<Tvalue>();

    public void OnBeforeSerialize() //Guarda el diccionario
    {
        keys.Clear();
        values.Clear();
        
        foreach(KeyValuePair<Tkey, Tvalue> pair in this)
        {
            keys.Add(pair.Key);
            values.Add(pair.Value);
        }
    }
    public void OnAfterDeserialize() //Carga el diccionario
    {
        this.Clear();

        if (keys.Count != values.Count)
        {
            Debug.Log("No hay la misma cantidad de valores y llaves");
        }
        for (int i = 0; i < keys.Count; i++)
        {
            this.Add(keys[i], values[i]);
        }
    }

}
