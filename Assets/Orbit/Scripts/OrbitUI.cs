using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitUI : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private AudioSource _clickSound;
    [SerializeField] private GameObject _safeArea;

    public void Pause()
    {
        _safeArea.SetActive(false);
        _clickSound.Play();
        Time.timeScale = 0f;
        _pausePanel.SetActive(true);
    }

    public void Continue()
    {
        _safeArea.SetActive(true);
        _clickSound.Play();
        _pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

}
