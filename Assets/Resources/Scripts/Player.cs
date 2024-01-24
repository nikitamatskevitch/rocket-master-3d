using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float tiltAngle = 30f;
    
    public int coal = 0;
    public int metal = 0;
    public int phosphor = 0;
    public int uran = 0;
    
    public GameObject first_rocket; //0 coal
    public GameObject second_rocket; //50 coal
    public GameObject third_rocket; //100 coal
    public GameObject fourth_rocket; //50 metal
    public GameObject fifth_rocket; //100   metal
    public GameObject sixth_rocket; //15pc phosphor
    public GameObject seventh_rocket; //15pc uran
    public GameObject eighth_rocket; //25pc uran

    public GameObject explosion;

    private void Update()
    {

        if(coal < 50 && metal < 50 && phosphor < 15 && uran < 15 && speed > 0){
            first_rocket.SetActive(true);
            second_rocket.SetActive(false);
            third_rocket.SetActive(false);
            fourth_rocket.SetActive(false);
            fifth_rocket.SetActive(false);
            sixth_rocket.SetActive(false);
            seventh_rocket.SetActive(false);
            eighth_rocket.SetActive(false);
        }

        if(coal >= 50 && coal < 100 && metal < 50 && phosphor < 15 && uran < 15 && speed > 0){
            first_rocket.SetActive(false);
            second_rocket.SetActive(true);
            third_rocket.SetActive(false);
            fourth_rocket.SetActive(false);
            fifth_rocket.SetActive(false);
            sixth_rocket.SetActive(false);
            seventh_rocket.SetActive(false);
            eighth_rocket.SetActive(false);
        }

        if(coal >= 100 && metal < 50 && phosphor < 15 && uran < 15 && speed > 0){
            first_rocket.SetActive(false);
            second_rocket.SetActive(false);
            third_rocket.SetActive(true);
            fourth_rocket.SetActive(false);
            fifth_rocket.SetActive(false);
            sixth_rocket.SetActive(false);
            seventh_rocket.SetActive(false);
            eighth_rocket.SetActive(false);
        }

        if(metal >= 50 && metal < 100 && phosphor < 15 && uran < 15 && speed > 0){
            first_rocket.SetActive(false);
            second_rocket.SetActive(false);
            third_rocket.SetActive(false);
            fourth_rocket.SetActive(true);
            fifth_rocket.SetActive(false);
            sixth_rocket.SetActive(false);
            seventh_rocket.SetActive(false);
            eighth_rocket.SetActive(false);
        }

        if(metal >= 100 && phosphor < 15 && uran < 15 && speed > 0){
            first_rocket.SetActive(false);
            second_rocket.SetActive(false);
            third_rocket.SetActive(false);
            fourth_rocket.SetActive(false);
            fifth_rocket.SetActive(true);
            sixth_rocket.SetActive(false);
            seventh_rocket.SetActive(false);
            eighth_rocket.SetActive(false);
        }

        if(phosphor >= 15 && uran < 15 && speed > 0){
            first_rocket.SetActive(false);
            second_rocket.SetActive(false);
            third_rocket.SetActive(false);
            fourth_rocket.SetActive(false);
            fifth_rocket.SetActive(false);
            sixth_rocket.SetActive(true);
            seventh_rocket.SetActive(false);
            eighth_rocket.SetActive(false);
        }

        if(uran >= 15 && uran < 25 && speed > 0){
            first_rocket.SetActive(false);
            second_rocket.SetActive(false);
            third_rocket.SetActive(false);
            fourth_rocket.SetActive(false);
            fifth_rocket.SetActive(false);
            sixth_rocket.SetActive(false);
            seventh_rocket.SetActive(true);
            eighth_rocket.SetActive(false);
        }

        if(uran >= 25 && speed > 0){
            first_rocket.SetActive(false);
            second_rocket.SetActive(false);
            third_rocket.SetActive(false);
            fourth_rocket.SetActive(false);
            fifth_rocket.SetActive(false);
            sixth_rocket.SetActive(false);
            seventh_rocket.SetActive(false);
            eighth_rocket.SetActive(true);
        }

       
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

       
        float horizontalMovement = Input.touchCount > 0 ? 
            Input.GetTouch(0).position.x < Screen.width / 2 ? -1f : 1f :
            Input.GetAxis("Horizontal");

        
        Vector3 sideMovement = new Vector3(horizontalMovement, 0f, 0f) * speed * Time.deltaTime;

        
        transform.Translate(sideMovement);

       
        //float tilt = horizontalMovement * tiltAngle;
        //transform.rotation = Quaternion.Euler(0f, 0f, -tilt);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("obstacle"))
        {
            //Time.timeScale = 0f;
            
            Debug.Log("Столкновение с препятствием!");
            speed = 0;

            first_rocket.SetActive(false);
            second_rocket.SetActive(false);
            third_rocket.SetActive(false);
            fourth_rocket.SetActive(false);
            fifth_rocket.SetActive(false);
            sixth_rocket.SetActive(false);
            seventh_rocket.SetActive(false);
            eighth_rocket.SetActive(false);

            explosion.SetActive(true);

            speed = 0;
        }

        if (other.CompareTag("coal"))
        {
            coal += 3;
            other.gameObject.SetActive(false);
        }

        if (other.CompareTag("metal"))
        {
            metal += 5;
            other.gameObject.SetActive(false);
        }

        if (other.CompareTag("phosphor"))
        {
            phosphor += 3;
            other.gameObject.SetActive(false);
        }

        if (other.CompareTag("uran"))
        {
            uran += 3;
            other.gameObject.SetActive(false);
        }
    }
}
