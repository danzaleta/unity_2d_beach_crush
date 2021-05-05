using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{
    // Color para detectar si un color está seleccionado
    private static Color selectedColor = new Color(0.5f, 0.5f, 0.5f, 1.0f);
    // Caramelo que se seleccionó previamente
    private static Candy previousSelected = null;

    // Referncia al sprite que utilizaremos para cambiar el aspecto del objeto
    private SpriteRenderer spriteRenderer;
    // Variable para saber si está o no seleccionado un caramelo.
    private bool isSelected = false;

    // Identificación del dulce
    public int id;

    // Array de vectores para saber los caramelos que hay a los 4 lados
    private Vector2[] adjacentDirections = new Vector2[]
    {
        Vector2.up,
        Vector2.down,
        Vector2.left,
        Vector2.right
    };

    private void Awake()
    {
        //Una buena práctica es que cuando tengamos una variable privada
        //como la de un componente, que se inicialice en el Awake.
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
