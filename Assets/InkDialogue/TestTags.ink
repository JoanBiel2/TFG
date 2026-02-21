INCLUDE Globals.ink

EXTERNAL GiveExp(exp)
EXTERNAL SearchEvidence(name)
EXTERNAL GiveEvidence(name,sprite,desc)


->Delgado_Body

=== Delgado_Body ===
~temp foundbola = SearchEvidence("Bola")
~temp foundkey = SearchEvidence("Llave de Delgado")

Gabriel Delgado, 57 años, más de 30 años de experiencia en el cuerpo. Todos los policías desean poder jubilarse y morir en una cama, rodeados de su familia, pero los mejores policías son los que mueren en las calles, protegiendo a su ciudad y a sus habitantes. Hizo unos juramentos, y los cumplió hasta el amargo final. No dejes que eso te afecte. Encuentra al culpable. #Speaker: Narrador #Portrait: narrador_anim

    *[Examinar cabeza]
        {not exp_cabeza:
            ~GiveExp(25)
            ~exp_cabeza = true
        }
        Tiene algunos salpicones de sangre en la cabeza, pero no ves ninguna herida. Los ojos están perdiendo su transparencia y apenas brillan con la luz de la linterna. Debe de llevar mínimo unas 6 horas muerto.#Speaker: Voz Interna #Portrait: voz_anim
        -> Delgado_Body
    
    *[Examinar torso]
        {not exp_torso:
            ~GiveExp(25)
            ~exp_torso = true
        }
        Aquí están. Varias heridas en la zona abdominal del cuerpo. Hay cuatro en total, una cerca del estómago, y las otras tres cerca del diafragma. El asesino no se ha ensañado con él, pero se aseguró de matarlo.#Speaker: Voz Interna #Portrait: voz_anim
        -> Delgado_Body
    
    *[Examinar manos]
        {not exp_cabeza:
            ~GiveExp(25)
            ~exp_manos = true
        }
        Al alcanzar sus manos, notas que están pálidas y empiezan a estar rígidas. Por lo demás, no parece que tenga rasguños ni marcas en las manos. No opuso resistencia.#Speaker: Voz Interna #Portrait: voz_anim
        -> Delgado_Body
    
    *[Examinar piernas]
        {not exp_cabeza:
            ~GiveExp(25)
            ~exp_piernas = true
        }
        Apenas puedes ver nada. Están completamente ensangrentadas, y bastante rígidas también. #Speaker: Voz Interna #Portrait: voz_anim
        -> Delgado_Body
            
    *{foundbola}[Examinar el suelo]
        Encuentras algo en el suelo cerca del cuerpo. Una bola que parece haber rodado hasta aquí. #Speaker: Voz Interna #Portrait: voz_anim
        -> Delgado_Body
    
    *{not foundkey} [Levantar el cuerpo]
        Podría haber algo debajo de Gabriel, pero ten cuidado, un cuerpo pesa mucho más de lo que parece. #Speaker: Voz Interna #Portrait: voz_anim
        -> Levantar_cuerpo

    *{foundkey} [Alejarse]
        Te alejas de la escena.#Speaker: Voz Interna #Portrait: voz_anim
        -> DONE

=== Levantar_cuerpo ===
Intentas levantar el cuerpo...
{strg > 2:
    ~GiveExp(25)
    ~GiveEvidence("Llave de Delgado","Llave","Llave que tenía Delgado en el bolsillo. No sabes qué abre.")
    Lo levantas con esfuerzo. Debajo del cuerpo encuentras una pequeña llave. #Speaker: Narrador #Portrait: narrador_anim
- else:
    No puedes levantar el cuerpo, ya que solo tienes {strg} de fuerza. Necesitas más fuerza física para moverlo. #Speaker: Narrador #Portrait: narrador_anim
}
->DONE

