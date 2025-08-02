using UnityEngine;

public interface DataPersistance
{
    void LoadData(GameData data);
    void SaveData(ref GameData data);
}
