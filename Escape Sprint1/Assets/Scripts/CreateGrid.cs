using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGrid : MonoBehaviour
{

    //public GameObject[] prefabs;
    //public GameObject prefab;
    public FollowTarget camara;
    private List<List<GameObject>> grid;
	private int x = 9, y = 9;
    private float tamano = 10;
    public GameObject hab_final;
    public GameObject hab_inicio;
    public GameObject hab_3;
    public GameObject hab_4;

    public List<int> pilaTargHab = new List<int>();



    void Awake(){

        CrearPilaHabitaciones();
        pilaTargHab = ShufflePilaHabitaciones(pilaTargHab);

        CrearMatriz();



        //GameObject hab_inicio = (GameObject)Instantiate(Resources.Load("Prefabs/Habitacion2/Habitacion2"));
        //GameObject hab_final = (GameObject)Instantiate(Resources.Load("Prefabs/Habitacion1/Habitacion1"));


        grid[9][9].GetComponent<MeshRenderer> ().enabled = true;

        camara.target = grid [9] [9].transform;
    }



    public void CrearPilaHabitaciones()
    {
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


    void CrearMatriz()
    {
        grid = new List<List<GameObject>>();

        for (int i = 0; i < 20; i++)
        {
            //Quaternion rot = Quaternion.EulerAngles(0, 90, 0);
            //GameObject cosa = (GameObject)Instantiate(Resources.Load("MiCosa"), transform.position + Vector3.zero, Quaternion.identity, transform);

            List<GameObject> row = new List<GameObject>();



            for (int j = 0; j < 20; j++)
            {

                // Creamos todas las habitaciones del grid como habitaciones de inicio, estas luego seran sustituidas.

                //GameObject prefab = prefabs[Random.Range(0, 5)];
                GameObject obj = Instantiate(hab_inicio);
                obj.transform.SetParent(this.transform);
                obj.GetComponent<MeshRenderer>().enabled = false;
                obj.transform.localPosition = new Vector3((float)j * tamano, 0f, -(float)i * tamano);
                row.Add(obj);
            }

            grid.Add(row);
        }


        // Activamos la habitacion de arriba y abajo.
        /*
        grid[9][8]  = AvanzarHabitacion(0);
        grid[9][10] = AvanzarHabitacion(180);
        */

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

    public GameObject CreaHabitacion(int id)
    {
        GameObject tipo = null;
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


    public int PopPila(List<int> pila)
    {
        int top = pila[0];
        pilaTargHab.RemoveAt(0);
        return top;
    }


    void AvanzarHabitacion(int rotacion)
    {
        int a = x;
        int b = y;

        // Significa que todavia quedan habitaciones en la pila.
        if (pilaTargHab.Count != 0)
        {
            int id = PopPila(pilaTargHab);
            GameObject habitacion = CreaHabitacion(id);

            switch (rotacion)
            {                
                // El caso 90 la habitacion nueva gira 90 grados Clockwise, flecha derecha.
                case 90:

                    b++;
                    b = Mathf.Clamp(b, 0, 19);

                    habitacion.transform.SetParent(this.transform);
                    habitacion.GetComponent<MeshRenderer>().enabled = true;
                    habitacion.transform.localPosition = new Vector3((float)b * tamano, 0f, -(float)a * tamano);

                    grid[a][b] = habitacion;
                    grid[a][b].GetComponent<Transform>().Rotate(0, 0, rotacion);

                    camara.target = grid[a][b].transform;
                    x = a;
                    y = b;


                    break;

                // El caso 180 la habitacion gira 180 g clockwise, flecha abajo.
                case 180:

                    a++;
                    a = Mathf.Clamp(a, 0, 19);

                    habitacion.transform.SetParent(this.transform);
                    habitacion.GetComponent<MeshRenderer>().enabled = true;
                    habitacion.transform.localPosition = new Vector3((float)b * tamano, 0f, -(float)a * tamano);

                    grid[a][b] = habitacion;
                    grid[a][b].GetComponent<Transform>().Rotate(0, 0, rotacion);


                    camara.target = grid[a][b].transform;
                    x = a;
                    y = b;



                    break;

                // El caso 270 la habitacon gira 270 g cw, flecha izquierda.
                case 270:

                    b--;
                    b = Mathf.Clamp(b, 0, 19);

                    habitacion.transform.SetParent(this.transform);
                    habitacion.GetComponent<MeshRenderer>().enabled = true;
                    habitacion.transform.localPosition = new Vector3((float)b * tamano, 0f, -(float)a * tamano);

                    grid[a][b] = habitacion;
                    grid[a][b].GetComponent<Transform>().Rotate(0, 0, rotacion);


                    camara.target = grid[a][b].transform;
                    x = a;
                    y = b;


                    break;

                // El caso 0 es cuando la habitacion no debe rotar, flecha arriba.
                default:

                    a--;
                    a = Mathf.Clamp(a, 0, 19);

                    habitacion.transform.SetParent(this.transform);
                    habitacion.GetComponent<MeshRenderer>().enabled = true;
                    habitacion.transform.localPosition = new Vector3((float)b * tamano, 0f, -(float)a * tamano);

                    grid[a][b] = habitacion;
                    grid[a][b].GetComponent<Transform>().Rotate(0, 0, rotacion);


                    camara.target = grid[a][b].transform;
                    x = a;
                    y = b;

                    break;
            }            
        }
    }




    void Update(){

		int a = x;
		int b = y;

		if (Input.GetKeyDown (KeyCode.UpArrow)) {
            /*
            a--;
			a = Mathf.Clamp (a, 0, 19);


			grid[a][b].GetComponent<MeshRenderer> ().enabled = true;
            //gira habitacion
            grid[a][b].GetComponent<Transform>().Rotate(0,0,90);
            camara.target = grid [a] [b].transform;
			x = a;
			y = b;
            */
            AvanzarHabitacion(0);


		}


		if (Input.GetKeyDown (KeyCode.DownArrow)) {

            /*

            a++;
			a = Mathf.Clamp (a, 0, 19);

			grid[a][b].GetComponent<MeshRenderer> ().enabled = true;
            grid[a][b].GetComponent<Transform>().Rotate(0, 0, 90);


            camara.target = grid [a] [b].transform;
			x = a;
			y = b;
            */

            AvanzarHabitacion(180);

        }

		if (Input.GetKeyDown (KeyCode.LeftArrow)) {

            /*

            b--;
			b = Mathf.Clamp (b, 0, 19);

			grid[a][b].GetComponent<MeshRenderer> ().enabled = true;


            camara.target = grid [a] [b].transform;
			x = a;
			y = b;
            */
            AvanzarHabitacion(270);
		}

		if (Input.GetKeyDown (KeyCode.RightArrow)) {


            /*
            b++;
			b = Mathf.Clamp (b, 0, 19);

			grid[a][b].GetComponent<MeshRenderer> ().enabled = true;

            camara.target = grid [a] [b].transform;
			x = a;
			y = b;
            */
            AvanzarHabitacion(90);
		}
	}


    

}