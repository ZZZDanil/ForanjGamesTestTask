using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface ICardModel
{

    public enum SUIT { CLUB, DIAMOND, HEART, SPADE }
    public enum RANK { TWO, THREE, FOUR, FIVE, SIX, SEVEN, EIGHT, NINE, TEN, JACK, QUEEN, KING, ACE }

    public struct Card
    {
        public SUIT suit;
        public RANK rank;
        public bool isOpened;
    };

    public SUIT suit { get; set; }
    public RANK rank { get; set; }
    public bool isOpened { get; set; }
    public ICardController top { get; set; }
    public ICardController bottom { get; set; }
    public ICardView cardView { get; set; }
    public ICardController cardController { get; set; }

    public void InitRelations(ICardController bottom, ICardController top)
    {
        this.bottom = bottom;
        this.top = top;
    }
    public void ChangeCard(SUIT suit, RANK rank, bool isOpened)
    {
        this.suit = suit;
        this.rank = rank;
        this.isOpened = isOpened;
        cardView.UpdateView(this);
    }
    public void ChangeCardFace(SUIT suit, RANK rank)
    {
        this.suit = suit;
        this.rank = rank;
        cardView.UpdateView(this);
    }
    public void SetVible(bool isOpened)
    {
        this.isOpened = isOpened;
        // TODO animation
        cardView.UpdateView(this);
    }
    public void MoveToEnd(Vector3 position, ICardController hand, GameObject cardBank);
 
    public bool IsNearestCard(ICardModel anotherCardModel)
    {
        //return true;
        int availability = (int)rank - (int)(anotherCardModel.rank);
        //Debug.Log($"IsNearestCard rank = {rank} anotherCardModel = {anotherCardModel.rank} length = {availability}");
        if (availability == 1 || availability == -1 || availability == 12 || availability == -12
            && !(((int)rank) == 0 && ((int)(anotherCardModel.rank) == 0)))
            return true;
        else
            return false;
    }
    public bool IsTop()
    {
        if (top == null)
            return true;
        else
            return false;
    }
    public void SetTop()
    {
        top = null;
    }
}
