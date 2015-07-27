using UnityEngine;
using UnityEngine.UI;

public class LevelTemplate : MonoBehaviour 
{
    public string GetCurrentScore()
    {
        float time = Time.timeSinceLevelLoad;
        LevelTier tiers = FindObjectOfType<LevelTiers>().Tiers[Application.loadedLevel - 1];

        return GetScoreForTime(tiers, time);
    }

    public string GetScoreForTime(LevelTier tier, float time)
    {
        if (time < tier.TierA)
        {
            return "A";
        }

        if (time < tier.TierB)
        {
            return "B";
        }

        if (time < tier.TierC)
        {
            return "C";
        }

        if (time < tier.TierD)
        {
            return "D";
        }

        return "E";
    }

    public Color GetScoreColor(string score)
    {
        switch (score)
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
