# Videojuego Aplicado

Proyecto desarrollado en **Unity 6** para la actividad **“Videojuego/proyecto aplicando conocimientos de clase”**.

## Qué incluye

- **MainMenu**
- **Level1, Level2 y Level3**
- **GameOver**
- **WinScreen**
- selección de color del jugador (**azul** o **amarillo**)
- música por escena
- sonido al recoger collectibles
- enemigo con **NavMesh**
- transición entre niveles

## Cómo funciona

El jugador controla una esfera y debe recoger todos los **collectibles** de cada nivel para avanzar.

Flujo del juego:

- `MainMenu` → `Level1`
- `Level1` → `Level2`
- `Level2` → `Level3`
- `Level3` → `WinScreen`

Si el enemigo alcanza al jugador, se carga la escena **GameOver**.

## Estructura principal

### Escenas
`Assets/Scenes/`

- `MainMenu.unity`
- `Level1.unity`
- `Level2.unity`
- `Level3.unity`
- `GameOver.unity`
- `WinScreen.unity`

### Scripts
`Assets/Scripts/`

- `MainMenu.cs` → menú principal y selección de color
- `PlayerSettings.cs` → guarda el color elegido
- `GameSession.cs` → guarda el último nivel jugado
- `Esfera.cs` → movimiento y recolección
- `GameManager.cs` → contador y cambio de nivel
- `Enemigo.cs` → comportamiento del enemigo con NavMesh
- `MusicManager.cs` → música según la escena
- `GameOverScreen.cs` → botones de Game Over
- `WinScreen.cs` → botones de victoria
- `Rotador.cs` → rotación de collectibles

### Audio
`Assets/Audio/`

- `musica-de-menu-principal.mp3`
- `musica-de-fondo.mp3`
- `musica-moneda.mp3`
- `musica-tension-enemigo.mp3`
- `musica-perdedor.mp3`
- `musica-ganador.mp3`

### Imágenes
`Assets/Images/`

- `menu-principal.jpg`
- `game-over-pantalla.jpg`

## Controles

- **W / A / S / D** o flechas → mover al jugador

## Temas aplicados

- manejo de escenas
- Canvas y UI básica en Unity
- audio por escena
- collectibles
- transición entre niveles
- NavMesh
- organización del proyecto en Unity
