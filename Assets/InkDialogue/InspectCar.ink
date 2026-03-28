INCLUDE Globals.ink

{not exam_coche:
Tu coche… o la escena del crimen. Has visto que Gabriel estaba ensangrentado de pies a cabeza. Es probable que el arma del crimen esté escondida por aquí, si el culpable no se la ha llevado. Mira debajo de tu coche. #Speaker: Narrador #Portrait: narrador_anim

~FadeToBlack()

Nada. Después de revisar toda la fila de coches, no has encontrado nada. Es probable que el culpable se la haya llevado. Eso complica las cosas, pero no hay que tirar la toalla. Sigue buscando. #Speaker: Narrador #Portrait: narrador_anim

- else:
    No hay nada mas por aqui. Busca en otro lado #Speaker: Narrador #Portrait: narrador_anim
}

~exam_coche = true
