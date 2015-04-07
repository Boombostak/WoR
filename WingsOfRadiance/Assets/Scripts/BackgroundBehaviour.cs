using UnityEngine;
using System.Collections;

public class BackgroundBehaviour : MonoBehaviour {

	//vertical scrolling
    //linking to n appropriate backgrounds

    public GameObject[] bg_options;
    public int bg_rng;
    public GameObject bg_selection;
    public float scrollspeed = 10;
    public Vector3 offset;
    
    // Use this for initialization
	void Start () {
        bg_rng = Random.Range(0, bg_options.Length);
        bg_selection = bg_options[bg_rng];
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(0, -scrollspeed * Time.deltaTime, 0);

        if (this.transform.position.y < -25f)
        {
            Destroy(this.gameObject);
        }
	}

    void OnBecameVisible()
    {
        offset = new Vector3(0, this.transform.position.y + this.GetComponent<SpriteRenderer>().bounds.size.y, 0);
        Instantiate(bg_selection, offset, this.transform.rotation);
    }
}
