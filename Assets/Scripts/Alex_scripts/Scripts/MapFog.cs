using UnityEngine;
using UnityEngine.UI;

namespace Alex_scripts
{
    public class MapFog : MonoBehaviour
    {
        private Texture2D _fogTexture;
        private Material _mapMaterial;
        
        private Color[] _fogData;
        // Start is called before the first frame update
        void Start()
        {
            _mapMaterial = GetComponent<Image>().material;
            _fogTexture = new Texture2D(100, 100, TextureFormat.RGBA32, false);
            _fogData = new Color[_fogTexture.width * _fogTexture.height];
            for (int i = 0; i < _fogData.Length; i++)
            {
                _fogData[i] = i % 2 == 0 ? Color.black : Color.white;
            }
            _fogTexture.SetPixels(_fogData);
            _fogTexture.Apply();
            //_uiImage.sprite = Sprite.Create(_texture, new Rect(0,0, _texture.width, _texture.height), _uiImage.sprite.pivot);
            _mapMaterial.SetTexture(ShaderConstants.MainTexture, _fogTexture);
        }

        // Update is called once per frame
        void Update()
        {
            //_uiImage.sprite = Sprite.Create(_texture, new Rect(0,0, _texture.width, _texture.height), _uiImage.sprite.pivot);
            
        }
    }
}
