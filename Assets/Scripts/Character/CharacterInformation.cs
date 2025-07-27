using TMPro;
using UnityEngine;

public class CharacterInformation : MonoBehaviour
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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stats.inte = 1;
        stats.str = 1;
        stats.refl = 1;

        level.lvl = 1;
        level.points = 0;
        level.exp = 0;
        level.cap = 100;

        strtext.text = "Strength: " + stats.str;
        inttext.text = "Intelligence: " + stats.inte;
        refltext.text = "Reflexes: " + stats.refl;
        leveltext.text = "Level: " + level.lvl;
        points.text = "Avaiable Points: " + level.points;
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
        }
    }
    public void AddExpItem(int expitem)
    {
        level.exp += expitem;
    }
}
