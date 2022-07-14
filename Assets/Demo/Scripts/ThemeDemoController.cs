using System.Collections;
using System.Collections.Generic;
using LiteNinja.Colors.Themes;
using LiteNinja.Utils.Extensions;
using UnityEngine;

namespace LiteNinja.Colors.Demo
{
    public class ThemeDemoController : MonoBehaviour
    {
        [SerializeField] private PaletteSO _activePalette;
        [SerializeField] private PaletteSO[] _themes;
        
        private int _currentThemeIndex;
        private void Start()
        {
            if (_themes.Length == 0)
            {
                _themes.Add(_activePalette);
            }
            
            _activePalette.ReplaceFromPalette(_themes[_currentThemeIndex]);
        }
        
        public void NextTheme()
        {
            Debug.Log("Current theme: " + _currentThemeIndex);
            _currentThemeIndex = (_currentThemeIndex + 1) % _themes.Length;
            _activePalette.ReplaceFromPalette(_themes[_currentThemeIndex]);
            Debug.Log("Current theme: " + _currentThemeIndex);
        }
    }

}