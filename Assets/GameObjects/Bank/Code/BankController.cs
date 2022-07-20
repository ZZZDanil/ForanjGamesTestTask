using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankController : MonoBehaviour, IBankController
{
    public GameObject cardPrefab;
    public IBankModel bankModel { get; set; }

    private void Awake()
    {
        bankModel = new BankModel();
    }

    public void CreateBank(List<ICardModel> bankCards)
    {
        bankModel.InitRectTransform(GetComponent<RectTransform>());
        bankModel.InitCard(cardPrefab);
        bankModel.InitBank(bankCards);
    }
}
