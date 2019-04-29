using UnityEngine;
using UnityEngine.UI;

namespace Geekbrains
{

    public class PlayerUI : MonoBehaviour
    {
        private Text _text;

        private void Start()
        {
            _text = GetComponent<Text>();
        }
        public void ShowHealth(float health)
        {
            _text.text = $"{health}";
        }
    }
}