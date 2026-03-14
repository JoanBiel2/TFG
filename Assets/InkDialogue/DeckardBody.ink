INCLUDE Globals.ink

EXTERNAL GiveExp(exp)
EXTERNAL SearchEvidence(name)
EXTERNAL GiveEvidence(name,sprite,desc)


->Delgado_Body

=== Delgado_Body ===

Gabriel Delgado, 57 años, más de 30 años de experiencia en el cuerpo. Todos los policías desean poder jubilarse y morir en una cama, rodeados de su familia, pero los mejores policías son los que mueren en las calles, protegiendo a su ciudad y a sus habitantes. #Speaker: Narrador #Portrait: voz_anim

Hizo unos juramentos, y los cumplió hasta el amargo final. No dejes que eso te afecte. Encuentra al culpable. #Speaker: Narrador #Portrait: voz_anim
-> Options

=== Options ===
~temp foundkey = SearchEvidence("Llave de Delgado")

    *[Examinar cabeza]
        Tiene algunos salpicones de sangre en la cabeza, pero no ves ninguna herida. Los ojos están perdiendo su transparencia y apenas brillan con la luz de la linterna. Debe de llevar mínimo unas 6 horas muerto.#Speaker: Voz Interna #Portrait: voz_anim
        -> Options
    
    *[Examinar torso]
        Aquí están. Varias heridas en la zona abdominal del cuerpo. Hay cuatro en total, una cerca del estómago, y las otras tres cerca del diafragma. El asesino no se ha ensañado con él, pero se aseguró de matarlo.#Speaker: Voz Interna #Portrait: voz_anim
        -> Options
    
    *[Examinar manos]
        Al alcanzar sus manos, notas que están pálidas y empiezan a estar rígidas. Por lo demás, no parece que tenga rasguños ni marcas en las manos. No opuso resistencia.#Speaker: Voz Interna #Portrait: voz_anim
        -> Options
    
    *[Examinar piernas]
        Apenas puedes ver nada. Están completamente ensangrentadas, y bastante rígidas también. #Speaker: Voz Interna #Portrait: voz_anim
        -> Options
    
    *{not foundkey} [Levantar el cuerpo]
        Podría haber algo debajo de Gabriel, pero ten cuidado, un cuerpo pesa mucho más de lo que parece. #Speaker: Voz Interna #Portrait: voz_anim
        -> Levantar_cuerpo

    *{foundkey} [Alejarse]
        Te alejas de la escena.#Speaker: Voz Interna #Portrait: voz_anim
        -> DONE

=== Levantar_cuerpo ===
Deckard pone una mano en la zona de los cuádriceps del cadáver, y otra en la espalda, y levanta con todas sus fuerzas.
{strg > 2:
    ~GiveExp(25)
    ~GiveEvidence("Llave de Delgado","Llave","Llave que tenía Delgado en el bolsillo. No sabes qué abre.")
    Consigue desplazar el cuerpo al asiento del medio, y deja visible el sitio donde estaba antes el cuerpo. 
    
    
    Veo que el gimnasio da sus frutos. Lo primero que atrae tu mirada es el asiento en si, está completamente ensangrentado. #Speaker: Narrador #Portrait: voz_anim
    
    Aparte de eso no parece que haya nada más… #Speaker: Narrador #Portrait: voz_anim
    
    Un momento, ¿Una llave? Es bastante pequeña, y no sabes lo que abre, pero creo que te puede venir bien conservarla. #Speaker: Narrador #Portrait: voz_anim
- else:
    No te sientas mal. Los cuerpos pesan mucho, y la postura no es la mejor. Igualmente, es poco probable que haya algo escondido debajo del cadáver.
 #Speaker: Narrador #Portrait: voz_anim
}
->DONE

