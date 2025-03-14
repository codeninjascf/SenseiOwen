using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class RollManager : MonoBehaviour
{
    public Collection collection;
    private static RollManager instance;
    public GameObject MoneyPopUpPrefab;
    public int StartMoney;
    private static int money;
    public int weightCommon;
    public Dino[] Common;
    public int weightRare;
    public Dino[] Rare;
    public int weightEpic;
    public Dino[] Epic;
    public int weightLegendary;
    public Dino[] Legendary;
   
    public TMP_Text TotalText;
    public TMP_Text CommonText;
    public TMP_Text RareText;
    public TMP_Text EpicText;
    public TMP_Text LegendaryText;
    public TMP_Text DinoNameText;
    public TMP_Text moneyText;
    public static TMP_Text MoneyText;


    private float TotalRolls;
   private float CommonTotal;
   private float RareTotal;
   private float EpicTotal;
   private float LegendaryTotal;

   
   private bool isRolling = false;

    public static int Money { get => money; set
        {
            instance.CreateMoneyPopUp(value - money);
            money = value;
            MoneyText.text = "Money: " + Money.ToString();
            
        } 
    }

    public void CreateMoneyPopUp(int value)
    {   
        Instantiate(MoneyPopUpPrefab,transform.parent).GetComponent<MoneyPopUp>().Money = value;
    }
    private void Start()
   {
        instance = this;
        MoneyText = moneyText;
        Money = StartMoney;
        TotalRolls = 0;
   }
   
   private void Roll()
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

    private void GetRandomSpriteFromPool(Dino[] pool)
   {
        Dino randomDino = pool[(int)Mathf.Floor(Random.Range(0,pool.Length))];
        GetComponent<Image>().sprite = randomDino.image;
        DinoNameText.text = randomDino.name;
        collection.AddDino(randomDino);
        TotalText.text = "Total Rolls: " + TotalRolls.ToString();
        CommonText.text = "Common: " + CommonTotal.ToString() +" (" + GetPercentage(CommonTotal)+"%)";
        RareText.text = "Rare: " +RareTotal.ToString() + " (" +GetPercentage(RareTotal)+"%)";
        EpicText.text = "Epic: " + EpicTotal.ToString() +" (" +GetPercentage(EpicTotal)+"%)";
        LegendaryText.text = "Legendary: " +LegendaryTotal.ToString() +" (" + GetPercentage(LegendaryTotal)+"%)";
   }

   private string GetPercentage(float rolls){
    return (Mathf.Round(rolls/TotalRolls * 10000)/100).ToString();
   }

   public void Work(Button button)
   {
       StartCoroutine(waitForWork(button));
   }
    public void rollSingle(){
        if (Money < 10 || isRolling) return;
        Money-=10;
        Roll();
    }

   public void RollMultiButton(){
     if (isRolling) return;
         StartCoroutine(RollMultiple());
   }

    IEnumerator RollMultiple()
   {
        isRolling = true;
        while (Money >= 10)
        {
            Money -= 10;
            Roll();
            yield return new WaitForSeconds(0.1f);
        }
        isRolling = false;
    }

   IEnumerator waitForWork(Button button)
   {
        button.interactable = false;
        yield return new WaitForSeconds(2f);
        button.interactable = true;
        Money+=10;
        MoneyText.text = "Money: " + Money.ToString();
   }
}
