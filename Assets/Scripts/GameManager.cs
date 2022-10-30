using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	//[SerializeField] List<int> containmentIDs;
	[SerializeField] List<int> selectedIDs;


	//------------------------------------------
	// シングルトン
	//------------------------------------------
	static public GameManager instance;

    private void Awake()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}


	//------------------------------------------
	// 外部共有関数
	//------------------------------------------
	public List<int> SelectedIDs => selectedIDs;
}
