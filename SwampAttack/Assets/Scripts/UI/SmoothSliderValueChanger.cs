using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmoothSliderValueChanger : MonoBehaviour
{
    [SerializeField] private float _smoothChangeValueStep = 0.001f;

    public void ChangeValue(float newValue, Slider slider)
    {
        StartCoroutine(SmoothChangeValue(newValue, slider));
    }

    private IEnumerator SmoothChangeValue(float newValue, Slider slider)
    {
        while (slider.value != newValue)
        {
            slider.value = Mathf.MoveTowards(slider.value, newValue, _smoothChangeValueStep);

            yield return null;
        }
    }
}
