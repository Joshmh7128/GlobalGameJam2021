using System;
using Alex_scripts.Interfaces;
using UnityEngine;

namespace Alex_scripts.Classes
{
    [Serializable]
    public class TestMapTile : IMapTile
    {
        private Texture2D _tileImage;

        public TestMapTile(Texture2D tileImage)
        {
            _tileImage = tileImage;
        }
        
        public Texture2D GetTileIcon()
        {
            return _tileImage;
        }
    }
}