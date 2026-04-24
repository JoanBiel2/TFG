EXTERNAL GiveExp(exp)
EXTERNAL LevelUP(stat)
EXTERNAL SearchEvidence(name)
EXTERNAL GiveEvidence(name,sprite,desc)
EXTERNAL FadeToBlack()
EXTERNAL ChangeDetectiveVisionOn()
EXTERNAL ChangeDetectiveVisionOff()
EXTERNAL SpawnNPCCar()
EXTERNAL SittingDown()
EXTERNAL StandUp()

//Estadisticas personaje
VAR str = 2
VAR inte = 3
VAR refl = 3

VAR str_string = "str"
VAR inte_string = "inte"
VAR refl_string = "refl"

//Cadaver_Delgado
VAR exp_cabeza = false
VAR exp_torso = false
VAR exp_manos = false
VAR exp_piernas = false

//Coche
VAR exam_coche = false

//Sangre
VAR exam_sangre = false

//Finish
VAR finish_exam = false

//Colms
VAR intro = false
VAR investig = false

//Bench
VAR sat = false

=== function all_clear() ===
~ return exp_cabeza && exp_torso && exp_manos && exp_piernas && exam_coche && exam_sangre