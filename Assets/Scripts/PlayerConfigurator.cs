using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerConfigurator : MonoBehaviour 
{
    public Animator Animator;
    public int PlayerIndex;

    public Image SlideUp;
    public Image SlideDown;
    public Image SlideLeft;
    public Image SlideRight;

    public Image RocketUp;
    public Image RocketDown;
    public Image RocketLeft;
    public Image RocketRight;

    public Text Label;

    void Start()
    {
        Animator = GetComponentInParent<Animator>();
    }

    public void Clear()
    {
        SlideUp.enabled = false;
        SlideDown.enabled = false;
        SlideLeft.enabled = false;
        SlideRight.enabled = false;

        RocketUp.enabled = false;
        RocketDown.enabled = false;
        RocketLeft.enabled = false;
        RocketRight.enabled = false;
    }

    public void ShowSlideUp()
    {
        Clear();
        SlideUp.enabled = true;
    }

    public void ShowSlideDown()
    {
        Clear();
        SlideDown.enabled = true;
    }

    public void ShowSlideLeft()
    {
        Clear();
        SlideLeft.enabled = true;
    }

    public void ShowSlideRight()
    {
        Clear();
        SlideRight.enabled = true;
    }

    public void ShowRocketUp()
    {
        Clear();
        RocketUp.enabled = true;
    }

    public void ShowRocketDown()
    {
        Clear();
        RocketDown.enabled = true;
    }

    public void ShowRocketLeft()
    {
        Clear();
        RocketLeft.enabled = true;
    }

    public void ShowRocketRight()
    {
        Clear();
        RocketRight.enabled = true;
    }

    public void Ready()
    {
        Animator.SetBool("P" + PlayerIndex + "Ready", true);
    }

    public void Unready()
    {
        Animator.SetBool("P" + PlayerIndex + "Ready", false);
    }
}
