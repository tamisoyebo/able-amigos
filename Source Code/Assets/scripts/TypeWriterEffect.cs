using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypeWriterEffect : MonoBehaviour
{

    [SerializeField] private float typeWriterSpeed = 30f;
    public Coroutine Run(string textToType, TMP_Text textLabel)
    {
        return StartCoroutine(routine: TypeText(textToType, textLabel));
    }

    public IEnumerator TypeText(string textToType, TMP_Text textLabel)
    {
        textLabel.text = string.Empty;

        yield return new WaitForSeconds(1);

        float t = 0;    // time
        int charIndex = 0;  //characters type per frame

        while (charIndex < textToType.Length)
        {
            t += Time.deltaTime * typeWriterSpeed;
            charIndex = Mathf.FloorToInt(t);
            charIndex = Mathf.Clamp(value: charIndex, min: 0, max: textToType.Length);

            textLabel.text = textToType.Substring(startIndex: 0, length: charIndex);

            yield return null;
        }

        textLabel.text = textToType;
    }
}
