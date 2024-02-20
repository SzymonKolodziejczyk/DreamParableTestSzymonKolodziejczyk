using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;

public class MarkoPoloGenerator : MonoBehaviour
{
    public TextMeshProUGUI outputText;
    public Button generateButton;
    public ScrollRect scrollView;
    public GameObject content;
    public float padding = 10f;

    private void Start()
    {
        generateButton.onClick.AddListener(GenerateLines);
    }

    private void GenerateLines()
    {
        int numLines = 100; // Number of lines to generate

        StringBuilder generatedText = new StringBuilder();

        for (int i = 1; i <= numLines; i++)
        {
            if (i % 3 == 0 && i % 5 == 0)
            {
                generatedText.AppendLine("MarkoPolo");
            }
            else if (i % 3 == 0)
            {
                generatedText.AppendLine("Marko");
            }
            else if (i % 5 == 0)
            {
                generatedText.AppendLine("Polo");
            }
            else
            {
                generatedText.AppendLine(i.ToString());
            }
        }

        outputText.SetText(generatedText.ToString());

        // Set the generated text as the content of the scroll view
        outputText.text = generatedText.ToString();

        // Enable scrolling by adjusting the size of the content
        RectTransform contentRectTransform = content.GetComponent<RectTransform>();
        contentRectTransform.sizeDelta = new Vector2(contentRectTransform.sizeDelta.x, outputText.preferredHeight + padding);

        // Toggle the visibility of the scroll view
        scrollView.gameObject.SetActive(!scrollView.gameObject.activeSelf);
    }
}