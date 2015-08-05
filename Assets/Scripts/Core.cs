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

    private Action OnFloorCollision = () => { };
    public Action OnEnterZone = () => { };
    public Action OnLeaveZone = () => { };
    public Action OnWin = () => { };

    public AudioClip[] CollisionSound;
    public AudioClip EnterZoneSound;
    public AudioClip LeaveZoneSound;
    public AudioClip WinSound;

    private float CollisionSoundCoolDown;

    private SoundBoard SoundBoard;

    void PlaySound(AudioClip clip)
    {
        if (SoundBoard)
        {
            SoundBoard.Play(clip, transform);
        }
    }

    void PlaySound(AudioClip[] clips)
    {
        if (SoundBoard)
        {
            SoundBoard.PlayAny(clips, transform);
        }
    }

    void SetupAudio()
    {
        SoundBoard = FindObjectOfType<SoundBoard>();

        if (SoundBoard)
        {
            OnFloorCollision += () =>
            {
                if (CollisionSoundCoolDown < 0)
                {
                    PlaySound(CollisionSound);
                    CollisionSoundCoolDown = 0.5f;
                }
            };

            OnEnterZone += () => PlaySound(EnterZoneSound);
            OnLeaveZone += () => PlaySound(LeaveZoneSound);
            OnWin += () => PlaySound(WinSound);
        }

    }

}
