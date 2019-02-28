using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Colour : MonoBehaviour
{
    public TrailRenderer brush;

    public Button blueGreenButton;

    private Gradient customGradient;
    private GradientColorKey[] colour;
    private GradientAlphaKey[] alpha;

    // Start is called before the first frame update
    void Start()
    {
        customGradient = new Gradient();
        colour = new GradientColorKey[1];
        alpha = new GradientAlphaKey[1];
        colour[0].color = Color.white;
        alpha[0].time = 1.0f;

        blueGreenButton.onClick.AddListener(blueGreener);

        customGradient.SetKeys(colour, alpha);
        brush.colorGradient = customGradient;
    }

   void blueGreener()
   {
       colour = new GradientColorKey[2];
       alpha = new GradientAlphaKey[2];
       colour[0].color = Color.blue;
       colour[0].time = 0.0f;
       colour[1].color = Color.green;
       colour[1].time = 1.0f;

       customGradient.SetKeys(colour, alpha);
       brush.colorGradient = customGradient;
   }
}
