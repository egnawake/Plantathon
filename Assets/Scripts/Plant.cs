using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField] private int cost;
    [SerializeField] private int baseValue;

    public int Cost => cost;
    public int Value => baseValue;
}
