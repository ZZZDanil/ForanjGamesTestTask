using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankModel : IBankModel
{
    public int bankCount { get; set; }
    public RectTransform bankTransform;
    public GameObject cardPrefab;

    public void InitRectTransform(RectTransform bankTransform)
    {
        this.bankTransform = bankTransform;
    }
    public void InitCard(GameObject cardPrefab)
    {
        this.cardPrefab = cardPrefab;
    }
    public void InitBank(List<ICardModel> newBankCards)
    {
        bankCount = newBankCards.Count;
        float bankWidth = bankTransform.rect.width;
        float cardWidth = cardPrefab.GetComponent<RectTransform>().rect.width;
        float halfCardWidth = cardWidth / 2;
        float step = (bankWidth - halfCardWidth) / bankCount;

        for (int i = bankCount-1; i >= 0; i--) {
            GameObject newBankCard = GameObject.Instantiate(cardPrefab, new Vector3(-halfCardWidth - i * step + bankTransform.rect.x + bankTransform.rect.width, 0, 0) + bankTransform.transform.position
                , Quaternion.identity, bankTransform);
            ICardController cardController = (ICardController)newBankCard.GetComponent(typeof(ICardController));
            cardController.ChangeCard(newBankCards[i]);
        }
    }
}
