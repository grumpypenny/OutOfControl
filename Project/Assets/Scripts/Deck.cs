using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;

[RequireComponent(typeof(Animator))]
public class Deck : MonoBehaviour
{
	private Animator anim;
	private bool open = false;

	public void Start()
	{
		anim = GetComponent<Animator>();
	}

	public void ToggleDeck()
	{
		open = !open;
		print(open);
		anim.SetBool("open", open);
	}
}

