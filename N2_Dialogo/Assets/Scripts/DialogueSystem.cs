using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public Text dialogueText; // O texto que ser� exibido na tela
    public GameObject[] dialogueOptions; // Op��es de respostas do di�logo
    public string[] dialogueLines; // As linhas de di�logo
    private int currentLine = 0; // Linha atual do di�logo

    // Listas de labels para os bot�es
    public string[] positiveLabels; // Labels para a resposta positiva ("Sim, me conte mais!")
    public string[] negativeLabels; // Labels para a resposta negativa ("N�o, prefiro ir embora.")

    void Start()
    {
        dialogueLines = new string[]
        {
            "Ol�, Amor!! quanto tempo", // Linha 0
            "Ol�, Amor!! quanto tempo", // Linha 1
            "Nao esta me reconhecendo?", // Linha 2
            "Sou o seu amor u�, como pode se esquecer?", // Linha 3
            "Voce esta brincando comigo n�? para isso Nao tem gra�a!", // Linha 4
            "Eu estava t�o animada", // Linha 5
            "Com o dia de hoje � claro", // Linha 6
            "N�o, seu bobo, � nosso dia juntos", // Linha 7
            "Mas Voce me prometeu por esse dia h� anos", // Linha 8
            "Mas deveria! afinal eu sou sua namorada!", // Linha 9
            "Eu n�o sou??", // Linha 10
            "Voce n�o me ama?", // Linha 11
            "", // Linha 12
            "", // Linha 13
            "", // Linha 14
            "", // Linha 15
            "", // Linha 16
            "", // Linha 17
            "", // Linha 18
            "", // Linha 19
        };

        positiveLabels = new string[]
        {
            "ahnn... oi?",// Linha 0
            "ola?",// Linha 1
            "acho que n�o, quem � voce?",// Linha 2
            "Eu n�o sei, onde eu estou?", // Linha 3
            "Como assim?", // Linha 4
            "Animada com o que??", // Linha 5
            "O que tem hoje? � feriado e eu nao sabia?", // Linha 6
            "Calma la, eu estou muito perdido, nao sei onde eu estou e so queria ir embora, tenho coisas pra fazer", // Linha 7
            "Eu n�o me lembro disso", // Linha 8
            "O Que???", // Linha 9
            "Eu... Eu nao sei...", // Linha 10
            "Mas eu nem te conhe�o, como vou amar?", // Linha 11
            "", // Linha 12
            "", // Linha 13
            "", // Linha 14
            "", // Linha 15
            "", // Linha 16
            "", // Linha 17
            "", // Linha 17
        };

        negativeLabels = new string[]
        {
            ".",// Linha 0
            ".",// Linha 1
            ".",// Linha 2
            ".", // Linha 3
            ".", // Linha 4
            ".", // Linha 5
            ".", // Linha 6
            ".", // Linha 7
            ".", // Linha 8
            ".", // Linha 9
            ".", // Linha 10
            "� claro que sim", // Linha 11
            ".", // Linha 12
            ".", // Linha 13
            ".", // Linha 14
            ".", // Linha 15
            ".", // Linha 16
            ".", // Linha 17
            ".", // Linha 17
        };

        // Exibe a primeira linha do di�logo
        ShowDialogueLine();
    }

    // Exibe uma linha de di�logo
    void ShowDialogueLine()
    {
        if (currentLine < dialogueLines.Length)
        {
            dialogueText.text = dialogueLines[currentLine];
            ShowOptions();
        }
        else
        {
            EndDialogue();
        }

        if (currentLine < positiveLabels.Length)
        {
            var indexPositiveBtn = 0;
            var indexNegativeBtn = 1;
            setNewTextButtonPositive(indexPositiveBtn, currentLine);
            setNewTextButtonNegative(indexNegativeBtn, currentLine);
        }
    }

    // Desativa todas as op��es
    void DisabledAllOptions()
    {
        foreach (GameObject option in dialogueOptions)
        {
            option.SetActive(false);
        }
    }

    // Exibe as op��es de resposta
    void ShowOptions()
    {

        // Exibe op��es com base na linha atual
        switch (currentLine)
        {    
                     
            case 11: // Quando o jogador pergunta sobre os portais
                dialogueOptions[0].SetActive(true); // "Sim, me conte mais!"
                dialogueOptions[1].SetActive(true); // "N�o, prefiro ir embora."
                break;

            case 16: // Caso o di�logo chegue ao fim
                dialogueOptions[0].SetActive(true); // "Sim, me conte mais!"
                dialogueOptions[1].SetActive(true); // "N�o, prefiro ir embora
                break;
            default: // Para todas as outras op��es
                dialogueOptions[0].SetActive(true); // "Sim, me conte mais!"
                dialogueOptions[1].SetActive(false); // "N�o, prefiro ir embora
                break;
        }
    }

    // Fun��o para o jogador selecionar uma resposta
    public void SelectOption(int optionIndex)
    {
        switch (optionIndex)
        {
            case 0: // "Sim, me conte mais!"
                HandleYesOption();
                break;

            case 1: // "N�o, prefiro ir embora."
                HandleNoOption();
                break;
        }

        ShowDialogueLine(); // Atualiza a linha do di�logo
    }

    // L�gica quando o jogador escolhe "Sim, me conte mais!"
    void HandleYesOption()
    {
        switch (currentLine)
        {
            case 0: // Para todas as outras op��es
                currentLine = 2; // Apenas avan�a para a pr�xima linha
                break;

            default: // Para todas as outras op��es
                currentLine += 1; // Apenas avan�a para a pr�xima linha
                break;
        }
    }

    // L�gica quando o jogador escolhe "N�o, prefiro ir embora."
    void HandleNoOption()
    {
        switch (currentLine)
        {
            
            case 11: // Quando o jogador escolhe saber mais sobre drag�es
                currentLine = 8; // Fala mais sobre os drag�es
                break;
       
        }
    }

    void setNewTextButtonPositive(int indexDialogOption, int currentLine)
    {
        Text buttonText = dialogueOptions[indexDialogOption].GetComponentInChildren<Text>();
        buttonText.text = positiveLabels[currentLine];
    }

    void setNewTextButtonNegative(int indexDialogOption, int currentLine)
    {
        Text buttonText = dialogueOptions[indexDialogOption].GetComponentInChildren<Text>();
        buttonText.text = negativeLabels[currentLine];
    }
    // Finaliza o di�logo
    void EndDialogue()
    {
        dialogueText.text = "O di�logo terminou. Voc� pode voltar quando quiser!";
        foreach (GameObject option in dialogueOptions)
        {
            option.SetActive(false); // Aqui os bot�es s�o desativados quando o di�logo termina
        }
    }
}