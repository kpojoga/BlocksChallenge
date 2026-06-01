using System.Collections;
using TMPro;
using UnityEngine;

namespace Orbibt
{
    public class MainMenuManager : MonoBehaviour
    {

        private void Awake()
        {
            if (!GameManager.Instance.IsInitialized)
            {

            }
            else
            {
                StartCoroutine(ShowScore());
            }
        }

        [SerializeField] private float _animationTime;
        [SerializeField] private AnimationCurve _speedCurve;

        private IEnumerator ShowScore()
        {
            int tempScore = 0;
           
            int currentScore = GameManager.Instance.CurrentScore;
            int highScore = GameManager.Instance.HighScore;

            if (currentScore > highScore)
            {
                GameManager.Instance.HighScore = currentScore;
            }
            else
            {
                
            }

            float speed = 1 / _animationTime;
            float timeElapsed = 0f;
            while (timeElapsed < 1f)
            {
                timeElapsed += speed * Time.deltaTime;

                tempScore = (int)(_speedCurve.Evaluate(timeElapsed) * currentScore);
               

                yield return null;
            }

            tempScore = currentScore;
            
        }

        [SerializeField] private AudioSource _clickSound;

        public void ClickedPlay()
        {
            _clickSound.Play();
        }
    }
}
