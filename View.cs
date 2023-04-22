

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


        public void ApresentarInstrucoes()
        {

            List<string> availableCmds = model.ListarComandos();
        }

        public string ImprimirPromptInserirInput(string msg)
        {
            Console.WriteLine(msg + "Introduza um comando. Para sair, pressione 'E':");
            string input = Console.ReadLine();
            return input;
        }

   
      

        public void ApresentarResultados() {

            Environment.Exit(ExitCodes.SUCCESS);

        }


        public void HandleException(Exception excp)
        {
            if (excp is NoCommandFound || excp is CommandNotValid || excp is InvalidPath)
            {

                string command = ImprimirPromptInserirInput(excp.Message + "\n");
                controller.LerComando(command);
            }
            else if (excp is OperationError)
            {
                Console.WriteLine(excp.Message);
                Environment.Exit(ExitCodes.ERROR_OPERATION_NOT_SUCCESSFUL);
            }


        }

        public void ImprimirMensagemDespedida()
        {
            Console.WriteLine("A terminar sessão, até breve!");
            Environment.Exit(ExitCodes.SUCCESS);
        }




    }
}