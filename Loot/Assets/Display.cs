using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Display : MonoBehaviour
{
   public Collection collection;
   public Image image;
   public TMP_Text amount;
   public int value;
   public new TMP_Text name;
   public Button button;

   public void Sell()
   {
     StartCoroutine(sellAll());
     button.interactable = false;
   }

   IEnumerator sellAll()
   {
      var dino = collection.AllDinos.Find(x => x.dino.name == name.text);
      float time = 0.5f;
      while (dino.dinoAmount > 0)
      {
         collection.removeDino(dino.dino);
         RollManager.Money += (int)(value * Random.Range(0.5f, 1.2f));
         dino = collection.AllDinos.Find(x => x.dino.name == name.text);
         amount.text = dino.dinoAmount.ToString();
         float delay = Mathf.Max(0.1f, time);
         time -= 0.05f;
         yield return new WaitForSeconds(delay);
      }
   }
}
