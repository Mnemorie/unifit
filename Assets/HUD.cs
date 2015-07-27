using System;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class HUD : MonoBehaviour 
{
    public Text Location;
    public Text SubTitle;
    public Text Lettrine;
    public Text Hint;

    public RectTransform ScoreBoard;
    public Text CompletedTemplate;
    public Text CurrentTemplate;
    public Text LockedTemplate;

    LevelTemplate level;

    void Start()
    {
        Location.text = BeautifyLevelName(Application.loadedLevelName);
        level = FindObjectOfType<LevelTemplate>();

        PopulateScoreBoard();
    }


    public float HintTextDisplayTime = 2;
    float currentHintTextDisplayTime;
    bool showingHint;

    void Update()
    {
        float levelTime = Time.timeSinceLevelLoad;
        SubTitle.text = String.Format( "{0}:{1:D2}", Mathf.FloorToInt(levelTime / 60), Mathf.FloorToInt(levelTime) % 60 );

        string score = level.GetCurrentScore();

        Lettrine.text = score;
        Lettrine.material.color = level.GetScoreColor(score);

        if (showingHint)
        {
            currentHintTextDisplayTime -= Time.deltaTime;
            if (currentHintTextDisplayTime < 0)
            {
                Hint.text = "";
                showingHint = false;
            }
        }
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

    public float ScoreBoardYPadding = 40;

    void PopulateScoreBoard()
    {
        LevelTier[] tiers = FindObjectOfType<LevelTiers>().Tiers;
        GameController game = FindObjectOfType<GameController>();

        for (int i = 0; i < tiers.Length; ++i)
        {
            Text instance;
            if (i + 1 == Application.loadedLevel)
            {
                instance = Instantiate(CurrentTemplate);
            }
            else if (game.IsLevelUnlocked(i+1))
            {
                instance = Instantiate(CompletedTemplate);

                int levelTime = game.GetCompletedLevelScore(i + 1);
                instance.rectTransform.GetChild(2).GetComponent<Text>().text = level.GetScoreForTime(tiers[i], levelTime);
            }
            else
            {
                instance = Instantiate(LockedTemplate);
            }

            instance.rectTransform.parent = ScoreBoard;
            instance.rectTransform.localPosition = new Vector3(0, (-(i - (tiers.Length/2)) * ScoreBoardYPadding), 0);
            instance.text = tiers[i].Title;
        }
    }



    public void ShowHint(string p)
    {
        Hint.text = p;
        showingHint = true;

        currentHintTextDisplayTime = HintTextDisplayTime;
    }
}
