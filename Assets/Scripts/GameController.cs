using System;
using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public float TimeToLoadNextLevel = 1;

	public int currentLevel;
    private bool LoadingLevel;

    HUD hud;

	void Start()
    {
        hud = FindObjectOfType<HUD>();

        currentLevel = Application.loadedLevel;

        if (IsLevelUnlocked(currentLevel + 1))
        {
            hud.ShowHint("Press SPACEBAR to skip to next level");
        }
        else
        {
            hud.ShowHint("Press ESC to start over");
        }
	}

    void Update()
    {
        if (LoadingLevel)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && currentLevel > 1)
            {
                --currentLevel;
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && currentLevel == 1)
            {
                Application.Quit();
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#endif
            }

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

	public void RestartLevel()
    {
        LoadingLevel = true;

        Fade fade = FindObjectOfType<Fade>();
        if (fade)
        {
            fade.FadeOut();
        }
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
            hud.ShowHint("Next level is locked");
            hud.ShowScore();
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
 