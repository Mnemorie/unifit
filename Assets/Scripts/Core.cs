using System;
using UnityEngine;

[SelectionBase]
public class Core : MonoBehaviour 
{
    Vector3 lastUp;

    HUD HUD;

    void Start()
    {
        HUD = FindObjectOfType<HUD>();
        SetupAudio();
    }

    void Update()
    {
        UpdateTricks();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            FindObjectOfType<GameController>().SkipLevel();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            FindObjectOfType<GameController>().RestartLevel();
        }

        CollisionSoundCoolDown -= Time.deltaTime;
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

        OnFloorCollision();
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
        if (absRotation < 180)
        {
            return;
        }

        if (currentRotation > 0)
        {
            ShowTrickText(Mathf.FloorToInt(absRotation / 180) * 180 + "° Front Flip");
        }
        else
        {
            ShowTrickText(Mathf.FloorToInt(absRotation / 180) * 180 + "° Back Flip");
        }
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

    public AudioSource Output;

    private Action OnFloorCollision = () => { };
    public Action OnEnterZone = () => { };
    public Action OnLeaveZone = () => { };
    public Action OnWin = () => { };

    public AudioClip[] CollisionSound;
    public AudioClip EnterZoneSound;
    public AudioClip LeaveZoneSound;
    public AudioClip WinSound;

    private float CollisionSoundCoolDown;

    void SetupAudio()
    {
        OnFloorCollision += () =>
        {
            if (CollisionSoundCoolDown < 0)
            {
                Output.clip = CollisionSound[UnityEngine.Random.Range(0, CollisionSound.Length)];
                Output.Play();
                CollisionSoundCoolDown = 0.5f;
            }
        };

        OnEnterZone += () =>
        {
            Output.clip = EnterZoneSound;
            Output.Play();
        };

        OnLeaveZone += () =>
        {
            Output.clip = LeaveZoneSound;
            Output.Play();
        };

        OnWin += () =>
        {
            Output.clip = WinSound;
            Output.Play();
        };
    }

}
