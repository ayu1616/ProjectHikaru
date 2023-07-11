using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossessionObjectBase : MonoBehaviour
{
    [SerializeField]
    protected Vector3 playerLocalPosition = Vector3.zero;

    public Vector3 GetPlayerLocalPoition() { return playerLocalPosition; }
}
