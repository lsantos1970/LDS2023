

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
            view = new View(this); // Pass the Controller reference to the View
            model = new Model();
            view.Model = model; // Set the Model reference in the View
        }

        public void IniciarPrograma()
        {
      
            view.ApresentarInstrucoes();
            view.ImprimirPromptInserirInput("");
            string command = Console.ReadLine();
            LerComando(command);
       
        }

        private void LerComando(string command)
        {

            try
            {
               model.ValidarComando(command);
               model.ExecutarComando(command);
                
            } catch (Exception excp)
            {
              view.HandleException(excp);
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


