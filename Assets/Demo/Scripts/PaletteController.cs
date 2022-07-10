using UnityEngine;
using LiteNinja.Colors.Palettes;


namespace LiteNinja.Colors.Demo
{
    public class PaletteController : MonoBehaviour
    {
        [SerializeField] private Palette _randomPalette;
        [SerializeField] private Palette _harmonicPalette;
        [SerializeField] private Palette _randomWalkPalette;

        private void OnEnable()
        {
            Generate();
        }

        private void Generate()
        {
            // TODO: Generate palettes 
        }
    }
}