INCLUDE Globals.ink


{intro_amaram == false:
    ->Intro_Amaram

- else:
    Vamos, deja de molestarme y vete de aquí. Habla con Colms y resolved el asesinato de Gabriel. #Speaker: Amaram #Portrait: amaram_anim
}
=== Intro_Amaram ===
En el interior de la oficina, Amaram está sentado en su escritorio escribiendo algo en su ordenador. Alza la mirada hacia ti. #Speaker: Voz Interna #Portrait: voz_anim

Espero que tengas una buena excusa para lo de esta noche Deckard. #Speaker: Amaram #Portrait: amaram_anim

* [“Vaya, ¿Cree que he sido yo?”]
    Serás idiota. Lo digo por haber estado más de 20 minutos solo con el cadáver ¿!¿En qué estabas pensando!?#Speaker: Amaram #Portrait: amaram_anim
    
    Estás en las cámaras, Deckard. Es imposible que hayas sido tú. No vamos a sospechar de ti.#Speaker: Amaram #Portrait: amaram_anim

->Continuacion

* [“Lo siento mucho comisario”]
    Bien. Me alegro de que veas tu error.#Speaker: Amaram #Portrait: amaram_anim
    
->Continuacion

* [(Mierda, tengo que salir de aquí)]
    ¿Qué estás diciendo? ¿Delante suyo? No pienses en esas tonterías y céntrate. #Speaker: Voz Interna #Portrait: voz_anim
    
    ¿Todo bien, Deckard?.#Speaker: Amaram #Portrait: amaram_anim
    
    Bien, ahora escucha un momento.#Speaker: Amaram #Portrait: amaram_anim
    
->Continuacion

=== Continuacion ===
Mira, vamos de culo con todo este tema. Averigua quién ha matado a Delgado y metelo entre rejas. Mientras tanto, llamaré a su familia para comunicarles el fallecimiento. #Speaker: Amaram #Portrait: amaram_anim

* [“Lo haré yo. Quiero ir a su casa de todos modos”]
    ~GiveExp(25)
    ~sara_subtram = true
    
    Buena idea. Puede ser que encuentres algo útil para la investigación. Bien, pues lo dejo en tus manos.  #Speaker: Amaram #Portrait: amaram_anim
    
    Un momento. Antes de ir al piso de Delgado, tienes que recoger a Colms en la escena del crimen.#Speaker: Amaram #Portrait: amaram_anim
    
    ->Continuacion2

* [“Entendido ¿Por donde puedo empezar?”]

    Lo primero que tienes que hacer, es ir a buscar a Colms a la escena del crimen. Los dos llevaréis el homicidio.#Speaker: Amaram #Portrait: amaram_anim
    
    ->Continuacion2
    
=== Continuacion2 ===
~intro_amaram = true
* [“Trabajo mejor solo”]
    Es una orden. Venga sal y déjame trabajar. #Speaker: Amaram #Portrait: amaram_anim

    ->DONE
    
* [“Vale, iré a buscarla”]
    Bien. Lo dejo en vuestras manos. #Speaker: Amaram #Portrait: amaram_anim

    ->DONE
