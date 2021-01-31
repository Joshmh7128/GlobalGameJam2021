using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileInitiationHandler : MonoBehaviour
{
    [SerializeField] GameObject gameTile; // which tile are we using for generation?

    // instantiate 8 or 9 tiles, all at 1,000 coordinates other than 0
    private void Start()
    {
        Instantiate(gameTile, new Vector3(0, 0), Quaternion.identity);
        Instantiate(gameTile, new Vector3(1000,0), Quaternion.identity);
        Instantiate(gameTile, new Vector3(-1000,0), Quaternion.identity);
        Instantiate(gameTile, new Vector3(0, 0, -1000), Quaternion.identity);
        Instantiate(gameTile, new Vector3(0, 0, 1000), Quaternion.identity);
        Instantiate(gameTile, new Vector3(1000, 0, 1000), Quaternion.identity);
        Instantiate(gameTile, new Vector3(-1000, 0, 1000), Quaternion.identity);
        Instantiate(gameTile, new Vector3(1000, 0, -1000), Quaternion.identity);
        Instantiate(gameTile, new Vector3(-1000, 0, -1000), Quaternion.identity);
    }


}
