

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
            model = new Model(view);
            view = new View(this, model);  
        }

        public void IniciarPrograma()
        {
            view.ApresentarInstrucoes();

            string command = "";
            do
            {
                command = view.ImprimirPromptInserirInput("");
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
                string cmd = "", path = "";
                model.ValidarComando(command, ref cmd, ref path);
                model.ExecutarComando(cmd, path);
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

                string command = view.ImprimirPromptInserirInput(excp.Message + "\n");
                LerComando(command);
            }
            else if (excp is OperationError)
            {
                view.ImprimirMensagemErro(excp.Message);
            }


        }

    }
}
