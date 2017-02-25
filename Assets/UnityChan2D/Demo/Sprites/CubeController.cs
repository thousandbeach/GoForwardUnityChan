using UnityEngine;
using System.Collections;

public class CubeController : MonoBehaviour {

	// キューブの移動速度
	private float speed = -0.2f;

	// 消滅位置
	private float deadLine = -10;

	// オーディオソースのオブジェクトを取得（音の出し方の情報）
	public AudioSource audioSource;

	// オーディクリップを取得（音自体の情報 音のファイル）
	public AudioClip grave;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		// キューブを移動させる
		transform.Translate(this.speed, 0, 0);

		// 画面外にでたら破滅する
		if(transform.position.x < this.deadLine){
			Destroy (gameObject);
		}
	}

	// 2Dの場合はコリジョンの後に2Dは必須
	void OnCollisionEnter2D(Collision2D other){
		// グラウンドタグかキューブタグに衝突したときに音をならす unity側でタグを設定しておく
		if(other.transform.tag == "GroundTag" || other.transform.tag == "CubeTag"){
			audioSource.PlayOneShot (grave);
		}
	}

}
