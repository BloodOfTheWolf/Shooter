using UnityEngine;
using System.Collections;

public class ZombieController : MonoBehaviour 
{
	public float attackRange;
	public float attackDamage;

	public GameObject attackCollider;

	Animator animator;
	NavMeshAgent agent;
	GameObject target;

	int health;


	enum State
	{
		Idle,
		Chase,
		Attack,
		TakeDamage,
		Dead
	};

	State state;

	void Start()
	{
		animator = GetComponentInChildren<Animator>();
		agent = GetComponent<NavMeshAgent>();
	}

	void Update()
	{
		switch (state)
		{
		case State.Idle:
			UpdateIdle();
			break;
		case State.Chase:
			UpdateChase();
			break;
		case State.Attack:
			UpdateAttack();
			break;
		case State.TakeDamage:
			UpdateTakeDamage();
			break;
		case State.Dead:
			UpdateDead();
			break;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Player"))
	    {
			target = other.gameObject;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.CompareTag ("Player"))
		{
			target = null;
		}
	}

	void UpdateIdle()
	{
		if (target != null)
		{
			state = State.Chase;
			animator.SetBool("TargetSpottedBool", true);
		}

	}

	void UpdateChase()
	{
		if (target == null)
		{
			state = State.Idle;
			animator.SetBool("TargetSpottedBool", false);
		}
		else
		{
			float distance = Vector3.Distance (transform.position, target.transform.position);
			if (distance <= attackRange)
			{
				state = State.Attack;
				animator.SetTrigger("AttackTrigger");
				agent.Stop ();
			}
			else
			{
				agent.SetDestination(target.transform.position);
			}
		}
	}

	void UpdateAttack()
	{
		AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo (0);
		if (info.IsName("Main.Idle"))
		{
			state = State.Idle;
			animator.SetBool ("TargetSpottedBool", false);
		}
	}

	void UpdateTakeDamage()
	{

	}

	void UpdateDead()
	{

	}

	public void OnAttack()
	{
				if (target != null) {
						float distance = Vector3.Distance (transform.position, target.transform.position);

						if (distance <= attackRange) {
								target.SendMessage("TakeDamage", attackDamage);
								DamageHUD.Instance.OnPlayerHit();
						}
				}
		}
}
