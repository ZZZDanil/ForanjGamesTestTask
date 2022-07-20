using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBankModel
{
    public int bankCount { get; set; }
    public void InitRectTransform(RectTransform bankTransform);
    public void InitCard(GameObject cardPrefab);
    public void InitBank(List<ICardModel> newBankCards);
}

