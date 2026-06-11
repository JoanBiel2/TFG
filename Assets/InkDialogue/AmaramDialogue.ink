INCLUDE Globals.ink


{final_amaram == true:
    Vamos, deja de molestarme y vete de aquí. Habla con Colms y resolved el asesinato de Gabriel. #Speaker: Amaram #Portrait: amaram_anim
}

{EnEspera == true:
    ->Continuacion4
}

{revised == true:
    ->AmaramKey
}

{intro_amaram == false:
    ->Intro_Amaram

-else:
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


=== AmaramKey ===
Hey. Acuérdate de la taquilla de Delgado. Pregúntale al comisario si puede abrirla. Podría tener pistas importantes para el caso.#Speaker: Voz Interna #Portrait: voz_anim

¿La taquilla? No es mala idea, Deckard. Toma, la llave maestra. Esta abre todas las taquillas, así que cuidado con abrir la de otros compañeros. #Speaker: Amaram #Portrait: amaram_anim

Amaram abre un cajón de su escritorio, y te da la llave. #Speaker: Voz Interna #Portrait: voz_anim

~GiveExp(25)
~GiveEvidence("Llave maestra","LlaveMaestra","Llave que abre las taquillas de la comisaría La mayoría de las veces que se usa es para abrir las taquillas de los oficiales despitados que se olvidan de la combinación del candado.")
 
{inte >= 3:
    ->Continuacion4
    
-else:
    ->DONE
    
}
    === Continuacion4 ===
    Vaya, ha sido muy fácil, ¿no crees? Hay algo raro en el comisario. Normalmente no estaría dispuesto a algo así. Es probable que el mismo tenga sus propias sospechas sobre el caso. Es arriesgado, pero deberías preguntarle al respecto. #Speaker: Voz Interna #Portrait: voz_anim
    
    * [“¿Qué me estás ocultando, Amaram?”]
        Deckard ¿De que estas hablando? Deja de tocarme los huevos, que tengo trabajo. Ve ha hacer investigar el caso, venga. #Speaker: Amaram #Portrait: amaram_anim
        Lo has cabreado, era esperable. NECESITAS esa información, así que es recomendable que desescales la situación. Contraataca. #Speaker: Amaram #Portrait: amaram_anim
        ->Continuacion5
    
    * [*No preguntarle sobre el asunto*]
        ->EnEsperaKnot
    
    === EnEsperaKnot ===
    ~EnEspera = true
    ->DONE
    
    === Continuacion5 ===
    
    *[“Sé que sabe algo. Necesito esa información para comenzar por algún lado. Por favor comisario”]
    
        Veo que tus habilidades deductivas no han mermado. Muy bien, te haré el resumen rápido, porque apenas tenemos tiempo.#Speaker: Amaram #Portrait: amaram_anim
        
        Sospecho que el asesino es alguno de los oficiales de la comisaría. Tranquilo, no sospecho de ti ni de Colms, por eso os he encargado el caso a vosotros. Si quieres indagar más, necesito el informe que me estaba preparando Delgado sobre un caso muy confidencial que estaba investigando.#Speaker: Amaram #Portrait: amaram_anim
        
        Un movimiento sagaz, ha sido un éxito absoluto. Bien hecho. #Speaker: Voz Interna #Portrait: voz_anim
        ->Final
        
    *[“¡Han asesinado a un inspector de policía! ¡A mi compañero! Voy a mover cielo y tierra para encontrar al hijo de puta que ha hecho esto. Necesito esa información, Amaram”]
    
        ¡¿Y crees que a mi me parece bien que lo hayan matado?! Conozco a Delgado desde hace más de 30 años. Esto me duele más de lo que crees. Mucho. #Speaker: Amaram #Portrait: amaram_anim
        
        Sé que es complicado, pero necesitas dejar de lado tus emociones. Sabes que para el comisario es difícil, pero sabe mantener la actitud sería y la mente fría, pero en el fondo le duele. Compartir ese dolor, os hará más fuertes. #Speaker: Voz Interna #Portrait: voz_anim
        
        te haré el resumen rápido porque apenas tenemos tiempo.#Speaker: Amaram #Portrait: amaram_anim
        
        Sospecho que el asesino es alguno de los oficiales de la comisaría. Tranquilo, no sospecho de ti ni de Colms, por eso os he encargado el caso a vosotros. Si quieres indagar más, necesito el informe que me estaba preparando Delgado sobre un caso muy confidencial que estaba investigando. #Speaker: Amaram #Portrait: amaram_anim
        
        La técnica ha sido nefasta, pero has obtenido lo que necesitabas. Bravo.#Speaker: Voz Interna #Portrait: voz_anim
        ->Final
        
        === Final ===
        Ya he cantado todo lo que sé. Ahora te toca a ti Deckard, encuentra al culpable, confío en ti.#Speaker: Amaram #Portrait: amaram_anim
        ~GiveExp(100)
        ~GiveEvidence("Identidad del asesino","IdentidadAsesino","El principal sospechoso es uno de los oficiales de la comisaría")
        ~final_amaram = true
        
        ->DONE





