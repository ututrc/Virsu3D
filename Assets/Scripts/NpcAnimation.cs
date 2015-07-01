using UnityEngine;
using System.Collections;

public class NpcAnimation : MonoBehaviour
{
	public int idleModes = 1;
	public float idleChangeMinTime = 2.0f;
	public float idleChangeMaxTime = 5.0f;

	public bool isTalking;

	protected Animator animator;
	protected float idleChangeTime;
	protected int idleCurrent;

	void Start ()
	{
		animator = GetComponent<Animator>();
		idleChangeTime = Random.Range(idleChangeMinTime,idleChangeMaxTime);
		idleCurrent = Random.Range(0,idleModes);
	}

	void Update ()
	{
		AnimatorStateInfo asf = animator.GetCurrentAnimatorStateInfo(0);
		if (asf.nameHash == Animator.StringToHash("Base Layer.Idle"))
		{
			idleChangeTime -= Time.deltaTime;
			if (idleChangeTime <= 0.0f)
			{
				idleCurrent = Random.Range(0,idleModes);
				idleChangeTime = Random.Range(idleChangeMinTime,idleChangeMaxTime);
			}
			animator.SetFloat("IdleType",idleCurrent,0.25f,Time.deltaTime);
		}

		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		animator.SetFloat("Speed",v);
		animator.SetFloat("Direction",h,0.25f,Time.deltaTime);

		animator.SetBool("IsTalking",isTalking);
	}
}