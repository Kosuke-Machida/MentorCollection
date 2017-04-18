using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MentorRecluitItemManager : MonoBehaviour {

[SerializeField] private MasterDataManager _masterDataManager;
[SerializeField] private GameObject _content;
[SerializeField] private GameObject _mentorRecluitItem;
[SerializeField] private Image _mentorImage;
[SerializeField] private Text _mentorName;
[SerializeField] private Text _mentorExplanation;
[SerializeField] private Text _mentorProductionLevel;
[SerializeField] private Button _mentorRecruitButton;

private List<MstCharacter> _characterTable;
	void Start ()
	{

		// MasterDataManagerにマッピングされたデータを表示していく
		 SetUpAllMentorRecluitItem();
	}

	private void SetUpAllMentorRecluitItem ()
	{
		// キャラクターデータのListを入手
		_characterTable = _masterDataManager.CharacterTable;

		// 入れ物の変数itemを定義
		GameObject item;

		// foreach文回す時のindexを定義
		foreach (MstCharacter chara in _characterTable)
		{
			// 各変数のの中身をリセット（nullにする）
			// うまく動けば必要ないコードだが、バグが出た時に同じ値の入ったPrefabがInstantiateされるのを防ぐ
							  item = null;
					   _mentorName = null;
				_mentorExplanation = null;
			_mentorProductionLevel = null;

			// itemにInstantiateしたMentorRecluitItemを入れる
			item = 	Instantiate(
						_mentorRecluitItem,
						_content.transform.position,
						Quaternion.identity,
						_content.transform
					);
			// _mentorName = item.transform.FindChild ("MentorName").gameObject.GetComponent<Text>();
			// _mentorExplanation = item.transform.FindChild ("MentoExplanation").gameObject.GetComponent<Text>();
			// _mentorName = item.transform.FindChild ("MentorRecruitButton").gameObject.GetComponent<Text>();

		}
	}

}
