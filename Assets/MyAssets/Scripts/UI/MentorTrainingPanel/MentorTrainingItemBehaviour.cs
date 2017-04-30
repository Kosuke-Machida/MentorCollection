using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MentorTrainingItemBehaviour : MonoBehaviour {

    [SerializeField] private Image _mentorImage;
	[SerializeField] private Text _mentorName;
	[SerializeField] private Text _mentorLevel;
	[SerializeField] private Text _mentorLowerEnergy;
	[SerializeField] private Text _mentorRarity;
	[SerializeField] private Text _mentorTrainingCostValue;
	[SerializeField] private Button _mentorDiscriptionButton;
	[SerializeField] private Button _mentorVRViewButton;
	[SerializeField] private Button _mentorTrainingButton;

	private MstCharacter chara;
	private GameObject avator;

	void Update ()
	{
		// もしメンターのレベルが最大レベルより小さく
		if (chara.Level < chara.MaxLebel)
		{
			// 所持金が雇用にかかる金額よりも大きい場合
			if (PlayerManager.instance.MyMoney >= chara.InitialCost)
			{
				_mentorTrainingButton.interactable = true;
			}
		}
	}

	public void SetChara (MstCharacter _chara) //クラス変数charaにメンター情報をセット
	{
		chara = _chara;
	}

	public void SetAvator (GameObject _avator) //クラス変数avatorにメンター情報をセット
	{
		avator =  _avator;
	}

	public void SetValues () // MentorRecruitItemの値を入れていくメソッド
    {
		_mentorImage.sprite = Resources.Load<Sprite>("Face/" + chara.ImageId);
        _mentorName.text = chara.Name;
		_mentorLevel.text = "LV. " + chara.Level;
		_mentorRarity.text = "";

		// Rarityはint型なのでfor文を回して値の数だけ"★"を入れる
		for (int i = 0; i < chara.Rarity; i++)
		{
			_mentorRarity.text += "★";
		}

		_mentorLowerEnergy.text = "生産性(lv." + chara.Level + ")：" + chara.Power.ToString();
		_mentorTrainingCostValue.text = string.Format("¥{0:#,0}", chara.InitialCost);
    }

	public void SetButtonFunction (MstCharacter chara) //InstantiateされたButtonにListernerを定義する
	{
		// Trainingボタンにアクションを追加
		_mentorTrainingButton.onClick.AddListener (() => {

			// 所持金からレベル上げに使う金額を差し引く
			PlayerManager.instance.MyMoney -= chara.InitialCost;

			// メンターをレベルアップ
			chara.LevelUp();

			// powerを計算しなおす
			chara.CaluculatePower();

			//Playerの生産性を計算し直す
			PlayerManager.instance.CaluculateMyProductivity();

			//Itemの値を設定し直す
			SetValues();

			// レベル上げボタンを無効にする
			_mentorTrainingButton.interactable = false;

			// もしレベルが上限に達したらテキストを"MAX LEVEL"に変更する
			if (chara.Level >= chara.MaxLebel)
			{
				_mentorTrainingCostValue.text = "MAX LEVEL";
			}

        });

		// Discriptionボタンにアクションを追加
		_mentorDiscriptionButton.onClick.AddListener (() => {

        });

		// VRViewボタンにアクションを追加
		_mentorVRViewButton.onClick.AddListener (() => {
			avator.GetComponent<MentorAvatorBehavior>().SwitchCameraToDive();
        });
	}

}
