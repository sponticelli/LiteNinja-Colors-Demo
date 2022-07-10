using LiteNinja.Colors.Spaces;
using UnityEngine;
using UnityEngine.UI;


namespace LiteNinja.Colors.Demo
{
    public class ColorController : MonoBehaviour
    {
        [SerializeField] private ColorHSV _colorHSV;
        [SerializeField] private ColorHSL _colorHSL;

        [SerializeField] private Image _imageHSV; 
        [SerializeField] private Image _imageHSL;

        private void Update()
        {
            _colorHSL.Hue = (_colorHSL.Hue + Time.deltaTime * 0.3f) % 1f;
            _colorHSL.Saturation = (Mathf.Sin(Time.timeSinceLevelLoad * 0.5f) + 1) * 0.5f;
            _colorHSL.Lightness = (Mathf.Sin(Time.timeSinceLevelLoad * 0.44f) + 1) * 0.5f;

            _colorHSV.Hue = (_colorHSV.Hue + Time.deltaTime * 0.3f) % 1f;
            _colorHSV.Saturation = (Mathf.Sin(Time.timeSinceLevelLoad * 0.5f) + 1) * 0.5f;
            _colorHSV.Value = (Mathf.Sin(Time.timeSinceLevelLoad * 0.44f) + 1) * 0.5f;

            _imageHSL.color = _colorHSL;
            _imageHSV.color = _colorHSV;
        }
    }
}