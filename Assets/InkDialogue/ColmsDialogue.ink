INCLUDE Globals.ink

{intro == false:
    ->Intro
}
{investig == false:
    ->Investigacion
}
=== Intro ===
Ahí tienes a Camila, con la cabeza enterrada en su cuaderno, como siempre. Algo que siempre te ha sorprendido de ella, es que, pese a su edad, ha conseguido escalar muy rápido en el cuerpo policial. #Speaker: Voz Interna #Portrait: voz_anim

Con poco más de 30 años, ya era una inspectora del departamento de homicidios muy respetada. Y es algo normal, lo puedes ver en su mirada. Aún conserva LA mirada, esa que tenías cuando eras más joven. Es una mirada desafiante, determinada, indomable. Vais a resolver el caso. #Speaker: Voz Interna #Portrait: voz_anim

(Levanta la cabeza hacia Deckard) !Rick¡ ¿Cómo estás, compañero? #Speaker: Colms #Portrait: colms_anim

* “Estoy bien. ¿Qué has descubierto?”

    Bien. Se que vosotros dos erais muy cercanos, me alegro que mantengas la cabeza fría. #Speaker: Colms #Portrait: colms_anim
    
    Aunque te cueste horrores. #Speaker: Voz Interna #Portrait: voz_anim
    ->Continuacion
    
* “No muy bien. Estaré mejor cuando atrapemos al cabrón que mató a Delgado” 

    Calmate. Te entiendo, pero tienes que mantener la cabeza fría. #Speaker: Colms #Portrait: colms_anim
    ->Continuacion

=== Continuacion ===    
La investigación preliminar ya está hecha. No se si has tenido tiempo de investigar por tu cuenta. ¿Quieres que te explique lo que hemos descubierto? #Speaker: Colms #Portrait: colms_anim

* “Adelante”
    A ver… (Baja la mirada hacia su cuaderno). Nombre de la víctima: Gabriel Delgado, 57 años. Ocupación: inspector de policía del departamento de drogas de la ciudad de Lyndel. Causa de la muerte: herida mortal en la zona estomacal, acompañada de múltiples puñaladas en la zona del diafragma. Arma del crimen: cuchillo de 8 pulgadas (sin identificar). #Speaker: Colms #Portrait: colms_anim
        ->Continuacion2
    
*{not all_clear()}“Ya hice mi investigación. No creo que saquemos nada nuevo”
        ->Continuacion3
    
    ===Continuacion2===
    
    * “¿No habéis encontrado el arma?”
        No. Seguramente se la haya llevado. Aparte, ha tenido que mancharse la ropa, y eso sí que ha tenido que desecharlo en algún lado. #Speaker: Colms #Portrait: colms_anim
        
        Buena deducción, pero de nada nos sirve si sigue escondida. #Speaker: Voz Interna #Portrait: voz_anim
        ->Continuacion3


    *\*No interrumpir*
        Esperabas que encontrarán el arma. Esto es un problema. Grave #Speaker: Voz Interna #Portrait: voz_anim
        ->Continuacion3
    

=== Continuacion3 ===
No tenemos ni pruebas sólidas ni testigos. La situación es muy desfavorable, pero no hay que rendirse. Podemos investigar más la escena del crimen, o, si tienes que ir a algún lado, puedo acompañarte. Ellos dos se quedarán vigilando la escena del crimen. #Speaker: Colms #Portrait: colms_anim

~intro = true

->DONE

=== Investigacion ===
~temp foundkey = SearchEvidence("Llave de Delgado")

Has encontrado algo útil?

*{foundkey} Esta llave


->DONE

