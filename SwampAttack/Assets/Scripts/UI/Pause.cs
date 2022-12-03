using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject _menuPanel;

    [SerializeField] private Button _pauseButton;

    private bool _isPaused = false;
    
    private void OnEnable()
    {
        _pauseButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _pauseButton.onClick.RemoveListener(OnButtonClick);
    }

    public void SetPanelState(GameObject panel)
    {
        panel.SetActive(true);
    }

    private void OnButtonClick()
    {
        _isPaused = !_isPaused;

        UpdatePauseGameState(_isPaused);
    }    

    private void UpdatePauseGameState(bool isPaused)
    {
        if (isPaused == true)
        {
            PauseGame();
            ShowMenuPanel();
        }
        else
        {
            ContinueGame();
            HideMenuPanel();
        }
    }

    private void ShowMenuPanel()
    {
        _menuPanel.SetActive(true);
    }

    private void HideMenuPanel()
    {
        _menuPanel.SetActive(false);
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
    }

    private void ContinueGame()
    {
        Time.timeScale = 1;
    }
}
