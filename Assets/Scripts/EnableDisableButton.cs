using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDisableButton : MonoBehaviour {

    [SerializeField]
    private GameObject desiredObject;

    public void EnableDisable()
    {
        desiredObject.SetActive(!desiredObject.active);
    }
}
