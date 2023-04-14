

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

            List<string> availableCmds = model.ListarComandos();
            view.ApresentarInstrucoes(availableCmds);

            Console.WriteLine("Introduza um comando:");
            command = Console.ReadLine();

            try
            {
               model.ValidarComando(command);
               model.ExecutarComando(command);
               view.ApresentarResultados();
                
            } catch (Exception excp)
            {
              view.HandleException(excp);
            }

            
        }


     
    }
}
