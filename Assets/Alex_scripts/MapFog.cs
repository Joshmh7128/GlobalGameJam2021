using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.UI;

namespace Alex_scripts
{
    public class MapFog : MonoBehaviour
    {
        private Texture2D _texture;
        private Image _uiImage;
        private Material _mapMaterial;
        
        private Color[] _textureData;
        // Start is called before the first frame update
        void Start()
        {
            _uiImage = GetComponent<Image>();
            _mapMaterial = _uiImage.material;
            _texture = new Texture2D(100, 100, TextureFormat.RGBA32, false);
            _textureData = new Color[_texture.width * _texture.height];
            for (int i = 0; i < _textureData.Length; i++)
            {
                _textureData[i] = i % 2 == 0 ? Color.black : Color.white;
            }
            _texture.SetPixels(_textureData);
            _texture.Apply();
            //_uiImage.sprite = Sprite.Create(_texture, new Rect(0,0, _texture.width, _texture.height), _uiImage.sprite.pivot);
            _mapMaterial.SetTexture(ShaderConstants.FogMap, _texture);
        }

        // Update is called once per frame
        void Update()
        {
            //_uiImage.sprite = Sprite.Create(_texture, new Rect(0,0, _texture.width, _texture.height), _uiImage.sprite.pivot);
            
        }
    }
}
