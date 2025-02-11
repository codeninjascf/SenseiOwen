using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class RollManager : MonoBehaviour
{
    public int weightCommon;
    public Sprite[] Common;
    public int weightRare;
    public Sprite[] Rare;
    public int weightEpic;
    public Sprite[] Epic;
    public int weightLegendary;
    public Sprite[] Legendary;
   
    public TMP_Text TotalText;
    public TMP_Text CommonText;
    public TMP_Text RareText;
    public TMP_Text EpicText;
    public TMP_Text LegendaryText;


   private float TotalRolls;
   private float CommonTotal;
   private float RareTotal;
   private float EpicTotal;
   private float LegendaryTotal;
   public void Roll()
   {
    TotalRolls++;
    float TotalWeight = weightCommon + weightRare + weightEpic + weightLegendary;
    float randomNumber = Random.Range(0,TotalWeight);
    float addedWeight = weightCommon;
    if (randomNumber <= addedWeight){
        CommonTotal++;
        GetRandomSpriteFromPool(Common);
        return;
    }
    addedWeight+= weightRare;
    if (randomNumber <= addedWeight){
        RareTotal++;
        GetRandomSpriteFromPool(Rare);
        return;
    }
    addedWeight += weightEpic;
    if (randomNumber <= addedWeight){
        EpicTotal++;
        GetRandomSpriteFromPool(Epic);
        return;
    }
    LegendaryTotal++;
    GetRandomSpriteFromPool(Legendary);
   }

    private void GetRandomSpriteFromPool(Sprite[] pool)
   {
        GetComponent<Image>().sprite = pool[Random.Range(0,pool.Length-1)];
        TotalText.text = "Total Rolls: " + TotalRolls.ToString();
        CommonText.text = "Common: " + CommonTotal.ToString() +" (" + GetPercentage(CommonTotal)+"%)";
        RareText.text = "Rare: " +RareTotal.ToString() + " (" +GetPercentage(RareTotal)+"%)";
        EpicText.text = "Epic: " + EpicTotal.ToString() +" (" +GetPercentage(EpicTotal)+"%)";
        LegendaryText.text = "Legendary: " +LegendaryTotal.ToString() +" (" + GetPercentage(LegendaryTotal)+"%)";
   }

   private string GetPercentage(float rolls){
    return (Mathf.Round(rolls/TotalRolls * 10000)/100).ToString();
   }

   void Update(){
    //Roll();
   }
}
