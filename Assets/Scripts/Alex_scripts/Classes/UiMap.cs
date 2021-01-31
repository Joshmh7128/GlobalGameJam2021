using System;
using Alex_scripts.Interfaces;
using UnityEngine;

namespace Alex_scripts.Classes
{
    [System.Serializable]
    public class UiMap
    {
        [SerializeField] private int tileSize = 100;
        
        [SerializeField]
        private Shader mapShader;
        private Texture2D _mapTexture;
        private Material _mapMaterial;

        public Material GETMaterial
        {
            get => _mapMaterial;
        }
        
        private Color[] _mapData;

        public void Init(IMapTile[,] tiles)
        {
            int mapPxls = tiles.GetLength(0) * tiles.GetLength(1) * tileSize * tileSize;
            _mapData = new Color[mapPxls];
            _mapMaterial = new Material(mapShader);
            _mapTexture = new Texture2D(tiles.GetLength(0) * tileSize, 
                tiles.GetLength(1) * tileSize, TextureFormat.RGBA32, false);
            
            foreach (IMapTile row in tiles)
            {
                Color[] tileTex = row.GetTileIcon().GetPixels();
                for (int i = 0; i < tileSize * tileSize; i++)
                {
                    // Offset should be: row of the tile's current texel + length of every completed row
                    int index = i % tileSize + (tileSize * tiles.GetLength(0) * (i / tileSize));
                    _mapData[index] = i < tileTex.Length ? 
                        new Color(tileTex[i].r, tileTex[i].g, tileTex[i].b, 0f) 
                        : Color.black;
                }
            }
            
            _mapTexture.SetPixels(_mapData);
            _mapTexture.Apply();
            //_uiImage.sprite = Sprite.Create(_texture, new Rect(0,0, _texture.width, _texture.height), _uiImage.sprite.pivot);
            _mapMaterial.SetTexture(ShaderConstants.MainTexture, _mapTexture);
        }
    }
}