using UnityEngine;


[System.Serializable]
public class GameData
{
    public int str;
    public int inte;
    public int refl;
    public int exp;
    public int lvl;
    public int points;

    public Vector3 playerpos;

    public ItemSlot[] inventory;

    public GameData()
    {
        this.str = 1;
        this.inte = 1;
        this.refl = 1;
        this.points = 0;
        this.lvl = 1;
        this.exp = 0;

        this.playerpos = Vector3.zero;

        this.inventory = new ItemSlot[10];

    }
}
