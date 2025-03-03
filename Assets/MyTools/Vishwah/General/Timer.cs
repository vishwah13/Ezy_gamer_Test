using System.Collections;
using UnityEngine;
using Vishwah.Interfaces;

namespace Vishwah.General
{
    public class Timer : MonoBehaviour
{
    [SerializeField] float waitTime = 1f;
    private float elapsedTime;
    [SerializeField] private bool loop;
    
    private MonoBehaviour[] monoBehaviours;

    private void Start()
    {
        monoBehaviours = gameObject.GetComponents<MonoBehaviour>();
        
        StartCoroutine(TimeCoroutine());
    }

    void CheckExecutableActions()
    {
        foreach (MonoBehaviour monoBehaviour in monoBehaviours)
        {
            if (monoBehaviour is IExecutableAction)
            {
                IExecutableAction actionableObject = (IExecutableAction)monoBehaviour;
                actionableObject.ExecuteAction();
            }
        }
    }

    IEnumerator TimeCoroutine()
    {   
         elapsedTime = 0f;

        while(elapsedTime <= waitTime)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        CheckExecutableActions();
        if (loop)
        {
            StartCoroutine(TimeCoroutine());
        }
          

    }
}

}

