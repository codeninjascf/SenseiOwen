using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collection : MonoBehaviour
{
    public GameObject collection;
    public GameObject rolls;
    public GameObject display;
    public GameObject content;

    private List<Display> allDisplays;

    public void sellAll()
    {
        foreach (Display display in allDisplays)
        {
            display.Sell();
        }
    }
    public struct DinoSlot 
    {
        public Dino dino;
        public int dinoAmount;
    }
    public List<DinoSlot> AllDinos = new List<DinoSlot>();
    void Start()
    {
        rolls.SetActive(true);
        collection.SetActive(false);
    }

    public void AddDino(Dino nDino)
    {
        for (int index = 0; index < AllDinos.Count; index++)
        {
            if (nDino.name != AllDinos[index].dino.name) continue;
            DinoSlot updatedSlot = AllDinos[index];
            updatedSlot.dinoAmount++;
            AllDinos[index] = updatedSlot;
            return;
        }
        AllDinos.Add(new DinoSlot() { dino = nDino, dinoAmount = 1 });
    }

    public void removeDino(Dino nDino)
    {
        for (int index = 0; index < AllDinos.Count; index++)
        {
            if (nDino.name != AllDinos[index].dino.name) continue;
            DinoSlot updatedSlot = AllDinos[index];
            updatedSlot.dinoAmount--;
            AllDinos[index] = updatedSlot;
            return;
        }
    }
    private float getWidth(int num) => num switch
    {
        0 => 0,
        1 => 260,
        2 => 520,
        _ => 0
    };

    public void DisplayCollection()
    {
        rolls.SetActive(false);
        collection.SetActive(true);
        allDisplays = new List<Display>();
        int col = 0;
        int row = 0;
          for (int index = 0; index < AllDinos.Count; index++)
        {
            DinoSlot dinoSlot = AllDinos[index];
            GameObject newDisplay = Instantiate(display,content.transform);
            Display script = newDisplay.GetComponent<Display>();
            allDisplays.Add(script);
            script.value = (int)dinoSlot.dino.sellValue;
            script.collection = this;
            script.name.text = dinoSlot.dino.name;
            script.amount.text = dinoSlot.dinoAmount.ToString();
            script.image.sprite = dinoSlot.dino.image;
            float width = getWidth(row) + 130;
            float height = col * - 190 -90;
             newDisplay.GetComponent<RectTransform>().anchoredPosition = new Vector3(width,height,0);
            if (row == 2)
            {
                row = 0;
                col++;
            }
            else
            {
                row++;
            }
        }
    }

    public void BackToRolls()
    {
        rolls.SetActive(true);
        collection.SetActive(false);
        foreach(Transform child in content.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
