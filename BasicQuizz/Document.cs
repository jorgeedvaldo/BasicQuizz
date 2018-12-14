using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicQuizz
{
    public class Document
    {

        public static byte Nivel = 0;
        public static byte Pontos = 0;

        public static int NivelPergunta(int NivelActual, int NumeroPerguntas)
        { 
            int Nperguntas = 0;
            Nperguntas = Convert.ToInt32((NumeroPerguntas / 4)) + Convert.ToInt32((NumeroPerguntas / 4))* NivelActual;
            return Nperguntas;
        }

        public static void ResetJogo()
        {
            Nivel = 0;
            Pontos = 0;
        }

        public static void AvancaNivel(int ponto)
        {
            if (ponto < 5)
            {
                Nivel = 0;
            }
            else if ((ponto >= 5) && (ponto < 10))
            {
                Nivel = 1;
            }
            else if ((ponto >= 10) && (ponto < 15))
            {
                Nivel = 2;
            }
            else if ((ponto >= 15) && (ponto < 20))
            {
                Nivel = 3;
            }
        }

        public static string[]  perguntas = new string[]{

            /******************* FACIL ***********************/
                 "Quem matou Abel?",
                 "Quem é o pai de Zeus?",
                 "Qual é a quinta letra do alfabeto?",
                 "Quem foi o 1º presidente afro-americano dos E.U.A?",
                 "Qual das seguintes linguagens de programação não é orientada a objecto?",
                 "Quantas letras tem o alfabeto?",
                 "A esposa do imperador é uma...?",
                 "No animie \"Naruto\" quantas caudas tem o biju de Naruto?",
                 "No animie \"Naruto\" quem é conhecido como o \"ninja cópia\"?",
                 "Qual é o nome do elefante voa com as suas grandes orelhas?",
                 "Quantos estados tem a água?",
                 "Qual é o símbolo químico da água?",

                 "Quantas copas do mundo tem a seleção da Inglaterra?",
                 "O sujeito é aquele que...?",
                 "Qual é o oposto de norte?",
                 "Qual é o oposto de sul?",
                 "Em linguagem binária quanto é 1+1?",
                 "Quantos títulos de campeão ingles tem o Liverpool FC?",
                 "Qual destas músicas é da cantora Rihanna?",
                 "The vampire diares é...?",
                 "Quanto é 3+5x2+4 ?",
                 "Quantas horas tem um dia?",
                 "Quantos dias possui um ano bissexto?",
                 "Na mitologia grega, quem é o deus do vinho?",
                 "Qual destes é o menor número?",

                 "Quantas são as tartarugas ninjas?",
                 "Qual destas músicas é da cantora Miley Cyrus?",
                 "Qual destas músicas é da cantora Selena Gomez?",
                 "O heroi Killer Bean é um...?",
                 "Em que ano foi lançado o Windows XP?",
                 "Complete o ditado: Quem tudo quer...?",
                 "Em que clube de futebol joga Cristiano Ronaldo?",
                 "Em que clube de futebol joga Leonel Messi?",
                 "Em que clube de futebol joga Phillippe Coutinho?",
                 "Em que clube de futebol joga Luis Suarez?",
                 "No total, quantos dedos tem um ser humano?",
                 "Quem é o namorado da Barbie?",

                 "Quem é a namorada do rato Mickey?",
                 "De que país é o estilo musical \"Kuduro\"?",
                 "Quantas bolas de ouro tem Lionel Messi?",
                 "Qual é a decima letra do alfabeto?",
                 "Qual destes é pai do personagem \"Percy Jackson\"?",
                 "Qual destes é a parte física do computador?",
                 "Em que ano aconteceu o atentado de 11 de Setembro?",
                 "Em que ano morreu Michael Jackson",
                 "Qual é a mascote da SEGA?",
                 "Qual é a mascote da Nintendo?",
                 "O sol é...?",
                 "No total, existem quantas estações?",
                 "Quem venceu o EURO de 2016?"
        /*******************NORMAL***************************************/

        /*******************DIFICIL***************************************/

        /*******************MUITO DIFICIL***************************************/

                                     };

    public static string[,] alternativas = new string[,]{

                        {"Davi", "Adão", "Sete"},
                        {"Hades", "Hermes", "Aquiles"},
                        {"A", "B", "H"},
                        {"George Bush", "Nelson Mandela", "Donald Trump"},
                        {"Java", "C++", "C#"},
                        {"32", "24", "23"},
                        {"Imperadora", "Dama", "Imperadoreira"},
                        {"Oito caudas", "Uma cauda", "Quatro caudas"},
                        {"Sasori", "Gaara", "Itachi"},
                        {"Sonic", "Pinóquio", "Tantor"},
                        {"Cinco estados", "Dois estados", "Dez estados"},
                        {"Ag", "Au", "K"},
                        {"Duas", "Nenhuma", "Três"},
                        {"Foge da polícia", "Sabe os verbos", "Sabe acentuar"},
                        {"Oeste", "Leste", "Sudoeste"},
                        {"Leste", "Este", "Sudoeste"},
                        {"2", "11", "9"},
                        {"Nenhum", "7", "15"},
                        {"Bad Romance", "Waka Waka", "Hands to my self"},
                        {"Uma música", "Um vídeo clip", "Uma marca de perfume"},
                        {"20", "33", "48"},
                        {"25", "26", "48"},
                        {"365", "367", "364"},
                        {"Hermes", "Zeus", "Ares"},
                        {"1", "-2", "3"},
                        {"5", "3", "6"},
                        {"Work", "Te amo", "Who says"},
                        {"Halo", "Party animal", "Roar"},
                        {"Esquilo", "Cão", "Repolho"},
                        {"2003", "2000", "2005"},
                        {"Sempre procede", "Tudo consegue", "Morre querendo"},
                        {"Valencia", "Sporting", "Manchester United"},
                        {"Chelsea", "Liverpool FC", "AC Milan"},
                        {"Arsenal", "Barcelona FC", "PSG"},
                        {"Arsenal", "Real Madrid", "Manchester City"},
                        {"5", "10", "16"},
                        {"Mickey", "Mário", "Pocoyo"},
                        {"Margarida", "Ana Bela", "Pocahontas"},
                        {"Brasil", "Moçambique", "Timor-Leste"},
                        {"Quantro", "Três", "Duas"},
                        {"K","I","E"},
                        {"Zeus", "Hades", "Hefestos"},
                        {"Software", "Malware", "Firewall"},
                        {"2000", "2002","2011"},
                        {"2010", "2008", "2011"},
                        {"Mario", "Sonia", "Pocoyo"},
                        {"Mickey", "Spider-man", "Hulk"},
                        {"Um planeta", "Uma lua", "Um satélite"},
                        {"Três", "Duas", "Uma"},
                        {"França","Alemanha","Espanha"}
        };

        public static string[] respostas = new string[]{
                     "Cain",
                     "Cronus",
                     "E",
                     "Barack Obama",
                     "Linguagem C",
                     "26",
                     "Imperatriz",
                     "Nove caudas",
                     "Kakashi",
                     "Dumbo",
                     "Três estados",
                     "H2O",
                     "Uma",
                     "Pratica a acção",
                     "Sul",
                     "Norte",
                     "10",
                     "18",
                     "Work",
                     "Uma série",
                     "17",
                     "24",
                     "366",
                     "Dionísio",
                     "-4",
                     "4",
                     "The climb",
                     "Who says",
                     "Feijão",
                     "2001",
                     "Tudo perde",
                     "Real Madrid",
                     "Barcelona FC",
                     "Liverpool FC",
                     "Barcelona FC",
                     "20",
                     "Ken",
                     "Minnie",
                     "Angola",
                     "Cinco",
                     "J",
                     "Poseidon",
                     "Hardware",
                     "2001",
                     "2009",
                     "Sonic",
                     "Mario",
                     "Uma estrela",
                     "Quatro",
                     "Portugal"
        };

    }
}
