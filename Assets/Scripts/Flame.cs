using UnityEngine;
using System.Collections;

public class Flame : MonoBehaviour
{
    public Renderer SmallFlame;
    public Renderer BigFlame;

    public void SetBigFlameColor(Color c)
    {
        SmallFlame.material.SetColor("_Color", c);
    }

    public void SetSmallFlameColor(Color c)
    {
        BigFlame.material.SetColor("_Color", c);
    }
}
