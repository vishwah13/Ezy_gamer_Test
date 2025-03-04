using TMPro;
using UnityEngine;
using UnityEngine.Video;
using GameLevel.data;
using Vishwah.ScriptableEvents;
using System.Collections;
using System;

[RequireComponent(typeof(VideoPlayer))]
public class LevelManager : MonoBehaviour
{
    private VideoPlayer _videoPlayer;

    [SerializeField]
    private TextMeshProUGUI _optionText_1;
    [SerializeField]
    private TextMeshProUGUI _optionText_2;
    [SerializeField]
    private GameEvent _screenChangeEvent;

    [SerializeField]
    private LevelData[] levelData;

    private LevelData.option _option_1;
    private LevelData.option _option_2;

    public event Action FirstOptionEvent;
    public event Action SecondOptionEvent;

    private bool _isAnswerCorrect = true;
    private int _levelCount = -1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(_videoPlayer == null)
            _videoPlayer = GetComponent<VideoPlayer>();

        FirstOptionEvent += pressedOption1;
        SecondOptionEvent += pressedoption2;

    }

    // Update is called once per frame
    void Update()
    {
        if (_isAnswerCorrect)
        {
            _levelCount++;

            if (_levelCount <= levelData.Length)
            {
                getLevelDataToScreen(_levelCount);
                _videoPlayer.Play();
                _screenChangeEvent.Raise();
            }
            
            _isAnswerCorrect = false;
        }
    }

    void getLevelDataToScreen(int levelCount)
    {
        _videoPlayer.clip = levelData[levelCount].GetQuestionVideoClip();
        _option_1 = levelData[levelCount].GetFirstOption();
        _option_2 = levelData[levelCount].GetSecondOption();
        _optionText_1.text = _option_1.optionText;
        _optionText_2.text = _option_2.optionText;
    }

    void pressedOption1()
    {
        Debug.Log("OPTION 1 TRIGGRED");

        _videoPlayer.clip = _option_1.videoToPlay;
        _videoPlayer.Play();
        if (_option_1.isAnswer)
        {
            //_isAnswerCorrect = true;
            StartCoroutine(waitForVideo());
            _optionText_1.text = "CORRECT !";
        }
        else
        {
            _optionText_1.text = "WRONG !";
        }
    }

    void pressedoption2()
    {
        Debug.Log("OPTION 2 TRIGGRED");

        _videoPlayer.clip = _option_2.videoToPlay;
        _videoPlayer.Play();
        if (_option_2.isAnswer)
        {
            //_isAnswerCorrect = true;
            StartCoroutine(waitForVideo());
            _optionText_2.text = "CORRECT !";
        }
        else
        {
            _optionText_2.text = "WRONG !";
        }
    }

    public void firstOptionTrigger()
    {
        FirstOptionEvent?.Invoke();
    }

    public void secondOptionTrigger()
    {
        SecondOptionEvent?.Invoke();
    }

    IEnumerator waitForVideo()
    {
        yield return new WaitForSeconds(5.0f);
        _isAnswerCorrect = true;
    }

}
