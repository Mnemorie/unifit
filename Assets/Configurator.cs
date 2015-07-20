using System;
using UnityEngine;
using System.Collections;

public class Configurator : MonoBehaviour 
{
    public int NumberOfPlayers = 4;

    public int CurrentPlayer;

    public enum ConfigurationPhase
    {
        ControllerSelect,

        SlideUp,
        SlideDown,
        SlideLeft,
        SlideRight,

        RocketUp,
        RocketDown,
        RocketLeft,
        RocketRight,

        Done,

        AllDone
    }
    ConfigurationPhase CurrentPhase;

    void Start()
    {
        CurrentPlayer = -1;
        ConfigureNextPlayer();
    }

    void ConfigureNextPlayer()
    {
        CurrentPlayer++;

        if (CurrentPlayer == NumberOfPlayers)
        {
            CurrentPhase = ConfigurationPhase.AllDone;
        }
        else
        {
            CurrentPhase = ConfigurationPhase.ControllerSelect;
        }
    }

	void Update () 
    {
        if (CurrentPhase == ConfigurationPhase.AllDone)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (CurrentPhase == ConfigurationPhase.ControllerSelect)
            {
                if (CurrentPlayer > 0)
                {
                    CurrentPlayer--;
                }
            }
            else
            {
                CurrentPhase = ConfigurationPhase.ControllerSelect;
            }
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CurrentPhase++;
            return;
        }

        if (CurrentPhase == ConfigurationPhase.Done)
        {
            ConfigureNextPlayer();
        }
    }

    void OnGUI()
    {
        if (CurrentPhase == ConfigurationPhase.AllDone)
        {
            GUILayout.Label("Done");
            return;
        }



        GUILayout.Label(String.Format("Player {0} press {1}", CurrentPlayer + 1, CurrentPhase));
    }
}
