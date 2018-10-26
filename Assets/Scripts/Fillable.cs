using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fillable : MonoBehaviour {

    [SerializeField]
    private GameObject drinkLevel;

    private float filled;

    private Flavour flavour;

    [SerializeField]
    private ParticleSystem particleSystem;

	// Use this for initialization
	void Start () {
        drinkLevel.transform.localPosition = new Vector3(0, -.04f, 0);
        drinkLevel.gameObject.SetActive(false);
        filled = 0;
	}
	
	// Update is called once per frame
	void Update () {
        CheckSpilling();
	}

    public void Fill(float amount, Flavour flavour)
    {

        if (this.flavour != flavour)
        {
            this.flavour = flavour;
            drinkLevel.GetComponent<MeshRenderer>().material.color = flavour.getColor();
        }

        if (filled == 0)
        {
            drinkLevel.gameObject.SetActive(true);
        }

        if (filled < 1)
        {
            filled += amount;

            if (filled > 1)
            {
                filled = 1;
            }
        }


        UpdateDrinkLevel();
    }

    private void UpdateDrinkLevel()
    {
        float height = -.04f + (.1f * filled);
        drinkLevel.transform.localPosition = new Vector3(0, height, 0);
    }

    private void CheckSpilling()
    {
        float value = Mathf.Round((filled * 2)*100)/100;
        float position = Mathf.Round((this.transform.up.y + 1f) * 100) / 100;
        if (position <= 1)
        {
            Spill(.01f * (1- position));
        }
        else if (value > position)
        {
            Spill(value-position);
        }
    }

    private void Spill(float amount)
    {
        if (amount < 0)
        {
            return;
        }
        if (amount > 0 && filled > 0)
        {
            particleSystem.GetComponent<ParticleSystemRenderer>().material.color = flavour.getColor();
            particleSystem.Emit(2);
        }

        if (filled <= 0)
        {
            emptyCup();
        }
        else
        {
            filled -= amount;

            if (filled <= 0)
            {
                emptyCup();
            }
        }
        UpdateDrinkLevel();
    }

    private void emptyCup()
    {
        filled = 0;
        drinkLevel.gameObject.SetActive(false);
        flavour = null;
    }

    public Flavour getFlavour()
    {
        return flavour;
    }
}
