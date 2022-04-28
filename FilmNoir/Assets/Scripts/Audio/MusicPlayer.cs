using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip musicClip;

    // Start is called before the first frame update
    void Start()
    {
        if(musicClip != null)
        {
            GameManager.manager.SetMusic(musicClip);
        }
    }

}
