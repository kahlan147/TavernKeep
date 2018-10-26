using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Order : MonoBehaviour {

    private Flavour requestedFlavour;

    [SerializeField]
    private Image background;
    [SerializeField]
    private Image RequestedFlavourColour;
    [SerializeField]
    private Image TimerImage;

    private float maxTimer;
    private float time = 0;

    private void Awake()
    {
        maxTimer = 30;
    }


    public void SpawnOrder(Flavour flavour, float OrderTime)
    {
        maxTimer = OrderTime;
        setRequestedFlavour(flavour);
    }

    private void Update()
    {
        Timer();
        LookAtPlayer();
    }

    private void Timer()
    {
        time += Time.deltaTime;
        if (time > maxTimer)
        {
            Destroy(this.gameObject);
        }

        float percentage = time / maxTimer;
        TimerImage.rectTransform.offsetMax = new Vector2(0, -0.5f * percentage);
        TimerImage.color = Color.Lerp(Color.green, Color.red, percentage);

    }


    public void setRequestedFlavour(Flavour flavour)
    {
        this.requestedFlavour = flavour;
        RequestedFlavourColour.color = requestedFlavour.getColor();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Holdable>())
        {
            Flavour drinkFlavour = other.gameObject.GetComponentInChildren<Fillable>().getFlavour();
            if (drinkFlavour == this.requestedFlavour)
            {
                AcceptDrink(other.gameObject);
            }
        }
    }

    private void AcceptDrink(GameObject mug)
    {
        mug.transform.position = this.transform.position;
        Destroy(mug.GetComponent<Holdable>());
    }

    private void LookAtPlayer()
    {
        background.rectTransform.LookAt(Camera.main.transform);
    }


}
