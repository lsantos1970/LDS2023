

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
            view = new View(this, model);
            model = new Model(view);
        }

        public void IniciarPrograma()
        {
            view.ApresentarInstrucoes();
            string command = view.ImprimirPromptInserirInput("");
            LerComando(command);
            
        }

        public void LerComando(string command)
        {
            
            if (command.Equals("E"))
            {
                view.ImprimirMensagemDespedida();
            } else
            {
                model.ExecutarComando(command);
            }

        }

        

    }
}
