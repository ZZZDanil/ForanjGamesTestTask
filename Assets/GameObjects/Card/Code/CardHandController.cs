using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardHandController : MonoBehaviour, ICardController
{
    public ICardModel cardModel { get; set; }

    private void Awake()
    {
        cardModel = new CardModel(GetComponent<CardView>(), this);
    }
    public void ChekGameResult()
    {
        throw new System.NotImplementedException();
    }
}

