using TMPro;
using UnityEngine;

namespace TeamSleaze.Utilities
{
    [RequireComponent(typeof(TMP_Text))]
    public class FPSCounter : MonoBehaviour
    {
        public bool UpdateFPS = true;

        private TMP_Text text;
        private int lastFrameIndex;
        private float[] frameDeltaTimeArray;


        private void Awake()
        {
            text = GetComponent<TMP_Text>();
            frameDeltaTimeArray = new float[50];
        }

        private void Update()
        {
            if (UpdateFPS)
            {
                frameDeltaTimeArray[lastFrameIndex] = Time.unscaledDeltaTime;
                lastFrameIndex = (lastFrameIndex + 1) % frameDeltaTimeArray.Length;

                text.text = Mathf.RoundToInt(CalculateFPS()).ToString();
            }
        }

        private float CalculateFPS()
        {
            float total = 0f;
            foreach (float deltaTime in frameDeltaTimeArray)
            {
                total += deltaTime;
            }
            return frameDeltaTimeArray.Length / total;
        }

    }
}