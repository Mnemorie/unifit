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
        int currentScore = Mathf.FloorToInt(Time.timeSinceLevelLoad);
        if (!PlayerPrefs.HasKey(scoreKey) ||
            PlayerPrefs.GetInt(scoreKey) > currentScore)
        {
            PlayerPrefs.SetInt(Application.loadedLevel + "-score", currentScore);
        }
        
		LoadNextLevel ();
	}

    public void SkipLevel()
    {
        if (IsLevelUnlocked(Application.loadedLevel + 1))
        {
            LoadNextLevel();
        }
        else
        {
            FindObjectOfType<HUD>().ShowHint("Next level is locked");
        }
    }

    public bool IsLevelUnlocked(int level)
    {
        return PlayerPrefs.HasKey(level + "-score");
    }

    public int GetCompletedLevelScore(int level)
    {
        if (!PlayerPrefs.HasKey(level + "-score"))
        {
            return -1;
        }

        return PlayerPrefs.GetInt(level + "-score");
    }
}
 