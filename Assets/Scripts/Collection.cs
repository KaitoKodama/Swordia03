using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CC;


//------------------------------------------
// クラス
//------------------------------------------
[System.Serializable]
public class AnyDictionary<Tkey, Tvalue>
{
	public Tkey key;
	public Tvalue value;

	public AnyDictionary(Tkey key, Tvalue value)
	{
		this.key = key;
		this.value = value;
	}
	public AnyDictionary(KeyValuePair<Tkey, Tvalue> pair)
	{
		this.key = pair.Key;
		this.value = pair.Value;
    }
}
[System.Serializable]
public class ActorSet<T> where T : Pawn
{
	private List<Location> locations = new List<Location>()
	{
		new Location(new Vector3(3f, -2f, 0f), 0),
		new Location(new Vector3(5f, -3f, 0f), 1),
		new Location(new Vector3(6f, -1f, 0f), -1),
	};

	public List<Actor> actors = new List<Actor>();
	public delegate void OnRemoveActorComplete();
	public OnRemoveActorComplete OnRemoveActorCompleteHandler;


	public ActorSet(OnRemoveActorComplete handler)
    {
		OnRemoveActorCompleteHandler = handler;
	}
	public void Add(GameObject obj, SO_Param param, int index)
	{
		var loc = locations[index];
		var actor = obj.GetComponent<Actor>();
		actor.Init<T>(param, loc);
		actors.Add(actor);
	}
	public void Remove(Actor remove)
	{
		Utility.SetRemovedList(ref actors, remove, (el) => el != null);
		if (actors == null || actors.Count == 0)
        {
			OnRemoveActorCompleteHandler?.Invoke();
		}
	}
}
[System.Serializable]
public struct AbnormalStatus
{
	[SerializeField] AbnormalStatusType type;
	[SerializeField] int keep;
	[SerializeField] bool has;

	public AbnormalStatus(AbnormalStatusType type, int keep)
    {
		this.type = type;
		this.keep = keep;
		this.has = true;
    }
	public void UpdateKeepTime()
	{
		keep -= 1;
		if (keep <= 0)
			has = false;
	}
	public AbnormalStatusType Type => type;
	public bool Has => has;
	public int Keep => keep;
}
[System.Serializable]
public struct Location
{
	public Vector3 origin;
	public int depth;

	public Location(Vector3 origin, int depth)
    {
		this.origin = origin;
		this.depth = depth;
	}
}


//------------------------------------------
// インターフェイス
//------------------------------------------


//------------------------------------------
// 列挙
//------------------------------------------
public enum AbnormalStatusType
{
	Poison, Sleep, Palsy
}
public enum Role
{
	Player, Enemy
}


//------------------------------------------
// ユーティリティ
//------------------------------------------
namespace CC
{
	public static class Utility
	{
		public static TValue GetDICVal<TValue, TKey>(TKey component, List<AnyDictionary<TKey, TValue>> dics)
		{
			foreach (var dic in dics)
			{
				if (dic.key.Equals(component))
				{
					return dic.value;
				}
			}
			return default;
		}
		public static T GetNextEnum<T>(int currentEnum)
		{
			int nextIndex = currentEnum + 1;
			T nextEnum = (T)Enum.ToObject(typeof(T), nextIndex);
			int length = Enum.GetValues(typeof(T)).Length;
			if (nextIndex >= length)
			{
				nextEnum = (T)Enum.ToObject(typeof(T), 0);
			}
			return nextEnum;
		}
		public static T GetIntToEnum<T>(int targetInt)
		{
			T targetEnum = (T)Enum.ToObject(typeof(T), targetInt);
			return targetEnum;
		}
		public static T GetRndFromList<T>(List<T> list)
		{
			int i = UnityEngine.Random.Range(0, list.Count);
			return list[i];
		}
		public static void SetRemovedList<T>(ref List<T> list, T remove, Func<T, bool> predicate, Action<T> inLoop = null)
        {
			var tmpList = new List<T>();
			list.Remove(remove);
			foreach (var el in list)
            {
				if (inLoop != null) inLoop(el);
				if (predicate(el)) tmpList.Add(el);
			}
            list.Clear();
			list = tmpList;
		}
		public static void SetTrimmedList<T>(ref List<T> list, Func<T, bool> predicate, Action<T> inLoop = null)
		{
			var tmpList = new List<T>();
			foreach (var el in list)
			{
				if (inLoop != null) inLoop(el);
				if (predicate(el)) tmpList.Add(el);
			}
			list.Clear();
			list = tmpList;
		}
		public static bool Probability(float fPercent)
		{
			float fProbabilityRate = UnityEngine.Random.value * 100.0f;

			if (fPercent == 100.0f && fProbabilityRate == fPercent) return true;
			else if (fProbabilityRate < fPercent) return true;
			else return false;
		}
	}
}