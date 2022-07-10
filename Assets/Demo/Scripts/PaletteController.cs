using System.Collections.Generic;
using System.Linq;
using LiteNinja.Colors.Extensions;
using LiteNinja.Colors.Helpers;
using UnityEngine;
using LiteNinja.Colors.Palettes;
using LiteNinja.Colors.Spaces;
using LiteNinja.Utils.Extensions;
using UnityEngine.UI;


namespace LiteNinja.Colors.Demo
{
    public class PaletteController : MonoBehaviour
    {
        [Header("Prefabs")] [SerializeField] private GameObject _palettePrefab;

        [Header("UI")] 
        [SerializeField] private Transform _paletteContainer;
        [SerializeField] private Image _colorPreview;

        [SerializeField] private int _numColors = 10;
        [SerializeField] private Color _color;

        [SerializeField] private float _time = 5f;
        
        private float _timeElapsed;
        
        private void OnEnable()
        {
            Generate();
        }
        
        private void Update()
        {
            _timeElapsed += Time.deltaTime;
            if (!(_timeElapsed >= _time)) return;
            _timeElapsed = 0;
            Generate();
        }

        private void Generate()
        {
            //Remove all _paletteContainer children
            foreach (Transform child in _paletteContainer)
            {
                Destroy(child.gameObject);
            }
            
            _color = ColorRandomHelper.Random();
            _colorPreview.color = _color;

            AddPalette(_color.RandomHues(_numColors), "Random");
            AddPalette(_color.RandomMonochromaticHarmony(_numColors, 0.5f, 0.01f), "Monochromatic Harmony");
            AddPalette(_color.RandomAnalogousHarmony(_numColors, 60f, 0.01f), "Analogous Harmony");
            AddPalette(_color.RandomComplementaryHarmony(_numColors, 0.25f), "Complementary Harmony");
            AddPalette(_color.RandomTriadicHarmony(_numColors, 0.25f), "Triadic Harmony");
            AddPalette(_color.RandomTetradicHarmony(_numColors, 0.25f), "Tetradic Harmony");
        }
        
        

        private void AddPalette(IList<Color> colors, string name)
        {
            colors.Sort(ColorComparison);
            var palette = new Palette();
            palette.AddRange(colors);
            var go = Instantiate(_palettePrefab, _paletteContainer);
            var paletteController = go.GetComponent<PaletteView>();
            paletteController.Init(palette, name);
        }

        private static int ColorComparison(Color c1, Color c2)
        {
            var hsl1 = (ColorHSL)c1;
            var hsl2 = (ColorHSL)c2;
            var comp = hsl1.Hue.CompareTo(hsl2.Hue);
            if (comp == 0)
            {
                comp = hsl1.Lightness.CompareTo(hsl2.Lightness);
            }

            if (comp == 0)
            {
                comp = hsl1.Saturation.CompareTo(hsl2.Saturation);
            }

            return comp;
        }
    }
}