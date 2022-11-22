using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    void Update()
    {
        // transform.Rotate(Vector3.up * 20 * Time.deltaTime);
        transform.Rotate(new Vector3(0, 1 , 0) * Time.deltaTime * 180);
    }

}
