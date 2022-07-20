using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[System.Serializable]
public class CardController : MonoBehaviour, ICardController, IPointerClickHandler
{
    public ICardModel cardModel { get; set; }

    private ICardBoardController board;

    private void Awake()
    {
        cardModel = new CardModel(GetComponent<CardView>(), this);
        board = (ICardBoardController)GetComponentInParent(typeof(ICardBoardController));
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (InputState.isInputActive)
            if (cardModel.isOpened == true)
                StartMoveToEnd();
    }

    public RectTransform GetRectTransform()
    {
        return GetComponent<RectTransform>();
    }
    private void StartMoveToEnd()
    {
        board.StartMoveToEnd(this);
    }
/*    public void MoveTo(Vector3 end, ICardController hand)
    {
        gameObject.transform.parent = transform.root;
        cardModel.MoveToEnd(end, hand, gameObject);
    }*/
    public void InitRelations(ICardController bottom, ICardController top)
    {
        cardModel.InitRelations(bottom, top);
    }
    public void ChekGameResult()
    {
        board.ChekGameResult();
    }
}
