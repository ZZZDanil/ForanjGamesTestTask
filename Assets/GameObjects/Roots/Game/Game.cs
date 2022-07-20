using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public ICardBoardController cardBoard;
    public ICardController handController;
    public IBankController bankController;

    public GameObject pauseUI;

    private Vector3 handPosition;

    private void Awake()
    {
        cardBoard = (ICardBoardController)GetComponentInChildren(typeof(CardBoardController));
        handController = (ICardController)GetComponentInChildren(typeof(CardHandController));
        bankController = (IBankController)GetComponentInChildren(typeof(BankController));
        handPosition = ((CardHandController)handController).gameObject.transform.position;
        //Debug.Log($"<Game>- handPosition = {handPosition}");
    }
    private void Start()
    {
        //Debug.Log("awake game");
        ICardBoardModel.GeneratorOut generatorOut = cardBoard.StartGenerator();
        for (int i = 0; i < generatorOut.topCardsFromBundles.Count; i++)
        {
            generatorOut.topCardsFromBundles[i].SetVible(true);
        }
        bankController.CreateBank(generatorOut.bankCards);
        handController.ChangeCard(generatorOut.handCard);
    }

    public void StartFieldCardMove(ICardController movable)
    {
        if (movable.CheckCardSequence(handController) == true)
        {
            movable.MoveTo(handPosition, handController, ((MonoBehaviour)movable).gameObject);
            //ChekGameResult();
        }
    }
    public void StartBankCardMove(ICardController movable)
    {
        movable.MoveTo(handPosition, handController, ((MonoBehaviour)movable).gameObject);
        bankController.DecreaseBankSize();
        //ChekGameResult();
    }

    public void ChekGameResult()
    {
        if (cardBoard.GetCardsCount() < 1)
        {
            ShowResult(true); // win
            return;
        }
        if (bankController.GetBankSize() < 1)
        {
            if (cardBoard.CheckOnAvailableMove(handController) == false)
            {
                ShowResult(false); // loss
                                   //Debug.Log("ChekGameResult status: loss");
            }
        }
      /*  Debug.Log($"ChekGameResult status: GetCardsCount: {cardBoard.GetCardsCount()} " +
            $"GetBankSize: {bankController.GetBankSize()} CheckOnAvailableMove: {cardBoard.CheckOnAvailableMove(handController)}");
*/
    }
    private void ShowResult(bool status) // true = win| false = loss
    {
        pauseUI.SetActive(true);
        pauseUI.GetComponentInChildren<Text>().text = status ? "Win" : "Loss";
    }
}
