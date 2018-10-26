using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionDetection : MonoBehaviour {

    [SerializeField]
    private Transform Eyes;

    [SerializeField]
    private SphereCollider hitBox;

    [SerializeField]
    private BoxCollider hitbox;

    private void Start()
    {
        Physics.IgnoreLayerCollision(8,9);
    }

    // Update is called once per frame
    void Update () {
        Vector3 position = Eyes.localPosition; //new Vector3(Eyes.localPosition.x, 1, Eyes.localPosition.z);
        Vector3 backPosition = new Vector3(Eyes.localPosition.x, .7f, Eyes.localPosition.z) - Eyes.forward * 0.5f;
        hitBox.center = position;
        hitbox.center = backPosition;
	}
}
