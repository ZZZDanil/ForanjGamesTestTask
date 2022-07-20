using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonControllerPlayGame : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        //Debug.Log("ButtonControllerPlayGame");
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
