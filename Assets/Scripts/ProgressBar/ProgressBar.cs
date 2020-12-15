using UnityEngine;
using UnityEngine.UI;

namespace JoystickLab
{
    [ExecuteInEditMode]
    public class ProgressBar : MonoBehaviour
    {
        public float minValue;
        public float maxValue;
        public float value;
        [Range(1,10)]public float step;
        public Image mask;
        public Image fillImage;
        public Color fillColor;
    
        public float Value
        {
            get => value;
            set
            {
                this.value = value;
                UpdateProgressBar();
            }
        }
        // Update is called once per frame
        void Update()
        {
#if UNITY_EDITOR
            UpdateProgressBar();
#endif
        
        }

        void UpdateProgressBar()
        {
            float maxOffset = maxValue - minValue;
            float currOffset = Value - minValue;
            float fill = step * (currOffset / maxOffset);
            mask.fillAmount = fill;
            fillImage.color = fillColor;
        }
    }
}
