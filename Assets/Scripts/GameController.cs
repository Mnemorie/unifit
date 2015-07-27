using System;
using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public float TimeToLoadNextLevel = 1;

	public int currentLevel;
    private bool LoadingLevel;
    
	void Start()
    {
        currentLevel = Application.loadedLevel;
	}

    void Update()
    {
        if (LoadingLevel)
        {
            TimeToLoadNextLevel -= Time.deltaTime;
            if (TimeToLoadNextLevel <= 0)
            {
                Application.LoadLevel(currentLevel);
                LoadingLevel = false;
            }
        }
    }

	public void StartGame()
    {
		LoadNextLevel ();
	}

	private void LoadNextLevel()
    {
		currentLevel++;
        LoadingLevel = true;

        Fade fade = FindObjectOfType<Fade>();
        if (fade)
        {
            fade.FadeOut();
        }
	}

	private void RestartLevel()
    {
        LoadingLevel = true;

        Fade fade = FindObjectOfType<Fade>();
        if (fade)
        {
            fade.FadeOut();
        }
	}

	public void Lose()
    {
		RestartLevel ();
	}

	public void WinLevel()
    {
        string scoreKey = Application.loadedLevel + "-score";
        string currentScore = FindObjectOfType<LevelTemplate>().GetCurrentScore();
        if (!PlayerPrefs.HasKey(scoreKey) ||
            char.Parse(PlayerPrefs.GetString(scoreKey)) > char.Parse(currentScore))
        {
            PlayerPrefs.SetString(Application.loadedLevel + "-score", "" + currentScore);
        }
        
		LoadNextLevel ();
	}

    public void SkipLevel()
    {
        if (IsLevelUnlocked(Application.loadedLevel+1))
        {
            LoadNextLevel();
        }
    }

    public bool IsLevelUnlocked(int level)
    {
        return PlayerPrefs.HasKey(level + "-score");
    }
}
 