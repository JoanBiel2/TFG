INCLUDE Globals.ink

{not all_clear():
    Te quedan cosas por investigar, no deberías llamar aún a nadie.
    
- else:
    Antes de que vengan tus compañeros, deberías intentar reconstruir mentalmente la escena del crimen. Gracias a las pruebas que has recolectado, es posible hacerlo. #Speaker: Voz Interna #Portrait: voz_anim
        
        *[(Ha sido una noche muy larga)]
            Es duro. Llevas muchas horas trabajando, y un amigo ha muerto, mereces descansar un poco. #Speaker: Voz Interna #Portrait: voz_anim
            ->DONE

        
        *[*Intentar reconstruir la escena del crimen* INT >=4]
        
            Notas como el mundo se ralentiza a tu alrededor. Sientes que eres capaz de esquivar las gotas de lluvia. Todo cobra una nueva dimensión, un nuevo significado. Aparecen un par de siluetas delante tuyo. #Speaker: Voz Interna #Portrait: voz_anim
            ->DONE
}
