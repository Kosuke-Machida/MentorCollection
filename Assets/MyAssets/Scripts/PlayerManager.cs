using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
	public static PlayerManager instance;
	private int myMoney; // 所持金
	private List<MstCharacter> myMentors = new List<MstCharacter>(); //雇ったメンターの一覧
	private int myProductivity; //メンターの生産性の合計
	public int MyMoney
	{
		get { return myMoney; }
		set { myMoney = value; }
	}

	public int MyProductivity
	{
		get { return myProductivity; }
		set { myProductivity = value; }
	}
	public List<MstCharacter> MyMentors
	{
		get { return myMentors; }
	}

	void Start () {
		// singleton化する
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad (instance.gameObject);
		}

		// 生産性の初期値を2に設定
		myProductivity = 2;

		// 毎秒で生産性の分利益を上げるコルーチンをスタート
		StartCoroutine ("AutomaticProduce");
	}

	// 毎秒で生産性の分の利益を上げるコルーチン
	private IEnumerator AutomaticProduce ()
	{
		while (true)
		{
			myMoney += myProductivity / 2;
			yield return new WaitForSeconds (1f);
		}
    }
}

