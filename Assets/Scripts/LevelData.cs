using UnityEngine;
using UnityEngine.Video;

namespace GameLevel.data
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "Scriptable Objects/LevelData")]

    public class LevelData : ScriptableObject
    {
        [System.Serializable]
        public struct option { public string optionText; public VideoClip videoToPlay; public bool isAnswer; }

        [SerializeField]
        private VideoClip _questionVideoClip;

        [SerializeField]
        private option _Option_1;
        [SerializeField]
        private option _Option_2;

        public VideoClip GetQuestionVideoClip() {  return _questionVideoClip; }

        public option GetFirstOption() { return _Option_1; }
        public option GetSecondOption() { return _Option_2; }
    }
}


