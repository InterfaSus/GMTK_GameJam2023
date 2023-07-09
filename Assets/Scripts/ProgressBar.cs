using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public GameObject loadWindow;
    public GameObject rulesWindow;
    public Slider slider;
    public AnimationCurve loadCurve;
    public Button startButton;
    public float baseLoadTime = 10.0f;

    public AudioSource Fan;


    private float progress = 0.0f;
    private bool loadingStarted = false;

    private void Update()
    {
        if (loadingStarted && progress < 1.0f)
        {
            progress += Time.deltaTime / (baseLoadTime - 1.5f * Persistents.upgradeLevels[4]); // Incrementa el progreso con el tiempo
            progress = Mathf.Clamp01(progress); // Asegúrate de que el progreso esté dentro del rango [0, 1]
            float curveValue = loadCurve.Evaluate(progress); // Evalúa la curva de animación en el progreso de la carga actual
            slider.value = curveValue; // Actualiza el valor del Slider con el valor de la curva de animación
        }

        if(progress >= 1.0f)
        {
            Fan.Stop();
            progress = 0.0f;
            loadingStarted = false;
            Browser.instance.FocusTab("ruleList");
            rulesWindow.GetComponentInChildren<RulesList>().InitRuleList();
            loadWindow.SetActive(false);
        }
    }

    public void StartLoading()
    {
        progress = 0.0f; // Reinicia el progreso
        loadingStarted = true; // Inicia la carga
        Fan.Play();
    }
}