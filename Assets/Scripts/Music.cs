using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    

    private string _isMusicOn;
    private string _isSoundOn;

    [SerializeField] private GameObject _checkmark;
    [SerializeField] private AudioSource _fromMenu;


    [SerializeField] private GameObject _checkmarkSound;

    [SerializeField] private GameObject _sounds;
    [SerializeField] private GameObject _soundsFromBlock;
    


    private void Awake()
    {
        //MUSIC

        DontDestroyOnLoad(gameObject);
        _isMusicOn = PlayerPrefs.GetString("isMusicOn", _isMusicOn);
        if (_isMusicOn == "yes")
        {
            _checkmark.SetActive(true);
            _fromMenu.Play();
        }
        else
        {
            _checkmark.SetActive(false);
            _fromMenu.Stop();
        }

        //SOUND
        ////////////////////////////////////////////////////////////////

        DontDestroyOnLoad(gameObject);
        _isSoundOn = PlayerPrefs.GetString("isSoundOn", _isSoundOn);
        if (_isSoundOn == "yes")
        {
            _checkmarkSound.SetActive(true);
            _sounds.SetActive(true);
            _soundsFromBlock.SetActive(true);
        }
        else
        {
            _checkmarkSound.SetActive(false);
            _sounds.SetActive(false);
            _soundsFromBlock.SetActive(false);
        }

    }

    

    public void MuteMusic()
    {
        
        if (_checkmark.activeSelf == true)
        {
            _checkmark.SetActive(false);
            _isMusicOn = "no";
            PlayerPrefs.SetString("isMusicOn", "no");
            _fromMenu.Stop();
        }
        else if (_checkmark.activeSelf == false)
        {
            _checkmark.SetActive(true);
            _isMusicOn = "yes";
            PlayerPrefs.SetString("isMusicOn", "yes");
            _fromMenu.Play();
        }
    }


    public void MuteSound()
    {
        if (_checkmarkSound.activeSelf == true)
        {
            _checkmarkSound.SetActive(false);
            _isSoundOn = "no";
            PlayerPrefs.SetString("isSoundOn", "no");
            _soundsFromBlock.SetActive(false);
            _sounds.SetActive(false);
        }
        else if (_checkmarkSound.activeSelf == false)
        {
            _checkmarkSound.SetActive(true);
            _isSoundOn = "yes";
            PlayerPrefs.SetString("isSoundOn", "yes");
            _sounds.SetActive(true);
            _soundsFromBlock.SetActive(true);
        }
    }


}
