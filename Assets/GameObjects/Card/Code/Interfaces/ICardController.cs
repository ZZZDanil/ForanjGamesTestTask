using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICardController
{
    public ICardModel cardModel { set; get; }
    public RectTransform GetRectTransform() 
    {
        return null;    
    }
    public void InitRelations(ICardController bottom, ICardController top)
    {
        cardModel.InitRelations(bottom, top);
    }
    public void ChangeCard(ICardModel model)
    {
        cardModel.ChangeCard(model.suit, model.rank, model.isOpened);
    }
    public void ChangeCardFace(ICardModel model)
    {
        cardModel.ChangeCardFace(model.suit, model.rank);
    }
    public void SetVible(bool visible)
    {
        cardModel.SetVible(visible);
    }

    public void MoveTo(Vector3 end, ICardController hand, GameObject card)
    {
        cardModel.MoveToEnd(end, hand, card);
    }
    public bool CheckCardSequence(ICardController hand)
    {
        return cardModel.IsNearestCard(hand.cardModel);
    }
    public bool IsAvailableToMove(ICardController toCheck)
    {
        return cardModel.IsNearestCard(toCheck.cardModel);
    }

    public bool IsTop()
    {
        return cardModel.IsTop();
    }
    public void SetTop()
    {
        cardModel.SetTop();
    }
    public ICardController GetBottomCard()
    {
        return cardModel.bottom;
    }
    public void ChekGameResult();
}
