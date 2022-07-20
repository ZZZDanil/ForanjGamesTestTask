using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class CardView : MonoBehaviour, ICardView
{
    public CardImagesDB cardImagesDB;
    private Image view;

    private void Awake()
    {
        view = GetComponent<Image>();
    }

    void OnDrawGizmos()
    {
        if (view == null)
        {
            view = GetComponent<Image>();
            view.sprite = cardImagesDB.back;
        }
    }

    public void UpdateView(ICardModel cardModel)
    {
        view.sprite = GetCardImage(cardModel.suit, cardModel.rank, cardModel.isOpened);
    }
    private Sprite GetCardImage(ICardModel.SUIT suit, ICardModel.RANK rank, bool isOpened)
    {
        if (isOpened) {
            switch (suit)
            {
                case ICardModel.SUIT.CLUB:
                    return cardImagesDB.clubs[(int)rank];

                case ICardModel.SUIT.DIAMOND:
                    return cardImagesDB.diamonds[(int)rank];

                case ICardModel.SUIT.HEART:
                    return cardImagesDB.hearts[(int)rank];

                default:
                    return cardImagesDB.spades[(int)rank];

            }
        }
        else
        {
            return cardImagesDB.back;
        }
    }
}
