INCLUDE Globals.ink

{not all_clear():
    Te quedan cosas por investigar, no deberías llamar aún a nadie. #Speaker: Voz Interna #Portrait: voz_anim
    
- else:
    Antes de que vengan tus compañeros, deberías intentar reconstruir mentalmente la escena del crimen. Gracias a las pruebas que has recolectado, es posible hacerlo. #Speaker: Voz Interna #Portrait: voz_anim
        
        *[(Ha sido una noche muy larga)]
            Es duro. Llevas muchas horas trabajando, y un amigo ha muerto, mereces descansar un poco. #Speaker: Voz Interna #Portrait: voz_anim
            ->DONE

        
        *[*Intentar reconstruir la escena del crimen*]
        {inte > 3:
            ~GiveExp(25)
            ~ChangeDetectiveVisionOn()
            Notas como el mundo se ralentiza a tu alrededor. Sientes que eres capaz de esquivar las gotas de lluvia. Todo cobra una nueva dimensión, un nuevo significado. Aparecen un par de siluetas delante tuyo. #Speaker: Voz Interna #Portrait: voz_anim
            
            Dos siluetas aparecen. Están marcadas por un color azul celeste muy fuerte. Una de ellas está apoyada en la pared, fumando un cigarro, mientras la otra se está acercando al fumador.#Speaker: Narrador #Portrait: narrador_anim
            
            Gabriel estaba fumando, apoyado en la pared. El asesino camina con la cabeza gacha hacia su víctima. Gabriel gira la cabeza, y es entonces cuando el culpable le asesta la primera puñalada. Gabriel deja caer el cigarro, y el asesino le asesta tres puñaladas más. El cuchillo es de unas 8 pulgadas. Gabriel cae muerto al suelo, apenas ha podido defenderse. Luego el asesino abre la puerta del coche usando una llave, y lo mete en el asiento de atrás.#Speaker: Voz Interna #Portrait: voz_anim
            
            La reconstrucción de la escena acaba. Las siluetas desaparecen, y el tiempo vuelve a la normalidad. #Speaker: Narrador #Portrait: narrador_anim
            
            Tienes varias incógnitas. Lo primero, ¿Cómo ha conseguido abrir la puerta de tu coche? Ha tenido que usar la que llevas en la gabardina. Lo segundo; la ropa del asesino ha tenido que mancharse por la sangre de Gabriel ¿Dónde la ha podido dejar? Sería muy positivo para la investigación que encontrarás las respuestas, pero parece que empiezas a escuchar las sirenas. #Speaker: Voz Interna #Portrait: voz_anim

            ~ChangeDetectiveVisionOff()
            
            - else:
                Te cuesta concentrarte. Lo mejor sería hablar con los demás y sacar conclusiones entre todos. #Speaker: Voz Interna #Portrait: voz_anim
        }
        ->DONE
}
