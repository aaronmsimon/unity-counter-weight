using System.Collections;
using RoboRyanTron.Unite2017.Variables;
using UnityEngine;
using UnityEngine.UI;

namespace CounterWeight.UI
{
    // [ExecuteInEditMode()]
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField] private GameObject background;
        [SerializeField] private float maximum;
        [SerializeField] private float current;
        [SerializeField] private Image mask;
        [SerializeField] private FloatVariable seconds;

        private void Update()
        {
            GetCurrentFill();
        }

        private void GetCurrentFill()
        {
            float fillAmount = (float)current / (float)maximum;
            mask.fillAmount = fillAmount;
        }

        public void RunFillProgressBar()
        {
            StartCoroutine(FillProgressBar());
        }

        private IEnumerator FillProgressBar()
        {
            background.SetActive(true);
            current = 0f;
            maximum = seconds.Value;
            while(current < maximum)
            {
                current += Time.deltaTime;
                yield return null;
            }
            background.SetActive(false);
        }
    }
}
