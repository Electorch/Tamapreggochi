using UnityEngine;
using UnityEngine.UI;

public class TamapreggochiManager : MonoBehaviour
{
	[Tooltip("Mouseover")]
	public string Notes = "This script manages all hypothetical preggochis";
	public float weight,coins;
	public int weightTxt;
	public Text gText,cText;
	private string textg;
	private bool weightOverTime;
	private float foodStocked;
	public Sprite[] bbSprites;
	public Image bbImage;
	public Button[] foodBtns;
	public PlusOneFading[] prices;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
	public void WeightIncreasedOnClick(int price)
	{
		if(coins>=price)
		{
			coins-=price;
			weight++;
		}
	}
	public void WeightIncreasedOverTime(float foodKind)//if we wanna change the way it increase over time
	{
		foodStocked+=foodKind;
		weightOverTime = true;
	}
    // Update is called once per frame
    void Update()
    {
		
			for(int i=0;i<foodBtns.Length;i++)
			{
				if(coins < prices[i].price)
					foodBtns[i].interactable = false;
				else
				{
					foodBtns[i].interactable = true;
				}
			}
		
		cText.text = coins.ToString()+" ¢";
		weightTxt = (int)weight;
		textg = weightTxt.ToString()+" g";
        gText.text = textg;
		if(weight > 100 && weight < 400)
		{
			bbImage.sprite = bbSprites[1];
		}
		if(weight > 400)
		{
			bbImage.sprite = bbSprites[2];
		}
		if(weightOverTime)
			weight+=Mathf.RoundToInt(foodStocked)*Time.deltaTime*0.1f;
    }
}
