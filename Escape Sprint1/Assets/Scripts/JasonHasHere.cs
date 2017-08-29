using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JasonHasHere : MonoBehaviour {


    public FollowTarget camara;
    public GameObject hab_final;
    public GameObject hab_inicio;
    public GameObject hab_3;
    public GameObject hab_4;

    
    //matriz de GameObject
    public GameObject[][] grid = new GameObject[20][];
    //pila de numeros que son los tipos de habitaciones que hay
    public List<int> pilaTargHab = new List<int>();
    public int posActHab = 0;

    
    private float tamano = 10;

    //no se usa
    private int x = 9, y = 9;

    
    private int randomHab;

    
    public void CrearPilaHabitaciones()
    {
        //inicio
        pilaTargHab.Add(1);
        //hab tres_P_LL
        pilaTargHab.Add(2);
        pilaTargHab.Add(2);
        //hab tres_P_A
        pilaTargHab.Add(3);
        pilaTargHab.Add(3);
        //hab tres_P_G
        for (int i = 0; i < 6; i++)
        {
            pilaTargHab.Add(4);
        }
        //hab cuatro P
        for (int i = 0; i < 7; i++)
        {
            pilaTargHab.Add(5);
        }
        //final
        pilaTargHab.Add(6);
    }

    /**
     * Recuperado y modificado de: 
     * http://answers.unity3d.com/questions/486626/how-can-i-shuffle-alist.html?childToView=948088#answer-948088
     */

    public static List<int> ShufflePilaHabitaciones(List<int> aList)
    {
        System.Random _random = new System.Random();

        int myGO;

        int n = aList.Count;
        for (int i = 1; i < n; i++)
        {
            // NextDouble returns a random number between 0 and 1.
            // ... It is equivalent to Math.random() in Java.
            int r = i + (int)(_random.NextDouble() * (n - i));
            myGO = aList[r];
            aList[r] = aList[i];
            aList[i] = myGO;
        }

        return aList;
    }
    
    public void CreaMatriz()
    {
        for (int i = 0; i < 20; i++)
        {
            grid[i] = new GameObject[20];
        }
    }
   

    public GameObject CreaHabitacion(int id)
    {
        GameObject tipo = null ;
        switch (id)
        {
            case 1://inicio
                tipo = Instantiate(hab_inicio);
                break;

            case 2://3 puertas - //hab tres_P_LL
                tipo = Instantiate(hab_3);
                break;
            case 3://3 puertas - //hab tres_P_A
                tipo = Instantiate(hab_3);
                break;
            case 4://3 puertas - //hab tres_P_G
                tipo = Instantiate(hab_3);
                break;

            case 5://4 puertas - //hab cuatro P
                tipo = Instantiate(hab_4);
                break;

            case 6://final
                tipo = Instantiate(hab_final);
                break;
            default:
                tipo = Instantiate(hab_final);
                break;
        }
        return tipo;
    }


    public void CreaHabitacionInicio()
    {
        GameObject obj = CreaHabitacion(pilaTargHab[posActHab]);
        //tomar la posicion i de la lista
        GameObject objI = obj;
        objI.transform.SetParent(this.transform);
        objI.GetComponent<MeshRenderer>().enabled = true;
        
        objI.transform.localPosition = new Vector3((float)9 * tamano, 0f, -(float)9 * tamano);
        
        grid[9][9] = objI;
        //agregar a la lista habitaciones
        
        //ubicar camara en posicion inicio
        camara.target = grid[9][9].transform;

        posActHab++;    
    }

    public void InstanciaHabitacion(int a, int b)
    {
        
        if (grid[a][b] == null && posActHab < 19)
        {
            //tomar la posicion i de la lista
            int tipoHab = pilaTargHab[posActHab];
            GameObject obj = CreaHabitacion(tipoHab);
            GameObject objI = obj;
            objI.transform.SetParent(this.transform);
            objI.GetComponent<MeshRenderer>().enabled = true;
            objI.transform.localPosition = new Vector3((float)b * tamano, 0f, -(float)a * tamano);
            grid[a][b] = objI;

            posActHab++;
            
        }
    }

    void Awake()
    {
        //pila
        CrearPilaHabitaciones();
        pilaTargHab = ShufflePilaHabitaciones(pilaTargHab);

        //matriz grid
        CreaMatriz();
        CreaHabitacionInicio();
        camara.target = grid[9][9].transform;
    }

    
    void Update()
    {
        //posicion inicial
        int a = x;
        int b = y;

        if (Input.GetKeyDown(KeyCode.UpArrow))//arriba
        {
            a--;
            //a = Mathf.Clamp(a, 0, 19);
            a = ((a < 0) ? a + 1 : a);

            InstanciaHabitacion(a, b);//solo instancia si todavia hay tarjetas en la pila

            //solo se mueve la camara por habitaciones creadas
            camara.target = (grid[a][b] == null) ? camara.target : grid[a][b].transform;

            x = a;
            y = b;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))//abajo
        {
            a++;
            //a = Mathf.Clamp(a, 0, 19);
            a = (a % 19 == 0) ? a - 1 : a;

            InstanciaHabitacion(a, b);//solo instancia si todavia hay tarjetas en la pila
            //solo se mueve la camara por habitaciones creadas
            camara.target = (grid[a][b] == null) ? camara.target : grid[a][b].transform;

            x = a;
            y = b;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))//izquierda
        {
            b--;
            //b = Mathf.Clamp(b, 0, 19);
            b = ((b < 0) ? b + 1 : b);

            InstanciaHabitacion(a, b);//solo instancia si todavia hay tarjetas en la pila
                                      //solo se mueve la camara por habitaciones creadas
            camara.target = (grid[a][b] == null) ? camara.target : grid[a][b].transform;

            x = a;
            y = b;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))//derecha
        {
            b++;
            //b = Mathf.Clamp(b, 0, 19);
            b = (b % 19 == 0) ? b - 1 : b;

            InstanciaHabitacion(a, b);//solo instancia si todavia hay tarjetas en la pila
                                      //solo se mueve la camara por habitaciones creadas
            camara.target = (grid[a][b] == null) ? camara.target : grid[a][b].transform;


            x = a;
            y = b;
        }
    }
}
