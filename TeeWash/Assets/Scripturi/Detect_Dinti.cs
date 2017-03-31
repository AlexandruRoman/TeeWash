using UnityEngine;
using System.Collections;

public class Detect_Dinti : MonoBehaviour {

	public float jp1, jp2, jp3, jp4, jp5, ji1, ji2, ji3, ji4, ji5, jm1, jm2;
	public float sp1, sp2, sp3, sp4, sp5, si1, si2, si3, si4, si5, sm1, sm2;

	public GameObject Bila, Gura, Gingie;

	public ParticleSystem sist;

	bool ok_rot, ok_wash, ok_open;

	Vector3 old, delta;

	//Punctaje

	public Transform p1, p2, p3;
	public GameObject timp, scor;
	TextMesh text_timp, text_scor;

	float T;


	void Start () 
	{
		text_timp = timp.GetComponent<TextMesh>();
		text_scor = scor.GetComponent<TextMesh>();

		sist.transform.position = new Vector3(100,100,100);
	}

	void Update () 
	{
		if(Application.platform == RuntimePlatform.WindowsEditor)
		{

			T += Time.deltaTime;
			text_timp.text = (int)T + " sec";


			Ray raza = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;



			if(Physics.Raycast(raza, out hit, 10) && ok_wash && hit.collider.name != "Gingie_sus")
			{

				Bila.transform.position = hit.point;
				sist.transform.position = hit.point;


				if(hit.collider.name == "Jp1") jp1 += Time.deltaTime;
				else if(hit.collider.name == "Jp2") jp2 += Time.deltaTime;
				else if(hit.collider.name == "Jp3") jp3 += Time.deltaTime;
				else if(hit.collider.name == "Jp4") jp4 += Time.deltaTime;
				else if(hit.collider.name == "Jp5") jp5 += Time.deltaTime;
				else if(hit.collider.name == "Ji1") ji1 += Time.deltaTime;
				else if(hit.collider.name == "Ji2") ji2 += Time.deltaTime;
				else if(hit.collider.name == "Ji3") ji3 += Time.deltaTime;
				else if(hit.collider.name == "Ji4") ji4 += Time.deltaTime;
				else if(hit.collider.name == "Ji5") ji5 += Time.deltaTime;
				else if(hit.collider.name == "Jm1") jm1 += Time.deltaTime;
				else if(hit.collider.name == "Jm2") jm2 += Time.deltaTime;

				else if(hit.collider.name == "Sp1") sp1 += Time.deltaTime;
				else if(hit.collider.name == "Sp2") sp2 += Time.deltaTime;
				else if(hit.collider.name == "Sp3") sp3 += Time.deltaTime;
				else if(hit.collider.name == "Sp4") sp4 += Time.deltaTime;
				else if(hit.collider.name == "Sp5") sp5 += Time.deltaTime;
				else if(hit.collider.name == "Si1") si1 += Time.deltaTime;
				else if(hit.collider.name == "Si2") si2 += Time.deltaTime;
				else if(hit.collider.name == "Si3") si3 += Time.deltaTime;
				else if(hit.collider.name == "Si4") si4 += Time.deltaTime;
				else if(hit.collider.name == "Si5") si5 += Time.deltaTime;
				else if(hit.collider.name == "Sm1") sm1 += Time.deltaTime;
				else if(hit.collider.name == "Sm2") sm2 += Time.deltaTime;
			}

			else
			{
				Bila.transform.position = new Vector3(100,100,100);
				sist.transform.position = new Vector3(100,100,100);
			}

			if(Input.GetMouseButtonDown(0))
			{
				if(!Physics.Raycast(raza, out hit, 10))
				{
					old = Input.mousePosition;
					ok_rot = true;
					ok_open = false;
					ok_wash = false;
				}

				else
				{

					if(hit.collider.name == "Gingie_sus")
					{
						old = Input.mousePosition;
						ok_rot =  false;
						ok_open = true;
						ok_wash = false;
					}

					else
					{
						ok_rot =  false;
						ok_open = false;
						ok_wash = true;
					}

				}

			}

			if(Input.GetMouseButtonUp(0))
			{
				ok_rot =  false;
				ok_open = false;
				ok_wash = false;
			}
			
			
			if(ok_rot)
			{
				delta = Input.mousePosition - old;
				old = Input.mousePosition;
				Gura.transform.eulerAngles += new Vector3(delta.y, -delta.x, 0)/2;
				Gura.transform.eulerAngles = new Vector3(Gura.transform.eulerAngles.x, Gura.transform.eulerAngles.y, 0);
			}

			if(ok_open)
			{
				delta = Input.mousePosition - old;
				old = Input.mousePosition;
				if(Gingie.transform.localEulerAngles.x < 320 && Gingie.transform.localEulerAngles.x > 20)
					Gingie.transform.localEulerAngles = new Vector3(320, 0, 0);

				Gingie.transform.localEulerAngles += new Vector3(delta.y, 0, 0)/10;
			}


			if(Input.GetMouseButtonDown(0) && hit.collider.name == "Start")
			{
				jp1=jp2=jp3=jp4=jp5=ji1=ji2=ji3=ji4=ji5=jm1=jm2=sp1=sp2=sp3=sp4=sp5=si1=si2=si3=si4=si5=sm1=sm2 = 0;
				T=-2;

				iTween.MoveTo(gameObject, p2.position, 2);

			}

			if(Input.GetMouseButtonDown(0) && hit.collider.name == "Finish")
			{
				if(jp1 > 6) jp1 = 6;
				if(jp2 > 5) jp2 = 5;
				if(jp3 > 7) jp3 = 7;
				if(jp4 > 5) jp4 = 5;
				if(jp5 > 6) jp5 = 6;

				if(sp1 > 6) sp1 = 6;
				if(sp2 > 5) sp2 = 5;
				if(sp3 > 7) sp3 = 7;
				if(sp4 > 5) sp4 = 5;
				if(sp5 > 6) sp5 = 6;

				if(jm1 > 5) jm1 = 5;
				if(jm2 > 5) jm2 = 5;
				if(sm1 > 5) sm1 = 5;
				if(sm2 > 5) sm2 = 5;



				if(ji1 > 4) ji1 = 4;
				if(ji2 > 3) ji2 = 3;
				if(ji3 > 3) ji3 = 3;
				if(ji4 > 3) ji4 = 3;
				if(ji5 > 4) ji5 = 4;
				
				if(si1 > 4) si1 = 4;
				if(si2 > 3) si2 = 3;
				if(si3 > 3) si3 = 3;
				if(si4 > 3) si4 = 3;
				if(si5 > 4) si5 = 4;




				text_scor.text = "" + (int)(jp1+jp2+jp3+jp4+jp5+ji1+ji2+ji3+ji4+ji5+jm1+jm2+sp1+sp2+sp3+sp4+sp5+si1+si2+si3+si4+si5+sm1+sm2)*100/112;
				
				iTween.MoveTo(gameObject, p3.position, 2);
				
			}

			if(Input.GetMouseButtonDown(0) && hit.collider.name == "Replay")
			{
				
				iTween.MoveTo(gameObject, p1.position, 2);
				
			}


		}
		














		if(Application.platform == RuntimePlatform.Android)
		{
			
			T += Time.deltaTime;
			text_timp.text = (int)T + " sec";
			
			if(Input.touchCount > 0)
			{
				Ray raza = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
				RaycastHit hit;
				
				
				
				if(Physics.Raycast(raza, out hit, 10) && ok_wash && hit.collider.name != "Gingie_sus")
				{
					
					Bila.transform.position = hit.point;
					sist.transform.position = hit.point;
					
					
					if(hit.collider.name == "Jp1") jp1 += Time.deltaTime;
					else if(hit.collider.name == "Jp2") jp2 += Time.deltaTime;
					else if(hit.collider.name == "Jp3") jp3 += Time.deltaTime;
					else if(hit.collider.name == "Jp4") jp4 += Time.deltaTime;
					else if(hit.collider.name == "Jp5") jp5 += Time.deltaTime;
					else if(hit.collider.name == "Ji1") ji1 += Time.deltaTime;
					else if(hit.collider.name == "Ji2") ji2 += Time.deltaTime;
					else if(hit.collider.name == "Ji3") ji3 += Time.deltaTime;
					else if(hit.collider.name == "Ji4") ji4 += Time.deltaTime;
					else if(hit.collider.name == "Ji5") ji5 += Time.deltaTime;
					else if(hit.collider.name == "Jm1") jm1 += Time.deltaTime;
					else if(hit.collider.name == "Jm2") jm2 += Time.deltaTime;
					
					else if(hit.collider.name == "Sp1") sp1 += Time.deltaTime;
					else if(hit.collider.name == "Sp2") sp2 += Time.deltaTime;
					else if(hit.collider.name == "Sp3") sp3 += Time.deltaTime;
					else if(hit.collider.name == "Sp4") sp4 += Time.deltaTime;
					else if(hit.collider.name == "Sp5") sp5 += Time.deltaTime;
					else if(hit.collider.name == "Si1") si1 += Time.deltaTime;
					else if(hit.collider.name == "Si2") si2 += Time.deltaTime;
					else if(hit.collider.name == "Si3") si3 += Time.deltaTime;
					else if(hit.collider.name == "Si4") si4 += Time.deltaTime;
					else if(hit.collider.name == "Si5") si5 += Time.deltaTime;
					else if(hit.collider.name == "Sm1") sm1 += Time.deltaTime;
					else if(hit.collider.name == "Sm2") sm2 += Time.deltaTime;
				}
				
				else
				{
					Bila.transform.position = new Vector3(100,100,100);
					sist.transform.position = new Vector3(100,100,100);
				}
				
				if(Input.GetTouch(0).phase == TouchPhase.Began)
				{
					if(!Physics.Raycast(raza, out hit, 10))
					{
						old = Input.GetTouch(0).position;
						ok_rot = true;
						ok_open = false;
						ok_wash = false;
					}
					
					else
					{
						
						if(hit.collider.name == "Gingie_sus")
						{
							old = Input.GetTouch(0).position;
							ok_rot =  false;
							ok_open = true;
							ok_wash = false;
						}
						
						else
						{
							ok_rot =  false;
							ok_open = false;
							ok_wash = true;
						}
						
					}
					
				}

				
				
				if(ok_rot)
				{
					delta = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 0) - old;
					old = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 0);
					Gura.transform.eulerAngles += new Vector3(delta.y, -delta.x, 0)/2;
					Gura.transform.eulerAngles = new Vector3(Gura.transform.eulerAngles.x, Gura.transform.eulerAngles.y, 0);
				}
				
				if(ok_open)
				{
					delta = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 0) - old;
					old = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 0);
					if(Gingie.transform.localEulerAngles.x < 320 && Gingie.transform.localEulerAngles.x > 20)
						Gingie.transform.localEulerAngles = new Vector3(320, 0, 0);
					
					Gingie.transform.localEulerAngles += new Vector3(delta.y, 0, 0)/10;
				}
				
				
				if(Input.GetTouch(0).phase == TouchPhase.Began && hit.collider.name == "Start")
				{
					jp1=jp2=jp3=jp4=jp5=ji1=ji2=ji3=ji4=ji5=jm1=jm2=sp1=sp2=sp3=sp4=sp5=si1=si2=si3=si4=si5=sm1=sm2 = 0;
					T=-2;
					Gura.transform.eulerAngles = new Vector3(0, 0, 0);


					iTween.MoveTo(gameObject, p2.position, 2);
					
				}
				
				if(Input.GetTouch(0).phase == TouchPhase.Began && hit.collider.name == "Finish")
				{
					if(jp1 > 6) jp1 = 6;
					if(jp2 > 5) jp2 = 5;
					if(jp3 > 7) jp3 = 7;
					if(jp4 > 5) jp4 = 5;
					if(jp5 > 6) jp5 = 6;
					
					if(sp1 > 6) sp1 = 6;
					if(sp2 > 5) sp2 = 5;
					if(sp3 > 7) sp3 = 7;
					if(sp4 > 5) sp4 = 5;
					if(sp5 > 6) sp5 = 6;
					
					if(jm1 > 5) jm1 = 5;
					if(jm2 > 5) jm2 = 5;
					if(sm1 > 5) sm1 = 5;
					if(sm2 > 5) sm2 = 5;
					
					
					
					if(ji1 > 4) ji1 = 4;
					if(ji2 > 3) ji2 = 3;
					if(ji3 > 3) ji3 = 3;
					if(ji4 > 3) ji4 = 3;
					if(ji5 > 4) ji5 = 4;
					
					if(si1 > 4) si1 = 4;
					if(si2 > 3) si2 = 3;
					if(si3 > 3) si3 = 3;
					if(si4 > 3) si4 = 3;
					if(si5 > 4) si5 = 4;
					
					
					
					
					text_scor.text = "" + (int)(jp1+jp2+jp3+jp4+jp5+ji1+ji2+ji3+ji4+ji5+jm1+jm2+sp1+sp2+sp3+sp4+sp5+si1+si2+si3+si4+si5+sm1+sm2)*100/112 + " %";
					
					iTween.MoveTo(gameObject, p3.position, 2);
					
				}
				
				if(Input.GetTouch(0).phase == TouchPhase.Began && hit.collider.name == "Replay")
				{
					
					iTween.MoveTo(gameObject, p1.position, 2);
					
				}
			}

			else 				
			{
				ok_rot =  false;
				ok_open = false;
				ok_wash = false;
			}
			
		}



	}
}
