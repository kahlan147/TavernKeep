using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterStream : MonoBehaviour {

    [SerializeField]
    private Transform origin;
    [SerializeField]
    private float fillRate;
    [SerializeField]
    private Flavour flavour;
    [SerializeField]
    private GameObject flavourIndicator;


	// Use this for initialization
	void Start () {
        this.GetComponent<MeshRenderer>().material.color = flavour.getColor();
        flavourIndicator.GetComponent<MeshRenderer>().material.color = flavour.getColor();
        this.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        float distance = CalculateLength();
        UpdatePosition(distance);
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Fillable>() != null)
        {
            other.gameObject.GetComponent<Fillable>().Fill(fillRate, flavour);
        }
    }

    private float CalculateLength()
    {
        RaycastHit hit;
        Physics.Raycast(origin.position, Vector3.down, out hit, 1000, -5, QueryTriggerInteraction.Ignore);
        return hit.distance;

    }

    private void UpdatePosition(float distance)
    {
        float height = origin.transform.localPosition.y - distance / 2;
        this.transform.localPosition = new Vector3(origin.localPosition.x, height, origin.localPosition.z);
        this.transform.localScale = new Vector3(this.transform.localScale.x, distance, this.transform.localScale.z);

    }
}
