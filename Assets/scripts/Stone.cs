using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour {

	public Route currentRoute;
	int routePosition;
	public int steps;
	bool isMoving;

	Animator anim;

	// public Animator m_animator;

	void Start()
	{
		anim = GetComponent<Animator>();
	}
	
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space) && !isMoving)
		{
			// Rodando el dado
			steps = Random.Range(1, 7);
			Debug.Log("Dado lanzado: " + steps);

			StartCoroutine(Move());

			// if(routePosition + steps < currentRoute.childNodeList.Count)
			// {
			// 	StartCoroutine(Move());
			// } else {
			// 	Debug.Log("El número obtenido en el dado es demasiado alto!");
			// }
		}
	}

	IEnumerator Move()
	{
		if (isMoving)
		{
			yield break;
		}
		isMoving = true;

		while(steps > 0)
		{

			routePosition++;
			routePosition %= currentRoute.childNodeList.Count;

			Vector3 nextPosition = currentRoute.childNodeList[routePosition].position;
			// m_animator.SetBool("Grounded", true);
			// anim.SetTrigger("walk");
			anim.SetBool("Grounded", true);
			while (MoveToNextNode(nextPosition)) { yield return null; }

			yield return new WaitForSeconds(0.1f);
			steps--;
			// routePosition++;
		}

		isMoving = false;
	}

	bool MoveToNextNode(Vector3 goal)
	{
		return goal != (transform.position = Vector3.MoveTowards(transform.position, goal, 1f * Time.deltaTime));
	}
	
}
