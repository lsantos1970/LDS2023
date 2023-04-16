

using System.Data;

namespace AnaliseImagens
{
    class Controller
    {
        //Atributos da classe 
        private View view;
        private Model model; 
        private string? command;

        //Construtor sem parâmetros
        public Controller() {
            model = new Model(this, view);
            view = new View(this, model);
            command = null;    
        }

        public void IniciarPrograma()
        {
      
            view.ApresentarInstrucoes();
            LerComando();
       
        }

        private void LerComando()
        {
            view.ImprimirPromptInserirInput();
            command = Console.ReadLine();

            try
            {
                model.ValidarComando(command);
                model.ExecutarComando(command);
                view.ApresentarResultados();

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
                Console.WriteLine(excp.Message);
                LerComando();
            }
            else if (excp is OperationError)
            {
                view.ImprimirMensagemErro(excp.Message);
            }


        }

    }
}
