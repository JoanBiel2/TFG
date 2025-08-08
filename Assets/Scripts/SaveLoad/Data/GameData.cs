using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;


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

    [System.Serializable]
    public class ItemData
    {
        public string name;
        public string spriteName;
        public string description;
    }

    public ItemData[] inventory;

    public SerializableDictionary<string, bool> evidencedic; //Pistas que el jugador ha recogido, y se tienen que eliminar del mundo


    public GameData()
    {
        this.str = 1;
        this.inte = 1;
        this.refl = 1;
        this.points = 0;
        this.lvl = 1;
        this.exp = 0;

        this.playerpos = new Vector3(0, 1f, 0); //Poner posición inicial

        evidencedic = new SerializableDictionary<string, bool>();
    }
}
