using UnityEngine;
using System.Collections.Generic;

public class Fade : MonoBehaviour 
{
    public Renderer Plane;

    Material FadeMaterial;

    void Start()
    {
        FadeMaterial = Plane.GetComponent<Renderer>().material;
        CurrentAlpha = FadedOutAlpha;
        FadeIn();
    }

    public float FadeTime = 2;

    private float CurrentAlpha = 0;

    public bool FadingIn;
    public bool FadingOut;

    public float FadedOutAlpha = 0.5f;
    public float FadedInAlpha = 0f;

    public void FadeIn()
    {
        FadingIn = true;
        FadingOut = false;
    }

    public void FadeOut()
    {
        FadingOut = true;
        FadingIn = false;
    }

    void Update()
    {
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
