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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text = GetComponent<Text>();
        text.color = startColor;
		startPos = transform.position;
    }
	public void OnClickFoodButton()
	{
		//instantiate img of sprite
		RectTransform spriteFood = Instantiate(Resources.Load<RectTransform>(foodsprite));
		spriteFood.transform.SetParent(panel.transform);
		spriteFood.anchoredPosition = new Vector3(-25,0,0)+(new Vector3(1+offsetx,0,0)*foodCount);
		spriteFood.localScale = Vector3.one;
		foodCount++;
		restartFade = false;
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
