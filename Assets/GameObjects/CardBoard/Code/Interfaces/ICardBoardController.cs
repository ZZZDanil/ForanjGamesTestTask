using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICardBoardController
{
    public ICardBoardModel cardBoardModel { get; set; }
    public ICardBoardModel.GeneratorOut StartGenerator();
    public void StartMoveToEnd(ICardController cardController);
    public int GetCardsCount();
    public bool CheckOnAvailableMove(ICardController cardController);
    public void ChekGameResult();


}
