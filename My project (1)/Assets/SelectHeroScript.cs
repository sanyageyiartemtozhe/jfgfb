using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectHeroScript : MonoBehaviour
{
    public GameObject Panel;
    public GameObject Menu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Select()
    {
        Panel.SetActive(true);
        Menu.SetActive(false);
    }

    public void Select2()
    {
        Panel.SetActive(false);
        Menu.SetActive(true);
    }
}
