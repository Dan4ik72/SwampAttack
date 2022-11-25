using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HeathBarView : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private SmoothSliderValueChanger _sliderValueChanger;

    private Slider _slider;

    private void OnEnable()
    {
        _player.OnHealthChanged += ChangeHealthBarValue;
    }

    private void OnDisable()
    {
        _player.OnHealthChanged -= ChangeHealthBarValue;
    }

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void Start()
    {
        _slider.maxValue = _player.MaxHealth;

        _slider.value = _slider.maxValue;
    }

    private void ChangeHealthBarValue(int health)
    {
        _sliderValueChanger.ChangeValue(health, _slider);
    }
}
