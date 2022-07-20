using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardBankController : MonoBehaviour, ICardController, IPointerClickHandler
{
    public ICardModel cardModel { get; set; }
    private Game game;

    private void Awake()
    {
        cardModel = new CardBankModel(GetComponent<CardView>(), this);

        game = GetComponentInParent<Game>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (InputState.isInputActive)
            StartMoveToEnd();
    }
    private void StartMoveToEnd()
    {
        game = GetComponentInParent<Game>();
        game.StartBankCardMove(this);
    }

    public void ChekGameResult()
    {
        game.ChekGameResult();
    }
}
