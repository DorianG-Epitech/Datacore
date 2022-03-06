using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionSetter : MonoBehaviour
{
    public Dropdown DropdownElement;
    private Resolution[] _resolutionsValues;

    private void Start()
    {
        _resolutionsValues = Screen.resolutions;
        DropdownElement.options = new List<Dropdown.OptionData>();
        foreach (Resolution res in _resolutionsValues)
            DropdownElement.options.Add(new Dropdown.OptionData($"{res.width}x{res.height}"));
        DropdownElement.value = 0;
    }

    public void ChangeResolution(int choice)
    {
        Screen.SetResolution(_resolutionsValues[choice].width, _resolutionsValues[choice].height, false);
    }
}
