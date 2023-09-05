using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallControl : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Rigidbody rb;
    public bool isgrounded;
    int count;
    public Text CoinText;
    public GameObject Light;
    public GameObject Fast;
    public GameObject Slow;
    public bool selected = true;
    public GameObject ballDetect;
    public GameObject ballDetect2;
    public Mesh sp1, sp2;
    public float HighScore;
    public Text HighScoreText;


    private void Start()
    {
        rb =gameObject.GetComponent<Rigidbody>();
        isgrounded = false;
    }
    private void Update()
    {
        if (isgrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0f, 400f, 0f));
        }
        else
            rb.AddForce(new Vector3(0f, 0f, 0f));
        if (Input.GetAxis("Horizontal") > 0 )
        {
            rb.AddForce(Vector3.right * speed);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            rb.AddForce(-Vector3.right * speed);
        }
        if(Input.GetAxis("Vertical") < 0  )
        {
            rb.AddForce(-Vector3.forward * speed);
        }
        else if(Input.GetAxis("Vertical") > 0 )
        {
            rb.AddForce(Vector3.forward * speed); 
        }
        
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isgrounded=true;
        }
        if (collision.gameObject.tag == "Limit")
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (collision.gameObject.tag == "Finish")
        {
          
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (collision.gameObject.tag == "Coin")
        {
            count++;
            GameObject effect= Instantiate(Light,transform.position,transform.rotation);
            UpdateUI();
            
        }
        if(collision.gameObject.tag == "Speed" && selected == true)
        {
            GameObject f = Instantiate(Fast, transform.position, transform.rotation);
            GetComponent<MeshFilter>().mesh = sp2;
            speed =1.1f;
            selected=false;
            ballDetect.SetActive(false);
        }
        if (collision.gameObject.tag == "Slow" && selected==true)
        {
            GameObject s = Instantiate(Slow, transform.position, transform.rotation);
            GetComponent<MeshFilter>().mesh = sp1;
            speed =0.3f;  
            selected = false;
            ballDetect2.SetActive(false);
        }
    }
    private void OnCollisionExit(Collision collision) 
    {
        if(collision.gameObject.tag=="Ground")
        {

            isgrounded =false;
        }
        
       
    }
    public void UpdateUI()
    {
        CoinText.text=count.ToString();
    }

}
