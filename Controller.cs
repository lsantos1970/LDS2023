

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
            command = view.ImprimirPromptInserirInput();

            if(command.Equals("E"))
            {
                view.ImprimirMensagemDespedida();
                return;
            } 

            try
            {
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
