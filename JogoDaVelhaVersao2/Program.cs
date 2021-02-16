using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaVelhaVersao2
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] tabuleiro = new char[3, 3];
            int linhaj1, linhaj2, colunaj1, colunaj2;
            bool podecolocarpeca = false;
            char resultadodojogo;
            string nomejog1 = "", nomejog2 = "";

            // Criando a matriz (tabuleiro) e preenchendo sua posições com '-'
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    tabuleiro[i, j] = '-';
                }
            }

            // Imprimindo nome do jogo
            Console.WriteLine(">>> JOGO DA VELHA <<<\n");
            //Solicitando o nome dos jogadores e garantindo que o nome seja informado
            Console.WriteLine("Informe o nome dos jogadores:\n");
            do
            {
                Console.Write("Jogador 1 (será representado por 'X'): ");
                nomejog1 = Console.ReadLine();
                if (nomejog1 == "")
                {
                    Console.WriteLine("\nPor favor, informe um nome para o jogador.");
                }
            } while (nomejog1 == "");
            Console.Write("\n");
            do
            {
                Console.Write("Jogador 2 (será representado por 'O'): ");
                nomejog2 = Console.ReadLine();
                if (nomejog2 == "")
                {
                    Console.WriteLine("\nPor favor, informe um nome para o jogador.");
                }
            } while (nomejog2 == "");

            // Solicitando aos jogadores as coordenadas que desejam marcar(jogar)
            do
            {
                // Jogador 1
                do
                {
                    Console.WriteLine("\n" + nomejog1 + ", informe a posição que deseja (linha e coluna) OBS: As coordenadas vão de 0 à 2!!: \n");
                    do
                    {
                        Console.Write("Linha: ");

                        int number;
                        var linhatemp = Console.ReadLine();
                        bool valorValido = Int32.TryParse(linhatemp, out number);
                        linhaj1 = 0;
                        while (!valorValido)
                        {
                            Console.WriteLine("As coordenadas precisam ser 0, 1 ou 2!!");
                            Console.Write("Linha: ");
                            var novoNumero = Console.ReadLine();
                            valorValido = Int32.TryParse(novoNumero, out number);

                            if (valorValido)
                            {
                                linhaj1 = int.Parse(novoNumero);
                            }

                            if (linhaj1 != 0 && linhaj1 != 1 && linhaj1 != 2)
                            {
                                valorValido = false;
                            }
                            linhatemp = novoNumero;
                        }

                        linhaj1 = int.Parse(linhatemp);
                        if (linhaj1 != 0 && linhaj1 != 1 && linhaj1 != 2)
                        {
                            Console.WriteLine("As coordenadas precisam ser 0, 1 ou 2!!");
                        }
                    } while (linhaj1 != 0 && linhaj1 != 1 && linhaj1 != 2); //garantindo que a coordenada informada para linha seja uma das que contem no tabuleiro

                    do
                    {
                        Console.Write("Coluna: ");

                        int number;
                        var colunatemp = Console.ReadLine();
                        bool valorValido = Int32.TryParse(colunatemp, out number);
                        colunaj1 = 0;
                        while (!valorValido)
                        {
                            Console.WriteLine("As coordenadas precisam ser 0, 1 ou 2!!");
                            Console.Write("Coluna: ");
                            var novoNumero = Console.ReadLine();
                            valorValido = Int32.TryParse(novoNumero, out number);

                            if (valorValido)
                            {
                                colunaj1 = int.Parse(novoNumero);
                            }

                            if (colunaj1 != 0 && colunaj1 != 1 && colunaj1 != 2)
                            {
                                valorValido = false;
                            }
                            colunatemp = novoNumero;
                        }
                        colunaj1 = int.Parse(colunatemp);
                        if (colunaj1 != 0 && colunaj1 != 1 && colunaj1 != 2)
                        {
                            Console.WriteLine("As coordenadas precisam ser 0, 1 ou 2!!");
                        }

                    } while (colunaj1 != 0 && colunaj1 != 1 && colunaj1 != 2); //garantindo que a coordenada informada para coluna seja uma das que contem no tabuleiro
                    podecolocarpeca = posicao_disponivel(tabuleiro, linhaj1, colunaj1); //chamando a função que verifica se a posição informada está disponível(livre) no tabuleiro

                } while (podecolocarpeca == false); //garantindo que enquanto o jogador não escolher uma posição disponível(livre), será pedido para que ele informe outra posição
                {
                    tabuleiro[linhaj1, colunaj1] = 'X'; //preenchendo a posição escolhida com X(que representa o jogador1)
                    imprimir_Jogo(tabuleiro); //chamando a função que imprime o tabuleiro na tela
                    resultadodojogo = verifica_Status(tabuleiro); //chamando a função que verifica o status do jogo(se já acabou ou se continua)
                }

                if (verifica_Status(tabuleiro) != '1' && verifica_Status(tabuleiro) != '0') //garantindo que se o jogador 1 não ganhou e se não houve empate, o jogo continua e pede para que o jogador 2 faça sua jogada
                {
                    //Jogador 2
                    do
                    {
                        Console.WriteLine("\n" + nomejog2 + ", informe a posição que deseja (linha e coluna) OBS: As coordenadas vão de 0 à 2!!: \n");
                        do
                        {
                            Console.Write("Linha: ");
                            int number;
                            var linhatemp = Console.ReadLine();
                            bool valorValido = Int32.TryParse(linhatemp, out number);
                            linhaj2 = 0;
                            while (!valorValido)
                            {
                                Console.WriteLine("As coordenadas precisam ser 0, 1 ou 2!!");
                                Console.Write("Linha: ");
                                var novoNumero = Console.ReadLine();
                                valorValido = Int32.TryParse(novoNumero, out number);

                                if (valorValido)
                                {
                                    linhaj2 = int.Parse(novoNumero);
                                }

                                if (linhaj2 != 0 && linhaj2 != 1 && linhaj2 != 2)
                                {
                                    valorValido = false;
                                }
                                linhatemp = novoNumero;
                            }

                            linhaj2 = int.Parse(linhatemp);
                            if (linhaj2 != 0 && linhaj2 != 1 && linhaj2 != 2)
                            {
                                Console.WriteLine("As coordenadas precisam ser 0, 1 ou 2!!");
                            }

                        } while (linhaj2 != 0 && linhaj2 != 1 && linhaj2 != 2); //garantindo que a coordenada informada para linha seja uma das que contem no tabuleiro

                        do
                        {
                            Console.Write("Coluna: ");
                            int number;
                            var colunatemp = Console.ReadLine();
                            bool valorValido = Int32.TryParse(colunatemp, out number);
                            colunaj2 = 0;
                            while (!valorValido)
                            {
                                Console.WriteLine("As coordenadas precisam ser 0, 1 ou 2!!");
                                Console.Write("Coluna: ");
                                var novoNumero = Console.ReadLine();
                                valorValido = Int32.TryParse(novoNumero, out number);

                                if (valorValido)
                                {
                                    colunaj2 = int.Parse(novoNumero);
                                }

                                if (colunaj2 != 0 && colunaj2 != 1 && colunaj2 != 2)
                                {
                                    valorValido = false;
                                }
                                colunatemp = novoNumero;
                            }
                            colunaj2 = int.Parse(colunatemp);
                            if (colunaj2 != 0 && colunaj2 != 1 && colunaj2 != 2)
                            {
                                Console.WriteLine("As coordenadas precisam ser 0, 1 ou 2!!");
                            }

                        } while (colunaj2 != 0 && colunaj2 != 1 && colunaj2 != 2); //garantindo que a coordenada informada para coluna seja uma das que contem no tabuleiro
                        podecolocarpeca = posicao_disponivel(tabuleiro, linhaj2, colunaj2); //chamando a função que verifica se a posição informada está disponível(livre) no tabuleiro

                    } while (podecolocarpeca == false); //garantindo que enquanto o jogador não escolher uma posição disponível(livre), será pedido para que ele informe outra posição
                    {
                        tabuleiro[linhaj2, colunaj2] = 'O'; //preenchendo a posição escolhida com O(que representa o jogador2)
                        imprimir_Jogo(tabuleiro); //chamando a função que imprime o tabuleiro na tela
                        resultadodojogo = verifica_Status(tabuleiro); //chamando a função que verifica o status do jogo(se já acabou ou se continua)
                    }
                }

            } while (verifica_Status(tabuleiro) != '1' && verifica_Status(tabuleiro) != '2' && verifica_Status(tabuleiro) != '0'); //garantindo que se o jogador 1 e 2 não ganharam e se não houve empate, o jogo continua e pede para que o jogador 1 jogue novamente

            //Imprimindo o resultado do jogo através da função "resultadodojogo" 
            if (resultadodojogo == '1') //Se resultado foi 1, então jogador 1 vence
            {
                Console.WriteLine("\n******************************************");
                Console.WriteLine("\n" + nomejog1 + " venceu!");
                Console.WriteLine("\nPressione qualquer tecla para sair...");
            }
            else if (resultadodojogo == '2') //Se resultado foi 2, então jogador 2 vence
            {
                Console.WriteLine("\n******************************************");
                Console.WriteLine("\n" + nomejog2 + " venceu!");
                Console.WriteLine("\nPressione qualquer tecla para sair...");
            }
            else if (resultadodojogo == '0') //Se resultado foi 0, então o jogo empatou
            {
                Console.WriteLine("\n******************************************");
                Console.WriteLine("\nO jogo Empatou!");
                Console.WriteLine("\nPressione qualquer tecla para sair...");
            }
            Console.ReadKey();
        }


        //Funções
        static void imprimir_Jogo(char[,] matriz) //imprime na tela como está o tabuleiro após cada jogada
        {
            Console.WriteLine("");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(matriz[i, j] + "\t");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");
        }


        static bool posicao_disponivel(char[,] matriz, int linha, int coluna) //verifica se a posição que os jogadores escolheram (linha e coluna) está disponível, ou seja, se ainda não foi marcada
        {
            if (matriz[linha, coluna] == '-')
            {
                return (true);
            }
            else
            {
                Console.WriteLine("\n=> Posição indisponível, escolha outra coordenada!!!\n");
                return (false);
            }
        }


        static char verifica_Status(char[,] matriz) //verifica e identifica o vencedor ou se houve empate
        {
            if (matriz[0, 0] == 'X' && matriz[0, 0] == matriz[0, 1] && matriz[0, 0] == matriz[0, 2])
            {
                return ('1');
            }
            else if (matriz[0, 0] == 'X' && matriz[0, 0] == matriz[1, 0] && matriz[0, 0] == matriz[2, 0])
            {
                return ('1');
            }
            else if (matriz[0, 0] == 'X' && matriz[0, 0] == matriz[1, 1] && matriz[0, 0] == matriz[2, 2])
            {
                return ('1');
            }
            else if (matriz[1, 0] == 'X' && matriz[1, 0] == matriz[1, 1] && matriz[1, 0] == matriz[1, 2])
            {
                return ('1');
            }
            else if (matriz[2, 0] == 'X' && matriz[2, 0] == matriz[2, 1] && matriz[2, 0] == matriz[2, 2])
            {
                return ('1');
            }
            else if (matriz[2, 0] == 'X' && matriz[2, 0] == matriz[1, 1] && matriz[2, 0] == matriz[0, 2])
            {
                return ('1');
            }
            else if (matriz[0, 1] == 'X' && matriz[0, 1] == matriz[1, 1] && matriz[0, 1] == matriz[2, 1])
            {
                return ('1');
            }
            else if (matriz[0, 2] == 'X' && matriz[0, 2] == matriz[1, 2] && matriz[0, 2] == matriz[2, 2])
            {
                return ('1');
            }
            else if (matriz[0, 0] == 'O' && matriz[0, 0] == matriz[0, 1] && matriz[0, 0] == matriz[0, 2])
            {
                return ('2');
            }
            else if (matriz[0, 0] == 'O' && matriz[0, 0] == matriz[1, 0] && matriz[0, 0] == matriz[2, 0])
            {
                return ('2');
            }
            else if (matriz[0, 0] == 'O' && matriz[0, 0] == matriz[1, 1] && matriz[0, 0] == matriz[2, 2])
            {
                return ('2');
            }
            else if (matriz[1, 0] == 'O' && matriz[1, 0] == matriz[1, 1] && matriz[1, 0] == matriz[1, 2])
            {
                return ('2');
            }
            else if (matriz[2, 0] == 'O' && matriz[2, 0] == matriz[2, 1] && matriz[2, 0] == matriz[2, 2])
            {
                return ('2');
            }
            else if (matriz[2, 0] == 'O' && matriz[2, 0] == matriz[1, 1] && matriz[2, 0] == matriz[0, 2])
            {
                return ('2');
            }
            else if (matriz[0, 1] == 'O' && matriz[0, 1] == matriz[1, 1] && matriz[0, 1] == matriz[2, 1])
            {
                return ('2');
            }
            else if (matriz[0, 2] == 'O' && matriz[0, 2] == matriz[1, 2] && matriz[0, 2] == matriz[2, 2])
            {
                return ('2');
            }
            else if (matriz[0, 0] != '-' && matriz[0, 1] != '-' && matriz[0, 2] != '-' && matriz[1, 0] != '-' && matriz[1, 1] != '-' && matriz[1, 2] != '-' && matriz[2, 0] != '-' && matriz[2, 1] != '-' && matriz[2, 2] != '-')
            {
                return ('0');
            }
            else
            {
                return ('3');
            }

        }
    }
}
