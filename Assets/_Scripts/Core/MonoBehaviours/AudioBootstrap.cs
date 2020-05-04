﻿using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;

public class AudioBootstrap : MonoBehaviour
{
    private static bool _initialized = false;

    private void Awake()
    {
        if (_initialized == false)
        {
            Audio.InitAudio(FindObjectOfType<Factory>());
            Audio.PlaySound(Core.Enums.AudioType.BACKGROUND, true);
            _initialized = true;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}