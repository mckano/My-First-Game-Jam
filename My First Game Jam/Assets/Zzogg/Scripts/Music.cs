using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField]
    AK.Wwise.Event _myEvent;
    void Start()
    {
        _myEvent.Post(gameObject);
    }

 
}
