using TMPro;
using UnityEngine;

namespace ZigZag._Scripts
{
    public class FadeAnimation : MonoBehaviour
    {
        public TextMeshProUGUI text;
        public float fadeTime = 1f;

        void Start()
        {
            LeanTween.value(0f, 1f, fadeTime).setOnUpdate((float val) =>
            {
                text.color = new Color(text.color.r, text.color.g, text.color.b, val);
            }).setEase(LeanTweenType.easeInOutSine).setLoopPingPong();
        }
    }
}

