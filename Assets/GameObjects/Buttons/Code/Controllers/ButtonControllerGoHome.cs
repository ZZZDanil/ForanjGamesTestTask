using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonControllerGoHome : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("ButtonControllerGoHome");
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}

