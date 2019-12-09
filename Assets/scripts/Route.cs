using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route : MonoBehaviour {

	Transform[] childObjects;
	public List<Transform> childNodeList = new List<Transform>();

	void Start() {
		fillNodes();
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.green;

		fillNodes();

		for (int i = 0; i < childNodeList.Count; i++)
		{
			Vector3 currentPos = childNodeList[i].position;
			if (i > 0)
			{
				Vector3 prevPos = childNodeList[i - 1].position;
				Gizmos.DrawLine(prevPos, currentPos);
			}
		}
	}

	void fillNodes()
	{
		childNodeList.Clear();

		childObjects = GetComponentsInChildren<Transform>();

		foreach (Transform child in childObjects)
		{
			if(child != this.transform)
			{
				childNodeList.Add(child);
			}
		}
	}
	
}
