using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyPopUp : MonoBehaviour
{
    public int Money;
    private RectTransform rectTransform;
    private float lifeTime = 2f;
    private float speed;
    private TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        text = GetComponent<TMP_Text>();
        speed = Random.Range(10, 30);
        text.text = (Money > 0? "+":"") + Money.ToString();
        text.color = Money > 0? Color.green : Color.red;
        text.fontSize = Mathf.Clamp(20,Money/2, 70);
        rectTransform.anchoredPosition = new Vector2(Random.Range(241,372),Random.Range(-215,-200));
    }

    // Update is called once per frame
    void Update()
    {
        rectTransform.anchoredPosition += new Vector2(0,lifeTime * speed) * Time.deltaTime;
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
        text.color = new Color(text.color.r, text.color.g, text.color.b, lifeTime * 2f);
    }
}
