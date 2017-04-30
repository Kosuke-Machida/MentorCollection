using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MentorAvatorManager : MonoBehaviour {
	public static MentorAvatorManager instance;
	[SerializeField] private GameObject _mentorAvator;
	[SerializeField] Transform[] targets;
	public Transform[] Targets
	{
		get { return targets; }
		private set {}
	}

	void Start ()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad (instance.gameObject);
		}
	}

	public GameObject CreateMentorAvator (MstCharacter chara) // MentorのavatorをInstantiateするメソッド
	{
		// MentorのavatorをInstantiate
		var avator = Instantiate(
					     _mentorAvator
				     );

		// クラス変数charaをセット
		var mentorAvatorBehavior = avator.GetComponent<MentorAvatorBehavior>();
		mentorAvatorBehavior.SetChara(chara);

		// avatorの顔面を設定
		mentorAvatorBehavior.SetFaceImage();

		return avator;
	}
}
