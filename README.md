# Platform-Collision-Quest
platformer rigolo dans lequel le personnage s'éclate dans les murs

Elements de juice :

VFX Graph : fumée quand le joueur dash qui se stoppe quand il se colle a un mur

Shader Graph : celui du VFX de fumée et drapeau RGB

Particule systèmes : collisions avec les murs et sang quand le joueur/un ennemie meurt

Post Process : aberration chromatique et lens distortion lors de la mort du joueur

SFX : Dash (3 différents joués aléatoirement) - cadavres (3 sons différens joués aléatoirement a chaque collision des membres du joeuur une fois mort) - collision avec un mur - collision avec un mur solide - bumper - mort (1 son de "chair" lorsque le joueur explose et 1 son pour rajouter du poids a l'effet de post process) - drop - win - mort ennemis(2 différents joués aléatoirement).

Camera screenshakes : rumble quand le joueur s'encastre dans un mur ou meurt (tres puissant si il meurt) - bump quand il cogne un mur ou un bumper

Camera Behaviour : la camera suit un objet placé a la position du personnage additionné a son vecteur vélocité. Elle est donc "en avance" sur les mouvemenbts du personnage et revient tres vite en arrière vers le joeuur quand celui-ci rencontre un mur. Donnant une impression d'une puissance telle qu'elle casse la caméra.

Interactions avec les murs : les murs changent de sprite quand le personnage s'encastre dedans. entre l'état cassé et l'état neuf, il passe par un état "hit" tres visible. Rendant "l'encastrage" satisfaisant

Autre : Tâche de sang a la mort du joueur lui permettant d'observer son parcours (frustrant quand opn meurt 16 fois au meme endroit).

Music by Karl Casey @ White Bat Audio