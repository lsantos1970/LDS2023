using System.IO;

namespace AnaliseImagens
{
    class Model
    {
        //Atributos
        private List<string> listCmds;
        private View view;

        //Construtor
        public Model(View _view)
        {
            view = _view;
        }

        public List<string> ListarComandos() 
        {

            return listCmds;
        }


        public void ValidarComando(string commandReceived, ref string cmd, ref string path) { }
        public void ExecutarComando(string cmd, string path) {

            view.ApresentarResultados();
        }


        
     }

}