using System.Linq.Expressions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public Text questionText;
    public Text[] answerText;
    public Button startButton;
    public GameObject quiz_panel;
    public GameObject pointer;

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
            }

            questionText.text=question[currentQuestion];
            for(int i = 0; i < answerText.Length; i++) {
                answerText[i].text=answers[currentQuestion][i];

                
            }
    }
    public void answerButton(int answerindex){

        if(answerindex==correctAnswer[currentQuestion]) {
            score++;
        }
        currentQuestion++;

        if (currentQuestion< question.Length)
        {
            NextQuestion();
        }else{

            EndQuiz();
        }


    }

    private void EndQuiz () {
        Debug.Log("Test bitti:  Puanınız "+score);
    }
}
