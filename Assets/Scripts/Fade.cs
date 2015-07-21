using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Fade : MonoBehaviour 
{
    public Renderer Plane;
    public Canvas Title;

    private Text TitleText;
    private Text LevelNumberText;
    Material FadeMaterial;

    void Start()
    {
        FadeMaterial = Plane.GetComponent<Renderer>().material;
        CurrentAlpha = FadedOutAlpha;
        FadeIn();

        Canvas c = Instantiate(Title);

        TitleText = c.GetComponentsInChildren<Text>()[0];
        LevelNumberText = c.GetComponentsInChildren<Text>()[1];
        TitleText.text = BeautifyLevelName(Application.loadedLevelName);
        LevelNumberText.text = "LEVEL " + (Application.loadedLevel - 2);
    }

    // might not catch all cases we will use
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
    
    public float FadeTime = 2;
    public float TitleDisplayTime = 3;
    public float TitleFadeTime = 1;

    private float CurrentTitleDisplayTime;
    private bool FadingText;

    private float CurrentAlpha = 0;

    public bool FadingIn;
    public bool FadingOut;

    public float FadedOutAlpha = 0.5f;
    public float FadedInAlpha = 0f;

    public void FadeIn()
    {
        FadingIn = true;
        FadingOut = false;

        FadingText = true;
        CurrentTitleDisplayTime = 0;
    }

    public void FadeOut()
    {
        FadingOut = true;
        FadingIn = false;
    }

    void Update()
    {
        CurrentTitleDisplayTime += Time.deltaTime;
        if (FadingText && CurrentTitleDisplayTime > TitleDisplayTime) 
        {
            if (CurrentTitleDisplayTime < TitleDisplayTime + TitleFadeTime)
            {
                Color textCol = TitleText.color;
                textCol.a = 1 - ((CurrentTitleDisplayTime - TitleDisplayTime) / TitleFadeTime);
                TitleText.color = textCol;
                LevelNumberText.color = textCol;
            }
            else
            {
                FadingText = false;
                Color textCol = TitleText.color;
                textCol.a = 0;
                TitleText.color = textCol;
                LevelNumberText.color = textCol;
            }
        }

        if (!(FadingIn || FadingOut))
            return;

        if (FadingIn)
        {
            CurrentAlpha -= Time.deltaTime / FadeTime;

            if (CurrentAlpha <= FadedInAlpha)
            {
                CurrentAlpha = FadedInAlpha;
                FadingIn = false;
            }
        }
        else if (FadingOut)
        {
            CurrentAlpha += Time.deltaTime / FadeTime;

            if (CurrentAlpha >= FadedOutAlpha)
            {
                CurrentAlpha = FadedOutAlpha;
                FadingOut = false;
            }
        }

        Color col = FadeMaterial.GetColor("_TintColor");
        col.a = CurrentAlpha;
        FadeMaterial.SetColor("_TintColor", col);
    }

}
