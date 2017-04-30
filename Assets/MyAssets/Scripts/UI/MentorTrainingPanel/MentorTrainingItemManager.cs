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

	public GameObject CreateItem (MstCharacter chara) //MentorTrainingItemを生成して初期設定
	{
		GameObject item = Instantiate(
						      _mentorTrainingItem,
							  _mentorRecluitItemContent.transform.position,
							  Quaternion.identity,
							  _mentorRecluitItemContent.transform
						  );

		// itemのMentorTrainingItemBehaviourを取得する
		MentorTrainingItemBehaviour mentorTrainingItemBehaviour = item.GetComponent<MentorTrainingItemBehaviour>();

		//Instantiateされたボタンにイベントをセット
		mentorTrainingItemBehaviour.SetButtonFunction(chara);

		// MentorTrainingItemBehaviourのクラス変数charaをセット
		mentorTrainingItemBehaviour.SetChara(chara);

		//MentorTrainingItemに値をセット
		mentorTrainingItemBehaviour.SetValues();

		return item;
	}
}
