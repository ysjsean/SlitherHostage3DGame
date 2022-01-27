using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour
{
	void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("SnakeHead"))
		{
			other.GetComponent<SnakeMovement>().AddBody();
			Destroy(gameObject);
		}
	}
}
