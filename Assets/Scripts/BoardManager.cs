using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public static BoardManager sharedInstance;            // Autoreferenciamos el BoardManager con la variable siguiente.
    public List<Sprite> prefabs = new List<Sprite>();    // Caramelos que formarán parte de la pantalla del juego.
    public GameObject currentCandy;                     // Variable que guarda referencia del caramelo actual.
    public int xSize, ySize;                           // Variables de tamaño del tablero.

    private GameObject [,] candies;        // Matriz de los caramelos que aparecen en pantalla.

    public bool isShifting {get; set;}     // Variable para saber si se está cambiando de posición un caramelo. Solo el propio BoardManager puede cambiar su valor, por eso el get;set; .

    void Start()
    {
        //Evaluamos si hay dos managers en la escena. Si hay mas de uno,
        //se destruye el que se ejecute después del primero y a que solo
        //debe existir un manager.

        if(sharedInstance == null)
        {
            sharedInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // Calculamos el offset llamando al caramelo actual, obteniendo su collider.
        // Depués inicializamos el Método de CreateInitialBoard, pasandole el valor de offset.
        Vector2 offset = currentCandy.GetComponent<BoxCollider2D>().size;
        CreateInitialBoard(offset);
    }

    // Método para configurar inicialmente el tablero.
    private void CreateInitialBoard(Vector2 offset)
    {
        candies = new GameObject[xSize, ySize];     // Inicializamos el array de filas y columnas con el numero dado en xSize & ySize
        float startX = this.transform.position.x;  // Donde sea que este creado el board manager, empieza la coordenada X de nuestro tablero
        float startY = this.transform.position.y; // Donde sea que este creado el board manager, empieza la coordenada Y de nuestro tablero

        int idx = -1;

        for(int x=0; x<xSize; x++) // Mientras x sea menor que el numero de columnas que establecimos, x aumenta.
        {
            for(int y=0; y<ySize; y++) // Mientras y sea menor que el numero de filas que establecimos, y aumenta, se instancia un caramelo
            {
                GameObject newCandy = Instantiate(currentCandy, new Vector3(startX+(offset.x*x),startY+(offset.y*y),0), currentCandy.transform.rotation);   // Intanciamos un caramelo haciendo el calculo de las coordenadas del offset asignado.
                newCandy.name = string.Format("Candy[{0}][{1}]", x, y);                                                                                    // Se guarda la columna y fila del nuevo caramelo
                            
                do
                {
                    idx = Random.Range(0, prefabs.Count);
                }
                while((x>0 && idx==candies[x-1,y].GetComponent<Candy>().id) || (y>0 && idx==candies[x,y-1].GetComponent<Candy>().id));
                            
                Sprite sprite = prefabs[idx];
                newCandy.GetComponent<SpriteRenderer>().sprite = sprite;
                newCandy.GetComponent<Candy>().id = idx;
                
                newCandy.transform.parent = this.transform;
                candies[x, y] = newCandy;  // Colocamos el nuevo caramelo que acabamos de inicializar
            }
        }
    }

    void Update()
    {
        
    }
    
}
