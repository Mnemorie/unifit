using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreboardLine : MonoBehaviour
{
    public Text Title;
    public Text Score;
    public Image locked;
    public Image completed;
    public Image current;

    public void ShowLevel(int level, RectTransform parent, LevelTier tier)
    {
        GameController game = FindObjectOfType<GameController>();
        LevelTemplate levelTemplate = FindObjectOfType<LevelTemplate>();

        if (Application.loadedLevel == level)
        {
            current.enabled = true;
        }
        else if (game.IsLevelUnlocked(level))
        {
            completed.enabled = true;
            int levelTime = game.GetCompletedLevelScore(level);
            Score.text = levelTemplate.GetScoreForTime(tier, levelTime);
        }
        else
        {
            locked.enabled = true;
        }

        GetComponent<RectTransform>().SetParent(parent);
        Title.text = tier.Title;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
