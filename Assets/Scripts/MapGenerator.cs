using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] Material noiseMat;
    [SerializeField] Image image;

    [SerializeField] int width = 100;
    int oldWidth = 100;
    [SerializeField] int height = 100;
    int oldHeight = 100;
    [SerializeField] float scale = 10f;
    float oldScale = 10f;

    MapDisplay display;
    GameObject plane;
    GameObject terrain;
    MeshRenderer planeRenderer;

    // Start is called before the first frame update
    void Start()
    {
        display = gameObject.GetComponent<MapDisplay>();


        //planeRenderer = plane.GetComponent<MeshRenderer>();
        //planeRenderer.material = noiseMat;

        noiseMat.mainTexture = Noise.GenerateNoiseTexture(width, height, scale);
    }

    // Update is called once per frame
    void Update()
    {
        if (scale != oldScale || width != oldWidth || height != oldHeight)
        {
            noiseMat.mainTexture = Noise.GenerateNoiseTexture(width, height, scale);
            image.material = noiseMat;
        }
    }
}
