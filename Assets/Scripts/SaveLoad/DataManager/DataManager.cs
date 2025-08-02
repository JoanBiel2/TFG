using UnityEngine;
using System.Linq;
using Ink.Parsed;
using System.Collections.Generic;

public class DataManager : MonoBehaviour
{
    private GameData gamedata;
    private List<DataPersistance> datapersistancelist;
    public static DataManager instance {get; private set;}


    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Solo deberia haber una instancia");
        }
        instance = this;
    }
    private void Start()
    {
        this.datapersistancelist = FindDataPersostance();
        LoadGame();
    }

    public void NewGame()
    {
        this.gamedata = new GameData();
    }
    public void LoadGame()
    {
        if(this.gamedata == null) //No hay partida guardada
        {
            Debug.Log("No hay partida guardada");
            NewGame();
        }
        foreach(DataPersistance dataper in datapersistancelist)
        {
            dataper.LoadData(gamedata);
        }
        Debug.Log("Load Str = " + gamedata.str);
        Debug.Log("Load Inte = " + gamedata.inte);
        Debug.Log("Load Refl = " + gamedata.refl);
    }
    public void SaveGame()
    {
        foreach(DataPersistance dataper in datapersistancelist)
        {
            dataper.SaveData(ref gamedata);
        }
        Debug.Log("Save Str = " + gamedata.str);
        Debug.Log("Save Inte = " + gamedata.inte);
        Debug.Log("Save Refl = " + gamedata.refl);
    }
    private void OnApplicationQuit()
    {
        SaveGame();
    }
    private List<DataPersistance> FindDataPersostance()
    {
        IEnumerable<DataPersistance> datapersistancelist =
         FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None)
             .OfType<DataPersistance>();

        return new List<DataPersistance>(datapersistancelist);
    }
}
