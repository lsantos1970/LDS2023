

using AnaliseImagens;
using System.Data;
namespace AnaliseImagens
{
    class Controller
    {
        //Atributos da classe 
        private View view;
        private Model model; 

        //Construtor sem parâmetros
        public Controller() {
            view = new View(this); 
            model = new Model();
            view.Model = model; 
        }


        /*
         * View imprime as instruções com os comandos disponíveis. 
         * View imprime um prompt a indicar ao utilizador para introduzir o comando.
         * Controller faz a leitura do input do utilizador e passa o comando para o método auxiliar interno à classe 'LerComando()'
        */
        public void IniciarPrograma()
        {
      
            view.ApresentarInstrucoes();
            view.ImprimirPromptInserirInput("");
            string command = Console.ReadLine();
            LerComando(command);
       
        }

        /*
         *   Modelo executa comando. 
         *   Podem ocorrer excepções que são geridas pelo método 'HandleException()' do Controller
        */
        private void LerComando(string command)
        {

            try
            {
               model.ExecutarComando(command);
                
            } catch (Exception excp)
            {
                HandleException(excp);
            }

            
        }


        /*
         * Faz a gestão de excepções que possam ser lançadas pelo modelo. 
         * Para as excepções NoCommandFound, CommandNotValid ou InvalidPath:
         *  - View imprime um prompt com uma mensagem de erro específica de cada excepção e solicita novamente ao utilizador para inserir o comando
         *  - Controller faz a leitura do comando inserido
         *  
         * Para a excepção OperationError:
         *  - View imprime mensagem de erro e execução do programa termina
         */

        private void HandleException(Exception excp)
        {
            if (excp is NoCommandFound || excp is CommandNotValid || excp is InvalidPath)
            {
                view.ImprimirPromptInserirInput(excp.Message + "\n");
                string command = Console.ReadLine();
                LerComando(command);
            }
            else if (excp is OperationError)
            {
                view.ImprimirMensagemErro(excp.Message);
            }


        }


     
    }
}


