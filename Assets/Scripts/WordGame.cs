using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordGame : MonoBehaviour
{
    public List<Image> correctSequence;

    private List<Image> clickedImages;

    void Start()
    {
        clickedImages = new List<Image>();
    }

    public void ImageClicked(Image image)
    {
        if (correctSequence.Contains(image))
        {
            int clickedIndex = correctSequence.IndexOf(image);

            if (clickedIndex == clickedImages.Count)
            {
                clickedImages.Add(image);
                Debug.Log("Correct image clicked!");
                CheckCompletion();
            }
            else
            {
                Debug.Log("Wrong image clicked!");
                clickedImages.Clear();
            }
        }
        else
        {
            Debug.Log("Wrong image clicked!");
        }
    }

    void CheckCompletion()
    {
        if (clickedImages.Count == correctSequence.Count)
        {
            Debug.Log("Game completed!");
        }
    }
}
