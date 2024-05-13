using UnityEngine;
using UnityEngine.UI;

public class TamapreggochiManager : MonoBehaviour
{
	[Tooltip("Mouseover")]
	public string Notes = "This script manages all hypothetical preggochis";
	public float weight;
	public Text kgText;
	private string textKg;
	private bool weightOverTime;
	private float foodStocked;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
	public void WeightIncreasedOnClick()
	{
		weight++;
	}
	public void WeightIncreasedOverTime(float foodKind)//if we wanna change the way it increase over time
	{
		foodStocked+=foodKind;
		weightOverTime = true;
	}
    // Update is called once per frame
    void Update()
    {
		textKg = weight.ToString()+" Kg";
        kgText.text = textKg;
		
		if(weightOverTime)
			weight+=foodStocked*Time.deltaTime*0.1f;
    }
}
