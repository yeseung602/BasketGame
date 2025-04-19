using UnityEngine;

public class BasketController : MonoBehaviour
{
    public AudioClip applesound;
    public AudioClip bombsound;
    AudioSource AS;
    public GameObject GM;
    ItemGenerator IG;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //position -> x,y,z = 0,0,0
        transform.position = Vector3.zero;
        AS = GetComponent<AudioSource>();
        IG = GM.GetComponent<ItemGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x <1)
        {
            transform.position += Vector3.right;
        }

       if(Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x > -1)
        {
            transform.position += Vector3.left;
        }

        if(Input.GetKeyDown(KeyCode.UpArrow) && transform.position.z < 1)
        {
            transform.position += Vector3.forward;
        }

        if(Input.GetKeyDown(KeyCode.DownArrow) && transform.position.z > -1)
        {
            transform.position += Vector3.back;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("apple")) { 
            Debug.Log("apple"); 
            AS.PlayOneShot(applesound);
            IG.GetApple();
        }
        if (other.CompareTag("bomb")) { 
            Debug.Log("bomb"); 
            AS.PlayOneShot(bombsound);
            IG.GetBomb();
        }
        if (other.CompareTag("add"))
        {
            Debug.Log("add");
            AS.PlayOneShot(applesound);
            IG.GetTime();
        }
        Destroy(other.gameObject);
    }
}
