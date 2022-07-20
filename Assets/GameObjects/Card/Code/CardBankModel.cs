using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBankModel : ICardModel
{
    public ICardModel.SUIT suit { get; set; }
    public ICardModel.RANK rank { get; set; }
    public bool isOpened { get; set; }
    public ICardController top { get; set; }
    public ICardController bottom { get; set; }
    public ICardView cardView { get; set; }
    public ICardController cardController { get; set; }

    public CardBankModel(ICardView cardView, ICardController cardController)
    {
        this.cardView = cardView;
        this.cardController = cardController;
    }
    public void MoveToEnd(Vector3 position, ICardController hand, GameObject cardBank)
    {
        InputState.isInputActive = false; 
        cardBank.transform.parent = cardBank.transform.root;
        DOTween.Sequence()
        .Append(cardBank.transform.DOMove(((CardHandController)hand).transform.position, 0.25f))
        .AppendCallback(() =>
        {
            hand.ChangeCardFace(this);
            cardController.ChekGameResult();
            InputState.isInputActive = true;
            GameObject.Destroy(cardBank);
        });

        
    }

}