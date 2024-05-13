using UnityEngine;

public class ClickerWeight : MonoBehaviour
{
	public float foodKind;
	private TamapreggochiManager tamapreggochiManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tamapreggochiManager = transform.root.transform.GetComponent<TamapreggochiManager>();
        tamapreggochiManager.WeightIncreasedOverTime(foodKind);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
