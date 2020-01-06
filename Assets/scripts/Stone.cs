using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour {

	public Route currentRoute;
	int routePosition;
	public int steps;
	bool isMoving;

	// Animator anim;

	Vector3 up = Vector3.zero,
	right = new Vector3(0, 90, 0),
	down = new Vector3(0, 180, 0),
	left = new Vector3(0, 270, 0),
	currentDirection = Vector3.zero;

	Vector3 nextPos, destination, direction;

	float speed = 5f;



	// public Animator m_animator;

	void Start()
	{
		// anim = GetComponent<Animator>();
		currentDirection = up;
		nextPos = Vector3.forward;
		destination = transform.position;
		// Movee();
	}
	
	void Update()
	{
		Movee();

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

	void Movee ()
	{
		// transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);

		if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
		{
			nextPos = Vector3.forward;
			currentDirection = up;
		}

		if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
		{
			nextPos = Vector3.back;
			currentDirection = down;
		}

		if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
		{
			nextPos = Vector3.right;
			currentDirection = right;
		}

		if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
		{
			nextPos = Vector3.left;
			currentDirection = left;
		}

		// if (Vector3.Distance(destination, transform.position) <= 0.00001f)
		// {
		// 	transform.localEulerAngles = currentDirection;
		// }
		transform.localEulerAngles = currentDirection;
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
