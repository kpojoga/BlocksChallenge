using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private AudioSource _clickSound;

    [SerializeField] private GameObject _menu;

    [SerializeField] private GameObject _colorGame;
    [SerializeField] private GameObject _orbirGame;
    [SerializeField] private GameObject _blockGame;
    [SerializeField] private GameObject _games;


    [SerializeField] private GameObject _colorGameOverPanel;
    [SerializeField] private GameObject _orbitGameOverPanel;
    [SerializeField] private GameObject _rulesPanel;

    public void CloseBlockGame()
    {
        _clickSound.Play();
        _menu.SetActive(true);
        _blockGame.SetActive(false);
        SceneManager.LoadScene("Main");

        //for (var i = _games.transform.childCount - 1; i >= 0; i--)
        //{
        //    Object.Destroy(_games.transform.GetChild(i).gameObject);
        //}
    }

    public void CloseColorGame()
    {
        _clickSound.Play();
        _colorGameOverPanel.SetActive(false);
        _menu.SetActive(true);
        _colorGame.SetActive(false);
        //Instantiate(_menu);
        SceneManager.LoadScene("Main");
    }

    public void CloseOrbitGame()
    {
        _clickSound.Play();
        _orbitGameOverPanel.SetActive(false);
        _menu.SetActive(true);
        _orbirGame.SetActive(false);
        SceneManager.LoadScene("Main");
    }

    public void OpenRules()
    {
        _clickSound.Play();
        _rulesPanel.SetActive(true);
    }

    public void CloseRules()
    {
        _clickSound.Play();
        _rulesPanel.SetActive(false);
    }



}
