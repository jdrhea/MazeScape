using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageButtons : MonoBehaviour
{
    public Text TexttoChange;
    public void English()
    {
        TexttoChange.text = "WASD (for movement) Shift for Sprinting space for killing enemies q for removing sword";
    }
    public void Spanish()
    {
        TexttoChange.text = "WASD (para acción) Shift para correr space para matar los contrarios q para eliminar el espada";
    }
    public void French()
    {
        TexttoChange.text = "WASD (pour le mouvement) SHIFT pour le sprint SPACE pour tuer les ennemis Q pour retirer l'épée";
    }
    public void German()
    {
        TexttoChange.text = "WASD (für Bewegung) SHIFT zum Sprinten SPACE zum Töten von Feinden Q zum Entfernen des Schwertes";
    }
}
