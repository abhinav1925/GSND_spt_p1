using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ITrigger : MonoBehaviour
{
    public bool TriggerOnce;
    public UnityEvent OnPlayerEnterEvt;

    protected bool HasTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("PlayerEnter");
            OnPlayerEnter();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("PlayerLeave");
            OnPlayerLeave();
        }
    }

    protected virtual void OnPlayerEnter()
    {
        if(TriggerOnce && HasTrigger)
        {
            return;
        }

        OnPlayerEnterEvt?.Invoke();
        HasTrigger = true;

        Debug.Log("Player Trigger");
    }

    protected virtual void OnPlayerLeave()
    {

    }
}
