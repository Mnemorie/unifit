﻿using System.Linq;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Core : MonoBehaviour 
{
    Vector3 lastUp;

    HUD HUD;

    void Start()
    {
        HUD = FindObjectOfType<HUD>();
    }

    void Update()
    {
        UpdateTricks();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            FindObjectOfType<GameController>().SkipLevel();
        }
    }

    void UpdateTricks()
    {
        currentRotation += AngleSigned(lastUp, transform.up, Vector3.right);
        lastUp = transform.up;
    }

    public float currentRotation;
    public int halfTurns;

    void OnCollisionEnter(Collision col)
    {
        ValidateTrick();

        lastUp = transform.up;
        currentRotation = 0;
    }

    void OnCollisionStay(Collision col)
    {
        lastUp = transform.up;
        currentRotation = 0;
    }

    Vector3 firstUp;

    void OnCollisionExit(Collision col)
    {
        firstUp = transform.up;
        lastUp = firstUp;
    }

    void ValidateTrick()
    {
        float absRotation = Mathf.Abs(currentRotation) + 10;
        if (absRotation < 360)
        {
            return;
        }

        ShowTrickText(Mathf.FloorToInt(absRotation / 360) * 360 + "° Flip");
    }


    void ShowTrickText(string trick)
    {
        HUD.ShowHint(trick);
    }

    public static float AngleSigned(Vector3 v1, Vector3 v2, Vector3 n)
    {
        return Mathf.Atan2(
            Vector3.Dot(n, Vector3.Cross(v1, v2)),
            Vector3.Dot(v1, v2)) * Mathf.Rad2Deg;
    }

}
