using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] List<QuestionsSO> questions = new List<QuestionsSO>();
    QuestionsSO currentQuestion;

    [Header("Answers")]
    [SerializeField] GameObject[] answerButtons;
    bool hasAnsweredEarly = true;
    
    int correctAnswerIndex;

    [Header("Button Sprite Colors")]
    [SerializeField] Sprite defaultButtonSprite;
    [SerializeField] Sprite CorrectButtonSprite;

    [Header("Timer")]
    [SerializeField] Image timerImage ;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI displayScoreText;

    Timer timer;
    Score score;

    [Header("Progress Bar")]
    [SerializeField] Slider progressBar;


    public bool isComplete;


    void Awake()
    {
        timer = FindObjectOfType<Timer>();
        score = FindObjectOfType<Score>();

        progressBar.maxValue = questions.Count;
        progressBar.minValue = 0;

    }

    void Update() {

        timerImage.fillAmount = timer.fillFraction;

        if(timer.LoadNextQuestion){

            if(progressBar.value == progressBar.maxValue){
                isComplete = true;
                return;
            }

            hasAnsweredEarly = false;
            nextQuestion();
            timer.LoadNextQuestion = false;
        }else if(!hasAnsweredEarly && !timer.isWaitingForAnswer){
            displayCorrectAnswer(-1);
            setButtonState(false);
        }

    }

    void ShuffleArray<T>(T[] array)
    {
        int n = array.Length;
        for (int i = 0; i < n; i++)
        {
            int randomIndex = Random.Range(i, n);
            T temp = array[randomIndex];
            array[randomIndex] = array[i];
            array[i] = temp;
        }
    }


    void getRandomQuestion(){
        int index = Random.Range(0, questions.Count);
        currentQuestion = questions[index];

        if(questions.Contains(currentQuestion)){
            questions.Remove(currentQuestion);
        }
    }

    void displayQuestion(){
        TextMeshProUGUI buttonText;
        questionText.text = currentQuestion.getQuestion();
        // Shuffle the answers using the ShuffleArray function
        for(int i = 0; i < answerButtons.Length; i++){
            buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = currentQuestion.getAnswer(i);
        }
    }

    void displayCorrectAnswer(int index){
          Image buttonImage;

        if (index == currentQuestion.getCorrectAnswerIndex()){
            questionText.text = "Benar!"; 
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = CorrectButtonSprite;
            score.setCurrentScore();  

        } else{
            correctAnswerIndex = currentQuestion.getCorrectAnswerIndex();
            questionText.text = "Salah! Jawabnya adalah: " + currentQuestion.getAnswer(correctAnswerIndex);   
            buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = CorrectButtonSprite;

        }
    }
    public void onAnswerSelected(int index){
        displayCorrectAnswer(index);
        setButtonState(false);
        hasAnsweredEarly = true;
        timer.cancelTimer();
        displayScoreText.text = "" + score.calculateTotalScore();

    }


    void nextQuestion(){
        if(questions.Count > 0){
            setButtonState(true);
            setDefaultButtonSprites();
            getRandomQuestion();
            displayQuestion();
            score.setNumOfQuestionsEncountered();
            progressBar.value += 1;
        }
    }

    void setButtonState(bool state){
        Button button;

        for(int i = 0; i < answerButtons.Length; i++){
                button = answerButtons[i].GetComponentInChildren<Button>();
                button.interactable = state;
        }
    }

    void setDefaultButtonSprites(){
        Image dButtonImage;

         for(int i = 0; i < answerButtons.Length; i++){
                dButtonImage = answerButtons[i].GetComponent<Image>();
                dButtonImage.sprite = defaultButtonSprite;
        }
    }


    void endGame(){
       questionText.text = "YNOUIYIOYIOPUNDCSIOPDUMIPSDUMIPOSdumOPSDMUSIODU*IOPDIPMUISDUIOSDuJIOSDNUIDOSPSD";   
    
    }

}
