using Alex_scripts.Classes;
using Alex_scripts.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Alex_scripts
{
    public class MapScript : MonoBehaviour
    {
        [SerializeField]
        private UiMap map;

        [SerializeField] private Texture2D tile;
        
        
        public void Start()
        {
            int size = 3;
            IMapTile[,] tiles = new IMapTile[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    tiles[i, j] = new TestMapTile(tile);
                }
            }
            map.Init(tiles);
            GetComponent<Image>().material = map.GETMaterial;
        }
    }
}