using System.Collections;
using TMPro;
using UnityEngine;

namespace Orbibt
{
    public class GameplayManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scoreText;
        [SerializeField] private GameObject _scorePrefab;

        private int score;

        private void Awake()
        {
            GameManager.Instance.IsInitialized = true;

            score = 0;
            _scoreText.text = score.ToString();
            SpawnScore();
        }

        public void UpdateScore()
        {
            score++;
            _scoreText.text = score.ToString();
            SpawnScore();
        }

        [SerializeField] private Transform _scoreParent;
        private void SpawnScore()
        {
            Instantiate(_scorePrefab,_scoreParent);
        }

        [SerializeField] private GameObject _gameOverPanel;

        public void GameEnded()
        {
            GameManager.Instance.CurrentScore = score;
            Time.timeScale = 0f;
            _gameOverPanel.SetActive(true);

            //StartCoroutine(GameOver());
        }

        //private IEnumerator GameOver()
        //{
        //    yield return new WaitForSeconds(2f);
        //    GameManager.Instance.GoToMainMenu();
        //}

        public void RestartOrbit()
        {
            for (var i = _scoreParent.transform.childCount - 1; i >= 0; i--)
            {
                Object.Destroy(_scoreParent.transform.GetChild(i).gameObject);
            }

            _gameOverPanel.SetActive(false);
            Time.timeScale = 1f;
            Awake();
        }
    }
}
