
using DG.Tweening;
using UnityEngine;

[System.Serializable]
public class CardModel : ICardModel
{
    public ICardModel.SUIT suit { get; set; }
    public ICardModel.RANK rank { get; set; }
    public bool isOpened { get; set; }
    public ICardController top { get; set ; }
    public ICardController bottom { get; set ; }
    public ICardView cardView { get; set; }
    public ICardController cardController { get; set; }

    public CardModel(ICardView cardView, ICardController cardController)
    {
        this.cardView = cardView;
        this.cardController = cardController;
    }
    public void MoveToEnd(Vector3 position, ICardController hand, GameObject card)
    {
        InputState.isInputActive = false;
        card.transform.parent = card.transform.root;
        DOTween.Sequence()
        .Append(card.transform.DOMove(((CardHandController)hand).transform.position, 0.5f))
        .AppendCallback(() =>
        {
            ShowPreviousCard();
            hand.ChangeCardFace(this);
            cardController.ChekGameResult();
            GameObject.Destroy(card);
            InputState.isInputActive = true;
        });
    }
    private void ShowPreviousCard()
    {
        if (bottom != null)
        {
            bottom.SetVible(true);
            bottom.SetTop();
        }
    }
}
