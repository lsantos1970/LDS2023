using System.IO;

namespace AnaliseImagens
{
    class Model
    {
        //Atributos
        private List<string> listCmds;
        private Controller controller;
        private View view;

        //Construtor
        public Model(Controller _controller, View _view)
        {
            controller = _controller;
            view = _view;
        }

        public List<string> ListarComandos() 
        {

            return listCmds;
        }

        public void ExecutarComando(string commandReceived) { }


        public void FornecerResultado() { }
        
     }

}