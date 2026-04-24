INCLUDE Globals.ink

{sat == false:
    ->Banco

- else:
    ->Sat
}

=== Banco ===
Un banco… Tienes unas ganas terribles de descansar. Ha sido una noche larga, las piernas te están matando… ¿Quieres sentarte? #Speaker: Voz Interna #Portrait: voz_anim

    *[Si, por favor]
        ~SittingDown()
        Deckard se sienta, y echa la cabeza hacia atrás. #Speaker: Narrador #Portrait: narrador_anim
        
        ->Banco2
    *[No, tengo que continuar]
        No viene mal parar de vez en cuando para reflexionar. Vuelve cuando quieras mirarte en el espejo. #Speaker: Voz Interna #Portrait: voz_anim
        
        ->Salir
    
    === Banco2 ===
    ¿Y bien? ¿En qué estás pensando? Tiene gracia que yo diga eso, pero enserio, ¿Que te pasa? #Speaker: Voz Interna #Portrait: voz_anim
    
    *[(Estoy perdiendo la cabeza, no se que hacer)]
    
    ¿Pensabas que esto te iba a liberar? Eres como un animal enjaulado, estabas atrapado en un trabajo aburrido, sentado todo el día, llenando informes de casos que tu no resolvías. #Speaker: Voz Interna #Portrait: voz_anim
    
    Necesitas salir ahí fuera, ser el protagonista, resolver crímenes. Pero ya es tarde. Has envejecido. Cada vez encuentras más pelo en la almohada cuando te despiertas. Cada vez te cuesta mas seguirle el paso a tu hijo. Cada vez te cuesta más pensar con claridad. Teniendo eso en mente, ¿Porque te sientes así? #Speaker: Voz Interna #Portrait: voz_anim
    
    ->Banco3
    
    *[(Nada, estoy perdiendo el tiempo) *Levantarse*]
    No estás bien. Tienes que enfrentarte a ti mismo de vez en cuando. Vuelve cuando estés listo. #Speaker: Voz Interna #Portrait: voz_anim
    
        ->Levantarse1
    
    === Banco3 ===
    ¿Qué es lo que quieres conseguir? #Speaker: Voz Interna #Portrait: voz_anim
    
    *[(Odio mi trabajo, odio perder a un amigo de esta manera)]
        Es una situación desalentadora. Muchos de vosotros vivís y morís al servicio de personas a las que no le importáis. Es triste veas por donde lo veas, pero hiciste unos juramentos. #Speaker: Voz Interna #Portrait: voz_anim
    
        Romperlos solo te haría más daño, y me perderías. Estarías más vacío que nunca, y jamás podrás hablar conmigo. Sabes tan bien como yo que existo gracias a este trabajo. Siempre te he impulsado a hacer lo correcto, y lo seguiré haciendo. #Speaker: Voz Interna #Portrait: voz_anim
        
        ->DecisionStat
    
    *[(Quiero matarlo. Quiero matar a ese asesino)]
        Gabriel era tu compañero, un buen amigo, un padre responsable, un marido ejemplar. Todas esas ideas han calado dentro tuyo, y siempre has hecho todo lo posible por seguir su ejemplo. Gabriel ha muerto, lo han matado. #Speaker: Voz Interna #Portrait: voz_anim
        
        Nunca más podrás salir de copas con él, nunca más podrá abrazar a su hijo, ni darle un beso a su mujer. Pero no tienes que estar triste, alégrate de haberlo conocido. #Speaker: Voz Interna #Portrait: voz_anim
        
        Todas esas ideas y pensamientos que él te transmitió seguirán contigo, y siempre que te mantengas fiel a sus principios, Gabriel nunca morirá, te lo aseguro. Ahora, ¿que necesitas? #Speaker: Voz Interna #Portrait: voz_anim

        ->DecisionStat
    
    === DecisionStat ===
        *[(Tengo que ser fuerte. Necesito aguantar todo lo que me echen)]
            Fuerza. Siempre has sido alguien fuerte, tanto física como mentalmente. Esa fuerza te llevará a donde desees. #Speaker: Voz Interna #Portrait: voz_anim
            
            ~LevelUP(str_string)
            ->Levantarse2
        *[(Ser más inteligente. Necesito ser capaz de entender todo lo relacionado con el caso)]
            Inteligencia. Siempre has sido alguien curioso, te devanas los sesos con cualquier tontería. Esa inteligencia te conducirá a la verdad. #Speaker: Voz Interna #Portrait: voz_anim
            
            ~LevelUP(inte_string)
            ->Levantarse2
        *[(Velocidad. Tengo que encontrar rápido al asesino, y no dejar que se escape)]
            Velocidad, el sueño de todo aventurero. Esa sensación que tenías cuando eras joven, la que te obliga moverte, actuar, a ser cinético. Gracias a esa velocidad, superarás todos los obstáculos. #Speaker: Voz Interna #Portrait: voz_anim
            
            ~LevelUP(refl_string)
            ->Levantarse2
    
    
    === Salir ===
        ->DONE
    
    === Levantarse1 ===
        ~StandUp()
        ->DONE
        
    === Levantarse2 ===
    Ya has hecho las paces contigo mismo. No puedes curarte, pero puedes arreglarte con los restos que has encontrado. Ahora, sal y haz tu trabajo. Es lo que Gabriel hubiese querido. #Speaker: Voz Interna #Portrait: voz_anim
        ~StandUp()
        ->DONE
    
    === Sat ===
    Ya has perdido demasiado tiempo. Sal ahí y encuentra al asesino #Speaker: Voz Interna #Portrait: voz_anim
    ->DONE
