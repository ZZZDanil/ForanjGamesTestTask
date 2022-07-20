using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface ICardBoardModel
{
    public struct GeneratorOut
    {
        public List<ICardController> topCardsFromBundles;
        public List<ICardModel> bankCards;
        public ICardModel handCard;
    }

    public GeneratorOut Generator(ICardController[] emptyCards);
}
