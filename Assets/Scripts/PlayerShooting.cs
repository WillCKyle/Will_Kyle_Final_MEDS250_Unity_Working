using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
	private GameObject gameController;
	private GameControl gameControl;
    public int damagePerShot = 20;
    public float timeBetweenBullets = 0.15f;
    public float range = 100f;
	public int ammo = 100;


    float timer;
    Ray shootRay;
    RaycastHit shootHit;
    int npcMask;
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    AudioSource gunAudio;
    Light gunLight;
    float effectsDisplayTime = 0.2f;


    void Awake ()
    {
		gameController = GameObject.FindGameObjectWithTag ("GameController");
        npcMask = LayerMask.GetMask ("NPC");
		shootRay = new Ray ();
        gunParticles = GetComponent<ParticleSystem> ();
        gunLine = GetComponent <LineRenderer> ();
        gunAudio = GetComponent<AudioSource> ();
        gunLight = GetComponent<Light> ();
		gameControl = gameController.GetComponent<GameControl> ();
    }


    void Update ()
    {
        timer += Time.deltaTime;

		if(Input.GetButton ("Fire1") && ammo > 0 && timer >= timeBetweenBullets && Time.timeScale != 0)
        {
            Shoot ();
        }

        if(timer >= timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects ();
        }
    }


    public void DisableEffects ()
    {
        gunLine.enabled = false;
        gunLight.enabled = false;
    }


    void Shoot ()
    {
        timer = 0f;

        gunAudio.Play ();

        gunLight.enabled = true;

        gunParticles.Stop ();
        gunParticles.Play ();

        gunLine.enabled = true;
        gunLine.SetPosition (0, transform.position);

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        if(Physics.Raycast (shootRay, out shootHit, range, npcMask))
        {
            gunLine.SetPosition (1, shootHit.point);
			shootHit.collider.gameObject.GetComponent<CharacterHealth> ().TakeDamage (damagePerShot);
        }
        else
        {
            gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
        }
		ammo--;
		gameControl.ReportPlayerAmmo (ammo);
    }
}
