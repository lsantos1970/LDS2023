

using AnaliseImagens;
using System.Data;
using System.Security.Cryptography;

namespace AnaliseImagens
{
    class Controller
    {
        //Atributos da classe 
        private View view;
        private Model model; 

        //Construtor sem parâmetros
        public Controller() {
            model = new Model(view);
            view = new View(model);
        }

        public void IniciarPrograma()
        {
      
            view.ApresentarInstrucoes();

            string command = "";

            do
            {
                view.ImprimirPromptInserirInput("");
                command = Console.ReadLine();
                LerComando(command);
            } while (!command.Equals("E"));
            
       
        }

        private void LerComando(string command)
        {

            if(command.Equals("E"))
            {
                view.ImprimirMensagemDespedida();
                return;
            } 

            try
            {
                model.ExecutarComando(command);
          
            }
            catch (Exception excp)
            {
                HandleException(excp);
            }

        }

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


