using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MentorTrainingItemManager : MonoBehaviour {
	public static MentorTrainingItemManager instance;
	[SerializeField] GameObject _mentorTrainingItem;
	[SerializeField] GameObject _mentorRecluitItemContent;

	void Start ()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad (instance.gameObject);
		}
 	}

	public void CreateItem (MstCharacter chara)
	{
		GameObject item = Instantiate(
						      _mentorTrainingItem,
							  _mentorRecluitItemContent.transform.position,
							  Quaternion.identity,
							  _mentorRecluitItemContent.transform
						  );

		// itemのMentorRecruitItemBehaviourを取得して値を入れていく
			MentorTrainingItemBehaviour mentorTrainingItemBehaviour = item.GetComponent<MentorTrainingItemBehaviour>();
			mentorTrainingItemBehaviour.SetValues(chara);
	}
}
