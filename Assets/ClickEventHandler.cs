using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClickEventHandler : MonoBehaviour
{
    [SerializeField]
    UnityEvent onClick, onMouseEnter, onMouseExit;
    private void OnMouseUpAsButton()
    {
        onClick.Invoke();
    }
    private void OnMouseEnter()
    {
        onMouseEnter.Invoke();
    }
    private void OnMouseExit()
    {
        onMouseExit.Invoke();
    }
}
