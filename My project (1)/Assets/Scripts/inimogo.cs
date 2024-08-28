using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimogo : MonoBehaviour
{
    public float velocidade;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(velocidade, 0) * Time.deltaTime);
    }
}
