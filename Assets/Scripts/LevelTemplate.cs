using UnityEngine;
using UnityEngine.UI;

public class LevelTemplate : MonoBehaviour 
{
    public string GetCurrentScore()
    {
        float time = Time.timeSinceLevelLoad;
        LevelTier tiers = FindObjectOfType<LevelTiers>().Tiers[Application.loadedLevel - 1];

        if (time < tiers.TierA)
        {
            return "A";
        }

        if (time < tiers.TierB)
        {
            return "B";
        }

        if (time < tiers.TierC)
        {
            return "C";
        }

        if (time < tiers.TierD)
        {
            return "D";
        }

        return "E";
    }

    public Color GetCurrentScoreColor()
    {
        string currentScore = GetCurrentScore();
        switch (currentScore)
        {
            case "A":
                return Color.green;
            case "B":
                return Color.yellow;
            case "C":
                return new Color(1, 0.5f, 0, 1);
            case "D":
                return Color.red;
        }

        return new Color(0, 0.5f, 1, 1);
    }

}
