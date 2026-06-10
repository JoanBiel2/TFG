INCLUDE Globals.ink

{pistol_obt == false:
    ->Locker
    
-else:
    No hay nada más que te puedas llevar de interés. #Speaker: Voz Interna #Portrait: voz_anim
}

=== Locker ===
Tu taquilla. Aquí normalmente guardas cosas importantes para tu trabajo. Hace tiempo que no la abres, ¿Crees que aun te acordarás de la combinación? #Speaker: Voz Interna #Portrait: voz_anim

Te acercas a la taquilla y empiezas a mover el dial. Al hacer algunos movimientos, se escucha un “click”.#Speaker: Voz Interna #Portrait: voz_anim

Bingo. Veamos lo que tenemos por aquí… Puedes ver tu arma reglamentaría junto a un par de cartuchos, parcialmente llenos de polvo. También puedes apreciar algunos papeles acumulados en el fondo, y unas fotos enganchadas en el interior de la puerta de la taquilla. Estas muestran a una pareja de recién casados, y a un joven oficial a punto de empezar su primera patrulla. Como pasa el tiempo… #Speaker: Voz Interna #Portrait: voz_anim

Sacas la pistola, la limpias un poco, y la guardas en tu cartuchera.#Speaker: Voz Interna #Portrait: voz_anim

~GiveExp(50)
~GiveEvidence("Pistola", "Pistola", "Tu pistola de servicio. No lo parece por lo compacta que es pero este bicho de casi 1 kg te pesa en la mano. Viene con dos cargadores completos.")

~pistol_obt = true

->DONE