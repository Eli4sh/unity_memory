using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_SelectSizePanel : MonoBehaviour
{
    public event Action<Memory.Enums.GridSize> SizeSelected;

    [SerializeField]
    private UI_SizeToggle[] _sizeToggles;

    private void Awake()
    {
        foreach (var toggle in _sizeToggles)
        {
            toggle.Selected += (OnToggleValueChanged);
        }
    }

    private void OnToggleValueChanged(Memory.Enums.GridSize size)
    {
        SizeSelected?.Invoke(size);
    }
}