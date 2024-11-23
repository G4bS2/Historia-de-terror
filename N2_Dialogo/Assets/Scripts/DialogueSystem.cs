using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public Text dialogueText; // O texto que será exibido na tela
    public GameObject[] dialogueOptions; // Opções de respostas do diálogo
    public string[] dialogueLines; // As linhas de diálogo
    private int currentLine = 0; // Linha atual do diálogo

    // Listas de labels para os botões
    public string[] positiveLabels; // Labels para a resposta positiva ("Sim, me conte mais!")
    public string[] negativeLabels; // Labels para a resposta negativa ("Não, prefiro ir embora.")

    void Start()
    {
        dialogueLines = new string[]
        {
            "Olá, Amor!! quanto tempo", // Linha 0
            "Olá, Amor!! quanto tempo", // Linha 1
            "Nao esta me reconhecendo?", // Linha 2
            "Sou o seu amor ué, como pode se esquecer?", // Linha 3
            "Voce esta brincando comigo né? para isso Nao tem graça!", // Linha 4
            "Eu estava tão animada", // Linha 5
            "Com o dia de hoje é claro", // Linha 6
            "Não, seu bobo, é nosso dia juntos", // Linha 7
            "Mas Voce me prometeu por esse dia há anos", // Linha 8
            "Mas deveria! afinal eu sou sua namorada!", // Linha 9
            "Eu não sou??", // Linha 10
            "Voce não me ama?", // Linha 11
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
            "acho que não, quem é voce?",// Linha 2
            "Eu não sei, onde eu estou?", // Linha 3
            "Como assim?", // Linha 4
            "Animada com o que??", // Linha 5
            "O que tem hoje? é feriado e eu nao sabia?", // Linha 6
            "Calma la, eu estou muito perdido, nao sei onde eu estou e so queria ir embora, tenho coisas pra fazer", // Linha 7
            "Eu não me lembro disso", // Linha 8
            "O Que???", // Linha 9
            "Eu... Eu nao sei...", // Linha 10
            "Mas eu nem te conheço, como vou amar?", // Linha 11
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
            "É claro que sim", // Linha 11
            ".", // Linha 12
            ".", // Linha 13
            ".", // Linha 14
            ".", // Linha 15
            ".", // Linha 16
            ".", // Linha 17
            ".", // Linha 17
        };

        // Exibe a primeira linha do diálogo
        ShowDialogueLine();
    }

    // Exibe uma linha de diálogo
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

    // Desativa todas as opções
    void DisabledAllOptions()
    {
        foreach (GameObject option in dialogueOptions)
        {
            option.SetActive(false);
        }
    }

    // Exibe as opções de resposta
    void ShowOptions()
    {

        // Exibe opções com base na linha atual
        switch (currentLine)
        {    
                     
            case 11: // Quando o jogador pergunta sobre os portais
                dialogueOptions[0].SetActive(true); // "Sim, me conte mais!"
                dialogueOptions[1].SetActive(true); // "Não, prefiro ir embora."
                break;

            case 16: // Caso o diálogo chegue ao fim
                dialogueOptions[0].SetActive(true); // "Sim, me conte mais!"
                dialogueOptions[1].SetActive(true); // "Não, prefiro ir embora
                break;
            default: // Para todas as outras opções
                dialogueOptions[0].SetActive(true); // "Sim, me conte mais!"
                dialogueOptions[1].SetActive(false); // "Não, prefiro ir embora
                break;
        }
    }

    // Função para o jogador selecionar uma resposta
    public void SelectOption(int optionIndex)
    {
        switch (optionIndex)
        {
            case 0: // "Sim, me conte mais!"
                HandleYesOption();
                break;

            case 1: // "Não, prefiro ir embora."
                HandleNoOption();
                break;
        }

        ShowDialogueLine(); // Atualiza a linha do diálogo
    }

    // Lógica quando o jogador escolhe "Sim, me conte mais!"
    void HandleYesOption()
    {
        switch (currentLine)
        {
            case 0: // Para todas as outras opções
                currentLine = 2; // Apenas avança para a próxima linha
                break;

            default: // Para todas as outras opções
                currentLine += 1; // Apenas avança para a próxima linha
                break;
        }
    }

    // Lógica quando o jogador escolhe "Não, prefiro ir embora."
    void HandleNoOption()
    {
        switch (currentLine)
        {
            
            case 11: // Quando o jogador escolhe saber mais sobre dragões
                currentLine = 8; // Fala mais sobre os dragões
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
    // Finaliza o diálogo
    void EndDialogue()
    {
        dialogueText.text = "O diálogo terminou. Você pode voltar quando quiser!";
        foreach (GameObject option in dialogueOptions)
        {
            option.SetActive(false); // Aqui os botões são desativados quando o diálogo termina
        }
    }
}