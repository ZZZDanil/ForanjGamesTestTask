using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBankController
{
    public IBankModel bankModel { get; set; }
    public void CreateBank(List<ICardModel> bankCards);
    public void DecreaseBankSize()
    {
        bankModel.bankCount--;
    }
    public int GetBankSize()
    {
        return bankModel.bankCount;
    }
}
