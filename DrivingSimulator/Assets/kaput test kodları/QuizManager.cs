using System.Linq.Expressions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    //public Text questionText;
    public Text[] answerText;
    public Button startButton;
    public GameObject quiz_panel;
    public GameObject pointer;
    public Button[] answerButtons;

    private int currentQuestion=0;
    private int score=0;

    private string[] question ={"İşaret ile gösterilen nedir?"};
    private string [][] answers={
        //0-motor sorusu
        new string[]{"A- MOTOR","B- HIDROLIK YAG ","C-AKU","D - LEVYE"},
        //1 antifiriz sorusu
        new string[]{"A- HAVA FILITRESI","B- ANTIFRIZ ","C-AKU","D - LEVYE"},
        //2 motor yağı kapağı sorusu
        new string[]{"A- YAG FILITRESI","B- AKU ","C-MOTOR YAGI KAPAGI","D - YANGIN TUPU"},
        //3 motor yağ kontrol çubuğu
        new string[]{"A- LEVYE","B- HIDROLIK YAG ","C-AKU","D - MOTOR YAG KONTROL CUBUGU"},
        //4 Hava Filtresi 
        new string[]{"A- MOTOR","B- HAVA FILITRESI ","C-AKU","D - LEVYE"},
        //5cam silecek suyu
        new string[]{"A- BENZIN DEPOSU","B- CAM SILECEK SUYU ","C-YAGDANLIK","D - LEVYE"},
        // 6 Yağ filitresi
        new string[]{"A- MOTOR","B- YAG FILITRESI ","C-AKU","D - KURDAN"},
        // 7 Akü
        new string[]{"A- MOTOR","B- HAVA FILITRESI ","C-AKU","D - LEVYE"},
        //8 Radyatör Kapağı
        new string[]{"A- RADYATOR KAPAGI","B- HAVA FILITRESI ","C-AKU","D - LEVYE"},
        //9 Fren hidroliği
        new string[]{"A- FREN HIDROLIGI","B- HAVA FILITRESI ","C-AKU","D - LEVYE"},
    };

    private int[] correctAnswer={0,1,2,3,1,1,1,2,0,0};
    void Start()
    {
        quiz_panel.SetActive(true);
        startButton.onClick.AddListener(StartQuiz);
        

        for (int i = 0; i < answerButtons.Length; i++)
        {
            int index = i; // Döngü değişkenini bir lambda içinde kullanmak için
            answerButtons[i].onClick.AddListener(() => answerButton(index));
        }
         
    }

     void StartQuiz(){

        startButton.gameObject.SetActive(false);
        quiz_panel.SetActive(true);
        NextQuestion();
    }

     void NextQuestion(){

            if (currentQuestion==0)
            {
                pointer.transform.position=new Vector3(-0.186f,1.366f,1.939f);
            }else if(currentQuestion==1) 
                
            {
                pointer.transform.position=new Vector3(0.096f,1.064f,2.026f);
            }else if(currentQuestion==2) 
                
            {
                pointer.transform.position=new Vector3(0.04f,1.326f,1.948f);
            }
            else if(currentQuestion==3)
                
            {
                pointer.transform.position=new Vector3(-0.065f,1.278f,1.966f);
            }

            else if(currentQuestion==4) 
                
            {
                pointer.transform.position=new Vector3(-0.453f,1.197f,1.998f);
            }
            else if(currentQuestion==5) 
                
            {
                pointer.transform.position=new Vector3(0.291f,1.210f,1.98f);
            }
            else if(currentQuestion==6) 
                
            {
                pointer.transform.position=new Vector3(-0.187f,1.125f,2.015f);
            }
            else if(currentQuestion==7) 
                
            {
                pointer.transform.position=new Vector3(-0.412f,1.361f,1.947f);
            }
            else if(currentQuestion==8) 
                
            {
                pointer.transform.position=new Vector3(-0.196f,1.0369f,2.041f);
            }
            else if(currentQuestion==9) 
                
            {
                pointer.transform.position=new Vector3(-0.266f,1.451f,1.917f);
            }
            
            else{


                /// <summary>
                /// hata
                /// </summary>
                /// <returns></returns>
            }

            for(int i = 0; i < answerText.Length; i++) {
                answerText[i].text = answers[currentQuestion][i];
            }
            
            for (int i = 0; i < answerButtons.Length; i++)
            {
                int index = i; // Döngü değişkenini bir lambda içinde kullanmak için
                answerButtons[i].onClick.AddListener(() => answerButton(index));
            }

         
    }
    public void answerButton(int answerindex){

        if(answerindex==correctAnswer[currentQuestion]) {
            score++;
        }
        currentQuestion++;

        if (currentQuestion< 10)
        {
            NextQuestion();
        }else{

            EndQuiz();
        }


    }

    private void EndQuiz () {
        Debug.Log("Test bitti:  Puaniniz "+score);
    }
}
