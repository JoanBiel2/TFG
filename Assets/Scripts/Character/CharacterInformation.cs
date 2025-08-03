using TMPro;
using UnityEngine;
using static CharacterInformation;

public class CharacterInformation : MonoBehaviour, DataPersistance
{
    public struct Stats //El jugador puede tomar diferentes decisiones dependiendo de las estadisticas que tenga 
    {
        public int str; //Fuerza
        public int inte; //Inteligencia
        public int refl; //Reflejos
    }

    public struct Level //Cada nivel, el jugador puede subir una de las estadisticas 
    {
        public int lvl; //Cuanto mas alto sea el nivel, mas complicado será subir
        public int points; //Estos puntos se dan al subir de nivel, y sirven para subir las stats
        public int exp; //La cantidad de experiencia que tiene el jugador
        public int cap; //La cantidad de experiencia que se necesita para subir de nivel
    }

    private Stats stats;
    private Level level;

    [SerializeField] private TextMeshProUGUI strtext;
    [SerializeField] private TextMeshProUGUI inttext;
    [SerializeField] private TextMeshProUGUI refltext;
    [SerializeField] private TextMeshProUGUI leveltext;
    [SerializeField] private TextMeshProUGUI points;

    private Dialogue dialogue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        dialogue = GameObject.Find("DialogueManager").GetComponent<Dialogue>();

        level.lvl = 1;
        level.points = 0;
        level.exp = 0;
        level.cap = 100;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (level.exp >= level.cap)
        {
            level.points++;
            points.text = "Avaiable Points: " + level.points;
            level.exp = level.exp-level.cap;
        }
    }

    public void WriteStats()
    {
        strtext.text = "Strength: " + stats.str;
        inttext.text = "Intelligence: " + stats.inte;
        refltext.text = "Reflexes: " + stats.refl;
        leveltext.text = "Level: " + level.lvl;
        points.text = "Avaiable Points: " + level.points;
    }

    public void LoadData(GameData data)
    {
        this.stats.str = data.str;
        this.stats.inte = data.inte;
        this.stats.refl = data.refl;
        this.level.exp = data.exp;
        this.level.lvl = data.lvl;
        this.level.points = data.points;

        WriteStats();
    }

    public void SaveData(ref GameData data)
    {
        data.str = this.stats.str;
        data.inte = this.stats.inte;
        data.refl = this.stats.refl;
        data.exp = this.level.exp;
        data.lvl = this.level.lvl;
        data.points = this.level.points;
    }

    public int GetStr()
    {
        return stats.str;
    }
    public int GetInte()
    {
        return stats.inte;
    }
    public int GetRefl()
    {
        return stats.refl;
    }

    public void LevelUp(string stat)
    {
        if (level.points > 0)
        {
            switch (stat)
            {
                case "str":
                    stats.str++;
                    strtext.text = "Strength: " + stats.str;
                    break;

                case "inte":
                    stats.inte++;
                    inttext.text = "Intelligence: " + stats.inte;
                    break;

                case "refl":
                    stats.refl++;
                    refltext.text = "Reflexes: " + stats.refl;
                    break;
            }
            level.lvl++;
            leveltext.text = "Level: " + level.lvl;
            level.points--;
            points.text = "Avaiable Points: " + level.points;
            dialogue.UpdateStats();
        }
    }
    public void AddExpItem(int expitem)
    {
        level.exp += expitem;
    }
}
