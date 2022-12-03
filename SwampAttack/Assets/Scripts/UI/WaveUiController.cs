using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WaveUiController : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;

    [SerializeField] private Slider _waveProgressBar;
    [SerializeField] private TMP_Text _waveEndedText;
    [SerializeField] private Button _startNewWaveButton;

    private void OnEnable()
    {
        _spawner.OnWaveStarted += OnWaveStarted;
        _spawner.OnWaveEnded += OnWaveEnded;
    }

    private void OnDisable()
    {
        _spawner.OnWaveStarted -= OnWaveStarted;
        _spawner.OnWaveEnded -= OnWaveEnded;
    }

    private void Start()
    {
        _waveEndedText.gameObject.SetActive(false);
        _waveProgressBar.gameObject.SetActive(false);
    }

    private void OnWaveStarted()
    {
        ShowProgressBar();
        HideStartNewWaveButton();
    }

    private void OnWaveEnded()
    {
        HideProgressBar();
        ShowWaveEndedText();
        HideWaveEndedText();
        ShowStartNewWaveButton();
    }

    private void HideStartNewWaveButton()
    {
        _startNewWaveButton.gameObject.SetActive(false);
    }

    private void ShowStartNewWaveButton()
    {
        _startNewWaveButton.gameObject.SetActive(true);
    }

    private void HideProgressBar()
    {
        _waveProgressBar.gameObject.SetActive(false);
    }

    private void ShowProgressBar()
    {
        _waveProgressBar.gameObject.SetActive(true);
    }
    
    private void ShowWaveEndedText()
    {
        _waveEndedText.gameObject.SetActive(true);
    }

    private void HideWaveEndedText()
    {
        StartCoroutine(HideWaveEndedTextAfterDelay());
    }

    private IEnumerator HideWaveEndedTextAfterDelay()
    {
        yield return new WaitForSeconds(5);

        _waveEndedText.gameObject.SetActive(false);
    }
}
