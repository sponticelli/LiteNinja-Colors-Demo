using System;
using System.Collections;
using LiteNinja_Colors.Runtime;
using LiteNinja.Colors.Extensions;
using LiteNinja.Colors.Helpers;
using LiteNinja.Utils.Extensions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LiteNinja.Colors.Demo
{
    public class ColorNameController : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private TextMeshProUGUI _colorRGBText;
        [SerializeField] private TextMeshProUGUI _colorNameText;
        [SerializeField] private Image _namedColorImage;
        [SerializeField] private TextMeshProUGUI _namedColorRGBText;
        [SerializeField] private TMP_Text _text;
        [SerializeField] private float _time = 1f;
       
        private float _timePassed;
        
        private void Start()
        {
            SetColor(ColorRandomHelper.Random());
        }

        private void Update()
        {
            _timePassed += Time.deltaTime;
            if (!(_timePassed >= _time)) return;
            _timePassed = 0;
            SetColor(ColorRandomHelper.Random());
        }

        private void SetColor(Color color)
        {
            _image.color = color;
            _colorRGBText.text = color.ToHtmlStringRGB();
            _colorNameText.text = ColorNameHelper.NameFromHSL(color);
            var nearestName = color.ToNearestName();
            _text.text =  color.ToNearestName();
            _namedColorImage.color = ColorNameHelper.FromName(nearestName);
            _namedColorRGBText.text = _namedColorImage.color.ToHtmlStringRGB();
        }
    }
}