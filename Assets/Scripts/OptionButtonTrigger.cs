using UnityEngine;
using UnityEngine.UI;
using Vishwah.ScriptableEvents;

public class OptionButtonTrigger : MonoBehaviour
{
   [SerializeField]
   private GameEvent _gameEvent;

    [SerializeField]
    private Button _button;

    public void ButtonPressed()
    {
        _gameEvent.Raise();
        _button.interactable = false;
    }

    public void ScreenChanged()
    {
        _button.interactable = true;
    }
}
