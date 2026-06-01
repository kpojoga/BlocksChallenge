using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace ColorfullChaos
{
    public class GameplayManager : MonoBehaviour
    {
        #region START

        [SerializeField] private AudioSource _pianoClick;

        public bool hasGameFinished;

        public static GameplayManager Instance;

        public List<Color> Colors;


        public void Awake()
        {
            Instance = this;

            hasGameFinished = false;
           // GameManager.Instance.IsInitialized = true;

            score = 0;
            //_scoreText.text = ((int)score).ToString();
            StartCoroutine(SpawnScore());

        }

        private void OnMouseDown()
        {
            
        }

        #endregion

        #region GAME_LOGIC

        [SerializeField] private ScoreEffect _scoreEffect;
        

        public void Update()
        {
            
            if (Input.GetMouseButtonDown(0) && !hasGameFinished)
            {

                if (CurrentScore == null)
                {
                    GameEnded();
                    return;
                }

                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
                RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

                if (hit.collider.gameObject.CompareTag("Block"))
                {
                    _pianoClick.Play();
                }
                    

                //if (!hit.collider || !hit.collider.gameObject.CompareTag("Block"))
                //{
                //    GameEnded();
                //    return;
                //}

                if (!hit.collider.gameObject.CompareTag("Block"))
                {
                    GameEnded();
                    return;
                }

                int currentScoreId = CurrentScore.ColorId;
                int clickedScoreId = hit.collider.gameObject.GetComponent<Player>().ColorId;


                if (currentScoreId != clickedScoreId)
                {
                    GameEnded();
                    return;
                }

                var t = Instantiate(_scoreEffect, CurrentScore.gameObject.transform.position, Quaternion.identity);
                t.Init(Colors[currentScoreId]);

                var tempScore = CurrentScore;
                if (CurrentScore.NextScore != null)
                {
                    CurrentScore = CurrentScore.NextScore;
                }

                Destroy(tempScore.gameObject);

                UpdateScore();

            }
        }

        #endregion

         #region SCORE

            public float score;
            [SerializeField] private TMP_Text _scoreText;
            [SerializeField] private AudioClip _pointClip;

            private void UpdateScore()
            {
                score++;
                _scoreText.text = ((int)score).ToString();
            }
        
            [SerializeField] private float _spawnTime;
            [SerializeField] private Score _scorePrefab;
            [SerializeField] private Transform _blockScoreParent;


            private Score CurrentScore;

            public IEnumerator SpawnScore()
            {
                Score prevScore = null;

                while (!hasGameFinished)
                {
                    var tempScore = Instantiate(_scorePrefab,_blockScoreParent);

                    if (prevScore == null)
                    {
                        prevScore = tempScore;
                        CurrentScore = prevScore;
                    }
                    else
                    {
                        prevScore.NextScore = tempScore;
                        prevScore = tempScore;
                    }

                    yield return new WaitForSeconds(_spawnTime);
                }
            }

        #endregion

        #region GAME_OVER

        [SerializeField] public GameObject _gameOverPanel;

        [SerializeField] private AudioClip _loseClip;
        public UnityAction GameEnd;

        public void GameEnded()
        {
            hasGameFinished = true;
            GameEnd?.Invoke();
            //SoundManager.Instance.PlaySound(_loseClip);
            //GameManager.Instance.CurrentScore = (int)score;
            // StartCoroutine(GameOver());
            _gameOverPanel.SetActive(true);
        }

        /*private IEnumerator GameOver()
        {
            yield return new WaitForSeconds(2f);
            GameManager.Instance.GoToMainMenu();
        }*/

        #endregion
    }
}
