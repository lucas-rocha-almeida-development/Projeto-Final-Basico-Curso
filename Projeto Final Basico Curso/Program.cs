using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Final_Basico_Curso
{
    internal class Program
    { //1º criar um struct
        public struct DadosCadastraisStruct
        {
            //declaração deve ser publica, justamente para poder utiliza-las fora da estrutura
            //não sendo publicas, so consigmos utiliza-las dentro da estrutura
            public string Nome;
            public DateTime DataDeNascimento;
            public string NomeDarua;
            public UInt32 NumeroCasa;

        }
        //2º criando um enum chamado resultado_E
        public enum ChamadoResultado_e
        {
            Successo = 0,
            Sair = 1,
            Excecao= 2
        }
        //3º criando primeiro metodo
        public static void MetodoMostraMensagem(string ChamadaMensagem)
        {
            Console.WriteLine(ChamadaMensagem);
            Console.WriteLine("Pressione qualquer tecla para continuar");
            Console.ReadKey();
            Console.Clear();


        }
        //4º Criando segundo metodo (PEGA STRING DIGITADAS PELO USUARIO)
        public static ChamadoResultado_e PegaStringDigitada (ref string MinhaString,string mensagem)//prenchida dentro e depois retornada fora
        {
            //vou criar uma variavel utilizando o metodo Resultado_e
            ChamadoResultado_e Retorno;
            Console.WriteLine(mensagem);
            //vou criar um variavel string chamada temp ( temporaria)
            string temp = Console.ReadLine();//pegar oque foi digitado pelo usuario
            if (temp == "s" || temp == "S")
                Retorno = ChamadoResultado_e.Sair;
            //atenção, programa ira capturar oque usuario digitou, caso seja S, basicamente ira sair do programa
            //programa sera encerrado.

            // CASO CONTRARIO, SEJA DIGITADO "C", podemos seguir com fluxo do programa.
            else
            {
                MinhaString= temp;//caso o usuario não tenha pressionado S, iremos pegar o valor digitado e aplicar
                //nesse variavel (minhaString)
                Retorno = ChamadoResultado_e.Successo;

            } Console.Clear();
            return Retorno;
        }
        //CRIANDO TERCEIRO METODO QUE PEGA A DATA EM QUE USUARIO DIGITOU
        public static ChamadoResultado_e PegaDataUsuario(ref DateTime DataDoUsuario, string mensagem)
        {
            //criando novamente uma variavel do tipo "resultado_e"
            ChamadoResultado_e retorno;
            do
            {
                 //teremos que ter um tratamento de excessao aqui dentro (try & catch
                 try
                {
                    Console.WriteLine(mensagem);
                    string temp = Console.ReadLine();
                    //vamos check se a variavel digitada seja "s"
                    if (temp == "s" || temp == "S")
                        retorno = ChamadoResultado_e.Sair;

                    else
                    {
                       DataDoUsuario = Convert.ToDateTime(temp);//caso ocorra uma excessao na conversão da data, o bloco
                        //catch sera executado.
                        retorno = ChamadoResultado_e.Successo;
                    }
                    
                } catch (Exception e) {
                Console.WriteLine("EXCESSÃO: " + e.Message);
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                    //VAMOS ATRIBUIR NOSSA VARIVEL EXCESSAO
                    retorno = ChamadoResultado_e.Excecao;
                
                 }

            } while (retorno == ChamadoResultado_e.Excecao);//OU SEJA, enquanto existir a excessao, devemos fazer o loop
            //ate o usuario chegar no metodo Sucesso, justamente porque o S, não chega nem nessa parte do comando.
            //tentando capturar a data correta.
            Console.Clear();
            return retorno;// iremos retornar o conteudo da variavel retorno.



        }

        //ULTIMO METODO DE CAPTURAR NUMERO DA RESIDENCIA
        //------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------
        public static ChamadoResultado_e PegaUInt32 (ref UInt32 Numero, string mensagem)
        {
            //criando novamente uma variavel do tipo "resultado_e"
            ChamadoResultado_e retorno;
            do
            {
                //teremos que ter um tratamento de excessao aqui dentro (try & catch
                try
                {
                    Console.WriteLine(mensagem);
                    string temp = Console.ReadLine();
                    //vamos check se a variavel digitada seja "s"
                    if (temp == "s" || temp == "S")
                        retorno = ChamadoResultado_e.Sair;

                    else
                    {
                        Numero = Convert.ToUInt32(temp);//caso ocorra uma excessao na conversão da data, o bloco
                        //catch sera executado.
                        retorno = ChamadoResultado_e.Successo;
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("EXCESSÃO: " + e.Message);
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                    //VAMOS ATRIBUIR NOSSA VARIVEL EXCESSAO
                    retorno = ChamadoResultado_e.Excecao;

                }

            } while (retorno == ChamadoResultado_e.Excecao);//OU SEJA, enquanto existir a excessao, devemos fazer o loop
            //ate o usuario chegar no metodo Sucesso, justamente porque o S, não chega nem nessa parte do comando.
            //tentando capturar a data correta.
            Console.Clear();
            return retorno;// iremos retornar o conteudo da variavel retorno.



        }

        //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX METODO PARA CADASTRAR DE FATO UM USUARIO NO PROGRAMAXXXXXXXXXXXXXXXXXXXXXX
        public static void CadastramentoUsuario (ref List<DadosCadastraisStruct> ListaDeUsuarios)
        {
            //metodo responsavel por cadastrar usuarios no programa
            //sera preenchida e depois sera reutilizada no Main
            DadosCadastraisStruct cadastroUsuario;//minha variavel chamada de cadastroUsuario.
            cadastroUsuario.Nome = "";
            cadastroUsuario.NomeDarua = "";
            cadastroUsuario.DataDeNascimento = new DateTime();//PRECISO CHAMAR O NEW MAIS METODO DATETIME
            cadastroUsuario.NumeroCasa= 0;
            //vamos utilizar os metodos criados acima, pegarstring=> ira pegar o que usuario digitou (C,S ou outra letra)
            if (PegaStringDigitada(ref cadastroUsuario.Nome, "Digite o nome completo ou digite S para SAIR") != ChamadoResultado_e.Successo)
                //acima estamos pegando oque o nome do usuario e armazenando na variavel "cadastroUsuario.nome, caso seja algo diferente do resultado
                // sucesso iremos finalizar o programa, sendo SUCESSO, IREMOS PEDIR PARA PEGAR O PROXIMO DADO (NOME RUA,DATANASCIMENTO E NUMERO DA CASA).
                return;
            if (PegaDataUsuario(ref cadastroUsuario.DataDeNascimento, "Digite sua data de nascimento:DD/MM/YYYY: ou digite S para SAIR:") != ChamadoResultado_e.Successo)
                return;
            if(PegaStringDigitada(ref cadastroUsuario.NomeDarua,"Digite o nome da rua ou digite s para sair : ")!= ChamadoResultado_e.Successo)
                return;
            if(PegaUInt32(ref cadastroUsuario.NumeroCasa,"Digite o numero da residencia ou digite s para sair : ")!= ChamadoResultado_e.Successo)
                return;

            //***********************************APOS USUARIO DIGITAR TODOS OS DADOS, IREMOS GRAVA-LOS NA NOSSA LISTA*******************
            ListaDeUsuarios.Add(cadastroUsuario);//bingo, lista de usuario gravada e passada para dentro do sistema (cadastroUsurio);

        }
        static void Main(string[] args) //metodos main
        {
            //passo entre <minha estrutura,que ira retornar os dados que estão dentro>

            //ATENÇÃO:lista sera criada para armazenar todos os dados dos usuarios que forem cadastrado
            List <DadosCadastraisStruct> ListaDeUsuarios = new List <DadosCadastraisStruct>();
            string opcao = ""; //=> opção que dara opção de cadastrar e sair do programa

            //2º dentro do main, posso criar um laço DO WHILE
            do {
                //1º mensagem para usuario
                Console.WriteLine("Digite C para CADASTRAR um novo USUARIO ou S para  SAIR do PROGRAMA: ");
                opcao= Console.ReadKey(true).KeyChar.ToString().ToLower();//ira ler a opção que usuario digitar S ou C, ou ate mesmo outra letra
                //acima ira capturar o digito, converte para string e converter para minusculo

                //primeira condição irei fazer com aplicação do if
                if (opcao == "c") {

                    CadastramentoUsuario(ref ListaDeUsuarios);//listadeUsuarios, sera o parametro de entrada para nosso metodo.
                    //sendo opção igual c, irei cadastrar um novo usuario
                }

                else if (opcao == "s")
                {
                    //quando usuario pressionar "S" o sistema ira ativar o metodoMostrarMensagem
                    MetodoMostraMensagem("Encerrando o programa");
                }
                    

                else
                        {
                    //quando usuario digirar uma tecla que seja diferente de "C" ou "S"
                    MetodoMostraMensagem("Opção desconhecida,Pressione C para cadastrar ou S para sair!!");
                }
            }
            
            
            while(/*aqui dentro ficara a condição*/ opcao != "s");
            //enquanto opção for diferente de "S" o loop ira continuar sendo executado,justamente porque quando o usuario
            //digitar a letra "s" basicamente ira querer usar opção sair.
        }
    }
}
