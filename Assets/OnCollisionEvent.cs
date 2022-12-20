using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnCollisionEvent : MonoBehaviour
{
    public TankController TankScr;

    //audio
    public AudioSource BatteryPickup;
    public AudioSource RockCrumble;
    public AudioSource MetalBanging1;
    public AudioSource MetalBanging2;
    public AudioSource Jumpscare;

    //horror
    public GameObject HorrorCam;
    public Animator myAnimationController;
    public GameObject HorrorObject;


    public GameObject Creatura1;
    public GameObject Creatura2;
    public GameObject WallAfter2;
    public List<GameObject> Deathlines;

    private void Start()
    {
        BatteryPickup = BatteryPickup.GetComponent<AudioSource>();
        RockCrumble = RockCrumble.GetComponent<AudioSource>();
        MetalBanging1 = MetalBanging1.GetComponent<AudioSource>();
        MetalBanging2 = MetalBanging2.GetComponent<AudioSource>();
        Jumpscare = Jumpscare.GetComponent<AudioSource>();
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        HorrorCam.SetActive(false);
    }
    IEnumerator SpookExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        MetalBanging2.Pause();
    }
    
    IEnumerator GameRestart(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        SceneManager.LoadScene(0);
    }

    IEnumerator VictoryScreen(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        SceneManager.LoadScene(1);
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "EventTriggerTag":
                Destroy(other.gameObject);
                break;
            case "Battery":
                
                TankScr.batteryCharge++;
                TankScr.RenderBattery();
                BatteryPickup.Play();
                Destroy(other.gameObject);
                break;
            case "Battery 1":
                
                TankScr.batteryCharge++;
                TankScr.RenderBattery();
                BatteryPickup.Play();
                Destroy(other.gameObject);
                Creatura1.SetActive(true); 
                
                break;
            case "Battery 2":
                
                TankScr.batteryCharge++;
                TankScr.RenderBattery();
                BatteryPickup.Play();
                Destroy(other.gameObject);
                Creatura2.SetActive(true); //Creatura appears behind tonka
                WallAfter2.SetActive(false);
                //Wall crumble noises
                RockCrumble.Play();


                foreach(GameObject dLine in Deathlines)
                {
                    dLine.SetActive(true);
                }
                break;

            case "Battery 3":
                BatteryPickup.Play();
                TankScr.batteryCharge++;
                TankScr.RenderBattery();
                Destroy(other.gameObject);
                if(TankScr.Deathlined)
                {
                    //Ded
                    //fade to red (ur ded)
                    
                    myAnimationController.SetBool("playScare",true);
                    HorrorObject.SetActive(true);
                    Jumpscare.Play();
                    ///restart game after 5 seconds
                    StartCoroutine(GameRestart(6));

                }
                else
                {
                    StartCoroutine(VictoryScreen(2));
                    //You're winner
                    //fade to black with text you got out.
                }
                break;
            case "Creatura": //Touched passive creatura
                //Spooky dookie sound 
                MetalBanging2.Play();
                StartCoroutine(SpookExecuteAfterTime(5));
                

                other.gameObject.SetActive(false);
                break;
            case "CreaturaSpook": //Touched giga spook creatura
                //Spooky dookie sound
                MetalBanging1.Play();
                TankScr.DisengageControls();
                other.gameObject.SetActive(false);
                //Make spooky image
                //make object appear. Object destroyed when pickedup periscope.
                HorrorCam.SetActive(true);
                //wait x seconds
                StartCoroutine(ExecuteAfterTime(5));

                break;
            case "Deathline": //Touched creatura after crossing death line
                other.GetComponent<DeathLine>().Creatura.SetActive(true);
                TankScr.Deathlined = true;
                //Jumpscare maybie

                ////Ded
                ////fade to red (ur ded)
                //HorrorObject.SetActive(true);
                //myAnimationController.SetBool("playScare", true);
                //Jumpscare.Play();
                /////restart game after 5 seconds
                //StartCoroutine(GameRestart(6));
                break;

            default:
                break;
        }
    }
}
