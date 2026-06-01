using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

namespace ColorfullChaos
{
    public class ColorUI : MonoBehaviour
    {
        [SerializeField] public GameObject _gameOverPanel;

        [SerializeField] public GameObject _pausePanel;

        //[SerializeField] private Button _restart;

        [SerializeField] private GameObject _parent;

        [SerializeField] private AudioSource _click;

        //private Score CurrentScore;

        public void Restart()
        {
            _click.Play();
            for (var i = _parent.transform.childCount - 1; i >= 0; i--)
            {
                Object.Destroy(_parent.transform.GetChild(i).gameObject);
            }

            _gameOverPanel.SetActive(false);
            GameplayManager.Instance.score = 0;
            GameplayManager.Instance.Awake();
        }

        public void EndGame()
        {
            _click.Play();
            _gameOverPanel.SetActive(true);
        }

        public void Pause()
        {
            _click.Play();
            Time.timeScale = 0f;    
            _pausePanel.SetActive(true);
        }

        public void Continue()
        {
            _click.Play();
            _pausePanel.SetActive(false);
            Time.timeScale = 1f;
        }
    
    }
}
