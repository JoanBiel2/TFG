using System;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using Unity.VisualScripting;
using UnityEngine;

public class FileDataHandler
{
    private string datapath = "";
    private string dataname = "";

    public FileDataHandler(string datapath, string dataname)
    {
        this.datapath = datapath;
        this.dataname = dataname;
    }

    public GameData Load()
    {
        string path = Path.Combine(datapath, dataname);
        GameData loadeddata = null;
        if (File.Exists(path))
        {
            try
            {
                string data = "";
                using (FileStream stream = new FileStream(path, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        data = reader.ReadToEnd();
                    }
                }
                loadeddata = JsonUtility.FromJson<GameData>(data);
            }
            catch (Exception e)
            {

                Debug.LogError("Error al intentar cargar los datos" + path + "\n" + e);
            }
        }
        return loadeddata;
    }

    public void Save(GameData data)
    {
        string path = Path.Combine(datapath,dataname);
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(path));
            string datastored = JsonUtility.ToJson(data, true);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(datastored);
                }
            }
        }
        catch(Exception e)
        {
            Debug.LogError("Error al guardar los datos" + path + "\n" + e);
        }
    }
}