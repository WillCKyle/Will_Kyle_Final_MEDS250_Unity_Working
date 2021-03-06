using UnityEngine;

public class NPCShooting : MonoBehaviour
{
	public GameObject target;
    public int damagePerShot = 20;
    public float timeBetweenBullets = 0.15f;
    public float range = 100f;


    float timer;
    Ray shootRay;
    RaycastHit shootHit;
    int playerMask;
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    AudioSource gunAudio;
    Light gunLight;
    float effectsDisplayTime = 0.2f;
	LayerMask empty = ~0;


    void Awake ()
    {
		target = GameObject.FindGameObjectWithTag ("Player");
        playerMask = LayerMask.GetMask ("Player");
		shootRay = new Ray ();
        gunParticles = GetComponent<ParticleSystem> ();
        gunLine = GetComponent <LineRenderer> ();
        gunAudio = GetComponent<AudioSource> ();
        gunLight = GetComponent<Light> ();
    }


    void Update ()
    {
        timer += Time.deltaTime;

		if(target!=null && TargetSightedInRange() && timer >= timeBetweenBullets && Time.timeScale != 0)
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
		Vector3 offset = new Vector3 (0f, -1f, 0f);
		shootRay.direction = ((target.transform.position + offset) - transform.position).normalized;

        if(Physics.Raycast (shootRay, out shootHit, range, empty)) 
        {
            gunLine.SetPosition (1, shootHit.point);
			if (shootHit.collider.gameObject.CompareTag("Player")
				|| shootHit.collider.gameObject.CompareTag("Shield")) {
				shootHit.collider.gameObject.GetComponent<CharacterHealth> ().TakeDamage (damagePerShot);
			}
        }
        else
        {
            gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
        }
    }

	bool TargetSightedInRange() {
		shootRay.origin = transform.position;
		shootRay.direction = (target.transform.position - transform.position).normalized;
		bool hitSomething = Physics.Raycast (shootRay, out shootHit, range, playerMask);
		if (hitSomething) {
			bool itsThePlayer = shootHit.collider.gameObject.CompareTag ("Player");
			if (itsThePlayer) {
				bool inRange = shootHit.distance <= range;
				if (inRange) {
					return true;
				}
			}
		}
		return false;
	}

}
