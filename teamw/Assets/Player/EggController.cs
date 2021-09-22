using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
 
public class EggController : MonoBehaviour {
 
	private Animator animator;
	private Vector3 latestPos;  //前回のPosition
	public bool isTouch;
	public float walkSpeed;
	public float _speed;
	[SerializeField]
	private Vector3 velocity;
	//　入力値
	private Vector3 input;
	//　rigidbody
	private Rigidbody rigid;
	//　地面に接地しているかどうか
	[SerializeField]
	private bool isGrounded;
	//　衝突しているかどうか
	[SerializeField]
	private bool isCollision;
	//　接地確認のコライダの位置のオフセット
	[SerializeField]
	private Vector3 groundPositionOffset = new Vector3(0f, 0.02f, 0f);
	//　接地確認の球のコライダの半径
	[SerializeField]
	private float groundColliderRadius = 0.29f;
	//　衝突確認のコライダの位置のオフセット
	[SerializeField]
	private Vector3 collisionPositionOffset = new Vector3(0f, 0.5f, 0.1f);
	//　衝突確認の球のコライダの半径
	[SerializeField]
	private float collisionColliderRadius = 0.3f;
 
	void Start() {
		animator = GetComponent<Animator>();
		rigid = GetComponent<Rigidbody>();
		isTouch = false;
		isCollision = false;
		isGrounded = true;
		//　歩く速さ
	    walkSpeed = 4.5f;
	}
 
 
	void Update() {
		if (isGrounded && !isTouch) {
			velocity = Vector3.zero;
            input.x = Input.GetAxis("Horizontal");
			input.z = Input.GetAxis("Vertical");
			input.Normalize();
 
			//　方向キーが多少押されている
			if (input.magnitude > 0f) {
				animator.SetFloat("Speed", input.magnitude);
				transform.LookAt(rigid.position + input);
 
				velocity = rigid.transform.forward * walkSpeed;
				//　キーの押しが小さすぎる場合は移動しない
			} else {
				animator.SetFloat("Speed", 0f);
			}
        }
		
		Vector3 diff = transform.position - latestPos;   //前回からどこに進んだかをベクトルで取得
        latestPos = transform.position;  //前回のPositionの更新

        //ベクトルの大きさが0.01以上の時に向きを変える処理をする
        if ((diff.magnitude > 0.01f) && !isTouch)
        {
            transform.rotation = Quaternion.LookRotation(diff); //向きを変更する
        }
		

		//　接触していたら移動方向の値は0にする
		if (!isGrounded && isCollision && isTouch) {
			velocity = new Vector3(0f, 0, 0f);
        }
	}
 
	void FixedUpdate() {
		if(isGrounded && !isTouch)
		{		
		    // カメラの方向から、X-Z平面の単位ベクトルを取得
            Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
 
            // 方向キーの入力値とカメラの向きから、移動方向を決定
            Vector3 moveForward = cameraForward * Input.GetAxis("Vertical") + Camera.main.transform.right * Input.GetAxis("Horizontal");
            // 移動方向にスピードを掛ける。
            rigid.velocity = moveForward * walkSpeed;
		}

		if (isCollision && isTouch) {
			velocity = new Vector3(0f, 0f, 0f);
		}
	}
 
	private void OnCollisionEnter(Collision collision) {
		//　指定したコライダと接触、かつ接触確認コライダと接触していたら衝突状態にする
		if (Physics.CheckSphere(rigid.position + transform.up * collisionPositionOffset.y + transform.forward * collisionPositionOffset.z, collisionColliderRadius, ~LayerMask.GetMask("Player"))) {
				isCollision = true;
		}
		//生き物とぶつかったらアニメーションを再生して操作できなくする
        Debug.Log("hit");
        foreach (ContactPoint point in collision.contacts)
        {
            Vector3 relativePoint = transform.InverseTransformPoint(point.point);

            if (collision.gameObject.CompareTag("Animal") && (relativePoint.x > 0.2)){
                Debug.Log("Right");
				isTouch = true;	
				animator.SetTrigger("HitBack");
			}


            else if (collision.gameObject.CompareTag("Animal") && (relativePoint.x < -0.2)){
                Debug.Log("Left");
			    isTouch = true;
				animator.SetTrigger("HitForward");
			}

            if (collision.gameObject.CompareTag("Animal") && (relativePoint.z > 0.2)){
                Debug.Log("Forward");
				isTouch = true;
				animator.SetTrigger("HitForward");
			}

            else if (collision.gameObject.CompareTag("Animal") && (relativePoint.z < -0.2)){
                Debug.Log("Back");
				isTouch = true;
				animator.SetTrigger("HitBack");
			}

            if (collision.gameObject.CompareTag("Human") && (relativePoint.x > 0.2)){
                Debug.Log("Right");
				isTouch = true;
				animator.SetTrigger("HitBack");
			}


            else if (collision.gameObject.CompareTag("Human") && (relativePoint.x < -0.2)){
                Debug.Log("Left");
			    isTouch = true;
				animator.SetTrigger("HitForward");
			}

            if (collision.gameObject.CompareTag("Human") && (relativePoint.z > 0.2)){
                Debug.Log("Forward");
				isTouch = true;
				animator.SetTrigger("HitForward");
			}

            else if (collision.gameObject.CompareTag("Human") && (relativePoint.z < -0.2)){
                Debug.Log("Back");
				isTouch = true;
				animator.SetTrigger("HitBack");
			}

			//動物とぶつかったらエンド2へ
			if (collision.gameObject.CompareTag("Animal") && (animator.GetCurrentAnimatorStateInfo(0).IsName("DeathForward") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.38f)|| (animator.GetCurrentAnimatorStateInfo(0).IsName("DeathBack") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.38f))
            {
				SceneManager.LoadScene("sub2");
				isTouch = true;
				isCollision= true;
            }

			//人間とぶつかったらエンド3へ
			if (collision.gameObject.CompareTag("Human") && (animator.GetCurrentAnimatorStateInfo(0).IsName("DeathForward") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.38f)|| (animator.GetCurrentAnimatorStateInfo(0).IsName("DeathBack") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.38f))
            {
				SceneManager.LoadScene("sub");
				isTouch = true;
				isCollision= true;
            }

			if(collision.gameObject.name =="SpeedItem")
			{
				walkSpeed = 4f * 1.2f;
			}
			if(collision.gameObject.name =="SpeedItema")
			{
				walkSpeed = 4f * 1.2f * 1.2f;
			}
            if(collision.gameObject.name =="SpeedItemb")
			{
				walkSpeed = 4f * 1.2f * 1.2f * 1.2f;
			}
		}
	}
 
 
	void OnDrawGizmos() {
		//　接地確認のギズモ
		Gizmos.DrawWireSphere(transform.position + groundPositionOffset, groundColliderRadius);
		Gizmos.color = Color.blue;
		//　衝突確認のギズモ
		Gizmos.DrawWireSphere(transform.position + transform.up * collisionPositionOffset.y + transform.forward * collisionPositionOffset.z, collisionColliderRadius);
	}	
}
 