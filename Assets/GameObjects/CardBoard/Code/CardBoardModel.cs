using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBoardModel : ICardBoardModel
{
    public ICardBoardModel.GeneratorOut Generator(ICardController[] allEmptyCards)
    {
        ICardBoardModel.GeneratorOut generatorOut = new ICardBoardModel.GeneratorOut { };

        generatorOut.topCardsFromBundles = CardRelationsGenerator(allEmptyCards);
        generatorOut.bankCards = CardsBundlesGenerator(generatorOut.topCardsFromBundles, allEmptyCards.Length);
        generatorOut.handCard = generatorOut.bankCards[0];
        generatorOut.handCard.isOpened = true;
        generatorOut.bankCards.RemoveAt(0);

        return generatorOut;
    }
    
    private List<ICardController> CardRelationsGenerator(ICardController[] cardControllers)
    {
        List<ICardController> topCardsFromBundles = new List<ICardController>();
        bool isCurrentCardIsFirst = true;
        float cardWidth = cardControllers[0].GetRectTransform().rect.width;
        for (int i = 0; i < cardControllers.Length - 1; i++)
        {
            if (isCurrentCardIsFirst == true)
            {
                cardControllers[i].InitRelations(null, cardControllers[i + 1]);
                isCurrentCardIsFirst = false;
            }
            else
            {
                if (DistanceBetweenCards(cardControllers[i], cardControllers[i + 1]) > cardWidth)
                {
                    cardControllers[i].InitRelations(cardControllers[i - 1], null);
                    isCurrentCardIsFirst = true;
                    topCardsFromBundles.Add(cardControllers[i]);
                }
                else
                {
                    cardControllers[i].InitRelations(cardControllers[i - 1], cardControllers[i + 1]);
                }
            }
        }

        cardControllers[cardControllers.Length - 1].InitRelations(cardControllers[cardControllers.Length - 2], null);
        topCardsFromBundles.Add(cardControllers[cardControllers.Length - 1]);
        return topCardsFromBundles;
    }

    private List<ICardModel> CardsBundlesGenerator(List<ICardController> topCardsFromBundles, int cardCount)
    {
        List<ICardController> topCardsFromBundlesC = new List<ICardController>(topCardsFromBundles);
        List<ICardModel> firstCardsFromBundles = new List<ICardModel>();
        int bundleLenght = 0;
        int newBundleCard = 0;
        int bundleRule = 1;                                         // [+1 == increasing || -1 == decreasing]
        int randomBundle = topCardsFromBundlesC.Count;              // GetRandomFullBundleIndex(topCardsFromBundlesC);
        
        for (; cardCount > 0;)
        { 
            if (cardCount > 8)
                bundleLenght = Random.Range(2, 8);
            else                                                    // becase (cardControllers.Count - bundleLenght) can be 1
            {
                if (cardCount < 4)
                    bundleLenght = cardCount + 1;                   // one will added to back
                else
                    bundleLenght = Random.Range(4, cardCount);
            }

            newBundleCard = Random.Range(0, 12);

            bundleLenght -= 1;
            firstCardsFromBundles.Add(CreateCard(newBundleCard, false));

            bundleRule = FindBundleRule();

            Debug.Log($"bundleSize = {bundleLenght}");
            for (; bundleLenght > 0;)
            {
                ChangeBindleRule(ref bundleRule);
                // for rundom
                //int randomBundle = GetRandomFullBundleIndex(topCardsFromBundlesC);
                randomBundle = MoveBundleIndex(topCardsFromBundlesC.Count, randomBundle);
                newBundleCard = ChangeCartRang(newBundleCard, bundleRule);
                topCardsFromBundlesC[randomBundle].ChangeCard(CreateCard(newBundleCard, false));
                ICardController bottomCard = topCardsFromBundlesC[randomBundle].GetBottomCard();
                //if (bottomCard != null)
                    topCardsFromBundlesC[randomBundle] = bottomCard;
                /*else
                    topCardsFromBundlesC.RemoveAt(randomBundle);*/

                bundleLenght--;
                cardCount--;
            }

        }
        return firstCardsFromBundles;
    }
    private int MoveBundleIndex(int topCardsFromBundlesCount, int startIndex)
    {
        int newIndex = startIndex + 1;
        if (newIndex > topCardsFromBundlesCount - 1)
            return 0;
        else
            return newIndex;
    }
    // for rundom
    private int GetRandomFullBundleIndex(List<ICardController> topCardsFromBundles)
    {
        List<int> bundles = new List<int>();
        for (int i = 0; i < topCardsFromBundles.Count; i++)
        {
            if (topCardsFromBundles[i] != null)
            {
                bundles.Add(i);
            }
        }
        if (bundles.Count > 0)
        {
            return bundles[Random.Range(0, bundles.Count)];
        }
        else
            return -1;
    }
    private int FindBundleRule()
    {
        if (Random.Range(0, 20) < 14)
            return 1;
        else
            return -1;
    }

    private void ChangeBindleRule(ref int bundleRule)
    {
        if (Random.Range(0, 20) < 4)
            bundleRule *= -1;
    }

    private int ChangeCartRang(int oldRang, int rule)
    {
        int newValue = oldRang + rule;

        if (newValue > 12)
            newValue = 0;
        else if (newValue < 0)
            newValue = 12;

        return newValue;
    }

    private ICardModel CreateCard(int intRank, bool isOpened)
    {
        return new CardModel(null, null) {
            suit = (ICardModel.SUIT)Random.Range(0, 3),
            rank = (ICardModel.RANK)intRank,
            isOpened = isOpened
        };
    }
    private float DistanceBetweenCards(ICardController from, ICardController to)
    {
        return Vector3.Distance(from.GetRectTransform().position, to.GetRectTransform().position);
    }

}
