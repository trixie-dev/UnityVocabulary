using UnityEngine;
using UnityEngine.UI;

public class Switch : MonoBehaviour
{
    GameObject on;
    GameObject off;
    public DB db;
    public Text status;
    void Start()
    {
        DB db = GameObject.Find("MenuManager").GetComponent<DB>();
        db.method = 1;
        on = GameObject.Find("SwitchON");
        off = GameObject.Find("SwitchOFF");

    }

    

    public void ON()
    {
        DB db = GameObject.Find("MenuManager").GetComponent<DB>();
        db.method = 1;
        on.SetActive(false);
        off.SetActive(true);
        status.color = new Color(255, 255, 255);
        status.text = "English -> Ukrainian ";





    }
    public void OFF()
    {
        
        
        
        
        DB db = GameObject.Find("MenuManager").GetComponent<DB>();
        db.method = 0;
        on.SetActive(true);
        off.SetActive(false);
        status.text = "Ukrainian -> English ";
        // 116 195 58
        status.color = new Color(116f / 255f, 195f / 255f, 58f / 255f);



    }
}
