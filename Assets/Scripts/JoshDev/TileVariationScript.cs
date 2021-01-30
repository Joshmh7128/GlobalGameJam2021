using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileVariationScript : MonoBehaviour
{
    /// 
    /// script works by enabling one of many child objects on the tile
    /// will also rotate tile at 90 degree intervals for randomness
    /// 

    private void Start()
    {
        // rotate randomly
        int i = Random.Range(0, 3); // for rotation
        transform.Rotate(0, 90 * i, 0); // perform rotation

        // enable a random object
        transform.GetChild(Random.Range(0, transform.childCount)).gameObject.SetActive(true);
    }
}
