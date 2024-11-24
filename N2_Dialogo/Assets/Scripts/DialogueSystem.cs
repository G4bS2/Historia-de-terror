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
            "(sons de choro)", // Linha 12
            "VOCE ESTA MENTINDO PRA MIM!!!", // Linha 13
            "DEPOIS DE TUDO O QUE EU FIZ POR VOCE, DO QUE PASSAMOS JUNTOS, VOCE ME TRATA ASSIM?", // Linha 14
            "Se voce me amasse de verdade saberia que o dia de hoje � muito especial!", // Linha 15
            "EU SOU SUA NAMORADA!!, VOCE TEM QUE ME AMAR!!", // Linha 16
            "HAHAHAHAAH! Simmm louca, sou toda louca apaixonada por voce!!", // Linha 17
            "Ok amor, mas venha comigo.", // Linha 18
            "Voce gosta de enigmas?", // Linha 19
            "Otimo amor! entao antes, vamos brincar um pouco", // Linha 20
            "Mas voce nao tem escolha hihi, se quiser que eu te conte o nosso segredinho", // Linha 21
            "La vai, presta bem atencao:     2 6 666 777 - 33 8 33 777 66 666", // Linha 22
            "Nao!! Era amor eterno, apesar de mortal, eu nunca deixaria de te amar", // Linha 23
            "Perfeito!! eu sabia que voce iria acertar", // Linha 24
            "Aqui est�: se eu fosse uma minhoca vc ainda me amaria?", // Linha 25
            "So responda vai, me amaria?", // Linha 26
            "Voce � muito chato e sem gra�a, achei q me amasse de verdade, mas tudo bem, nao podemos obrigar os outros a nos amar nao � mesmo? ou podemos? haha", // Linha 27
            "Vou te dar mais uma chance hein, eu confio em voce", // Linha 28
            "Ebaaaa!!! Muito bem!!", // Linha 29
            "So mais uma e acabamos", // Linha 30
            "Claro que nao, eu estou amando nosso dia juntinhos, passando um tempoinho com voce", // Linha 31
            "Tudo bem bb: blablabalbalbalblablalbalabalabl", // Linha 32
            "Muito bem!! uhullll! o meu amor � um genio", // Linha 33
            "Mas � claro querido, se voce n�o se lembra eu vou te lembrar com todo prazer", // Linha 34
            "Um dia, voce havia me prometido que nunca iria me deixar, que n�o iria me abandonar, n�o importa o que acontecesse", // Linha 35
            "Que Nem mesmo a morte poderia nos separar, hahaha que ironia. ", // Linha 36
            "Por muito tempo eu fiquei sozinha, te esperando, tirste, chorando, com raiva. E confesso que ate tinha perdido as esperan�as ", // Linha 37
            "Mas isso, esse sentimento acabou, com voc� chegando hoje ate mim meu amor", // Linha 38
            "HAHAHAHAHAHAHA", // Linha 39
            "lindo, n�o teria como eu estar melhor! Voce voltou! voltou para mim! eu estou te vendo novamente", // Linha 40
            "VOCE NAO TEM ESCOLHA MEU AMOR!", // Linha 41
            "O seu lugar, sua casa, agora � aqui comigo, para sempre!", // Linha 42
            "Vem comigo! nos vamos ser felizes, voce vai entender melhor se vier, � lindo! mas sem voce � vazio", // Linha 43
            "Por favor, Fica comigo, eu estive sozinha por tanto tempo aqui, e ter sua companhaia fez me sentir viva novamente", // Linha 44
            "Eu te entendo que esteja com medo de mim, e nao tiro sua razao, mas mesmo assim te imploro, me de uma chance de te mostrar que sera feliz comigo, que eu poderei ser sua noiva cadaver assim como voce � meu Jack", // Linha 45
            "Apenas confie em mim", // Linha 46
            "Nao!... na verdade eu nao sei... so tem como saber se voce ficar, mas isso depende da sua vontade, voce se arriscaria?", // Linha 47
            "Serio?? voce nao esta brincando comigo??", // Linha 48
            "mas...", // Linha 49
            "MAS VOCE VAI FICAR! HAHAHA! voce � meu! somente meu! e se eu nao puder te ter, ninguem mais vai!", // Linha 50
            "Ebaaaaa! obrigado amor, muito obrigado, voce nao vai se arrepender!", // Linha 51
            ".", // Linha 52
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
            "ei?", // Linha 12
            ".", // Linha 13
            "o que eu passei com voce? Como eu vou amar algu�m que eu n�o conhe�o?", // Linha 14
            ".", // Linha 15
            "VOCE � LOUCA GAROTA?", // Linha 16
            "Para de palha�ada e me conta o que que tem na porra do dia de hoje, e porque eu estou aqui! ", // Linha 17
            "Tudo bem", // Linha 18
            "Sim", // Linha 19
            "Ok", // Linha 20
            "Tudo bem entao, anda logo vai, me faz esse enigma", // Linha 21
            "Amor Mortal", // Linha 22
            "Ah... ta, me faz outra pergunta entao, essa eu irei acertar", // Linha 23
            "Obvio, foi muito facil, manda outra", // Linha 24
            "Ahnn... sim?", // Linha 25
            "Sim, amaria", // Linha 26
            "Voce era do CAPS so pode", // Linha 27
            "Voce � muito insistente", // Linha 28
            "E agora ta feliz?", // Linha 29
            "Voce nao se cansa disso ne", // Linha 30
            ":/ so me pergunta logo por favor", // Linha 31
            "1?", // Linha 32
            "Agora me conta, o segredo que voce prometeu", // Linha 33
            "Por favor!", // Linha 34
            "...", // Linha 35
            "O que voce quer dizer com isso?", // Linha 36
            "Te entendo, esse sentimento de solid�o, mas...", // Linha 37
            "...", // Linha 38
            "Ghost? voc� est� bem?", // Linha 39
            "At� quando vai durar isso? me diz como ir embora daqui! Eu quero ir pra casa", // Linha 40
            "Como assim? que bobagem � essa?", // Linha 41
            "SAI FORA! esquisita", // Linha 42
            "Nao quero te magoar, mas eu n�o quero ficar", // Linha 43
            "Sinto muito... eu...", // Linha 44
            "Mas como? voce � uma fantasma e eu um humano", // Linha 45
            "Espera! ficar aqui significa que eu terei que morrer?", // Linha 46
            "Sim", // Linha 47
            "nao, eu vou ficar", // Linha 48
            "...", // Linha 49
            ".", // Linha 50
            "Espero que nao mesmo", // Linha 51
        };

        negativeLabels = new string[]
        {
            "Quem � voce?",// Linha 0
            ".",// Linha 1
            ".",// Linha 2
            ".", // Linha 3
            ".", // Linha 4
            ".", // Linha 5
            ".", // Linha 6
            ".", // Linha 7
            ".", // Linha 8
            ".", // Linha 9
            "Talvez eu n me lembro de nada", // Linha 10
            "� claro que sim", // Linha 11
            ".", // Linha 12
            "Nao... eu te amo de verdade", // Linha 13
            ".", // Linha 14
            "Me desculpa!", // Linha 15
            ".", // Linha 16
            ".", // Linha 17
            "N�o", // Linha 18
            "N�o", // Linha 19
            "g", // Linha 20
            "Ta, vamos entao", // Linha 21
            "Amor Eterno", // Linha 22
            ".", // Linha 23
            "Obvio, essa foi muito facil", // Linha 24
            "Que tipo de pergunta � essa? kkkk", // Linha 25
            "Claro que nao, minhoca nao fala, como eu trocaria ideia com voce?", // Linha 26
            "Eu ja te disse que as vezes voce parece muito doida?", // Linha 27
            "Eu ja te disse que as vezes voce parece muito doida?", // Linha 28
            ".", // Linha 29
            ".", // Linha 30
            ".", // Linha 31
            "2", // Linha 32
            ".", // Linha 33
            ".", // Linha 34
            ".", // Linha 35
            ".", // Linha 36
            ".", // Linha 37
            ".", // Linha 38
            ".", // Linha 39
            ".", // Linha 40
            ".", // Linha 41
            ".", // Linha 42
            ".", // Linha 43
            ".", // Linha 44
            "Nao", // Linha 45
            ".", // Linha 46
            "Nao", // Linha 47
            "pensando melhor acho que mudei de ideia", // Linha 48
            "Ghost?", // Linha 49
            ".", // Linha 50
            ".", // Linha 51
            ".", // Linha 52

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
                     
            case 0: // Quando o jogador pergunta sobre os portais
                dialogueOptions[0].SetActive(true); // "Sim, me conte mais!"
                dialogueOptions[1].SetActive(true); // "N�o, prefiro ir embora."
                break;

                case 10 : // Caso o di�logo chegue ao fim
                dialogueOptions[0].SetActive(true); // "Sim, me conte mais!"
                dialogueOptions[1].SetActive(true); // "N�o, prefiro ir embora
                break;

            case 11 : // Caso o di�logo chegue ao fim
                dialogueOptions[0].SetActive(true); // "Sim, me conte mais!"
                dialogueOptions[1].SetActive(true); // "N�o, prefiro ir embora
                break;

            case 13 : // Caso o di�logo chegue ao fim
                dialogueOptions[0].SetActive(false); // "Sim, me conte mais!"
                dialogueOptions[1].SetActive(true); // "N�o, prefiro ir embora
                break;

            case 15 : // Caso o di�logo chegue ao fim
                dialogueOptions[0].SetActive(false); // "Sim, me conte mais!"
                dialogueOptions[1].SetActive(true); // "N�o, prefiro ir embora
                break;

            case 19 : // Caso o di�logo chegue ao fim
                dialogueOptions[0].SetActive(true); // "Sim, me conte mais!"
                dialogueOptions[1].SetActive(true); // "N�o, prefiro ir embora
                break;

            case 22 : // Caso o di�logo chegue ao fim
                dialogueOptions[0].SetActive(true); // "Sim, me conte mais!"
                dialogueOptions[1].SetActive(true); // "N�o, prefiro ir embora
                break;

            
            case 25 : // Caso o di�logo chegue ao fim
                dialogueOptions[0].SetActive(true); // "Sim, me conte mais!"
                dialogueOptions[1].SetActive(true); // "N�o, prefiro ir embora
                break;

            case 26 : // Caso o di�logo chegue ao fim
                dialogueOptions[0].SetActive(true); // "Sim, me conte mais!"
                dialogueOptions[1].SetActive(true); // "N�o, prefiro ir embora
                break;

            case 27 : // Caso o di�logo chegue ao fim
                dialogueOptions[0].SetActive(true); // "Sim, me conte mais!"
                dialogueOptions[1].SetActive(true); // "N�o, prefiro ir embora
                break;

            case 32 : // Caso o di�logo chegue ao fim
                dialogueOptions[0].SetActive(true); // "Sim, me conte mais!"
                dialogueOptions[1].SetActive(true); // "N�o, prefiro ir embora
                break;
                     
            case 47 : // Caso o di�logo chegue ao fim
                dialogueOptions[0].SetActive(true); // "Sim, me conte mais!"
                dialogueOptions[1].SetActive(true); // "N�o, prefiro ir embora
                break;

            case 48 : // Caso o di�logo chegue ao fim
                dialogueOptions[0].SetActive(true); // "Sim, me conte mais!"
                dialogueOptions[1].SetActive(true); // "N�o, prefiro ir embora
                break;

            case 49 : // Caso o di�logo chegue ao fim
                dialogueOptions[0].SetActive(true); // "Sim, me conte mais!"
                dialogueOptions[1].SetActive(true); // "N�o, prefiro ir embora
                break;

            case 50 : // Caso o di�logo chegue ao fim
                dialogueOptions[0].SetActive(false); // "Sim, me conte mais!"
                dialogueOptions[1].SetActive(false); // "N�o, prefiro ir embora
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

            case 11: // Para todas as outras op��es
                currentLine = 12; // Apenas avan�a para a pr�xima linha
                break;

            case 12: // Para todas as outras op��es
                currentLine = 14; // Apenas avan�a para a pr�xima linha
                break;

            case 14: // Para todas as outras op��es
                currentLine = 16; // Apenas avan�a para a pr�xima linha
                break;

            case 20: // Para todas as outras op��es
                currentLine = 22; // Apenas avan�a para a pr�xima linha
                break;

            case 23: // Para todas as outras op��es
                currentLine = 25; // Apenas avan�a para a pr�xima linha
                break;

            case 25: // Para todas as outras op��es
                currentLine = 29; // Apenas avan�a para a pr�xima linha
                break;

            case 26: // Para todas as outras op��es
                currentLine = 29; // Apenas avan�a para a pr�xima linha
                break;

            case 28: // Para todas as outras op��es
                currentLine = 26; // Apenas avan�a para a pr�xima linha
                break;

            case 48: // Para todas as outras op��es
                currentLine = 51; // Apenas avan�a para a pr�xima linha
                break;

            case 47: // Para todas as outras op��es
                currentLine = 48; // Apenas avan�a para a pr�xima linha
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
            case 0: // Para todas as outras op��es
                currentLine = 3; // Apenas avan�a para a pr�xima linha
                break;

            case 11: // Quando o jogador escolhe saber mais sobre drag�es
                currentLine = 13; // Fala mais sobre os drag�es
                break;

            case 13: // Quando o jogador escolhe saber mais sobre drag�es
                currentLine = 15; // Fala mais sobre os drag�es
                break;

            case 19: // Quando o jogador escolhe saber mais sobre drag�es
                currentLine = 21; // Fala mais sobre os drag�es
                break;

            case 22: // Quando o jogador escolhe saber mais sobre drag�es
                currentLine = 24; // Fala mais sobre os drag�es
                break;

            case 28: // Para todas as outras op��es
                currentLine = 26; // Apenas avan�a para a pr�xima linha
                break;

            case 47: // Quando o jogador escolhe saber mais sobre drag�es
                currentLine = 49; // Fala mais sobre os drag�es
                break;

             default: // Para todas as outras op��es
                currentLine += 1; // Apenas avan�a para a pr�xima linha
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