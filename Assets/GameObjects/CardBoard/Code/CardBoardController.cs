using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBoardController : MonoBehaviour, ICardBoardController
{
    public ICardBoardModel cardBoardModel { get; set; }

    private Game game;

    private void Awake()
    {
        cardBoardModel = new CardBoardModel();
        game = GetComponentInParent<Game>();

    }

    public ICardBoardModel.GeneratorOut StartGenerator()
    {
        ICardController[] cardControllers = GetComponentsInChildren<ICardController>();
        int i = 0;
        foreach(ICardController cardController in cardControllers)
        {
            CardController c = (CardController)cardController;
            GameObject g = c.gameObject;
            if(g != null)
            i++;
        }
        return cardBoardModel.Generator(cardControllers);
    }

    public void StartMoveToEnd(ICardController cardController)
    {
        game.StartFieldCardMove(cardController);
    }

    public int GetCardsCount()
    {
        return (GetComponentsInChildren<CardController>().Length);
    }

    public bool CheckOnAvailableMove(ICardController cardController)
    {

        ICardController[] cardControllers = GetComponentsInChildren<ICardController>();
        for (int i= 0; i < cardControllers.Length; i++)
        {
            ICardController card = cardControllers[i];
            if (card.IsTop())
                if (card.IsAvailableToMove(cardController) == true)
                    return true;
        }
        return false;
    }
    public void ChekGameResult()
    {
        game.ChekGameResult();
    }
}
