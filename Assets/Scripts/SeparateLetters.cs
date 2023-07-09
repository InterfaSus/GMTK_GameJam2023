using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SeparateLetters : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public float separationDelay = 30f;

    private Transform[] letterTransforms;
    private Vector3[] originalPositions;
    private Vector3[] directions;
    private bool finishedLoading = false;

    public void InitializeLetters(string text) {
        
        textComponent.text = text;

        letterTransforms = new Transform[textComponent.text.Length];
        originalPositions = new Vector3[textComponent.text.Length];
        directions = new Vector3[textComponent.text.Length];

        float letterSpacing = textComponent.fontSize * textComponent.characterSpacing;

        float startPositionX = -(letterSpacing * (textComponent.text.Length - 1)) / 2f;

        for (int i = 0; i < textComponent.text.Length; i++) {

            GameObject letterObject = new GameObject("Letter" + i);
            letterObject.transform.SetParent(transform);
            RectTransform rectTransform = letterObject.AddComponent<RectTransform>();

            TextMeshProUGUI letterText = letterObject.AddComponent<TextMeshProUGUI>();
            letterText.font = textComponent.font;
            letterText.fontSize = textComponent.fontSize;
            letterText.color = textComponent.color;
            letterText.text = textComponent.text[i].ToString();
            letterText.alignment = TextAlignmentOptions.Center;

            rectTransform.anchoredPosition = GetLetterPosition(i);

            letterTransforms[i] = letterObject.transform;
            originalPositions[i] = rectTransform.position;


            directions[i] = Random.insideUnitCircle.normalized;
        }

        textComponent.text = "";
        finishedLoading = true;
    }

    private Vector2 GetLetterPosition(int index) {

        int totalCharacters = textComponent.text.Length;
        float width = textComponent.preferredWidth;

        float x = -(width / 2f) + ((float)index / (totalCharacters - 1)) * width * 1.2f;
        float y = 0f;

        return new Vector2(x, y);
    }

    private void Update() {

        if (finishedLoading) {
            for (int i = 0; i < letterTransforms.Length; i++) {
                
                letterTransforms[i].position = Vector3.Lerp(letterTransforms[i].position, letterTransforms[i].position + directions[i], 1.0f / separationDelay * Time.deltaTime * 0.5f);
            }
        }
    }
}
