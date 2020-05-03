using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_SizeToggle : MonoBehaviour
{
    public event Action<Memory.Enums.GridSize> Selected;
    
    [SerializeField]
    private Toggle _toggle;
    
    [SerializeField]
    private Memory.Enums.GridSize _size;

    private void Awake()
    {
        _toggle.onValueChanged.AddListener(OnToggleValueChanged);
    }

    private void OnToggleValueChanged(bool value)
    {
        if (value)
        {
            Selected?.Invoke(_size);
        }
    }
}
