using UnityEngine;
using System.Collections;

public class GUIHelper 
{
    static public void DrawTextWithOutline(Rect r, string t, Color color, TextAnchor alignment)
    {
        GUI.skin.label.alignment = TextAnchor.MiddleCenter;

        GUIHelper.DrawOutline(r, t, 2);
        GUI.color = Color.white;

        GUI.Label(r, t);
    }

    static public void DrawOutline(Rect r, string t, int strength)
    {
        GUI.color = new Color(0, 0, 0, 1);
        int i;
        for (i = -strength; i <= strength; i++)
        {
            GUI.Label(new Rect(r.x - strength, r.y + i, r.width, r.height), t);
            GUI.Label(new Rect(r.x + strength, r.y + i, r.width, r.height), t);
        } for (i = -strength + 1; i <= strength - 1; i++)
        {
            GUI.Label(new Rect(r.x + i, r.y - strength, r.width, r.height), t);
            GUI.Label(new Rect(r.x + i, r.y + strength, r.width, r.height), t);
        }
    }
}
