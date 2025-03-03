using TMPro;
using UnityEngine;
using UnityEngine.Video;
using GameLevel.data;
using Vishwah.ScriptableEvents;

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

    private bool _isAnswerCorrect = true;
    private int _levelCount = -1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(_videoPlayer == null)
            _videoPlayer = GetComponent<VideoPlayer>();

        //_videoPlayer.clip = levelData[0];

    }

    // Update is called once per frame
    void Update()
    {
        if (_isAnswerCorrect)
        {
            //TO:DO need to do screen transitioning effect
            _levelCount++;

            if (/*levelData[_levelCount] != null &&*/ _levelCount <= levelData.Length)
            {
                getLevelDataToScreen(_levelCount);
                _videoPlayer.Play();
                _screenChangeEvent.Raise();
            }
            else
            {
                //show end screen and ask the user re-try again
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

    public void firstOptionTrigger()
    {
        Debug.Log("OPTION 1 TRIGGRED");

        _videoPlayer.clip = _option_1.videoToPlay;
        _videoPlayer.Play();
        if (_option_1.isAnswer)
        {
            _isAnswerCorrect = true;
            _optionText_1.text = "CORRECT !";
        }
        else
        {
            _optionText_1.text = "WRONG !";
        }
    }

    public void secondOptionTrigger()
    {
        Debug.Log("OPTION 2 TRIGGRED");

        _videoPlayer.clip = _option_2.videoToPlay;
        _videoPlayer.Play();
        if (_option_2.isAnswer)
        {
            _isAnswerCorrect = true;
            _optionText_2.text = "CORRECT !";
        }
        else
        {
            _optionText_2.text = "WRONG !";
        }
    }

}
