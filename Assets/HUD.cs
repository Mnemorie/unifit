using System;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour 
{
    public Text Location;
    public Text SubTitle;
    public Text Lettrine;
    public Text Hint;

    LevelTemplate level;

    void Start()
    {
        Location.text = BeautifyLevelName(Application.loadedLevelName);
        level = FindObjectOfType<LevelTemplate>();
    }

    void Update()
    {
        float levelTime = Time.timeSinceLevelLoad;
        SubTitle.text = String.Format( "{0}:{1:D2}", Mathf.FloorToInt(levelTime / 60), Mathf.FloorToInt(levelTime) % 60 );

        Lettrine.material.color = level.GetCurrentScoreColor();
        Lettrine.text = level.GetCurrentScore();
    }

    string BeautifyLevelName(string levelName)
    {
        string outName = "";

        foreach (char c in levelName.Remove(0, levelName.IndexOf('-') + 1))
        {
            if (c == '-' || Char.IsUpper(c))
            {
                outName += " ";
            }
            outName += c;
        }

        return outName;
    }
    

}
