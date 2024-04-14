using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class СamMov : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform Player;
    [SerializeField]
    float offset;

    void Start()
    {

    }

    void FixedUpdate()
    {
        transform.position = new Vector3(Player.position.x, 2.51f, Player.position.z + offset);
    }
}
