using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{

    private float _state = 0;

    public void SoundControll()
    {
        AudioListener.volume = _state;
        if (_state == 0)
        {
            _state = 1;
        }
        else
        {
            _state = 0;
        }
    }
}
