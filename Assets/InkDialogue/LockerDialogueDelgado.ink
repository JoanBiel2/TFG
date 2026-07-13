INCLUDE Globals.ink

{lockerdone == true:
    ->AllDone
}
{keygiven == true:
    ->OpenLocker
}

{revisedkey == false:
    ->LockerDelgado
}

{revisedkey == true:
    Ya has probado la llave y no abre. Ya encontrarás su uso. #Speaker: Voz Interna #Portrait: voz_anim
}

=== LockerDelgado ===
~temp foundkey = SearchEvidence("Llave de Delgado")

Es la taquilla de Delgado. Crees que dentro puede haber algo importante, pero no sabes la combinación y está cerrada con llave. Quizás el comisario tiene la llave maestra. #Speaker: Voz Interna #Portrait: voz_anim
~revised = true

{foundkey == true:
    ->TryKey
}

->DONE

=== TryKey ===
Es cierto, usa la llave. No perdemos nada por intentarlo. #Speaker: Voz Interna #Portrait: voz_anim

Sacas la llave del bolsillo e intentas abrir la taquilla. Esta no cede. #Speaker: Voz Interna #Portrait: voz_anim
    
Vaya, menudo chasco. Encontrarás su uso, eventualmente. #Speaker: Voz Interna #Portrait: voz_anim

~revisedkey = true

->DONE

=== OpenLocker ===
Deckard saca la llave de maestra, y abre la taquilla. #Speaker: Narrador #Portrait: narrador_anim

¿Que tenemos por aquí? A primera vista ves papeles, muchos papeles. Delgado era alguien con muchas virtudes, pero el orden no era una de ellas, muy parecido a ti. Descartando la montaña de papeles, ves… fotos, muchas de ellas son de su familia, otras de sus compañeros. Mira, en esta sale… ¿Por qué lloras? #Speaker: Voz Interna #Portrait: voz_anim

Deckard se echa hacia atrás, secándose los ojos. #Speaker: Narrador #Portrait: narrador_anim

No es el momento de venirse abajo, de momento. Podrías encontrar algo crucial para la investigación. Hay que apechugar y darlo todo. Tú puedes. #Speaker: Voz Interna #Portrait: voz_anim

Deckard mira a la taquilla, y unos momentos después, se pone a buscar dentro. #Speaker: Narrador #Portrait: narrador_anim

Al fondo, ves un archivo que te llama la atención. Lo coges, y te fijas en la fecha de creación. Tiene solo un par de meses. Lees el contenido del archivo. Al parecer estaba trabajando en una operación llamada Operación Talpe. #Speaker: Voz Interna #Portrait: voz_anim

¿Talpe, buscaban a un topo? #Speaker: Voz Interna #Portrait: voz_anim

Sigues leyendo el contenido del archivo. Aparentemente, hace unos meses desaparecieron algunos paquetes de droga incautados, en esta misma comisaría. La organización que traficaba con estas era conocida como “El Grupo”. Un nombre bastante simple, pero según el informe, es una de las redes de tráfico de drogas más importante del mundo. #Speaker: Voz Interna #Portrait: voz_anim

El nombre de la organización te suena, es possible que participaras en alguna redada a algún narco piso de esta organización.#Speaker: Voz Interna #Portrait: voz_anim

Es curioso, absolutamente nadie sabía nada de esta operación. En la lista de participantes, solo consta el nombre de tres personas: Víctor Amaram (comisario), Oliver Sykes (jefe del departamento de drogas), y Gabriel Delgado (inspector del departamento de drogas). #Speaker: Voz Interna #Portrait: voz_anim

Gabriel era el principal investigador de la operación. Lo que creían, era que uno de los integrantes del Grupo estaba infiltrado en la comisaría. y que, desde dentro, informaba de todos nuestros movimientos a su organización.#Speaker: Voz Interna #Portrait: voz_anim

Al final del archivo, ves como Delgado reportaba su éxito a la hora de infiltrarse en la organización, y también ha sacado el nombre real del infiltrado, un tal Reddi. Muy atrevido, podrían haberlo reconocido por la información que les proporcionaba su espía en la policía, de hecho, es lo más probable. #Speaker: Voz Interna #Portrait: voz_anim

Esto confirma dos cosas. La primera es que el asesino es, muy probablemente, el infiltrado de esta organización. La segunda es consecuencia directa de la primera. Si el asesino es ese topo, el motivo queda más que claro. Esa operación, es un peligro para El Grupo, y han querido silenciar al principal investigador. Hay que darse prisa y encontrar al asesino. #Speaker: Voz Interna #Portrait: voz_anim

~GiveEvidence("Investigación", "InvestigaciónDelgado", "Gracias a la investigación de Delgado, se destapó a un infiltrado dentro de la comisaría; su apellido real es Reddi.")

~GiveExp(50)

{not SearchEvidence("Identidad del asesino"):
    ~GiveEvidence("Identidad del asesino","IdentidadAsesino","El principal sospechoso es uno de los oficiales de la comisaría")
}

~lockerdone = true
->DONE

=== AllDone ===
Ya no queda nada más que ver aquí. Busquemos en otro lado. #Speaker: Voz Interna #Portrait: voz_anim
->DONE



