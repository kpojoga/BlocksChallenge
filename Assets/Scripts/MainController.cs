using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{
    [SerializeField] private AudioSource _click;
    [SerializeField] private GameObject _tetrisGame;
    [SerializeField] private GameObject _colorGame;
    [SerializeField] private GameObject _orbitGame;

    [SerializeField] private GameObject _menu;
    [SerializeField] private Transform _games;


    [SerializeField] private Button _blockgame;
    [SerializeField] private Button _colorgame;

    

    private void Start()
    {
        _blockgame.onClick.AddListener(OpenTetrisGame);
    }

    public void OpenTetrisGame()
    {
        _click.Play();
        Time.timeScale = 1f;
        _menu.SetActive(false);
        _tetrisGame.SetActive(true);
        
    }

    public void OpenColorGame()
    {
        _click.Play();
        Time.timeScale = 1f;
        _colorGame.SetActive(true);
        _menu.SetActive(false);
    }

    public void OpenOrbitGame()
    {
        _click.Play();
        Time.timeScale = 1f;
        _orbitGame.SetActive(true);
        _menu.SetActive(false);
    }

    [SerializeField] private GameObject _settingsPanel;

    public void OpenSettings()
    {
        _click.Play();
        _settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        _click.Play();
        _settingsPanel.SetActive(false);
    }

}
