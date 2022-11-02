using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
public struct LocationalStatus
{
	private Vector3 origin;
	private bool isFlipX;
	private int depth;


	public LocationalStatus(Vector3 origin, int depth, bool isFlipX = false)
    {
		this.origin = origin;
		this.depth = depth;
		this.isFlipX = isFlipX;
	}


	public void SetAsLeftSide()
    {
		origin.x *= -1;
		isFlipX = false;
	}
	public void SetAsRightSide()
    {
		isFlipX = true;
    }
	public Vector3 Origin => origin;
	public bool IsFlipX => isFlipX;
	public int Depth => depth;
}


//------------------------------------------
// インターフェイス
//------------------------------------------
public interface IApplyEffect
{
	void AddAbnormalStatus(AbnormalStatus status);
	void RemoveAbnormalStatus(AbnormalStatusType removeType);
	void ApplyHP(float value);
	void ApplyMP(float value);
	void ApplySpeed(float value);
	void ApplyPower(float value);
	void ApplyDefence(float value);
	void ApplySatisfactRate(float value);
	void ApplyEscapeRate(float value);
}


//------------------------------------------
// 列挙
//------------------------------------------
public enum AbnormalStatusType
{
	Poison, Sleep, Palsy
}
public enum RoleOfActor
{
	Player, Enemy
}


//------------------------------------------
// ユーティリティ
//------------------------------------------
namespace CMN
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
		public static List<T> GetTrimmedList<T>(List<T> list, T remove)
        {
			var tmpList = new List<T>();
			list.Remove(remove);
			foreach (var el in list)
				if (el != null)
					tmpList.Add(el);
			list.Clear();
			return tmpList;
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