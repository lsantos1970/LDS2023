

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

        public void ImprimirPromptInserirInput(string msg)
        {
            Console.WriteLine(msg + "Introduza um comando. Para sair, pressione 'E':");
        }

        public void ApresentarInstrucoes() {

            List<string> availableCmds = model.ListarComandos();
        }
      

        public void ApresentarResultados() {

            model.FornecerResultado();
            Environment.Exit(ExitCodes.SUCCESS);

        }

        public void ImprimirMensagemErro(string message)
        {
            Console.WriteLine(message);
            Environment.Exit(ExitCodes.ERROR_OPERATION_NOT_SUCCESSFUL);
        }

        public void ImprimirMensagemDespedida()
        {
            Console.WriteLine("A terminar sessão, até breve!");
            Environment.Exit(ExitCodes.SUCCESS);
        }




    }
}