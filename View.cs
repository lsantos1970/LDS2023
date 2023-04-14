

namespace AnaliseImagens
{
    class View
    {
        //Atributos
        private Controller controller;
        private Model model;


        //Construtor
        public View(Controller _controller, Model _model) {
            controller = _controller;
            model = _model; 
        }

        public void ApresentarInstrucoes(List <string> availableCommands) { }

        public void HandleException(Exception excp) {
            if (excp is NoCommandFound)
            {
                Console.WriteLine(excp.Message);
                Environment.Exit(ExitCodes.ERROR_NO_COMMAND);
            }
            else if (excp is CommandNotValid)
            {
                Console.WriteLine(excp.Message);
                Environment.Exit(ExitCodes.ERROR_INVALID_COMMAND);
            }
            else if (excp is InvalidPath)
            {
                Console.WriteLine(excp.Message);
                Environment.Exit(ExitCodes.ERROR_INVALID_IMAGE);

            }
            else if (excp is OperationError)
            {
                Console.WriteLine(excp.Message);
                Environment.Exit(ExitCodes.ERROR_OPERATION_NOT_SUCCESSFUL);
            }

           
        }

      

        public void ApresentarResultados() {

            model.FornecerResultado();
            Environment.Exit(ExitCodes.SUCCESS);

        }

        



    }
}