using UnityEngine;
using UnityEngine.UI;

public class PlusOneFading : MonoBehaviour
{
	public Text text; // Reference to the UI Text component
    public Color startColor; // Initial color of the text
    public Color endColor; // Final color to fade to
    public float duration = 2.0f; // Duration of the fading effect
	private Vector3 startPos;
    private float timer = 0.0f;
	private bool restartFade; // To stop the effect and restart it
	public GameObject panel;
	public string foodsprite;
	public int foodCount;
	public int offsetx;
	public TamapreggochiManager tamapreggochiManager;
	public int price;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text = GetComponent<Text>();
        text.color = startColor;
		startPos = transform.position;
    }
	public void OnClickConsignButton()
	{
		if(panel.transform.childCount > 0)
		{
			tamapreggochiManager.coins+=5;
			Destroy(panel.transform.GetChild(panel.transform.childCount-1).gameObject);
		}
	}
	public void OnClickFoodButton()
	{
		if(foodCount >= 25)return;
		if(tamapreggochiManager.coins<1)return;
		//instantiate img of sprite
		RectTransform spriteFood = Instantiate(Resources.Load<RectTransform>(foodsprite));
		spriteFood.transform.SetParent(panel.transform);
		spriteFood.anchoredPosition = Vector3.zero+(new Vector3(1+offsetx,0,0)*foodCount);
		spriteFood.localScale = Vector3.one;
		foodCount++;
		restartFade = false;
		tamapreggochiManager.WeightIncreasedOnClick(price);
	}
	
    // Update is called once per frame
    void Update()
    {
		if(restartFade)
		{
			transform.position = startPos;
			return;
		}
       transform.Translate(Vector3.up * 1f * Time.deltaTime);
	   timer += Time.deltaTime;
        text.color = Color.Lerp(startColor, endColor, timer / duration);

        if (timer >= duration)
        {
			restartFade = true;
            timer = 0.0f; // Reset the timer for continuous fading
        }
    }
}
