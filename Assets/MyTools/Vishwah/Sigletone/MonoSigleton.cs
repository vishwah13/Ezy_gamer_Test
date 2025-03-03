using UnityEngine;
public abstract class MonoSigleton<T> : MonoBehaviour where T : MonoSigleton<T>
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if(_instance == null)
                Debug.Log(typeof(T).ToString()+"is NULL.");

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this as T;
        
        Init();
    }

    public virtual void Init()
    {
        //use this for Awake
    }
}
