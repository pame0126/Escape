using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JasonHasHere : MonoBehaviour {

    //
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
   
    private int randomHab;

   

    void Awake()
    {

        //GameObject hab_inicio = (GameObject)Instantiate(Resources.Load("Prefabs/Habitacion2/Habitacion2"));
        //GameObject hab_final = (GameObject)Instantiate(Resources.Load("Prefabs/Habitacion1/Habitacion1"));

        

        grid = new List<List<GameObject>>();

        for (int i = 0; i < 20; i++)
        {
            //Quaternion rot = Quaternion.EulerAngles(0, 90, 0);
            //GameObject cosa = (GameObject)Instantiate(Resources.Load("MiCosa"), transform.position + Vector3.zero, Quaternion.identity, transform);

            List<GameObject> row = new List<GameObject>();



            for (int j = 0; j < 20; j++)
            {
                //GameObject prefab = prefabs[Random.Range(0, 5)];
                //GameObject obj = Instantiate(hab_final);
                //bj.transform.SetParent(this.transform);
                if (i == 9 && j == 9)
                {
                    GameObject objI = Instantiate(hab_inicio);
                    objI.transform.SetParent(this.transform);
                    objI.GetComponent<MeshRenderer>().enabled = true;
                    objI.transform.localPosition = new Vector3((float)j * tamano, 0f, -(float)i * tamano);
                    row.Add(objI);
                    
                }
                else
                {
                    randomHab = Random.Range(1, 3);
                    switch (randomHab)
                    {
                        case 1:
                            GameObject objF = Instantiate(hab_final);
                            objF.transform.SetParent(this.transform);
                            objF.GetComponent<MeshRenderer>().enabled = false;
                            objF.transform.localPosition = new Vector3((float)j * tamano, 0f, -(float)i * tamano);
                            row.Add(objF);
                            break;
                        case 2:
                            GameObject obj3 = Instantiate(hab_3);
                            obj3.transform.SetParent(this.transform);
                            obj3.GetComponent<MeshRenderer>().enabled = false;
                            obj3.transform.localPosition = new Vector3((float)j * tamano, 0f, -(float)i * tamano);
                            row.Add(obj3);
                            break;
                        case 3:
                            GameObject obj4 = Instantiate(hab_4);
                            obj4.transform.SetParent(this.transform);
                            obj4.GetComponent<MeshRenderer>().enabled = false;
                            obj4.transform.localPosition = new Vector3((float)j * tamano, 0f, -(float)i * tamano);
                            row.Add(obj4);
                            break;

                    }
                    /*
                    obj.GetComponent<MeshRenderer>().enabled = false;
                    obj.transform.localPosition = new Vector3((float)j * tamano, 0f, -(float)i * tamano);
                    row.Add(obj);
                    */
                }


            }

            grid.Add(row);
        }
        //grid[9][9].GetComponent<MeshRenderer> ().enabled = true;

        camara.target = grid[9][9].transform;
    }




    void Update()
    {

        int a = x;
        int b = y;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {



            grid[a][b].GetComponent<MeshRenderer>().material.color = Color.white;

            a--;
            a = Mathf.Clamp(a, 0, 19);


            grid[a][b].GetComponent<MeshRenderer>().enabled = true;
            //gira habitacion
            grid[a][b].GetComponent<Transform>().Rotate(0, 0, 90);
            grid[a][b].GetComponent<MeshRenderer>().material.color = Color.green;
            camara.target = grid[a][b].transform;
            x = a;
            y = b;
        }


        if (Input.GetKeyDown(KeyCode.DownArrow))
        {

            grid[a][b].GetComponent<MeshRenderer>().material.color = Color.white;


            a++;
            a = Mathf.Clamp(a, 0, 19);

            grid[a][b].GetComponent<MeshRenderer>().enabled = true;
            grid[a][b].GetComponent<Transform>().Rotate(0, 0, 90);

            grid[a][b].GetComponent<MeshRenderer>().material.color = Color.green;


            camara.target = grid[a][b].transform;
            x = a;
            y = b;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            grid[a][b].GetComponent<MeshRenderer>().material.color = Color.white;


            b--;
            b = Mathf.Clamp(b, 0, 19);

            grid[a][b].GetComponent<MeshRenderer>().enabled = true;

            grid[a][b].GetComponent<MeshRenderer>().material.color = Color.green;


            camara.target = grid[a][b].transform;
            x = a;
            y = b;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            grid[a][b].GetComponent<MeshRenderer>().material.color = Color.white;


            b++;
            b = Mathf.Clamp(b, 0, 19);

            grid[a][b].GetComponent<MeshRenderer>().enabled = true;

            grid[a][b].GetComponent<MeshRenderer>().material.color = Color.green;

            camara.target = grid[a][b].transform;
            x = a;
            y = b;
        }
    }
}
