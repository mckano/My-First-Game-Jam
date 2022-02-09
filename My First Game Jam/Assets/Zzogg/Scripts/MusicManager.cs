using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField]
    AK.Wwise.Event _myEvent;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        //AkSoundEngine.PostEvent("play_onion_music_01", gameObject);
        _myEvent.Post(gameObject);
    }


}
