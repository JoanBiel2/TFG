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
        public int exp; //La cantidad de experiencia que tiene el jugador
        public int cap; //La cantidad de experiencia que se necesita para subir de nivel
    }

    private Stats stats;
    private Level level;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stats.inte = 0;
        stats.str = 0;
        stats.refl = 0;

        level.lvl = 1;
        level.exp = 0;
        level.cap = 100;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
