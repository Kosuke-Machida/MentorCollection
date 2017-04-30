using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MentorAvatorBehavior : MonoBehaviour {
	[SerializeField] private GameObject faceImage;
	[SerializeField] private NavMeshAgent agent;
	[SerializeField] private GameObject diveCamera;
	[SerializeField] private GameObject face;
	private MstCharacter chara;
	private Transform target;
	private Transform[] targets;
	private int currentTarget;
	private Sprite faceImageSource;

	public GameObject DiveCamera
	{
		get { return diveCamera; }
		private set {}
	}

	void Start ()
	{
		var agent = GetComponent<NavMeshAgent>();
		targets = MentorAvatorManager.instance.Targets;
		currentTarget = Random.Range(0, 7);
		target = targets[currentTarget];
	}

	void Update ()
	{
		agent.SetDestination(target.position);

		if (Vector3.Distance(transform.position, target.position) < 1) {
            if (currentTarget < targets.Length - 1) {
                currentTarget += 1;
            }
            else {
                currentTarget = 0;
            }
        }

        target = targets[currentTarget];

        if (target != null) {
            agent.SetDestination (target.position);
        }
	}

	public void SetChara (MstCharacter _chara)
	{
		chara = _chara;
	}
	public void SetFaceImage ()
	{
		var spriteRenderer = faceImage.GetComponent<SpriteRenderer>();
		faceImageSource = Resources.Load<Sprite>("Face/" + chara.ImageId);
		spriteRenderer.sprite = faceImageSource;
	}

	public void StartVRView ()
	{
		CameraManager.instance.SwitchFromMainToVive(gameObject);
		faceImage.GetComponent<SpriteRenderer>().enabled = false;
		face.GetComponent<MeshRenderer>().enabled = false;
	}

	public void FinishVRView ()
	{
		CameraManager.instance.SwitchFromDiveToMain();
		faceImage.GetComponent<SpriteRenderer>().enabled = true;
		face.GetComponent<MeshRenderer>().enabled = true;
	}
}
