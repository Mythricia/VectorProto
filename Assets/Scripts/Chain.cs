using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain : MonoBehaviour {

	public GameObject linkPrefab;
    public int numChainLinks = 5;

	public float spacing = 0.25f;


	public GameObject[] links;
	private GameObject chainHead;

    // Use this for initialization
    void Start () {
		chainHead = this.gameObject;

		links = new GameObject[numChainLinks];

		Vector3 linkStart = chainHead.transform.position;
		linkStart.z -= chainHead.transform.localScale.z - 1.5f;

		for (int i = 0; i < numChainLinks; i++)
		{
			linkStart.z -= (i + 1) * spacing;

			GameObject link = Instantiate(linkPrefab, linkStart, Quaternion.identity);
			links[i] = link;
		}

		if (links.Length > 0) {
			for (int i = 0; i < links.Length; i++)
			{
				GameObject link = links[i];

				if (i == 0) {
					link.GetComponent<ChainLink>().prevLink = chainHead;
					link.GetComponent<ChainLink>().nextLink = links[i+1];
				} else if (i == numChainLinks-1) {
					link.GetComponent<ChainLink>().prevLink = links[i-1];
				} else {
					link.GetComponent<ChainLink>().nextLink = links[i+1];
					link.GetComponent<ChainLink>().prevLink = links[i-1];
				}
			}

			for (int i = 0; i < links.Length; i++)
			{
				GameObject link = links[i];

				if (i == 0) {
					link.GetComponent<SpringJoint>().connectedBody = chainHead.GetComponent<Rigidbody>();
					link.GetComponent<SpringJoint>().enableCollision = false;
				} else
				{
					link.GetComponent<SpringJoint>().connectedBody = links[i-1].GetComponent<Rigidbody>();
				}
			}
		}
	}
}
