INCLUDE Globals.ink
Un banco… Tienes unas ganas terribles de descansar. Ha sido una noche larga, las piernas te están matando… ¿Quieres sentarte?

    *[Si, por favor]
        ~SittingDown()
        Deckard se sienta, y echa la cabeza hacia atrás.
        
        ->Banco2
    *[No, tengo que continuar]
        No viene mal parar de vez en cuando para reflexionar. Vuelve cuando quieras mirarte en el espejo.

    
    === Banco2 ===
    ¿Y bien? ¿En qué estás pensando? Tiene gracia que yo diga eso, pero enserio, ¿Que te pasa?
    
    *[(Estoy perdiendo la cabeza, no se que hacer)]
    
    ¿Pensabas que esto te iba a liberar? Eres como un animal enjaulado, estabas atrapado en un trabajo aburrido, sentado todo el día, llenando informes de casos que tu no resolvías.
    
    Necesitas salir ahí fuera, ser el protagonista, resolver crímenes. Pero ya es tarde. Has envejecido. Cada vez encuentras más pelo en la almohada cuando te despiertas. Cada vez te cuesta mas seguirle el paso a tu hijo. Cada vez te cuesta más pensar con claridad. Teniendo eso en mente, ¿Porque te sientes así?
    
    ->Banco3
    
    *[(Nada, estoy perdiendo el tiempo) *Levantarse*]
    No estás bien. Tienes que enfrentarte a ti mismo de vez en cuando. Vuelve cuando estés listo
    
    === Banco3 ===
    ¿Qué es lo que quieres conseguir?
    
    *[(Odio mi trabajo, odio perder a un amigo de esta manera)]
        Es una situación desalentadora. Muchos de vosotros vivís y morís al servicio de personas a las que no le importáis. Es triste veas por donde lo veas, pero hiciste unos juramentos.
    
        Romperlos solo te haría más daño, y me perderías. Estarías más vacío que nunca, y jamás podrás hablar conmigo. Sabes tan bien como yo que existo gracias a este trabajo. Siempre te he impulsado a hacer lo correcto, y lo seguiré haciendo.
        
        ->DecisionStat
    
    *[(Quiero matarlo. Quiero matar a ese asesino)]
        Gabriel era tu compañero, un buen amigo, un padre responsable, un marido ejemplar. Todas esas ideas han calado dentro tuyo, y siempre has hecho todo lo posible por seguir su ejemplo. Gabriel ha muerto, lo han matado.
        
        Nunca más podrás salir de copas con él, nunca más podrá abrazar a su hijo, ni darle un beso a su mujer. Pero no tienes que estar triste, alégrate de haberlo conocido.
        
        Todas esas ideas y pensamientos que él te transmitió seguirán contigo, y siempre que te mantengas fiel a sus principios, Gabriel nunca morirá, te lo aseguro. Ahora, ¿que necesitas?

        ->DecisionStat
    
    === DecisionStat ===
        AAA
    
    === Levantarse ===
    AAA
