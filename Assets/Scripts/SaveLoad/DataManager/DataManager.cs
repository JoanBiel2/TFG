using UnityEngine;
using System.Linq;
using Ink.Parsed;
using System.Collections.Generic;

public class DataManager : MonoBehaviour
{
    [SerializeField] private string filename;
    private FileDataHandler datahandler;
    
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
        this.datahandler = new FileDataHandler(Application.persistentDataPath, filename);
        this.datapersistancelist = FindDataPersostance();
        LoadGame();
    }

    public void NewGame()
    {
        this.gamedata = new GameData();
    }
    public void LoadGame()
    {
        this.gamedata = datahandler.Load();
        
        if(this.gamedata == null) //No hay partida guardada
        {
            Debug.Log("No hay partida guardada");
            NewGame();
        }
        foreach(DataPersistance dataper in datapersistancelist)
        {
            dataper.LoadData(gamedata);
        }
    }
    public void SaveGame()
    {
        foreach(DataPersistance dataper in datapersistancelist)
        {
            dataper.SaveData(ref gamedata);
        }
        datahandler.Save(gamedata);
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
