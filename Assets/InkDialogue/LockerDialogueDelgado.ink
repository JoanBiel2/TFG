INCLUDE Globals.ink

{revised == false:
    ->LockerDelgado

- else:
    Ya has probado la llave y no abre. Ya encontrarás su uso. #Speaker: Voz Interna #Portrait: voz_anim
}


=== LockerDelgado ===
~temp foundkey = SearchEvidence("Llave de Delgado")

Es la taquilla de Delgado. Crees que dentro puede haber algo importante, pero está cerrada con llave. #Speaker: Voz Interna #Portrait: voz_anim

{foundkey == true:
    ->TryKey
}    

->DONE

=== TryKey ===
Es cierto, usa la llave. No perdemos nada por intentarlo. #Speaker: Voz Interna #Portrait: voz_anim

Sacas la llave del bolsillo e intentas abrir la taquilla. Esta no cede. #Speaker: Voz Interna #Portrait: voz_anim
    
Vaya, menudo chasco. Encontrarás su uso, eventualmente. #Speaker: Voz Interna #Portrait: voz_anim

~revised = true

->DONE