using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeInBehaviour : MonoBehaviour
{
    public float fadeInTime=1;

    private Image image;

    // Use this for initialization
    void Start()
    {
        image =  this.GetComponent<Image>();
        image.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        if (image.color.a>0)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a-Time.deltaTime/fadeInTime);
        }
        else
        {
            Destroy(this.gameObject);
        }

    }
}
