using UnityEngine;
using System.Collections;

public class LevelButton : MonoBehaviour {

    public int levelNo;

	void Start () 
    {
        transform.FindChild("Text").GetComponent<TextMesh>().text = name;
	
	}

    void OnMouseDown()
    {
        Application.LoadLevel(int.Parse(name));
    }
}
