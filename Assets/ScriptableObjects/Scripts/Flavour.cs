using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "Flavour", menuName = "Flavour", order = 1)]
public class Flavour : ScriptableObject {

    [SerializeField]
    private Color color;

    public Color getColor()
    {
        return color;
    }
}
