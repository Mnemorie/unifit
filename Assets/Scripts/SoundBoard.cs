using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundBoard : MonoBehaviour
{
    private List<AudioSource> Channels;

    public AudioSource ChannelTemplate;
    public int NumberOfChannels;

    void Awake()
    {
        Channels = new List<AudioSource>();

        for (int i = 0; i < NumberOfChannels; ++i)
        {
            Channels.Add(Instantiate(ChannelTemplate));
            Channels[i].transform.parent = transform;
            Channels[i].gameObject.name = "channel " + i;
        }
    }

	public void Play(AudioClip clip, Transform location = null)
    {
        foreach(var c in Channels)
        {
            if (!c.isPlaying)
            {
                if (location != null)
                {
                    c.transform.parent = location;
                    c.transform.localPosition = Vector3.zero;
                    c.transform.localRotation = Quaternion.identity;
                }
                else
                {
                    c.transform.parent = transform;
                    c.transform.localPosition = Vector3.zero;
                    c.transform.localRotation = Quaternion.identity;
                }

                c.clip = clip;
                c.Play();
                break;
            }
        }
    }

    public void PlayAny(AudioClip[] clips, Transform location = null)
    {
        Play(clips[Random.Range(0, clips.Length)], location);
    }
}
