using System.Collections;
using System.Collections.Generic;
using LiteNinja.Colors.Palettes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace LiteNinja.Colors.Demo
{

    public class PaletteView : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField]
        private GameObject _colorPrefab;
        [SerializeField]
        private TMP_Text _paletteName;
        [SerializeField]
        private Transform _colorsContainer;
        public void Init(IPalette palette, string name)
        {
            //remove all _colorContainers children
            foreach (Transform child in _colorsContainer)
            {
                Destroy(child.gameObject);
            }

            _paletteName.text = name;
            
            foreach (var color in palette.GetAll())
            {
                var colorObject = Instantiate(_colorPrefab, _colorsContainer);
                colorObject.GetComponent<Image>().color = color;
            }
        }
    }

}