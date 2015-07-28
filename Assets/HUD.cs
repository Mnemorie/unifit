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
    public ScoreboardLine LineTemplate;

    LevelTemplate level;

    public float ScoreBoardDisplayTime = 4;

    float InitialScoreBoardDisplayTime;

    void Start()
    {
        Location.text = BeautifyLevelName(Application.loadedLevelName);
        level = FindObjectOfType<LevelTemplate>();

        PopulateScoreBoard();

        InitialScoreBoardDisplayTime = ScoreBoardDisplayTime;
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

        //ScoreBoardDisplayTime -= Time.deltaTime;
        //if (ScoreBoardDisplayTime < 0 && ScoreBoard.gameObject.activeSelf)
        //{
        //    ScoreBoard.gameObject.SetActive(false);
        //}
        //else if (ScoreBoardDisplayTime > 0 && !ScoreBoard.gameObject.activeSelf)
        //{
        //    ScoreBoard.gameObject.SetActive(true);
        //}
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
            ScoreboardLine instance = Instantiate(LineTemplate);
            instance.ShowLevel(i+1, ScoreBoard, tiers[i]);
        }
    }

    public void ShowScore()
    {
        ScoreBoardDisplayTime = InitialScoreBoardDisplayTime;
    }

    public void ShowHint(string p)
    {
        Hint.text = p;
        showingHint = true;

        currentHintTextDisplayTime = HintTextDisplayTime;
    }
}
