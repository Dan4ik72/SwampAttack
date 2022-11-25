using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
[RequireComponent(typeof(SmoothSliderValueChanger))]
public class WaveProgressBar : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;

    private SmoothSliderValueChanger _sliderValueChanger;

    private Slider _slider;

    private float _currentUnitsCount;
    private float _currentBarValue = 0;
    private float _currentBarChangeStep;

    private void Awake()
    {
        _sliderValueChanger = GetComponent<SmoothSliderValueChanger>();
        _slider = GetComponent<Slider>();

        _slider.value = _currentBarValue;
    }

    private void OnEnable()
    {
        _spawner.OnWaveStarted += ResetProgressBar;
        _spawner.OnUnitSpawned += ChangeBarProgress;
    }

    private void OnDisable()
    {
        _spawner.OnUnitSpawned -= ChangeBarProgress;
        _spawner.OnWaveStarted -= ResetProgressBar;
    }

    private void ChangeBarProgress()
    {
        _currentBarValue += _currentBarChangeStep;

        _sliderValueChanger.ChangeValue(_currentBarValue, _slider);
    }

    private void ResetProgressBar()
    {
        _slider.value = _slider.minValue;
        _currentBarValue = _slider.value;

        _currentUnitsCount = _spawner.CurrentWave.Count;

        _currentBarChangeStep = _slider.maxValue / _currentUnitsCount;
    }
}