using Ink.Parsed;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DataManager : MonoBehaviour
{
    [SerializeField] private string filename;
    private FileDataHandler datahandler;
    
    private GameData gamedata;
    private List<DataPersistance> datapersistancelist;
    public static DataManager instance {get; private set;}



    private bool shouldLoadGame = true;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            transform.SetParent(null);
            DontDestroyOnLoad(gameObject);

            datahandler = new FileDataHandler(Application.persistentDataPath, filename);

            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void NewGame()
    {
        gamedata = new GameData();
        shouldLoadGame = false;
    }

    public void ContinueGame()
    {
        shouldLoadGame = true;
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
            Debug.Log("Datos cargados en " + dataper.ToString());
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

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        datapersistancelist = FindDataPersostance();

        if (shouldLoadGame)
        {
            LoadGame();
        }
        else
        {
            foreach (DataPersistance dataper in datapersistancelist)
            {
                dataper.LoadData(gamedata);
            }
        }
    }


}
